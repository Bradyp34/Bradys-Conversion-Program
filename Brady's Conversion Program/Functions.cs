using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Brady_s_Conversion_Program.Form1;
using System.Data.SqlClient;
using Brady_s_Conversion_Program.Models;
using Brady_s_Conversion_Program.ModelsA;
using Brady_s_Conversion_Program.ModelsB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Brady_s_Conversion_Program
{
    public class Functions {
        public interface ILogger {
            void Log(string message);
        }

        public class FileLogger : ILogger {
            private readonly string _filePath;

            public FileLogger(string filePath) {
                _filePath = filePath;
            }

            public void Log(string message) {
                using (var sw = new StreamWriter(_filePath, true)) {
                    sw.WriteLine(message);
                }
            }
        }

        public static string ConvertToDB(string connection, string FFPMConnection, string EyeMDConnection, bool ffpm, bool eyemd) {
            try {
                // have log file ready to record failings and issues
                using (StreamWriter sw = new StreamWriter("../../../../LogFiles/log.txt")) {
                    ILogger logger = new FileLogger("../../../../LogFiles/log.txt");

                    // Using block to ensure disposal of DbContexts
                    using (var convDbContext = new FoxfireConvContext(connection))
                    using (var ffpmDbContext = new FfpmContext(FFPMConnection))
                    using (var eyeMDDbContext = new EyeMdContext(EyeMDConnection)) {
                        // Start with FFPM only, do EyeMD later

                        // Testing Connections
                        convDbContext.Database.OpenConnection();
                        if (ffpm == true)
                            ffpmDbContext.Database.OpenConnection();
                        if (eyemd == true)
                            eyeMDDbContext.Database.OpenConnection();

                        if (ffpm == true) {
                            ConvertFFPM(convDbContext, ffpmDbContext, logger);
                        }

                        // Save changes if any modifications were made
                        convDbContext.SaveChanges();
                        ffpmDbContext.SaveChanges();
                        eyeMDDbContext.SaveChanges();

                        // EF Core automatically handles connection closing when DbContext is disposed
                    }
                }
            }
            catch (Exception e) {
                return "Database Upload Failed.\n" + e + "\n";
            }
            return "Operation Successful";
        }

        public static void ConvertFFPM(FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            // Convert Patients
            BatchProcessEntities(convDbContext.Patients.ToList(), PatientConvert, ffpmDbContext, logger);

            // Convert AccountXrefs
            BatchProcessEntities(convDbContext.AccountXrefs.ToList(), ConvertAccountXref, ffpmDbContext, logger);

            // Convert Addresses
            BatchProcessEntities(convDbContext.Addresses.ToList(), ConvertAddress, ffpmDbContext, logger);

            // Convert Appointments
            BatchProcessEntities(convDbContext.Appointments.ToList(), ConvertAppointment, ffpmDbContext, logger);

            // Convert AppointmentTypes
            BatchProcessEntities(convDbContext.AppointmentTypes.ToList(), ConvertAppointmentType, ffpmDbContext, logger);

            // Convert Employers
            BatchProcessEntities(convDbContext.Employers.ToList(), ConvertEmployer, ffpmDbContext, logger);

            // Convert Insurances
            BatchProcessEntities(convDbContext.Insurances.ToList(), ConvertInsurance, ffpmDbContext, logger);

            // Convert Locations
            BatchProcessEntities(convDbContext.Locations.ToList(), ConvertLocation, ffpmDbContext, logger);

            // Convert Names
            BatchProcessEntities(convDbContext.Names.ToList(), ConvertName, ffpmDbContext, logger);

            // Convert PatientAlerts
            BatchProcessEntities(convDbContext.PatientAlerts.ToList(), ConvertPatientAlert, ffpmDbContext, logger);

            // Convert PatientDocuments
            BatchProcessEntities(convDbContext.PatientDocuments.ToList(), ConvertPatientDocument, ffpmDbContext, logger);

            // Convert PatientInsurances
            BatchProcessEntities(convDbContext.PatientInsurances.ToList(), ConvertPatientInsurance, ffpmDbContext, logger);

            // Convert PatientNotes
            BatchProcessEntities(convDbContext.PatientNotes.ToList(), ConvertPatientNote, ffpmDbContext, logger);

            // Convert Phones
            BatchProcessEntities(convDbContext.Phones.ToList(), ConvertPhone, ffpmDbContext, logger);

            // Convert Providers
            BatchProcessEntities(convDbContext.Providers.ToList(), ConvertProvider, ffpmDbContext, logger);

            // Convert Recalls
            BatchProcessEntities(convDbContext.Recalls.ToList(), ConvertRecall, ffpmDbContext, logger);

            // Convert RecallTypes
            BatchProcessEntities(convDbContext.RecallTypes.ToList(), ConvertRecallType, ffpmDbContext, logger);

            // Convert Referrals
            BatchProcessEntities(convDbContext.Referrals.ToList(), ConvertReferral, ffpmDbContext, logger);

            // Convert SchedCodes
            BatchProcessEntities(convDbContext.SchedCodes.ToList(), ConvertSchedCode, ffpmDbContext, logger);
        }

        public static void BatchProcessEntities<T>(IEnumerable<T> entities, Action<T, FfpmContext, ILogger> convertFunction, FfpmContext ffpmDbContext, ILogger logger) {
            int batchSize = 100; // Define an appropriate batch size
            int numberOfRecords = entities.Count();
            int numberOfBatches = (numberOfRecords / batchSize) + (numberOfRecords % batchSize > 0 ? 1 : 0);

            for (int batchNumber = 0; batchNumber < numberOfBatches; batchNumber++) {
                var batch = entities.Skip(batchNumber * batchSize).Take(batchSize).ToList();

                using (var transaction = ffpmDbContext.Database.BeginTransaction()) {
                    try {
                        foreach (var entity in batch) {
                            convertFunction(entity, ffpmDbContext, logger);
                        }

                        ffpmDbContext.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception e) {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static void PatientConvert(Models.Patient patient, FfpmContext ffpmDbContext, ILogger logger) {
            // Regular expression
            string ssnPattern = @"^(?:\d{3}[-/]\d{2}[-/]\d{4}|\d{9})$";
            if (patient.PatientAccountNumber == null) {
                logger.Log("Patient Account Number is null for patient with ID: " + patient.Id);
                return;
            } else if (patient.PatientLast == null) {
                logger.Log("Patient Last Name is null for patient with ID: " + patient.Id);
                return;
            } else if (patient.PatientFirst == null) {
                logger.Log("Patient First Name is null for patient with ID: " + patient.Id);
                return;
            } else if (patient.PatientSsn == null || !Regex.IsMatch(patient.PatientSsn, ssnPattern)) {
                logger.Log("Patient SSN is null or invalid for patient with ID: " + patient.Id);
                return;
            } else if (patient.PatientDob == null) {
                logger.Log("Patient DOB is null for patient with ID: " + patient.Id);
                return;
            }
            // Checking between all date formats I have seen so far
            string[] dateFormats = new string[] {
                "dd/MM/yyyy", "MM/dd/yyyy", "yyyy/MM/dd", "yyyy/dd/MM",
                "d/M/yyyy", "M/d/yyyy", "yyyy/M/d", "yyyy/d/M",
                "dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd", "yyyy-dd-MM",
                "d-M-yyyy", "M-d-yyyy", "yyyy-M-d", "yyyy-d-M",
                "dd MM yyyy", "MM dd yyyy", "yyyy MM dd", "yyyy dd MM",
                "d M yyyy", "M d yyyy", "yyyy M d", "yyyy d M",
                "ddMMMyyyy", "MMMddyyyy",
                "dd MMM, yyyy", "MMM dd, yyyy"
            };

            DateTime dob;
            string dobString = patient.PatientDob.Trim(); // Remove any leading/trailing whitespaces
                                                          // Try parsing the date using the specified formats
            if (!DateTime.TryParseExact(dobString, dateFormats,
                CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out dob)) {
                logger.Log("Patient DOB is invalid or not in an expected format for patient with ID: " + patient.Id);
                return;
            }
            short? maritalStatusInt = null;
            if (patient.PatientMaritalStatus != null) {
                if (short.TryParse(patient.PatientMaritalStatus, out short maritalStatus)) {
                    maritalStatusInt = maritalStatus;
                }
            }
            short? titleInt = null;
            if (patient.Title != null) {
                if (short.TryParse(patient.Title, out short title)) {
                    titleInt = title;
                }
            }
            short? suffixInt = null;
            if (patient.Suffix != null) {
                if (short.TryParse(patient.Suffix, out short suffix)) {
                    suffixInt = suffix;
                }
            }
            short? genderInt = null;
            if (patient.PatientSex != null) {
                if (short.TryParse(patient.PatientSex, out short gender)) {
                    genderInt = gender;
                }
            } else if (patient.PatientEthnicity == null) {
                logger.Log("Patient ethnicity is null for patient with ID: " + patient.Id);
                return;
            }

            var newPatient = new Brady_s_Conversion_Program.ModelsA.DmgPatient {
                AccountNumber = patient.PatientAccountNumber,
                AltAccountNumber = patient.PatientAltAccountNumber,
                LastName = patient.PatientLast,
                MiddleName = patient.PatientMiddle,
                FirstName = patient.PatientFirst,
                PreferredName = patient.PatientPreferredName,
                // ssn in what format? int only? no dash?
                Ssn = patient.PatientSsn,
                DateOfBirth = dob,
                MaritialStatusId = maritalStatusInt,
                TitleId = titleInt,

            };
            ffpmDbContext.DmgPatients.Add(newPatient);

            var newRace = new Brady_s_Conversion_Program.ModelsA.MntRace {
                Race = patient.PatientRace
            };
            ffpmDbContext.MntRaces.Add(newRace);

            var newEthnicity = new Brady_s_Conversion_Program.ModelsA.MntEthnicity {
                Ethnicity = patient.PatientEthnicity
            };
            ffpmDbContext.MntEthnicities.Add(newEthnicity);
        }

        public static void ConvertAccountXref(Models.AccountXref accountXref, FfpmContext ffpmDbContext, ILogger logger) {
            var newAccountXref = new Brady_s_Conversion_Program.ModelsA.AccountXref {
                // Map properties
            };
            ffpmDbContext.AccountXrefs.Add(newAccountXref);
        }

        public static void ConvertAddress(Models.Address address, FfpmContext ffpmDbContext, ILogger logger) {
            // Existing logic for creating and adding a new Address
            var newAddress = new Brady_s_Conversion_Program.ModelsA.Address {
                // Map properties
            };
            ffpmDbContext.Addresses.Add(newAddress);
        }

        public static void ConvertAppointment(Models.Appointment appointment, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle appointment-related actions
            logger.Log("Processing appointment: " + appointment.AppointmentId);
            // No new entity creation, just process existing logic
        }

        public static void ConvertAppointmentType(Models.AppointmentType appointmentType, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle appointment type actions
            
        }

        public static void ConvertEmployer(Models.Employer employer, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle employer-related actions
            
        }

        public static void ConvertInsurance(Models.Insurance insurance, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle insurance-related actions
            
        }

        public static void ConvertLocation(Models.Location location, FfpmContext ffpmDbContext, ILogger logger) {
            // Existing logic for creating and adding a new Location
            var newLocation = new Brady_s_Conversion_Program.ModelsA.Location {
                // Map properties
            };
            ffpmDbContext.Locations.Add(newLocation);
        }

        public static void ConvertName(Models.Name name, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle name-related actions
            
        }

        public static void ConvertPatientAlert(Models.PatientAlert patientAlert, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle patient alert actions
            
        }

        public static void ConvertPatientDocument(Models.PatientDocument patientDocument, FfpmContext ffpmDbContext, ILogger logger) {
            // Existing logic for creating and adding a new PatientDocument
            var newPatientDocument = new Brady_s_Conversion_Program.ModelsA.ImgPatientDocument {
                // Map properties
            };
            ffpmDbContext.ImgPatientDocuments.Add(newPatientDocument);
        }

        public static void ConvertPatientInsurance(Models.PatientInsurance patientInsurance, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle patient insurance actions
            
        }

        public static void ConvertPatientNote(Models.PatientNote patientNote, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle patient note actions
            
        }

        public static void ConvertPhone(Models.Phone phone, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle phone-related actions
            
        }

        public static void ConvertProvider(Models.Provider provider, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle provider-related actions
            logger.Log("Processing provider: " + provider.ProviderId);
            // No new entity creation, just process existing logic
        }

        public static void ConvertRecall(Models.Recall recall, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle recall-related actions
            logger.Log("Processing recall: " + recall.RecallId);
            // No new entity creation, just process existing logic
        }

        public static void ConvertRecallType(Models.RecallType recallType, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle recall type actions
            
        }

        public static void ConvertReferral(Models.Referral referral, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle referral-related actions
            logger.Log("Processing referral: " + referral.ReferralId);
            // No new entity creation, just process existing logic
        }

        public static void ConvertSchedCode(Models.SchedCode schedCode, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle sched code-related actions
            
        }

        public static void ConvertEyeMD(FoxfireConvContext convDbContext, EyeMdContext eyeMDDbContext, ILogger logger) {
            // Log or handle EyeMD conversion
            logger.Log("Starting EyeMD conversion");
            // EyeMD conversion logic here
        }

    }
}
