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
                            eyeMDDbContext.Database.OpenConnection();
                            ConvertEyeMD(eHRDbContext, eyeMDDbContext, logger, progress);
                            eyeMDDbContext.SaveChanges();
                        }
                    }
                    completeConnection += "EyeMD Conversion Successful\n";
                }

                if (inv == true) {
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

            foreach (Allergy allergy in eHRDbContext.Allergies.ToList()) {
                AllergiesConvert(allergy, eyeMDDbContext, logger, progress);
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
                var newPatient = new Brady_s_Conversion_Program.ModelsB.Emrpatient {
                    // data here
                    // I will actually wait to do this until I know all of the data that is moved on the ffpm interface
                };
                eyeMDDbContext.Emrpatients.Add(newPatient);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the patient with ID: {patient.Id}. Error: {e.Message}");
            }
        }

        public static void MedicalHistoriesConvert(ModelsC.MedicalHistory medicalHistory, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                int? patientID = null;
                if (medicalHistory.PtId != null) {
                    patientID = int.Parse(medicalHistory.PtId);
                } else {
                    logger.Log($"EHR: EHR Patient ID not found for medical history with ID: {medicalHistory.Id}");
                    return;
                }
                var eyeMDPatient = eyeMDDbContext.Emrpatients.Find(patientID);
                if (eyeMDPatient == null) {
                    logger.Log($"EHR: EHR Patient not found for medical history with ID: {medicalHistory.Id}");
                    return;
                }

                int? visitId = null;
                if (medicalHistory.VisitId != null) {
                    if (int.TryParse(medicalHistory.VisitId, out int locum)) {
                        visitId = locum;
                    }
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
                string insertGUID = "";
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


                var newMedicalHistory = new Brady_s_Conversion_Program.ModelsB.EmrvisitMedicalHistory {
                    PtId = eyeMDPatient.PtId,
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
                    LastModifiedEmpId = lastModifiedEmpId
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
                var newAllergyList = new Brady_s_Conversion_Program.ModelsB.EmrallergyList {
                    // Tables dont match very well
                };
                eyeMDDbContext.EmrallergyLists.Add(newAllergyList);

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
                string insertGUID = "";
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
                    TabDrawing = tabDrawing
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
                } else if (ptId == null) {
                    var eydMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eydMDVisit == null) {
                        logger.Log($"EHR: EHR Visit not found for visit order with ID: {visitOrder.Id}");
                    }
                } else if (visitId == null) {
                    var eyeMDPatient = eyeMDDbContext.Emrpatients.Find(ptId);
                    if (eyeMDPatient == null) {
                        logger.Log($"EHR: EHR Patient not found for visit order with ID: {visitOrder.Id}");
                    }
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
                string insertGUID = ""; // This looks like it is supposed to be some large string. I don't see where it is coming from
                
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
                    var eydMDVisit = eyeMDDbContext.Emrvisits.Find(visitId);
                    if (eydMDVisit == null) {
                        logger.Log($"EHR: EHR Visit not found for visit order with ID: {visitDoctor.Id}");
                    }
                }
                else if (visitId == null) {
                    var eyeMDPatient = eyeMDDbContext.Emrpatients.Find(ptId);
                    if (eyeMDPatient == null) {
                        logger.Log($"EHR: EHR Patient not found for visit order with ID: {visitDoctor.Id}");
                    }
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
                    SentToWebPortalDays = sentToWebPortalDays
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
                var newAppointment = new Brady_s_Conversion_Program.ModelsB.Emrappt {
                    // data here
                };
                eyeMDDbContext.Emrappts.Add(newAppointment);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the appointment with ID: {appointment.Id}. Error: {e.Message}");
            }
        }

        public static void ContactLensesConvert(ModelsC.ContactLen contactLens, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                var newContactLens = new Brady_s_Conversion_Program.ModelsB.EmrvisitContactLense {
                    // data here
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
                var newDiagCodePool = new Brady_s_Conversion_Program.ModelsB.EmrvisitDiagCodePool {
                    // data here
                };
                eyeMDDbContext.EmrvisitDiagCodePools.Add(newDiagCodePool);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the diag code pool with ID: {diagCodePool.Id}. Error: {e.Message}");
            }
        }

        public static void DiagTestsConvert(ModelsC.DiagTest diagTest, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                var newDiagTest = new Brady_s_Conversion_Program.ModelsB.EmrvisitDiagTest {
                    // data here
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
                var newExamCondition = new Brady_s_Conversion_Program.ModelsB.EmrvisitExamCondition {
                    // data here
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
                var newFamilyHistory = new Brady_s_Conversion_Program.ModelsB.EmrvisitFamilyHistory {
                    // data here
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
                var newIop = new Brady_s_Conversion_Program.ModelsB.EmrvisitIop {
                    // data here
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

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the patient document with ID: {patientDocument.Id}. Error: {e.Message}");
            }
        }

        public static void PatientNotesConvert(ModelsC.PatientNote patientNote, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                var newPatientNote = new Brady_s_Conversion_Program.ModelsB.EmrptNote {
                    // data here
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
                var newPlanNarrative = new Brady_s_Conversion_Program.ModelsB.EmrvisitPlanNarrative {
                    // data here
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
                var newProcDiagPool = new Brady_s_Conversion_Program.ModelsB.EmrvisitProcCodePoolDiag {
                    // data here
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
                var newProcPool = new Brady_s_Conversion_Program.ModelsB.EmrvisitProcCodePool {
                    // data here
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
                var newRefraction = new Brady_s_Conversion_Program.ModelsB.EmrvisitRefraction {
                    // data here
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
                var newRos = new Brady_s_Conversion_Program.ModelsB.Emrrosdefault {
                    // data here
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
                var newRx = new Brady_s_Conversion_Program.ModelsB.EmrvisitRxMedication {
                    // data here
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
                var newSurgHistory = new Brady_s_Conversion_Program.ModelsB.EmrvisitSurgicalHistory {
                    // data here
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
                var newTech = new Brady_s_Conversion_Program.ModelsB.EmrvisitTech {
                    // data here
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
                var newTech2 = new Brady_s_Conversion_Program.ModelsB.EmrvisitTech2 {
                    // data here
                };
                eyeMDDbContext.EmrvisitTech2s.Add(newTech2);

                eyeMDDbContext.SaveChanges();
            } catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the tech2 with ID: {tech2.Id}. Error: {e.Message}");
            }
        }
        #endregion EyeMDConversion
    }
}
