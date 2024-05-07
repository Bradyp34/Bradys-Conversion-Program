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

namespace Brady_s_Conversion_Program
{
    public class Functions
    {
        public static string ConvertToDB(string connection, string FFPMConnection, string EyeMDConnection, bool ffpm, bool eyemd) {
            try {
                // have log file ready to record failings and issues
                using (StreamWriter sw = new StreamWriter("../../../../LogFiles/log.txt")) {
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
                            ConvertFFPM(convDbContext, ffpmDbContext);
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

        public static void ConvertFFPM(FoxfireConvContext convDbContext, FfpmContext ffpmDbContext) {
            // Convert Patients
            BatchProcessEntities(convDbContext.Patients.ToList(), PatientConvert, ffpmDbContext);

            // Convert AccountXrefs
            BatchProcessEntities(convDbContext.AccountXrefs.ToList(), ConvertAccountXref, ffpmDbContext);

            // Convert Addresses
            BatchProcessEntities(convDbContext.Addresses.ToList(), ConvertAddress, ffpmDbContext);

            // Convert Appointments
            BatchProcessEntities(convDbContext.Appointments.ToList(), ConvertAppointment, ffpmDbContext);

            // Convert AppointmentTypes
            BatchProcessEntities(convDbContext.AppointmentTypes.ToList(), ConvertAppointmentType, ffpmDbContext);

            // Convert Employers
            BatchProcessEntities(convDbContext.Employers.ToList(), ConvertEmployer, ffpmDbContext);

            // Convert Insurances
            BatchProcessEntities(convDbContext.Insurances.ToList(), ConvertInsurance, ffpmDbContext);

            // Convert Locations
            BatchProcessEntities(convDbContext.Locations.ToList(), ConvertLocation, ffpmDbContext);

            // Convert Names
            BatchProcessEntities(convDbContext.Names.ToList(), ConvertName, ffpmDbContext);

            // Convert PatientAlerts
            BatchProcessEntities(convDbContext.PatientAlerts.ToList(), ConvertPatientAlert, ffpmDbContext);

            // Convert PatientDocuments
            BatchProcessEntities(convDbContext.PatientDocuments.ToList(), ConvertPatientDocument, ffpmDbContext);

            // Convert PatientInsurances
            BatchProcessEntities(convDbContext.PatientInsurances.ToList(), ConvertPatientInsurance, ffpmDbContext);

            // Convert PatientNotes
            BatchProcessEntities(convDbContext.PatientNotes.ToList(), ConvertPatientNote, ffpmDbContext);

            // Convert Phones
            BatchProcessEntities(convDbContext.Phones.ToList(), ConvertPhone, ffpmDbContext);

            // Convert Providers
            BatchProcessEntities(convDbContext.Providers.ToList(), ConvertProvider, ffpmDbContext);

            // Convert Recalls
            BatchProcessEntities(convDbContext.Recalls.ToList(), ConvertRecall, ffpmDbContext);

            // Convert RecallTypes
            BatchProcessEntities(convDbContext.RecallTypes.ToList(), ConvertRecallType, ffpmDbContext);

            // Convert Referrals
            BatchProcessEntities(convDbContext.Referrals.ToList(), ConvertReferral, ffpmDbContext);

            // Convert SchedCodes
            BatchProcessEntities(convDbContext.SchedCodes.ToList(), ConvertSchedCode, ffpmDbContext);
        }



        public static void BatchProcessEntities<T>(IEnumerable<T> entities, Action<T, FfpmContext> convertFunction, FfpmContext ffpmDbContext) {
            int batchSize = 100; // Define an appropriate batch size
            int numberOfRecords = entities.Count();
            int numberOfBatches = (numberOfRecords / batchSize) + (numberOfRecords % batchSize > 0 ? 1 : 0);

            for (int batchNumber = 0; batchNumber < numberOfBatches; batchNumber++) {
                var batch = entities.Skip(batchNumber * batchSize).Take(batchSize).ToList();

                using (var transaction = ffpmDbContext.Database.BeginTransaction()) {
                    try {
                        foreach (var entity in batch) {
                            convertFunction(entity, ffpmDbContext);
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


        public static void PatientConvert(Models.Patient patient, FfpmContext ffpmDbContext) {
            var newPatient = new Brady_s_Conversion_Program.ModelsA.DmgPatient {
                // Map properties
            };
        }

        public static void ConvertAccountXref(Models.AccountXref accountXref, FfpmContext ffpmDbContext) {
            var newAccountXref = new Brady_s_Conversion_Program.ModelsA.AccountXref {
                // Map properties
            };
            ffpmDbContext.AccountXrefs.Add(newAccountXref);
        }

        public static void ConvertAddress(Models.Address address, FfpmContext ffpmDbContext) {
            var newAddress = new Brady_s_Conversion_Program.ModelsA.Address {
                // Map properties
            };
            ffpmDbContext.Addresses.Add(newAddress);
        }

        public static void ConvertAppointment(Models.Appointment appointment, FfpmContext ffpmDbContext) {
            // Map properties
        }

        public static void ConvertAppointmentType(Models.AppointmentType appointmentType, FfpmContext ffpmDbContext) {
            // Map properties
        }

        public static void ConvertEmployer(Models.Employer employer, FfpmContext ffpmDbContext) {
            // Map properties
        }

        public static void ConvertInsurance(Models.Insurance insurance, FfpmContext ffpmDbContext) {
            // There are a few insurance classes for ffpm
        }

        public static void ConvertLocation(Models.Location location, FfpmContext ffpmDbContext) {
            var newLocation = new Brady_s_Conversion_Program.ModelsA.Location {
                // Map properties
            };
            ffpmDbContext.Locations.Add(newLocation);
        }

        public static void ConvertName(Models.Name name, FfpmContext ffpmDbContext) {
            // Map properties
        }

        public static void ConvertPatientAlert(Models.PatientAlert patientAlert, FfpmContext ffpmDbContext) {
            // Map properties
        }

        public static void ConvertPatientDocument(Models.PatientDocument patientDocument, FfpmContext ffpmDbContext) {
            var newPatientDocument = new Brady_s_Conversion_Program.ModelsA.ImgPatientDocument {
                // Map properties
            };
            ffpmDbContext.ImgPatientDocuments.Add(newPatientDocument);
        }

        public static void ConvertPatientInsurance(Models.PatientInsurance patientInsurance, FfpmContext ffpmDbContext) {
            // other insurance things
        }

        public static void ConvertPatientNote(Models.PatientNote patientNote, FfpmContext ffpmDbContext) {
            // Map properties
        }

        public static void ConvertPhone(Models.Phone phone, FfpmContext ffpmDbContext) {
            // Map properties
        }

        public static void ConvertProvider(Models.Provider provider, FfpmContext ffpmDbContext) {
            // Im assuming this means insurance provider
        }

        public static void ConvertRecall(Models.Recall recall, FfpmContext ffpmDbContext) {
            // Not sure what recall is yet
        }

        public static void ConvertRecallType(Models.RecallType recallType, FfpmContext ffpmDbContext) {
            // More recall stuff
        }

        public static void ConvertReferral(Models.Referral referral, FfpmContext ffpmDbContext) {
            // not positive what a referrel is either
        }

        public static void ConvertSchedCode(Models.SchedCode schedCode, FfpmContext ffpmDbContext) {
            // Map properties
        }

        public static void ConvertEyeMD(FoxfireConvContext convDbContext, EyeMdContext eyeMDDbContext) {
            var patients = convDbContext.Patients.ToList();

            int batchSize = 100; // Define an appropriate batch size
            int numberOfRecords = convDbContext.Patients.Count();
            int numberOfBatches = (numberOfRecords / batchSize) + (numberOfRecords % batchSize > 0 ? 1 : 0);

            for (int batchNumber = 0; batchNumber < numberOfBatches; batchNumber++) {
                // Not ready to implement
                throw new NotImplementedException();

                var patientBatch = convDbContext.Patients.Skip(batchNumber * batchSize).Take(batchSize).ToList();
                // Process each batch as shown above
                using (var transaction = eyeMDDbContext.Database.BeginTransaction()) {
                    try {
                        foreach (var patient in patientBatch) {
                            // Convert patient data
                            
                        }

                        eyeMDDbContext.SaveChanges();
                        transaction.Commit();
                    } catch (Exception e) {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
