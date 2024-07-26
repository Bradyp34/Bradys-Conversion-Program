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
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection.Emit;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System.Data.SqlTypes;
using Brady_s_Conversion_Program.ModelsC;
using Brady_s_Conversion_Program.ModelsD;
using System.Web;
using System.CodeDom;

namespace Brady_s_Conversion_Program {
    public static class Functions {
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

        public static readonly string[] dateFormats = new string[] {
            // Date-only formats with numeric and abbreviated months
            "MM/dd/yyyy", "dd/MM/yyyy", "yyyy/MM/dd", "yyyy/dd/MM",
            "M/d/yyyy", "d/M/yyyy", "yyyy/M/d", "yyyy/d/M",
            "MM-dd-yyyy", "dd-MM-yyyy", "yyyy-MM-dd", "yyyy-dd-MM",
            "M-d-yyyy", "d-M-yyyy", "yyyy-M-d", "yyyy-d-M",
            "MM dd yyyy", "dd MM yyyy", "yyyy MM dd", "yyyy dd MM",
            "M d yyyy", "d M yyyy", "yyyy M d", "yyyy d M",
            "MMM dd, yyyy", "dd MMM, yyyy",

            // Date-only formats with full month names
            "MMMM dd, yyyy", "dd MMMM, yyyy",
            "MMMM-d-yyyy", "d-MMMM-yyyy",
            "MMMM/dd/yyyy", "dd/MMMM/yyyy",
            "MMMM dd yyyy", "dd MMMM yyyy",
            "MMMM d, yyyy", "d MMMM, yyyy",

            // Date-only formats with concatenated month and day names
            "MMMddyyyy", "ddMMMyyyy",

            // Date with 24-hour time formats with numeric and abbreviated months
            "MM/dd/yyyy HH:mm:ss", "dd/MM/yyyy HH:mm:ss", "yyyy/MM/dd HH:mm:ss", "yyyy/dd/MM HH:mm:ss",
            "M/d/yyyy HH:mm:ss", "d/M/yyyy HH:mm:ss", "yyyy/M/d HH:mm:ss", "yyyy/d/M HH:mm:ss",
            "MM-dd-yyyy HH:mm:ss", "dd-MM-yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "yyyy-dd-MM HH:mm:ss",
            "MM dd yyyy HH:mm:ss", "dd MM yyyy HH:mm:ss", "M d yyyy HH:mm:ss", "d M yyyy HH:mm:ss",
            "MMMddyyyy HH:mm:ss", "ddMMMyyyy HH:mm:ss",
            "MMM dd, yyyy HH:mm:ss", "dd MMM, yyyy HH:mm:ss",

            // Date with 24-hour time formats with full month names
            "MMMM/dd/yyyy HH:mm:ss", "dd/MMMM/yyyy HH:mm:ss",
            "MMMM-dd-yyyy HH:mm:ss", "dd-MMMM-yyyy HH:mm:ss",
            "MMMM dd, yyyy HH:mm:ss", "dd MMMM, yyyy HH:mm:ss",
            "MMMM d, yyyy HH:mm:ss", "d MMMM, yyyy HH:mm:ss",

            // Date with 12-hour time formats (AM/PM) with numeric and abbreviated months
            "MM/dd/yyyy hh:mm:ss tt", "dd/MM/yyyy hh:mm:ss tt", "yyyy/MM/dd hh:mm:ss tt", "yyyy/dd/MM hh:mm:ss tt",
            "M/d/yyyy hh:mm:ss tt", "d/M/yyyy hh:mm:ss tt", "yyyy/M/d hh:mm:ss tt", "yyyy/d/M hh:mm:ss tt",
            "MM-dd-yyyy hh:mm:ss tt", "dd-MM-yyyy hh:mm:ss tt", "yyyy-MM-dd hh:mm:ss tt", "yyyy-dd-MM hh:mm:ss tt",
            "MM dd yyyy hh:mm:ss tt", "dd MM yyyy hh:mm:ss tt", "M d yyyy hh:mm:ss tt", "d M yyyy hh:mm:ss tt",
            "MMMddyyyy hh:mm:ss tt", "ddMMMyyyy hh:mm:ss tt",
            "MMM dd, yyyy hh:mm:ss tt", "dd MMM, yyyy hh:mm:ss tt",

            // Date with 12-hour time formats (AM/PM) with full month names
            "MMMM/dd/yyyy hh:mm:ss tt", "dd/MMMM/yyyy hh:mm:ss tt",
            "MMMM-dd-yyyy hh:mm:ss tt", "dd-MMMM-yyyy hh:mm:ss tt",
            "MMMM dd, yyyy hh:mm:ss tt", "dd MMMM, yyyy hh:mm:ss tt",
            "MMMM d, yyyy hh:mm:ss tt", "d MMMM, yyyy hh:mm:ss tt",

            // Date with 24-hour time formats (without seconds) with numeric and abbreviated months
            "MM/dd/yyyy HH:mm", "dd/MM/yyyy HH:mm", "yyyy/MM/dd HH:mm", "yyyy/dd/MM HH:mm",
            "M/d/yyyy HH:mm", "d/M/yyyy HH:mm", "yyyy/M/d HH:mm", "yyyy/d/M HH:mm",
            "MM-dd-yyyy HH:mm", "dd-MM-yyyy HH:mm", "yyyy-MM-dd HH:mm", "yyyy-dd-MM HH:mm",
            "MM dd yyyy HH:mm", "dd MM yyyy HH:mm", "M d yyyy HH:mm", "d M yyyy HH:mm",
            "MMMddyyyy HH:mm", "ddMMMyyyy HH:mm",
            "MMM dd, yyyy HH:mm", "dd MMM, yyyy HH:mm",

            // Date with 24-hour time formats (without seconds) with full month names
            "MMMM/dd/yyyy HH:mm", "dd/MMMM/yyyy HH:mm",
            "MMMM-dd-yyyy HH:mm", "dd-MMMM-yyyy HH:mm",
            "MMMM dd, yyyy HH:mm", "dd MMMM, yyyy HH:mm",
            "MMMM d, yyyy HH:mm", "d MMMM, yyyy HH:mm",

            // Date with 12-hour time formats (AM/PM) without seconds with numeric and abbreviated months
            "MM/dd/yyyy hh:mm tt", "dd/MM/yyyy hh:mm tt", "yyyy/MM/dd hh:mm tt", "yyyy/dd/MM hh:mm tt",
            "M/d/yyyy hh:mm tt", "d/M/yyyy hh:mm tt", "yyyy/M/d hh:mm tt", "yyyy/d/M hh:mm tt",
            "MM-dd-yyyy hh:mm tt", "dd-MM-yyyy hh:mm tt", "yyyy-MM-dd hh:mm tt", "yyyy-dd-MM hh:mm tt",
            "MM dd yyyy hh:mm tt", "dd MM yyyy hh:mm tt", "M d yyyy hh:mm tt", "d M yyyy hh:mm tt",
            "MMMddyyyy hh:mm tt", "ddMMMyyyy hh:mm tt",
            "MMM dd, yyyy hh:mm tt", "dd MMM, yyyy hh:mm tt",

            // Date with 12-hour time formats (AM/PM) without seconds with full month names
            "MMMM/dd/yyyy hh:mm tt", "dd/MMMM/yyyy hh:mm tt",
            "MMMM-dd-yyyy hh:mm tt", "dd-MMMM-yyyy hh:mm tt",
            "MMMM dd, yyyy hh:mm tt", "dd MMMM, yyyy hh:mm tt",
            "MMMM d, yyyy hh:mm tt", "d MMMM, yyyy hh:mm tt"
        };


        private static Dictionary<string, short> stateDictionary = new Dictionary<string, short> {
            {"Alabama", 1}, {"Alaska", 2}, {"Arizona", 3}, {"Arkansas", 4}, {"California", 5},
            {"Colorado", 6}, {"Connecticut", 7}, {"Delaware", 8}, {"Florida", 9}, {"Georgia", 10},
            {"Hawaii", 11}, {"Idaho", 12}, {"Illinois", 13}, {"Indiana", 14}, {"Iowa", 15},
            {"Kansas", 16}, {"Kentucky", 17}, {"Louisiana", 18}, {"Maine", 19}, {"Maryland", 20},
            {"Massachusetts", 21}, {"Michigan", 22}, {"Minnesota", 23}, {"Mississippi", 24}, {"Missouri", 25},
            {"Montana", 26}, {"Nebraska", 27}, {"Nevada", 28}, {"New Hampshire", 29}, {"New Jersey", 30},
            {"New Mexico", 31}, {"New York", 32}, {"North Carolina", 33}, {"North Dakota", 34}, {"Ohio", 35},
            {"Oklahoma", 36}, {"Oregon", 37}, {"Pennsylvania", 38}, {"Rhode Island", 39}, {"South Carolina", 40},
            {"South Dakota", 41}, {"Tennessee", 42}, {"Texas", 43}, {"Utah", 44}, {"Vermont", 45},
            {"Virginia", 46}, {"Washington", 47}, {"West Virginia", 48}, {"Wisconsin", 49}, {"Wyoming", 50}
        };

        public static short? ConvertStateToShort(string? state) {
            if (state == null) {
                return null;
            }
            if (stateDictionary.ContainsKey(state))
                return stateDictionary[state];
            return null;
        }

        private static Regex ssnRegex = new Regex(@"^(?:\d{3}[-/]\d{2}[-/]\d{4}|\d{9})$");
        private static Regex zipRegex = new Regex(@"\b(\d{5})(?:[-\s]?(\d{4}))?\b"); // Regex for US ZIP codes
        private static Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        private static Regex phoneRegex = new Regex(@"^(\d{3}-\d{3}-\d{4})$");

        public static string FFPMString = "";
        public static string EyeMDString = "";

        public static string ConvertToDB(string convConnection, string ehrConnection, string invConnection, string FFPMConnection, string EyeMDConnection,
            bool conv, bool ehr, bool inv, bool newFfpm, bool newEyemd, ProgressBar progress) {
            FFPMString = FFPMConnection;
            EyeMDString = EyeMDConnection;
            string completeConnection = "";
            try {
                ILogger logger = new FileLogger("../../../../LogFiles/log.txt");

                // Using block for convDbContext conversion
                int totalEntries = 0;

                if (conv == true) { // Essentially, this appears to just be the foxfire_conv database
                    using (var convDbContext = new FoxfireConvContext(convConnection)) {
                        convDbContext.Database.OpenConnection();
                        if (newFfpm) {
                            new FfpmContext(FFPMConnection).Database.EnsureCreated();
                            new EyeMdContext(EyeMDConnection).Database.EnsureCreated();
                        }
                        using (var ffpmDbContext = new FfpmContext(FFPMConnection)) {
                            using (var eyeMDDbContext = new EyeMdContext(EyeMDConnection)) {
                                ffpmDbContext.Database.OpenConnection();
                                eyeMDDbContext.Database.OpenConnection();

                                // Calculate total number of entries for progress tracking
                                totalEntries = convDbContext.Patients.Count() +
                                                convDbContext.AccountXrefs.Count() +
                                                convDbContext.Addresses.Count() +
                                                convDbContext.Appointments.Count() +
                                                convDbContext.AppointmentTypes.Count() +
                                                convDbContext.Insurances.Count() +
                                                convDbContext.Locations.Count() +
                                                convDbContext.Names.Count() +
                                                convDbContext.PatientAlerts.Count() +
                                                convDbContext.PatientDocuments.Count() +
                                                convDbContext.PatientInsurances.Count() +
                                                convDbContext.PatientNotes.Count() +
                                                convDbContext.Phones.Count() +
                                                convDbContext.Providers.Count() +
                                                convDbContext.Recalls.Count() +
                                                convDbContext.RecallTypes.Count() +
                                                convDbContext.Referrals.Count() +
                                                convDbContext.SchedCodes.Count();


                                // Set progress bar properties on UI thread
                                progress.Invoke((MethodInvoker)delegate {
                                    progress.Maximum = totalEntries;
                                    progress.Step = 1;
                                    progress.Value = 0;
                                });

                                // Perform conversion for each table
                                ConvertFFPM(convDbContext, ffpmDbContext, eyeMDDbContext, logger, progress);

                                // Save changes to databases
                                ffpmDbContext.SaveChanges();
                                convDbContext.SaveChanges();
                            }
                        }
                    }
                    completeConnection += "FFPM Conversion Successful\n";
                }
                if (ehr == true) { // not positive what this will entail yet
                    using (var eHRDbContext = new EHRDbContext(ehrConnection)) {
                        if (newEyemd) {
                            new EyeMdContext(EyeMDConnection).Database.EnsureCreated();
                        }
                        using (var eyeMDDbContext = new EyeMdContext(EyeMDConnection)) {
                            totalEntries = eHRDbContext.MedicalHistories.Count() +
                                            eHRDbContext.Visits.Count() +
                                            eHRDbContext.VisitOrders.Count() +
                                            eHRDbContext.VisitDoctors.Count() +
                                            eHRDbContext.Allergies.Count() +
                                            eHRDbContext.ContactLens.Count() +
                                            eHRDbContext.DiagCodePools.Count() +
                                            eHRDbContext.DiagTests.Count() +
                                            eHRDbContext.ExamConditions.Count() +
                                            eHRDbContext.FamilyHistories.Count() +
                                            eHRDbContext.Iops.Count() +
                                            eHRDbContext.PlanNarratives.Count() +
                                            eHRDbContext.ProcDiagPools.Count() +
                                            eHRDbContext.ProcPools.Count() +
                                            eHRDbContext.Refractions.Count() +
                                            eHRDbContext.Ros.Count() +
                                            eHRDbContext.RxMedications.Count() +
                                            eHRDbContext.SurgHistories.Count() +
                                            eHRDbContext.Teches.Count() +
                                            eHRDbContext.Tech2s.Count() +
                                            eHRDbContext.PatientDocuments.Count() +
                                            eHRDbContext.Appointments.Count() +
                                            eHRDbContext.Patients.Count() +
                                            eHRDbContext.PatientDocuments.Count() +
                                            eHRDbContext.PatientNotes.Count();




                            // Set progress bar properties on UI thread
                            progress.Invoke((MethodInvoker)delegate {
                                progress.Maximum = totalEntries;
                                progress.Step = 1;
                                progress.Value = 0;
                            });



                            eyeMDDbContext.Database.OpenConnection();
                            ConvertEyeMD(eHRDbContext, eyeMDDbContext, logger, progress);
                            eyeMDDbContext.SaveChanges();
                        }
                    }
                    completeConnection += "EyeMD Conversion Successful\n";
                }

                if (inv == true) {
                    using (var invDbContext = new InvDbContext(invConnection)) {
                        using (var ffpmDbContext = new FfpmContext(FFPMConnection)) {
                            totalEntries = invDbContext.ClBrands.Count() +
                                            invDbContext.ClInventories.Count() +
                                            invDbContext.ClLenses.Count() +
                                            invDbContext.CptDepts.Count() +
                                            invDbContext.CptMappings.Count() +
                                            invDbContext.Cpts.Count() +
                                            invDbContext.FrameCategories.Count() +
                                            invDbContext.FrameCollections.Count() +
                                            invDbContext.FrameColors.Count() +
                                            invDbContext.FrameShapes.Count() +
                                            invDbContext.FrameStatuses.Count() +
                                            invDbContext.FrameTemples.Count() +
                                            invDbContext.FrameEtypes.Count() +
                                            invDbContext.FrameFtypes.Count() +
                                            invDbContext.FrameLensColors.Count() +
                                            invDbContext.FrameMaterials.Count() +
                                            invDbContext.FrameMounts.Count() +
                                            invDbContext.FrameOrders.Count() +
                                            invDbContext.Frames.Count();


                            // Set progress bar properties on UI thread
                            progress.Invoke((MethodInvoker)delegate {
                                progress.Maximum = totalEntries;
                                progress.Step = 1;
                                progress.Value = 0;
                            });



                            ffpmDbContext.Database.OpenConnection();
                            ConvertInv(invDbContext, ffpmDbContext, logger, progress); // need to find out where inv data goes
                            ffpmDbContext.SaveChanges();
                        }
                    }
                    return completeConnection + "\nInv not yet implemented";
                }
            }
            catch (Exception e) {
                return "Database Upload Failed.\n" + e + "\n";
            }
            return "Operation Successful";
        }

        #region FFPMConversion
        public static void ConvertFFPM(FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, EyeMdContext eyemdDbContext, ILogger logger, ProgressBar progress) {
            foreach (var patient in convDbContext.Patients.ToList()) {
                PatientConvert(patient, convDbContext, ffpmDbContext, eyemdDbContext, logger, progress);
            }

            foreach (var accountXref in convDbContext.AccountXrefs.ToList()) {
                ConvertAccountXref(accountXref, convDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var address in convDbContext.Addresses.ToList()) {
                ConvertAddress(address, convDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var appointment in convDbContext.Appointments.ToList()) {
                ConvertAppointment(appointment, convDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var appointmentType in convDbContext.AppointmentTypes.ToList()) {
                ConvertAppointmentType(appointmentType, convDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var insurance in convDbContext.Insurances.ToList()) {
                ConvertInsurance(insurance, convDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var location in convDbContext.Locations.ToList()) {
                ConvertLocation(location, convDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var name in convDbContext.Names.ToList()) {
                ConvertName(name, convDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var patientAlert in convDbContext.PatientAlerts.ToList()) {
                ConvertPatientAlert(patientAlert, convDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var patientDocument in convDbContext.PatientDocuments.ToList()) {
                ConvertPatientDocument(patientDocument, convDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var patientInsurance in convDbContext.PatientInsurances.ToList()) {
                ConvertPatientInsurance(patientInsurance, convDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var patientNote in convDbContext.PatientNotes.ToList()) {
                ConvertPatientNote(patientNote, convDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var phone in convDbContext.Phones.ToList()) {
                ConvertPhone(phone, convDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var provider in convDbContext.Providers.ToList()) {
                ConvertProvider(provider, convDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var recall in convDbContext.Recalls.ToList()) {
                ConvertRecall(recall, convDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var recallType in convDbContext.RecallTypes.ToList()) {
                ConvertRecallType(recallType, convDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var referral in convDbContext.Referrals.ToList()) {
                ConvertReferral(referral, convDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var schedCode in convDbContext.SchedCodes.ToList()) {
                ConvertSchedCode(schedCode, convDbContext, ffpmDbContext, logger, progress);
            }
        }

        public static void PatientConvert(Models.Patient patient, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, EyeMdContext eyeMdDbContext, 
            ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                if (patient.PatientAccountNumber == null) {
                    logger.Log($"Conv: Conv Patient Account Number is null for patient with ID: {patient.Id}");
                    return;
                }
                else if (patient.PatientLast == null) {
                    logger.Log($"Conv: Conv Patient Last Name is null for patient with ID: {patient.Id}");
                    return;
                }
                else if (patient.PatientFirst == null) {
                    logger.Log($"Conv: Conv Patient First Name is null for patient with ID: {patient.Id}");
                    return;
                }
                else if (patient.PatientSsn == null || !ssnRegex.IsMatch(patient.PatientSsn)) {
                    logger.Log($"Conv: Conv Patient SSN is null or invalid for patient with ID: {patient.Id}");
                    return;
                }
                else if (patient.PatientDob == null) {
                    logger.Log($"Conv: Conv Patient DOB is null for patient with ID: {patient.Id}");
                    return;
                }

                DateTime dob;
                string dobString = patient.PatientDob.Trim(); // Remove any leading/trailing whitespaces
                                                              // Try parsing the date using the specified formats
                if (!DateTime.TryParseExact(dobString, dateFormats,
                    CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out dob)) {
                    logger.Log($"Conv: Conv Patient DOB is invalid or not in an expected format for patient with ID: {patient.Id}");
                    return;
                }
                short? maritalStatusInt = null;
                if (patient.PatientMaritalStatus != null) {
                    switch (patient.PatientMaritalStatus.ToLower()) {
                        case "married":
                            maritalStatusInt = 1;
                            break;
                        case "single":
                            maritalStatusInt = 2;
                            break;
                        case "divorced":
                            maritalStatusInt = 3;
                            break;
                        case "widowed":
                            maritalStatusInt = 4;
                            break;
                    }
                }

                short? titleInt = null;
                if (patient.Title != null) {
                    switch (patient.Title.ToLower()) {
                        case "mr":
                        case "mr.":
                            titleInt = 1;
                            break;
                        case "mrs":
                        case "mrs.":
                            titleInt = 2;
                            break;
                        case "ms":
                        case "ms.":
                            titleInt = 3;
                            break;
                        case "miss":
                            titleInt = 4;
                            break;
                    }
                }

                short? suffixInt = null;
                if (patient.Suffix != null) {
                    switch (patient.Suffix.ToLower()) {
                        case "jr":
                    suffixInt = 1;
                    break;
                        case "sr":
                    case "sr.":
                        suffixInt = 2;
                        break;
                    case "ii":
                        suffixInt = 3;
                        break;
                    case "iii":
                        suffixInt = 4;
                        break;
                    case "iv":
                        suffixInt = 5;
                        break;
                    case "v":
                        suffixInt = 6;
                        break;
                    }
                }

                short? genderInt = null;
                if (patient.PatientSex != null) {
                    genderInt = patient.PatientSex.ToLower() == "m" ? (short)1 : (short)2;
                }
                if (patient.DriversLicenseState == null) {

                }
                short? licenseShort = ConvertStateToShort(patient.DriversLicenseState);

                short? race = null;
                if (patient.PatientRace != null) {
                    if (short.TryParse(patient.PatientRace, out short raceInt)) {
                        race = raceInt;
                    }
                }

                short? ethnicity = null;
                string ethnicityString = "";
                if (patient.PatientEthnicity != null) {
                    if (short.TryParse(patient.PatientEthnicity, out short ethnicityInt)) {
                        ethnicity = ethnicityInt;
                        ethnicityString = patient.PatientEthnicity;
                    }
                }

                string? medicareSecondary = null;
                if (patient.MedicareSecondaryCode != null) {
                    medicareSecondary = patient.MedicareSecondaryCode;
                }

                bool? patientIsActive = null;
                if (patient.Active != null) {
                    patientIsActive = patient.Active.ToUpper() == "YES" ? true : false;
                }

                bool? deceased = null;
                if (patient.DeceasedFlag != null) {
                    deceased = patient.DeceasedFlag.ToUpper() == "YES" ? true : false;
                }

                bool? consent = null;
                if (patient.Consent != null) {
                    consent = patient.Consent.ToUpper() == "YES" ? true : false;
                }

                DateTime? consentDate = null;
                if (patient.ConsentDate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(patient.ConsentDate, dateFormats,
                        CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        consentDate = tempDateTime;
                    }
                }
                DateOnly? deceasedDate = null;
                if (patient.DateOfDeath != null) {
                    DateOnly tempDateTime;
                    if (!DateOnly.TryParseExact(patient.DateOfDeath, dateFormats,
                                           CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        deceasedDate = tempDateTime;
                    }
                }
                DateTime? lastExamDate = null;
                if (patient.LastExamDate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(patient.LastExamDate, dateFormats,
                                           CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        lastExamDate = tempDateTime;
                    }
                }
                if (patient.PatientEmail != null && patient.PatientEmail != "") {
                    string email = patient.PatientEmail;
                }
                bool isEmailValid = new EmailAddressAttribute().IsValid(patient.PatientEmail);
                bool dontSendStatements = false;
                bool emailStatements = false;
                short? prefContact1 = null;
                if (patient.PatientPreferredContact1 != null) {
                    if (short.TryParse(patient.PatientPreferredContact1, out short prefContact1Int)) {
                        prefContact1 = prefContact1Int;
                    }
                }
                short? prefContact2 = null;
                if (patient.PatientPreferredContact2 != null) {
                    if (short.TryParse(patient.PatientPreferredContact2, out short prefContact2Int)) {
                        prefContact2 = prefContact2Int;
                    }
                }
                short? prefContact3 = null;
                if (patient.PatientPreferredContact3 != null) {
                    if (short.TryParse(patient.PatientPreferredContact3, out short prefContact3Int)) {
                        prefContact3 = prefContact3Int;
                    }
                }
                string preferredContactsNotes = patient.PatientPreferredContact1 + "; " + patient.PatientPreferredContact2 + "; " + patient.PatientPreferredContact3;
                DateTime minDate = DateTime.Parse("1/1/1900");

                var newPatient = new Brady_s_Conversion_Program.ModelsA.DmgPatient {
                    DateCreated = DateTime.Now,
                    AccountNumber = patient.PatientAccountNumber,
                    AltAccountNumber = patient.PatientAltAccountNumber,
                    LastName = patient.PatientLast,
                    MiddleName = patient.PatientMiddle,
                    FirstName = patient.PatientFirst,
                    PreferredName = patient.PatientPreferredName,
                    Ssn = patient.PatientSsn,
                    DateOfBirth = dob,
                    MaritialStatusId = maritalStatusInt,
                    TitleId = titleInt,
                    IsActive = patientIsActive,
                    IsDeceased = deceased,
                    DeceasedDate = deceasedDate,
                    LastExamDate = lastExamDate,
                    PatientBalance = 0,
                    InsuranceBalance = 0,
                    OtherBalance = 0,
                    GenderId = genderInt,
                    SuffixId = suffixInt,
                    BalanceLastUpdatedDateTime = minDate,
                    EmailNotApplicable = isEmailValid,
                    DoNotSendStatements = dontSendStatements,
                    EmailStatements = emailStatements,
                    OpenEdgeCustomerId = "",
                    TextStatements = true,
                    LocationId = 0
                };

                ffpmDbContext.DmgPatients.Add(newPatient);
                ffpmDbContext.SaveChanges();

                var newRace = new Brady_s_Conversion_Program.ModelsA.MntRace {
                    Race = patient.PatientRace
                };
                ffpmDbContext.MntRaces.Add(newRace);
                ffpmDbContext.SaveChanges();

                var newEthnicity = new Brady_s_Conversion_Program.ModelsA.MntEthnicity {
                    Ethnicity = ethnicityString
                };
                ffpmDbContext.MntEthnicities.Add(newEthnicity);
                ffpmDbContext.SaveChanges();

                var newMedicareSecondary = new Brady_s_Conversion_Program.ModelsA.MntMedicareSecondary {
                    MedicareSecondarryCode = medicareSecondary,
                    MedicareSecondaryDescription = patient.MedicareSecondaryNotes
                };
                ffpmDbContext.MntMedicareSecondaries.Add(newMedicareSecondary);
                ffpmDbContext.SaveChanges();

                var newAdditionDetails = new Brady_s_Conversion_Program.ModelsA.DmgPatientAdditionalDetail {
                    PatientId = newPatient.PatientId,
                    DriversLicenseNumber = patient.DriversLicense,
                    DriversLicenseStateId = licenseShort,
                    RaceId = newRace.RaceId,
                    EthnicityId = newEthnicity.EthnicityId,
                    MedicareSecondaryId = newMedicareSecondary.MedicareSecondaryId,
                    MedicareSecondaryNotes = patient.MedicareSecondaryNotes,
                    HippaConsent = consent,
                    HippaConsentDate = consentDate,
                    PreferredContactFirstId = prefContact1,
                    PreferredContactSecondId = prefContact2,
                    PreferredContactThirdId = prefContact3,
                    PreferredContactNotes = preferredContactsNotes,
                    DefaultLocationId = newPatient.LocationId
                };
                ffpmDbContext.DmgPatientAdditionalDetails.Add(newAdditionDetails);
                ffpmDbContext.SaveChanges();

                var newEMRPatient = new Brady_s_Conversion_Program.ModelsB.Emrpatient {
                    ClientSoftwarePtId = newPatient.AccountNumber,
                    PatientNameFirst = newPatient.FirstName,
                    PatientNameLast = newPatient.LastName,
                    PatientNameMiddle = newPatient.MiddleName
                };
                eyeMdDbContext.Emrpatients.Add(newEMRPatient);

                eyeMdDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"Conv: Conv An error occurred while converting the patient with ID: {patient.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertAddress(Models.Address address, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.Find(address.Id);
                if (ConvPatient == null) {
                    logger.Log($"Conv: Conv Patient not found for address with ID: {address.Id}");
                    return;
                }
                var ffpmPatient = ffpmDbContext.DmgPatients.FirstOrDefault(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Conv: Conv Patient not found for address with ID: {address.Id}");
                    return;
                }

                DmgPatientAdditionalDetail? ffpmPatientAdditional = null;
                foreach (var details in ffpmDbContext.DmgPatientAdditionalDetails.ToList()) {
                    if (details.PatientId == ffpmPatient.PatientId) {
                        ffpmPatientAdditional = details;
                    }
                }
                if (ffpmPatientAdditional == null) {
                    logger.Log($"Conv: Conv Patient additional not found for address with ID: {address.Id}");
                    return;
                }
                string? zipCode = null;
                if (address.Zip == null) {
                    if (address.Zip4 == null) {
                        zipCode = null;
                    }
                    else {
                        zipCode = address.Zip4;
                    }
                }
                else {
                    zipCode = address.Zip;
                }
                string? baseZipCode = null;
                string? zipExtension = null;

                if (zipCode != null) {
                    Match match = zipRegex.Match(zipCode);
                    if (match.Success) {
                        baseZipCode = match.Groups[1].Value;
                        zipExtension = !string.IsNullOrEmpty(match.Groups[2].Value) ? match.Groups[2].Value : null;
                    }
                }

                bool isPrimary = false;
                bool isAlternate = false;
                bool isActive = false;
                bool isEmergency = false;
                bool isPreferred = false;
                if (address.TypeOfAddress == null) {
                    logger.Log($"Conv: Conv Address type is null for address with ID: {address.Id}");
                }

                if (address.TypeOfAddress == "primary" || address.TypeOfAddress == "Primary") {
                    isPrimary = true;
                    isActive = true;
                    isPreferred = true;
                }
                else if (address.TypeOfAddress == "alternate" || address.TypeOfAddress == "Alternate") {
                    isAlternate = true;
                    isActive = true;
                }
                else if (address.TypeOfAddress == "emergency" || address.TypeOfAddress == "Emergency") {
                    isEmergency = true;
                    isActive = true;
                }

                var newAddress = new Brady_s_Conversion_Program.ModelsA.DmgPatientAddress {
                    PatientId = ffpmPatient.PatientId,
                    Address1 = address.Address1,
                    Address2 = address.Address2,
                    City = address.City,
                    StateId = ffpmPatientAdditional.DriversLicenseStateId,
                    Zip = zipCode,
                    ZipExt = zipExtension,
                    Email = ConvPatient.PatientEmail,
                    Notes = address.Note,
                    IsPrimary = isPrimary,
                    IsActive = isActive,
                    IsPreferred = isPreferred,
                    IsEmergencyContactAddress = isEmergency,
                    IsAlternateAddress = isAlternate
                };
                ffpmDbContext.DmgPatientAddresses.Add(newAddress);

                ffpmDbContext.SaveChanges();

                ffpmPatient.AddressId = newAddress.PatientAddressId;

                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"Conv: Conv An error occurred while converting the address with ID: {address.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertAppointment(Models.Appointment appointment, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, 
            ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                long patientId = 0;
                if (long.TryParse(appointment.PatientId, out long patientIdInt)) {
                    patientId = patientIdInt;
                } else {
                    logger.Log($"Conv: Conv Patient ID is invalid for appointment with ID: {appointment.Id}");
                    return;
                }
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.Find((int)patientId);
                if (ConvPatient == null) {
                    logger.Log($"Conv: Conv Patient not found for appointment with ID: {appointment.Id}");
                    return;
                }
                DmgPatient? ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Conv: Conv Patient not found for appointment with ID: {appointment.Id}");
                    return;
                }

                long resource = 0;
                if (appointment.ResourceId != null) {
                    resource = long.Parse(appointment.ResourceId);
                }

                DateTime start = DateTime.Parse("1/1/1900");
                if (!DateTime.TryParseExact(appointment.StartDate, dateFormats,
                                   CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out start)) {
                    logger.Log($"Conv: Conv Appointment start time is invalid or not in an expected format for appointment with ID: {appointment.Id}");
                    return;
                }
                DateTime end = DateTime.Parse("1/1/1900");
                if (!DateTime.TryParseExact(appointment.EndDate, dateFormats,
                                          CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out end)) {
                    logger.Log($"Conv: Conv Appointment end time is invalid or not in an expected format for appointment with ID: {appointment.Id}");
                    return;
                }
                int duration = 0;
                if (appointment.Duration != null) {
                    if (int.TryParse(appointment.Duration, out int durationInt)) {
                        duration = durationInt;
                    }
                }
                DateTime created = DateTime.Parse("1/1/1900 12:00 AM");
                if (!DateTime.TryParseExact(appointment.DateTimeCreated, dateFormats,
                                         CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out created)) {
                    logger.Log($"Conv: Conv Appointment created time is invalid or not in an expected format for appointment with ID: {appointment.Id}");
                }
                int billingLocId = 0;
                if (appointment.BillingLocationId != null) {
                    if (int.TryParse(appointment.BillingLocationId, out int billingLocIdInt)) {
                        billingLocId = billingLocIdInt;
                    }
                }
                bool confirmed = false;
                if (appointment.Confirmed != null && appointment.Confirmed.ToLower() == "yes") {
                    confirmed = true;
                }
                int sequence = 0;
                if (appointment.Sequence != null) {
                    if (int.TryParse(appointment.Sequence, out int sequenceInt)) {
                        sequence = sequenceInt;
                    }
                }
                int requestId = 0;
                if (appointment.RequestId != null) {
                    if (int.TryParse(appointment.RequestId, out int requestIdInt)) {
                        requestId = requestIdInt;
                    }
                }
                int status = 0;
                if (appointment.Status != null) {
                    if (int.TryParse(appointment.Status, out int statusInt)) {
                        status = statusInt;
                    }
                }
                DateTime? checkIn = null;
                if (appointment.CheckInDateTime != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(appointment.CheckInDateTime, dateFormats,
                                           CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        checkIn = tempDateTime;
                    }
                }
                DateTime? takeback = null;
                if (appointment.TakeBackDateTime != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(appointment.TakeBackDateTime, dateFormats,
                                              CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        takeback = tempDateTime;
                    }
                }
                DateTime? checkOut = null;
                if (appointment.CheckOutDateTime != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(appointment.CheckOutDateTime, dateFormats,
                                           CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        checkOut = tempDateTime;
                    }
                }
                long? prior = null;
                if (appointment.PriorAppointmentId != null) {
                    prior = long.Parse(appointment.PriorAppointmentId);
                }
                long? linked = null;
                if (appointment.LinkedAppointmentId != null) {
                    linked = long.Parse(appointment.LinkedAppointmentId);
                }
                int schedulingCode = 0;
                if (appointment.SchedulingCodeId != null) {
                    if (int.TryParse(appointment.SchedulingCodeId, out int schedulingCodeInt)) {
                        schedulingCode = schedulingCodeInt;
                    }
                }
                long? recallId = null;
                if (appointment.RecallId != null) {
                    recallId = long.Parse(appointment.RecallId);
                }
                long? waitlistId = null;
                if (appointment.WaitingListId != null) {
                    waitlistId = long.Parse(appointment.WaitingListId);
                }
                int type = 0;
                if (appointment.AppointmentTypeId != null) {
                    if (int.TryParse(appointment.AppointmentTypeId, out int typeInt)) {
                        type = typeInt;
                    }
                }
                DateTime? updated = null;
                if (appointment.DateTimeUpdated != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(appointment.DateTimeUpdated, dateFormats,
                                                                  CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        updated = tempDateTime;
                    }
                }
                DateTime acceptableMinDateTime = DateTime.Parse("1/1/1900 12:00:00 AM");
                long appId = 0;
                if (appointment.AppointmentId != null) {
                    appId = long.Parse(appointment.AppointmentId);
                }

                var newAppointment = new SchedulingAppointment {
                    PatientId = ffpmPatient.PatientId,
                    ResourceId = resource,
                    BillingLocationId = billingLocId,
                    StartDate = start,
                    EndDate = end,
                    Notes = appointment.Notes,
                    Duration = duration,
                    DateTimeCreated = created,
                    LocationId = ffpmPatient.LocationId,
                    Confirmed = confirmed,
                    Sequence = sequence,
                    RequestId = requestId,
                    Status = status,
                    CheckInDateTime = acceptableMinDateTime,
                    TakeBackDateTime = takeback,
                    CheckOutDateTime = checkOut,
                    Description = appointment.Description,
                    PriorAppointmentId = prior,
                    LinkedAppointmentId = linked,
                    SchedulingCodeId = schedulingCode,
                    SchedulingCodeNotes = appointment.SchedulingCodeNotes,
                    AppointmentTypeId = type,
                    DateTimeUpdated = acceptableMinDateTime
                };
                ffpmDbContext.SchedulingAppointments.Add(newAppointment);
                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"Conv: Conv An error occurred while converting the appointment with ID: {appointment.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertAppointmentType(Models.AppointmentType appointmentType, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, 
            ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? duration = null;
                if (appointmentType.DefaultDuration != null) {
                    if (int.TryParse(appointmentType.DefaultDuration, out int durationInt)) {
                        duration = durationInt;
                    }
                }

                bool isActive = false;
                if (appointmentType.Active != null && appointmentType.Active.ToLower() == "yes") {
                    isActive = true;
                }
                bool schedule = false;
                if (appointmentType.CanSchedule != null && appointmentType.CanSchedule.ToLower() == "yes") {
                    schedule = true;
                }
                bool required = false;
                if (appointmentType.PatientRequired != null && appointmentType.PatientRequired.ToLower() == "yes") {
                    required = true;
                }
                bool examType = false;
                if (appointmentType.IsExamType != null && appointmentType.IsExamType.ToLower() == "yes") {
                    examType = true;
                }
                string code = "";
                if (appointmentType.Code != null) {
                    code = appointmentType.Code;
                }
                string description = "";
                if (appointmentType.Description != null) {
                    description = appointmentType.Description;
                }
                string notes = "";
                if (appointmentType.Notes != null) {
                    notes = appointmentType.Notes;
                }

                var newAppointmentType = new SchedulingAppointmentType {
                    Code = code,
                    Description = description,
                    LocationId = 0,
                    PatientRequired = required,
                    Notes = notes,
                    IsExamType = examType,
                    IsAppointmentType = true,
                    IsRecallType = false, // Will set this to true for recall types
                    DefaultDuration = duration,
                    Active = isActive,
                    CanSchedule = schedule
                };
                ffpmDbContext.SchedulingAppointmentTypes.Add(newAppointmentType);
                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"Conv: Conv An error occurred while converting the appointment type with ID: {appointmentType.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertInsurance(Models.Insurance insurance, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                var insuranceCompanies = ffpmDbContext.InsInsuranceCompanies.ToList();
                foreach (var company in insuranceCompanies) {
                    if (company.InsCompanyName == insurance.InsCompanyName) {
                        return;
                    }
                }

                int stateId = 0; // Default value for not found or null

                if (insurance.InsCompanyState != null) {
                    stateId = ConvertStateToShort(insurance.InsCompanyState) ?? 0;
                }

                string insZip = "";
                if (insurance.InsCompanyZip != null) {
                    Match match = zipRegex.Match(insurance.InsCompanyZip);
                    if (match.Success) {
                        insZip = match.Groups[1].Value;
                    }
                }

                string insEmail = "";
                if (insurance.InsCompanyEmail != null) {
                    if (emailRegex.IsMatch(insurance.InsCompanyEmail)) {
                        insEmail = insurance.InsCompanyEmail;
                    }
                }

                string insFax = "";
                if (insurance.InsCompanyFax != null) {
                    if (phoneRegex.IsMatch(insurance.InsCompanyFax)) {
                        insFax = insurance.InsCompanyFax;
                    }
                }

                string insPhone = "";
                if (insurance.InsCompanyPhone != null) {
                    if (phoneRegex.IsMatch(insurance.InsCompanyPhone)) {
                        insPhone = insurance.InsCompanyPhone;
                    }
                }

                string payerId = "";
                if (insurance.InsCompanyCode != null) {
                    payerId = insurance.InsCompanyCode;
                }

                bool active = false;
                if (insurance.IsActive != null && insurance.IsActive.ToLower() == "yes") {
                    active = true;
                }

                bool collections = false;
                if (insurance.IsCollections != null && insurance.IsCollections.ToLower() == "yes") {
                    collections = true;
                }

                bool dmerc = false;
                if (insurance.IsDmerc != null && insurance.IsDmerc.ToLower() == "yes") {
                    dmerc = true;
                }
                string companyName = "";
                if (insurance.InsCompanyName != null) {
                    companyName = insurance.InsCompanyName;
                }
                string code = "";
                if (insurance.InsCompanyCode != null) {
                    code = insurance.InsCompanyCode;
                }
                int companyId = 0;
                if (insurance.InsCompanyId != null) {
                    if (int.TryParse(insurance.InsCompanyId, out int companyIdInt)) {
                        companyId = companyIdInt;
                    }
                }
                int claimTypeId = 0;
                if (insurance.InsCompanyClaimType != null) {
                    if (insurance.InsCompanyClaimType.ToLower() == "medical") {
                        claimTypeId = 1;
                    } else if (insurance.InsCompanyClaimType.ToLower() == "vision") {
                        claimTypeId = 2;
                    }
                }
                int policyTypeId = 0;
                if (insurance.InsCompanyPolicyType != null) {
                    if (insurance.InsCompanyPolicyType.ToLower() == "medical") {
                        policyTypeId = 1;
                    } else if (insurance.InsCompanyPolicyType.ToLower() == "vision") {
                        policyTypeId = 2;
                    }
                }
                int? carrierTypeId = 0;
                if (insurance.InsCompanyCarrierType == "medical") {
                    carrierTypeId = 1;
                } else if (insurance.InsCompanyCarrierType == "vision") {
                    carrierTypeId = 2;
                }

                var newInsuranceCompany = new Brady_s_Conversion_Program.ModelsA.InsInsuranceCompany {
                    InsCompanyName = companyName,
                    InsCompanyAddress1 = insurance.InsCompanyAddress1,
                    InsCompanyAddress2 = insurance.InsCompanyAddress2,
                    InsCompanyCity = insurance.InsCompanyCity,
                    InsCompanyStateId = stateId,
                    InsCompanyZip = insZip,
                    InsCompanyPhone = insPhone,
                    InsCompanyFax = insFax,
                    InsCompanyCode = code,
                    InsCompanyEmail = insEmail,
                    InsCompanyPayerId = payerId,
                    IsActive = active,
                    IsCollectionsInsurance = collections,
                    IsDmercPlaceOfService = dmerc,
                    CategoryId = 0,
                    ResponsibilityId = 0,
                    PaymentTransaction = "",
                    AdjustmentTransaction = "",
                    AcceptAssignment = true,
                    PrintAsOtherInsurance = true,
                    AllowEligibilityChecks = true,
                    ElectornicEnabled = true,
                    ApplyShiftLogic = true,
                    PaperClaimsOnly = false,
                    IsCompanyInsurance = false,
                    InsCompanyClaimTypeId = claimTypeId,
                    InsCompanyPolicyTypeId = policyTypeId,
                    InsCompanyCarrierTypeId = carrierTypeId
                };
                ffpmDbContext.InsInsuranceCompanies.Add(newInsuranceCompany);
                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"Conv: Conv An error occurred while converting the insurance with ID: {insurance.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertLocation(Models.Location location, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                string? name = null;
                if (location.LocationName != null) {
                    name = location.LocationName;
                }

                #region taxonomys
                int primaryTaxId = 0;
                if (int.TryParse(name, out primaryTaxId)) {
                    primaryTaxId = int.Parse(name);
                }
                if (location.PrimaryTaxonomyId != null) {
                    primaryTaxId = int.Parse(location.PrimaryTaxonomyId);
                }
                else {
                    logger.Log($"Conv: Conv Primary taxonomy ID not found for location with ID: {location.Id}");
                }

                int tax1Id = 0;
                if (location.AlternateTaxonomy1Id != null) {
                    tax1Id = int.Parse(location.AlternateTaxonomy1Id);
                }
                int tax2Id = 0;
                if (location.AlternateTaxonomy2Id != null) {
                    tax2Id = int.Parse(location.AlternateTaxonomy2Id);
                }
                int tax3Id = 0;
                if (location.AlternateTaxonomy3Id != null) {
                    tax3Id = int.Parse(location.AlternateTaxonomy3Id);
                }
                int tax4Id = 0;
                if (location.AlternateTaxonomy4Id != null) {
                    tax4Id = int.Parse(location.AlternateTaxonomy4Id);
                }
                int tax5Id = 0;
                if (location.AlternateTaxonomy5Id != null) {
                    tax5Id = int.Parse(location.AlternateTaxonomy5Id);
                }
                int tax6Id = 0;
                if (location.AlternateTaxonomy6Id != null) {
                    tax6Id = int.Parse(location.AlternateTaxonomy6Id);
                }
                int tax7Id = 0;
                if (location.AlternateTaxonomy7Id != null) {
                    tax7Id = int.Parse(location.AlternateTaxonomy7Id);
                }
                int tax8Id = 0;
                if (location.AlternateTaxonomy8Id != null) {
                    tax8Id = int.Parse(location.AlternateTaxonomy8Id);
                }
                int tax9Id = 0;
                if (location.AlternateTaxonomy9Id != null) {
                    tax9Id = int.Parse(location.AlternateTaxonomy9Id);
                }
                int tax10Id = 0;
                if (location.AlternateTaxonomy10Id != null) {
                    tax10Id = int.Parse(location.AlternateTaxonomy10Id);
                }
                int tax11Id = 0;
                if (location.AlternateTaxonomy11Id != null) {
                    tax11Id = int.Parse(location.AlternateTaxonomy11Id);
                }
                int tax12Id = 0;
                if (location.AlternateTaxonomy12Id != null) {
                    tax12Id = int.Parse(location.AlternateTaxonomy12Id);
                }
                int tax13Id = 0;
                if (location.AlternateTaxonomy13Id != null) {
                    tax13Id = int.Parse(location.AlternateTaxonomy13Id);
                }
                int tax14Id = 0;
                if (location.AlternateTaxonomy14Id != null) {
                    tax14Id = int.Parse(location.AlternateTaxonomy14Id);
                }
                int tax15Id = 0;
                if (location.AlternateTaxonomy15Id != null) {
                    tax15Id = int.Parse(location.AlternateTaxonomy15Id);
                }
                int tax16Id = 0;
                if (location.AlternateTaxonomy16Id != null) {
                    tax16Id = int.Parse(location.AlternateTaxonomy16Id);
                }
                int tax17Id = 0;
                if (location.AlternateTaxonomy17Id != null) {
                    tax17Id = int.Parse(location.AlternateTaxonomy17Id);
                }
                int tax18Id = 0;
                if (location.AlternateTaxonomy18Id != null) {
                    tax18Id = int.Parse(location.AlternateTaxonomy18Id);
                }
                int tax19Id = 0;
                if (location.AlternateTaxonomy19Id != null) {
                    tax19Id = int.Parse(location.AlternateTaxonomy19Id);
                }
                int tax20Id = 0;
                if (location.AlternateTaxonomy20Id != null) {
                    tax20Id = int.Parse(location.AlternateTaxonomy20Id);
                }
                #endregion taxonomys

                bool isBilling = false;
                if (location.IsBilling != null && location.IsBilling.ToLower() == "yes") {
                    isBilling = true;
                }
                bool isSchedule = false;
                if (location.IsScheduling != null && location.IsScheduling.ToLower() == "yes") {
                    isSchedule = true;
                }

                int treatmentPlaceId = 0;
                if (int.TryParse(location.PlaceOfTreatment, out int temp)) {
                    treatmentPlaceId = temp;
                }

                var newLocation = new Brady_s_Conversion_Program.ModelsA.BillingLocation {
                    PrimaryTaxonomyId = primaryTaxId,
                    AlternateTaxonomy1Id = tax1Id,
                    AlternateTaxonomy2Id = tax2Id,
                    AlternateTaxonomy3Id = tax3Id,
                    AlternateTaxonomy4Id = tax4Id,
                    AlternateTaxonomy5Id = tax5Id,
                    AlternateTaxonomy6Id = tax6Id,
                    AlternateTaxonomy7Id = tax7Id,
                    AlternateTaxonomy8Id = tax8Id,
                    AlternateTaxonomy9Id = tax9Id,
                    AlternateTaxonomy10Id = tax10Id,
                    AlternateTaxonomy11Id = tax11Id,
                    AlternateTaxonomy12Id = tax12Id,
                    AlternateTaxonomy13Id = tax13Id,
                    AlternateTaxonomy14Id = tax14Id,
                    AlternateTaxonomy15Id = tax15Id,
                    AlternateTaxonomy16Id = tax16Id,
                    AlternateTaxonomy17Id = tax17Id,
                    AlternateTaxonomy18Id = tax18Id,
                    AlternateTaxonomy19Id = tax19Id,
                    AlternateTaxonomy20Id = tax20Id,
                    Name = name,
                    IsBillingLocation = isBilling,
                    CliaIdNo = location.Clia,
                    Npi = location.Npi,
                    FederalIdNo = location.FederalEin,
                    IsSchedulingLocation = isSchedule,
                    PlaceOfTreatmentId = treatmentPlaceId,
                    LocationId = 0,
                    IsActive = true,
                    CaculateTaxOnEstimatedPatientBalance = false,
                    IsDefaultLocation = true,
                    CaculateTaxOnTotalFee = false
                };
                ffpmDbContext.BillingLocations.Add(newLocation);
                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"Conv: Conv An error occurred while converting the location with ID: {location.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertName(Models.Name name, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatients = convDbContext.Patients.ToList();
                var ConvPatient = convDbContext.Patients.FirstOrDefault(p => p.PatientAccountNumber == name.AccountNumber);
                if (ConvPatient == null) {
                    logger.Log($"Conv: Conv Conv patient not found for name with ID: {name.Id}");
                    return;
                }
                DmgPatient?ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Conv: Conv FFPM patient not found for name with ID: {name.Id}");
                    return;
                }
                DmgPatientAdditionalDetail? ffpmPatientAdditional = null;
                foreach (var details in ffpmDbContext.DmgPatientAdditionalDetails.ToList()) {
                    if (details.PatientId == ffpmPatient.PatientId) {
                        ffpmPatientAdditional = details;
                    }
                }
                if (ffpmPatientAdditional == null) {
                    logger.Log($"Conv: Conv FFPM patient additional details not found for name with ID: {name.Id}");
                    return;
                }
                long? accNum = null;
                long? addId = null;
                if (name.AccountNumber != null) {
                    DmgPatient?tempPatient = ffpmPatients.Find(p => p.AccountNumber == name.AccountNumber);
                    DmgPatientAdditionalDetail? tempAdditionalDetail = null;
                    if (tempPatient == null) {
                        logger.Log($"Conv: Conv FFPM patient w/ account number not found for name with ID: {name.Id}");
                        return;
                    }
                    foreach (var details in ffpmDbContext.DmgPatientAdditionalDetails.ToList()) {
                        if (details.PatientId == tempPatient.PatientId) {
                            tempAdditionalDetail = details;
                        }
                    }
                    accNum = tempPatient.PatientId;
                    addId = tempPatient.AddressId;
                }
                string? ssn = null;
                if (name.Ssn != null && ssnRegex.IsMatch(name.Ssn)) {
                    ssn = name.Ssn;
                }

                DateTime? dob = null;
                if (name.Dob != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(name.Dob, dateFormats,
                                           CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dob = tempDateTime;
                    }
                }
                short? genderInt = null;
                if (name.Sex != null) {
                    if (name.Sex.ToUpper() == "M" || name.Sex.ToLower() == "male") {
                        genderInt = 1;
                    }
                    else if (name.Sex.ToUpper() == "F" || name.Sex.ToLower() == "female") {
                        genderInt = 2;
                    } else {
                        genderInt = 0;
                    }
                }
                if (name.Relationship == null) {
                    logger.Log($"Conv: Conv Relationship is null for name with ID: {name.Id}");
                    return;
                }
                if (name.Relationship.ToLower() == "emergency contact") {
                    ffpmPatientAdditional.EmergencyLast = name.LastName;
                    ffpmPatientAdditional.EmergencyFirst = name.FirstName;
                    ffpmPatientAdditional.EmergencyPatientId = accNum;
                    ffpmPatientAdditional.EmergencyAddressId = addId;
                }
                else if (name.Relationship.ToLower() == "guarantor") {
                    bool isExistingPatient = false;
                    if (accNum != null) {
                        isExistingPatient = true;
                    }
                    var newGuarantor = new Brady_s_Conversion_Program.ModelsA.DmgGuarantor {
                        PatientId = ffpmPatient.PatientId,
                        AddressId = addId,
                        IsGuarantorExistingPatient = isExistingPatient,
                        FirstName = name.FirstName,
                        LastName = name.LastName,
                        MiddleName = name.MiddleName,
                        Ssn = ssn,
                        Dob = dob,
                        GenderId = genderInt
                    };
                    ffpmDbContext.DmgGuarantors.Add(newGuarantor);
                    ffpmDbContext.SaveChanges();
                }
                else if (name.Relationship.ToLower() == "employer") {
                    ffpmPatientAdditional.EmployerName = name.LastName;
                    ffpmPatientAdditional.EmployerWebsite = name.FirstName;
                    ffpmPatientAdditional.EmployerAddressId = addId;
                }
                else {
                    logger.Log($"Conv: Conv Invalid relationship for name with ID: {name.Id}");
                    return;
                }
                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"Conv: Conv An error occurred while converting the name with ID: {name.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertPatientAlert(Models.PatientAlert patientAlert, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, 
            ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.Find(patientAlert.Id);
                if (ConvPatient == null) {
                    logger.Log($"Conv: Conv Patient not found for patient alert with ID: {patientAlert.Id}");
                    return;
                }
                DmgPatient?ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Conv: Conv Patient not found for patient alert with ID: {patientAlert.Id}");
                    return;
                }
                short? priorityID = null;
                if (patientAlert.PriorityId != null) {
                    if (short.TryParse(patientAlert.PriorityId, out short priority)) {
                        priorityID = priority;
                    }
                }

                DateTime? alertDate = null;
                if (patientAlert.AlertCreatedDate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(patientAlert.AlertCreatedDate, dateFormats,
                                           CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        alertDate = tempDateTime;
                    }
                }
                DateTime? alertEndDate = null;
                if (patientAlert.AlertExpiryDate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(patientAlert.AlertExpiryDate, dateFormats,
                                                  CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        alertEndDate = tempDateTime;
                    }
                }
                long? alertCreatedBy = null;
                if (patientAlert.AlertCreatedBy != null) {
                    if (long.TryParse(patientAlert.AlertCreatedBy, out long createdBy)) {
                        alertCreatedBy = createdBy;
                    }
                }
                bool? isActive = null;
                if (patientAlert.IsActive != null) {
                    if (bool.TryParse(patientAlert.IsActive, out bool active)) {
                        isActive = active;
                    }
                }
                bool? alertFlash = null;
                if (patientAlert.AlertFlash != null) {
                    if (bool.TryParse(patientAlert.AlertFlash, out bool flash)) {
                        alertFlash = flash;
                    }
                }

                var newPatientAlert = new Brady_s_Conversion_Program.ModelsA.DmgPatientAlert {
                    PatientId = ffpmPatient.PatientId,
                    AlertMessage = patientAlert.AlertMessage,
                    PriorityId = priorityID,
                    AlertCreatedDate = alertDate,
                    AlertCreatedBy = alertCreatedBy,
                    AlertExpiryDate = alertEndDate,
                    IsActive = isActive,
                    AlertFlash = alertFlash
                };
                ffpmDbContext.DmgPatientAlerts.Add(newPatientAlert);
                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"Conv: Conv An error occurred while converting the patient alert with ID: {patientAlert.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertPatientDocument(Models.PatientDocument patientDocument, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, 
            ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.Find(patientDocument.Id);
                if (ConvPatient == null) {
                    logger.Log($"Conv: Conv Patient not found for patient document with ID: {patientDocument.Id}");
                    return;
                }
                DmgPatient?ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Conv: Conv Patient not found for patient document with ID: {patientDocument.Id}");
                    return;
                }
                short? imageType = null;
                if (patientDocument.DocumentImageType != null) {
                    if (short.TryParse(patientDocument.DocumentImageType, out short type)) {
                        imageType = type;
                    }
                }

                DateTime? dateDocument = null;
                if (patientDocument.Date != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(patientDocument.Date, dateFormats,
                                                  CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dateDocument = tempDateTime;
                    }
                }

                var newPatientDocument = new Brady_s_Conversion_Program.ModelsA.ImgPatientDocument {
                    PatientId = ffpmPatient.PatientId,
                    DocumentType = imageType,
                    DocumentRemarks = patientDocument.DocumentNotes,
                    AddedDate = dateDocument,
                    DocumentName = patientDocument.DocumentDescription,
                    DocumentLocation = patientDocument.FilePathName,
                };
                ffpmDbContext.ImgPatientDocuments.Add(newPatientDocument);
                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"Conv: Conv An error occurred while converting the patient document with ID: {patientDocument.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertPatientInsurance(Models.PatientInsurance patientInsurance, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, 
            ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.Find(patientInsurance.Id);
                if (ConvPatient == null) {
                    logger.Log($"Conv: Conv Patient not found for patient insurance with ID: {patientInsurance.Id}");
                    return;
                }
                DmgPatient?ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Conv: Conv Patient not found for patient insurance with ID: {patientInsurance.Id}");
                    return;
                }
                Models.Insurance? patientInsuranceCompany = null;
                foreach (var insurance in convDbContext.Insurances.ToList()) {
                    if (insurance.InsCompanyCode == patientInsurance.Code) {
                        patientInsuranceCompany = insurance;
                    }
                }
                if (patientInsuranceCompany == null) {
                    logger.Log($"Conv: Conv Insurance company not found for patient insurance with ID: {patientInsurance.Id}");
                    return;
                }

                DateTime? startDate = null;
                if (patientInsurance.StartDate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(patientInsurance.StartDate, dateFormats,
                                             CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        startDate = tempDateTime;
                    }
                }
                DateOnly? endDate = null;
                if (patientInsurance.EndDate != null) {
                    DateOnly tempDateTime;
                    if (!DateOnly.TryParseExact(patientInsurance.EndDate, dateFormats,
                                             CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        endDate = tempDateTime;
                    }
                }
                decimal? copay = null;
                if (patientInsurance.Copay != null) {
                    if (decimal.TryParse(patientInsurance.Copay, out decimal copayDec)) {
                        copay = copayDec;
                    }
                }
                decimal? deductible = null;
                if (patientInsurance.Deductible != null) {
                    if (decimal.TryParse(patientInsurance.Deductible, out decimal deductibleDec)) {
                        deductible = deductibleDec;
                    }
                }
                short? rank = null;
                if (patientInsurance.Rank == "primary") {
                    rank = 1;
                }
                else if (patientInsurance.Rank == "secondary") {
                    rank = 2;
                }
                else if (patientInsurance.Rank == "tertiary") {
                    rank = 3;
                }
                else {
                    rank = 1;
                }
                bool isAdditional = false;
                if (rank == 2 || rank == 3) {
                    isAdditional = true;
                }
                bool medical = false;
                bool vision = false;
                if (patientInsurance.MedicalVision == "medical") {
                    medical = true;
                }
                else if (patientInsurance.MedicalVision == "vision") {
                    vision = true;
                }
                else {
                    medical = true;
                }
                int plan_id = 0;
                int insCompId = 0;
                InsInsuranceCompany? insuranceCompany = null;
                foreach (var insComp in ffpmDbContext.InsInsuranceCompanies.ToList()) {
                    if (insComp.InsCompanyCode == patientInsurance.Code) {
                        insuranceCompany = insComp;
                    }
                }
                if (insuranceCompany == null) {
                    logger.Log($"Conv: Conv Insurance company not found for patient insurance with ID: {patientInsurance.Id}");
                    return;
                }
                insCompId = insuranceCompany.InsCompanyId;

                var newPatientInsurance = new Brady_s_Conversion_Program.ModelsA.DmgPatientInsurance {
                    PatientId = ffpmPatient.PatientId,
                    StartDate = startDate,
                    EndDate = endDate,
                    Copay = copay,
                    Deductible = deductible,
                    Rank = rank,
                    PlanId = plan_id,
                    IsMedicalInsurance = medical,
                    IsVisionInsurance = vision,
                    IsAdditionalInsurance = isAdditional,
                    InsuranceCompanyId = insCompId,
                    PolicyNumber = patientInsurance.Cert,
                    GroupId = patientInsurance.Group
                    
                };
                ffpmDbContext.DmgPatientInsurances.Add(newPatientInsurance);
                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"Conv: Conv An error occurred while converting the patient insurance with ID: {patientInsurance.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertPatientNote(Models.PatientNote patientNote, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, 
            ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                if (patientNote.PatientId == null) {
                    logger.Log($"Conv: Conv Patient ID is null for patient note with ID: {patientNote.Id}");
                    return;
                }
                int? patientId = int.Parse(patientNote.PatientId);
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.FirstOrDefault(p => p.Id == patientId);
                if (ConvPatient == null) {
                    logger.Log($"Conv: Conv Patient not found for patient note with ID: {patientNote.Id}");
                    return;
                }
                DmgPatient?ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Conv: Conv Patient not found for patient note with ID: {patientNote.Id}");
                    return;
                }

                var newPatientRemarks = new Brady_s_Conversion_Program.ModelsA.DmgPatientRemark {
                    PatientId = ffpmPatient.PatientId,
                    Remarks = patientNote.Note
                };
                ffpmDbContext.DmgPatientRemarks.Add(newPatientRemarks);
                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"Conv: Conv An error occurred while converting the patient note with ID: {patientNote.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertPhone(Models.Phone phone, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.Find(phone.Id);
                var ffpmAddresses = ffpmDbContext.DmgPatientAddresses.ToList();
                if (ConvPatient == null) {
                    logger.Log($"Conv: Conv Patient not found for phone with ID: {phone.Id}");
                    return;
                }
                if (ffpmPatients == null) {
                    logger.Log($"Conv: Conv Patient not found for phone with ID: {phone.Id}");
                    return;
                }
                if (ffpmAddresses == null) {
                    logger.Log($"Conv: Conv Patient not found for phone with ID: {phone.Id}");
                    return;
                }
                DmgPatient?ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Conv: Conv Patient not found for phone with ID: {phone.Id}");
                    return;
                }
                DmgPatientAddress? address = ffpmAddresses.Find(p => p.PatientId == ffpmPatient.PatientId);
                if (address == null) {
                    logger.Log($"Conv: Conv Patient not found for phone with ID: {phone.Id}");
                    return;
                }

                if (phone.TypeOfPhone != null) {
                    switch (phone.TypeOfPhone.ToLower()) {
                        case "home":
                            address.HomePhone = phone.PhoneNumber;
                            break;
                        case "work":
                            address.WorkPhone = phone.PhoneNumber;
                            break;
                        case "cell":
                            address.CellPhone = phone.PhoneNumber;
                            break;
                        case "mobile":
                            address.CellPhone = phone.PhoneNumber;
                            break;
                        case "fax":
                            address.Fax = phone.PhoneNumber;
                            break;
                        default:
                            address.CellPhone = phone.PhoneNumber;
                            break;
                    }
                    address.Extension = phone.Extension;
                } else {
                    address.CellPhone = phone.PhoneNumber;
                    address.Extension = phone.Extension;
                }

                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"Conv: Conv An error occurred while converting the phone with ID: {phone.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertProvider(Models.Provider provider, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                short? suffixInt = null;
                if (provider.Suffix != null) {
                    switch (provider.Suffix.ToLower()) {
                        case "jr":
                        case "jr.":
                            suffixInt = 1;
                            break;
                        case "sr":
                        case "sr.":
                            suffixInt = 2;
                            break;
                        case "ii":
                            suffixInt = 3;
                            break;
                        case "iii":
                            suffixInt = 4;
                            break;
                        case "iv":
                            suffixInt = 5;
                            break;
                        case "v":
                            suffixInt = 6;
                            break;
                    }
                }

                short? titleInt = null;
                if (provider.Title != null) {
                    switch (provider.Title.ToLower()) {
                        case "mr":
                        case "mr.":
                            titleInt = 1;
                            break;
                        case "mrs":
                        case "mrs.":
                            titleInt = 2;
                            break;
                        case "ms":
                        case "ms.":
                            titleInt = 3;
                            break;
                        case "miss":
                            titleInt = 4;
                            break;
                    }
                }

                string? ssnString = null;
                if (provider.ProviderSsn != null) {
                    if (ssnRegex.IsMatch(provider.ProviderSsn)) {
                        ssnString = provider.ProviderSsn;
                    }
                }

                DateTime? dobDate = null;
                if (provider.ProviderDob != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParse(provider.ProviderDob, out tempDateTime)) {
                        dobDate = tempDateTime;
                    }
                }

                string? einString = null;
                if (provider.ProviderEin != null) {
                    einString = provider.ProviderEin;
                }

                string? upinString = null;
                if (provider.ProviderUpin != null) {
                    upinString = provider.ProviderUpin;
                }

                string? npiString = null;
                if (provider.ProviderNpi != null) {
                    npiString = provider.ProviderNpi;
                }

                bool? isActive = null;
                if (provider.IsActive != null && provider.IsActive.ToLower() == "yes") {
                    isActive = true;
                }

                int clExpId = 0;
                if (provider.ClExpiration != null) {
                    if (int.TryParse(provider.ClExpiration, out int clExpIdInt)) {
                        clExpId = clExpIdInt;
                    }
                }
                int clExpTypeId = 0;

                int specExpId = 0;
                if (provider.SpectacleExpiration != null) {
                    if (int.TryParse(provider.SpectacleExpiration, out int specExpIdInt)) {
                        specExpId = specExpIdInt;
                    }
                }
                int specExpTypeId = 0;

                int? stateId = 0;
                if (provider.LicenseIssuingStateId != null) {
                    if (int.TryParse(provider.LicenseIssuingStateId, out int stateIdInt)) {
                        stateId = stateIdInt;
                    }
                }

                int? countryId = 0;
                if (provider.LicenseIssuingCountryId != null) {
                    if (int.TryParse(provider.LicenseIssuingCountryId, out int countryIdInt)) {
                        countryId = countryIdInt;
                    }
                }

                int? specialtyId = null;
                if (provider.ProviderSpecialityId != null) {
                    if (int.TryParse(provider.ProviderSpecialityId, out int specialtyIdInt)) {
                        specialtyId = specialtyIdInt;
                    }
                }

                #region taxonomys
                int primaryTaxId = 0;
                if (provider.PrimaryTaxonomyId != null) {
                    primaryTaxId = int.Parse(provider.PrimaryTaxonomyId);
                }
                else {
                    logger.Log($"Conv: Conv Primary taxonomy ID not found for provider with ID: {provider.Id}");
                }

                int tax1Id = 0;
                if (provider.AlternateTaxonomy1Id != null) {
                    tax1Id = int.Parse(provider.AlternateTaxonomy1Id);
                }
                int tax2Id = 0;
                if (provider.AlternateTaxonomy2Id != null) {
                    tax2Id = int.Parse(provider.AlternateTaxonomy2Id);
                }
                int tax3Id = 0;
                if (provider.AlternateTaxonomy3Id != null) {
                    tax3Id = int.Parse(provider.AlternateTaxonomy3Id);
                }
                int tax4Id = 0;
                if (provider.AlternateTaxonomy4Id != null) {
                    tax4Id = int.Parse(provider.AlternateTaxonomy4Id);
                }
                int tax5Id = 0;
                if (provider.AlternateTaxonomy5Id != null) {
                    tax5Id = int.Parse(provider.AlternateTaxonomy5Id);
                }
                int tax6Id = 0;
                if (provider.AlternateTaxonomy6Id != null) {
                    tax6Id = int.Parse(provider.AlternateTaxonomy6Id);
                }
                int tax7Id = 0;
                if (provider.AlternateTaxonomy7Id != null) {
                    tax7Id = int.Parse(provider.AlternateTaxonomy7Id);
                }
                int tax8Id = 0;
                if (provider.AlternateTaxonomy8Id != null) {
                    tax8Id = int.Parse(provider.AlternateTaxonomy8Id);
                }
                int tax9Id = 0;
                if (provider.AlternateTaxonomy9Id != null) {
                    tax9Id = int.Parse(provider.AlternateTaxonomy9Id);
                }
                int tax10Id = 0;
                if (provider.AlternateTaxonomy10Id != null) {
                    tax10Id = int.Parse(provider.AlternateTaxonomy10Id);
                }
                int tax11Id = 0;
                if (provider.AlternateTaxonomy11Id != null) {
                    tax11Id = int.Parse(provider.AlternateTaxonomy11Id);
                }
                int tax12Id = 0;
                if (provider.AlternateTaxonomy12Id != null) {
                    tax12Id = int.Parse(provider.AlternateTaxonomy12Id);
                }
                int tax13Id = 0;
                if (provider.AlternateTaxonomy13Id != null) {
                    tax13Id = int.Parse(provider.AlternateTaxonomy13Id);
                }
                int tax14Id = 0;
                if (provider.AlternateTaxonomy14Id != null) {
                    tax14Id = int.Parse(provider.AlternateTaxonomy14Id);
                }
                int tax15Id = 0;
                if (provider.AlternateTaxonomy15Id != null) {
                    tax15Id = int.Parse(provider.AlternateTaxonomy15Id);
                }
                int tax16Id = 0;
                if (provider.AlternateTaxonomy16Id != null) {
                    tax16Id = int.Parse(provider.AlternateTaxonomy16Id);
                }
                int tax17Id = 0;
                if (provider.AlternateTaxonomy17Id != null) {
                    tax17Id = int.Parse(provider.AlternateTaxonomy17Id);
                }
                int tax18Id = 0;
                if (provider.AlternateTaxonomy18Id != null) {
                    tax18Id = int.Parse(provider.AlternateTaxonomy18Id);
                }
                int tax19Id = 0;
                if (provider.AlternateTaxonomy19Id != null) {
                    tax19Id = int.Parse(provider.AlternateTaxonomy19Id);
                }
                int tax20Id = 0;
                if (provider.AlternateTaxonomy20Id != null) {
                    tax20Id = int.Parse(provider.AlternateTaxonomy20Id);
                }
                #endregion taxonomys


                DmgProvider? ffpmProvider = null;
                foreach (var prov in ffpmDbContext.DmgProviders.ToList()) {
                    if (prov.ProviderCode == provider.ProviderCode) {
                        ffpmProvider = prov;
                    }
                }
                if (ffpmProvider != null) {
                    ffpmProvider.FirstName = provider.FirstName;
                    ffpmProvider.MiddleName = provider.MiddleName;
                    ffpmProvider.LastName = provider.LastName;
                    ffpmProvider.ProviderCode = provider.ProviderCode;
                    ffpmProvider.SuffixId = suffixInt;
                    ffpmProvider.TitleId = titleInt;
                    ffpmProvider.ProviderSsn = ssnString;
                    ffpmProvider.ProviderEin = einString;
                    ffpmProvider.ProviderUpin = upinString;
                    ffpmProvider.ProviderDob = dobDate;
                    ffpmProvider.ProviderNpi = npiString;
                    ffpmProvider.IsActive = isActive;
                    ffpmProvider.ClExpiration = clExpId;
                    ffpmProvider.ClExpirationTypeId = clExpTypeId;
                    ffpmProvider.SpectacleExpiration = specExpId;
                    ffpmProvider.SpectacleExpirationTypeId = specExpTypeId;
                    ffpmProvider.LicenseIssuingStateId = stateId;
                    ffpmProvider.ProviderLicenseNo = provider.ProviderLicenseNo;
                    ffpmProvider.PrimaryTaxonomyId = primaryTaxId;
                    ffpmProvider.ProviderDeaNumber = provider.ProviderDeaNumber;
                    ffpmProvider.ProviderSpecialityId = specialtyId;
                    ffpmProvider.AlternateTaxonomy1Id = tax1Id;
                    ffpmProvider.AlternateTaxonomy2Id = tax2Id;
                    ffpmProvider.AlternateTaxonomy3Id = tax3Id;
                    ffpmProvider.AlternateTaxonomy4Id = tax4Id;
                    ffpmProvider.AlternateTaxonomy5Id = tax5Id;
                    ffpmProvider.AlternateTaxonomy6Id = tax6Id;
                    ffpmProvider.AlternateTaxonomy7Id = tax7Id;
                    ffpmProvider.AlternateTaxonomy8Id = tax8Id;
                    ffpmProvider.AlternateTaxonomy9Id = tax9Id;
                    ffpmProvider.AlternateTaxonomy10Id = tax10Id;
                    ffpmProvider.AlternateTaxonomy11Id = tax11Id;
                    ffpmProvider.AlternateTaxonomy12Id = tax12Id;
                    ffpmProvider.AlternateTaxonomy13Id = tax13Id;
                    ffpmProvider.AlternateTaxonomy14Id = tax14Id;
                    ffpmProvider.AlternateTaxonomy15Id = tax15Id;
                    ffpmProvider.AlternateTaxonomy16Id = tax16Id;
                    ffpmProvider.AlternateTaxonomy17Id = tax17Id;
                    ffpmProvider.AlternateTaxonomy18Id = tax18Id;
                    ffpmProvider.AlternateTaxonomy19Id = tax19Id;
                    ffpmProvider.AlternateTaxonomy20Id = tax20Id;
                    ffpmDbContext.SaveChanges();
                    return;
                }

                var newPatientProvider = new Brady_s_Conversion_Program.ModelsA.DmgProvider {
                    FirstName = provider.FirstName,
                    MiddleName = provider.MiddleName,
                    LastName = provider.LastName,
                    ProviderCode = provider.ProviderCode,
                    SuffixId = suffixInt,
                    TitleId = titleInt,
                    ProviderSsn = ssnString,
                    ProviderEin = einString,
                    ProviderUpin = upinString,
                    ProviderDob = dobDate,
                    ProviderNpi = npiString,
                    IsActive = isActive,
                    IsReferringProvider = false,
                    SignatureUrl = "",
                    GroupId = 0,
                    SpectacleExpiration = specExpId,
                    SpectacleExpirationTypeId = specExpTypeId,
                    ClExpirationTypeId = clExpId,
                    ClExpiration = clExpTypeId,
                    LicenseIssuingStateId = stateId,
                    LicenseIssuingCountryId = countryId,
                    ProviderDeaNumber = provider.ProviderDeaNumber,
                    PrimaryTaxonomyId = primaryTaxId,
                    AlternateTaxonomy1Id = tax1Id,
                    AlternateTaxonomy2Id = tax2Id,
                    AlternateTaxonomy3Id = tax3Id,
                    AlternateTaxonomy4Id = tax4Id,
                    AlternateTaxonomy5Id = tax5Id,
                    AlternateTaxonomy6Id = tax6Id,
                    AlternateTaxonomy7Id = tax7Id,
                    AlternateTaxonomy8Id = tax8Id,
                    AlternateTaxonomy9Id = tax9Id,
                    AlternateTaxonomy10Id = tax10Id,
                    AlternateTaxonomy11Id = tax11Id,
                    AlternateTaxonomy12Id = tax12Id,
                    AlternateTaxonomy13Id = tax13Id,
                    AlternateTaxonomy14Id = tax14Id,
                    AlternateTaxonomy15Id = tax15Id,
                    AlternateTaxonomy16Id = tax16Id,
                    AlternateTaxonomy17Id = tax17Id,
                    AlternateTaxonomy18Id = tax18Id,
                    AlternateTaxonomy19Id = tax19Id,
                    AlternateTaxonomy20Id = tax20Id
                };
                ffpmDbContext.DmgProviders.Add(newPatientProvider);
                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"Conv: Conv An error occurred while converting the provider with ID: {provider.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertRecall(Models.Recall recall, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.FirstOrDefault(p => p.PatientAccountNumber == recall.PatientId);
                if (ConvPatient == null) {
                    logger.Log($"Conv: Conv Patient not found for recall with ID: {recall.Id}");
                    return;
                }
                DmgPatient?ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Conv: Conv Patient not found for recall with ID: {recall.Id}");
                    return;
                }

                int appointmentType = 0;
                if (int.TryParse(recall.RecallTypeId, out int temp)) {
                    appointmentType = temp;
                }
                int resource = 0;
                if (int.TryParse(recall.ResourceId, out temp)) {
                    resource = temp;
                }
                int billingLocation = 0;
                if (int.TryParse(recall.BillingLocationId, out temp)) {
                    billingLocation = temp;
                }
                DateOnly recallDate = new DateOnly();
                if (recall.RecallDate != null) {
                    DateOnly tempDate;
                    if (!DateOnly.TryParseExact(recall.RecallDate, dateFormats,
                                                  CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDate)) {
                        recallDate = tempDate;
                    }
                }
                bool isActive = false;
                if (recall.Active != null && recall.Active.ToLower() == "yes") {
                    isActive = true;
                }

                int location = 0;
                int number = 0;
                string note = "";
                if (recall.Notes != null) {
                    note = recall.Notes;
                }

                var newRecallList = new Brady_s_Conversion_Program.ModelsA.SchedulingPatientRecallList {
                    PatientId = ffpmPatient.PatientId,
                    AppointmentTypeId = appointmentType,
                    Notes = note,
                    ResourceId = resource,
                    BillingLocationId = billingLocation,
                    RecallListDate = recallDate,
                    Active = isActive,
                    LocationId = location,
                    NumberOfRecallSent = number
                };
                ffpmDbContext.SchedulingPatientRecallLists.Add(newRecallList);
                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"Conv: Conv An error occurred while converting the recall with ID: {recall.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertRecallType(Models.RecallType recallType, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                // Log or handle recall type actions
                string code = "";
                if (recallType.Code != null) {
                    code = recallType.Code;
                }
                string description = "";
                if (recallType.Description != null) {
                    description = recallType.Description;
                }
                int defaultDuration = 0;
                if (int.TryParse(recallType.DefaultDuration, out int temp)) {
                    defaultDuration = temp;
                }
                bool isActive = false;
                if (recallType.Active != null && recallType.Active.ToLower() == "yes") {
                    isActive = true;
                }
                string note = "";
                if (recallType.Notes != null) {
                    note = recallType.Notes;
                }

                var newRecallType = new Brady_s_Conversion_Program.ModelsA.SchedulingAppointmentType {
                    IsRecallType = true,
                    IsAppointmentType = false,
                    IsExamType = false,
                    Code = code,
                    Description = description,
                    DefaultDuration = defaultDuration,
                    Active = isActive,
                    Notes = note,
                    LocationId = 0,
                    PatientRequired = false,

                };
                ffpmDbContext.SchedulingAppointmentTypes.Add(newRecallType);

                ffpmDbContext.SaveChanges();
            } catch (Exception ex) {
                logger.Log($"Conv: Conv An error occurred while converting the recall type with ID: {recallType.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertReferral(Models.Referral referral, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                var providersList = ffpmDbContext.DmgProviders.ToList();

                long providerID = 0;
                if (long.TryParse(referral.ReferralId, out providerID)) {
                    providerID = long.Parse(referral.ReferralId);
                }
                else {
                    logger.Log($"Conv: Conv Provider ID not found for referral with ID: {referral.Id}");
                }

                short? suffixInt = null;
                if (referral.Suffix != null) {
                    switch (referral.Suffix.ToLower()) {
                        case "jr":
                        case "jr.":
                            suffixInt = 1;
                            break;
                        case "sr":
                        case "sr.":
                            suffixInt = 2;
                            break;
                        case "ii":
                            suffixInt = 3;
                            break;
                        case "iii":
                            suffixInt = 4;
                            break;
                        case "iv":
                            suffixInt = 5;
                            break;
                        case "v":
                            suffixInt = 6;
                            break;
                    }
                }

                short? titleInt = null;
                if (referral.Title != null) {
                    switch (referral.Title.ToLower()) {
                        case "mr":
                        case "mr.":
                            titleInt = 1;
                            break;
                        case "mrs":
                        case "mrs.":
                            titleInt = 2;
                            break;
                        case "ms":
                        case "ms.":
                            titleInt = 3;
                            break;
                        case "miss":
                            titleInt = 4;
                            break;
                    }
                }

                string? ssnString = null;
                if (referral.ReferralSsn != null) {
                    if (ssnRegex.IsMatch(referral.ReferralSsn)) {
                        ssnString = referral.ReferralSsn;
                    }
                }

                DateTime? dobDate = null;
                if (referral.ReferralDob != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParse(referral.ReferralDob, out tempDateTime)) {
                        dobDate = tempDateTime;
                    }
                }

                string? einString = null;
                if (referral.ReferralEin != null) {
                    einString = referral.ReferralEin;
                }

                string? upinString = null;
                if (referral.ReferralUpin != null) {
                    upinString = referral.ReferralUpin;
                }

                string? npiString = null;
                if (referral.ReferralNpi != null) {
                    npiString = referral.ReferralNpi;
                }

                bool? isActive = null;
                if (referral.IsActive != null && referral.IsActive.ToLower() == "yes") {
                    isActive = true;
                }

                #region taxonomys
                int primaryTaxId = 0;
                if (int.TryParse(referral.PrimaryTaxonomyId, out primaryTaxId)) {
                    primaryTaxId = int.Parse(referral.PrimaryTaxonomyId);
                }
                if (referral.PrimaryTaxonomyId != null) {
                    primaryTaxId = int.Parse(referral.PrimaryTaxonomyId);
                }
                else {
                    logger.Log($"Conv: Conv Primary taxonomy ID not found for referral with ID: {referral.Id}");
                }

                int tax1Id = 0;
                if (referral.AlternateTaxonomy1Id != null) {
                    tax1Id = int.Parse(referral.AlternateTaxonomy1Id);
                }
                int tax2Id = 0;
                if (referral.AlternateTaxonomy2Id != null) {
                    tax2Id = int.Parse(referral.AlternateTaxonomy2Id);
                }
                int tax3Id = 0;
                if (referral.AlternateTaxonomy3Id != null) {
                    tax3Id = int.Parse(referral.AlternateTaxonomy3Id);
                }
                int tax4Id = 0;
                if (referral.AlternateTaxonomy4Id != null) {
                    tax4Id = int.Parse(referral.AlternateTaxonomy4Id);
                }
                int tax5Id = 0;
                if (referral.AlternateTaxonomy5Id != null) {
                    tax5Id = int.Parse(referral.AlternateTaxonomy5Id);
                }
                int tax6Id = 0;
                if (referral.AlternateTaxonomy6Id != null) {
                    tax6Id = int.Parse(referral.AlternateTaxonomy6Id);
                }
                int tax7Id = 0;
                if (referral.AlternateTaxonomy7Id != null) {
                    tax7Id = int.Parse(referral.AlternateTaxonomy7Id);
                }
                int tax8Id = 0;
                if (referral.AlternateTaxonomy8Id != null) {
                    tax8Id = int.Parse(referral.AlternateTaxonomy8Id);
                }
                int tax9Id = 0;
                if (referral.AlternateTaxonomy9Id != null) {
                    tax9Id = int.Parse(referral.AlternateTaxonomy9Id);
                }
                int tax10Id = 0;
                if (referral.AlternateTaxonomy10Id != null) {
                    tax10Id = int.Parse(referral.AlternateTaxonomy10Id);
                }
                int tax11Id = 0;
                if (referral.AlternateTaxonomy11Id != null) {
                    tax11Id = int.Parse(referral.AlternateTaxonomy11Id);
                }
                int tax12Id = 0;
                if (referral.AlternateTaxonomy12Id != null) {
                    tax12Id = int.Parse(referral.AlternateTaxonomy12Id);
                }
                int tax13Id = 0;
                if (referral.AlternateTaxonomy13Id != null) {
                    tax13Id = int.Parse(referral.AlternateTaxonomy13Id);
                }
                int tax14Id = 0;
                if (referral.AlternateTaxonomy14Id != null) {
                    tax14Id = int.Parse(referral.AlternateTaxonomy14Id);
                }
                int tax15Id = 0;
                if (referral.AlternateTaxonomy15Id != null) {
                    tax15Id = int.Parse(referral.AlternateTaxonomy15Id);
                }
                int tax16Id = 0;
                if (referral.AlternateTaxonomy16Id != null) {
                    tax16Id = int.Parse(referral.AlternateTaxonomy16Id);
                }
                int tax17Id = 0;
                if (referral.AlternateTaxonomy17Id != null) {
                    tax17Id = int.Parse(referral.AlternateTaxonomy17Id);
                }
                int tax18Id = 0;
                if (referral.AlternateTaxonomy18Id != null) {
                    tax18Id = int.Parse(referral.AlternateTaxonomy18Id);
                }
                int tax19Id = 0;
                if (referral.AlternateTaxonomy19Id != null) {
                    tax19Id = int.Parse(referral.AlternateTaxonomy19Id);
                }
                int tax20Id = 0;
                if (referral.AlternateTaxonomy20Id != null) {
                    tax20Id = int.Parse(referral.AlternateTaxonomy20Id);
                }
                #endregion taxonomys

                var newReferral = new Brady_s_Conversion_Program.ModelsA.ReferringProvider {
                    LocationId = 0,
                    FirstName = referral.FirstName,
                    MiddleName = referral.MiddleName,
                    LastName = referral.LastName,
                    RefProviderCode = referral.ReferralCode,
                    Active = isActive
                };
                ffpmDbContext.ReferringProviders.Add(newReferral);

                ffpmDbContext.SaveChanges();

                DmgProvider? ffpmProvider = null;
                foreach (var prov in ffpmDbContext.DmgProviders.ToList()) {
                    if (prov.ProviderCode == referral.ReferralCode) {
                        ffpmProvider = prov;
                    }
                }
                if (ffpmProvider != null) {
                    ffpmProvider.FirstName = referral.FirstName;
                    ffpmProvider.MiddleName = referral.MiddleName;
                    ffpmProvider.LastName = referral.LastName;
                    ffpmProvider.ProviderCode = referral.ReferralCode;
                    ffpmProvider.SuffixId = suffixInt;
                    ffpmProvider.TitleId = titleInt;
                    ffpmProvider.ProviderSsn = ssnString;
                    ffpmProvider.ProviderEin = einString;
                    ffpmProvider.ProviderUpin = upinString;
                    ffpmProvider.ProviderDob = dobDate;
                    ffpmProvider.ProviderNpi = npiString;
                    ffpmProvider.IsActive = isActive;
                    ffpmProvider.PrimaryTaxonomyId = primaryTaxId;
                    ffpmProvider.AlternateTaxonomy1Id = tax1Id;
                    ffpmProvider.AlternateTaxonomy2Id = tax2Id;
                    ffpmProvider.AlternateTaxonomy3Id = tax3Id;
                    ffpmProvider.AlternateTaxonomy4Id = tax4Id;
                    ffpmProvider.AlternateTaxonomy5Id = tax5Id;
                    ffpmProvider.AlternateTaxonomy6Id = tax6Id;
                    ffpmProvider.AlternateTaxonomy7Id = tax7Id;
                    ffpmProvider.AlternateTaxonomy8Id = tax8Id;
                    ffpmProvider.AlternateTaxonomy9Id = tax9Id;
                    ffpmProvider.AlternateTaxonomy10Id = tax10Id;
                    ffpmProvider.AlternateTaxonomy11Id = tax11Id;
                    ffpmProvider.AlternateTaxonomy12Id = tax12Id;
                    ffpmProvider.AlternateTaxonomy13Id = tax13Id;
                    ffpmProvider.AlternateTaxonomy14Id = tax14Id;
                    ffpmProvider.AlternateTaxonomy15Id = tax15Id;
                    ffpmProvider.AlternateTaxonomy16Id = tax16Id;
                    ffpmProvider.AlternateTaxonomy17Id = tax17Id;
                    ffpmProvider.AlternateTaxonomy18Id = tax18Id;
                    ffpmProvider.AlternateTaxonomy19Id = tax19Id;
                    ffpmProvider.AlternateTaxonomy20Id = tax20Id;
                    ffpmDbContext.SaveChanges();
                    return;
                }

                var newProvider = new Brady_s_Conversion_Program.ModelsA.DmgProvider {
                    FirstName = referral.FirstName,
                    MiddleName = referral.MiddleName,
                    LastName = referral.LastName,
                    ProviderCode = referral.ReferralCode,
                    IsActive = isActive,
                    IsReferringProvider = true,
                    SignatureUrl = "",
                    GroupId = 0,
                    SpectacleExpiration = 0,
                    ClExpiration = 0,
                    SpectacleExpirationTypeId = 0,
                    ClExpirationTypeId = 0,
                    PrimaryTaxonomyId = primaryTaxId,
                    AlternateTaxonomy1Id = tax1Id,
                    AlternateTaxonomy2Id = tax2Id,
                    AlternateTaxonomy3Id = tax3Id,
                    AlternateTaxonomy4Id = tax4Id,
                    AlternateTaxonomy5Id = tax5Id,
                    AlternateTaxonomy6Id = tax6Id,
                    AlternateTaxonomy7Id = tax7Id,
                    AlternateTaxonomy8Id = tax8Id,
                    AlternateTaxonomy9Id = tax9Id,
                    AlternateTaxonomy10Id = tax10Id,
                    AlternateTaxonomy11Id = tax11Id,
                    AlternateTaxonomy12Id = tax12Id,
                    AlternateTaxonomy13Id = tax13Id,
                    AlternateTaxonomy14Id = tax14Id,
                    AlternateTaxonomy15Id = tax15Id,
                    AlternateTaxonomy16Id = tax16Id,
                    AlternateTaxonomy17Id = tax17Id,
                    AlternateTaxonomy18Id = tax18Id,
                    AlternateTaxonomy19Id = tax19Id,
                    AlternateTaxonomy20Id = tax20Id,
                };
                ffpmDbContext.DmgProviders.Add(newProvider);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"Conv: Conv An error occurred while converting the referral with ID: {referral.Id}. Error: {e.Message}");
            }
        }

        public static void ConvertSchedCode(Models.SchedCode schedtype, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int type = 0;
                if (schedtype.TypeId != null) {
                    type = int.Parse(schedtype.TypeId);
                }
                string code = "";
                if (schedtype.Code != null) {
                    code = schedtype.Code;
                }
                string description = "";
                if (schedtype.Description != null) {
                    description = schedtype.Description;
                }
                bool isActive = false;
                if (schedtype.Active != null && schedtype.Active.ToLower() == "yes") {
                    isActive = true;
                }
                int location = 0;
                bool isDefault = false;
                bool noShow = false;
                if (schedtype.IsNoShow != null && schedtype.IsNoShow.ToLower() == "yes") {
                    noShow = true;
                }

                var newSchdulingCode = new Brady_s_Conversion_Program.ModelsA.SchedulingCode {
                    TypeId = type,
                    Code = code,
                    Description = description,
                    Active = isActive,
                    LocationId = location,
                    IsDefaultCode = isDefault,
                    IsNoShow = noShow
                };
                ffpmDbContext.SchedulingCodes.Add(newSchdulingCode);

                ffpmDbContext.SaveChanges();
            } catch (Exception ex) {
                logger.Log($"Conv: Conv An error occurred while converting the scheduling code with ID: {schedtype.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertAccountXref(Models.AccountXref accountXref, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            // currently not implementing renumbering
        }
        #endregion FFPMConversion

        #region EyeMDConversion

        public static void ConvertEyeMD(EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            foreach (var patient in eHRDbContext.Patients.ToList()) {
                PatientsConvert(patient, eyeMDDbContext, logger, progress);
            }

            foreach (var medicalHistory in eHRDbContext.MedicalHistories.ToList()) {
                MedicalHistoriesConvert(medicalHistory, eyeMDDbContext, logger, progress);
            }

            foreach (var visit in eHRDbContext.Visits.ToList()) {
                VisitsConvert(visit, eyeMDDbContext, logger, progress);
            }

            foreach (var visitOrders in eHRDbContext.VisitOrders.ToList()) {
                VisitOrdersConvert(visitOrders, eyeMDDbContext, logger, progress);
            }

            foreach (var visitDoctor in eHRDbContext.VisitDoctors.ToList()) {
                VisitDoctorsConvert(visitDoctor, eyeMDDbContext, logger, progress);
            }

            foreach (Allergy allergy in eHRDbContext.Allergies.ToList()) {
                AllergiesConvert(allergy, eyeMDDbContext, logger, progress);
            }

            foreach (var appointments in eHRDbContext.Appointments.ToList()) {
                AppointmentsConvert(appointments, eyeMDDbContext, logger, progress);
            }

            foreach (var contactLens in eHRDbContext.ContactLens.ToList()) {
                ContactLensesConvert(contactLens, eyeMDDbContext, logger, progress);
            }

            foreach (var diagCodePool in eHRDbContext.DiagCodePools.ToList()) {
                DiagCodePoolsConvert(diagCodePool, eyeMDDbContext, logger, progress);
            }

            foreach (var diagTest in eHRDbContext.DiagTests.ToList()) {
                DiagTestsConvert(diagTest, eyeMDDbContext, logger, progress);
            }

            foreach (var examCondition in eHRDbContext.ExamConditions.ToList()) {
                ExamConditionsConvert(examCondition, eyeMDDbContext, logger, progress);
            }

            foreach (var familyHistory in eHRDbContext.FamilyHistories.ToList()) {
                FamilyHistoriesConvert(familyHistory, eyeMDDbContext, logger, progress);
            }

            foreach (var iop in eHRDbContext.Iops.ToList()) {
                IopsConvert(iop, eyeMDDbContext, logger, progress);
            }

            foreach (var patientDocument in eHRDbContext.PatientDocuments.ToList()) {
                PatientDocumentsConvert(patientDocument, eyeMDDbContext, logger, progress);
            }

            foreach (var patientNote in eHRDbContext.PatientNotes.ToList()) {
                PatientNotesConvert(patientNote, eyeMDDbContext, logger, progress);
            }

            foreach (var planNarrative in eHRDbContext.PlanNarratives.ToList()) {
                PlanNarrativesConvert(planNarrative, eyeMDDbContext, logger, progress);
            }

            foreach (var procDiagPool in eHRDbContext.ProcDiagPools.ToList()) {
                ProcDiagPoolsConvert(procDiagPool, eyeMDDbContext, logger, progress);
            }

            foreach (var procPool in eHRDbContext.ProcPools.ToList()) {
                ProcPoolsConvert(procPool, eyeMDDbContext, logger, progress);
            }

            foreach (var refraction in eHRDbContext.Refractions.ToList()) {
                RefractionsConvert(refraction, eyeMDDbContext, logger, progress);
            }

            foreach (var ros in eHRDbContext.Ros.ToList()) {
                RosConvert(ros, eyeMDDbContext, logger, progress);
            }

            foreach (var rx in eHRDbContext.RxMedications.ToList()) {
                RxConvert(rx, eyeMDDbContext, logger, progress);
            }

            foreach (var surgHistory in eHRDbContext.SurgHistories.ToList()) {
                SurgHistoriesConvert(surgHistory, eyeMDDbContext, logger, progress);
            }

            foreach (var tech in eHRDbContext.Teches.ToList()) {
                TechsConvert(tech, eyeMDDbContext, logger, progress);
            }

            foreach (var tech2 in eHRDbContext.Tech2s.ToList()) {
                Tech2sConvert(tech2, eyeMDDbContext, logger, progress);
            }
        }

        public static void PatientsConvert(ModelsC.Patient patient, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                // This is only in case the situation arises where we do eyemd and not ffpm
                return;
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the patient with ID: {patient.Id}. Error: {e.Message}");
            }
        }

        public static void MedicalHistoriesConvert(ModelsC.MedicalHistory medicalHistory, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? visitId = null;
                if (medicalHistory.VisitId != null) {
                    if (int.TryParse(medicalHistory.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                int? ptId = null;
                if (medicalHistory.PtId != null) {
                    if (int.TryParse(medicalHistory.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                if (ptId == null && visitId == null) {
                    logger.Log($"EHR: EHR Visit ID and Patient ID not found for visit order with ID: {medicalHistory.Id}");
                }
                else if (ptId == null) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null) {
                        ptId = eyeMDVisit.PtId;
                    }
                    else {
                        logger.Log($"EHR: EHR Visit not found for visit order with ID: {medicalHistory.Id}");
                    }
                }
                else if (visitId == null) {
                    logger.Log($"EHR: EHR VisitID not found for visit order with ID: {medicalHistory.Id}");
                }

                int? controlId = null;
                if (medicalHistory.ControlId != null) {
                    if (int.TryParse(medicalHistory.ControlId, out int locum)) {
                        controlId = locum;
                    }
                }
                DateTime? dosDate = null;
                if (medicalHistory.Dosdate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(medicalHistory.Dosdate, dateFormats,
                        CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosDate = tempDateTime;
                    }
                }
                int? origVisMedHisID = null;
                if (medicalHistory.OrigVisitMedicalHistoryId != null) {
                    if (int.TryParse(medicalHistory.OrigVisitMedicalHistoryId, out int locum)) {
                        origVisMedHisID = locum;
                    }
                }
                int? origVisDiagCodePoolID = null;
                if (medicalHistory.OrigVisitDiagCodePoolId != null) {
                    if (int.TryParse(medicalHistory.OrigVisitDiagCodePoolId, out int locum)) {
                        origVisDiagCodePoolID = locum;
                    }
                }
                DateTime? origDosDate = null;
                if (medicalHistory.OrigDosdate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(medicalHistory.OrigDosdate, dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        origDosDate = tempDateTime;
                    }
                }
                string description = "";
                if (medicalHistory.Description != null) {
                    description = medicalHistory.Description;
                }
                string code = "";
                if (medicalHistory.Code != null) {
                    code = medicalHistory.Code;
                }
                string modifier = "";
                if (medicalHistory.Modifier != null) {
                    modifier = medicalHistory.Modifier;
                }
                string codeICD10 = "";
                if (medicalHistory.CodeIcd10 != null) {
                    codeICD10 = medicalHistory.CodeIcd10;
                }
                string codeSnomed = "";
                if (medicalHistory.CodeSnomed != null) {
                    codeSnomed = medicalHistory.CodeSnomed;
                }
                int? typeId = null;
                if (medicalHistory.TypeId != null) {
                    if (int.TryParse(medicalHistory.TypeId, out int locum)) {
                        typeId = locum;
                    }
                }
                string location1 = "";
                if (medicalHistory.Location1 != null) {
                    location1 = medicalHistory.Location1;
                }
                short? severity1 = null;
                if (short.TryParse(medicalHistory.Severity1, out short temp)) {
                    severity1 = temp;
                }
                string onsetMonth1 = "";
                if (medicalHistory.OnsetMonth1 != null) {
                    onsetMonth1 = medicalHistory.OnsetMonth1;
                }
                string onsetDay1 = "";
                if (medicalHistory.OnsetDay1 != null) {
                    onsetDay1 = medicalHistory.OnsetDay1;
                }
                string onsetYear1 = "";
                if (medicalHistory.OnsetYear1 != null) {
                    onsetYear1 = medicalHistory.OnsetYear1;
                }
                string location2 = "";
                if (medicalHistory.Location2 != null) {
                    location2 = medicalHistory.Location2;
                }
                short? severity2 = null;
                if (short.TryParse(medicalHistory.Severity2, out temp)) {
                    severity2 = temp;
                }
                string onsetMonth2 = "";
                if (medicalHistory.OnsetMonth2 != null) {
                    onsetMonth2 = medicalHistory.OnsetMonth2;
                }
                string onsetDay2 = "";
                if (medicalHistory.OnsetDay2 != null) {
                    onsetDay2 = medicalHistory.OnsetDay2;
                }
                string onsetYear2 = "";
                if (medicalHistory.OnsetYear2 != null) {
                    onsetYear2 = medicalHistory.OnsetYear2;
                }
                short? isResolved1 = null;
                if (short.TryParse(medicalHistory.IsResolved1, out temp)) {
                    isResolved1 = temp;
                }
                int? resolvedVisitID1 = null;
                if (medicalHistory.ResolvedVisitId1 != null) {
                    if (int.TryParse(medicalHistory.ResolvedVisitId1, out int locum)) {
                        resolvedVisitID1 = locum;
                    }
                }
                int ?resolvedReqProcID1 = null;
                if (medicalHistory.ResolvedRequestedProcedureId1 != null) {
                    if (int.TryParse(medicalHistory.ResolvedRequestedProcedureId1, out int locum)) {
                        resolvedReqProcID1 = locum;
                    }
                }
                DateTime? resolvedDate1 = null;
                if (medicalHistory.ResolvedDate1 != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(medicalHistory.ResolvedDate1, dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        resolvedDate1 = tempDateTime;
                    }
                }
                string resolveType1 = "";
                if (medicalHistory.ResolveType1 != null) {
                    resolveType1 = medicalHistory.ResolveType1;
                }
                short isResolved2 = 0;
                if (short.TryParse(medicalHistory.IsResolved2, out temp)) {
                    isResolved2 = temp;
                }
                int? resolvedVisitID2 = null;
                if (medicalHistory.ResolvedVisitId2 != null) {
                    if (int.TryParse(medicalHistory.ResolvedVisitId2, out int locum)) {
                        resolvedVisitID2 = locum;
                    }
                }
                int? resolvedReqProcID2 = null;
                if (medicalHistory.ResolvedRequestedProcedureId2 != null) {
                    if (int.TryParse(medicalHistory.ResolvedRequestedProcedureId2, out int locum)) {
                        resolvedReqProcID2 = locum;
                    }
                }
                DateTime? resolvedDate2 = null;
                if (medicalHistory.ResolvedDate2 != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(medicalHistory.ResolvedDate2, dateFormats,
                                  CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        resolvedDate2 = tempDateTime;
                    }
                }
                string resolveType2 = "";
                if (medicalHistory.ResolveType2 != null) {
                    resolveType2 = medicalHistory.ResolveType2;
                }
                string notes = "";
                if (medicalHistory.Notes != null) {
                    notes = medicalHistory.Notes;
                }
                string insertGUID = Guid.NewGuid().ToString();
                bool doNotReconcile = false;
                if (medicalHistory.DoNotReconcile != null && medicalHistory.DoNotReconcile.ToLower() == "yes") {
                    doNotReconcile = true;
                }
                DateTime? lastModified = null;
                if (medicalHistory.LastModified != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(medicalHistory.LastModified, dateFormats,
                                CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        lastModified = tempDateTime;
                    }
                }
                DateTime? created = null;
                if (medicalHistory.Created != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(medicalHistory.Created, dateFormats,
                                CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        created = tempDateTime;
                    }
                }
                int? createdEmpId = null;
                if (medicalHistory.CreatedEmpId != null) {
                    if (int.TryParse(medicalHistory.CreatedEmpId, out int locum)) {
                        createdEmpId = locum;
                    }
                }
                int? lastModifiedEmpId = null;
                if (medicalHistory.LastModifiedEmpId != null) {
                    if (int.TryParse(medicalHistory.LastModifiedEmpId, out int locum)) {
                        lastModifiedEmpId = locum;
                    }
                }

                var ehrOrig = eyeMDDbContext.EmrvisitMedicalHistories.FirstOrDefault(x => x.PtId == ptId);
                var ehrOrigVisit = eyeMDDbContext.EmrvisitMedicalHistories.FirstOrDefault(x => x.VisitId == visitId);
                if (ehrOrig != null && ehrOrigVisit != null && ehrOrig == ehrOrigVisit) {
                    ehrOrig.PtId = ptId;
                    ehrOrig.VisitId = visitId;
                    ehrOrig.ControlId = controlId;
                    ehrOrig.Dosdate = dosDate;
                    ehrOrig.OrigVisitMedicalHistoryId = origVisMedHisID;
                    ehrOrig.OrigVisitDiagCodePoolId = origVisDiagCodePoolID;
                    ehrOrig.OrigDosdate = origDosDate;
                    ehrOrig.Description = description;
                    ehrOrig.Code = code;
                    ehrOrig.Modifier = modifier;
                    ehrOrig.CodeIcd10 = codeICD10;
                    ehrOrig.CodeSnomed = codeSnomed;
                    ehrOrig.TypeId = typeId;
                    ehrOrig.Location1 = location1;
                    ehrOrig.Severity1 = severity1;
                    ehrOrig.OnsetMonth1 = onsetMonth1;
                    ehrOrig.OnsetDay1 = onsetDay1;
                    ehrOrig.OnsetYear1 = onsetYear1;
                    ehrOrig.Location2 = location2;
                    ehrOrig.Severity2 = severity2;
                    ehrOrig.OnsetMonth2 = onsetMonth2;
                    ehrOrig.OnsetDay2 = onsetDay2;
                    ehrOrig.OnsetYear2 = onsetYear2;
                    ehrOrig.IsResolved1 = isResolved1;
                    ehrOrig.ResolvedVisitId1 = resolvedVisitID1;
                    ehrOrig.ResolvedRequestedProcedureId1 = resolvedReqProcID1;
                    ehrOrig.ResolvedDate1 = resolvedDate1;
                    ehrOrig.ResolveType1 = resolveType1;
                    ehrOrig.IsResolved2 = isResolved2;
                    ehrOrig.ResolvedVisitId2 = resolvedVisitID2;
                    ehrOrig.ResolvedRequestedProcedureId2 = resolvedReqProcID2;
                    ehrOrig.ResolvedDate2 = resolvedDate2;
                    ehrOrig.ResolveType2 = resolveType2;
                    ehrOrig.Notes = notes;
                    ehrOrig.InsertGuid = insertGUID;
                    ehrOrig.DoNotReconcile = doNotReconcile;
                    ehrOrig.LastModified = lastModified;
                    ehrOrig.Created = created;
                    ehrOrig.CreatedEmpId = createdEmpId;
                    ehrOrig.LastModifiedEmpId = lastModifiedEmpId;
                    ehrOrig.Location2OnsetVisitId = null;
                    eyeMDDbContext.SaveChanges();
                    return;
                }


                var newMedicalHistory = new Brady_s_Conversion_Program.ModelsB.EmrvisitMedicalHistory {
                    PtId = ptId,
                    VisitId = visitId,
                    ControlId = controlId,
                    Dosdate = dosDate,
                    OrigVisitMedicalHistoryId = origVisMedHisID,
                    OrigVisitDiagCodePoolId = origVisDiagCodePoolID,
                    OrigDosdate = origDosDate,
                    Description = description,
                    Code = code,
                    Modifier = modifier,
                    CodeIcd10 = codeICD10,
                    CodeSnomed = codeSnomed,
                    TypeId = typeId,
                    Location1 = location1,
                    Severity1 = severity1,
                    OnsetMonth1 = onsetMonth1,
                    OnsetDay1 = onsetDay1,
                    OnsetYear1 = onsetYear1,
                    Location2 = location2,
                    Severity2 = severity2,
                    OnsetMonth2 = onsetMonth2,
                    OnsetDay2 = onsetDay2,
                    OnsetYear2 = onsetYear2,
                    IsResolved1 = isResolved1,
                    ResolvedVisitId1 = resolvedVisitID1,
                    ResolvedRequestedProcedureId1 = resolvedReqProcID1,
                    ResolvedDate1 = resolvedDate1,
                    ResolveType1 = resolveType1,
                    IsResolved2 = isResolved2,
                    ResolvedVisitId2 = resolvedVisitID2,
                    ResolvedRequestedProcedureId2 = resolvedReqProcID2,
                    ResolvedDate2 = resolvedDate2,
                    ResolveType2 = resolveType2,
                    Notes = notes,
                    InsertGuid = insertGUID,
                    DoNotReconcile = doNotReconcile,
                    LastModified = lastModified,
                    Created = created,
                    CreatedEmpId = createdEmpId,
                    LastModifiedEmpId = lastModifiedEmpId,
                    Location2OnsetVisitId = null
                };
                eyeMDDbContext.EmrvisitMedicalHistories.Add(newMedicalHistory);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the medical history with ID: {medicalHistory.Id}. Error: {e.Message}");
            }
        }

        public static void AllergiesConvert(ModelsC.Allergy allergy, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? visitId = null;
                if (allergy.VisitId != null) {
                    if (int.TryParse(allergy.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                int? ptId = null;
                if (allergy.PtId != null) {
                    if (int.TryParse(allergy.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                if (ptId == null && visitId == null) {
                    logger.Log($"EHR: EHR Visit ID and Patient ID not found for visit order with ID: {allergy.Id}");
                }
                else if (ptId == null) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null) {
                        ptId = eyeMDVisit.PtId;
                    }
                    else {
                        logger.Log($"EHR: EHR Visit not found for visit order with ID: {allergy.Id}");
                    }
                }
                else if (visitId == null) {
                    logger.Log($"EHR: EHR VisitID not found for visit order with ID: {allergy.Id}");
                }

                DateTime? dosDate = null;
                if (allergy.Dosdate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(allergy.Dosdate, dateFormats,
                        CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosDate = tempDateTime;
                    }
                }
                short? inactive = -1;
                if (allergy.Inactive != null) {
                    if (short.TryParse(allergy.Inactive, out short locum)) {
                        inactive = locum;
                    }
                }
                DateTime? created = null;
                if (allergy.Created != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(allergy.Created, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        created = tempDateTime;
                    }
                }
                int? empId = null;
                if (allergy.CreatedEmpId != null) {
                    if (int.TryParse(allergy.CreatedEmpId, out int locum)) {
                        empId = locum;
                    }
                }

                var ehrOrig = eyeMDDbContext.EmrvisitAllergies.FirstOrDefault(x => x.PtId == ptId);
                var ehrOrigVisit = eyeMDDbContext.EmrvisitAllergies.FirstOrDefault(x => x.VisitId == visitId);

                if (ehrOrig != null && ehrOrigVisit != null && ehrOrig == ehrOrigVisit) {
                    ehrOrig.PtId = ptId;
                    ehrOrig.VisitId = visitId;
                    ehrOrig.Dosdate = dosDate;
                    ehrOrig.Inactive = inactive;
                    ehrOrig.StartDate = allergy.StartDate;
                    ehrOrig.Created = created;
                    ehrOrig.CreatedEmpId = empId;
                    ehrOrig.Severity = allergy.Severity;
                    ehrOrig.Reaction = allergy.Reaction;
                    ehrOrig.AllergyName = allergy.AllergyName;
                    ehrOrig.Snomedtype = null;
                    ehrOrig.AllergyConceptId = null;
                    ehrOrig.AllergyMappingId = null;
                    ehrOrig.InsertGuid = null;
                    ehrOrig.LastModified = null;
                    ehrOrig.Rxcui = null;
                    ehrOrig.Snomed = null;
                    ehrOrig.LastModifiedEmpId = null;
                    eyeMDDbContext.SaveChanges();
                    return;
                }



                var newVisitAllergy = new Brady_s_Conversion_Program.ModelsB.EmrvisitAllergy {
                    AllergyName = allergy.AllergyName,
                    VisitId = visitId,
                    PtId = ptId,
                    Dosdate = dosDate,
                    Severity = allergy.Severity,
                    Reaction = allergy.Reaction,
                    Inactive = inactive,
                    StartDate = allergy.StartDate,
                    Created = created,
                    CreatedEmpId = empId,
                    Snomedtype = null,
                    AllergyConceptId = null,
                    AllergyMappingId = null,
                    InsertGuid = null,
                    LastModified = null,
                    Rxcui = null,
                    Snomed = null,
                    LastModifiedEmpId = null
                };
                eyeMDDbContext.EmrvisitAllergies.Add(newVisitAllergy);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the allergy with ID: {allergy.Id}. Error: {e.Message}");
            }
        }

        public static void VisitsConvert(ModelsC.Visit visit, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                var eyeMDPatient = eyeMDDbContext.Emrpatients.Find(visit.PtId);

                short tabPOHPMH = -1;
                // no tabPOHPMH
                short tabROS = -1;
                // no tabROS
                short tabCCHPI = -1;
                // no tabCCHPI
                short Workup = -1;
                // no Workup
                short tabWorkup2 = -1;
                // no tabWorkup2
                short tabMBalance = -1;
                // no tabMBalance
                short tabGonio = -1;
                // no tabGonio
                short tabSLE = -1;
                // no tabSLE
                short tabDFE = -1;
                // no tabDFE
                short tabLensRx = -1;
                // no tabLensRx
                short tabDiag = -1;
                // no tabDiag
                short tabPlan = -1;
                // no tabPlan
                short tabCoding = -1;
                // no tabCoding
                short MDSignedOff = -1;
                if (short.TryParse(visit.MdsignedOff, out short temp)) {
                    MDSignedOff = temp;
                }

                int? ptid = null;
                if (visit.PtId != null) {
                    if (int.TryParse(visit.PtId, out int locum)) {
                        ptid = locum;
                    }
                }
                int? ClientSoftwareApptId = null;
                if (visit.ClientSoftwareApptId != null) {
                    if (int.TryParse(visit.ClientSoftwareApptId, out int locum)) {
                        ClientSoftwareApptId = locum;
                    }
                }
                int? clientSoftwarePtId = null;
                if (eyeMDPatient != null && eyeMDPatient.ClientSoftwarePtId != null) {
                    if (int.TryParse(eyeMDPatient.ClientSoftwarePtId, out int locum)) {
                        clientSoftwarePtId = locum;
                    }
                }
                int? locationId = null;
                // no location id
                int? providerEmpId = null;
                if (visit.InitialSignedOffEmpId != null) {
                    if (int.TryParse(visit.InitialSignedOffEmpId, out int locum)) {
                        providerEmpId = locum;
                    }
                }
                int? examTypeId = null;
                // no exam type id
                DateTime? dosDate = null;
                if (visit.Dosdate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(visit.Dosdate, dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosDate = tempDateTime;
                    }
                }
                int? visitTech = null;
                if (visit.VisitTech != null) {
                    if (int.TryParse(visit.VisitTech, out int locum)) {
                        visitTech = locum;
                    }
                }
                int? visitDoctor = null;
                if (visit.VisitDoctor != null) {
                    if (int.TryParse(visit.VisitDoctor, out int locum)) {
                        visitDoctor = locum;
                    }
                }
                int? visitRefProviderId = null;
                if (visit.VisitRefProviderId != null) {
                    if (int.TryParse(visit.VisitRefProviderId, out int locum)) {
                        visitRefProviderId = locum;
                    }
                }
                int? visitPriCareProviderId = null;
                if (visit.VisitPriCareProviderId != null) {
                    if (int.TryParse(visit.VisitPriCareProviderId, out int locum)) {
                        visitPriCareProviderId = locum;
                    }
                }
                string visitType = "";
                if (visit.VisitType != null) {
                    visitType = visit.VisitType;
                }
                int? visitTypeId = null;
                if (visit.VisitTypeId != null) {
                    if (int.TryParse(visit.VisitTypeId, out int locum)) {
                        visitTypeId = locum;
                    }
                }
                int? visitClassId = null;
                if (visit.VisitClassId != null) {
                    if (int.TryParse(visit.VisitClassId, out int locum)) {
                        visitClassId = locum;
                    }
                }
                int? linkedProcVisitId = null;
                if (visit.LinkedProcedureVisitId != null) {
                    if (int.TryParse(visit.LinkedProcedureVisitId, out int locum)) {
                        linkedProcVisitId = locum;
                    }
                }
                string locationSpecific = "";
                // not in incoming table
                DateTime? mdSignedOffDate = null;
                if (visit.MdsignedOffDate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(visit.MdsignedOffDate, dateFormats,
                                CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        mdSignedOffDate = tempDateTime;
                    }
                }
                int? mdSignedOffEmpId = null;
                if (visit.MdsignedOffEmpId != null) {
                    if (int.TryParse(visit.MdsignedOffEmpId, out int locum)) {
                        mdSignedOffEmpId = locum;
                    }
                }
                int? codeId = null;
                // no codeId
                int? procVisitTypeId = null;
                // no procVisitTypeId
                short? tabVitals = null;
                // no tabVitals
                int? visitEyeCareProvId = null;
                if (visit.VisitEyeCareProviderId != null) {
                    if (int.TryParse(visit.VisitEyeCareProviderId, out int locum)) {
                        visitEyeCareProvId = locum;
                    }
                }
                short? techIsDirty = null;
                // no techIsDirty
                string techDirtyInfo = "";
                // no techDirtyInfo
                short? techWU2IsDirty = null;
                // no techWU2IsDirty
                string techWU2DirtyInfo = "";
                // no techWU2DirtyInfo
                short? techROSIsDirty = null;
                // no techROSIsDirty
                string techROSDirtyInfo = "";
                // no techROSDirtyInfo
                short? diagTestIsDirty = null;
                // no diagTestIsDirty
                string diagTestDirtyInfo = "";
                // no diagTestDirtyInfo
                short? doctorIsDirty = null;
                // no doctorIsDirty
                string doctorDirtyInfo = "";
                // no doctorDirtyInfo
                short? providedPtEducation = null;
                if (visit.ProvidedPtEducation != null) {
                    if (short.TryParse(visit.ProvidedPtEducation, out short locum)) {
                        providedPtEducation = locum;
                    }
                }
                short? tabImmunizations = null;
                // no tabImmunizations
                string insertGUID = Guid.NewGuid().ToString();
                // no insertGUID
                short? procIsDirty = null;
                // no procIsDirty
                string procDirtyInfo = "";
                // no procDirtyInfo
                short? excludedVisit = null;
                if (visit.ExcludeVisit != null) {
                    if (short.TryParse(visit.ExcludeVisit, out short locum)) {
                        excludedVisit = locum;
                    }
                }
                string clrefNoteRemember = "";
                if (visit.ClrefNoteRemember != null) {
                    clrefNoteRemember = visit.ClrefNoteRemember;
                }
                int? serviceType = null;
                if (visit.ServiceType != null) {
                    if (int.TryParse(visit.ServiceType, out int locum)) {
                        serviceType = locum;
                    }
                }
                string initialSignedOffRole = "";
                if (visit.InitialSignedOffRole != null) {
                    initialSignedOffRole = visit.InitialSignedOffRole;
                }
                short? initialSignedOff = null;
                if (visit.InitialSignedOff != null) {
                    if (short.TryParse(visit.InitialSignedOff, out short locum)) {
                        initialSignedOff = locum;
                    }
                }
                DateTime? initialSignedOffDate = null;
                if (visit.InitialSignedOffDate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(visit.InitialSignedOffDate, dateFormats,
                                                    CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        initialSignedOffDate = tempDateTime;
                    }
                }
                int? initialSignedOffEmpId = null;
                if (visit.InitialSignedOffEmpId != null) {
                    if (int.TryParse(visit.InitialSignedOffEmpId, out int locum)) {
                        initialSignedOffEmpId = locum;
                    }
                }
                short? tabExam = null;
                // no tabExam
                short? tabDrawing = null;
                // no tabDrawing
                bool reconciledCCDA = false;
                if (visit.ReconciledCcda != null && visit.ReconciledCcda.ToLower() == "yes") {
                    reconciledCCDA = true;
                }

                // one patient can have multiple visits, so I wont check this one
                



                var newVisit = new Brady_s_Conversion_Program.ModelsB.Emrvisit {
                    // non nullable fields
                    TabPohpmh = tabPOHPMH,
                    TabRos = tabROS,
                    TabCchpi = tabCCHPI,
                    TabWorkup = Workup,
                    TabWorkUp2 = tabWorkup2,
                    TabMbalance = tabMBalance,
                    TabGonio = tabGonio,
                    TabSle = tabSLE,
                    TabDfe = tabDFE,
                    TabLensRx = tabLensRx,
                    TabDiag = tabDiag,
                    TabPlan = tabPlan,
                    TabCoding = tabCoding,
                    MdsignedOff = MDSignedOff,


                    // nullable fields
                    PtId = ptid,
                    ClientSoftwareApptId = ClientSoftwareApptId,
                    ClientSoftwarePtId = clientSoftwarePtId,
                    LocationId = locationId,
                    ProviderEmpId = providerEmpId,
                    ExamType = examTypeId,
                    Dosdate = dosDate,
                    VisitTech = visitTech,
                    VisitDoctor = visitDoctor,
                    VisitRefProviderId = visitRefProviderId,
                    VisitPriCareProviderId = visitPriCareProviderId,
                    VisitType = visitType,
                    VisitTypeId = visitTypeId,
                    VisitClassId = visitClassId,
                    LinkedProcedureVisitId = linkedProcVisitId,
                    LocationSpecific = locationSpecific,
                    MdsignedOffDate = mdSignedOffDate,
                    MdsignedOffEmpId = mdSignedOffEmpId,
                    CodeId = codeId,
                    ProcVisitTypeId = procVisitTypeId,
                    TabVitals = tabVitals,
                    VisitEyeCareProviderId = visitEyeCareProvId,
                    TechIsDirty = techIsDirty,
                    TechDirtyInfo = techDirtyInfo,
                    TechWu2isDirty = techWU2IsDirty,
                    TechWu2dirtyInfo = techWU2DirtyInfo,
                    TechRosisDirty = techROSIsDirty,
                    TechRosdirtyInfo = techROSDirtyInfo,
                    DiagTestIsDirty = diagTestIsDirty,
                    DiagTestDirtyInfo = diagTestDirtyInfo,
                    DoctorIsDirty = doctorIsDirty,
                    DoctorDirtyInfo = doctorDirtyInfo,
                    ReconciledCcda = reconciledCCDA,
                    ProvidedPtEducation = providedPtEducation,
                    TabImmunizations = tabImmunizations,
                    InsertGuid = insertGUID,
                    ProcIsDirty = procIsDirty,
                    ProcDirtyInfo = procDirtyInfo,
                    ExcludeVisit = excludedVisit,
                    ClrefNoteRemember = clrefNoteRemember,
                    ServiceType = serviceType,
                    InitialSignedOffRole = initialSignedOffRole,
                    InitialSignedOff = initialSignedOff,
                    InitialSignedOffDate = initialSignedOffDate,
                    InitialSignedOffEmpId = initialSignedOffEmpId,
                    TabExam = tabExam,
                    TabDrawing = tabDrawing,
                    Wu2visitTypeId = null
                };
                eyeMDDbContext.Emrvisits.Add(newVisit);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the visit with ID: {visit.Id}. Error: {e.Message}");
            }
        }

        public static void VisitOrdersConvert(ModelsC.VisitOrder visitOrder, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? visitId = null;
                if (visitOrder.VisitId != null) {
                    if (int.TryParse(visitOrder.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                int? ptId = null;
                if (visitOrder.PtId != null) {
                    if (int.TryParse(visitOrder.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                if (ptId == null && visitId == null) {
                    logger.Log($"EHR: EHR Visit ID and Patient ID not found for visit order with ID: {visitOrder.Id}");
                }
                else if (ptId == null) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null) {
                        ptId = eyeMDVisit.PtId;
                    }
                    else {
                        logger.Log($"EHR: EHR Visit not found for visit order with ID: {visitOrder.Id}");
                    }
                }
                else if (visitId == null) {
                    logger.Log($"EHR: EHR VisitID not found for visit order with ID: {visitOrder.Id}");
                }

                DateTime? dosdate = null;
                if (visitOrder.Dosdate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(visitOrder.Dosdate, dateFormats,
                                                  CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosdate = tempDateTime;
                    }
                }
                string description = "";
                if (visitOrder.OrderDescription != null) {
                    description = visitOrder.OrderDescription;
                }
                string orderWhen = "";
                if (visitOrder.OrderWhen != null) {
                    orderWhen = visitOrder.OrderWhen;
                }
                string orderScheduledDate = "";
                if (visitOrder.OrderScheduledDate != null) {
                    orderScheduledDate = visitOrder.OrderScheduledDate;
                }
                short doNotPrintRx = -1;
                if (short.TryParse(visitOrder.DoNotPrintRx, out short temp)) {
                    doNotPrintRx = temp;
                }
                int? addedbyFastPlanId = null;
                if (visitOrder.AddedbyFastPlanId != null) {
                    if (int.TryParse(visitOrder.AddedbyFastPlanId, out int locum)) {
                        addedbyFastPlanId = locum;
                    }
                }
                int? orderTypeId = null;
                if (visitOrder.OrderTypeId != null) {
                    if (int.TryParse(visitOrder.OrderTypeId, out int locum)) {
                        orderTypeId = locum;
                    }
                }
                short? orderHasSpecimen = null;
                if (short.TryParse(visitOrder.OrderHasSpecimen, out temp)) {
                    orderHasSpecimen = temp;
                }
                string orderSpecimenType = "";
                if (visitOrder.OrderSpecimenType != null) {
                    orderSpecimenType = visitOrder.OrderSpecimenType;
                }
                string orderSpecimenId = "";
                if (visitOrder.OrderSpecimenId != null) {
                    orderSpecimenId = visitOrder.OrderSpecimenId;
                }
                DateTime? orderLabResultFulfilledDate = null;
                if (visitOrder.OrderLabResultFulfilledDate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(visitOrder.OrderLabResultFulfilledDate, dateFormats,
                                                                         CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        orderLabResultFulfilledDate = tempDateTime;
                    }
                }
                int? orderLabResultId = null;
                if (visitOrder.OrderLabResultId != null) {
                    if (int.TryParse(visitOrder.OrderLabResultId, out int locum)) {
                        orderLabResultId = locum;
                    }
                }
                short? orderNeedsFollowUp = null;
                if (short.TryParse(visitOrder.OrderNeedsFollowup, out temp)) {
                    orderNeedsFollowUp = temp;
                }
                short? orderWasFollowedUp = null;
                if (short.TryParse(visitOrder.OrderWasFollowedup, out temp)) {
                    orderWasFollowedUp = temp;
                }
                string orderNotes = "";
                if (visitOrder.OrderNotes != null) {
                    orderNotes = visitOrder.OrderNotes;
                }
                short? summarySent = null;
                if (short.TryParse(visitOrder.SummarySent, out temp)) {
                    summarySent = temp;
                }
                string orderRemarks = "";
                if (visitOrder.OrderRemarks != null) {
                    orderRemarks = visitOrder.OrderRemarks;
                }
                string insertGUID = Guid.NewGuid().ToString(); // This looks like it is supposed to be some large string. I don't see where it is coming from
                
                string studyInstanceUID = "";
                if (visitOrder.StudyInstanceUid != null) {
                    studyInstanceUID = visitOrder.StudyInstanceUid;
                }
                string dicomRequestedProc = "";
                if (visitOrder.DicomrequestedProcedureId != null) {
                    dicomRequestedProc = visitOrder.DicomrequestedProcedureId;
                }
                string dicomScheduledProcStepId = "";
                if (visitOrder.DicomscheduledProcedureStepId != null) {
                    dicomScheduledProcStepId = visitOrder.DicomscheduledProcedureStepId;
                }
                int? orderModality = null;
                if (visitOrder.OrderModalityId != null) {
                    if (int.TryParse(visitOrder.OrderModalityId, out int locum)) {
                        orderModality = locum;
                    }
                }
                string scheduledAE = "";
                if (visitOrder.ScheduledAe != null) {
                    scheduledAE = visitOrder.ScheduledAe;
                }
                string CodeCPT = "";
                if (visitOrder.CodeCpt != null) {
                    CodeCPT = visitOrder.CodeCpt;
                }
                string CodeSNOMED = "";
                if (visitOrder.CodeSnomed != null) {
                    CodeSNOMED = visitOrder.CodeSnomed;
                }
                int? recordedEmpRole = null;
                if (visitOrder.RecordedEmpRole != null) {
                    if (int.TryParse(visitOrder.RecordedEmpRole, out int locum)) {
                        recordedEmpRole = locum;
                    }
                }
                short? summaryTransmitted = null;
                if (short.TryParse(visitOrder.SummaryTransmitted, out temp)) {
                    summaryTransmitted = temp;
                }
                string codeLOINC = "";
                if (visitOrder.CodeLoinc != null) {
                    codeLOINC = visitOrder.CodeLoinc;
                }
                string RefProvFirst = "";
                if (visitOrder.RefProviderFirstName != null) {
                    RefProvFirst = visitOrder.RefProviderFirstName;
                }
                string RefProvLast = "";
                if (visitOrder.RefProviderLastName != null) {
                    RefProvLast = visitOrder.RefProviderLastName;
                }
                string refProvId = "";
                if (visitOrder.RefProviderId != null) {
                    refProvId = visitOrder.RefProviderId;
                }
                string refProvOrgName = "";
                if (visitOrder.RefProviderOrganizationName != null) {
                    refProvOrgName = visitOrder.RefProviderOrganizationName;
                }

                var ehrOrig = eyeMDDbContext.EmrvisitOrders.FirstOrDefault(x => x.PtId == ptId);
                var ehrOrigVisit = eyeMDDbContext.EmrvisitOrders.FirstOrDefault(x => x.VisitId == visitId);

                if (ehrOrig != null && ehrOrigVisit != null && ehrOrig == ehrOrigVisit) {
                    ehrOrig.VisitId = visitId;
                    ehrOrig.PtId = ptId;
                    ehrOrig.Dosdate = dosdate;
                    ehrOrig.OrderDescription = description;
                    ehrOrig.OrderWhen = orderWhen;
                    ehrOrig.OrderScheduledDate = orderScheduledDate;
                    ehrOrig.DoNotPrintRx = doNotPrintRx;
                    ehrOrig.AddedbyFastPlanId = addedbyFastPlanId;
                    ehrOrig.OrderTypeId = orderTypeId;
                    ehrOrig.OrderHasSpecimen = orderHasSpecimen;
                    ehrOrig.OrderSpecimenType = orderSpecimenType;
                    ehrOrig.OrderSpecimenId = orderSpecimenId;
                    ehrOrig.OrderLabResultFulfilledDate = orderLabResultFulfilledDate;
                    ehrOrig.OrderLabResultId = orderLabResultId;
                    ehrOrig.OrderNeedsFollowup = orderNeedsFollowUp;
                    ehrOrig.OrderWasFollowedup = orderWasFollowedUp;
                    ehrOrig.OrderNotes = orderNotes;
                    ehrOrig.SummarySent = summarySent;
                    ehrOrig.OrderRemarks = orderRemarks;
                    ehrOrig.InsertGuid = insertGUID;
                    ehrOrig.StudyInstanceUid = studyInstanceUID;
                    ehrOrig.DicomrequestedProcedureId = dicomRequestedProc;
                    ehrOrig.DicomscheduledProcedureStepId = dicomScheduledProcStepId;
                    ehrOrig.OrderModalityId = orderModality;
                    ehrOrig.ScheduledAe = scheduledAE;
                    ehrOrig.CodeCpt = CodeCPT;
                    ehrOrig.CodeSnomed = CodeSNOMED;
                    ehrOrig.RecordedEmpRole = recordedEmpRole;
                    ehrOrig.SummaryTransmitted = summaryTransmitted;
                    ehrOrig.CodeLoinc = codeLOINC;
                    ehrOrig.RefProviderFirstName = RefProvFirst;
                    ehrOrig.RefProviderLastName = RefProvLast;
                    ehrOrig.RefProviderId = refProvId;
                    ehrOrig.RefProviderOrganizationName = refProvOrgName;
                    eyeMDDbContext.SaveChanges();
                    return;
                }



                var newVisitOrder = new Brady_s_Conversion_Program.ModelsB.EmrvisitOrder {
                    VisitId = visitId,
                    PtId = ptId,
                    Dosdate = dosdate,
                    OrderDescription = description,
                    OrderWhen = orderWhen,
                    OrderScheduledDate = orderScheduledDate,
                    DoNotPrintRx = doNotPrintRx,
                    AddedbyFastPlanId = addedbyFastPlanId,
                    OrderTypeId = orderTypeId,
                    OrderHasSpecimen = orderHasSpecimen,
                    OrderSpecimenType = orderSpecimenType,
                    OrderSpecimenId = orderSpecimenId,
                    OrderLabResultFulfilledDate = orderLabResultFulfilledDate,
                    OrderLabResultId = orderLabResultId,
                    OrderNeedsFollowup = orderNeedsFollowUp,
                    OrderWasFollowedup = orderWasFollowedUp,
                    OrderNotes = orderNotes,
                    SummarySent = summarySent,
                    OrderRemarks = orderRemarks,
                    InsertGuid = insertGUID,
                    StudyInstanceUid = studyInstanceUID,
                    DicomrequestedProcedureId = dicomRequestedProc,
                    DicomscheduledProcedureStepId = dicomScheduledProcStepId,
                    OrderModalityId = orderModality,
                    ScheduledAe = scheduledAE,
                    CodeCpt = CodeCPT,
                    CodeSnomed = CodeSNOMED,
                    RecordedEmpRole = recordedEmpRole,
                    SummaryTransmitted = summaryTransmitted,
                    CodeLoinc = codeLOINC,
                    RefProviderFirstName = RefProvFirst,
                    RefProviderLastName = RefProvLast,
                    RefProviderId = refProvId,
                    RefProviderOrganizationName = refProvOrgName
                };
                eyeMDDbContext.EmrvisitOrders.Add(newVisitOrder);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the visit order with ID: {visitOrder.Id}. Error: {e.Message}");
            }
        }

        public static void VisitDoctorsConvert(ModelsC.VisitDoctor visitDoctor, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? visitId = null;
                if (visitDoctor.VisitId != null) {
                    if (int.TryParse(visitDoctor.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                int? ptId = null;
                if (visitDoctor.PtId != null) {
                    if (int.TryParse(visitDoctor.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                if (ptId == null && visitId == null) {
                    logger.Log($"EHR: EHR Visit ID and Patient ID not found for visit order with ID: {visitDoctor.Id}");
                }
                else if (ptId == null) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null) {
                        ptId = eyeMDVisit.PtId;
                    }
                    else {
                        logger.Log($"EHR: EHR Visit not found for visit order with ID: {visitDoctor.Id}");
                    }
                }
                else if (visitId == null) {
                    logger.Log($"EHR: EHR VisitID not found for visit order with ID: {visitDoctor.Id}");
                }

                DateTime? dosdate = null;
                if (visitDoctor.Dosdate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(visitDoctor.Dosdate, dateFormats,
                                                                         CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosdate = tempDateTime;
                    }
                }
                string sleDiagOd = "";
                if (visitDoctor.SleDiagOd != null) {
                    sleDiagOd = visitDoctor.SleDiagOd;
                }
                string sleDiagOs = "";
                if (visitDoctor.SleDiagOs != null) {
                    sleDiagOs = visitDoctor.SleDiagOs;
                }
                string sleComments = "";
                if (visitDoctor.Slecomments != null) {
                    sleComments = visitDoctor.Slecomments;
                }
                string dfeCdRatioVertOd = "";
                if (visitDoctor.DfeCdratioVertOd != null) {
                    dfeCdRatioVertOd = visitDoctor.DfeCdratioVertOd;
                }
                string dfeCdRatioVertOs = "";
                if (visitDoctor.DfeCdratioVertOs != null) {
                    dfeCdRatioVertOs = visitDoctor.DfeCdratioVertOs;
                }
                string dfeCdRatioHorizOd = "";
                if (visitDoctor.DfeCdratioHorizOd != null) {
                    dfeCdRatioHorizOd = visitDoctor.DfeCdratioHorizOd;
                }
                string dfeCdRatioHorizOs = "";
                if (visitDoctor.DfeCdratioHorizOs != null) {
                    dfeCdRatioHorizOs = visitDoctor.DfeCdratioHorizOs;
                }
                string dfeDiagOd = "";
                if (visitDoctor.DfeDiagOd != null) {
                    dfeDiagOd = visitDoctor.DfeDiagOd;
                }
                string dfeDIagOs = "";
                if (visitDoctor.DfeDiagOs != null) {
                    dfeDIagOs = visitDoctor.DfeDiagOs;
                }
                string dfeComments = "";
                if (visitDoctor.Dfecomments != null) {
                    dfeComments = visitDoctor.Dfecomments;
                }
                string diagOtherDiagnoses = "";
                if (visitDoctor.DiagOtherDiagnoses != null) {
                    diagOtherDiagnoses = visitDoctor.DiagOtherDiagnoses;
                }
                string planStaffOrderComments = "";
                if (visitDoctor.PlanStaffOrderComments != null) {
                    planStaffOrderComments = visitDoctor.PlanStaffOrderComments;
                }
                string planRTOWhen = "";
                if (visitDoctor.PlanRtowhen != null) {
                    planRTOWhen = visitDoctor.PlanRtowhen;
                }
                string PlanRTOReason = "";
                if (visitDoctor.PlanRtoreason != null) {
                    PlanRTOReason = visitDoctor.PlanRtoreason;
                }
                short planDictateReferingDoc = -1;
                if (short.TryParse(visitDoctor.PlanDictateReferingDoc, out short temp)) {
                    planDictateReferingDoc = temp;
                }
                short planDictatePriCareDoc = -1;
                if (short.TryParse(visitDoctor.PlanDictatePriCareDoc, out temp)) {
                    planDictatePriCareDoc = temp;
                }
                short planDictatePatient = -1;
                if (short.TryParse(visitDoctor.PlanDictatePatient, out temp)) {
                    planDictatePatient = temp;
                }
                string planNextScheduledAppt = "";
                if (visitDoctor.PlanNextScheduledAppt != null) {
                    planNextScheduledAppt = visitDoctor.PlanNextScheduledAppt;
                }
                int? codingMDM = null;
                if (visitDoctor.CodingMdm != null) {
                    if (int.TryParse(visitDoctor.CodingMdm, out int locum)) {
                        codingMDM = locum;
                    }
                }
                string codingAdditionalProcs = "";
                if (visitDoctor.CodingAdditionalProcedures != null) {
                    codingAdditionalProcs = visitDoctor.CodingAdditionalProcedures;
                }
                string planRxMedRemarks = "";
                if (visitDoctor.PlanRxMedRemarks != null) {
                    planRxMedRemarks = visitDoctor.PlanRxMedRemarks;
                }
                string planRxOrdersRemarks = "";
                if (visitDoctor.PlanRxOrdersRemarks != null) {
                    planRxOrdersRemarks = visitDoctor.PlanRxOrdersRemarks;
                }
                short? codingChargesSent = null;
                // no codingChargesSent
                short? dfeExtOpth = null;
                if (visitDoctor.DfeextOpth != null) {
                    if (short.TryParse(visitDoctor.DfeextOpth, out short locum)) {
                        dfeExtOpth = locum;
                    }
                }
                string dfeLensUsed = "";
                if (visitDoctor.DfelensUsed != null) {
                    dfeLensUsed = visitDoctor.DfelensUsed;
                }
                string planTargetIOPOd = "";
                if (visitDoctor.PlanTargetIopOd != null) {
                    planTargetIOPOd = visitDoctor.PlanTargetIopOd;
                }
                string planTargetIOPOs = "";
                if (visitDoctor.PlanTargetIopOs != null) {
                    planTargetIOPOs = visitDoctor.PlanTargetIopOs;
                }
                string dfeDilatedPupilSizeOd = "";
                if (visitDoctor.DfedilatedPupilSizeOd != null) {
                    dfeDilatedPupilSizeOd = visitDoctor.DfedilatedPupilSizeOd;
                }
                string dfeDilatedPupilSizeOs = "";
                if (visitDoctor.DfedilatedPupilSizeOs != null) {
                    dfeDilatedPupilSizeOs = visitDoctor.DfedilatedPupilSizeOs;
                }
                short? planDictateEyeCareDoc = null;
                if (visitDoctor.PlanDictateEyeCareDoc != null) {
                    if (short.TryParse(visitDoctor.PlanDictateEyeCareDoc, out short locum)) {
                        planDictateEyeCareDoc = locum;
                    }
                }
                short? sentToWebPortal = null;
                // no sentToWebPortal
                int? sentToWebPortalDays = null;
                // no sentToWebPortalDays
                string planLensRxNotes = "";
                if (visitDoctor.PlanLensRxNotes != null) {
                    planLensRxNotes = visitDoctor.PlanLensRxNotes;
                }
                short? providedClinicalSummary = null;
                if (visitDoctor.ProvidedClinicalSummary != null) {
                    if (short.TryParse(visitDoctor.ProvidedClinicalSummary, out short locum)) {
                        providedClinicalSummary = locum;
                    }
                }
                int? providedClinicalSummaryDays = null;
                if (visitDoctor.ProvidedClinicalSummaryDays != null) {
                    if (int.TryParse(visitDoctor.ProvidedClinicalSummaryDays, out int locum)) {
                        providedClinicalSummaryDays = locum;
                    }
                }
                short? codingQRAutoCheckStatus = null;
                // no codingQRAutoCheckStatus
                short? sleAbutehl = null;
                if (visitDoctor.SleAbutehl != null) {
                    if (short.TryParse(visitDoctor.SleAbutehl, out short locum)) {
                        sleAbutehl = locum;
                    }
                }
                int? scribeEmpId = null;
                if (visitDoctor.ScribeEmpId != null) {
                    if (int.TryParse(visitDoctor.ScribeEmpId, out int locum)) {
                        scribeEmpId = locum;
                    }
                }
                int? codingC3EMLevel = null;
                if (visitDoctor.CodingC3emlevel != null) {
                    if (int.TryParse(visitDoctor.CodingC3emlevel, out int locum)) {
                        codingC3EMLevel = locum;
                    }
                }
                int? codingC3EyeCareLevel = null;
                if (visitDoctor.CodingC3eyeCareLevel != null) {
                    if (int.TryParse(visitDoctor.CodingC3eyeCareLevel, out int locum)) {
                        codingC3EyeCareLevel = locum;
                    }
                }
                string pdDistOu = "";
                if (visitDoctor.PdDistOu != null) {
                    pdDistOu = visitDoctor.PdDistOu;
                }
                string pdNearOu = "";
                if (visitDoctor.PdNearOu != null) {
                    pdNearOu = visitDoctor.PdNearOu;
                }

                var ehrOrig = eyeMDDbContext.EmrvisitDoctors.FirstOrDefault(x => x.PtId == ptId);
                var ehrOrigVisit = eyeMDDbContext.EmrvisitDoctors.FirstOrDefault(x => x.VisitId == visitId);

                if (ehrOrig != null && ehrOrigVisit != null && ehrOrig == ehrOrigVisit) {
                    ehrOrig.VisitId = visitId;
                    ehrOrig.PtId = ptId;
                    ehrOrig.Dosdate = dosdate;
                    ehrOrig.SleDiagOd = sleDiagOd;
                    ehrOrig.SleDiagOs = sleDiagOs;
                    ehrOrig.Slecomments = sleComments;
                    ehrOrig.DfeCdratioVertOd = dfeCdRatioVertOd;
                    ehrOrig.DfeCdratioVertOs = dfeCdRatioVertOs;
                    ehrOrig.DfeCdratioHorizOd = dfeCdRatioHorizOd;
                    ehrOrig.DfeCdratioHorizOs = dfeCdRatioHorizOs;
                    ehrOrig.DfeDiagOd = dfeDiagOd;
                    ehrOrig.DfeDiagOs = dfeDIagOs;
                    ehrOrig.Dfecomments = dfeComments;
                    ehrOrig.DiagOtherDiagnoses = diagOtherDiagnoses;
                    ehrOrig.PlanStaffOrderComments = planStaffOrderComments;
                    ehrOrig.PlanRtowhen = planRTOWhen;
                    ehrOrig.PlanRtoreason = PlanRTOReason;
                    ehrOrig.PlanDictateReferingDoc = planDictateReferingDoc;
                    ehrOrig.PlanDictatePriCareDoc = planDictatePriCareDoc;
                    ehrOrig.PlanDictatePatient = planDictatePatient;
                    ehrOrig.PlanNextScheduledAppt = planNextScheduledAppt;
                    ehrOrig.CodingMdm = codingMDM;
                    ehrOrig.CodingAdditionalProcedures = codingAdditionalProcs;
                    ehrOrig.PlanRxMedRemarks = planRxMedRemarks;
                    ehrOrig.PlanRxOrdersRemarks = planRxOrdersRemarks;
                    ehrOrig.DfeextOpth = dfeExtOpth;
                    ehrOrig.DfelensUsed = dfeLensUsed;
                    ehrOrig.PlanTargetIopOd = planTargetIOPOd;
                    ehrOrig.PlanTargetIopOs = planTargetIOPOs;
                    ehrOrig.DfedilatedPupilSizeOd = dfeDilatedPupilSizeOd;
                    ehrOrig.DfedilatedPupilSizeOs = dfeDilatedPupilSizeOs;
                    ehrOrig.PlanDictateEyeCareDoc = planDictateEyeCareDoc;
                    ehrOrig.SleAbutehl = sleAbutehl;
                    ehrOrig.ScribeEmpId = scribeEmpId;
                    eyeMDDbContext.SaveChanges();
                    return;
                }



                var newVisitDoctor = new Brady_s_Conversion_Program.ModelsB.EmrvisitDoctor {
                    VisitId = visitId,
                    PtId = ptId,
                    UpsizeTs = null,
                    Dosdate = dosdate,
                    SleDiagOd = sleDiagOd,
                    SleDiagOs = sleDiagOs,
                    Slecomments = sleComments,
                    DfeCdratioVertOd = dfeCdRatioVertOd,
                    DfeCdratioVertOs = dfeCdRatioVertOs,
                    DfeCdratioHorizOd = dfeCdRatioHorizOd,
                    DfeCdratioHorizOs = dfeCdRatioHorizOs,
                    DfeDiagOd = dfeDiagOd,
                    DfeDiagOs = dfeDIagOs,
                    Dfecomments = dfeComments,
                    DiagOtherDiagnoses = diagOtherDiagnoses,
                    PlanStaffOrderComments = planStaffOrderComments,
                    PlanRtowhen = planRTOWhen,
                    PlanRtoreason = PlanRTOReason,
                    PlanDictateReferingDoc = planDictateReferingDoc,
                    PlanDictatePriCareDoc = planDictatePriCareDoc,
                    PlanDictatePatient = planDictatePatient,
                    PlanNextScheduledAppt = planNextScheduledAppt,
                    CodingMdm = codingMDM,
                    CodingAdditionalProcedures = codingAdditionalProcs,
                    PlanRxMedRemarks = planRxMedRemarks,
                    PlanRxOrdersRemarks = planRxOrdersRemarks,
                    DfeextOpth = dfeExtOpth,
                    DfelensUsed = dfeLensUsed,
                    PlanTargetIopOd = planTargetIOPOd,
                    PlanTargetIopOs = planTargetIOPOs,
                    DfedilatedPupilSizeOd = dfeDilatedPupilSizeOd,
                    DfedilatedPupilSizeOs = dfeDilatedPupilSizeOs,
                    PlanDictateEyeCareDoc = planDictateEyeCareDoc,
                    SleAbutehl = sleAbutehl,
                    ScribeEmpId = scribeEmpId,
                    CodingC3emlevel = codingC3EMLevel,
                    CodingC3eyeCareLevel = codingC3EyeCareLevel,
                    PdDistOu = pdDistOu,
                    PdNearOu = pdNearOu,
                    CodingChargesSent = codingChargesSent,
                    CodingQrautoCheckStatus = codingQRAutoCheckStatus,
                    SentToWebPortal = sentToWebPortal,
                    SentToWebPortalDays = sentToWebPortalDays,
                    PlanLensRxNotes = planLensRxNotes,
                    ProvidedClinicalSummary = providedClinicalSummary,
                    ProvidedClinicalSummaryDays = providedClinicalSummaryDays
                };
                eyeMDDbContext.EmrvisitDoctors.Add(newVisitDoctor);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the visit doctor with ID: {visitDoctor.Id}. Error: {e.Message}");
            }
        }

        public static void AppointmentsConvert(ModelsC.Appointment appointment, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                // this table is only for the situation where we do eyemd and not ffpm
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the appointment with ID: {appointment.Id}. Error: {e.Message}");
            }
        }

        public static void ContactLensesConvert(ModelsC.ContactLen contactLens, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? visitId = null;
                if (contactLens.VisitId != null) {
                    if (int.TryParse(contactLens.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                int ptId = -1;
                if (contactLens.PtId != null) {
                    if (int.TryParse(contactLens.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                if (ptId == -1) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null && eyeMDVisit.PtId != null) {
                        ptId = (int)eyeMDVisit.PtId;
                    }
                    else {
                        logger.Log($"EHR: EHR PatientID not found for contact lens with ID: {contactLens.Id}");
                        return;
                    }
                }

                DateTime dosdate = DateTime.Parse("1/1/1900");
                if (contactLens.Dosdate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(contactLens.Dosdate, dateFormats,
                                                            CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosdate = tempDateTime;
                    }
                }
                int? rxId = null;
                if (contactLens.RxId != null) {
                    if (int.TryParse(contactLens.RxId, out int locum)) {
                        rxId = locum;
                    }
                }
                string contactClass = "";
                if (contactLens.ContactClass != null) {
                    contactClass = contactLens.ContactClass;
                }
                string lensType = "";
                if (contactLens.LensType != null) {
                    lensType = contactLens.LensType;
                }
                string powerOd = "";
                if (contactLens.PowerOd != null) {
                    powerOd = contactLens.PowerOd;
                }
                string powerOs = "";
                if (contactLens.PowerOs != null) {
                    powerOs = contactLens.PowerOs;
                }
                string cylinderOd = "";
                if (contactLens.CylinderOd != null) {
                    cylinderOd = contactLens.CylinderOd;
                }
                string cylinderOs = "";
                if (contactLens.CylinderOs != null) {
                    cylinderOs = contactLens.CylinderOs;
                }
                string axisOd = "";
                if (contactLens.AxisOd != null) {
                    axisOd = contactLens.AxisOd;
                }
                string axisOs = "";
                if (contactLens.AxisOs != null) {
                    axisOs = contactLens.AxisOs;
                }
                string bcOd = "";
                if (contactLens.BcOd != null) {
                    bcOd = contactLens.BcOd;
                }
                string bcOs = "";
                if (contactLens.BcOs != null) {
                    bcOs = contactLens.BcOs;
                }
                string addOd = "";
                if (contactLens.AddOd != null) {
                    addOd = contactLens.AddOd;
                }
                string addOs = "";
                if (contactLens.AddOs != null) {
                    addOs = contactLens.AddOs;
                }
                string colorOd = "";
                if (contactLens.ColorOd != null) {
                    colorOd = contactLens.ColorOd;
                }
                string colorOs = "";
                if (contactLens.ColorOs != null) {
                    colorOs = contactLens.ColorOs;
                }
                string pupilOd = "";
                if (contactLens.PupilOd != null) {
                    pupilOd = contactLens.PupilOd;
                }
                string pupilOs = "";
                if (contactLens.PupilOs != null) {
                    pupilOs = contactLens.PupilOs;
                }
                string vaDOd = "";
                if (contactLens.VaDOd != null) {
                    vaDOd = contactLens.VaDOd;
                }
                string vaDOs = "";
                if (contactLens.VaDOs != null) {
                    vaDOs = contactLens.VaDOs;
                }
                string vaDOu = "";
                if (contactLens.VaDOu != null) {
                    vaDOu = contactLens.VaDOu;
                }
                string VaNOd = "";
                if (contactLens.VaNOd != null) {
                    VaNOd = contactLens.VaNOd;
                }
                string VaNOs = "";
                if (contactLens.VaNOs != null) {
                    VaNOs = contactLens.VaNOs;
                }
                string VaNOu = "";
                if (contactLens.VaNOu != null) {
                    VaNOu = contactLens.VaNOu;
                }
                string vaIOd = "";
                if (contactLens.VaIOd != null) {
                    vaIOd = contactLens.VaIOd;
                }
                string vaIOs = "";
                if (contactLens.VaIOs != null) {
                    vaIOs = contactLens.VaIOs;
                }
                string vaIOu = "";
                if (contactLens.VaIOu != null) {
                    vaIOu = contactLens.VaIOu;
                }
                string comfortOd = "";
                if (contactLens.ComfortOd != null) {
                    comfortOd = contactLens.ComfortOd;
                }
                string comfortOs = "";
                if (contactLens.ComfortOs != null) {
                    comfortOs = contactLens.ComfortOs;
                }
                string centrationOd = "";
                if (contactLens.CentrationOd != null) {
                    centrationOd = contactLens.CentrationOd;
                }
                string centrationOs = "";
                if (contactLens.CentrationOs != null) {
                    centrationOs = contactLens.CentrationOs;
                }
                string coverageOd = "";
                if (contactLens.CoverageOd != null) {
                    coverageOd = contactLens.CoverageOd;
                }
                string coverageOs = "";
                if (contactLens.CoverageOs != null) {
                    coverageOs = contactLens.CoverageOs;
                }
                string movementOd = "";
                if (contactLens.MovementOd != null) {
                    movementOd = contactLens.MovementOd;
                }
                string movementOs = "";
                if (contactLens.MovementOs != null) {
                    movementOs = contactLens.MovementOs;
                }
                string diameterOd = "";
                if (contactLens.DiameterOd != null) {
                    diameterOd = contactLens.DiameterOd;
                }
                string diameterOs = "";
                if (contactLens.DiameterOs != null) {
                    diameterOs = contactLens.DiameterOs;
                }
                string rotationDegOd = "";
                if (contactLens.RotationDegOd != null) {
                    rotationDegOd = contactLens.RotationDegOd;
                }
                string rotationDegOs = "";
                if (contactLens.RotationDegOs != null) {
                    rotationDegOs = contactLens.RotationDegOs;
                }
                string kOd = "";
                if (contactLens.KOd != null) {
                    kOd = contactLens.KOd;
                }
                string kOs = "";
                if (contactLens.KOs != null) {
                    kOs = contactLens.KOs;
                }
                string edgeLiftOd = "";
                if (contactLens.EdgeLiftOd != null) {
                    edgeLiftOd = contactLens.EdgeLiftOd;
                }
                string edgeLiftOs = "";
                if (contactLens.EdgeLiftOs != null) {
                    edgeLiftOs = contactLens.EdgeLiftOs;
                }
                string distNearOd = "";
                if (contactLens.DistNearOd != null) {
                    distNearOd = contactLens.DistNearOd;
                }
                string distNearOs = "";
                if (contactLens.DistNearOs != null) {
                    distNearOs = contactLens.DistNearOs;
                }
                short? ptInsertedRemoved = null;
                if (short.TryParse(contactLens.PtInsertedRemoved, out short temp)) {
                    ptInsertedRemoved = temp;
                }
                string wAgeOd = "";
                if (contactLens.WAgeOd != null) {
                    wAgeOd = contactLens.WAgeOd;
                }
                string wAgeOs = "";
                if (contactLens.WAgeOs != null) {
                    wAgeOs = contactLens.WAgeOs;
                }
                string wTimeTodayOd = "";
                if (contactLens.WTimeTodayOd != null) {
                    wTimeTodayOd = contactLens.WTimeTodayOd;
                }
                string wTimeTodayOs = "";
                if (contactLens.WTimeTodayOs != null) {
                    wTimeTodayOs = contactLens.WTimeTodayOs;
                }
                string wAvgWearTimeOd = "";
                if (contactLens.WAvgWearTimeOd != null) {
                    wAvgWearTimeOd = contactLens.WAvgWearTimeOd;
                }
                string wAvgWearTimeOs = "";
                if (contactLens.WAvgWearTimeOs != null) {
                    wAvgWearTimeOs = contactLens.WAvgWearTimeOs;
                }
                string solution = "";
                if (contactLens.Solution != null) {
                    solution = contactLens.Solution;
                }
                string productOd = "";
                if (contactLens.ProductOd != null) {
                    productOd = contactLens.ProductOd;
                }
                string productOs = "";
                if (contactLens.ProductOs != null) {
                    productOs = contactLens.ProductOs;
                }
                string lensDesignOd = "";
                if (contactLens.LensDesignOd != null) {
                    lensDesignOd = contactLens.LensDesignOd;
                }
                string lensDesignOs = "";
                if (contactLens.LensDesignOs != null) {
                    lensDesignOs = contactLens.LensDesignOs;
                }
                string materialOd = "";
                if (contactLens.MaterialOd != null) {
                    materialOd = contactLens.MaterialOd;
                }
                string materialOs = "";
                if (contactLens.MaterialOs != null) {
                    materialOs = contactLens.MaterialOs;
                }
                string replacementSchedule = "";
                if (contactLens.ReplacementSchedule != null) {
                    replacementSchedule = contactLens.ReplacementSchedule;
                }
                string wearingInstructions = "";
                if (contactLens.WearingInstructions != null) {
                    wearingInstructions = contactLens.WearingInstructions;
                }
                string expires = "";
                if (contactLens.Expires != null) {
                    expires = contactLens.Expires;
                }
                int? rgpLayoutOd = null;
                if (contactLens.RgpLayoutOd != null) {
                    if (int.TryParse(contactLens.RgpLayoutOd, out int locum)) {
                        rgpLayoutOd = locum;
                    }
                }
                int? rgpLayoutOs = null;
                if (contactLens.RgpLayoutOs != null) {
                    if (int.TryParse(contactLens.RgpLayoutOs, out int locum)) {
                        rgpLayoutOs = locum;
                    }
                }
                string power2Od = "";
                if (contactLens.Power2Od != null) {
                    power2Od = contactLens.Power2Od;
                }
                string power2Os = "";
                if (contactLens.Power2Os != null) {
                    power2Os = contactLens.Power2Os;
                }
                string cylinder2Od = "";
                if (contactLens.Cylinder2Od != null) {
                    cylinder2Od = contactLens.Cylinder2Od;
                }
                string cylinder2Os = "";
                if (contactLens.Cylinder2Os != null) {
                    cylinder2Os = contactLens.Cylinder2Os;
                }
                string axis2Od = "";
                if (contactLens.Axis2Od != null) {
                    axis2Od = contactLens.Axis2Od;
                }
                string axis2Os = "";
                if (contactLens.Axis2Os != null) {
                    axis2Os = contactLens.Axis2Os;
                }
                string bc2Od = "";
                if (contactLens.Bc2Od != null) {
                    bc2Od = contactLens.Bc2Od;
                }
                string bc2Os = "";
                if (contactLens.Bc2Os != null) {
                    bc2Os = contactLens.Bc2Os;
                }
                string diameter2Od = "";
                if (contactLens.Diameter2Od != null) {
                    diameter2Od = contactLens.Diameter2Od;
                }
                string diameter2Os = "";
                if (contactLens.Diameter2Os != null) {
                    diameter2Os = contactLens.Diameter2Os;
                }
                string periphCurveOd = "";
                if (contactLens.PeriphCurveOd != null) {
                    periphCurveOd = contactLens.PeriphCurveOd;
                }
                string periphCurveOs = "";
                if (contactLens.PeriphCurveOs != null) {
                    periphCurveOs = contactLens.PeriphCurveOs;
                }
                string peripheralCurve2Od = "";
                if (contactLens.PeriphCurve2Od != null) {
                    peripheralCurve2Od = contactLens.PeriphCurve2Od;
                }
                string peripheralCurve2Os = "";
                if (contactLens.PeriphCurve2Os != null) {
                    peripheralCurve2Os = contactLens.PeriphCurve2Os;
                }
                string secondaryCurveOd = "";
                if (contactLens.SecondaryCurveOd != null) {
                    secondaryCurveOd = contactLens.SecondaryCurveOd;
                }
                string secondaryCurveOs = "";
                if (contactLens.SecondaryCurveOs != null) {
                    secondaryCurveOs = contactLens.SecondaryCurveOs;
                }
                string equivalentCurveOd = "";
                if (contactLens.EquivalentCurveOd != null) {
                    equivalentCurveOd = contactLens.EquivalentCurveOd;
                }
                string equivalentCurveOs = "";
                if (contactLens.EquivalentCurveOs != null) {
                    equivalentCurveOs = contactLens.EquivalentCurveOs;
                }
                string centerThicknessOd = "";
                if (contactLens.CenterThicknessOd != null) {
                    centerThicknessOd = contactLens.CenterThicknessOd;
                }
                string centerThicknessOs = "";
                if (contactLens.CenterThicknessOs != null) {
                    centerThicknessOs = contactLens.CenterThicknessOs;
                }
                string opticalZoneDiaOd = "";
                if (contactLens.OpticalZoneDiaOd != null) {
                    opticalZoneDiaOd = contactLens.OpticalZoneDiaOd;
                }
                string opticalZoneDiaOs = "";
                if (contactLens.OpticalZoneDiaOs != null) {
                    opticalZoneDiaOs = contactLens.OpticalZoneDiaOs;
                }
                string edgeOd = "";
                if (contactLens.EdgeOd != null) {
                    edgeOd = contactLens.EdgeOd;
                }
                string edgeOs = "";
                if (contactLens.EdgeOs != null) {
                    edgeOs = contactLens.EdgeOs;
                }
                string blendOd = "";
                if (contactLens.BlendOd != null) {
                    blendOd = contactLens.BlendOd;
                }
                string blendOs = "";
                if (contactLens.BlendOs != null) {
                    blendOs = contactLens.BlendOs;
                }
                string naFlPatternOd = "";
                if (contactLens.NaFlPatternOd != null) {
                    naFlPatternOd = contactLens.NaFlPatternOd;
                }
                string naFlPatternOs = "";
                if (contactLens.NaFlPatternOs != null) {
                    naFlPatternOs = contactLens.NaFlPatternOs;
                }
                string surfaceWettingOd = "";
                if (contactLens.SurfaceWettingOd != null) {
                    surfaceWettingOd = contactLens.SurfaceWettingOd;
                }
                string surfaceWettingOs = "";
                if (contactLens.SurfaceWettingOs != null) {
                    surfaceWettingOs = contactLens.SurfaceWettingOs;
                }
                string dkOd = "";
                if (contactLens.DkOd != null) {
                    dkOd = contactLens.DkOd;
                }
                string dkOs = "";
                if (contactLens.DkOs != null) {
                    dkOs = contactLens.DkOs;
                }
                string segHeightOd = "";
                if (contactLens.SegHeightOd != null) {
                    segHeightOd = contactLens.SegHeightOd;
                }
                string segHeightOs = "";
                if (contactLens.SegHeightOs != null) {
                    segHeightOs = contactLens.SegHeightOs;
                }
                string specialInstructionsOd = "";
                if (contactLens.SpecialInstructionsOd != null) {
                    specialInstructionsOd = contactLens.SpecialInstructionsOd;
                }
                string specialInstructionsOs = "";
                if (contactLens.SpecialInstructionsOs != null) {
                    specialInstructionsOs = contactLens.SpecialInstructionsOs;
                }
                string insertGUID = Guid.NewGuid().ToString();
                // no insertGUID, where does this always come from?
                int? treeviewTableIdOd = null;
                // no treeviewTableIdOd
                int? treeviewTableIdOs = null;
                // no treeviewTableIdOs
                string notes = "";
                if (contactLens.Notes != null) {
                    notes = contactLens.Notes;
                }
                string remarks = "";
                if (contactLens.Remarks != null) {
                    remarks = contactLens.Remarks;
                }
                bool printed = false;
                // no printed
                bool sentToOptical = false;
                // no sentToOptical
                string upcOd = "";
                if (contactLens.UpcOd != null) {
                    upcOd = contactLens.UpcOd;
                }
                string upcOs = "";
                if (contactLens.UpcOs != null) {
                    upcOs = contactLens.UpcOs;
                }
                int? catalogSource = null;
                if (contactLens.CatalogSource != null) {
                    if (int.TryParse(contactLens.CatalogSource, out int locum)) {
                        catalogSource = locum;
                    }
                }
                string catalogManufacturerIdOd = "";
                if (contactLens.CatalogManufacturerIdOd != null) {
                    catalogManufacturerIdOd = contactLens.CatalogManufacturerIdOd;
                }
                string catalogManufacturerIdOs = "";
                if (contactLens.CatalogManufacturerIdOs != null) {
                    catalogManufacturerIdOs = contactLens.CatalogManufacturerIdOs;
                }
                string catalogBrandIdOd = "";
                if (contactLens.CatalogBrandIdOd != null) {
                    catalogBrandIdOd = contactLens.CatalogBrandIdOd;
                }
                string catalogBrandIdOs = "";
                if (contactLens.CatalogBrandIdOs != null) {
                    catalogBrandIdOs = contactLens.CatalogBrandIdOs;
                }
                string catalogProductIdOd = "";
                if (contactLens.CatalogProductIdOd != null) {
                    catalogProductIdOd = contactLens.CatalogProductIdOd;
                }
                string catalogProductIdOs = "";
                if (contactLens.CatalogProductIdOs != null) {
                    catalogProductIdOs = contactLens.CatalogProductIdOs;
                }
                string trialNumber = "";
                if (contactLens.TrialNumber != null) {
                    trialNumber = contactLens.TrialNumber;
                }
                string orSphereOd = "";
                if (contactLens.OrSphereOd != null) {
                    orSphereOd = contactLens.OrSphereOd;
                }
                string orSphereOs = "";
                if (contactLens.OrSphereOs != null) {
                    orSphereOs = contactLens.OrSphereOs;
                }
                string orCylinderOd = "";
                if (contactLens.OrCylinderOd != null) {
                    orCylinderOd = contactLens.OrCylinderOd;
                }
                string orCylinderOs = "";
                if (contactLens.OrCylinderOs != null) {
                    orCylinderOs = contactLens.OrCylinderOs;
                }
                string orAxisOd = "";
                if (contactLens.OrAxisOd != null) {
                    orAxisOd = contactLens.OrAxisOd;
                }
                string orAxisOs = "";
                if (contactLens.OrAxisOs != null) {
                    orAxisOs = contactLens.OrAxisOs;
                }
                string orVaDOd = "";
                if (contactLens.OrVaDOd != null) {
                    orVaDOd = contactLens.OrVaDOd;
                }
                string orVaDOs = "";
                if (contactLens.OrVaDOs != null) {
                    orVaDOs = contactLens.OrVaDOs;
                }
                string orVaNOd = "";
                if (contactLens.OrVaNOd != null) {
                    orVaNOd = contactLens.OrVaNOd;
                }
                string orVaNOs = "";
                if (contactLens.OrVaNOs != null) {
                    orVaNOs = contactLens.OrVaNOs;
                }
                string rotationDirectionOd = "";
                if (contactLens.RotationDirectionOd != null) {
                    rotationDirectionOd = contactLens.RotationDirectionOd;
                }
                string rotationDirectionOs = "";
                if (contactLens.RotationDirectionOs != null) {
                    rotationDirectionOs = contactLens.RotationDirectionOs;
                }

                var ehrOrig = eyeMDDbContext.EmrvisitContactLenses.FirstOrDefault(x => x.PtId == ptId);

                if (ehrOrig != null) {
                    ehrOrig.VisitId = visitId;
                    ehrOrig.PtId = ptId;
                    ehrOrig.Dosdate = dosdate;
                    ehrOrig.RxId = rxId;
                    ehrOrig.ContactClass = contactClass;
                    ehrOrig.LensType = lensType;
                    ehrOrig.PowerOd = powerOd;
                    ehrOrig.PowerOs = powerOs;
                    ehrOrig.CylinderOd = cylinderOd;
                    ehrOrig.CylinderOs = cylinderOs;
                    ehrOrig.AxisOd = axisOd;
                    ehrOrig.AxisOs = axisOs;
                    ehrOrig.BcOd = bcOd;
                    ehrOrig.BcOs = bcOs;
                    ehrOrig.AddOd = addOd;
                    ehrOrig.AddOs = addOs;
                    ehrOrig.ColorOd = colorOd;
                    ehrOrig.ColorOs = colorOs;
                    ehrOrig.PupilOd = pupilOd;
                    ehrOrig.PupilOs = pupilOs;
                    ehrOrig.VaDOd = vaDOd;
                    ehrOrig.VaDOs = vaDOs;
                    ehrOrig.VaDOu = vaDOu;
                    ehrOrig.VaNOd = VaNOd;
                    ehrOrig.VaNOs = VaNOs;
                    ehrOrig.VaNOu = VaNOu;
                    ehrOrig.VaIOd = vaIOd;
                    ehrOrig.VaIOs = vaIOs;
                    ehrOrig.VaIOu = vaIOu;
                    ehrOrig.ComfortOd = comfortOd;
                    ehrOrig.ComfortOs = comfortOs;
                    ehrOrig.CentrationOd = centrationOd;
                    ehrOrig.CentrationOs = centrationOs;
                    ehrOrig.CoverageOd = coverageOd;
                    ehrOrig.CoverageOs = coverageOs;
                    ehrOrig.MovementOd = movementOd;
                    ehrOrig.MovementOs = movementOs;
                    ehrOrig.DiameterOd = diameterOd;
                    ehrOrig.DiameterOs = diameterOs;
                    ehrOrig.RotationDegOd = rotationDegOd;
                    ehrOrig.RotationDegOs = rotationDegOs;
                    ehrOrig.KOd = kOd;
                    ehrOrig.KOs = kOs;
                    ehrOrig.EdgeLiftOd = edgeLiftOd;
                    ehrOrig.EdgeLiftOs = edgeLiftOs;
                    ehrOrig.DistNearOd = distNearOd;
                    ehrOrig.DistNearOs = distNearOs;
                    ehrOrig.PtInsertedRemoved = ptInsertedRemoved;
                    ehrOrig.WAgeOd = wAgeOd;
                    ehrOrig.WAgeOs = wAgeOs;
                    ehrOrig.WTimeTodayOd = wTimeTodayOd;
                    ehrOrig.WTimeTodayOs = wTimeTodayOs;
                    ehrOrig.WAvgWearTimeOd = wAvgWearTimeOd;
                    ehrOrig.WAvgWearTimeOs = wAvgWearTimeOs;
                    ehrOrig.Solution = solution;
                    ehrOrig.ProductOd = productOd;
                    ehrOrig.ProductOs = productOs;
                    ehrOrig.LensDesignOd = lensDesignOd;
                    ehrOrig.LensDesignOs = lensDesignOs;
                    ehrOrig.MaterialOd = materialOd;
                    ehrOrig.MaterialOs = materialOs;
                    ehrOrig.ReplacementSchedule = replacementSchedule;
                    ehrOrig.WearingInstructions = wearingInstructions;
                    ehrOrig.Expires = expires;
                    ehrOrig.RgpLayoutOd = rgpLayoutOd;
                    ehrOrig.RgpLayoutOs = rgpLayoutOs;
                    ehrOrig.Power2Od = power2Od;
                    ehrOrig.Power2Os = power2Os;
                    ehrOrig.Cylinder2Od = cylinder2Od;
                    ehrOrig.Cylinder2Os = cylinder2Os;
                    ehrOrig.Axis2Od = axis2Od;
                    ehrOrig.Axis2Os = axis2Os;
                    ehrOrig.Bc2Od = bc2Od;
                    ehrOrig.Bc2Os = bc2Os;
                    ehrOrig.Diameter2Od = diameter2Od;
                    ehrOrig.Diameter2Os = diameter2Os;
                    ehrOrig.PeriphCurveOd = periphCurveOd;
                    ehrOrig.PeriphCurveOs = periphCurveOs;
                    ehrOrig.PeriphCurve2Od = peripheralCurve2Od;
                    ehrOrig.PeriphCurve2Os = peripheralCurve2Os;
                    ehrOrig.SecondaryCurveOd = secondaryCurveOd;
                    ehrOrig.SecondaryCurveOs = secondaryCurveOs;
                    ehrOrig.EquivalentCurveOd = equivalentCurveOd;
                    ehrOrig.EquivalentCurveOs = equivalentCurveOs;
                    ehrOrig.CenterThicknessOd = centerThicknessOd;
                    ehrOrig.CenterThicknessOs = centerThicknessOs;
                    ehrOrig.OpticalZoneDiaOd = opticalZoneDiaOd;
                    ehrOrig.OpticalZoneDiaOs = opticalZoneDiaOs;
                    ehrOrig.EdgeOd = edgeOd;
                    ehrOrig.EdgeOs = edgeOs;
                    ehrOrig.BlendOd = blendOd;
                    ehrOrig.BlendOs = blendOs;
                    ehrOrig.NaFlPatternOd = naFlPatternOd;
                    ehrOrig.NaFlPatternOs = naFlPatternOs;
                    ehrOrig.SurfaceWettingOd = surfaceWettingOd;
                    ehrOrig.SurfaceWettingOs = surfaceWettingOs;
                    ehrOrig.DkOd = dkOd;
                    ehrOrig.DkOs = dkOs;
                    ehrOrig.SegHeightOd = segHeightOd;
                    ehrOrig.SegHeightOs = segHeightOs;
                    ehrOrig.SpecialInstructionsOd = specialInstructionsOd;
                    ehrOrig.SpecialInstructionsOs = specialInstructionsOs;
                    ehrOrig.InsertGuid = insertGUID;
                    ehrOrig.TreeviewTableIdOd = treeviewTableIdOd;
                    ehrOrig.TreeviewTableIdOs = treeviewTableIdOs;
                    ehrOrig.Notes = notes;
                    ehrOrig.Remarks = remarks;
                    ehrOrig.Printed = printed;
                    ehrOrig.SentToOptical = sentToOptical;
                    ehrOrig.UpcOd = upcOd;
                    ehrOrig.UpcOs = upcOs;
                    ehrOrig.CatalogSource = catalogSource;
                    ehrOrig.CatalogManufacturerIdOd = catalogManufacturerIdOd;
                    ehrOrig.CatalogManufacturerIdOs = catalogManufacturerIdOs;
                    ehrOrig.CatalogBrandIdOd = catalogBrandIdOd;
                    ehrOrig.CatalogBrandIdOs = catalogBrandIdOs;
                    ehrOrig.CatalogProductIdOd = catalogProductIdOd;
                    ehrOrig.CatalogProductIdOs = catalogProductIdOs;
                    ehrOrig.TrialNumber = trialNumber;
                    ehrOrig.OrSphereOd = orSphereOd;
                    ehrOrig.OrSphereOs = orSphereOs;
                    ehrOrig.OrCylinderOd = orCylinderOd;
                    ehrOrig.OrCylinderOs = orCylinderOs;
                    ehrOrig.OrAxisOd = orAxisOd;
                    ehrOrig.OrAxisOs = orAxisOs;
                    ehrOrig.OrVaDOd = orVaDOd;
                    ehrOrig.OrVaDOs = orVaDOs;
                    ehrOrig.OrVaNOd = orVaNOd;
                    ehrOrig.OrVaNOs = orVaNOs;
                    ehrOrig.RotationDirectionOd = rotationDirectionOd;
                    ehrOrig.RotationDirectionOs = rotationDirectionOs;
                    eyeMDDbContext.SaveChanges();
                    return;
                }



                var newContactLens = new Brady_s_Conversion_Program.ModelsB.EmrvisitContactLense {
                    VisitId = visitId,
                    PtId = ptId,
                    Dosdate = dosdate,
                    RxId = rxId,
                    ContactClass = contactClass,
                    LensType = lensType,
                    PowerOd = powerOd,
                    PowerOs = powerOs,
                    CylinderOd = cylinderOd,
                    CylinderOs = cylinderOs,
                    AxisOd = axisOd,
                    AxisOs = axisOs,
                    BcOd = bcOd,
                    BcOs = bcOs,
                    AddOd = addOd,
                    AddOs = addOs,
                    ColorOd = colorOd,
                    ColorOs = colorOs,
                    PupilOd = pupilOd,
                    PupilOs = pupilOs,
                    VaDOd = vaDOd,
                    VaDOs = vaDOs,
                    VaDOu = vaDOu,
                    VaNOd = VaNOd,
                    VaNOs = VaNOs,
                    VaNOu = VaNOu,
                    VaIOd = vaIOd,
                    VaIOs = vaIOs,
                    VaIOu = vaIOu,
                    ComfortOd = comfortOd,
                    ComfortOs = comfortOs,
                    CentrationOd = centrationOd,
                    CentrationOs = centrationOs,
                    CoverageOd = coverageOd,
                    CoverageOs = coverageOs,
                    MovementOd = movementOd,
                    MovementOs = movementOs,
                    DiameterOd = diameterOd,
                    DiameterOs = diameterOs,
                    RotationDegOd = rotationDegOd,
                    RotationDegOs = rotationDegOs,
                    KOd = kOd,
                    KOs = kOs,
                    EdgeLiftOd = edgeLiftOd,
                    EdgeLiftOs = edgeLiftOs,
                    DistNearOd = distNearOd,
                    DistNearOs = distNearOs,
                    PtInsertedRemoved = ptInsertedRemoved,
                    WAgeOd = wAgeOd,
                    WAgeOs = wAgeOs,
                    WTimeTodayOd = wTimeTodayOd,
                    WTimeTodayOs = wTimeTodayOs,
                    WAvgWearTimeOd = wAvgWearTimeOd,
                    WAvgWearTimeOs = wAvgWearTimeOs,
                    Solution = solution,
                    ProductOd = productOd,
                    ProductOs = productOs,
                    LensDesignOd = lensDesignOd,
                    LensDesignOs = lensDesignOs,
                    MaterialOd = materialOd,
                    MaterialOs = materialOs,
                    ReplacementSchedule = replacementSchedule,
                    WearingInstructions = wearingInstructions,
                    Expires = expires,
                    RgpLayoutOd = rgpLayoutOd,
                    RgpLayoutOs = rgpLayoutOs,
                    Power2Od = power2Od,
                    Power2Os = power2Os,
                    Cylinder2Od = cylinder2Od,
                    Cylinder2Os = cylinder2Os,
                    Axis2Od = axis2Od,
                    Axis2Os = axis2Os,
                    Bc2Od = bc2Od,
                    Bc2Os = bc2Os,
                    Diameter2Od = diameter2Od,
                    Diameter2Os = diameter2Os,
                    PeriphCurveOd = periphCurveOd,
                    PeriphCurveOs = periphCurveOs,
                    PeriphCurve2Od = peripheralCurve2Od,
                    PeriphCurve2Os = peripheralCurve2Os,
                    SecondaryCurveOd = secondaryCurveOd,
                    SecondaryCurveOs = secondaryCurveOs,
                    EquivalentCurveOd = equivalentCurveOd,
                    EquivalentCurveOs = equivalentCurveOs,
                    CenterThicknessOd = centerThicknessOd,
                    CenterThicknessOs = centerThicknessOs,
                    OpticalZoneDiaOd = opticalZoneDiaOd,
                    OpticalZoneDiaOs = opticalZoneDiaOs,
                    EdgeOd = edgeOd,
                    EdgeOs = edgeOs,
                    BlendOd = blendOd,
                    BlendOs = blendOs,
                    NaFlPatternOd = naFlPatternOd,
                    NaFlPatternOs = naFlPatternOs,
                    SurfaceWettingOd = surfaceWettingOd,
                    SurfaceWettingOs = surfaceWettingOs,
                    DkOd = dkOd,
                    DkOs = dkOs,
                    SegHeightOd = segHeightOd,
                    SegHeightOs = segHeightOs,
                    SpecialInstructionsOd = specialInstructionsOd,
                    SpecialInstructionsOs = specialInstructionsOs,
                    InsertGuid = insertGUID,
                    TreeviewTableIdOd = treeviewTableIdOd,
                    TreeviewTableIdOs = treeviewTableIdOs,
                    Notes = notes,
                    Remarks = remarks,
                    Printed = printed,
                    SentToOptical = sentToOptical,
                    UpcOd = upcOd,
                    UpcOs = upcOs,
                    CatalogSource = catalogSource,
                    CatalogManufacturerIdOd = catalogManufacturerIdOd,
                    CatalogManufacturerIdOs = catalogManufacturerIdOs,
                    CatalogBrandIdOd = catalogBrandIdOd,
                    CatalogBrandIdOs = catalogBrandIdOs,
                    CatalogProductIdOd = catalogProductIdOd,
                    CatalogProductIdOs = catalogProductIdOs,
                    TrialNumber = trialNumber,
                    OrSphereOd = orSphereOd,
                    OrSphereOs = orSphereOs,
                    OrCylinderOd = orCylinderOd,
                    OrCylinderOs = orCylinderOs,
                    OrAxisOd = orAxisOd,
                    OrAxisOs = orAxisOs,
                    OrVaDOd = orVaDOd,
                    OrVaDOs = orVaDOs,
                    OrVaNOd = orVaNOd,
                    OrVaNOs = orVaNOs,
                    RotationDirectionOd = rotationDirectionOd,
                    RotationDirectionOs = rotationDirectionOs
                };
                eyeMDDbContext.EmrvisitContactLenses.Add(newContactLens);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the contact lens with ID: {contactLens.Id}. Error: {e.Message}");
            }
        }

        public static void DiagCodePoolsConvert(ModelsC.DiagCodePool diagCodePool, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? visitId = null;
                if (diagCodePool.VisitId != null) {
                    if (int.TryParse(diagCodePool.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                int? ptId = null;
                if (diagCodePool.PtId != null) {
                    if (int.TryParse(diagCodePool.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                if (ptId == null && visitId == null) {
                    logger.Log($"EHR: EHR Visit ID and Patient ID not found for diag code pool with visit ID: {diagCodePool.VisitId}");
                }
                else if (ptId == null) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null) {
                        ptId = eyeMDVisit.PtId;
                    }
                    else {
                        logger.Log($"EHR: EHR Visit not found for diag code pool with ID: {diagCodePool.VisitId}");
                    }
                }
                else if (visitId == null) {
                    logger.Log($"EHR: EHR VisitID not found for diag code pool with ID: {diagCodePool.VisitId}");
                }

                int? controlId = null;
                // no controlId
                DateTime? dosDate = null;
                if (diagCodePool.Dosdate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(diagCodePool.Dosdate, dateFormats,
                        CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosDate = tempDateTime;
                    }
                }
                string diagText = "";
                if (diagCodePool.DiagText != null) {
                    diagText = diagCodePool.DiagText;
                }
                string code = "";
                if (diagCodePool.Code != null) {
                    code = diagCodePool.Code;
                }
                string modifier = "";
                if (diagCodePool.Modifier != null) {
                    modifier = diagCodePool.Modifier;
                }
                string sourceField = "";
                if (diagCodePool.SourceField != null) {
                    sourceField = diagCodePool.SourceField;
                }
                short isactive = -1;
                if (short.TryParse(diagCodePool.IsActive, out short temp)) {
                    isactive = temp;
                }
                string codeICD10 = "";
                if (diagCodePool.CodeIcd10 != null) {
                    codeICD10 = diagCodePool.CodeIcd10;
                }
                string codeSNOMED = "";
                if (diagCodePool.CodeSnomed != null) {
                    codeSNOMED = diagCodePool.CodeSnomed;
                }
                string insertGUID = Guid.NewGuid().ToString();
                // no insertGUID
                int? requestedProcId = null;
                if (diagCodePool.RequestedProcedureId != null) {
                    if (int.TryParse(diagCodePool.RequestedProcedureId, out int locum)) {
                        requestedProcId = locum;
                    }
                }
                string location1 = "";
                if (diagCodePool.Location1 != null) {
                    location1 = diagCodePool.Location1;
                }
                string onsetMonth1 = "";
                if (diagCodePool.OnsetMonth1 != null) {
                    onsetMonth1 = diagCodePool.OnsetMonth1;
                }
                string onsetDay1 = "";
                if (diagCodePool.OnsetDay1 != null) {
                    onsetDay1 = diagCodePool.OnsetDay1;
                }
                string onsetYear1 = "";
                if (diagCodePool.OnsetYear1 != null) {
                    onsetYear1 = diagCodePool.OnsetYear1;
                }
                string location2 = "";
                if (diagCodePool.Location2 != null) {
                    location2 = diagCodePool.Location2;
                }
                int? location2onsetVisitId = null;
                if (diagCodePool.Location2OnsetVisitId != null) {
                    if (int.TryParse(diagCodePool.Location2OnsetVisitId, out int locum)) {
                        location2onsetVisitId = locum;
                    }
                }
                string onsetMonth2 = "";
                if (diagCodePool.OnsetMonth2 != null) {
                    onsetMonth2 = diagCodePool.OnsetMonth2;
                }
                string onsetDay2 = "";
                if (diagCodePool.OnsetDay2 != null) {
                    onsetDay2 = diagCodePool.OnsetDay2;
                }
                string onsetYear2 = "";
                if (diagCodePool.OnsetYear2 != null) {
                    onsetYear2 = diagCodePool.OnsetYear2;
                }
                short isResolved1 = -1;
                if (short.TryParse(diagCodePool.IsResolved1, out short foo)) {
                    isResolved1 = foo;
                }
                int? resolvedVisitId1 = null;
                if (diagCodePool.ResolvedVisitId1 != null) {
                    if (int.TryParse(diagCodePool.ResolvedVisitId1, out int locum)) {
                        resolvedVisitId1 = locum;
                    }
                }
                int? resolvedRequestedProcId1 = null;
                if (diagCodePool.ResolvedRequestedProcedureId1 != null) {
                    if (int.TryParse(diagCodePool.ResolvedRequestedProcedureId1, out int locum)) {
                        resolvedRequestedProcId1 = locum;
                    }
                }
                DateTime? resolvedDate1 = null; 
                if (diagCodePool.ResolvedDate1 != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(diagCodePool.Dosdate, dateFormats,
                        CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        resolvedDate1 = tempDateTime;
                    }
                }
                string resolveType1 = "";
                if (diagCodePool.ResolveType1 != null) {
                    resolveType1 = diagCodePool.ResolveType1;
                }
                short isResolved2 = -1;
                if (short.TryParse(diagCodePool.IsResolved2, out short temp2)) {
                    isResolved2 = temp2;
                }
                int? resolvedVisitId2 = null;
                if (diagCodePool.ResolvedVisitId2 != null) {
                    if (int.TryParse(diagCodePool.ResolvedVisitId2, out int locum)) {
                        resolvedVisitId2 = locum;
                    }
                }
                int? resolvedRequestedProc2 = null;
                if (diagCodePool.ResolvedRequestedProcedureId2 != null) {
                    if (int.TryParse(diagCodePool.ResolvedRequestedProcedureId2, out int locum)) {
                        resolvedRequestedProc2 = locum;
                    }
                }
                DateTime? resolvedDate2 = null;
                if (diagCodePool.ResolvedDate2 != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(diagCodePool.Dosdate, dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        resolvedDate2 = tempDateTime;
                    }
                }
                string resolveType2 = "";
                if (diagCodePool.ResolveType2 != null) {
                    resolveType2 = diagCodePool.ResolveType2;
                }
                bool doNotReconcile = false;
                if (diagCodePool.DoNotReconcile != null && diagCodePool.DoNotReconcile.ToLower() == "yes") {
                    doNotReconcile = true;
                }
                int? conditionId = null;
                // no conditionId
                DateTime? lastModified = null;
                // no lastModified
                DateTime? created = null;
                // no created
                int? createdEmpId = null;
                // no createdEmpId

                var ehrOrig = eyeMDDbContext.EmrvisitDiagCodePools.FirstOrDefault(x => x.PtId == ptId);
                var ehrOrigVisit = eyeMDDbContext.EmrvisitDiagCodePools.FirstOrDefault(x => x.VisitId == visitId);

                if (ehrOrig != null && ehrOrigVisit != null && ehrOrig == ehrOrigVisit) {
                    ehrOrig.VisitId = visitId;
                    ehrOrig.PtId = ptId;
                    ehrOrig.ControlId = controlId;
                    ehrOrig.DiagText = diagText;
                    ehrOrig.Code = code;
                    ehrOrig.Modifier = modifier;
                    ehrOrig.SourceField = sourceField;
                    ehrOrig.IsActive = isactive;
                    ehrOrig.CodeIcd10 = codeICD10;
                    ehrOrig.CodeSnomed = codeSNOMED;
                    ehrOrig.InsertGuid = insertGUID;
                    ehrOrig.RequestedProcedureId = requestedProcId;
                    ehrOrig.Location1 = location1;
                    ehrOrig.OnsetMonth1 = onsetMonth1;
                    ehrOrig.OnsetDay1 = onsetDay1;
                    ehrOrig.OnsetYear1 = onsetYear1;
                    ehrOrig.Location2 = location2;
                    ehrOrig.Location2OnsetVisitId = location2onsetVisitId;
                    ehrOrig.OnsetMonth2 = onsetMonth2;
                    ehrOrig.OnsetDay2 = onsetDay2;
                    ehrOrig.IsResolved1 = isResolved1;
                    ehrOrig.ResolvedVisitId1 = resolvedVisitId1;
                    ehrOrig.ResolvedRequestedProcedureId1 = resolvedRequestedProcId1;
                    ehrOrig.ResolvedDate1 = resolvedDate1;
                    ehrOrig.ResolveType1 = resolveType1;
                    ehrOrig.IsResolved2 = isResolved2;
                    ehrOrig.ResolvedVisitId2 = resolvedVisitId2;
                    ehrOrig.ResolvedRequestedProcedureId2 = resolvedRequestedProc2;
                    ehrOrig.ResolvedDate2 = resolvedDate2;
                    ehrOrig.ResolveType2 = resolveType2;
                    ehrOrig.DoNotReconcile = doNotReconcile;
                    ehrOrig.ConditionId = conditionId;
                    ehrOrig.LastModified = lastModified;
                    ehrOrig.Created = created;
                    ehrOrig.CreatedEmpId = createdEmpId;
                    ehrOrig.Dosdate = dosDate;
                    eyeMDDbContext.SaveChanges();
                    return;
                }



                var newDiagCodePool = new Brady_s_Conversion_Program.ModelsB.EmrvisitDiagCodePool {
                    PtId = ptId,
                    VisitId = visitId,
                    ControlId = controlId,
                    DiagText = diagText,
                    Code = code,
                    Modifier = modifier,
                    SourceField = sourceField,
                    IsActive = isactive,
                    CodeIcd10 = codeICD10,
                    CodeSnomed = codeSNOMED,
                    InsertGuid = insertGUID,
                    RequestedProcedureId = requestedProcId,
                    Location1 = location1,
                    OnsetMonth1 = onsetMonth1,
                    OnsetDay1 = onsetDay1,
                    OnsetYear1 = onsetYear1,
                    Location2 = location2,
                    Location2OnsetVisitId = location2onsetVisitId,
                    OnsetMonth2 = onsetMonth2,
                    OnsetDay2 = onsetDay2,
                    IsResolved1 = isResolved1,
                    ResolvedVisitId1 = resolvedVisitId1,
                    ResolvedRequestedProcedureId1 = resolvedRequestedProcId1,
                    ResolvedDate1 = resolvedDate1,
                    ResolveType1 = resolveType1,
                    IsResolved2 = isResolved2,
                    ResolvedVisitId2 = resolvedVisitId2,
                    ResolvedRequestedProcedureId2 = resolvedRequestedProc2,
                    ResolvedDate2 = resolvedDate2,
                    ResolveType2 = resolveType2,
                    DoNotReconcile = doNotReconcile,
                    ConditionId = conditionId,
                    LastModified = lastModified,
                    Created = created,
                    CreatedEmpId = createdEmpId,
                    Dosdate = dosDate,
                    LastModifiedEmpId = null,
                    OnsetYear2 = onsetYear2
                };
                eyeMDDbContext.EmrvisitDiagCodePools.Add(newDiagCodePool);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the diag code pool with visit ID: {diagCodePool.VisitId}. Error: {e.Message}");
            }
        }

        public static void DiagTestsConvert(ModelsC.DiagTest diagTest, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? visitId = null;
                if (diagTest.VisitId != null) {
                    if (int.TryParse(diagTest.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                int? ptId = null;
                if (diagTest.PtId != null) {
                    if (int.TryParse(diagTest.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                if (ptId == null && visitId == null) {
                    logger.Log($"EHR: EHR Visit ID and Patient ID not found for visit order with ID: {diagTest.Id}");
                }
                else if (ptId == null) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null) {
                        ptId = eyeMDVisit.PtId;
                    } else {
                        logger.Log($"EHR: EHR Visit not found for visit order with ID: {diagTest.Id}");
                    }
                }
                else if (visitId == null) {
                    logger.Log($"EHR: EHR VisitID not found for visit order with ID: {diagTest.Id}");
                }

                DateTime? dosDate = null;
                if (diagTest.Dosdate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(diagTest.Dosdate, dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosDate = tempDateTime;
                    }
                }

                #region diagTests
                string gonioAngleDepthSuOd = "";
                if (diagTest.GonioAngleDepthSuOd != null) {
                    gonioAngleDepthSuOd = diagTest.GonioAngleDepthSuOd;
                }
                string gonioAngleDepthMedialOd = "";
                if (diagTest.GonioAngleDepthMedialOd != null) {
                    gonioAngleDepthMedialOd = diagTest.GonioAngleDepthMedialOd;
                }
                string gonioAngleDepthInOd = "";
                if (diagTest.GonioAngleDepthInOd != null) {
                    gonioAngleDepthInOd = diagTest.GonioAngleDepthInOd;
                }
                string gonioAngleDepthTemporalOd = "";
                if (diagTest.GonioAngleDepthTemporalOd != null) {
                    gonioAngleDepthTemporalOd = diagTest.GonioAngleDepthTemporalOd;
                }
                string gonioAngleStructureSuOd = "";
                if (diagTest.GonioAngleStructureSuOd != null) {
                    gonioAngleStructureSuOd = diagTest.GonioAngleStructureSuOd;
                }
                string gonioAngleStructureMedialOd = "";
                if (diagTest.GonioAngleStructureMedialOd != null) {
                    gonioAngleStructureMedialOd = diagTest.GonioAngleStructureMedialOd;
                }
                string gonioAngleStructureInOd = "";
                if (diagTest.GonioAngleStructureInOd != null) {
                    gonioAngleStructureInOd = diagTest.GonioAngleStructureInOd;
                }
                string gonioAngleStructureTemporalOd = "";
                if (diagTest.GonioAngleStructureTemporalOd != null) {
                    gonioAngleStructureTemporalOd = diagTest.GonioAngleStructureTemporalOd;
                }
                string gonioAngleDepthSuOs = "";
                if (diagTest.GonioAngleDepthSuOs != null) {
                    gonioAngleDepthSuOs = diagTest.GonioAngleDepthSuOs;
                }
                string gonioAngleDepthMedialOs = "";
                if (diagTest.GonioAngleDepthMedialOs != null) {
                    gonioAngleDepthMedialOs = diagTest.GonioAngleDepthMedialOs;
                }
                string gonioAngleDepthInOs = "";
                if (diagTest.GonioAngleDepthInOs != null) {
                    gonioAngleDepthInOs = diagTest.GonioAngleDepthInOs;
                }
                string gonioAngleDepthTemporalOs = "";
                if (diagTest.GonioAngleDepthTemporalOs != null) {
                    gonioAngleDepthTemporalOs = diagTest.GonioAngleDepthTemporalOs;
                }
                string gonioAngleStructureSuOs = "";
                if (diagTest.GonioAngleStructureSuOs != null) {
                    gonioAngleStructureSuOs = diagTest.GonioAngleStructureSuOs;
                }
                string gonioAngleStructureMedialOs = "";
                if (diagTest.GonioAngleStructureMedialOs != null) {
                    gonioAngleStructureMedialOs = diagTest.GonioAngleStructureMedialOs;
                }
                string gonioAngleStructureInOs = "";
                if (diagTest.GonioAngleStructureInOs != null) {
                    gonioAngleStructureInOs = diagTest.GonioAngleStructureInOs;
                }
                string gonioAngleStructureTemporalOs = "";
                if (diagTest.GonioAngleStructureTemporalOs != null) {
                    gonioAngleStructureTemporalOs = diagTest.GonioAngleStructureTemporalOs;
                }
                string gonioComments = "";
                if (diagTest.GonioComments != null) {
                    gonioComments = diagTest.GonioComments;
                }
                short mBalanceScOrtho = -1;
                if (short.TryParse(diagTest.MbalanceScOrtho, out short temp)) {
                    mBalanceScOrtho = temp;
                }
                string mBalanceHorizScPriGaze = "";
                if (diagTest.MbalanceHorizScPriGaze != null) {
                    mBalanceHorizScPriGaze = diagTest.MbalanceHorizScPriGaze;
                }
                string mBalanceHorizTypeScPriGaze = "";
                if (diagTest.MbalanceHorizTypeScPriGaze != null) {
                    mBalanceHorizTypeScPriGaze = diagTest.MbalanceHorizTypeScPriGaze;
                }
                string mBalanceVertScPriGaze = "";
                if (diagTest.MbalanceVertScPriGaze != null) {
                    mBalanceVertScPriGaze = diagTest.MbalanceVertScPriGaze;
                }
                string mBalanceVertTypeScPriGaze = "";
                if (diagTest.MbalanceVertTypeScPriGaze != null) {
                    mBalanceVertTypeScPriGaze = diagTest.MbalanceVertTypeScPriGaze;
                }
                string mBalanceHorizScUpGaze = "";
                if (diagTest.MbalanceHorizScUpGaze != null) {
                    mBalanceHorizScUpGaze = diagTest.MbalanceHorizScUpGaze;
                }
                string mBalanceHorizTypeScUpGaze = "";
                if (diagTest.MbalanceHorizTypeScUpGaze != null) {
                    mBalanceHorizTypeScUpGaze = diagTest.MbalanceHorizTypeScUpGaze;
                }
                string mBalanceVertScUpGaze = "";
                if (diagTest.MbalanceVertScUpGaze != null) {
                    mBalanceVertScUpGaze = diagTest.MbalanceVertScUpGaze;
                }
                string mBalanceVertTypeScUpGaze = "";
                if (diagTest.MbalanceVertTypeScUpGaze != null) {
                    mBalanceVertTypeScUpGaze = diagTest.MbalanceVertTypeScUpGaze;
                }
                string mBalanceHorizScDownGaze = "";
                if (diagTest.MbalanceHorizScDownGaze != null) {
                    mBalanceHorizScDownGaze = diagTest.MbalanceHorizScDownGaze;
                }
                string mBalanceHorizTypeScDownGaze = "";
                if (diagTest.MbalanceHorizTypeScDownGaze != null) {
                    mBalanceHorizTypeScDownGaze = diagTest.MbalanceHorizTypeScDownGaze;
                }
                string mBalanceVertScDownGaze = "";
                if (diagTest.MbalanceVertScDownGaze != null) {
                    mBalanceVertScDownGaze = diagTest.MbalanceVertScDownGaze;
                }
                string mBalanceVertTypeScDownGaze = "";
                if (diagTest.MbalanceVertTypeScDownGaze != null) {
                    mBalanceVertTypeScDownGaze = diagTest.MbalanceVertTypeScDownGaze;
                }
                string mBalanceHorizScRtGaze = "";
                if (diagTest.MbalanceHorizScRtGaze != null) {
                    mBalanceHorizScRtGaze = diagTest.MbalanceHorizScRtGaze;
                }
                string mBalanceHorizTypeScRtGaze = "";
                if (diagTest.MbalanceHorizTypeScRtGaze != null) {
                    mBalanceHorizTypeScRtGaze = diagTest.MbalanceHorizTypeScRtGaze;
                }
                string mBalanceVertScRtGaze = "";
                if (diagTest.MbalanceVertScRtGaze != null) {
                    mBalanceVertScRtGaze = diagTest.MbalanceVertScRtGaze;
                }
                string mBalanceVertTypeScRtGaze = "";    
                if (diagTest.MbalanceVertTypeScRtGaze != null) {
                    mBalanceVertTypeScRtGaze = diagTest.MbalanceVertTypeScRtGaze;
                }
                string mBalanceHorizScLtGaze = "";
                if (diagTest.MbalanceHorizScLtGaze != null) {
                    mBalanceHorizScLtGaze = diagTest.MbalanceHorizScLtGaze;
                }
                string mBalanceHorizTypeScLtGaze = "";
                if (diagTest.MbalanceHorizTypeScLtGaze != null) {
                    mBalanceHorizTypeScLtGaze = diagTest.MbalanceHorizTypeScLtGaze;
                }
                string mBalanceVertScLtGaze = "";
                if (diagTest.MbalanceVertScLtGaze != null) {
                    mBalanceVertScLtGaze = diagTest.MbalanceVertScLtGaze;
                }
                string mBalanceVertTypeScLtGaze = "";
                if (diagTest.MbalanceVertTypeScLtGaze != null) {
                    mBalanceVertTypeScLtGaze = diagTest.MbalanceVertTypeScLtGaze;
                }
                short mBalanceCCOrtho = -1;
                if (short.TryParse(diagTest.MbalanceCcOrtho, out short temp3)) {
                    mBalanceCCOrtho = temp3;
                }
                string mBalanceHorizCcPriGaze = "";
                if (diagTest.MbalanceHorizCcPriGaze != null) {
                    mBalanceHorizCcPriGaze = diagTest.MbalanceHorizCcPriGaze;
                }
                string mBalanceHorizTypeCcPriGaze = "";
                if (diagTest.MbalanceHorizTypeCcPriGaze != null) {
                    mBalanceHorizTypeCcPriGaze = diagTest.MbalanceHorizTypeCcPriGaze;
                }
                string mBalanceVertCcPriGaze = "";
                if (diagTest.MbalanceVertCcPriGaze != null) {
                    mBalanceVertCcPriGaze = diagTest.MbalanceVertCcPriGaze;
                }
                string mBalanceVertTypeCcPriGaze = "";
                if (diagTest.MbalanceVertTypeCcPriGaze != null) {
                    mBalanceVertTypeCcPriGaze = diagTest.MbalanceVertTypeCcPriGaze;
                }
                string mBalanceHorizCcUpGaze = "";
                if (diagTest.MbalanceHorizCcUpGaze != null) {
                    mBalanceHorizCcUpGaze = diagTest.MbalanceHorizCcUpGaze;
                }
                string mBalanceHorizTypeCcUpGaze = "";
                if (diagTest.MbalanceHorizTypeCcUpGaze != null) {
                    mBalanceHorizTypeCcUpGaze = diagTest.MbalanceHorizTypeCcUpGaze;
                }
                string mBalanceVertCcUpGaze = "";
                if (diagTest.MbalanceVertCcUpGaze != null) {
                    mBalanceVertCcUpGaze = diagTest.MbalanceVertCcUpGaze;
                }
                string mBalanceVertTypeCcUpGaze = "";
                if (diagTest.MbalanceVertTypeCcUpGaze != null) {
                    mBalanceVertTypeCcUpGaze = diagTest.MbalanceVertTypeCcUpGaze;
                }
                string mBalanceHorizCcDownGaze = "";
                if (diagTest.MbalanceHorizCcDownGaze != null) {
                    mBalanceHorizCcDownGaze = diagTest.MbalanceHorizCcDownGaze;
                }
                string mBalanceHorizTypeCcDownGaze = "";
                if (diagTest.MbalanceHorizTypeCcDownGaze != null) {
                    mBalanceHorizTypeCcDownGaze = diagTest.MbalanceHorizTypeCcDownGaze;
                }
                string mBalanceVertCcDownGaze = "";
                if (diagTest.MbalanceVertCcDownGaze != null) {
                    mBalanceVertCcDownGaze = diagTest.MbalanceVertCcDownGaze;
                }
                string mBalanceVertTypeCcDownGaze = "";
                if (diagTest.MbalanceVertTypeCcDownGaze != null) {
                    mBalanceVertTypeCcDownGaze = diagTest.MbalanceVertTypeCcDownGaze;
                }
                string mBalanceHorizCcRtGaze = "";
                if (diagTest.MbalanceHorizCcRtGaze != null) {
                    mBalanceHorizCcRtGaze = diagTest.MbalanceHorizCcRtGaze;
                }
                string mBalanceHorizTypeCcRtGaze = "";
                if (diagTest.MbalanceHorizTypeCcRtGaze != null) {
                    mBalanceHorizTypeCcRtGaze = diagTest.MbalanceHorizTypeCcRtGaze;
                }
                string mBalanceVertCcRtGaze = "";
                if (diagTest.MbalanceVertCcRtGaze != null) {
                    mBalanceVertCcRtGaze = diagTest.MbalanceVertCcRtGaze;
                }
                string mBalanceVertTypeCcRtGaze = "";
                if (diagTest.MbalanceVertTypeCcRtGaze != null) {
                    mBalanceVertTypeCcRtGaze = diagTest.MbalanceVertTypeCcRtGaze;
                }
                string mBalanceHorizCcLtGaze = "";
                if (diagTest.MbalanceHorizCcLtGaze != null) {
                    mBalanceHorizCcLtGaze = diagTest.MbalanceHorizCcLtGaze;
                }
                string mBalanceHorizTypeCcLtGaze = "";
                if (diagTest.MbalanceHorizTypeCcLtGaze != null) {
                    mBalanceHorizTypeCcLtGaze = diagTest.MbalanceHorizTypeCcLtGaze;
                }
                string mBalanceVertCcLtGaze = "";
                if (diagTest.MbalanceVertCcLtGaze != null) {
                    mBalanceVertCcLtGaze = diagTest.MbalanceVertCcLtGaze;
                }
                string mBalanceVertTypeCcLtGaze = "";
                if (diagTest.MbalanceVertTypeCcLtGaze != null) {
                    mBalanceVertTypeCcLtGaze = diagTest.MbalanceVertTypeCcLtGaze;
                }
                string mBalanceMethod = "";
                if (diagTest.MbalanceMethod != null) {
                    mBalanceMethod = diagTest.MbalanceMethod;
                }
                string gonioPigmentOd = "";
                if (diagTest.GonioPigmentOd != null) {
                    gonioPigmentOd = diagTest.GonioPigmentOd;
                }
                string gonioPigmentOs = "";
                if (diagTest.GonioPigmentOs != null) {
                    gonioPigmentOs = diagTest.GonioPigmentOs;
                }
                string mBalanceScType = "";
                if (diagTest.MbalanceScType != null) {
                    mBalanceScType = diagTest.MbalanceScType;
                }
                string mBalanceCcType = "";
                if (diagTest.MbalanceCcType != null) {
                    mBalanceCcType = diagTest.MbalanceCcType;
                }
                string mbalanceHorizScUpRtGaze = "";
                if (diagTest.MbalanceHorizScUpRtGaze != null) {
                    mbalanceHorizScUpRtGaze = diagTest.MbalanceHorizScUpRtGaze;
                }
                string mBalancehorizTypeScUpRtGaze = "";
                if (diagTest.MbalanceHorizTypeScUpRtGaze != null) {
                    mBalancehorizTypeScUpRtGaze = diagTest.MbalanceHorizTypeScUpRtGaze;
                }
                string mBalanceVertScUpRtGaze = "";
                if (diagTest.MbalanceVertScUpRtGaze != null) {
                    mBalanceVertScUpRtGaze = diagTest.MbalanceVertScUpRtGaze;
                }
                string mBalanceVertTypeScUpRtGaze = "";
                if (diagTest.MbalanceVertTypeScUpRtGaze != null) {
                    mBalanceVertTypeScUpRtGaze = diagTest.MbalanceVertTypeScUpRtGaze;
                }
                string mBalanceHorizScUpLtGaze = "";
                if (diagTest.MbalanceHorizScUpLtGaze != null) {
                    mBalanceHorizScUpLtGaze = diagTest.MbalanceHorizScUpLtGaze;
                }
                string mBalanceHorizTypeScUpLtGaze = "";
                if (diagTest.MbalanceHorizTypeScUpLtGaze != null) {
                    mBalanceHorizTypeScUpLtGaze = diagTest.MbalanceHorizTypeScUpLtGaze;
                }
                string mBalanceVertScUpLtGaze = "";
                if (diagTest.MbalanceVertScUpLtGaze != null) {
                    mBalanceVertScUpLtGaze = diagTest.MbalanceVertScUpLtGaze;
                }
                string mBalanceVertTypeScUpLtGaze = "";
                if (diagTest.MbalanceVertTypeScUpLtGaze != null) {
                    mBalanceVertTypeScUpLtGaze = diagTest.MbalanceVertTypeScUpLtGaze;
                }
                string mBalanceHorizScDownRtGaze = "";
                if (diagTest.MbalanceHorizScDownRtGaze != null) {
                    mBalanceHorizScDownRtGaze = diagTest.MbalanceHorizScDownRtGaze;
                }
                string mBalanceHorizTypeScDownRtGaze = "";
                if (diagTest.MbalanceHorizTypeScDownRtGaze != null) {
                    mBalanceHorizTypeScDownRtGaze = diagTest.MbalanceHorizTypeScDownRtGaze;
                }
                string mBalanceVertScDownRtGaze = "";
                if (diagTest.MbalanceVertScDownRtGaze != null) {
                    mBalanceVertScDownRtGaze = diagTest.MbalanceVertScDownRtGaze;
                }
                string mBalanceVertTypeScDownRtGaze = "";
                if (diagTest.MbalanceVertTypeScDownRtGaze != null) {
                    mBalanceVertTypeScDownRtGaze = diagTest.MbalanceVertTypeScDownRtGaze;
                }
                string mBalanceHorizScDownLtGaze = "";
                if (diagTest.MbalanceHorizScDownLtGaze != null) {
                    mBalanceHorizScDownLtGaze = diagTest.MbalanceHorizScDownLtGaze;
                }
                string mBalanceHorizTypeScDownLtGaze = "";
                if (diagTest.MbalanceHorizTypeScDownLtGaze != null) {
                    mBalanceHorizTypeScDownLtGaze = diagTest.MbalanceHorizTypeScDownLtGaze;
                }
                string mBalanceVertScDownLtGaze = "";
                if (diagTest.MbalanceVertScDownLtGaze != null) {
                    mBalanceVertScDownLtGaze = diagTest.MbalanceVertScDownLtGaze;
                }
                string mBalanceVertTypeScDownLtGaze = "";
                if (diagTest.MbalanceVertTypeScDownLtGaze != null) {
                    mBalanceVertTypeScDownLtGaze = diagTest.MbalanceVertTypeScDownLtGaze;
                }
                string mBalanceHorizCcUpRtGaze = "";
                if (diagTest.MbalanceHorizCcUpRtGaze != null) {
                    mBalanceHorizCcUpRtGaze = diagTest.MbalanceHorizCcUpRtGaze;
                }
                string mBalanceHorizTypeCcUpRtGaze = "";
                if (diagTest.MbalanceHorizTypeCcUpRtGaze != null) {
                    mBalanceHorizTypeCcUpRtGaze = diagTest.MbalanceHorizTypeCcUpRtGaze;
                }
                string mBalanceVertCcUpRtGaze = "";
                if (diagTest.MbalanceVertCcUpRtGaze != null) {
                    mBalanceVertCcUpRtGaze = diagTest.MbalanceVertCcUpRtGaze;
                }
                string mBalanceVertTypeCcUpRtGaze = "";
                if (diagTest.MbalanceVertTypeCcUpRtGaze != null) {
                    mBalanceVertTypeCcUpRtGaze = diagTest.MbalanceVertTypeCcUpRtGaze;
                }
                string mBalanceHorizCcUpLtGaze = "";
                if (diagTest.MbalanceHorizCcUpLtGaze != null) {
                    mBalanceHorizCcUpLtGaze = diagTest.MbalanceHorizCcUpLtGaze;
                }
                string mBalanceHorizTypeCcUpLtGaze = "";
                if (diagTest.MbalanceHorizTypeCcUpLtGaze != null) {
                    mBalanceHorizTypeCcUpLtGaze = diagTest.MbalanceHorizTypeCcUpLtGaze;
                }
                string mBalanceVertCcUpLtGaze = "";
                if (diagTest.MbalanceVertCcUpLtGaze != null) {
                    mBalanceVertCcUpLtGaze = diagTest.MbalanceVertCcUpLtGaze;
                }
                string mBalanceVertTypeCcUpLtGaze = "";
                if (diagTest.MbalanceVertTypeCcUpLtGaze != null) {
                    mBalanceVertTypeCcUpLtGaze = diagTest.MbalanceVertTypeCcUpLtGaze;
                }
                string mBalanceHorizCcDownRtGaze = "";
                if (diagTest.MbalanceHorizCcDownRtGaze != null) {
                    mBalanceHorizCcDownRtGaze = diagTest.MbalanceHorizCcDownRtGaze;
                }
                string mBalanceHorizTypeCcDownRtGaze = "";
                if (diagTest.MbalanceHorizTypeCcDownRtGaze != null) {
                    mBalanceHorizTypeCcDownRtGaze = diagTest.MbalanceHorizTypeCcDownRtGaze;
                }
                string mBalanceVertCcDownRtGaze = "";
                if (diagTest.MbalanceVertCcDownRtGaze != null) {
                    mBalanceVertCcDownRtGaze = diagTest.MbalanceVertCcDownRtGaze;
                }
                string mBalanceVertTypeCcDownRtGaze = "";
                if (diagTest.MbalanceVertTypeCcDownRtGaze != null) {
                    mBalanceVertTypeCcDownRtGaze = diagTest.MbalanceVertTypeCcDownRtGaze;
                }
                string mBalanceHorizCcDownLtGaze = "";
                if (diagTest.MbalanceHorizCcDownLtGaze != null) {
                    mBalanceHorizCcDownLtGaze = diagTest.MbalanceHorizCcDownLtGaze;
                }
                string mBalanceHorizTypeCcDownLtGaze = "";
                if (diagTest.MbalanceHorizTypeCcDownLtGaze != null) {
                    mBalanceHorizTypeCcDownLtGaze = diagTest.MbalanceHorizTypeCcDownLtGaze;
                }
                string mBalanceVertCcDownLtGaze = "";
                if (diagTest.MbalanceVertCcDownLtGaze != null) {
                    mBalanceVertCcDownLtGaze = diagTest.MbalanceVertCcDownLtGaze;
                }
                string mBalanceVertTypeCcDownLtGaze = "";
                if (diagTest.MbalanceVertTypeCcDownLtGaze != null) {
                    mBalanceVertTypeCcDownLtGaze = diagTest.MbalanceVertTypeCcDownLtGaze;
                }
                string smotorFixPrefDist = "";
                if (diagTest.SmotorFixPrefDist != null) {
                    smotorFixPrefDist = diagTest.SmotorFixPrefDist;
                }
                string smotorFixPrefNear = "";
                if (diagTest.SmotorFixPrefNear != null) {
                    smotorFixPrefNear = diagTest.SmotorFixPrefNear;
                }
                string smotorNystagmus = "";
                if (diagTest.SmotorNystagmus != null) {
                    smotorNystagmus = diagTest.SmotorNystagmus;
                }
                string smotorFrisby = "";
                if (diagTest.SmotorFrisby != null) {
                    smotorFrisby = diagTest.SmotorFrisby;
                }
                string smotorLang = "";
                if (diagTest.SmotorLang != null) {
                    smotorLang = diagTest.SmotorLang;
                }
                string smotorTitmusStereoFly = "";
                if (diagTest.SmotorTitmusStereoFly != null) {
                    smotorTitmusStereoFly = diagTest.SmotorTitmusStereoFly;
                }
                string smotorTitmusStereoCircles = "";
                if (diagTest.SmotorTitmusStereoCircles != null) {
                    smotorTitmusStereoCircles = diagTest.SmotorTitmusStereoCircles;
                }
                string smotorTitmusStereoAnimals = "";
                if (diagTest.SmotorTitmusStereoAnimals != null) {
                    smotorTitmusStereoAnimals = diagTest.SmotorTitmusStereoAnimals;
                }
                string smotorRandotCircles = "";
                if (diagTest.SmotorRandotCircles != null) {
                    smotorRandotCircles = diagTest.SmotorRandotCircles;
                }
                string smotorWorth4DotDist = "";
                if (diagTest.SmotorWorth4DotDist != null) {
                    smotorWorth4DotDist = diagTest.SmotorWorth4DotDist;
                }
                string smotorWorth4DotNear = "";
                if (diagTest.SmotorWorth4DotNear != null) {
                    smotorWorth4DotNear = diagTest.SmotorWorth4DotNear;
                }
                string smotorAvPattern = "";
                if (diagTest.SmotorAvpattern != null) {
                    smotorAvPattern = diagTest.SmotorAvpattern;
                }
                string smotorDistStereo = "";
                if (diagTest.SmotorDistStereo != null) {
                    smotorDistStereo = diagTest.SmotorDistStereo;
                }
                string smotorDistVectograph = "";
                if (diagTest.SmotorDistVectograph != null) {
                    smotorDistVectograph = diagTest.SmotorDistVectograph;
                }
                string smotorNPC = "";
                if (diagTest.SmotorNpc != null) {
                    smotorNPC = diagTest.SmotorNpc;
                }
                string smotorHorizVergBoBreak = "";
                if (diagTest.SmotorHorizVergBoBreak != null) {
                    smotorHorizVergBoBreak = diagTest.SmotorHorizVergBoBreak;
                }
                string smotorHorizVergBoRecover = "";
                if (diagTest.SmotorHorizVergBoRecover != null) {
                    smotorHorizVergBoRecover = diagTest.SmotorHorizVergBoRecover;
                }
                string smotorHorizVergBiBreak = "";
                if (diagTest.SmotorHorizVergBiBreak != null) {
                    smotorHorizVergBiBreak = diagTest.SmotorHorizVergBiBreak;
                }
                string smotorHorizVergBiRecover = "";
                if (diagTest.SmotorHorizVergBiRecover != null) {
                    smotorHorizVergBiRecover = diagTest.SmotorHorizVergBiRecover;
                }
                string smotorVertVergBuBreak = "";
                if (diagTest.SmotorVertVergBuBreak != null) {
                    smotorVertVergBuBreak = diagTest.SmotorVertVergBuBreak;
                }
                string smotorVertVergBuRecover = "";
                if (diagTest.SmotorVertVergBuRecover != null) {
                    smotorVertVergBuRecover = diagTest.SmotorVertVergBuRecover;
                }
                string smotorVertVergBdBreak = "";
                if (diagTest.SmotorVertVergBdBreak != null) {
                    smotorVertVergBdBreak = diagTest.SmotorVertVergBdBreak;
                }
                string smotorVertVergBdRecover = "";
                if (diagTest.SmotorVertVergBdRecover != null) {
                    smotorVertVergBdRecover = diagTest.SmotorVertVergBdRecover;
                }
                string smotorDMadRodOd = "";
                if (diagTest.SmotorDmadRodOd != null) {
                    smotorDMadRodOd = diagTest.SmotorDmadRodOd;
                }
                string smotorDMadRodOs = "";
                if (diagTest.SmotorDmadRodOs != null) {
                    smotorDMadRodOs = diagTest.SmotorDmadRodOs;
                }
                string smotorDMadRodTorsionOd = "";
                if (diagTest.SmotorDmadRodTorsionOd != null) {
                    smotorDMadRodTorsionOd = diagTest.SmotorDmadRodTorsionOd;
                }
                string smotorMadRodTorsionOs = "";
                if (diagTest.SmotorDmadRodTorsionOs != null) {
                    smotorMadRodTorsionOs = diagTest.SmotorDmadRodTorsionOs;
                }
                string smotorColorVisionOd = "";
                if (diagTest.SmotorColorVisionOd != null) {
                    smotorColorVisionOd = diagTest.SmotorColorVisionOd;
                }
                string smotorColorVisionOs = "";
                if (diagTest.SmotorColorVisionOs != null) {
                    smotorColorVisionOs = diagTest.SmotorColorVisionOs;
                }
                string smotorColorVisionType = "";
                if (diagTest.SmotorColorVisionType != null) {
                    smotorColorVisionType = diagTest.SmotorColorVisionType;
                }
                short? smotorAbute = null;
                if (short.TryParse(diagTest.SmotorAbute, out short temp4)) {
                    smotorAbute = temp4;
                }
                string smotorHtRtHorizSc = "";
                if (diagTest.SmotorHtRtHorizSc != null) {
                    smotorHtRtHorizSc = diagTest.SmotorHtRtHorizSc;
                }
                string smotorHtRtHorizTypeSc = "";
                if (diagTest.SmotorHtRtHorizTypeSc != null) {
                    smotorHtRtHorizTypeSc = diagTest.SmotorHtRtHorizTypeSc;
                }
                string smotorHtRtVertSc = "";
                if (diagTest.SmotorHtRtVertSc != null) {
                    smotorHtRtVertSc = diagTest.SmotorHtRtVertSc;
                }
                string smotorHtRtVertTypeSc = "";
                if (diagTest.SmotorHtRtVertTypeSc != null) {
                    smotorHtRtVertTypeSc = diagTest.SmotorHtRtVertTypeSc;
                }
                string smotorHtLtHorizSc = "";
                if (diagTest.SmotorHtLtHorizSc != null) {
                    smotorHtLtHorizSc = diagTest.SmotorHtLtHorizSc;
                }
                string smotorHtLtHorizTypeSc = "";
                if (diagTest.SmotorHtLtHorizTypeSc != null) {
                    smotorHtLtHorizTypeSc = diagTest.SmotorHtLtHorizTypeSc;
                }
                string smotorHtLtVertSc = "";
                if (diagTest.SmotorHtLtVertSc != null) {
                    smotorHtLtVertSc = diagTest.SmotorHtLtVertSc;
                }
                string smotorHtLtVertTypeSc = "";
                if (diagTest.SmotorHtLtVertTypeSc != null) {
                    smotorHtLtVertTypeSc = diagTest.SmotorHtLtVertTypeSc;
                }
                string smotorHtRtHorizCc = "";
                if (diagTest.SmotorHtRtHorizCc != null) {
                    smotorHtRtHorizCc = diagTest.SmotorHtRtHorizCc;
                }
                string smotorHtRtHorizTypeCc = "";
                if (diagTest.SmotorHtRtHorizTypeCc != null) {
                    smotorHtRtHorizTypeCc = diagTest.SmotorHtRtHorizTypeCc;
                }
                string smotorHtRtVertCc = "";
                if (diagTest.SmotorHtRtVertCc != null) {
                    smotorHtRtVertCc = diagTest.SmotorHtRtVertCc;
                }
                string smotorHtRtVertTypeCc = "";
                if (diagTest.SmotorHtRtVertTypeCc != null) {
                    smotorHtRtVertTypeCc = diagTest.SmotorHtRtVertTypeCc;
                }
                string smotorHtLtHorizCc = "";
                if (diagTest.SmotorHtLtHorizCc != null) {
                    smotorHtLtHorizCc = diagTest.SmotorHtLtHorizCc;
                }
                string smotorHtLtHorizTypeCc = "";
                if (diagTest.SmotorHtLtHorizTypeCc != null) {
                    smotorHtLtHorizTypeCc = diagTest.SmotorHtLtHorizTypeCc;
                }
                string smotorHtLtVertCc = "";
                if (diagTest.SmotorHtLtVertCc != null) {
                    smotorHtLtVertCc = diagTest.SmotorHtLtVertCc;
                }
                string smotorHtLtVertTypeCc = "";
                if (diagTest.SmotorHtLtVertTypeCc != null) {
                    smotorHtLtVertTypeCc = diagTest.SmotorHtLtVertTypeCc;
                }
                string smotorHtRtHorizScNear = "";
                if (diagTest.SmotorHtRtHorizSc != null) {
                    smotorHtRtHorizScNear = diagTest.SmotorHtRtHorizSc;
                }
                string smotorHtRtHorizTypeScNear = "";
                if (diagTest.SmotorHtRtHorizTypeSc != null) {
                    smotorHtRtHorizTypeScNear = diagTest.SmotorHtRtHorizTypeSc;
                }
                string smotorVertScNear = "";   
                if (diagTest.SmotorVertScNear != null) {
                    smotorVertScNear = diagTest.SmotorVertScNear;
                }
                string smotorVertTypeScNear = "";
                if (diagTest.SmotorVertTypeScNear != null) {
                    smotorVertTypeScNear = diagTest.SmotorVertTypeScNear;
                }
                string smotorHorizCcNear = "";
                if (diagTest.SmotorHorizCcNear != null) {
                    smotorHorizCcNear = diagTest.SmotorHorizCcNear;
                }
                string smotorHorizTypeCcNear = "";
                if (diagTest.SmotorHorizTypeCcNear != null) {
                    smotorHorizTypeCcNear = diagTest.SmotorHorizTypeCcNear;
                }
                string smotorVertCcNear = "";
                if (diagTest.SmotorVertCcNear != null) {
                    smotorVertCcNear = diagTest.SmotorVertCcNear;
                }
                string smotorVertTypeCcNear = "";
                if (diagTest.SmotorVertTypeCcNear != null) {
                    smotorVertTypeCcNear = diagTest.SmotorVertTypeCcNear;
                }
                string smotorHorizScDist = "";
                if (diagTest.SmotorHorizScDist != null) {
                    smotorHorizScDist = diagTest.SmotorHorizScDist;
                }
                string smotorHorizTypeScDist = "";
                if (diagTest.SmotorHorizTypeScDist != null) {
                    smotorHorizTypeScDist = diagTest.SmotorHorizTypeScDist;
                }
                string smotorVertScDist = "";
                if (diagTest.SmotorVertScDist != null) {
                    smotorVertScDist = diagTest.SmotorVertScDist;
                }
                string smotorVertTypeScDist = "";
                if (diagTest.SmotorVertTypeScDist != null) {
                    smotorVertTypeScDist = diagTest.SmotorVertTypeScDist;
                }
                string smotorHorizCcDist = "";
                if (diagTest.SmotorHorizCcDist != null) {
                    smotorHorizCcDist = diagTest.SmotorHorizCcDist;
                }
                string smotorHorizTypeCcDist = "";
                if (diagTest.SmotorHorizTypeCcDist != null) {
                    smotorHorizTypeCcDist = diagTest.SmotorHorizTypeCcDist;
                }
                string smotorVertCcDist = "";
                if (diagTest.SmotorVertCcDist != null) {
                    smotorVertCcDist = diagTest.SmotorVertCcDist;
                }
                string smotorVertTypeCcDist = "";
                if (diagTest.SmotorVertTypeCcDist != null) {
                    smotorVertTypeCcDist = diagTest.SmotorVertTypeCcDist;
                }
                string mbalanceMethodSc = "";
                if (diagTest.MbalanceMethodSc != null) {
                    mbalanceMethodSc = diagTest.MbalanceMethodSc;
                }
                string mbalanceMethodCc = "";
                if (diagTest.MbalanceMethodCc != null) {
                    mbalanceMethodCc = diagTest.MbalanceMethodCc;
                }
                string smotorPrismOd = "";
                if (diagTest.SmotorPrismOd != null) {
                    smotorPrismOd = diagTest.SmotorPrismOd;
                }
                string smotorPrismOs = "";
                if (diagTest.SmotorPrismOs != null) {
                    smotorPrismOs = diagTest.SmotorPrismOs;
                }
                string smotorDirectionOd = "";
                if (diagTest.SmotorDirectionOd != null) {
                    smotorDirectionOd = diagTest.SmotorDirectionOd;
                }
                string smotorDirectionOs = "";
                if (diagTest.SmotorDirectionOs != null) {
                    smotorDirectionOs = diagTest.SmotorDirectionOs;
                }
                string smotorComments = "";
                if (diagTest.SmotorComments != null) {
                    smotorComments = diagTest.SmotorComments;
                }
                string mBalanceHorizTypeScUpRtGaze = ""; 
                if (diagTest.MbalanceHorizTypeScUpRtGaze != null) {
                    mBalanceHorizTypeScUpRtGaze = diagTest.MbalanceHorizTypeScUpRtGaze;
                }
                string smotorHorizCcNear3Plus = "";
                if (diagTest.SmotorHorizCcNear3Plus != null) {
                    smotorHorizCcNear3Plus = diagTest.SmotorHorizCcNear3Plus;
                }
                string smotorHorizScNear3Plus = "";
                // no smotorHorizScNear3Plus
                string smotorHorizScNear = "";
                if (diagTest.SmotorHorizScNear != null) {
                    smotorHorizScNear = diagTest.SmotorHorizScNear;
                }
                string smotorHorizTypeScNear = "";
                if (diagTest.SmotorHorizTypeScNear != null) {
                    smotorHorizTypeScNear = diagTest.SmotorHorizTypeScNear;
                }
                string smotorVertCcNear3Plus = "";
                if (diagTest.SmotorVertCcNear3Plus != null) {
                    smotorVertCcNear3Plus = diagTest.SmotorVertCcNear3Plus;
                }
                string smotorVertTypeCcNear3Plus = "";
                if (diagTest.SmotorVertTypeCcNear3Plus != null) {
                    smotorVertTypeCcNear3Plus = diagTest.SmotorVertTypeCcNear3Plus;
                }
                #endregion diagTests

                var ehrOrig = eyeMDDbContext.EmrvisitDiagTests.FirstOrDefault(x => x.PtId == ptId);
                var ehrOrigVisit = eyeMDDbContext.EmrvisitDiagTests.FirstOrDefault(x => x.VisitId == visitId);

                if (ehrOrig != null && ehrOrigVisit != null && ehrOrig == ehrOrigVisit) {
                    ehrOrig.Dosdate = dosDate;
                    ehrOrig.GonioAngleDepthInOd = gonioAngleDepthInOd;
                    ehrOrig.GonioAngleDepthInOs = gonioAngleDepthInOs;
                    ehrOrig.GonioAngleDepthMedialOd = gonioAngleDepthMedialOd;
                    ehrOrig.GonioAngleDepthMedialOs = gonioAngleDepthMedialOs;
                    ehrOrig.GonioAngleDepthSuOd = gonioAngleDepthSuOd;
                    ehrOrig.GonioAngleDepthSuOs = gonioAngleDepthSuOs;
                    ehrOrig.GonioAngleDepthTemporalOd = gonioAngleDepthTemporalOd;
                    ehrOrig.GonioAngleDepthTemporalOs = gonioAngleDepthTemporalOs;
                    ehrOrig.GonioAngleStructureInOd = gonioAngleStructureInOd;
                    ehrOrig.GonioAngleStructureInOs = gonioAngleStructureInOs;
                    ehrOrig.GonioAngleStructureMedialOd = gonioAngleStructureMedialOd;
                    ehrOrig.GonioAngleStructureMedialOs = gonioAngleStructureMedialOs;
                    ehrOrig.GonioAngleStructureSuOd = gonioAngleStructureSuOd;
                    ehrOrig.GonioAngleStructureSuOs = gonioAngleStructureSuOs;
                    ehrOrig.GonioAngleStructureTemporalOd = gonioAngleStructureTemporalOd;
                    ehrOrig.GonioAngleStructureTemporalOs = gonioAngleStructureTemporalOs;
                    ehrOrig.GonioComments = gonioComments;
                    ehrOrig.GonioPigmentOd = gonioPigmentOd;
                    ehrOrig.GonioPigmentOs = gonioPigmentOs;
                    ehrOrig.MbalanceCcOrtho = mBalanceCCOrtho;
                    ehrOrig.MbalanceHorizCcUpGaze = mBalanceHorizCcUpGaze;
                    ehrOrig.MbalanceHorizTypeCcUpGaze = mBalanceHorizTypeCcUpGaze;
                    ehrOrig.MbalanceVertCcUpGaze = mBalanceVertCcUpGaze;
                    ehrOrig.MbalanceCcType = mBalanceCcType;
                    ehrOrig.MbalanceHorizCcDownGaze = mBalanceHorizCcDownGaze;
                    ehrOrig.MbalanceHorizCcDownLtGaze = mBalanceHorizCcDownLtGaze;
                    ehrOrig.MbalanceHorizCcDownRtGaze = mBalanceHorizCcDownRtGaze;
                    ehrOrig.MbalanceHorizCcLtGaze = mBalanceHorizCcLtGaze;
                    ehrOrig.MbalanceHorizCcRtGaze = mBalanceHorizCcRtGaze;
                    ehrOrig.MbalanceHorizTypeCcDownGaze = mBalanceHorizTypeCcDownGaze;
                    ehrOrig.MbalanceHorizCcPriGaze = mBalanceHorizCcPriGaze;
                    ehrOrig.MbalanceHorizCcUpLtGaze = mBalanceHorizCcUpLtGaze;
                    ehrOrig.MbalanceHorizCcUpRtGaze = mBalanceHorizCcUpRtGaze;
                    ehrOrig.MbalanceHorizScDownGaze = mBalanceHorizScDownGaze;
                    ehrOrig.MbalanceHorizScDownLtGaze = mBalanceHorizScDownLtGaze;
                    ehrOrig.MbalanceHorizScDownRtGaze = mBalanceHorizScDownRtGaze;
                    ehrOrig.MbalanceHorizScLtGaze = mBalanceHorizScLtGaze;
                    ehrOrig.MbalanceHorizScPriGaze = mBalanceHorizScPriGaze;
                    ehrOrig.MbalanceHorizScRtGaze = mBalanceHorizScRtGaze;
                    ehrOrig.MbalanceHorizScUpGaze = mBalanceHorizScUpGaze;
                    ehrOrig.MbalanceHorizScUpLtGaze = mBalanceHorizScUpLtGaze;
                    ehrOrig.MbalanceHorizScUpRtGaze = mbalanceHorizScUpRtGaze;
                    ehrOrig.MbalanceHorizTypeCcDownLtGaze = mBalanceHorizTypeCcDownLtGaze;
                    ehrOrig.MbalanceHorizTypeCcDownRtGaze = mBalanceHorizTypeCcDownRtGaze;
                    ehrOrig.MbalanceHorizTypeCcLtGaze = mBalanceHorizTypeCcLtGaze;
                    ehrOrig.MbalanceHorizTypeCcPriGaze = mBalanceHorizTypeCcPriGaze;
                    ehrOrig.MbalanceHorizTypeCcRtGaze = mBalanceHorizTypeCcRtGaze;
                    ehrOrig.MbalanceHorizTypeCcUpLtGaze = mBalanceHorizTypeCcUpLtGaze;
                    ehrOrig.MbalanceHorizTypeCcUpRtGaze = mBalanceHorizTypeCcUpRtGaze;
                    ehrOrig.MbalanceHorizTypeScDownGaze = mBalanceHorizTypeScDownGaze;
                    ehrOrig.MbalanceHorizTypeScDownLtGaze = mBalanceHorizTypeScDownLtGaze;
                    ehrOrig.MbalanceHorizTypeScDownRtGaze = mBalanceHorizTypeScDownRtGaze;
                    ehrOrig.MbalanceHorizTypeScLtGaze = mBalanceHorizTypeScLtGaze;
                    ehrOrig.MbalanceHorizTypeScPriGaze = mBalanceHorizTypeScPriGaze;
                    ehrOrig.MbalanceHorizTypeScRtGaze = mBalanceHorizTypeScRtGaze;
                    ehrOrig.MbalanceHorizTypeScUpGaze = mBalanceHorizTypeScUpGaze;
                    ehrOrig.MbalanceHorizTypeScUpLtGaze = mBalanceHorizTypeScUpLtGaze;
                    ehrOrig.MbalanceHorizTypeScUpRtGaze = mBalanceHorizTypeScUpRtGaze;
                    ehrOrig.MbalanceMethod = mBalanceMethod;
                    ehrOrig.MbalanceMethodCc = mbalanceMethodCc;
                    ehrOrig.MbalanceMethodSc = mbalanceMethodSc;
                    ehrOrig.MbalanceScOrtho = mBalanceScOrtho;
                    ehrOrig.MbalanceScType = mBalanceScType;
                    ehrOrig.MbalanceVertCcDownGaze = mBalanceVertCcDownGaze;
                    ehrOrig.MbalanceVertCcDownLtGaze = mBalanceVertCcDownLtGaze;
                    ehrOrig.MbalanceVertCcDownRtGaze = mBalanceVertCcDownRtGaze;
                    ehrOrig.MbalanceVertCcLtGaze = mBalanceVertCcLtGaze;
                    ehrOrig.MbalanceVertCcPriGaze = mBalanceVertCcPriGaze;
                    ehrOrig.MbalanceVertCcRtGaze = mBalanceVertCcRtGaze;
                    ehrOrig.MbalanceVertCcUpLtGaze = mBalanceVertCcUpLtGaze;
                    ehrOrig.MbalanceVertCcUpRtGaze = mBalanceVertCcUpRtGaze;
                    ehrOrig.MbalanceVertScDownGaze = mBalanceVertScDownGaze;
                    ehrOrig.MbalanceVertScDownLtGaze = mBalanceVertScDownLtGaze;
                    ehrOrig.MbalanceVertScDownRtGaze = mBalanceVertScDownRtGaze;
                    ehrOrig.MbalanceVertScLtGaze = mBalanceVertScLtGaze;
                    ehrOrig.MbalanceVertScPriGaze = mBalanceVertScPriGaze;
                    ehrOrig.MbalanceVertScRtGaze = mBalanceVertScRtGaze;
                    ehrOrig.MbalanceVertScUpGaze = mBalanceVertScUpGaze;
                    ehrOrig.MbalanceVertScUpLtGaze = mBalanceVertScUpLtGaze;
                    ehrOrig.MbalanceVertScUpRtGaze = mBalanceVertScUpRtGaze;
                    ehrOrig.MbalanceVertTypeCcDownGaze = mBalanceVertTypeCcDownGaze;
                    ehrOrig.MbalanceVertTypeCcDownLtGaze = mBalanceVertTypeCcDownLtGaze;
                    ehrOrig.MbalanceVertTypeCcDownRtGaze = mBalanceVertTypeCcDownRtGaze;
                    ehrOrig.MbalanceVertTypeCcLtGaze = mBalanceVertTypeCcLtGaze;
                    ehrOrig.MbalanceVertTypeCcPriGaze = mBalanceVertTypeCcPriGaze;
                    ehrOrig.MbalanceVertTypeCcRtGaze = mBalanceVertTypeCcRtGaze;
                    ehrOrig.MbalanceVertTypeCcUpGaze = mBalanceVertTypeCcUpGaze;
                    ehrOrig.MbalanceVertTypeCcUpLtGaze = mBalanceVertTypeCcUpLtGaze;
                    ehrOrig.MbalanceVertTypeCcUpRtGaze = mBalanceVertTypeCcUpRtGaze;
                    ehrOrig.MbalanceVertTypeScDownGaze = mBalanceVertTypeScDownGaze;
                    ehrOrig.MbalanceVertTypeScDownLtGaze = mBalanceVertTypeScDownLtGaze;
                    ehrOrig.MbalanceVertTypeScDownRtGaze = mBalanceVertTypeScDownRtGaze;
                    ehrOrig.MbalanceVertTypeScLtGaze = mBalanceVertTypeScLtGaze;
                    ehrOrig.MbalanceVertTypeScPriGaze = mBalanceVertTypeScPriGaze;
                    ehrOrig.MbalanceVertTypeScRtGaze = mBalanceVertTypeScRtGaze;
                    ehrOrig.MbalanceVertTypeScUpGaze = mBalanceVertTypeScUpGaze;
                    ehrOrig.MbalanceVertTypeScUpLtGaze = mBalanceVertTypeScUpLtGaze;
                    ehrOrig.MbalanceVertTypeScUpRtGaze = mBalanceVertTypeScUpRtGaze;
                    ehrOrig.SmotorAbute = smotorAbute;
                    ehrOrig.SmotorAvpattern = smotorAvPattern;
                    ehrOrig.SmotorColorVisionOd = smotorColorVisionOd;
                    ehrOrig.SmotorColorVisionOs = smotorColorVisionOs;
                    ehrOrig.SmotorColorVisionType = smotorColorVisionType;
                    ehrOrig.SmotorComments = smotorComments;
                    ehrOrig.SmotorDirectionOd = smotorDirectionOd;
                    ehrOrig.SmotorDirectionOs = smotorDirectionOs;
                    ehrOrig.SmotorDistStereo = smotorDistStereo;
                    ehrOrig.SmotorDistVectograph = smotorDistVectograph;
                    ehrOrig.SmotorDmadRodOd = smotorDMadRodOd;
                    ehrOrig.SmotorDmadRodOs = smotorDMadRodOs;
                    ehrOrig.SmotorDmadRodTorsionOd = smotorDMadRodTorsionOd;
                    ehrOrig.SmotorDmadRodTorsionOs = smotorMadRodTorsionOs;
                    ehrOrig.SmotorFixPrefDist = smotorFixPrefDist;
                    ehrOrig.SmotorFixPrefNear = smotorFixPrefNear;
                    ehrOrig.SmotorFrisby = smotorFrisby;
                    ehrOrig.SmotorHorizCcDist = smotorHorizCcDist;
                    ehrOrig.SmotorHorizCcNear = smotorHorizCcNear;
                    ehrOrig.SmotorHorizCcNear3Plus = smotorHorizCcNear3Plus;
                    ehrOrig.SmotorHorizScDist = smotorHorizScDist;
                    ehrOrig.SmotorHorizScNear = smotorHorizScNear;
                    ehrOrig.SmotorHorizTypeCcDist = smotorHorizTypeCcDist;
                    ehrOrig.SmotorHorizTypeCcNear = smotorHorizTypeCcNear;
                    ehrOrig.SmotorHorizTypeCcNear3Plus = smotorHorizScNear3Plus;
                    ehrOrig.SmotorHorizTypeScDist = smotorHorizTypeScDist;
                    ehrOrig.SmotorHorizTypeScNear = smotorHorizTypeScNear;
                    ehrOrig.SmotorHorizVergBiBreak = smotorHorizVergBiBreak;
                    ehrOrig.SmotorHorizVergBiRecover = smotorHorizVergBiRecover;
                    ehrOrig.SmotorHorizVergBoBreak = smotorHorizVergBoBreak;
                    ehrOrig.SmotorHorizVergBoRecover = smotorHorizVergBoRecover;
                    ehrOrig.SmotorHtLtHorizCc = smotorHtLtHorizCc;
                    ehrOrig.SmotorHtLtHorizSc = smotorHtLtHorizSc;
                    ehrOrig.SmotorHtLtHorizTypeCc = smotorHtLtHorizTypeCc;
                    ehrOrig.SmotorHtLtHorizTypeSc = smotorHtLtHorizTypeSc;
                    ehrOrig.SmotorHtLtVertCc = smotorHtLtVertCc;
                    ehrOrig.SmotorHtLtVertSc = smotorHtLtVertSc;
                    ehrOrig.SmotorHtLtVertTypeCc = smotorHtLtVertTypeCc;
                    ehrOrig.SmotorHtLtVertTypeSc = smotorHtLtVertTypeSc;
                    ehrOrig.SmotorHtRtHorizCc = smotorHtRtHorizCc;
                    ehrOrig.SmotorHtRtHorizSc = smotorHtRtHorizSc;
                    ehrOrig.SmotorHtRtHorizTypeCc = smotorHtRtHorizTypeCc;
                    ehrOrig.SmotorHtRtHorizTypeSc = smotorHtRtHorizTypeSc;
                    ehrOrig.SmotorHtRtVertCc = smotorHtRtVertCc;
                    ehrOrig.SmotorHtRtVertSc = smotorHtRtVertSc;
                    ehrOrig.SmotorHtRtVertTypeCc = smotorHtRtVertCc;
                    ehrOrig.SmotorHtRtVertTypeSc = smotorHtRtVertTypeSc;
                    ehrOrig.SmotorLang = smotorLang;
                    ehrOrig.SmotorNpc = smotorNPC;
                    ehrOrig.SmotorNystagmus = smotorNystagmus;
                    ehrOrig.SmotorPrismOd = smotorPrismOd;
                    ehrOrig.SmotorPrismOs = smotorPrismOs;
                    ehrOrig.SmotorRandotCircles = smotorRandotCircles;
                    ehrOrig.SmotorTitmusStereoAnimals = smotorTitmusStereoAnimals;
                    ehrOrig.SmotorTitmusStereoCircles = smotorTitmusStereoCircles;
                    ehrOrig.SmotorTitmusStereoFly = smotorTitmusStereoFly;
                    ehrOrig.SmotorVertCcDist = smotorVertCcDist;
                    ehrOrig.SmotorVertCcNear = smotorVertCcNear;
                    ehrOrig.SmotorVertCcNear3Plus = smotorVertCcNear3Plus;
                    ehrOrig.SmotorVertScDist = smotorVertScDist;
                    ehrOrig.SmotorVertScNear = smotorVertScNear;
                    ehrOrig.SmotorVertTypeCcDist = smotorVertTypeCcDist;
                    ehrOrig.SmotorVertTypeCcNear = smotorVertTypeCcNear;
                    ehrOrig.SmotorVertTypeCcNear3Plus = smotorVertTypeCcNear3Plus;
                    ehrOrig.SmotorVertTypeScDist = smotorVertTypeScDist;
                    ehrOrig.SmotorVertTypeScNear = smotorVertTypeScNear;
                    ehrOrig.SmotorVertVergBdBreak = smotorVertVergBdBreak;
                    ehrOrig.SmotorVertVergBdRecover = smotorVertVergBdRecover;
                    ehrOrig.SmotorVertVergBuBreak = smotorVertVergBuBreak;
                    ehrOrig.SmotorVertVergBuRecover = smotorVertVergBuRecover;
                    ehrOrig.SmotorWorth4DotDist = smotorWorth4DotDist;
                    ehrOrig.UpsizeTs = null;
                    ehrOrig.SmotorWorth4DotNear = smotorWorth4DotNear;
                    ehrOrig.VisitDiagTestId = diagTest.Id;
                    eyeMDDbContext.SaveChanges();
                    return;
                }


                var newDiagTest = new Brady_s_Conversion_Program.ModelsB.EmrvisitDiagTest {
                    VisitId = visitId,
                    PtId = ptId,
                    Dosdate = dosDate,
                    GonioAngleDepthInOd = gonioAngleDepthInOd,
                    GonioAngleDepthInOs = gonioAngleDepthInOs,
                    GonioAngleDepthMedialOd = gonioAngleDepthMedialOd,
                    GonioAngleDepthMedialOs = gonioAngleDepthMedialOs,
                    GonioAngleDepthSuOd = gonioAngleDepthSuOd,
                    GonioAngleDepthSuOs = gonioAngleDepthSuOs,
                    GonioAngleDepthTemporalOd = gonioAngleDepthTemporalOd,
                    GonioAngleDepthTemporalOs = gonioAngleDepthTemporalOs,
                    GonioAngleStructureInOd = gonioAngleStructureInOd,
                    GonioAngleStructureInOs = gonioAngleStructureInOs,
                    GonioAngleStructureMedialOd = gonioAngleStructureMedialOd,
                    GonioAngleStructureMedialOs = gonioAngleStructureMedialOs,
                    GonioAngleStructureSuOd = gonioAngleStructureSuOd,
                    GonioAngleStructureSuOs = gonioAngleStructureSuOs,
                    GonioAngleStructureTemporalOd = gonioAngleStructureTemporalOd,
                    GonioAngleStructureTemporalOs = gonioAngleStructureTemporalOs,
                    GonioComments = gonioComments,
                    GonioPigmentOd = gonioPigmentOd,
                    GonioPigmentOs = gonioPigmentOs,
                    MbalanceCcOrtho = mBalanceCCOrtho,
                    MbalanceHorizCcUpGaze = mBalanceHorizCcUpGaze,
                    MbalanceHorizTypeCcUpGaze = mBalanceHorizTypeCcUpGaze,
                    MbalanceVertCcUpGaze = mBalanceVertCcUpGaze,
                    MbalanceCcType = mBalanceCcType,
                    MbalanceHorizCcDownGaze = mBalanceHorizCcDownGaze,
                    MbalanceHorizCcDownLtGaze = mBalanceHorizCcDownLtGaze,
                    MbalanceHorizCcDownRtGaze = mBalanceHorizCcDownRtGaze,
                    MbalanceHorizCcLtGaze = mBalanceHorizCcLtGaze,
                    MbalanceHorizCcRtGaze = mBalanceHorizCcRtGaze,
                    MbalanceHorizTypeCcDownGaze = mBalanceHorizTypeCcDownGaze,
                    MbalanceHorizCcPriGaze = mBalanceHorizCcPriGaze,
                    MbalanceHorizCcUpLtGaze = mBalanceHorizCcUpLtGaze,
                    MbalanceHorizCcUpRtGaze = mBalanceHorizCcUpRtGaze,
                    MbalanceHorizScDownGaze = mBalanceHorizScDownGaze,
                    MbalanceHorizScDownLtGaze = mBalanceHorizScDownLtGaze,
                    MbalanceHorizScDownRtGaze = mBalanceHorizScDownRtGaze,
                    MbalanceHorizScLtGaze = mBalanceHorizScLtGaze,
                    MbalanceHorizScPriGaze = mBalanceHorizScPriGaze,
                    MbalanceHorizScRtGaze = mBalanceHorizScRtGaze,
                    MbalanceHorizScUpGaze = mBalanceHorizScUpGaze,
                    MbalanceHorizScUpLtGaze = mBalanceHorizScUpLtGaze,
                    MbalanceHorizScUpRtGaze = mbalanceHorizScUpRtGaze,
                    MbalanceHorizTypeCcDownLtGaze = mBalanceHorizTypeCcDownLtGaze,
                    MbalanceHorizTypeCcDownRtGaze = mBalanceHorizTypeCcDownRtGaze,
                    MbalanceHorizTypeCcLtGaze = mBalanceHorizTypeCcLtGaze,
                    MbalanceHorizTypeCcPriGaze = mBalanceHorizTypeCcPriGaze,
                    MbalanceHorizTypeCcRtGaze = mBalanceHorizTypeCcRtGaze,
                    MbalanceHorizTypeCcUpLtGaze = mBalanceHorizTypeCcUpLtGaze,
                    MbalanceHorizTypeCcUpRtGaze = mBalanceHorizTypeCcUpRtGaze,
                    MbalanceHorizTypeScDownGaze = mBalanceHorizTypeScDownGaze,
                    MbalanceHorizTypeScDownLtGaze = mBalanceHorizTypeScDownLtGaze,
                    MbalanceHorizTypeScDownRtGaze = mBalanceHorizTypeScDownRtGaze,
                    MbalanceHorizTypeScLtGaze = mBalanceHorizTypeScLtGaze,
                    MbalanceHorizTypeScPriGaze = mBalanceHorizTypeScPriGaze,
                    MbalanceHorizTypeScRtGaze = mBalanceHorizTypeScRtGaze,
                    MbalanceHorizTypeScUpGaze = mBalanceHorizTypeScUpGaze,
                    MbalanceHorizTypeScUpLtGaze = mBalanceHorizTypeScUpLtGaze,
                    MbalanceHorizTypeScUpRtGaze = mBalanceHorizTypeScUpRtGaze,
                    MbalanceMethod = mBalanceMethod,
                    MbalanceMethodCc = mbalanceMethodCc,
                    MbalanceMethodSc = mbalanceMethodSc,
                    MbalanceScOrtho = mBalanceScOrtho,
                    MbalanceScType = mBalanceScType,
                    MbalanceVertCcDownGaze = mBalanceVertCcDownGaze,
                    MbalanceVertCcDownLtGaze = mBalanceVertCcDownLtGaze,
                    MbalanceVertCcDownRtGaze = mBalanceVertCcDownRtGaze,
                    MbalanceVertCcLtGaze = mBalanceVertCcLtGaze,
                    MbalanceVertCcPriGaze = mBalanceVertCcPriGaze,
                    MbalanceVertCcRtGaze = mBalanceVertCcRtGaze,
                    MbalanceVertCcUpLtGaze = mBalanceVertCcUpLtGaze,
                    MbalanceVertCcUpRtGaze = mBalanceVertCcUpRtGaze,
                    MbalanceVertScDownGaze = mBalanceVertScDownGaze,
                    MbalanceVertScDownLtGaze = mBalanceVertScDownLtGaze,
                    MbalanceVertScDownRtGaze = mBalanceVertScDownRtGaze,
                    MbalanceVertScLtGaze = mBalanceVertScLtGaze,
                    MbalanceVertScPriGaze = mBalanceVertScPriGaze,
                    MbalanceVertScRtGaze = mBalanceVertScRtGaze,
                    MbalanceVertScUpGaze = mBalanceVertScUpGaze,
                    MbalanceVertScUpLtGaze = mBalanceVertScUpLtGaze,
                    MbalanceVertScUpRtGaze = mBalanceVertScUpRtGaze,
                    MbalanceVertTypeCcDownGaze = mBalanceVertTypeCcDownGaze,
                    MbalanceVertTypeCcDownLtGaze = mBalanceVertTypeCcDownLtGaze,
                    MbalanceVertTypeCcDownRtGaze = mBalanceVertTypeCcDownRtGaze,
                    MbalanceVertTypeCcLtGaze = mBalanceVertTypeCcLtGaze,
                    MbalanceVertTypeCcPriGaze = mBalanceVertTypeCcPriGaze,
                    MbalanceVertTypeCcRtGaze = mBalanceVertTypeCcRtGaze,
                    MbalanceVertTypeCcUpGaze = mBalanceVertTypeCcUpGaze,
                    MbalanceVertTypeCcUpLtGaze = mBalanceVertTypeCcUpLtGaze,
                    MbalanceVertTypeCcUpRtGaze = mBalanceVertTypeCcUpRtGaze,
                    MbalanceVertTypeScDownGaze = mBalanceVertTypeScDownGaze,
                    MbalanceVertTypeScDownLtGaze = mBalanceVertTypeScDownLtGaze,
                    MbalanceVertTypeScDownRtGaze = mBalanceVertTypeScDownRtGaze,
                    MbalanceVertTypeScLtGaze = mBalanceVertTypeScLtGaze,
                    MbalanceVertTypeScPriGaze = mBalanceVertTypeScPriGaze,
                    MbalanceVertTypeScRtGaze = mBalanceVertTypeScRtGaze,
                    MbalanceVertTypeScUpGaze = mBalanceVertTypeScUpGaze,
                    MbalanceVertTypeScUpLtGaze = mBalanceVertTypeScUpLtGaze,
                    MbalanceVertTypeScUpRtGaze = mBalanceVertTypeScUpRtGaze,
                    SmotorAbute = smotorAbute,
                    SmotorAvpattern = smotorAvPattern,
                    SmotorColorVisionOd = smotorColorVisionOd,
                    SmotorColorVisionOs = smotorColorVisionOs,
                    SmotorColorVisionType = smotorColorVisionType,
                    SmotorComments = smotorComments,
                    SmotorDirectionOd = smotorDirectionOd,
                    SmotorDirectionOs = smotorDirectionOs,
                    SmotorDistStereo = smotorDistStereo,
                    SmotorDistVectograph = smotorDistVectograph,
                    SmotorDmadRodOd = smotorDMadRodOd,
                    SmotorDmadRodOs = smotorDMadRodOs,
                    SmotorDmadRodTorsionOd = smotorDMadRodTorsionOd,
                    SmotorDmadRodTorsionOs = smotorMadRodTorsionOs,
                    SmotorFixPrefDist = smotorFixPrefDist,
                    SmotorFixPrefNear = smotorFixPrefNear,
                    SmotorFrisby = smotorFrisby,
                    SmotorHorizCcDist = smotorHorizCcDist,
                    SmotorHorizCcNear = smotorHorizCcNear,
                    SmotorHorizCcNear3Plus = smotorHorizCcNear3Plus,
                    SmotorHorizScDist = smotorHorizScDist,
                    SmotorHorizScNear = smotorHorizScNear,
                    SmotorHorizTypeCcDist = smotorHorizTypeCcDist,
                    SmotorHorizTypeCcNear = smotorHorizTypeCcNear,
                    SmotorHorizTypeCcNear3Plus = smotorHorizScNear3Plus,
                    SmotorHorizTypeScDist = smotorHorizTypeScDist,
                    SmotorHorizTypeScNear = smotorHorizTypeScNear,
                    SmotorHorizVergBiBreak = smotorHorizVergBiBreak,
                    SmotorHorizVergBiRecover = smotorHorizVergBiRecover,
                    SmotorHorizVergBoBreak = smotorHorizVergBoBreak,
                    SmotorHorizVergBoRecover = smotorHorizVergBoRecover,
                    SmotorHtLtHorizCc = smotorHtLtHorizCc,
                    SmotorHtLtHorizSc = smotorHtLtHorizSc,
                    SmotorHtLtHorizTypeCc = smotorHtLtHorizTypeCc,
                    SmotorHtLtHorizTypeSc = smotorHtLtHorizTypeSc,
                    SmotorHtLtVertCc = smotorHtLtVertCc,
                    SmotorHtLtVertSc = smotorHtLtVertSc,
                    SmotorHtLtVertTypeCc = smotorHtLtVertTypeCc,
                    SmotorHtLtVertTypeSc = smotorHtLtVertTypeSc,
                    SmotorHtRtHorizCc = smotorHtRtHorizCc,
                    SmotorHtRtHorizSc = smotorHtRtHorizSc,
                    SmotorHtRtHorizTypeCc = smotorHtRtHorizTypeCc,
                    SmotorHtRtHorizTypeSc = smotorHtRtHorizTypeSc,
                    SmotorHtRtVertCc = smotorHtRtVertCc,
                    SmotorHtRtVertSc = smotorHtRtVertSc,
                    SmotorHtRtVertTypeCc = smotorHtRtVertCc,
                    SmotorHtRtVertTypeSc = smotorHtRtVertTypeSc,
                    SmotorLang = smotorLang,
                    SmotorNpc = smotorNPC,
                    SmotorNystagmus = smotorNystagmus,
                    SmotorPrismOd = smotorPrismOd,
                    SmotorPrismOs = smotorPrismOs,
                    SmotorRandotCircles = smotorRandotCircles,
                    SmotorTitmusStereoAnimals = smotorTitmusStereoAnimals,
                    SmotorTitmusStereoCircles = smotorTitmusStereoCircles,
                    SmotorTitmusStereoFly = smotorTitmusStereoFly,
                    SmotorVertCcDist = smotorVertCcDist,
                    SmotorVertCcNear = smotorVertCcNear,
                    SmotorVertCcNear3Plus = smotorVertCcNear3Plus,
                    SmotorVertScDist = smotorVertScDist,
                    SmotorVertScNear = smotorVertScNear,
                    SmotorVertTypeCcDist = smotorVertTypeCcDist,
                    SmotorVertTypeCcNear = smotorVertTypeCcNear,
                    SmotorVertTypeCcNear3Plus = smotorVertTypeCcNear3Plus,
                    SmotorVertTypeScDist = smotorVertTypeScDist,
                    SmotorVertTypeScNear = smotorVertTypeScNear,
                    SmotorVertVergBdBreak = smotorVertVergBdBreak,
                    SmotorVertVergBdRecover = smotorVertVergBdRecover,
                    SmotorVertVergBuBreak = smotorVertVergBuBreak,
                    SmotorVertVergBuRecover = smotorVertVergBuRecover,
                    SmotorWorth4DotDist = smotorWorth4DotDist,
                    UpsizeTs = null,
                    SmotorWorth4DotNear = smotorWorth4DotNear,
                    VisitDiagTestId = diagTest.Id
                };
                eyeMDDbContext.EmrvisitDiagTests.Add(newDiagTest);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the diag test with ID: {diagTest.Id}. Error: {e.Message}");
            }
        }

        public static void ExamConditionsConvert(ModelsC.ExamCondition examCondition, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? visitId = null;
                if (examCondition.VisitId != null) {
                    if (int.TryParse(examCondition.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                int ptId = -1;
                if (examCondition.PtId != null) {
                    if (int.TryParse(examCondition.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                if (ptId == -1) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null && eyeMDVisit.PtId != null) {
                        ptId = (int)eyeMDVisit.PtId;
                    }
                    else {
                        logger.Log($"EHR: EHR PatientID not found for Exam Condition with ID: {examCondition.Id}");
                        return;
                    }
                }

                DateTime dosDate = DateTime.Parse("1/1/1900");
                if (examCondition.Dosdate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(examCondition.Dosdate, dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosDate = tempDateTime;
                    }
                }
                if (dosDate == DateTime.Parse("1/1/1900")) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null && eyeMDVisit.Dosdate != null) {
                        dosDate = (DateTime)eyeMDVisit.Dosdate;
                        if (dosDate == DateTime.Parse("1/1/1900")) {
                            logger.Log($"EHR: EHR DOSDate not found for Exam Condition with ID: {examCondition.Id}");
                            return;
                        }
                    }
                    else {
                        logger.Log($"EHR: EHR DOSDate not found for Exam Condition with ID: {examCondition.Id}");
                        return;
                    }
                }
                int? locationId = null;
                // no locationId, but this is used
                int? conditionId = null;
                // conditionID is always -888 or -999, dont know what they mean, dont know where this comes from
                // also have an unused [condition value] field in the source table
                string condition = "";
                if (examCondition.Condition != null) {
                    condition = examCondition.Condition;
                }
                string? eye = "";
                if (examCondition.Eye != null) {
                    if (examCondition.Eye == "R") {
                        eye = "OD";
                    } else if (examCondition.Eye == "L") {
                        eye = "OS";
                    } else {
                        eye = examCondition.Eye;
                    }
                }




                var newExamCondition = new Brady_s_Conversion_Program.ModelsB.EmrvisitExamCondition {
                    Snomed = null,
                    PtId = ptId,
                    VisitId = visitId,
                    Dosdate = dosDate,
                    Comment = examCondition.Comment,
                    Condition = condition,
                    Laterality = eye,
                    ConditionId = conditionId,
                    LocationId = locationId
                };
                eyeMDDbContext.EmrvisitExamConditions.Add(newExamCondition);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the exam condition with ID: {examCondition.Id}. Error: {e.Message}");
            }
        }

        public static void FamilyHistoriesConvert(ModelsC.FamilyHistory familyHistory, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? ptId = null;
                if (familyHistory.PtId != null) {
                    if (int.TryParse(familyHistory.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                int? visitId = null;
                if (familyHistory.VisitId != null) {
                    if (int.TryParse(familyHistory.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                if (ptId == null) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null && eyeMDVisit.PtId != null) {
                        ptId = (int)eyeMDVisit.PtId;
                    } else {
                        logger.Log($"EHR: EHR PatientID not found for Family History with ID: {familyHistory.Id}");
                    }
                }
                DateTime? dosDate = null;
                if (familyHistory.Dosdate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(familyHistory.Dosdate, dateFormats,
                                                                      CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosDate = tempDateTime;
                    }
                }
                string description = "";
                if (familyHistory.Description != null) {
                    description = familyHistory.Description;
                }
                string relation = "";
                if (familyHistory.Relation != null) {
                    relation = familyHistory.Relation;
                }
                string comments = "";
                if (familyHistory.Comments != null) {
                    comments = familyHistory.Comments;
                }
                string age = "";
                if (familyHistory.Age != null) {
                    age = familyHistory.Age;
                }
                string status = "";
                if (familyHistory.Status != null) {
                    status = familyHistory.Status;
                }
                string code = "";
                if (familyHistory.CodeIcd9 != null) {
                    code = familyHistory.CodeIcd9;
                }
                string codeIcd10 = "";
                if (familyHistory.CodeIcd10 != null) {
                    codeIcd10 = familyHistory.CodeIcd10;
                }
                string codeSnomed = "";
                if (familyHistory.CodeSnomed != null) {
                    codeSnomed = familyHistory.CodeSnomed;
                }



                var newFamilyHistory = new Brady_s_Conversion_Program.ModelsB.EmrvisitFamilyHistory {
                    PtId = ptId,
                    VisitId = visitId,
                    Dosdate = dosDate,
                    Description = description,
                    Relation = relation,
                    Comments = comments,
                    Age = age,
                    Status = status,
                    Code = code,
                    CodeIcd10 = codeIcd10,
                    CodeSnomed = codeSnomed
                };
                eyeMDDbContext.EmrvisitFamilyHistories.Add(newFamilyHistory);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the family history with ID: {familyHistory.Id}. Error: {e.Message}");
            }
        }

        public static void IopsConvert(ModelsC.Iop iop, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? ptId = null;
                if (iop.PtId != null) {
                    if (int.TryParse(iop.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                int? visitId = null;
                if (iop.VisitId != null) {
                    if (int.TryParse(iop.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                if (ptId == null) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null && eyeMDVisit.PtId != null) {
                        ptId = (int)eyeMDVisit.PtId;
                    } else {
                        logger.Log($"EHR: EHR PatientID not found for IOP with ID: {iop.Id}");
                    }
                }

                DateTime? dosDate = null;
                if (iop.Dosdate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(iop.Dosdate, dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosDate = tempDateTime;
                    }
                }
                string iopOd = "";
                if (iop.IopOd != null) {
                    iopOd = iop.IopOd;
                }
                string iopOs = "";
                if (iop.IopOs != null) {
                    iopOs = iop.IopOs;
                }
                string iopDeviceUsed = "";
                if (iop.IopdeviceUsed != null) {
                    iopDeviceUsed = iop.IopdeviceUsed;
                }
                DateTime? iopTimeTaken = null;
                if (iop.IoptimeTaken != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(iop.IoptimeTaken, dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        iopTimeTaken = tempDateTime;
                    }
                }
                string iopNotes = "";
                if (iop.Iopnotes != null) {
                    iopNotes = iop.Iopnotes;
                }
                string iopCcOd = "";
                if (iop.IopccOd != null) {
                    iopCcOd = iop.IopccOd;
                }
                string iopCcOs = "";
                if (iop.IopccOs != null) {
                    iopCcOs = iop.IopccOs;
                }
                decimal? cornealHysteresisOd = null;
                if (iop.CornealHysteresisOd != null) {
                    if (decimal.TryParse(iop.CornealHysteresisOd, out decimal locum)) {
                        cornealHysteresisOd = locum;
                    }
                }
                decimal? cornealHysteresisOs = null;
                if (iop.CornealHysteresisOs != null) {
                    if (decimal.TryParse(iop.CornealHysteresisOs, out decimal locum)) {
                        cornealHysteresisOs = locum;
                    }
                }
                


                var newIop = new Brady_s_Conversion_Program.ModelsB.EmrvisitIop {
                    PtId = ptId,
                    VisitId = visitId,
                    Dosdate = dosDate,
                    IopOd = iopOd,
                    IopOs = iopOs,
                    IopdeviceUsed = iopDeviceUsed,
                    IoptimeTaken = iopTimeTaken,
                    Iopnotes = iopNotes,
                    IopccOd = iopCcOd,
                    IopccOs = iopCcOs,
                    CornealHysteresisOd = cornealHysteresisOd,
                    CornealHysteresisOs = cornealHysteresisOs
                };
                eyeMDDbContext.EmrvisitIops.Add(newIop);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the iop with ID: {iop.Id}. Error: {e.Message}");
            }
        }

        public static void PatientDocumentsConvert(ModelsC.PatientDocument patientDocument, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                // var newPatientDocument = new Brady_s_Conversion_Program.ModelsB. {
                // data here
                //};
                // eyeMDDbContext.EmrpatientDocuments.Add(newPatientDocument);
                // cant find a document table in modelsB (EyeMD)
                // assuming this is a spare table, like patients and appointments

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the patient document with ID: {patientDocument.Id}. Error: {e.Message}");
            }
        }

        public static void PatientNotesConvert(ModelsC.PatientNote patientNote, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try { // assuming this is also spare, but will give it conversion functionality since it is small and easy, save for guid
                int? ptId = null;
                if (patientNote.PtId != null) {
                    if (int.TryParse(patientNote.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                int? visitId = null;
                if (patientNote.VisitId != null) {
                    if (int.TryParse(patientNote.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }

                string notes = "";
                if (patientNote.Notes != null) {
                    notes = patientNote.Notes;
                }
                DateTime? createdDate = null;
                if (patientNote.Created != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(patientNote.Created, dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        createdDate = tempDateTime;
                    }
                }
                int? empId = null;
                if (patientNote.EmpId != null) {
                    if (int.TryParse(patientNote.EmpId, out int locum)) {
                        empId = locum;
                    }
                }
                short? showInVisitSummary = null;
                // no showInVisitSummary in source table
                string guid = "";
                // no guid in source table

                // there is no showInVisitSummary in the source table, and there is no visit id in the eyemd table



                var newPatientNote = new Brady_s_Conversion_Program.ModelsB.EmrptNote {
                    PtId = ptId,
                    Notes = notes,
                    CreatedDate = createdDate,
                    EmpId = empId,
                    ShowInVisitSummary = showInVisitSummary,
                    InsertGuid = guid
                };
                eyeMDDbContext.EmrptNotes.Add(newPatientNote);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the patient note with ID: {patientNote.Id}. Error: {e.Message}");
            }
        }

        public static void PlanNarrativesConvert(ModelsC.PlanNarrative planNarrative, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int ptId = -1;
                if (planNarrative.PtId != null) {
                    if (int.TryParse(planNarrative.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                int? visitId = null;
                if (planNarrative.VisitId != null) {
                    if (int.TryParse(planNarrative.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                if (ptId == -1) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null && eyeMDVisit.PtId != null) {
                        ptId = (int)eyeMDVisit.PtId;
                    } else {
                        logger.Log($"EHR: EHR PatientID not found for Plan Narrative with ID: {planNarrative.Id}");
                        return;
                    }
                }

                DateTime? dosDate = null;
                if (planNarrative.Dosdate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(planNarrative.Dosdate, dateFormats,
                                                                      CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosDate = tempDateTime;
                    }
                }
                int? visitDoctorId = null;
                if (planNarrative.VisitDoctorId != null) {
                    if (int.TryParse(planNarrative.VisitDoctorId, out int locum)) {
                        visitDoctorId = locum;
                    }
                }
                string snomedCode = "";
                if (planNarrative.Snomedcode != null) {
                    snomedCode = planNarrative.Snomedcode;
                }
                int? visitDiagCodePoolId = null;
                if (planNarrative.VisitDiagCodePoolId != null) {
                    if (int.TryParse(planNarrative.VisitDiagCodePoolId, out int locum)) {
                        visitDiagCodePoolId = locum;
                    }
                }
                string ICD10Code = "";
                if (planNarrative.Icd10code != null) {
                    ICD10Code = planNarrative.Icd10code;
                }
                string ICD9Code = "";
                if (planNarrative.Icd9code != null) {
                    ICD9Code = planNarrative.Icd9code;
                }
                string narrativeHeader = "";
                if (planNarrative.NarrativeHeader != null) {
                    narrativeHeader = planNarrative.NarrativeHeader;
                }
                string narrativeText = "";
                if (planNarrative.NarrativeText != null) {
                    narrativeText = planNarrative.NarrativeText;
                }
                string narrativeType = "";
                if (planNarrative.NarrativeType != null) {
                    narrativeType = planNarrative.NarrativeType;
                }
                int displayOrder = -1;
                if (planNarrative.DisplayOrder != null) {
                    if (int.TryParse(planNarrative.DisplayOrder, out int locum)) {
                        displayOrder = locum;
                    }
                }
                string insertGUID = Guid.NewGuid().ToString();
                // no insertGUID in source table



                var newPlanNarrative = new Brady_s_Conversion_Program.ModelsB.EmrvisitPlanNarrative {
                    PtId = ptId,
                    VisitId = visitId,
                    Dosdate = dosDate,
                    VisitDoctorId = visitDoctorId,
                    Snomedcode = snomedCode,
                    VisitDiagCodePoolId = visitDiagCodePoolId,
                    Icd10code = ICD10Code,
                    Icd9code = ICD9Code,
                    NarrativeHeader = narrativeHeader,
                    NarrativeText = narrativeText,
                    NarrativeType = narrativeType,
                    DisplayOrder = displayOrder,
                    InsertGuid = insertGUID
                };
                eyeMDDbContext.EmrvisitPlanNarratives.Add(newPlanNarrative);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the plan narrative with ID: {planNarrative.Id}. Error: {e.Message}");
            }
        }

        public static void ProcDiagPoolsConvert(ModelsC.ProcDiagPool procDiagPool, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? ptId = null;
                if (procDiagPool.PtId != null) {
                    if (int.TryParse(procDiagPool.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                int? visitId = null;
                if (procDiagPool.VisitId != null) {
                    if (int.TryParse(procDiagPool.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                if (ptId == null) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null && eyeMDVisit.PtId != null) {
                        ptId = (int)eyeMDVisit.PtId;
                    } else {
                        logger.Log($"EHR: EHR PatientID not found for Proc Diag Pool with ID: {procDiagPool.Id}");
                    }
                }

                DateTime? dosDate = null;
                if (procDiagPool.Dosdate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(procDiagPool.Dosdate, dateFormats,
                                                                      CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosDate = tempDateTime;
                    }
                }
                int? controlId = null;
                // no controlId in source table
                int? visitProcCodePoolId = null;
                if (procDiagPool.VisitProcCodePoolId != null) {
                    if (int.TryParse(procDiagPool.VisitProcCodePoolId, out int locum)) {
                        visitProcCodePoolId = locum;
                    }
                }
                int? visitDiagCodePoolId = null;
                if (procDiagPool.VisitDiagCodePoolId != null) {
                    if (int.TryParse(procDiagPool.VisitDiagCodePoolId, out int locum)) {
                        visitDiagCodePoolId = locum;
                    }
                }
                int? requestedProcId = null;
                if (procDiagPool.RequestedProcedureId != null) {
                    if (int.TryParse(procDiagPool.RequestedProcedureId, out int locum)) {
                        requestedProcId = locum;
                    }
                }
                string insertGUID = Guid.NewGuid().ToString();
                // no insertGUID in source table


                var newProcDiagPool = new Brady_s_Conversion_Program.ModelsB.EmrvisitProcCodePoolDiag {
                    PtId = ptId,
                    VisitId = visitId,
                    Dosdate = dosDate,
                    ControlId = controlId,
                    VisitProcCodePoolId = visitProcCodePoolId,
                    VisitDiagCodePoolId = visitDiagCodePoolId,
                    RequestedProcedureId = requestedProcId,
                    InsertGuid = insertGUID
                };
                eyeMDDbContext.EmrvisitProcCodePoolDiags.Add(newProcDiagPool);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the proc diag pool with ID: {procDiagPool.Id}. Error: {e.Message}");
            }
        }

        public static void ProcPoolsConvert(ModelsC.ProcPool procPool, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? ptId = null;
                if (procPool.PtId != null) {
                    if (int.TryParse(procPool.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                int? visitId = null;
                if (procPool.VisitId != null) {
                    if (int.TryParse(procPool.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                if (ptId == null) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null && eyeMDVisit.PtId != null) {
                        ptId = (int)eyeMDVisit.PtId;
                    } else {
                        logger.Log($"EHR: EHR PatientID not found for Proc Pool with ID: {procPool.Id}");
                    }
                }

                DateTime? dosDate = null;
                if (procPool.Dosdate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(procPool.Dosdate, dateFormats,
                                                                                             CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosDate = tempDateTime;
                    }
                }
                int? controlId = null;
                // no controlId in source table
                string procText = "";
                if (procPool.ProcText != null) {
                    procText = procPool.ProcText;
                }
                string code = "";
                if (procPool.Code != null) {
                    code = procPool.Code;
                }
                string modifier = "";
                if (procPool.Modifier != null) {
                    modifier = procPool.Modifier;
                }
                string originalModifier = "";
                if (procPool.OriginalModifier != null) {
                    originalModifier = procPool.OriginalModifier;
                }
                string location = "";
                if (procPool.Location != null) {
                    location = procPool.Location;
                }
                string sourceField = "";
                if (procPool.SourceField != null) {
                    sourceField = procPool.SourceField;
                }
                short isBilled = -1;
                if (procPool.IsBilled != null) {
                    if (short.TryParse(procPool.IsBilled, out short locum)) {
                        isBilled = locum;
                    }
                }
                int? procLocationType = null;
                if (procPool.ProcLocationType != null) {
                    if (int.TryParse(procPool.ProcLocationType, out int locum)) {
                        procLocationType = locum;
                    }
                }
                short procDiagTestComponents = -1;
                if (procPool.ProcDiagTestComponents != null) {
                    if (short.TryParse(procPool.ProcDiagTestComponents, out short locum)) {
                        procDiagTestComponents = locum;
                    }
                }
                short? notPoRelated = null;
                if (procPool.NotPorelated != null) {
                    if (short.TryParse(procPool.NotPorelated, out short locum)) {
                        notPoRelated = locum;
                    }
                }
                int? procType = null;
                if (procPool.ProcType != null) {
                    if (int.TryParse(procPool.ProcType, out int locum)) {
                        procType = locum;
                    }
                }
                int? billMultiProcId = null;
                if (procPool.BillMultiProcId != null) {
                    if (int.TryParse(procPool.BillMultiProcId, out int locum)) {
                        billMultiProcId = locum;
                    }
                }
                int? billMultiProcControlId = null;
                if (procPool.BillMultiProcControlId != null) {
                    if (int.TryParse(procPool.BillMultiProcControlId, out int locum)) {
                        billMultiProcControlId = locum;
                    }
                }
                string additionalModifier = "";
                if (procPool.AdditionalModifier != null) {
                    additionalModifier = procPool.AdditionalModifier;
                }
                short? isQr = null;
                if (procPool.IsQr != null) {
                    if (short.TryParse(procPool.IsQr, out short locum)) {
                        isQr = locum;
                    }
                }
                string eyeMDQRNum = "";
                if (procPool.EyeMdqrnum != null) {
                    eyeMDQRNum = procPool.EyeMdqrnum;
                }
                string pqrsNum = "";
                if (procPool.Pqrsnum != null) {
                    pqrsNum = procPool.Pqrsnum;
                }
                string nqfNum = "";
                if (procPool.Nqfnum != null) {
                    nqfNum = procPool.Nqfnum;
                }
                int? numerator = null;
                if (procPool.Numerator != null) {
                    if (int.TryParse(procPool.Numerator, out int locum)) {
                        numerator = locum;
                    }
                }
                int? denominator = null;
                if (procPool.Denominator != null) {
                    if (int.TryParse(procPool.Denominator, out int locum)) {
                        denominator = locum;
                    }
                }
                short? isHidden = null;
                if (procPool.IsHidden != null) {
                    if (short.TryParse(procPool.IsHidden, out short locum)) {
                        isHidden = locum;
                    }
                }
                string qrComponent = "";
                if (procPool.Qrcomponent != null) {
                    qrComponent = procPool.Qrcomponent;
                }
                string insertGUID = Guid.NewGuid().ToString();
                // no insertGUID in source table
                int? units = null;
                if (procPool.Units != null) {
                    if (int.TryParse(procPool.Units, out int locum)) {
                        units = locum;
                    }
                }
                int? requestedProcedureId = null;
                if (procPool.RequestedProcedureId != null) {
                    if (int.TryParse(procPool.RequestedProcedureId, out int locum)) {
                        requestedProcedureId = locum;
                    }
                }
                short? sentInVisit = null;
                if (procPool.SentInVisit != null) {
                    if (short.TryParse(procPool.SentInVisit, out short locum)) {
                        sentInVisit = locum;
                    }
                }
                int? sourceRecordId = null;
                if (procPool.SourceRecordId != null) {
                    if (int.TryParse(procPool.SourceRecordId, out int locum)) {
                        sourceRecordId = locum;
                    }
                }
                int? initialPatientPopulation = null;
                if (procPool.InitialPatientPopulation != null) {
                    if (int.TryParse(procPool.InitialPatientPopulation, out int locum)) {
                        initialPatientPopulation = locum;
                    }
                }
                int? denominatorExclusion = null;
                if (procPool.DenominatorExclusion != null) {
                    if (int.TryParse(procPool.DenominatorExclusion, out int locum)) {
                        denominatorExclusion = locum;
                    }
                }
                int? denominatorException = null;
                if (procPool.DenominatorException != null) {
                    if (int.TryParse(procPool.DenominatorException, out int locum)) {
                        denominatorException = locum;
                    }
                }
                int billingOrder = -1;
                if (procPool.BillingOrder != null) {
                    if (int.TryParse(procPool.BillingOrder, out int locum)) {
                        billingOrder = locum;
                    }
                }



                var newProcPool = new Brady_s_Conversion_Program.ModelsB.EmrvisitProcCodePool {
                    Qrcomponent = qrComponent,
                    PtId = ptId,
                    VisitId = visitId,
                    Dosdate = dosDate,
                    ControlId = controlId,
                    ProcText = procText,
                    Code = code,
                    Modifier = modifier,
                    OriginalModifier = originalModifier,
                    Location = location,
                    SourceField = sourceField,
                    IsBilled = isBilled,
                    ProcLocationType = procLocationType,
                    ProcDiagTestComponents = procDiagTestComponents,
                    NotPorelated = notPoRelated,
                    ProcType = procType,
                    BillMultiProcId = billMultiProcId,
                    BillMultiProcControlId = billMultiProcControlId,
                    AdditionalModifier = additionalModifier,
                    IsQr = isQr,
                    EyeMdqrnum = eyeMDQRNum,
                    Pqrsnum = pqrsNum,
                    Nqfnum = nqfNum,
                    Numerator = numerator,
                    Denominator = denominator,
                    IsHidden = isHidden,
                    InsertGuid = insertGUID,
                    Units = units,
                    RequestedProcedureId = requestedProcedureId,
                    SentInVisit = sentInVisit,
                    SourceRecordId = sourceRecordId,
                    InitialPatientPopulation = initialPatientPopulation,
                    DenominatorExclusion = denominatorExclusion,
                    DenominatorException = denominatorException,
                    BillingOrder = billingOrder
                };
                eyeMDDbContext.EmrvisitProcCodePools.Add(newProcPool);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the proc pool with ID: {procPool.Id}. Error: {e.Message}");
            }
        }

        public static void RefractionsConvert(ModelsC.Refraction refraction, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int ptId = -1;
                if (refraction.PtId != null) {
                    if (int.TryParse(refraction.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                int? visitId = null;
                if (refraction.VisitId != null) {
                    if (int.TryParse(refraction.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                if (ptId == -1) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null && eyeMDVisit.PtId != null) {
                        ptId = (int)eyeMDVisit.PtId;
                    } else {
                        logger.Log($"EHR: EHR PatientID not found for Refraction with ID: {refraction.Id}");
                        return;
                    }
                }
                DateTime dosDate = DateTime.Parse("1/1/1900");
                if (refraction.Dosdate != null) {
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(refraction.Dosdate, dateFormats,
                                                                      CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosDate = tempDateTime;
                    }
                }
                string refractionClass = "";
                if (refraction.RefractionClass != null) {
                    refractionClass = refraction.RefractionClass;
                }
                string refractionType = "";
                if (refraction.RefractionType != null) {
                    refractionType = refraction.RefractionType;
                }
                string sphereOd = "";
                if (refraction.SphereOd != null) {
                    sphereOd = refraction.SphereOd;
                }
                string sphereOs = "";
                if (refraction.SphereOs != null) {
                    sphereOs = refraction.SphereOs;
                }
                string cylinderOd = "";
                if (refraction.CylinderOd != null) {
                    cylinderOd = refraction.CylinderOd;
                }
                string cylinderOs = "";
                if (refraction.CylinderOs != null) {
                    cylinderOs = refraction.CylinderOs;
                }
                string axisOd = "";
                if (refraction.AxisOd != null) {
                    axisOd = refraction.AxisOd;
                }
                string axisOs = "";
                if (refraction.AxisOs != null) {
                    axisOs = refraction.AxisOs;
                }
                string bifocalAddOd = "";
                if (refraction.BifocalAddOd != null) {
                    bifocalAddOd = refraction.BifocalAddOd;
                }
                string bifocalAddOs = "";
                if (refraction.BifocalAddOs != null) {
                    bifocalAddOs = refraction.BifocalAddOs;
                }
                string prismTypeOd = "";
                if (refraction.PrismTypeOd != null) {
                    prismTypeOd = refraction.PrismTypeOd;
                }
                string prismTypeOs = "";
                if (refraction.PrismTypeOs != null) {
                    prismTypeOs = refraction.PrismTypeOs;
                }
                string prism360Od = "";
                if (refraction.Prism360Od != null) {
                    prism360Od = refraction.Prism360Od;
                }
                string prism360Os = "";
                if (refraction.Prism360Os != null) {
                    prism360Os = refraction.Prism360Os;
                }
                string directionOd = "";
                if (refraction.DirectionOd != null) {
                    directionOd = refraction.DirectionOd;
                }
                string directionOs = "";
                if (refraction.DirectionOs != null) {
                    directionOs = refraction.DirectionOs;
                }
                string pdDistOd = "";
                if (refraction.PdDistOd != null) {
                    pdDistOd = refraction.PdDistOd;
                }
                string pdDistOs = "";
                if (refraction.PdDistOs != null) {
                    pdDistOs = refraction.PdDistOs;
                }
                string pdNearOd = "";
                if (refraction.PdNearOd != null) {
                    pdNearOd = refraction.PdNearOd;
                }
                string pdNearOs = "";
                if (refraction.PdNearOs != null) {
                    pdNearOs = refraction.PdNearOs;
                }
                string age = "";
                if (refraction.Age != null) {
                    age = refraction.Age;
                }
                string? vaDOd = "";
                if (refraction.VaDOs != null) {
                    vaDOd = refraction.VaDOd;
                }
                string vaDOs = "";
                if (refraction.VaDOs != null) {
                    vaDOs = refraction.VaDOs;
                }
                string vaDOu = "";
                if (refraction.VaDOu != null) {
                    vaDOu = refraction.VaDOu;
                }
                string vaNOd = "";
                if (refraction.VaNOd != null) {
                    vaNOd = refraction.VaNOd;
                }
                string vaNOs = "";
                if (refraction.VaNOs != null) {
                    vaNOs = refraction.VaNOs;
                }
                string vaNOu = "";
                if (refraction.VaNOu != null) {
                    vaNOu = refraction.VaNOu;
                }
                string vaIOd = "";
                if (refraction.VaIOd != null) {
                    vaIOd = refraction.VaIOd;
                }
                string vaIOs = "";
                if (refraction.VaIOs != null) {
                    vaIOs = refraction.VaIOs;
                }
                string vaIOu = "";
                if (refraction.VaIOu != null) {
                    vaIOu = refraction.VaIOu;
                }
                string expires = "";
                if (refraction.Expires != null) {
                    expires = refraction.Expires;
                }
                string remarks = "";
                if (refraction.Remarks != null) {
                    remarks = refraction.Remarks;
                }
                string insertGUID = Guid.NewGuid().ToString();
                // no insertGUID in source table
                bool printed = false;
                // no printed in source table
                bool sentToOptical = false;
                // no sentToOptical in source table
                string enteredBy = "";
                // no enteredBy in source table



                var newRefraction = new Brady_s_Conversion_Program.ModelsB.EmrvisitRefraction {
                    PtId = ptId,
                    VisitId = visitId,
                    Dosdate = dosDate,
                    RefractionClass = refractionClass,
                    RefractionType = refractionType,
                    SphereOd = sphereOd,
                    SphereOs = sphereOs,
                    CylinderOd = cylinderOd,
                    CylinderOs = cylinderOs,
                    AxisOd = axisOd,
                    AxisOs = axisOs,    
                    BifocalAddOd = bifocalAddOd,
                    BifocalAddOs = bifocalAddOs,
                    PrismTypeOd = prismTypeOd,
                    PrismTypeOs = prismTypeOs,
                    Prism360Od = prism360Od,
                    Prism360Os = prism360Os,
                    DirectionOd = directionOd,
                    DirectionOs = directionOs,
                    PdDistOd = pdDistOd,
                    PdDistOs = pdDistOs,
                    PdNearOd = pdNearOd,
                    PdNearOs = pdNearOs,
                    Age = age,
                    VaDOd = vaDOd,
                    VaDOs = vaDOs,
                    VaDOu = vaDOu,
                    VaNOd = vaNOd,
                    VaNOs = vaNOs,
                    VaNOu = vaNOu,
                    VaIOd = vaIOd,
                    VaIOs = vaIOs,
                    VaIOu = vaIOu,
                    Expires = expires,
                    Remarks = remarks,
                    InsertGuid = insertGUID,
                    Printed = printed,
                    SentToOptical = sentToOptical,
                    EnteredBy = enteredBy
                };
                eyeMDDbContext.EmrvisitRefractions.Add(newRefraction);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the refraction with ID: {refraction.Id}. Error: {e.Message}");
            }
        }

        public static void RosConvert(ModelsC.Ro ros, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                // seemingly no conversions necessary

                var newRos = new Brady_s_Conversion_Program.ModelsB.Emrrosdefault {
                    RosbloodCustomDesc1 = ros.RosbloodCustomDesc1,
                    RosbloodCustomDesc2 = ros.RosbloodCustomDesc2,
                    RoscardioCustomDesc1 = ros.RoscardioCustomDesc1,
                    RoscardioCustomDesc2 = ros.RoscardioCustomDesc2,
                    RosconsCustomDesc1 = ros.RosconsCustomDesc1,
                    RosconsCustomDesc2 = ros.RosconsCustomDesc2,
                    RosendoCustomDesc1 = ros.RosendoCustomDesc1,
                    RosendoCustomDesc2 = ros.RosendoCustomDesc2,
                    RosentcustomDesc1 = ros.RosentcustomDesc1,
                    RosentcustomDesc2 = ros.RosentcustomDesc2,
                    RoseyeCustomDesc1 = ros.RoseyeCustomDesc1,
                    RoseyeCustomDesc2 = ros.RoseyeCustomDesc2,
                    RoseyeCustomDesc3 = ros.RoseyeCustomDesc3,
                    RoseyeCustomDesc4 = ros.RoseyeCustomDesc4,
                    RosgasCustomDesc1 = ros.RosgasCustomDesc1,
                    RosgasCustomDesc2 = ros.RosgasCustomDesc2,
                    RosimmuCustomDesc1 = ros.RosimmuCustomDesc1,
                    RosimmuCustomDesc2 = ros.RosimmuCustomDesc2,
                    RosmusSkeCustomDesc1 = ros.RosmusSkeCustomDesc1,
                    RosmusSkeCustomDesc2 = ros.RosmusSkeCustomDesc2,
                    RosneuroCustomDesc1 = ros.RosneuroCustomDesc1,
                    RosneuroCustomDesc2 = ros.RosneuroCustomDesc2,
                    RospsycCustomDesc1 = ros.RospsycCustomDesc1,
                    RospsycCustomDesc2 = ros.RospsycCustomDesc2,
                    RosrespCustomDesc1 = ros.RosrespCustomDesc1,
                    RosrespCustomDesc2 = ros.RosrespCustomDesc2,
                    RosskinCustomDesc1 = ros.RosskinCustomDesc1,
                    RosskinCustomDesc2 = ros.RosskinCustomDesc2,
                    RosurinaryCustomDesc1 = ros.RosurinaryCustomDesc1,
                    RosurinaryCustomDesc2 = ros.RosurinaryCustomDesc2
                };
                eyeMDDbContext.Emrrosdefaults.Add(newRos);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the ros with ID: {ros.Id}. Error: {e.Message}");
            }
        }

        public static void RxConvert(ModelsC.RxMedication rx, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? ptId = null;
                if (rx.PtId != null) {
                    if (int.TryParse(rx.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                int? visitId = null;
                if (rx.VisitId != null) {
                    if (int.TryParse(rx.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                if (ptId == null) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null && eyeMDVisit.PtId != null) {
                        ptId = (int)eyeMDVisit.PtId;
                    } else {
                        logger.Log($"EHR: EHR PatientID not found for Rx with ID: {rx.Id}");
                    }
                }

                DateTime? dosDate = null;
                if (rx.Dosdate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(rx.Dosdate, dateFormats,
                                                                                             CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosDate = tempDateTime;
                    }
                }
                string medName = "";
                if (rx.MedName != null) {
                    medName = rx.MedName;
                }
                string medSig = "";
                if (rx.MedSig != null) {
                    medSig = rx.MedSig;
                }
                string medDisp = "";
                if (rx.MedDisp != null) {
                    medDisp = rx.MedDisp;
                }
                string medRefill = "";
                    
                int? medType = null;
                if (rx.MedType != null) {
                    if (int.TryParse(rx.MedType, out int locum)) {
                        medType = locum;
                    }
                }
                short brandMedOnly = -1;
                if (rx.BrandMedOnly != null) {
                    if (short.TryParse(rx.BrandMedOnly, out short locum)) {
                        brandMedOnly = locum;
                    }
                }
                short doNotPrintRx = -1;
                if (rx.DoNotPrintRx != null) {
                    if (short.TryParse(rx.DoNotPrintRx, out short locum)) {
                        doNotPrintRx = locum;
                    }
                }
                short sampleGiven = -1;
                if (rx.SampleGiven != null) {
                    if (short.TryParse(rx.SampleGiven, out short locum)) {
                        sampleGiven = locum;
                    }
                }
                string notes = "";
                if (rx.Notes != null) {
                    notes = rx.Notes;
                }
                string description = "";
                if (rx.Description != null) {
                    description = rx.Description;
                }
                int? medTableId = null;
                if (rx.MedTableId != null) {
                    if (int.TryParse(rx.MedTableId, out int locum)) {
                        medTableId = locum;
                    }
                }
                short? medDispType = null;
                if (rx.MedDispType != null) {
                    if (short.TryParse(rx.MedDispType, out short locum)) {
                        medDispType = locum;
                    }
                }
                string drugStrength = "";
                if (rx.DrugStrength != null) {
                    drugStrength = rx.DrugStrength;
                }
                string drugRoute = "";
                if (rx.DrugRoute != null) {
                    drugRoute = rx.DrugRoute;
                }
                string drugForm = "";
                if (rx.DrugForm != null) {
                    drugForm = rx.DrugForm;
                }
                string drugMappingId = "";
                if (rx.DrugMappingId != null) {
                    drugMappingId = rx.DrugMappingId;
                }
                string drugAltMappingId = "";
                if (rx.DrugAltMappingId != null) {
                    drugAltMappingId = rx.DrugAltMappingId;
                }
                string drugName = "";
                if (rx.DrugName != null) {
                    drugName = rx.DrugName;
                }
                string drugNameId = "";
                if (rx.DrugNameId != null) {
                    drugNameId = rx.DrugNameId;
                }
                string erxGUID = "";
                if (rx.ErxGuid != null) {
                    erxGUID = rx.ErxGuid;
                }
                short? erxPendingTransmit = null;
                if (rx.ErxPendingTransmit != null) {
                    if (short.TryParse(rx.ErxPendingTransmit, out short locum)) {
                        erxPendingTransmit = locum;
                    }
                }
                int? calledInLocationId = null;
                if (rx.CalledInLocationId != null) {
                    if (int.TryParse(rx.CalledInLocationId, out int locum)) {
                        calledInLocationId = locum;
                    }
                }
                int? calledInProviderEmpId = null;
                if (rx.CalledInProviderEmpId != null) {
                    if (int.TryParse(rx.CalledInProviderEmpId, out int locum)) {
                        calledInProviderEmpId = locum;
                    }
                }
                string medDispUnitType = "";
                if (rx.MedDispUnitType != null) {
                    medDispUnitType = rx.MedDispUnitType;
                }
                string rxcui = "";
                if (rx.Rxcui != null) {
                    rxcui = rx.Rxcui;
                }
                short? isRefill = null;
                if (rx.IsRefill != null) {
                    if (short.TryParse(rx.IsRefill, out short locum)) {
                        isRefill = locum;
                    }
                }
                string originalMedicationId = "";
                if (rx.OriginalMedicationId != null) {
                    originalMedicationId = rx.OriginalMedicationId;
                }
                string originalMedicationDate = "";
                if (rx.OriginalMedicationDate != null) {
                    originalMedicationDate = rx.OriginalMedicationDate;
                }
                short? sentViaErx = null;
                if (rx.SentViaErx != null) {
                    if (short.TryParse(rx.SentViaErx, out short locum)) {
                        sentViaErx = locum;
                    }
                }
                string snomed = "";
                if (rx.Snomed != null) {
                    snomed = rx.Snomed;
                }
                string drugFdaStatus = "";
                if (rx.DrugFdastatus != null) {
                    drugFdaStatus = rx.DrugFdastatus;
                }
                string drugDeaClass = "";
                if (rx.DrugDeaclass != null) {
                    drugDeaClass = rx.DrugDeaclass;
                }
                string rxRemarks = "";
                if (rx.RxRemarks != null) {
                    rxRemarks = rx.RxRemarks;
                }
                string insertGUID = Guid.NewGuid().ToString();
                // no insertGUID in source table
                int? recordedEmpRole = null;
                if (rx.RecordedEmpRole != null) {
                    if (int.TryParse(rx.RecordedEmpRole, out int locum)) {
                        recordedEmpRole = locum;
                    }
                }
                short? administeredMed = null;
                if (rx.AdministeredMed != null) {
                    if (short.TryParse(rx.AdministeredMed, out short locum)) {
                        administeredMed = locum;
                    }
                }
                short? formularyChecked = null;
                if (rx.FormularyChecked != null) {
                    if (short.TryParse(rx.FormularyChecked, out short locum)) {
                        formularyChecked = locum;
                    }
                }
                short? printedRx = null;
                if (rx.PrintedRx != null) {
                    if (short.TryParse(rx.PrintedRx, out short locum)) {
                        printedRx = locum;
                    }
                }
                bool doNotReconcile = false;
                if (rx.DoNotReconcile != null && rx.DoNotReconcile.ToLower() == "yes") {
                    doNotReconcile = true;
                }
                DateTime? rxStartDate = null;
                if (rx.RxStartDate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(rx.RxStartDate, dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        rxStartDate = tempDateTime;
                    }
                }
                DateTime? rxEndDate = null;
                if (rx.RxEndDate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(rx.RxEndDate, dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        rxEndDate = tempDateTime;
                    }
                }
                int? rxDurationDays = null;
                if (rx.RxDurationDays != null) {
                    if (int.TryParse(rx.RxDurationDays, out int locum)) {
                        rxDurationDays = locum;
                    }
                }
                DateTime? lastModified = null;
                if (rx.LastModified != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(rx.LastModified, dateFormats,
                                                                      CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        lastModified = tempDateTime;
                    }
                }
                int? visitDiagCodePoolId = null;
                if (rx.VisitDiagCodePoolId != null) {
                    if (int.TryParse(rx.VisitDiagCodePoolId, out int locum)) {
                        visitDiagCodePoolId = locum;
                    }
                }
                DateTime? created = null;
                if (rx.Created != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(rx.Created, dateFormats,
                                                                      CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        created = tempDateTime;
                    }
                }
                int? createdEmpId = null;
                if (rx.CreatedEmpId != null) {
                    if (int.TryParse(rx.CreatedEmpId, out int locum)) {
                        createdEmpId = locum;
                    }
                }
                int? lastModifiedEmpId = null;
                if (rx.LastModifiedEmpId != null) {
                    if (int.TryParse(rx.LastModifiedEmpId, out int locum)) {
                        lastModifiedEmpId = locum;
                    }
                }
                string erxStatus = "";
                if (rx.ErxStatus != null) {
                    erxStatus = rx.ErxStatus;
                }



                var newRx = new Brady_s_Conversion_Program.ModelsB.EmrvisitRxMedication {
                    PtId = ptId,
                    VisitId = visitId,
                    Dosdate = dosDate,
                    MedName = medName,
                    MedSig = medSig,
                    MedDisp = medDisp,
                    MedRefill = medRefill,
                    MedType = medType,
                    BrandMedOnly = brandMedOnly,
                    DoNotPrintRx = doNotPrintRx,
                    SampleGiven = sampleGiven,
                    Notes = notes,
                    Description = description,
                    MedTableId = medTableId,
                    MedDispType = medDispType,
                    DrugStrength = drugStrength,
                    DrugRoute = drugRoute,
                    DrugForm = drugForm,
                    DrugMappingId = drugMappingId,
                    DrugAltMappingId = drugAltMappingId,
                    DrugName = drugName,
                    DrugNameId = drugNameId,
                    ErxGuid = erxGUID,
                    ErxPendingTransmit = erxPendingTransmit,
                    CalledInLocationId = calledInLocationId,
                    CalledInProviderEmpId = calledInProviderEmpId,
                    MedDispUnitType = medDispUnitType,
                    Rxcui = rxcui,
                    IsRefill = isRefill,
                    OriginalMedicationId = originalMedicationId,
                    OriginalMedicationDate = originalMedicationDate,
                    SentViaErx = sentViaErx,
                    Snomed = snomed,
                    DrugFdastatus = drugFdaStatus,
                    DrugDeaclass = drugDeaClass,
                    RxRemarks = rxRemarks,
                    InsertGuid = insertGUID,
                    RecordedEmpRole = recordedEmpRole,
                    AdministeredMed = administeredMed,
                    FormularyChecked = formularyChecked,
                    PrintedRx = printedRx,
                    DoNotReconcile = doNotReconcile,
                    RxStartDate = rxStartDate,
                    RxEndDate = rxEndDate,
                    RxDurationDays = rxDurationDays,
                    LastModified = lastModified,
                    VisitDiagCodePoolId = visitDiagCodePoolId,
                    Created = created,
                    CreatedEmpId = createdEmpId,
                    LastModifiedEmpId = lastModifiedEmpId,
                    ErxStatus = erxStatus
                };
                eyeMDDbContext.EmrvisitRxMedications.Add(newRx);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the rx with ID: {rx.Id}. Error: {e.Message}");
            }
        }

        public static void SurgHistoriesConvert(ModelsC.SurgHistory surgHistory, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? ptId = null;
                if (surgHistory.PtId != null) {
                    if (int.TryParse(surgHistory.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                int? visitId = null;
                if (surgHistory.VisitId != null) {
                    if (int.TryParse(surgHistory.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                if (ptId == null) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null && eyeMDVisit.PtId != null) {
                        ptId = (int)eyeMDVisit.PtId;
                    } else {
                        logger.Log($"EHR: EHR PatientID not found for Surg History with ID: {surgHistory.Id}");
                    }
                }

                DateTime? visitDate = null;
                if (surgHistory.Dosdate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(surgHistory.Dosdate, dateFormats,
                                                                                                                    CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        visitDate = tempDateTime;
                    }
                }
                int? controlId = null;
                // no controlId in source table
                int? origVisitSurgicalHistoryId = null;
                if (surgHistory.OrigVisitSurgicalHistoryId != null) {
                    if (int.TryParse(surgHistory.OrigVisitSurgicalHistoryId, out int locum)) {
                        origVisitSurgicalHistoryId = locum;
                    }
                }
                DateTime? origVisitDate = null;
                if (surgHistory.OrigVisitDate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(surgHistory.OrigVisitDate, dateFormats,
                                                                                                                                           CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        origVisitDate = tempDateTime;
                    }
                }
                string description = "";
                if (surgHistory.Description != null) {
                    description = surgHistory.Description;
                }
                int? typeId = null; 
                if (surgHistory.TypeId != null) {
                    if (int.TryParse(surgHistory.TypeId, out int locum)) {
                        typeId = locum;
                    }
                }
                int? codeId = null;
                if (surgHistory.CodeId != null) {
                    if (int.TryParse(surgHistory.CodeId, out int locum)) {
                        codeId = locum;
                    }
                }
                string code = "";
                if (surgHistory.Code != null) {
                    code = surgHistory.Code;
                }
                string modifier = "";
                if (surgHistory.Modifier != null) {
                    modifier = surgHistory.Modifier;
                }
                string codeICD10 = "";
                if (surgHistory.CodeIcd10 != null) {
                    codeICD10 = surgHistory.CodeIcd10;
                }
                string codeSnomed = "";
                if (surgHistory.CodeSnomed != null) {
                    codeSnomed = surgHistory.CodeSnomed;
                }
                string location1 = "";
                if (surgHistory.Location1 != null) {
                    location1 = surgHistory.Location1;
                }
                string procedureMonth1 = "";
                if (surgHistory.ProcedureMonth1 != null) {
                    procedureMonth1 = surgHistory.ProcedureMonth1;
                }
                string procedureDay1 = "";
                if (surgHistory.ProcedureDay1 != null) {
                    procedureDay1 = surgHistory.ProcedureDay1;
                }
                string procedureYear1 = "";
                if (surgHistory.ProcedureYear1 != null) {
                    procedureYear1 = surgHistory.ProcedureYear1;
                }
                int? performedByEmpId1 = null;
                if (surgHistory.PerformedbyEmpId1 != null) {
                    if (int.TryParse(surgHistory.PerformedbyEmpId1, out int locum)) {
                        performedByEmpId1 = locum;
                    }
                }
                int? performedByRefProvider1 = null;
                if (surgHistory.ComanageRefProviderId1 != null) {
                    if (int.TryParse(surgHistory.ComanageRefProviderId1, out int locum)) {
                        performedByRefProvider1 = locum;
                    }
                }
                string comanageFullName1 = "";
                if (surgHistory.ComanageFullName1 != null) {
                    comanageFullName1 = surgHistory.ComanageFullName1;
                }
                string location2 = "";
                if (surgHistory.Location2 != null) {
                    location2 = surgHistory.Location2;
                }
                string procedureMonth2 = "";
                if (surgHistory.ProcedureMonth2 != null) {
                    procedureMonth2 = surgHistory.ProcedureMonth2;
                }
                string procedureDay2 = "";
                if (surgHistory.ProcedureDay2 != null) {
                    procedureDay2 = surgHistory.ProcedureDay2;
                }
                string procedureYear2 = "";
                if (surgHistory.ProcedureYear2 != null) {
                    procedureYear2 = surgHistory.ProcedureYear2;
                }
                int? performedByEmpId2 = null;
                if (surgHistory.PerformedbyEmpId2 != null) {
                    if (int.TryParse(surgHistory.PerformedbyEmpId2, out int locum)) {
                         performedByEmpId2 = locum;
                    }
                }
                int? performedbyRefProviderId2 = null;
                if (surgHistory.ComanageRefProviderId2 != null) {
                    if (int.TryParse(surgHistory.ComanageRefProviderId2, out int locum)) {
                        performedbyRefProviderId2 = locum;
                    }
                }
                string comanageFullName2 = "";
                if (surgHistory.ComanageFullName2 != null) {
                    comanageFullName2 = surgHistory.ComanageFullName2;
                }
                string notes = "";
                if (surgHistory.Notes != null) {
                    notes = surgHistory.Notes;
                }
                string insertGUID = Guid.NewGuid().ToString();
                
                bool doNotReconcile = false;
                if (surgHistory.DoNotReconcile != null && surgHistory.DoNotReconcile.ToLower() == "yes") {
                    doNotReconcile = true;
                }
                int? ptDeviceId = null;
                if (surgHistory.PtDeviceId != null) {
                    if (int.TryParse(surgHistory.PtDeviceId, out int locum)) {
                        ptDeviceId = locum;
                    }
                }
                int? comanageRefProviderId1 = null;
                if (surgHistory.ComanageRefProviderId1 != null) {
                    if (int.TryParse(surgHistory.ComanageRefProviderId1, out int locum)) {
                        comanageRefProviderId1 = locum;
                    }
                }
                int? comanageRefProviderId2 = null;
                if (surgHistory.ComanageRefProviderId2 != null) {
                    if (int.TryParse(surgHistory.ComanageRefProviderId2, out int locum)) {
                        comanageRefProviderId2 = locum;
                    }
                }
                DateTime? created = null;
                // no created in source table
                DateTime? lastModified = null;
                // no lastModified in source table
                int? createdEmpId = null;
                // no createdEmpId in source table
                int? lastModifiedEmpId = null;
                // no lastModifiedEmpId in source table



                var newSurgHistory = new Brady_s_Conversion_Program.ModelsB.EmrvisitSurgicalHistory {
                    PtId = ptId,
                    VisitId = visitId,
                    VisitDate = visitDate,
                    ControlId = controlId,
                    OrigVisitSurgicalHistoryId = origVisitSurgicalHistoryId,
                    OrigVisitDate = origVisitDate,
                    Description = description,
                    TypeId = typeId,
                    CodeId = codeId,
                    Code = code,
                    Modifier = modifier,
                    CodeIcd10 = codeICD10,
                    CodeSnomed = codeSnomed,
                    ComanageEmpId1 = performedByEmpId1,
                    ComanageRefProviderId1 = comanageRefProviderId1,
                    ComanageFullName1 = comanageFullName1,
                    ComanageEmpId2 = performedByEmpId2,
                    ComanageRefProviderId2 = performedbyRefProviderId2,
                    ComanageFullName2 = comanageFullName2,
                    Notes = notes,
                    Created = created,
                    LastModified = lastModified,
                    CreatedEmpId = createdEmpId,
                    LastModifiedEmpId = lastModifiedEmpId,
                    DoNotReconcile = doNotReconcile,
                    PtDeviceId = ptDeviceId,
                    InsertGuid = insertGUID,
                    Location1 = location1,
                    ProcedureMonth1 = procedureMonth1,
                    ProcedureDay1 = procedureDay1,
                    ProcedureYear1 = procedureYear1,
                    PerformedbyEmpId1 = performedByEmpId1,
                    PerformedbyFullName1 = comanageFullName1,
                    PerformedbyRefProviderId1 = performedByRefProvider1,
                    Location2 = location2,
                    ProcedureMonth2 = procedureMonth2,
                    ProcedureDay2 = procedureDay2,
                    ProcedureYear2 = procedureYear2,
                    PerformedbyEmpId2 = performedByEmpId2,
                    PerformedbyFullName2 = comanageFullName2,
                    PerformedbyRefProviderId2 = performedbyRefProviderId2
                };
                eyeMDDbContext.EmrvisitSurgicalHistories.Add(newSurgHistory);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the surg history with ID: {surgHistory.Id}. Error: {e.Message}");
            }
        }

        public static void TechsConvert(ModelsC.Tech tech, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? ptId = null;
                if (tech.PtId != null) {
                    if (int.TryParse(tech.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                int? visitId = null;
                if (tech.VisitId != null) {
                    if (int.TryParse(tech.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                if (ptId == null) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null && eyeMDVisit.PtId != null) {
                        ptId = (int)eyeMDVisit.PtId;
                    } else {
                        logger.Log($"EHR: EHR PatientID not found for Tech with ID: {tech.Id}");
                    }
                }

                DateTime? dosDate = null;
                if (tech.Dosdate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(tech.Dosdate, dateFormats,
                                                    CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosDate = tempDateTime;
                    }
                }
                int? pmhSmoking = null;
                if (tech.Pmhsmoking != null) {
                    if (int.TryParse(tech.Pmhsmoking, out int locum)) {
                        pmhSmoking = locum;
                    }
                }
                int? pmhAlcohol = null;
                if (tech.Pmhalcohol != null) {
                    if (int.TryParse(tech.Pmhalcohol, out int locum)) {
                        pmhAlcohol = locum;
                    }
                }
                int? pmhDrugs = null;
                if (tech.Pmhdrugs != null) {
                    if (int.TryParse(tech.Pmhdrugs, out int locum)) {
                        pmhDrugs = locum;
                    }
                }
                int? wuvaCcType = null;
                if (tech.WuvaCcType != null) {
                    if (int.TryParse(tech.WuvaCcType, out int locum)) {
                        wuvaCcType = locum;
                    }
                }
                short? workupMdReviewed = null;
                if (tech.WorkupMdreviewed != null) {
                    if (short.TryParse(tech.WorkupMdreviewed, out short locum)) {
                        workupMdReviewed = locum;
                    }
                }
                DateTime? workupMdReviewedDate = null;
                if (tech.WorkupMdreviewedDate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(tech.WorkupMdreviewedDate, dateFormats,
                                                                           CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        workupMdReviewedDate = tempDateTime;
                    }
                }
                int? workupMdReviewedEmpId = null;
                if (tech.WorkupMdreviewedEmpId != null) {
                    if (int.TryParse(tech.WorkupMdreviewedEmpId, out int locum)) {
                        workupMdReviewedEmpId = locum;
                    }
                }
                short? wucvfAbute = null;
                if (tech.WucvfAbute != null) {
                    if (short.TryParse(tech.WucvfAbute, out short locum)) {
                        wucvfAbute = locum;
                    }
                }
                int? wuDilated = null;
                if (tech.Wudilated != null) {
                    if (int.TryParse(tech.Wudilated, out int locum)) {
                        wuDilated = locum;
                    }
                }
                decimal? vitalsBmiPercentile = null;
                if (tech.VitalsBmipercentile != null) {
                    if (decimal.TryParse(tech.VitalsBmipercentile, out decimal locum)) {
                        vitalsBmiPercentile = locum;
                    }
                }
                decimal? vitalsHofcPercentile = null;
                if (tech.VitalsHofcpercentile != null) {
                    if (decimal.TryParse(tech.VitalsHofcpercentile, out decimal locum)) {
                        vitalsHofcPercentile = locum;
                    }
                }
                decimal? vitalsInhaled02Concentration = null;
                if (tech.VitalsInhaled02Concentration != null) {
                    if (decimal.TryParse(tech.VitalsInhaled02Concentration, out decimal locum)) {
                        vitalsInhaled02Concentration = locum;
                    }
                }
                decimal? vitalsPulseOximetry = null;
                if (tech.VitalsPulseOximetry != null) {
                    if (decimal.TryParse(tech.VitalsPulseOximetry, out decimal locum)) {
                        vitalsPulseOximetry = locum;
                    }
                }
                decimal? vitalsWflPercentile = null;
                if (tech.VitalsWflpercentile != null) {
                    if (decimal.TryParse(tech.VitalsWflpercentile, out decimal locum)) {
                        vitalsWflPercentile = locum;
                    }
                }
                short? historyReviewed = null;
                if (tech.HistoryMdreviewed != null) {
                    if (short.TryParse(tech.HistoryMdreviewed, out short locum)) {
                        historyReviewed = locum;
                    }
                }
                DateTime? historyMdReviewedDate = null;
                if (tech.HistoryMdreviewedDate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(tech.HistoryMdreviewedDate, dateFormats,
                                                    CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        historyMdReviewedDate = tempDateTime;
                    }
                }
                int? historyMdReviewedEmpId = null;
                if (tech.HistoryMdreviewedEmpId != null) {
                    if (int.TryParse(tech.HistoryMdreviewedEmpId, out int locum)) {
                        historyMdReviewedEmpId = locum;
                    }
                }
                DateTime? created = null;
                if (tech.Created != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(tech.Created, dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        created = tempDateTime;
                    }
                }
                int? createdEmpId = null;
                if (tech.CreatedEmpId != null) {
                    if (int.TryParse(tech.CreatedEmpId, out int locum)) {
                        createdEmpId = locum;
                    }
                }
                DateTime? wuDilatedTime = null;
                if (tech.WudilatedTime != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(tech.WudilatedTime, dateFormats,
                                              CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        wuDilatedTime = tempDateTime;
                    }
                }
                short? wuDilatedTimeZone = null;
                if (tech.WudilatedTimeZone != null) {
                    if (short.TryParse(tech.WudilatedTimeZone, out short locum)) {
                        wuDilatedTimeZone = locum;
                    }
                }
                bool intakeReconciled = false;
                if (tech.IntakeReconciled != null && tech.IntakeReconciled.ToLower() == "yes") {
                    intakeReconciled = true;
                }
                DateTime? lastModified = null;
                if (tech.LasstModified != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(tech.LasstModified, dateFormats,
                                                CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        lastModified = tempDateTime;
                    }
                }
                int? lastModifiedEmpId = null;
                if (tech.LastModifiedEmpId != null) {
                    if (int.TryParse(tech.LastModifiedEmpId, out int locum)) {
                        lastModifiedEmpId = locum;
                    }
                }
                short? medRecNotPerformed = null;
                if (tech.MedRecNotPerformed != null) {
                    if (short.TryParse(tech.MedRecNotPerformed, out short locum)) {
                        medRecNotPerformed = locum;
                    }
                }
                int? wuMood = null;
                if (tech.Wumood != null) {
                    if (int.TryParse(tech.Wumood, out int locum)) {
                        wuMood = locum;
                    }
                }
                int? wuextPan = null;
                if (tech.Wuextpan != null) {
                    if (int.TryParse(tech.Wuextpan, out int locum)) {
                        wuextPan = locum;
                    }
                }
                short? wuiopAbute = null;
                if (tech.WuiopAbute != null) {
                    if (short.TryParse(tech.WuiopAbute, out short locum)) {
                        wuiopAbute = locum;
                    }
                }
                int? wuOrientPerson = null;
                if (tech.WuorientPerson != null) {
                    if (int.TryParse(tech.WuorientPerson, out int locum)) {
                        wuOrientPerson = locum;
                    }
                }
                int? wuOrientPlace = null;
                if (tech.WuorientPlace != null) {
                    if (int.TryParse(tech.WuorientPlace, out int locum)) {
                        wuOrientPlace = locum;
                    }
                }
                int? wuOrientTime = null;
                if (tech.WuorientTime != null) {
                    if (int.TryParse(tech.WuorientTime, out int locum)) {
                        wuOrientTime = locum;
                    }
                }
                int? wuOrientSituation = null;
                if (tech.WuorientSituation != null) {
                    if (int.TryParse(tech.WuorientSituation, out int locum)) {
                        wuOrientSituation = locum;
                    }
                }



                var newTech = new Brady_s_Conversion_Program.ModelsB.EmrvisitTech {
                    PtId = ptId,
                    VisitId = visitId,
                    Dosdate = dosDate,
                    Pmhsmoking = pmhSmoking,
                    Pmhalcohol = pmhAlcohol,
                    Pmhdrugs = pmhDrugs,
                    WuvaCcType = wuvaCcType,
                    Pmhfhother = tech.Pmhfhother,
                    PmhsmokeHowMuch = tech.PmhsmokeHowMuch,
                    PmhsmokeHowLong = tech.PmhsmokeHowLong,
                    PmhsmokeWhenQuit = tech.PmhsmokeWhenQuit,
                    PmhalcoholHowMuch = tech.PmhalcoholHowMuch,
                    PmhdrugsNames = tech.PmhdrugsNames,
                    PmhdrugsHowMuch = tech.PmhdrugsHowMuch,
                    PmhdrugsHowLong = tech.PmhdrugsHowLong,
                    PmhdrugsWhenQuit = tech.PmhdrugsWhenQuit,
                    HpichiefComplaint = tech.HpichiefComplaint,
                    Hpilocation1 = tech.Hpilocation1,
                    Hpiquality1 = tech.Hpiquality1,
                    Hpiseverity1 = tech.Hpiseverity1,
                    Hpitiming1 = tech.Hpitiming1,
                    Hpiduration1 = tech.Hpiduration1,
                    Hpicontext1 = tech.Hpicontext1,
                    HpimodFactors1 = tech.HpimodFactors1,
                    HpiassoSignsSymp1 = tech.HpiassoSignsSymp1,
                    Hpi1letterText = tech.Hpi1letterText,
                    WuvaCcOd = tech.WuvaCcOd,
                    WuvaCcOs = tech.WuvaCcOs,
                    WuvaCcOu = tech.WuvaCcOu,
                    WuvaPhOd = tech.WuvaPhOd,
                    WuvaPhOs = tech.WuvaPhOs,
                    WuvaScOd = tech.WuvaScOd,
                    WuvaScOs = tech.WuvaScOs,
                    WuvaScOu = tech.WuvaScOu,
                    WuvaTestUsed = tech.WuvaTestUsed,
                    WunCcOd = tech.WunCcOd,
                    WunCcOs = tech.WunCcOs,
                    WunCcOu = tech.WunCcOu,
                    Wunotes = tech.Wunotes,
                    WunScOd = tech.WunScOd,
                    WunScOs = tech.WunScOs,
                    WunScOu = tech.WunScOu,
                    WudomEye = tech.WudomEye,
                    WutcvfOd = tech.WutcvfOd,
                    WutcvfOs = tech.WutcvfOs,
                    WucvfdiagOd = tech.WucvfdiagOd,
                    WucvfdiagOs = tech.WucvfdiagOs,
                    WueomSuTmOd = tech.WueomSuTmOd,
                    WueomSuTmOs = tech.WueomSuTmOs,
                    WueomMedialOd = tech.WueomMedialOd,
                    WueomMedialOs = tech.WueomMedialOs,
                    WueomInNaOs = tech.WueomInNaOs,
                    WueomInNaOd = tech.WueomInNaOd,
                    WueomInTmOd = tech.WueomInTmOd,
                    WueomInTmOs = tech.WueomInTmOs,
                    WueomSuNaOd = tech.WueomSuNaOd,
                    WueomSuNaOs = tech.WueomSuNaOs,
                    WupupilNearOd = tech.WupupilNearOd,
                    WupupilNearOs = tech.WupupilNearOs,
                    WorkupMdreviewed = workupMdReviewed,
                    WorkupMdreviewedDate = workupMdReviewedDate,
                    WorkupMdreviewedEmpId = workupMdReviewedEmpId,
                    WuamslerOd = tech.WuamslerOd,
                    WuamslerOs = tech.WuamslerOs,
                    WucvfAbute = wucvfAbute,
                    Wudilated = wuDilated,
                    WudilatedAgent = tech.WudilatedAgent,
                    WudilatedEye = tech.WudilatedEye,
                    WudilatedFrequency = tech.WudilatedFrequency,
                    VitalsTemp = tech.VitalsTemp,
                    VitalsTempUnits = tech.VitalsTempUnits,
                    VitalsPulse = tech.VitalsPulse,
                    VitalsBpsys = tech.VitalsBpsys,
                    VitalsBpdia = tech.VitalsBpdia,
                    VitalsRespRate = tech.VitalsRespRate,
                    VitalsWeight = tech.VitalsWeight,
                    VitalsWeightUnits = tech.VitalsWeightUnits,
                    VitalsHeight = tech.VitalsHeight,
                    VitalsHeightUnits = tech.VitalsHeightUnits,
                    VitalsBmi = tech.VitalsBmi,
                    VitalsBmipercentile = vitalsBmiPercentile,
                    VitalsBgl = tech.VitalsBgl,
                    VitalsBglunits = tech.VitalsBglunits,
                    VitalsHofcpercentile = vitalsHofcPercentile,
                    VitalsInhaled02Concentration = vitalsInhaled02Concentration,
                    VitalsPulseOximetry = vitalsPulseOximetry,
                    VitalsWflpercentile = vitalsWflPercentile,
                    HistoryMdreviewed = historyReviewed,
                    HistoryMdreviewedDate = historyMdReviewedDate,
                    HistoryMdreviewedEmpId = historyMdReviewedEmpId,
                    Created = created,
                    CreatedEmpId = createdEmpId,
                    WupupilShapeOs = tech.WupupilShapeOs,
                    WupupilShapeOd = tech.WupupilShapeOd,
                    WudilatedTimeZone = wuDilatedTimeZone,
                    WudilatedTime = wuDilatedTime,
                    WueomTemporalOd = tech.WueomTemporalOd,
                    WueomTemporalOs = tech.WueomTemporalOs,
                    WueomType = tech.WueomType,
                    Wuextlids = tech.Wuextlids,
                    Wuextorbits = tech.Wuextorbits,
                    PmhsmokingStatus = tech.PmhsmokingStatus,
                    WupupilReactionOs = tech.WupupilReactionOs,
                    WupupilReactionOd = tech.WupupilReactionOd,
                    WupupilLightSizeOs = tech.WupupilLightSizeOs,
                    WupupilLightSizeOd = tech.WupupilLightSizeOd,
                    WupupilApdOd = tech.WupupilApdOd,
                    WupupilApdOs = tech.WupupilApdOs,
                    WupupilDarkSizeOd = tech.WupupilDarkSizeOd,
                    WupupilDarkSizeOs = tech.WupupilDarkSizeOs,
                    HpiadditionalComments1 = tech.HpiadditionalComments1,
                    IntakeReconciled = intakeReconciled,
                    LastModified = lastModified,
                    LastModifiedEmpId = lastModifiedEmpId,
                    MedRecNotPerformed = medRecNotPerformed,
                    UpsizeTs = null,
                    Wumood = wuMood,
                    Wuextpan = wuextPan,
                    WuiopAbute = wuiopAbute,
                    WuorientPerson = wuOrientPerson,
                    WuorientPlace = wuOrientPlace,
                    WuorientTime = wuOrientTime,
                    WuorientSituation = wuOrientSituation
                };
                eyeMDDbContext.EmrvisitTeches.Add(newTech);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the tech with ID: {tech.Id}. Error: {e.Message}");
            }
        }

        public static void Tech2sConvert(ModelsC.Tech2 tech2, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? ptId = null;
                if (tech2.PtId != null) {
                    if (int.TryParse(tech2.PtId, out int locum)) {
                        ptId = locum;
                    }
                }
                int? visitId = null;
                if (tech2.VisitId != null) {
                    if (int.TryParse(tech2.VisitId, out int locum)) {
                        visitId = locum;
                    }
                }
                if (ptId == null) {
                    var eyeMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eyeMDVisit != null && eyeMDVisit.PtId != null) {
                        ptId = (int)eyeMDVisit.PtId;
                    } else {
                        logger.Log($"EHR: EHR PatientID not found for Tech2 with ID: {tech2.Id}");
                    }
                }

                DateTime? dosDate = null;
                if (tech2.Dosdate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(tech2.Dosdate, dateFormats,
                                                                           CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        dosDate = tempDateTime;
                    }
                }
                float? wu2kmaxOd = null;
                if (tech2.Wu2kmaxOd != null) {
                    if (float.TryParse(tech2.Wu2kmaxOd, out float locum)) {
                        wu2kmaxOd = locum;
                    }
                }
                float? wu2kmaxOs = null;
                if (tech2.Wu2kmaxOs != null) {
                    if (float.TryParse(tech2.Wu2kmaxOs, out float locum)) {
                        wu2kmaxOs = locum;
                    }
                }
                float? wu2kminOd = null;
                if (tech2.Wu2kminOd != null) {
                    if (float.TryParse(tech2.Wu2kminOd, out float locum)) {
                        wu2kminOd = locum;
                    }
                }
                float? wu2kminOs = null;
                if (tech2.Wu2kminOs != null) {
                    if (float.TryParse(tech2.Wu2kminOs, out float locum)) {
                        wu2kminOs = locum;
                    }
                }
                float? wu2kminDegOd = null;
                if (tech2.Wu2kminDegOd != null) {
                    if (float.TryParse(tech2.Wu2kminDegOd, out float locum)) {
                        wu2kminDegOd = locum;
                    }
                }
                float? wu2kminDegOs = null;
                if (tech2.Wu2kminDegOs != null) {
                    if (float.TryParse(tech2.Wu2kminDegOs, out float locum)) {
                        wu2kminDegOs = locum;
                    }
                }
                float? wu2kmaxDegOd = null;
                if (tech2.Wu2kmaxDegOd != null) {
                    if (float.TryParse(tech2.Wu2kmaxDegOd, out float locum)) {
                        wu2kmaxDegOd = locum;
                    }
                }
                float? wu2kmaxDegOs = null;
                if (tech2.Wu2kmaxDegOs != null) {
                    if (float.TryParse(tech2.Wu2kmaxDegOs, out float locum)) {
                        wu2kmaxDegOs = locum;
                    }
                }
                short? wu2TearOsmolarityCollectionDifficult = null;
                if (tech2.Wu2tearOsmolarityCollectionDifficult != null) {
                    if (short.TryParse(tech2.Wu2tearOsmolarityCollectionDifficult, out short locum)) {
                        wu2TearOsmolarityCollectionDifficult = locum;
                    }
                }
                byte[]? upsizets = null;
                // no upsizets in source table

                

                var newTech2 = new Brady_s_Conversion_Program.ModelsB.EmrvisitTech2 {
                    PtId = ptId,
                    VisitId = visitId,
                    Dosdate = dosDate,
                    Wu2vaOrxOd = tech2.Wu2vaOrxOd,
                    Wu2vaOrxOs = tech2.Wu2vaOrxOs,
                    Wu2kmaxOd = wu2kmaxOd,
                    Wu2kmaxOs = wu2kmaxOs,
                    Wu2kminOd = wu2kminOd,
                    Wu2kminOs = wu2kminOs,
                    Wu2kminDegOd = wu2kminDegOd,
                    Wu2kminDegOs = wu2kminDegOs,
                    Wu2kmaxDegOd = wu2kmaxDegOd,
                    Wu2kmaxDegOs = wu2kmaxDegOs,
                    UpsizeTs = upsizets,
                    Wu2tearOsmolarityOd = tech2.Wu2tearOsmolarityOd,
                    Wu2tearOsmolarityOs = tech2.Wu2tearOsmolarityOs,
                    Wu2tearOsmolarityCollectionDifficult = wu2TearOsmolarityCollectionDifficult,
                    Wu2custom1Data = tech2.Wu2custom1Data,
                    Wu2custom1Desc = tech2.Wu2custom1Desc,
                    Wu2custom2Data = tech2.Wu2custom2Data,
                    Wu2custom2Desc = tech2.Wu2custom2Desc,
                    Wu2custom3Data = tech2.Wu2custom3Data,
                    Wu2custom3Desc = tech2.Wu2custom3Desc,
                    Wu2custom4Data = tech2.Wu2custom4Data,
                    Wu2custom4Desc = tech2.Wu2custom4Desc,
                    Wu2custom5Data = tech2.Wu2custom5Data,
                    Wu2custom5Desc = tech2.Wu2custom5Desc,
                    Wu2custom6Data = tech2.Wu2custom6Data,
                    Wu2custom6Desc = tech2.Wu2custom6Desc,
                    Wu2custom7Data = tech2.Wu2custom7Data,
                    Wu2custom7Desc = tech2.Wu2custom7Desc,
                    Wu2custom8Data = tech2.Wu2custom8Data,
                    Wu2custom8Desc = tech2.Wu2custom8Desc,
                    Wu2custom9Data = tech2.Wu2custom9Data,
                    Wu2custom9Desc = tech2.Wu2custom9Desc,
                    Wu2custom10Data = tech2.Wu2custom10Data,
                    Wu2custom10Desc = tech2.Wu2custom10Desc,
                    Wu2custom11Data = tech2.Wu2custom11Data,
                    Wu2custom11Desc = tech2.Wu2custom11Desc,
                    Wu2custom12Data = tech2.Wu2custom12Data,
                    Wu2custom12Desc = tech2.Wu2custom12Desc,
                    Wu2custom13Data = tech2.Wu2custom13Data,
                    Wu2custom13Desc = tech2.Wu2custom13Desc,
                    Wu2custom14Data = tech2.Wu2custom14Data,
                    Wu2custom14Desc = tech2.Wu2custom14Desc,
                    Wu2custom15Data = tech2.Wu2custom15Data,
                    Wu2custom15Desc = tech2.Wu2custom15Desc,
                    Wu2custom16Data = tech2.Wu2custom16Data,
                    Wu2custom16Desc = tech2.Wu2custom16Desc,
                    Wu2custom17Data = tech2.Wu2custom17Data,
                    Wu2custom17Desc = tech2.Wu2custom17Desc,
                    Wu2custom18Data = tech2.Wu2custom18Data,
                    Wu2custom18Desc = tech2.Wu2custom18Desc,
                    Wu2custom19Data = tech2.Wu2custom19Data,
                    Wu2custom19Desc = tech2.Wu2custom19Desc,
                    Wu2custom20Data = tech2.Wu2custom20Data,
                    Wu2custom20Desc = tech2.Wu2custom20Desc,
                    Wu2custom21Data = tech2.Wu2custom21Data,
                    Wu2custom21Desc = tech2.Wu2custom21Desc,
                    Wu2custom22Data = tech2.Wu2custom22Data,
                    Wu2custom22Desc = tech2.Wu2custom22Desc,
                    Wu2GlareHighOd = tech2.Wu2GlareHighOd,
                    Wu2GlareHighOs = tech2.Wu2GlareHighOs,
                    Wu2GlareLowOd = tech2.Wu2GlareLowOd,
                    Wu2GlareLowOs = tech2.Wu2GlareLowOs,
                    Wu2GlareMedOd = tech2.Wu2GlareMedOd,
                    Wu2GlareMedOs = tech2.Wu2GlareMedOs,
                    Wu2GlareType = tech2.Wu2GlareType,
                    Wu2hertelBase = tech2.Wu2hertelBase,
                    Wu2hertelOd = tech2.Wu2hertelOd,
                    Wu2hertelOs = tech2.Wu2hertelOs,
                    Wu2ktype = tech2.Wu2ktype,
                    Wu2pachCctOd = tech2.Wu2pachCctOd,
                    Wu2pachCctOs = tech2.Wu2pachCctOs,
                    Wu2ttvOd = tech2.Wu2ttvOd,
                    Wu2ttvOs = tech2.Wu2ttvOs,
                    Wu2ttvtype = tech2.Wu2ttvtype,
                    Wu2vaPamOd = tech2.Wu2vaPamOd,
                    Wu2vaPamOs = tech2.Wu2vaPamOs
                };
                eyeMDDbContext.EmrvisitTech2s.Add(newTech2);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the tech2 with ID: {tech2.Id}. Error: {e.Message}");
            }
        }
        #endregion EyeMDConversion

        #region InvConversion
        public static void ConvertInv(InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            foreach (var clBrand in invDbContext.ClBrands) {
                CLBrandsConvert(clBrand, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var clInventory in invDbContext.ClInventories) {
                clInventoryConvert(clInventory, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var clLense in invDbContext.ClLenses) {
                CLLensesConvert(clLense, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var cptDept in invDbContext.CptDepts) {
                CPTDeptConvert(cptDept, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var cptMapping in invDbContext.CptMappings) {
                CPTMappingConvert(cptMapping, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var cpt in invDbContext.Cpts) {
                CPTConvert(cpt, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var frameCategory in invDbContext.FrameCategories) {
                FrameCategoryConvert(frameCategory, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var frameCollection in invDbContext.FrameCollections) {
                FrameCollectionConvert(frameCollection, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var frameColor in invDbContext.FrameColors) {
                FrameColorConvert(frameColor, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var frameShape in invDbContext.FrameShapes) {
                FrameShapeConvert(frameShape, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var frameStatus in invDbContext.FrameStatuses) {
                FrameStatusConvert(frameStatus, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var frameTemple in invDbContext.FrameTemples) {
                FrameTempleConvert(frameTemple, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var frameEtype in invDbContext.FrameEtypes) {
                FrameETypeConvert(frameEtype, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var frameFtype in invDbContext.FrameFtypes) {
                FrameFTypeConvert(frameFtype, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var frameLensColor in invDbContext.FrameLensColors) {
                FrameLensColorConvert(frameLensColor, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var frameMaterial in invDbContext.FrameMaterials) {
                FrameMaterialConvert(frameMaterial, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var frameOrder in invDbContext.FrameOrders) {
                FrameOrderConvert(frameOrder, invDbContext, ffpmDbContext, logger, progress);
            }

            foreach (var frames in invDbContext.Frames) {
                FrameConvert(frames, invDbContext, ffpmDbContext, logger, progress);
            }
        }

        public static void CLBrandsConvert(ClBrand clBrand, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                long? addedBy = null;
                if (clBrand.AddedBy != null) {
                    if (long.TryParse(clBrand.AddedBy, out long locum)) {
                        addedBy = locum;
                    }
                }
                DateTime? addedDate = null;
                if (clBrand.AddedDate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(clBrand.AddedDate, dateFormats,
                                                                      CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        addedDate = tempDateTime;
                    }
                }
                long? locationId = null;
                if (clBrand.LocationId != null) {
                    if (long.TryParse(clBrand.LocationId, out long locum)) {
                        locationId = locum;
                    }
                }
                bool? isActive = null;
                if (clBrand.IsActive != null) {
                    if (bool.TryParse(clBrand.IsActive, out bool locum)) {
                        isActive = locum;
                    }
                }

                var invList = ffpmDbContext.ClnsBrands.FirstOrDefault(x => x.BrandName == clBrand.BrandName);
                if (invList != null) {
                    invList.BrandCode = clBrand.BrandCode;
                    invList.AddedBy = addedBy;
                    invList.AddedDate = addedDate;
                    invList.LocationId = locationId;
                    invList.IsActive = isActive;
                    ffpmDbContext.SaveChanges();
                    return;
                }



                var newClBrand = new Brady_s_Conversion_Program.ModelsA.ClnsBrand {
                    BrandName = clBrand.BrandName,
                    BrandCode = clBrand.BrandCode,
                    AddedBy = addedBy,
                    AddedDate = addedDate,
                    LocationId = locationId,
                    IsActive = isActive
                };
                ffpmDbContext.ClnsBrands.Add(newClBrand);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the CL Brand with ID {clBrand.Id}. Error: {e.Message}");
            }
        }

        public static void clInventoryConvert(ClInventory clInventory, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                if (clInventory.ContactLensId != -1) {
                    logger.Log($"INV: INV Contact Lens ID not found for clInventory with ID {clInventory.Id}");
                    return;
                }
                int? quantityOrdered = null;
                if (clInventory.QuantityOrdered != null) {
                    if (int.TryParse(clInventory.QuantityOrdered, out int locum)) {
                        quantityOrdered = locum;
                    }
                }
                int? received = null;
                if (clInventory.Received != null) {
                    if (int.TryParse(clInventory.Received, out int locum)) {
                        received = locum;
                    }
                }
                int? onHand = null;
                if (clInventory.OnHand != null) {
                    if (int.TryParse(clInventory.OnHand, out int locum)) {
                        onHand = locum;
                    }
                }
                int? dispensed = null;
                if (clInventory.Dispensed != null) {
                    if (int.TryParse(clInventory.Dispensed, out int locum)) {
                        dispensed = locum;
                    }
                }
                long? addedBy = null;
                if (clInventory.AddedBy != null) {
                    if (long.TryParse(clInventory.AddedBy, out long locum)) {
                        addedBy = locum;
                    }
                }
                DateTime? addedDate = null;
                if (clInventory.AddedDate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(clInventory.AddedDate, dateFormats,
                                              CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        addedDate = tempDateTime;
                    }
                }
                DateTime? invoiceDate = null;
                if (clInventory.InvoiceDate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(clInventory.InvoiceDate, dateFormats,
                                              CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        invoiceDate = tempDateTime;
                    }
                }
                DateTime? expiryDate = null;
                if (clInventory.ExpiryDate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(clInventory.ExpiryDate, dateFormats,
                                              CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        expiryDate = tempDateTime;
                    }
                }
                long? updatedBy = null;
                if (clInventory.UpdatedBy != null) {
                    if (long.TryParse(clInventory.UpdatedBy, out long locum)) {
                        updatedBy = locum;
                    }
                }
                DateTime? updatedDate = null;
                if (clInventory.UpdatedDate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(clInventory.UpdatedDate, dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        updatedDate = tempDateTime;
                    }
                }
                bool? isTrials = null;
                if (clInventory.IsTrials != null) {
                    if (bool.TryParse(clInventory.IsTrials, out bool locum)) {
                        isTrials = locum;
                    }
                }
                bool? isActive = null;
                if (clInventory.IsActive != null) {
                    if (bool.TryParse(clInventory.IsActive, out bool locum)) {
                        isActive = locum;
                    }
                }
                long? locationId = null;
                if (clInventory.LocationId != null) {
                    if (long.TryParse(clInventory.LocationId, out long locum)) {
                        locationId = locum;
                    }
                }

                var invList = ffpmDbContext.ClnsInventories.FirstOrDefault(x => x.ContactLensId == clInventory.ContactLensId);
                if (invList != null) {
                    invList.Barcode = clInventory.Barcode;
                    invList.InvoiceNumber = clInventory.InvoiceNumber;
                    invList.ItemCost = clInventory.ItemCost;
                    invList.WholesalePrice = clInventory.WholesalePrice;
                    invList.RetailPrice = clInventory.RetailPrice;
                    invList.Notes = clInventory.Notes;
                    invList.QuantityOrdered = quantityOrdered;
                    invList.Received = received;
                    invList.OnHand = onHand;
                    invList.Dispensed = dispensed;
                    invList.AddedBy = addedBy;
                    invList.AddedDate = addedDate;
                    invList.InvoiceDate = invoiceDate;
                    invList.ExpiryDate = expiryDate;
                    invList.UpdatedBy = updatedBy;
                    invList.UpdatedDate = updatedDate;
                    invList.IsTrials = isTrials;
                    invList.IsActive = isActive;
                    invList.LocationId = locationId;
                    ffpmDbContext.SaveChanges();
                    return;
                }



                var newClInventory = new Brady_s_Conversion_Program.ModelsA.ClnsInventory {
                    ContactLensId = clInventory.ContactLensId,
                    Barcode = clInventory.Barcode,
                    InvoiceNumber = clInventory.InvoiceNumber,
                    ItemCost = clInventory.ItemCost,
                    WholesalePrice = clInventory.WholesalePrice,
                    RetailPrice = clInventory.RetailPrice,
                    Notes = clInventory.Notes,
                    QuantityOrdered = quantityOrdered,
                    Received = received,
                    OnHand = onHand,
                    Dispensed = dispensed,
                    AddedBy = addedBy,
                    AddedDate = addedDate,
                    InvoiceDate = invoiceDate,
                    ExpiryDate = expiryDate,
                    UpdatedBy = updatedBy,
                    UpdatedDate = updatedDate,
                    IsTrials = isTrials,
                    IsActive = isActive,
                    LocationId = locationId
                };
                ffpmDbContext.ClnsInventories.Add(newClInventory);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the CL Inventory with ID {clInventory.Id}. Error: {e.Message}");
            }
        }

        public static void CLLensesConvert(ClLense clLense, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int clnsBrandId = -1;
                if (clLense.ClnsBrandId != null) {
                    if (int.TryParse(clLense.ClnsBrandId, out int locum)) {
                        clnsBrandId = locum;
                    }
                }
                if (clnsBrandId == -1) {
                    logger.Log($"INV: INV Brand ID not found for CL Lense with ID {clLense.Id}");
                    return;
                }
                int? clnsManufacturerId = null;
                if (clLense.ClnsManufacturerId != null) {
                    if (int.TryParse(clLense.ClnsManufacturerId, out int locum)) {
                        clnsManufacturerId = locum;
                    }
                }
                int? clnsLensTypeId = null;
                if (clLense.ClnsLensTypeId != null) {
                    if (int.TryParse(clLense.ClnsLensTypeId, out int locum)) {
                        clnsLensTypeId = locum;
                    }
                }
                int? cptId = null;
                if (clLense.CptId != null) {
                    if (int.TryParse(clLense.CptId, out int locum)) {
                        cptId = locum;
                    }
                }
                DateTime? addedDate = null;
                if (clLense.AddedDate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(clLense.AddedDate, dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        addedDate = tempDateTime;
                    }
                }
                long? addedBy = null;
                if (clLense.AddedBy != null) {
                    if (long.TryParse(clLense.AddedBy, out long locum)) {
                        addedBy = locum;
                    }
                }
                DateTime? updatedDate = null;
                if (clLense.UpdatedDate != null) {
                    DateTime tempDateTime;
                    if (DateTime.TryParseExact(clLense.UpdatedDate, dateFormats,
                                              CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                        updatedDate = tempDateTime;
                    }
                }
                long? updatedBy = null;
                if (clLense.UpdatedBy != null) {
                    if (long.TryParse(clLense.UpdatedBy, out long locum)) {
                        updatedBy = locum;
                    }
                }
                bool? isSoftContact = null;
                if (clLense.IsSoftContact != null) {
                    if (bool.TryParse(clLense.IsSoftContact, out bool locum)) {
                        isSoftContact = locum;
                    }
                }
                bool? isActive = null;
                if (clLense.IsActive != null) {
                    if (bool.TryParse(clLense.IsActive, out bool locum)) {
                        isActive = locum;
                    }
                }
                long? locationId = null;
                if (clLense.LocationId != null) {
                    if (long.TryParse(clLense.LocationId, out long locum)) {
                        locationId = locum;
                    }
                }
                int? lensPerBox = null;
                if (clLense.LensPerBox != null) {
                    if (int.TryParse(clLense.LensPerBox, out int locum)) {
                        lensPerBox = locum;
                    }
                }
                bool? isLensFromClxCatalog = null;
                if (clLense.IsLensFromClxCatalog != null) {
                    if (bool.TryParse(clLense.IsLensFromClxCatalog, out bool locum)) {
                        isLensFromClxCatalog = locum;
                    }
                }

                var invList = ffpmDbContext.ClnsContactLens.FirstOrDefault(x => x.ClnsBrandId == clnsBrandId);
                if (invList != null) {
                    invList.ClnsManufacturerId = clnsManufacturerId;
                    invList.Sphere = clLense.Sphere;
                    invList.Cylinder = clLense.Cylinder;
                    invList.Axis = clLense.Axis;
                    invList.BaseCurve = clLense.BaseCurve;
                    invList.Diameter = clLense.Diameter;
                    invList.AddPower = clLense.AddPower;
                    invList.AddPowerName = clLense.AddPowerName;
                    invList.Multifocal = clLense.Multifocal;
                    invList.Color = clLense.Color;
                    invList.Upc = clLense.Upc;
                    invList.ClnsLensTypeId = clnsLensTypeId;
                    invList.CptId = cptId;
                    invList.AddedDate = addedDate;
                    invList.AddedBy = addedBy;
                    invList.UpdatedDate = updatedDate;
                    invList.UpdatedBy = updatedBy;
                    invList.IsSoftContact = isSoftContact;
                    invList.IsActive = isActive;
                    invList.LocationId = locationId;
                    invList.LensPerBox = lensPerBox;
                    invList.IsLensFromClxCatalog = isLensFromClxCatalog;
                    ffpmDbContext.SaveChanges();
                    return;
                }



                var newClLens = new Brady_s_Conversion_Program.ModelsA.ClnsContactLen {
                    ClnsBrandId = clnsBrandId,
                    ClnsManufacturerId = clnsManufacturerId,
                    Sphere = clLense.Sphere,
                    Cylinder = clLense.Cylinder,
                    Axis = clLense.Axis,
                    BaseCurve = clLense.BaseCurve,
                    Diameter = clLense.Diameter,
                    AddPower = clLense.AddPower,
                    AddPowerName = clLense.AddPowerName,
                    Multifocal = clLense.Multifocal,
                    Color = clLense.Color,
                    Upc = clLense.Upc,
                    ClnsLensTypeId = clnsLensTypeId,
                    CptId = cptId,
                    AddedDate = addedDate,
                    AddedBy = addedBy,
                    UpdatedDate = updatedDate,
                    UpdatedBy = updatedBy,
                    IsSoftContact = isSoftContact,
                    IsActive = isActive,
                    LocationId = locationId,
                    LensPerBox = lensPerBox,
                    IsLensFromClxCatalog = isLensFromClxCatalog
                };
                ffpmDbContext.ClnsContactLens.Add(newClLens);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the CL Lens with ID {clLense.Id}. Error: {e.Message}");
            }
        }

        public static void CPTDeptConvert(CptDept cptDept, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                string code = "";
                if (cptDept.Code != null) {
                    code = cptDept.Code;
                }
                string description = "";
                if (cptDept.Description != null) {
                    description = cptDept.Description;
                }
                int locationId = -1;
                if (cptDept.LocationId != null) {
                    if (int.TryParse(cptDept.LocationId, out int locum)) {
                        locationId = locum;
                    }
                }
                bool active = false;
                if (cptDept.Active != null && cptDept.Active.ToLower() == "yes") {
                    active = true;
                }
                string sortNumber = "";
                if (cptDept.SortNumber != null) {
                    sortNumber = cptDept.SortNumber;
                } // max size here is 3. it is a number in string form.

                var invList = ffpmDbContext.CptDepartments.FirstOrDefault(x => x.Code == code);
                if (invList != null) {
                    invList.Description = description;
                    invList.LocationId = locationId;
                    invList.Active = active;
                    invList.SortNumber = sortNumber;
                    ffpmDbContext.SaveChanges();
                    return;
                }



                var newCptDept = new Brady_s_Conversion_Program.ModelsA.CptDepartment {
                    Code = code,
                    Description = description,
                    LocationId = locationId,
                    Active = active,
                    SortNumber = sortNumber
                };
                ffpmDbContext.CptDepartments.Add(newCptDept);

                ffpmDbContext.SaveChanges();
            }
            catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the CPT Dept with ID {cptDept.Id}. Error: {e.Message}");
            }
        }

        public static void CPTMappingConvert(CptMapping cptMapping, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? cptId = null;
                if (cptMapping.CptId != null) {
                    if (int.TryParse(cptMapping.CptId, out int locum)) {
                        cptId = locum;
                    }
                }
                int? groupId = null;
                if (cptMapping.GroupId != null) {
                    if (int.TryParse(cptMapping.GroupId, out int locum)) {
                        groupId = locum;
                    }
                }
                int? locationId = null;
                if (cptMapping.LocationId != null) {
                    if (int.TryParse(cptMapping.LocationId, out int locum)) {
                        locationId = locum;
                    }
                }
                bool? Active = null;
                if (cptMapping.Active != null && cptMapping.Active.ToLower() == "yes") {
                    Active = true;
                }
                else if (cptMapping.Active != null && cptMapping.Active.ToLower() == "no") {
                    Active = false;
                }

                var invList = ffpmDbContext.CptGroupMappings.FirstOrDefault(x => x.CptId == cptId && x.GroupId == groupId);
                if (invList != null) {
                    invList.LocationId = locationId;
                    invList.Active = Active;
                    ffpmDbContext.SaveChanges();
                    return;
                }



                var newCptMapping = new Brady_s_Conversion_Program.ModelsA.CptGroupMapping {
                    CptId = cptId,
                    GroupId = groupId,
                    LocationId = locationId,
                    Active = Active                    
                };
                ffpmDbContext.CptGroupMappings.Add(newCptMapping);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the CPT Mapping with ID {cptMapping.Id}. Error: {e.Message}");
            }
        }

        public static void CPTConvert(Cpt cpt, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? sortOrder = null;
                if (cpt.SortOrder != null) {
                    if (int.TryParse(cpt.SortOrder, out int locum)) {
                        sortOrder = locum;
                    }
                }
                bool? active = null;
                if (cpt.Active != null && cpt.Active.ToLower() == "yes") {
                    active = true;
                }
                else if (cpt.Active != null && cpt.Active.ToLower() == "no") {
                    active = false;
                }
                long? locationId = null;
                if (cpt.LocationId != null) {
                    if (long.TryParse(cpt.LocationId, out long locum)) {
                        locationId = locum;
                    }
                }
                decimal? fee = null;
                if (cpt.Fee != null) {
                    if (decimal.TryParse(cpt.Fee, out decimal locum)) {
                        fee = locum;
                    }
                }
                bool taxable = false;
                if (cpt.Taxable != null && cpt.Taxable.ToLower() == "yes") {
                    taxable = true;
                }
                int departmentId = -1;
                if (cpt.DepartmentId != null) {
                    if (int.TryParse(cpt.DepartmentId, out int locum)) {
                        departmentId = locum;
                    }
                }
                int typeOfServiceId = -1;
                if (cpt.TypeOfServiceId != null) {
                    if (int.TryParse(cpt.TypeOfServiceId, out int locum)) {
                        typeOfServiceId = locum;
                    }
                }
                int taxTypeId = -1;
                if (cpt.TaxTypeId != null) {
                    if (int.TryParse(cpt.TaxTypeId, out int locum)) {
                        taxTypeId = locum;
                    }
                }
                bool useCliaNumber = false;
                if (cpt.UseClianumber != null && cpt.UseClianumber.ToLower() == "yes") {
                    useCliaNumber = true;
                }
                int units = -1;
                if (cpt.Units != null) {
                    if (int.TryParse(cpt.Units, out int locum)) {
                        units = locum;
                    }
                }
                bool ndcActive = false;
                if (cpt.NdcActive != null && cpt.NdcActive.ToLower() == "yes") {
                    ndcActive = true;
                }
                decimal? ndcCost = null;
                if (cpt.NdcCost != null) {
                    if (decimal.TryParse(cpt.NdcCost, out decimal locum)) {
                        ndcCost = locum;
                    }
                }
                int? ndcUnitsMeasurementId = null;
                if (cpt.NdcUnitsMeasurementId != null) {
                    if (int.TryParse(cpt.NdcUnitsMeasurementId, out int locum)) {
                        ndcUnitsMeasurementId = locum;
                    }
                }
                decimal? ndcQuantity = null;
                if (cpt.NdcQuantity != null) {
                    if (decimal.TryParse(cpt.NdcQuantity, out decimal locum)) {
                        ndcQuantity = locum;
                    }
                }
                bool autoUpdateReferringProvider = false;
                if (cpt.AutoUpdateReferringProvider != null && cpt.AutoUpdateReferringProvider.ToLower() == "yes") {
                    autoUpdateReferringProvider = true;
                }
                string privateStatementDescription = "";
                if (cpt.PrivateStatementDescription != null) {
                    privateStatementDescription = cpt.PrivateStatementDescription;
                }
                string alternateCode = "";
                if (cpt.AlternateCode != null) {
                    alternateCode = cpt.AlternateCode;
                }

                var invList = ffpmDbContext.Cptids.FirstOrDefault(x => x.Cpt == cpt.Cpt1);
                if (invList != null) {
                    invList.Description = cpt.Description;
                    invList.SortOrder = sortOrder;
                    invList.Active = active;
                    invList.LocationId = locationId;
                    invList.Fee = fee;
                    invList.Taxable = taxable;
                    invList.DepartmentId = departmentId;
                    invList.TypeOfServiceId = typeOfServiceId;
                    invList.TaxTypeId = taxTypeId;
                    invList.PrivateStatementDescription = privateStatementDescription;
                    invList.AlternateCode = alternateCode;
                    invList.UseClianumber = useCliaNumber;
                    invList.Units = units;
                    invList.NdcActive = ndcActive;
                    invList.NdcCost = ndcCost;
                    invList.NdcCode = cpt.NdcCode;
                    invList.NdcUnitsMeasurementId = ndcUnitsMeasurementId;
                    invList.NdcQuantity = ndcQuantity;
                    invList.AutoUpdateReferringProvider = autoUpdateReferringProvider;
                    ffpmDbContext.SaveChanges();
                    return;
                }



                var newCpt = new Brady_s_Conversion_Program.ModelsA.Cptid {
                    Cpt = cpt.Cpt1, // what is the 1 for? is it because it is the same name as the table?
                    Description = cpt.Description,
                    SortOrder = sortOrder,
                    Active = active,
                    LocationId = locationId,
                    Fee = fee,
                    Taxable = taxable,
                    DepartmentId = departmentId,
                    TypeOfServiceId = typeOfServiceId,
                    TaxTypeId = taxTypeId,
                    PrivateStatementDescription = privateStatementDescription,
                    AlternateCode = alternateCode,
                    UseClianumber = useCliaNumber,
                    Units = units,
                    NdcActive = ndcActive,
                    NdcCost = ndcCost,
                    NdcCode = cpt.NdcCode,
                    NdcUnitsMeasurementId = ndcUnitsMeasurementId,
                    NdcQuantity = ndcQuantity,
                    AutoUpdateReferringProvider = autoUpdateReferringProvider
                };
                ffpmDbContext.Cptids.Add(newCpt);

                ffpmDbContext.SaveChanges();
            }
            catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the CPT with ID {cpt.Id}. Error: {e.Message}");
            }
        }

        public static void FrameCategoryConvert(ModelsD.FrameCategory frameCategory, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                string categoryName = "";
                if (frameCategory.CategoryName != null) {
                    categoryName = frameCategory.CategoryName;
                }
                bool? active = null;
                if (frameCategory.Active != null && frameCategory.Active.ToLower() == "yes") {
                    active = true;
                }
                else if (frameCategory.Active != null && frameCategory.Active.ToLower() == "no") {
                    active = false;
                }
                long sortOrder = -1;
                if (frameCategory.SortOrder != null) {
                    if (long.TryParse(frameCategory.SortOrder, out long locum)) {
                        sortOrder = locum;
                    }
                }
                long? locationId = null;
                if (frameCategory.LocationId != null) {
                    if (long.TryParse(frameCategory.LocationId, out long locum)) {
                        locationId = locum;
                    }
                }

                var invList = ffpmDbContext.FrameCategories.FirstOrDefault(x => x.CategoryName == categoryName);
                if (invList != null) {
                    invList.CategoryDescription = frameCategory.CategoryDescription;
                    invList.Active = active;
                    invList.SortOrder = sortOrder;
                    invList.LocationId = locationId;
                    ffpmDbContext.SaveChanges();
                    return;
                }


                var newFrameCategory = new Brady_s_Conversion_Program.ModelsA.FrameCategory {
                    CategoryName = categoryName,
                    CategoryDescription = frameCategory.CategoryDescription,
                    Active = active,
                    SortOrder = sortOrder,
                    LocationId = locationId
                };
                ffpmDbContext.FrameCategories.Add(newFrameCategory);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the Frame Category with ID {frameCategory.Id}. Error: {e.Message}");
            }
        }

        public static void FrameCollectionConvert(ModelsD.FrameCollection frameCollection, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                string collectionName = "";
                if (frameCollection.CollectionName != null) {
                    collectionName = frameCollection.CollectionName;
                }
                bool active = false;
                if (frameCollection.Active != null && frameCollection.Active.ToLower() == "yes") {
                    active = true;
                }
                long locationId = -1;
                if (frameCollection.LocationId != null) {
                    if (long.TryParse(frameCollection.LocationId, out long locum)) {
                        locationId = locum;
                    }
                }

                var invList = ffpmDbContext.FrameCollections.FirstOrDefault(x => x.CollectionName == collectionName);
                if (invList != null) {
                    invList.Active = active;
                    invList.LocationId = locationId;
                    ffpmDbContext.SaveChanges();
                    return;
                }



                var newFrameCollection = new Brady_s_Conversion_Program.ModelsA.FrameCollection {
                    CollectionName = collectionName,
                    Active = active,
                    LocationId = locationId
                };
                ffpmDbContext.FrameCollections.Add(newFrameCollection);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the Frame Collection with ID {frameCollection.Id}. Error: {e.Message}");
            }
        }

        public static void FrameColorConvert(ModelsD.FrameColor frameColor, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                bool active = false;
                if (frameColor.Active != null && frameColor.Active.ToLower() == "yes") {
                    active = true;
                }
                long locationId = -1;
                if (frameColor.LocationId != null) {
                    if (long.TryParse(frameColor.LocationId, out long locum)) {
                        locationId = locum;
                    }
                }

                var invList = ffpmDbContext.FrameColors.FirstOrDefault(x => x.ColorCode == frameColor.ColorCode);
                if (invList != null) {
                    invList.ColorDescription = frameColor.ColorDescription;
                    invList.Active = active;
                    invList.LocationId = locationId;
                    ffpmDbContext.SaveChanges();
                    return;
                }



                var newFrameColor = new Brady_s_Conversion_Program.ModelsA.FrameColor {
                    ColorCode = frameColor.ColorCode,
                    ColorDescription = frameColor.ColorDescription,
                    Active = active,
                    LocationId = locationId
                };
                ffpmDbContext.FrameColors.Add(newFrameColor);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the Frame Color with ID {frameColor.Id}. Error: {e.Message}");
            }
        }

        public static void FrameShapeConvert(ModelsD.FrameShape frameShape, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                string shape = "";
                if (frameShape.FrameShape1 != null) {
                    shape = frameShape.FrameShape1;
                }
                bool active = false;
                if (frameShape.Active != null && frameShape.Active.ToLower() == "yes") {
                    active = true;
                }
                long sortOrder = -1;
                if (frameShape.SortOrder != null) {
                    if (long.TryParse(frameShape.SortOrder, out long locum)) {
                        sortOrder = locum;
                    }
                }
                long? locationId = null;
                if (frameShape.LocationId != null) {
                    if (long.TryParse(frameShape.LocationId, out long locum)) {
                        locationId = locum;
                    }
                }

                var invList = ffpmDbContext.FrameShapes.FirstOrDefault(x => x.FrameShape1 == shape);
                if (invList != null) {
                    invList.ShapeDescription = frameShape.ShapeDescription;
                    invList.Active = active;
                    invList.SortOrder = sortOrder;
                    invList.LocationId = locationId;
                    ffpmDbContext.SaveChanges();
                    return;
                }



                var newFrameShape = new Brady_s_Conversion_Program.ModelsA.FrameShape {
                    FrameShape1 = shape,
                    ShapeDescription = frameShape.ShapeDescription,
                    Active = active,
                    SortOrder = sortOrder,
                    LocationId = locationId
                };
                ffpmDbContext.FrameShapes.Add(newFrameShape);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the Frame Shape with ID {frameShape.Id}. Error: {e.Message}");
            }
        }

        public static void FrameStatusConvert(ModelsD.FrameStatus frameStatus, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                string status = "";
                if (frameStatus.StatusId != null) {
                    status = frameStatus.StatusId;
                }

                var invList = ffpmDbContext.FrameStatuses.FirstOrDefault(x => x.Status == status);
                if (invList != null) {
                    invList.Description = frameStatus.Description;
                    invList.LabCode = frameStatus.LabCode;
                    ffpmDbContext.SaveChanges();
                    return;
                }



                var newFrameStatus = new Brady_s_Conversion_Program.ModelsA.FrameStatus {
                    Status = status,
                    Description = frameStatus.Description,
                    LabCode = frameStatus.LabCode
                };
                ffpmDbContext.FrameStatuses.Add(newFrameStatus);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the Frame Status with ID {frameStatus.Id}. Error: {e.Message}");
            }
        }

        public static void FrameTempleConvert(ModelsD.FrameTemple frameTemple, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                string temple = "";
                if (frameTemple.TempleId != null) {
                    temple = frameTemple.TempleId;
                }

                var invList = ffpmDbContext.FrameTempleStyles.FirstOrDefault(x => x.Temple == temple);
                if (invList != null) {
                    invList.Description = frameTemple.Description;
                    invList.LabCode = frameTemple.LabCode;
                    ffpmDbContext.SaveChanges();
                    return;
                }



                var newFrameTemple = new Brady_s_Conversion_Program.ModelsA.FrameTempleStyle {
                    Temple = temple,
                    Description = frameTemple.Description,
                    LabCode = frameTemple.LabCode
                };
                ffpmDbContext.FrameTempleStyles.Add(newFrameTemple);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the Frame Temple with ID {frameTemple.Id}. Error: {e.Message}");
            }
        }

        public static void FrameETypeConvert(ModelsD.FrameEtype frameEType, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                string eType = "";
                if (frameEType.EtypeId != null) {
                    eType = frameEType.EtypeId;
                }

                var invList = ffpmDbContext.FrameEtypes.FirstOrDefault(x => x.Etype == eType);
                if (invList != null) {
                    invList.Description = frameEType.Description;
                    invList.LabCode = frameEType.LabCode;
                    ffpmDbContext.SaveChanges();
                    return;
                }



                var newFrameEType = new Brady_s_Conversion_Program.ModelsA.FrameEtype {
                    Etype = eType,
                    Description = frameEType.Description,
                    LabCode = frameEType.LabCode
                };
                ffpmDbContext.FrameEtypes.Add(newFrameEType);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the Frame EType with ID {frameEType.Id}. Error: {e.Message}");
            }
        }

        public static void FrameFTypeConvert(ModelsD.FrameFtype frameFType, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                string fType = "";
                if (frameFType.FtypeId != null) {
                    fType = frameFType.FtypeId;
                }

                var invList = ffpmDbContext.FrameFtypes.FirstOrDefault(x => x.Ftype == fType);
                if (invList != null) {
                    invList.Description = frameFType.Description;
                    invList.LabCode = frameFType.LabCode;
                    ffpmDbContext.SaveChanges();
                    return;
                }



                var newFrameFType = new Brady_s_Conversion_Program.ModelsA.FrameFtype {
                    Ftype = fType,
                    Description = frameFType.Description,
                    LabCode = frameFType.LabCode
                };
                ffpmDbContext.FrameFtypes.Add(newFrameFType);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the Frame FType with ID {frameFType.Id}. Error: {e.Message}");
            }
        }

        public static void FrameLensColorConvert(ModelsD.FrameLensColor frameLensColor, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                string colorCode = "";
                if (frameLensColor.ColorCode != null) {
                    colorCode = frameLensColor.ColorCode;
                }
                string colorDescription = "";
                if (frameLensColor.ColorDescription != null) {
                    colorDescription = frameLensColor.ColorDescription;
                }
                int statusId = -1;
                if (frameLensColor.StatusId != null) {
                    if (int.TryParse(frameLensColor.StatusId, out int locum)) {
                        statusId = locum;
                    }
                }
                long locationId = -1;
                if (frameLensColor.LocationId != null) {
                    if (long.TryParse(frameLensColor.LocationId, out long locum)) {
                        locationId = locum;
                    }
                }

                var invList = ffpmDbContext.FrameDblensColors.FirstOrDefault(x => x.ColorCode == colorCode);
                if (invList != null) {
                    invList.ColorDescription = colorDescription;
                    invList.StatusId = statusId;
                    invList.LocationId = locationId;
                    ffpmDbContext.SaveChanges();
                    return;
                }



                var newFrameLensColor = new Brady_s_Conversion_Program.ModelsA.FrameDblensColor {
                    ColorCode = colorCode,
                    ColorDescription = colorDescription,
                    StatusId = statusId,
                    LocationId = locationId
                };
                ffpmDbContext.FrameDblensColors.Add(newFrameLensColor);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the Frame Lens Color with ID {frameLensColor.Id}. Error: {e.Message}");
            }
        }

        public static void FrameMaterialConvert(ModelsD.FrameMaterial frameMaterial, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                string materialName = "";
                if (frameMaterial.MaterialName != null) {
                    materialName = frameMaterial.MaterialName;
                }
                bool active = false;
                if (frameMaterial.Active != null && frameMaterial.Active.ToLower() == "yes") {
                    active = true;
                }
                long sortOrder = -1;
                if (frameMaterial.SortOrder != null) {
                    if (long.TryParse(frameMaterial.SortOrder, out long locum)) {
                        sortOrder = locum;
                    }
                }
                long locationId = -1;
                if (frameMaterial.LocationId != null) {
                    if (long.TryParse(frameMaterial.LocationId, out long locum)) {
                        locationId = locum;
                    }
                }

                var invList = ffpmDbContext.FrameMaterials.FirstOrDefault(x => x.MaterialName == materialName);
                if (invList != null) {
                    invList.MaterialDescription = frameMaterial.MaterialDescription;
                    invList.Active = active;
                    invList.SortOrder = sortOrder;
                    invList.LocationId = locationId;
                    ffpmDbContext.SaveChanges();
                    return;
                }



                var newFrameMaterial = new Brady_s_Conversion_Program.ModelsA.FrameMaterial {
                    MaterialName = materialName,
                    MaterialDescription = frameMaterial.MaterialDescription,
                    Active = active,
                    SortOrder = sortOrder,
                    LocationId = locationId
                };
                ffpmDbContext.FrameMaterials.Add(newFrameMaterial);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the Frame Material with ID {frameMaterial.Id}. Error: {e.Message}");
            }
        }

        public static void FrameMountConvert(ModelsD.FrameMount frameMount, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                string frameMount1 = "";
                if (frameMount.FrameMount1 != null) {
                    frameMount1 = frameMount.FrameMount1;
                }
                bool active = false;
                if (frameMount.Active != null && frameMount.Active.ToLower() == "yes") {
                    active = true;
                }
                long sortOrder = -1;
                if (frameMount.SortOrder != null) {
                    if (long.TryParse(frameMount.SortOrder, out long locum)) {
                        sortOrder = locum;
                    }
                }
                long locationId = -1;
                if (frameMount.LocationId != null) {
                    if (long.TryParse(frameMount.LocationId, out long locum)) {
                        locationId = locum;
                    }
                }

                var invList = ffpmDbContext.FrameMounts.FirstOrDefault(x => x.FrameMount1 == frameMount1);
                if (invList != null) {
                    invList.MountDescription = frameMount.MountDescription;
                    invList.Active = active;
                    invList.SortOrder = sortOrder;
                    invList.LocationId = locationId;
                    ffpmDbContext.SaveChanges();
                    return;
                }



                var newFrameMount = new Brady_s_Conversion_Program.ModelsA.FrameMount {
                    FrameMount1 = frameMount1,
                    MountDescription = frameMount.MountDescription,
                    Active = active,
                    SortOrder = sortOrder,
                    LocationId = locationId
                };
                ffpmDbContext.FrameMounts.Add(newFrameMount);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the Frame Mount with ID {frameMount.Id}. Error: {e.Message}");
            }
        }

        public static void FrameOrderConvert(ModelsD.FrameOrder frameOrder, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                string name = "";
                if (frameOrder.Name != null) {
                    name = frameOrder.Name;
                }
                int materialId = -1;
                if (frameOrder.MaterialId != null) {
                    if (int.TryParse(frameOrder.MaterialId, out int locum)) {
                        materialId = locum;
                    }
                }
                int statusId = -1;
                if (frameOrder.StatusId != null) {
                    if (int.TryParse(frameOrder.StatusId, out int locum)) {
                        statusId = locum;
                    }
                }
                int cptId = -1;
                if (frameOrder.CptId != null) {
                    if (int.TryParse(frameOrder.CptId, out int locum)) {
                        cptId = locum;
                    }
                }
                int eTypId = -1;
                if (frameOrder.EtypId != null) {
                    if (int.TryParse(frameOrder.EtypId, out int locum)) {
                        eTypId = locum;
                    }
                }
                int fTypId = -1;
                if (frameOrder.FtypId != null) {
                    if (int.TryParse(frameOrder.FtypId, out int locum)) {
                        fTypId = locum;
                    }
                }
                string color = "";
                if (frameOrder.Color != null) {
                    color = frameOrder.Color;
                }
                long manufacturerId = -1;
                if (frameOrder.ManufacturerId != null) {
                    if (long.TryParse(frameOrder.ManufacturerId, out long locum)) {
                        manufacturerId = locum;
                    }
                }
                int eye = -1;
                if (frameOrder.Eye != null) {
                    if (int.TryParse(frameOrder.Eye, out int locum)) {
                        eye = locum;
                    }
                }
                int bridge = -1;
                if (frameOrder.Bridge != null) {
                    if (int.TryParse(frameOrder.Bridge, out int locum)) {
                        bridge = locum;
                    }
                }
                decimal a = -1;
                if (frameOrder.A != null) {
                    if (decimal.TryParse(frameOrder.A, out decimal locum)) {
                        a = locum;
                    }
                }
                decimal b = -1;
                if (frameOrder.B != null) {
                    if (decimal.TryParse(frameOrder.B, out decimal locum)) {
                        b = locum;
                    }
                }
                decimal ed = -1;   
                if (frameOrder.Ed != null) {
                    if (decimal.TryParse(frameOrder.Ed, out decimal locum)) {
                        ed = locum;
                    }
                }
                decimal dbl = -1;
                if (frameOrder.Dbl != null) {
                    if (decimal.TryParse(frameOrder.Dbl, out decimal locum)) {
                        dbl = locum;
                    }
                }
                decimal cSize = -1;
                if (frameOrder.Csize != null) {
                    if (decimal.TryParse(frameOrder.Csize, out decimal locum)) {
                        cSize = locum;
                    }
                }
                int templeSize = -1;
                if (frameOrder.TempleSize != null) {
                    if (int.TryParse(frameOrder.TempleSize, out int locum)) {
                        templeSize = locum;
                    }
                }
                int templeStyleId = -1;
                if (frameOrder.TempleStyleId != null) {
                    if (int.TryParse(frameOrder.TempleStyleId, out int locum)) {
                        templeStyleId = locum;
                    }
                }
                decimal retail = -1;
                if (frameOrder.Retail != null) {
                    if (decimal.TryParse(frameOrder.Retail, out decimal locum)) {
                        retail = locum;
                    }
                }
                long inventoryId = -1;
                if (frameOrder.InventoryId != null) {
                    if (long.TryParse(frameOrder.InventoryId, out long locum)) {
                        inventoryId = locum;
                    }
                }
                bool isLmsFrame = false;
                if (frameOrder.IsLmsframe != null && frameOrder.IsLmsframe.ToLower() == "yes") {
                    isLmsFrame = true;
                }

                // since it is orders, there can be multiple that are the exact same
                // because of this, I wont check for duplicate orders



                var newFrameOrder = new Brady_s_Conversion_Program.ModelsA.FrameOrderInfo {
                    Name = name,
                    MaterialId = materialId,
                    StatusId = statusId,
                    CptId = cptId,
                    EtypId = eTypId,
                    FtypId = fTypId,
                    Color = color,
                    ManufacturerId = manufacturerId,
                    Eye = eye,
                    Bridge = bridge,
                    A = a,
                    B = b,
                    Ed = ed,
                    Dbl = dbl,
                    Csize = cSize,
                    TempleSize = templeSize,
                    TempleStyleId = templeStyleId,
                    Retail = retail,
                    InventoryId = inventoryId,
                    IsLmsframe = isLmsFrame
                };
                ffpmDbContext.FrameOrderInfos.Add(newFrameOrder);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the Frame Order with ID {frameOrder.Id}. Error: {e.Message}");
            }
        }

        public static void FrameConvert(ModelsD.Frame frame, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try { 
                string upc = "";
                if (frame.Upc != null) {
                    upc = frame.Upc;
                }
                int styleId = -1;
                if (frame.StyleId != null) {
                    if (int.TryParse(frame.StyleId, out int locum)) {
                        styleId = locum;
                    }
                }
                int? eye = null;
                if (frame.Eye != null) {
                    if (int.TryParse(frame.Eye, out int locum)) {
                        eye = locum;
                    }
                }
                int? bridge = null;
                if (frame.Bridge != null) {
                    if (int.TryParse(frame.Bridge, out int locum)) {
                        bridge = locum;
                    }
                }
                int? temple = null;
                if (frame.Temple != null) {
                    if (int.TryParse(frame.Temple, out int locum)) {
                        temple = locum;
                    }
                }
                decimal? dbl = null;
                if (frame.Dbl != null) {
                    if (decimal.TryParse(frame.Dbl, out decimal locum)) {
                        dbl = locum;
                    }
                }
                decimal? a = null;
                if (frame.A != null) {
                    if (decimal.TryParse(frame.A, out decimal locum)) {
                        a = locum;
                    }
                }
                decimal? b = null;
                if (frame.B != null) {
                    if (decimal.TryParse(frame.B, out decimal locum)) {
                        b = locum;
                    }
                }
                decimal? ed = null;
                if (frame.Ed != null) {
                    if (decimal.TryParse(frame.Ed, out decimal locum)) {
                        ed = locum;
                    }
                }
                decimal? circumference = null;
                if (frame.Circumference != null) {
                    if (decimal.TryParse(frame.Circumference, out decimal locum)) {
                        circumference = locum;
                    }
                }
                decimal? edAngle = null;
                if (frame.Edangle != null) {
                    if (decimal.TryParse(frame.Edangle, out decimal locum)) {
                        edAngle = locum;
                    }
                }
                decimal? frontPrice = null;
                if (frame.FrontPrice != null) {
                    if (decimal.TryParse(frame.FrontPrice, out decimal locum)) {
                        frontPrice = locum;
                    }
                }
                decimal? halfTemplesPrice = null;
                if (frame.HalfTemplesPrice != null) {
                    if (decimal.TryParse(frame.HalfTemplesPrice, out decimal locum)) {
                        halfTemplesPrice = locum;
                    }
                }
                decimal? templesPrice = null;
                if (frame.TemplesPrice != null) {
                    if (decimal.TryParse(frame.TemplesPrice, out decimal locum)) {
                        templesPrice = locum;
                    }
                }
                decimal? completePrice = null;
                if (frame.CompletePrice != null) {
                    if (decimal.TryParse(frame.CompletePrice, out decimal locum)) {
                        completePrice = locum;
                    }
                }
                bool? styleNew = null;
                if (frame.StyleNew != null && frame.StyleNew.ToLower() == "yes") {
                    styleNew = true;
                } else if (frame.StyleNew != null && frame.StyleNew.ToLower() == "no") {
                    styleNew = false;
                }
                bool? changedPrice = null;
                if (frame.ChangedPrice != null && frame.ChangedPrice.ToLower() == "yes") {
                    changedPrice = true;
                } else if (frame.ChangedPrice != null && frame.ChangedPrice.ToLower() == "no") {
                    changedPrice = false;
                }
                long? manufacturerId = null;
                if (frame.ManufacturerId != null) {
                    if (long.TryParse(frame.ManufacturerId, out long locum)) {
                        manufacturerId = locum;
                    }
                }
                long? vendorId = null;
                if (frame.VendorId != null) {
                    if (long.TryParse(frame.VendorId, out long locum)) {
                        vendorId = locum;
                    }
                }
                long? brandId = null;
                if (frame.BrandId != null) {
                    if (long.TryParse(frame.BrandId, out long locum)) {
                        brandId = locum;
                    }
                }
                long? collectionId = null;
                if (frame.CollectionId != null) {
                    if (long.TryParse(frame.CollectionId, out long locum)) {
                        collectionId = locum;
                    }
                }
                int? frameCategoryId = null;
                if (frame.FrameCategoryId != null) {
                    if (int.TryParse(frame.FrameCategoryId, out int locum)) {
                        frameCategoryId = locum;
                    }
                }
                int? frameShapeId = null;
                if (frame.FrameShapeId != null) {
                    if (int.TryParse(frame.FrameShapeId, out int locum)) {
                        frameShapeId = locum;
                    }
                }
                int? materialId = null;
                if (frame.MaterialId != null) {
                    if (int.TryParse(frame.MaterialId, out int locum)) {
                        materialId = locum;
                    }
                }
                int? frameMountId = null;
                if (frame.FrameMountId != null) {
                    if (int.TryParse(frame.FrameMountId, out int locum)) {
                        frameMountId = locum;
                    }
                }
                long? frameColorId = null;
                if (frame.FrameColorId != null) {
                    if (long.TryParse(frame.FrameColorId, out long locum)) {
                        frameColorId = locum;
                    }
                }
                long? lensColorId = null;
                if (frame.LensColorId != null) {
                    if (long.TryParse(frame.LensColorId, out long locum)) {
                        lensColorId = locum;
                    }
                }
                int? genderId = null;
                if (frame.GenderId != null) {
                    if (int.TryParse(frame.GenderId, out int locum)) {
                        genderId = locum;
                    }
                }
                long? countryId = null;
                if (frame.CountryId != null) {
                    if (long.TryParse(frame.CountryId, out long locum)) {
                        countryId = locum;
                    }
                }
                int? ageGroupId = null;
                if (frame.AgeGroupId != null) {
                    if (int.TryParse(frame.AgeGroupId, out int locum)) {
                        ageGroupId = locum;
                    }
                }
                long? locationId = null;
                if (frame.LocationId != null) {
                    if (long.TryParse(frame.LocationId, out long locum)) {
                        locationId = locum;
                    }
                }
                int? cptid = null;
                if (frame.Cptid != null) {
                    if (int.TryParse(frame.Cptid, out int locum)) {
                        cptid = locum;
                    }
                }
                bool? active = null;
                if (frame.Active != null && frame.Active.ToLower() == "yes") {
                    active = true;
                } else if (frame.Active != null && frame.Active.ToLower() == "no") {
                    active = false;
                }
                DateTime? dateAdded = null;
                if (frame.DateAdded != null) {
                    if (DateTime.TryParse(frame.DateAdded, out DateTime locum)) {
                        dateAdded = locum;
                    }
                }
                DateTime? lastUpdated = null;
                if (frame.LastUpdated != null) {
                    if (DateTime.TryParse(frame.LastUpdated, out DateTime locum)) {
                        lastUpdated = locum;
                    }
                }

                // how do we know if a frame is a duplicate?

            
            
            
                var newFrame = new Brady_s_Conversion_Program.ModelsA.Frame {
                    Fpc = frame.Fpc,
                    Upc = upc,
                    StyleId = styleId,
                    StyleName = frame.StyleName,
                    Eye = eye,
                    Bridge = bridge,
                    Temple = temple,
                    Dbl = dbl,
                    A = a,
                    B = b,
                    Ed = ed,
                    Circumference = circumference,
                    Edangle = edAngle,
                    FrontPrice = frontPrice,
                    HalfTemplesPrice = halfTemplesPrice,
                    TemplesPrice = templesPrice,
                    CompletePrice = completePrice,
                    StyleNew = styleNew,
                    ChangedPrice = changedPrice,
                    Sku = frame.Sku,
                    YearIntroduced = frame.YearIntroduced,
                    ManufacturerId = manufacturerId,
                    VendorId = vendorId,
                    BrandId = brandId,
                    CollectionId = collectionId,
                    FrameCategoryId = frameCategoryId,
                    FrameShapeId = frameShapeId,
                    MaterialId = materialId,
                    FrameMountId = frameMountId,
                    FrameColorId = frameColorId,
                    LensColorId = lensColorId,
                    GenderId = genderId,
                    CountryId = countryId,
                    AgeGroupId = ageGroupId,
                    LocationId = locationId,
                    Cptid = cptid,
                    Active = active,
                    DateAdded = dateAdded,
                    LastUpdated = lastUpdated
                };
                ffpmDbContext.Frames.Add(newFrame);

                ffpmDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the Frame with ID {frame.Id}. Error: {e.Message}");
            }
        }
        
        #endregion InvConversion
    }
}
