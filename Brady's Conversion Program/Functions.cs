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
            // Date-only formats
            "dd/MM/yyyy", "MM/dd/yyyy", "yyyy/MM/dd", "yyyy/dd/MM",
            "d/M/yyyy", "M/d/yyyy", "yyyy/M/d", "yyyy/d/M",
            "dd-MM-yyyy", "MM-dd-yyyy", "yyyy-MM-dd", "yyyy-dd-MM",
            "d-M-yyyy", "M-d-yyyy", "yyyy-M-d", "yyyy-d-M",
            "dd MM yyyy", "MM dd yyyy", "yyyy MM dd", "yyyy dd MM",
            "d M yyyy", "M d yyyy", "yyyy M d", "yyyy d M",
            "ddMMMyyyy", "MMMddyyyy",
            "dd MMM, yyyy", "MMM dd, yyyy",
            // Date with 24-hour time formats
            "dd/MM/yyyy HH:mm:ss", "MM/dd/yyyy HH:mm:ss", "yyyy/MM/dd HH:mm:ss", "yyyy/dd/MM HH:mm:ss",
            "d/M/yyyy HH:mm:ss", "M/d/yyyy HH:mm:ss", "yyyy/M/d HH:mm:ss", "yyyy/d/M HH:mm:ss",
            "dd-MM-yyyy HH:mm:ss", "MM-dd-yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss", "yyyy-dd-MM HH:mm:ss",
            "d-M-yyyy HH:mm:ss", "M-d-yyyy HH:mm:ss", "yyyy-M-d HH:mm:ss", "yyyy-d-M HH:mm:ss",
            "dd MM yyyy HH:mm:ss", "MM dd yyyy HH:mm:ss", "yyyy MM dd HH:mm:ss", "yyyy dd MM HH:mm:ss",
            "d M yyyy HH:mm:ss", "M d yyyy HH:mm:ss", "yyyy M d HH:mm:ss", "yyyy d M HH:mm:ss",
            "ddMMMyyyy HH:mm:ss", "MMMddyyyy HH:mm:ss",
            "dd MMM, yyyy HH:mm:ss", "MMM dd, yyyy HH:mm:ss",
            // Date with 12-hour time formats (AM/PM)
            "dd/MM/yyyy hh:mm:ss tt", "MM/dd/yyyy hh:mm:ss tt", "yyyy/MM/dd hh:mm:ss tt", "yyyy/dd/MM hh:mm:ss tt",
            "d/M/yyyy hh:mm:ss tt", "M/d/yyyy hh:mm:ss tt", "yyyy/M/d hh:mm:ss tt", "yyyy/d/M hh:mm:ss tt",
            "dd-MM-yyyy hh:mm:ss tt", "MM-dd-yyyy hh:mm:ss tt", "yyyy-MM-dd hh:mm:ss tt", "yyyy-dd-MM hh:mm:ss tt",
            "d-M-yyyy hh:mm:ss tt", "M-d-yyyy hh:mm:ss tt", "yyyy-M-d hh:mm:ss tt", "yyyy-d-M hh:mm:ss tt",
            "dd MM yyyy hh:mm:ss tt", "MM dd yyyy hh:mm:ss tt", "yyyy MM dd hh:mm:ss tt", "yyyy dd MM hh:mm:ss tt",
            "d M yyyy hh:mm:ss tt", "M d yyyy hh:mm:ss tt", "yyyy M d hh:mm:ss tt", "yyyy d M hh:mm:ss tt",
            "ddMMMyyyy hh:mm:ss tt", "MMMddyyyy hh:mm:ss tt",
            "dd MMM, yyyy hh:mm:ss tt", "MMM dd, yyyy hh:mm:ss tt"
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

        

        public static string ConvertToDB(string connection, string FFPMConnection, string EyeMDConnection, bool newFfpm, bool newEyemd) {
            try {
                ILogger logger = new FileLogger("../../../../LogFiles/log.txt");

                // Using block to ensure disposal of DbContexts
                using (var convDbContext = new FoxfireConvContext(connection)) {
                    // Start with FFPM only, do EyeMD later

                    convDbContext.Database.OpenConnection();
                    if (newFfpm) {
                        new FfpmContext(FFPMConnection).Database.EnsureCreated();
                    }
                    using (var ffpmDbContext = new FfpmContext(FFPMConnection)) {
                        ffpmDbContext.Database.OpenConnection();
                        ConvertFFPM(convDbContext, ffpmDbContext, logger);
                        ffpmDbContext.SaveChanges();
                    }
                    if (newEyemd) {
                        new EyeMdContext(EyeMDConnection).Database.EnsureCreated();
                    }
                    using (var eyeMDDbContext = new EyeMdContext(EyeMDConnection)) {
                        eyeMDDbContext.Database.OpenConnection();
                        ConvertEyeMD(convDbContext, eyeMDDbContext, logger);
                        eyeMDDbContext.SaveChanges();
                    } // Test comment for jira

                    convDbContext.SaveChanges();

                    // EF Core automatically handles connection closing when DbContext is disposed
                }
            }
            catch (Exception e) {
                return "Database Upload Failed.\n" + e + "\n";
            }
            return "Operation Successful";
        }

        public static void ConvertFFPM(FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            // Assuming PatientConvert now returns a patientNum
            foreach (var patient in convDbContext.Patients.ToList()) {
                PatientConvert(patient, convDbContext, ffpmDbContext, logger);
            }
            foreach (var accountXref in convDbContext.AccountXrefs.ToList()) {
                ConvertAccountXref(accountXref, convDbContext, ffpmDbContext, logger);
            }
            foreach (var address in convDbContext.Addresses.ToList()) {
                ConvertAddress(address, convDbContext, ffpmDbContext, logger);
            }
            foreach (var appointment in convDbContext.Appointments.ToList()) {
                ConvertAppointment(appointment, convDbContext, ffpmDbContext, logger);
            }
            foreach (var appointmentType in convDbContext.AppointmentTypes.ToList()) {
                ConvertAppointmentType(appointmentType, convDbContext, ffpmDbContext, logger);
            }
            foreach (var insurance in convDbContext.Insurances.ToList()) {
                ConvertInsurance(insurance, convDbContext, ffpmDbContext, logger);
            }
            foreach (var location in convDbContext.Locations.ToList()) {
                ConvertLocation(location, convDbContext, ffpmDbContext, logger);
            }
            foreach (var name in convDbContext.Names.ToList()) {
                ConvertName(name, convDbContext, ffpmDbContext, logger);
            }
            foreach (var patientAlert in convDbContext.PatientAlerts.ToList()) {
                ConvertPatientAlert(patientAlert, convDbContext, ffpmDbContext, logger);
            }
            foreach (var patientDocument in convDbContext.PatientDocuments.ToList()) {
                ConvertPatientDocument(patientDocument, convDbContext, ffpmDbContext, logger);
            }
            foreach (var patientInsurance in convDbContext.PatientInsurances.ToList()) {
                ConvertPatientInsurance(patientInsurance, convDbContext, ffpmDbContext, logger);
            }
            foreach (var patientNote in convDbContext.PatientNotes.ToList()) {
                ConvertPatientNote(patientNote, convDbContext, ffpmDbContext, logger);
            }
            foreach (var phone in convDbContext.Phones.ToList()) {
                ConvertPhone(phone, convDbContext, ffpmDbContext, logger);
            }
            foreach (var provider in convDbContext.Providers.ToList()) {
                ConvertProvider(provider, convDbContext, ffpmDbContext, logger);
            }
            foreach (var recall in convDbContext.Recalls.ToList()) {
                ConvertRecall(recall, convDbContext, ffpmDbContext, logger);
            }
            foreach (var recallType in convDbContext.RecallTypes.ToList()) {
                ConvertRecallType(recallType, convDbContext, ffpmDbContext, logger);
            }
            foreach (var referral in convDbContext.Referrals.ToList()) {
                ConvertReferral(referral, convDbContext, ffpmDbContext, logger);
            }
            foreach (var schedCode in convDbContext.SchedCodes.ToList()) {
                ConvertSchedCode(schedCode, convDbContext, ffpmDbContext, logger);
            }
        }

        public static void PatientConvert(Models.Patient patient, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            try {
                if (patient.PatientAccountNumber == null) {
                    logger.Log($"Patient Account Number is null for patient with ID: {patient.Id}");
                    return;
                }
                else if (patient.PatientLast == null) {
                    logger.Log($"Patient Last Name is null for patient with ID: {patient.Id}");
                    return;
                }
                else if (patient.PatientFirst == null) {
                    logger.Log($"Patient First Name is null for patient with ID: {patient.Id}");
                    return;
                }
                else if (patient.PatientSsn == null || !ssnRegex.IsMatch(patient.PatientSsn)) {
                    logger.Log($"Patient SSN is null or invalid for patient with ID: {patient.Id}");
                    return;
                }
                else if (patient.PatientDob == null) {
                    logger.Log($"Patient DOB is null for patient with ID: {patient.Id}");
                    return;
                }

                DateTime dob;
                string dobString = patient.PatientDob.Trim(); // Remove any leading/trailing whitespaces
                                                              // Try parsing the date using the specified formats
                if (!DateTime.TryParseExact(dobString, dateFormats,
                    CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out dob)) {
                    logger.Log($"Patient DOB is invalid or not in an expected format for patient with ID: {patient.Id}");
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
            }
            catch (Exception ex) {
                logger.Log($"An error occurred while converting the patient with ID: {patient.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertAddress(Models.Address address, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            try {
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.Find(address.Id);
                if (ConvPatient == null) {
                    logger.Log($"Patient not found for address with ID: {address.Id}");
                    return;
                }
                var ffpmPatient = ffpmDbContext.DmgPatients.FirstOrDefault(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Patient not found for address with ID: {address.Id}");
                    return;
                }

                DmgPatientAdditionalDetail? ffpmPatientAdditional = null;
                foreach (var details in ffpmDbContext.DmgPatientAdditionalDetails.ToList()) {
                    if (details.PatientId == ffpmPatient.PatientId) {
                        ffpmPatientAdditional = details;
                    }
                }
                if (ffpmPatientAdditional == null) {
                    logger.Log($"Patient additional not found for address with ID: {address.Id}");
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
                    logger.Log($"Address type is null for address with ID: {address.Id}");
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
                logger.Log($"An error occurred while converting the address with ID: {address.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertAppointment(Models.Appointment appointment, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            try {
                int patientId = 0;
                if (int.TryParse(appointment.PatientId, out int patientIdInt)) {
                    patientId = patientIdInt;
                } else {
                    logger.Log($"Patient ID is invalid for appointment with ID: {appointment.Id}");
                }
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.Find(patientId);
                if (ConvPatient == null) {
                    logger.Log($"Patient not found for appointment with ID: {appointment.PatientId}");
                    return;
                }
                DmgPatient? ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Patient not found for appointment with ID: {appointment.PatientId}");
                    return;
                }

                long resource = 0;
                if (appointment.ResourceId != null) {
                    resource = long.Parse(appointment.ResourceId);
                }

                DateTime start = DateTime.Parse("1/1/1900");
                if (!DateTime.TryParseExact(appointment.StartDate, dateFormats,
                                   CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out start)) {
                    logger.Log($"Appointment start time is invalid or not in an expected format for appointment with ID: {appointment.Id}");
                    return;
                }
                DateTime end = DateTime.Parse("1/1/1900");
                if (!DateTime.TryParseExact(appointment.EndDate, dateFormats,
                                          CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out end)) {
                    logger.Log($"Appointment end time is invalid or not in an expected format for appointment with ID: {appointment.Id}");
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
                    logger.Log($"Appointment created time is invalid or not in an expected format for appointment with ID: {appointment.Id}");
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

                var newAppointment = new SchedulingAppointment {
                    PatientId = ffpmPatient.PatientId,
                    ResourceId = resource,
                    BillingLocationId = billingLocId,
                    StartDate = start,
                    EndDate = end,
                    Notes = appointment.Notes,
                    Duration = duration,
                    DateTimeCreated = acceptableMinDateTime,
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
                logger.Log($"An error occurred while converting the appointment with ID: {appointment.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertAppointmentType(Models.AppointmentType appointmentType, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
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
                logger.Log($"An error occurred while converting the appointment type with ID: {appointmentType.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertInsurance(Models.Insurance insurance, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
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
                    IsCompanyInsurance = false
                };
                ffpmDbContext.InsInsuranceCompanies.Add(newInsuranceCompany);
                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"An error occurred while converting the insurance with ID: {insurance.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertLocation(Models.Location location, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
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
                    logger.Log($"Primary taxonomy ID not found for location with ID: {location.Id}");
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
                logger.Log($"An error occurred while converting the location with ID: {location.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertName(Models.Name name, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            try {
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.Find(name.Id);
                if (ConvPatient == null) {
                    logger.Log($"Patient not found for name with ID: {name.Id}");
                    return;
                }
                DmgPatient?ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Patient not found for name with ID: {name.Id}");
                    return;
                }
                DmgPatientAdditionalDetail? ffpmPatientAdditional = null;
                foreach (var details in ffpmDbContext.DmgPatientAdditionalDetails.ToList()) {
                    if (details.PatientId == ffpmPatient.PatientId) {
                        ffpmPatientAdditional = details;
                    }
                }
                if (ffpmPatientAdditional == null) {
                    logger.Log($"Patient not found for name with ID: {name.Id}");
                    return;
                }
                long? accNum = null;
                long? addId = null;
                if (name.AccountNumber != null) {
                    DmgPatient?tempPatient = ffpmPatients.Find(p => p.AccountNumber == name.AccountNumber);
                    DmgPatientAdditionalDetail? tempAdditionalDetail = null;
                    if (tempPatient == null) {
                        logger.Log($"Patient not found for name with ID: {name.Id}");
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
                    if (name.Sex.ToUpper() == "M") {
                        genderInt = 1;
                    }
                    else if (name.Sex.ToUpper() == "F") {
                        genderInt = 2;
                    }
                }
                if (name.Relationship == "emergency contact") {
                    ffpmPatientAdditional.EmergencyLast = name.LastName;
                    ffpmPatientAdditional.EmergencyFirst = name.FirstName;
                    ffpmPatientAdditional.EmergencyPatientId = accNum;
                    ffpmPatientAdditional.EmergencyAddressId = addId;
                }
                else if (name.Relationship == "guarantor") {
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
                else if (name.Relationship == "employer") {
                    ffpmPatientAdditional.EmployerName = name.LastName;
                    ffpmPatientAdditional.EmployerWebsite = name.FirstName;
                    ffpmPatientAdditional.EmployerAddressId = addId;
                }
                else {
                    logger.Log($"Invalid relationship for name with ID: {name.Id}");
                    return;
                }
                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"An error occurred while converting the name with ID: {name.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertPatientAlert(Models.PatientAlert patientAlert, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            try {
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.Find(patientAlert.Id);
                if (ConvPatient == null) {
                    logger.Log($"Patient not found for patient alert with ID: {patientAlert.Id}");
                    return;
                }
                DmgPatient?ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Patient not found for patient alert with ID: {patientAlert.Id}");
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
                logger.Log($"An error occurred while converting the patient alert with ID: {patientAlert.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertPatientDocument(Models.PatientDocument patientDocument, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            try {
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.Find(patientDocument.Id);
                if (ConvPatient == null) {
                    logger.Log($"Patient not found for patient document with ID: {patientDocument.Id}");
                    return;
                }
                DmgPatient?ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Patient not found for patient document with ID: {patientDocument.Id}");
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
                logger.Log($"An error occurred while converting the patient document with ID: {patientDocument.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertPatientInsurance(Models.PatientInsurance patientInsurance, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            try {
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.Find(patientInsurance.Id);
                if (ConvPatient == null) {
                    logger.Log($"Patient not found for patient insurance with ID: {patientInsurance.Id}");
                    return;
                }
                DmgPatient?ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Patient not found for patient insurance with ID: {patientInsurance.Id}");
                    return;
                }
                Models.Insurance? patientInsuranceCompany = null;
                foreach (var insurance in convDbContext.Insurances.ToList()) {
                    if (insurance.InsCompanyCode == patientInsurance.Code) {
                        patientInsuranceCompany = insurance;
                    }
                }
                if (patientInsuranceCompany == null) {
                    logger.Log($"Insurance company not found for patient insurance with ID: {patientInsurance.Id}");
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
                    logger.Log($"Insurance company not found for patient insurance with ID: {patientInsurance.Id}");
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
                logger.Log($"An error occurred while converting the patient insurance with ID: {patientInsurance.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertPatientNote(Models.PatientNote patientNote, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            try {
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.Find(patientNote.Id);
                if (ConvPatient == null) {
                    logger.Log($"Patient not found for patient note with ID: {patientNote.Id}");
                    return;
                }
                DmgPatient?ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Patient not found for patient note with ID: {patientNote.Id}");
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
                logger.Log($"An error occurred while converting the patient note with ID: {patientNote.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertPhone(Models.Phone phone, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            try {
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.Find(phone.Id);
                var ffpmAddresses = ffpmDbContext.DmgPatientAddresses.ToList();
                if (ConvPatient == null) {
                    logger.Log($"Patient not found for phone with ID: {phone.Id}");
                    return;
                }
                if (ffpmPatients == null) {
                    logger.Log($"Patient not found for phone with ID: {phone.Id}");
                    return;
                }
                if (ffpmAddresses == null) {
                    logger.Log($"Patient not found for phone with ID: {phone.Id}");
                    return;
                }
                DmgPatient?ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Patient not found for phone with ID: {phone.Id}");
                    return;
                }
                DmgPatientAddress? address = ffpmAddresses.Find(p => p.PatientId == ffpmPatient.PatientId);
                if (address == null) {
                    logger.Log($"Patient not found for phone with ID: {phone.Id}");
                    return;
                }

                switch (phone.TypeOfPhone) {
                    case "home":
                        address.HomePhone = phone.PhoneNumber;
                        break;
                    case "work":
                        address.WorkPhone = phone.PhoneNumber;
                        break;
                    case "cell":
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
                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"An error occurred while converting the phone with ID: {phone.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertProvider(Models.Provider provider, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            try {
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.Find(provider.Id);
                if (ConvPatient == null) {
                    logger.Log($"Patient not found for provider with ID: {provider.Id}");
                    return;
                }
                DmgPatient?ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Patient not found for provider with ID: {provider.Id}");
                    return;
                }

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

                #region taxonomys
                int primaryTaxId = 0;
                if (provider.PrimaryTaxonomyId != null) {
                    primaryTaxId = int.Parse(provider.PrimaryTaxonomyId);
                }
                else {
                    logger.Log($"Primary taxonomy ID not found for provider with ID: {provider.Id}");
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
                ffpmDbContext.DmgProviders.Add(newPatientProvider);
                ffpmDbContext.SaveChanges();
            }
            catch (Exception ex) {
                logger.Log($"An error occurred while converting the provider with ID: {provider.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertRecall(Models.Recall recall, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            try {
                var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
                var ConvPatient = convDbContext.Patients.Find(recall.PatientId);
                if (ConvPatient == null) {
                    logger.Log($"Patient not found for recall with ID: {recall.Id}");
                    return;
                }
                DmgPatient?ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
                if (ffpmPatient == null) {
                    logger.Log($"Patient not found for recall with ID: {recall.Id}");
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
                logger.Log($"An error occurred while converting the recall with ID: {recall.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertRecallType(Models.RecallType recallType, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
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
                logger.Log($"An error occurred while converting the recall type with ID: {recallType.Id}. Error: {ex.Message}");
            }
        }

        public static void ConvertReferral(Models.Referral referral, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            // No new entity creation, just process existing logic

        }

        public static void ConvertSchedCode(Models.SchedCode schedtype, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
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
        }

        public static void ConvertAccountXref(Models.AccountXref accountXref, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            // currently not implementing renumbering
        }

        public static void ConvertEyeMD(FoxfireConvContext convDbContext, EyeMdContext eyeMDDbContext, ILogger logger) {

            // EyeMD conversion logic here
        }
    }
}
