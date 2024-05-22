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

        public static string ConvertToDB(string connection, string FFPMConnection, string EyeMDConnection, bool ffpm, bool eyemd, bool newFfpm, bool newEyemd) {
            try {
                // have log file ready to record failings and issues
                using (StreamWriter sw = new StreamWriter("../../../../LogFiles/log.txt")) {
                    ILogger logger = new FileLogger("../../../../LogFiles/log.txt");

                    // Using block to ensure disposal of DbContexts
                    using (var convDbContext = new FoxfireConvContext(connection)) {
                        // Start with FFPM only, do EyeMD later

                        convDbContext.Database.OpenConnection();
                        if (ffpm == true) {
                            if (newFfpm) {
                                new FfpmContext(FFPMConnection).Database.EnsureCreated();
                            }
                            using (var ffpmDbContext = new FfpmContext(FFPMConnection)) {
                                ffpmDbContext.Database.OpenConnection();
                                ConvertFFPM(convDbContext, ffpmDbContext, logger);
                                ffpmDbContext.SaveChanges();
                            }
                        }
                        if (eyemd == true) {
                            if (newEyemd) {
                                new EyeMdContext(EyeMDConnection).Database.EnsureCreated();
                            }
                            using (var eyeMDDbContext = new EyeMdContext(EyeMDConnection)) {
                                eyeMDDbContext.Database.OpenConnection();
                                ConvertEyeMD(convDbContext, eyeMDDbContext, logger);
                                eyeMDDbContext.SaveChanges();
                            }
                        }

                        convDbContext.SaveChanges();

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
            // Assuming PatientConvert now returns a patientNum
            foreach (var patient in convDbContext.Patients.ToList()) {
                PatientConvert(patient, convDbContext , ffpmDbContext, logger);
            }
            foreach (var accountXref in convDbContext.AccountXrefs.ToList()) {
                ConvertAccountXref(accountXref, convDbContext , ffpmDbContext, logger);
            }
            foreach (var address in convDbContext.Addresses.ToList()) {
                ConvertAddress(address, convDbContext , ffpmDbContext, logger);
            }
            foreach (var appointment in convDbContext.Appointments.ToList()) {
                ConvertAppointment(appointment, convDbContext , ffpmDbContext, logger);
            }
            foreach (var appointmentType in convDbContext.AppointmentTypes.ToList()) {
                ConvertAppointmentType(appointmentType, convDbContext , ffpmDbContext, logger);
            }
            foreach (var employer in convDbContext.Employers.ToList()) {
                ConvertEmployer(employer, convDbContext , ffpmDbContext, logger);
            }
            foreach (var insurance in convDbContext.Insurances.ToList()) {
                ConvertInsurance(insurance, convDbContext , ffpmDbContext, logger);
            }
            foreach (var location in convDbContext.Locations.ToList()) {
                ConvertLocation(location, convDbContext , ffpmDbContext, logger);
            }
            foreach (var name in convDbContext.Names.ToList()) {
                ConvertName(name, convDbContext , ffpmDbContext, logger);
            }
            foreach (var patientAlert in convDbContext.PatientAlerts.ToList()) {
                ConvertPatientAlert(patientAlert, convDbContext , ffpmDbContext, logger);
            }
            foreach (var patientDocument in convDbContext.PatientDocuments.ToList()) {
                ConvertPatientDocument(patientDocument, convDbContext , ffpmDbContext, logger);
            }
            foreach (var patientInsurance in convDbContext.PatientInsurances.ToList()) {
                ConvertPatientInsurance(patientInsurance, convDbContext , ffpmDbContext, logger);
            }
            foreach (var patientNote in convDbContext.PatientNotes.ToList()) {
                ConvertPatientNote(patientNote, convDbContext , ffpmDbContext, logger);
            }
            foreach (var phone in convDbContext.Phones.ToList()) {
                ConvertPhone(phone, convDbContext , ffpmDbContext, logger);
            }
            foreach (var provider in convDbContext.Providers.ToList()) {
                ConvertProvider(provider, convDbContext , ffpmDbContext, logger);
            }
            foreach (var recall in convDbContext.Recalls.ToList()) {
                ConvertRecall(recall, convDbContext , ffpmDbContext, logger);
            }
            foreach (var recallType in convDbContext.RecallTypes.ToList()) {
                ConvertRecallType(recallType, convDbContext , ffpmDbContext, logger);
            }
            foreach (var referral in convDbContext.Referrals.ToList()) {
                ConvertReferral(referral, convDbContext , ffpmDbContext, logger);
            }
            foreach (var schedCode in convDbContext.SchedCodes.ToList()) {
                ConvertSchedCode(schedCode, convDbContext , ffpmDbContext, logger);
            }
        }


        public static void PatientConvert(Models.Patient patient, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
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

            short? genderInt = null;
            if (patient.PatientSex != null) {
                genderInt = patient.PatientSex.ToLower() == "m" ? (short)1 : (short)2;
            }

            short? licenseShort = null;
            if (patient.DriversLicenseState != null) {
                switch (patient.DriversLicenseState.ToUpper()) {
                    case "NY":
                        licenseShort = 1;
                        break;
                    case "CA":
                        licenseShort = 2;
                        break;
                    case "TX":
                        licenseShort = 3;
                        break;
                        // Add more states as needed
                }
            }

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
                if (!DateTime.TryParseExact(dobString, dateFormats,
                    CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                    consentDate = tempDateTime;
                }
            }
            DateOnly? deceasedDate = null;
            if (patient.DateOfDeath != null) {
                DateOnly tempDateTime;
                if (!DateOnly.TryParseExact(dobString, dateFormats,
                                       CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                    deceasedDate = tempDateTime;
                }
            }
            DateTime? lastExamDate = null;
            if (patient.LastExamDate != null) {
                DateTime tempDateTime;
                if (!DateTime.TryParseExact(dobString, dateFormats,
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
                // this is apparently a bit, but i used bool and it's working. not sure how this works
                IsActive = patientIsActive,
                IsDeceased = deceased,
                DeceasedDate = deceasedDate, // everything below here is filler to allow the creation of the dmg patient
                LastExamDate = lastExamDate,
                PatientBalance = 0,
                InsuranceBalance = 0,
                OtherBalance = 0,
                GenderId = genderInt,
                SuffixId = suffixInt,
                BalanceLastUpdatedDateTime = minDate, // This probably needs to be changed
                EmailNotApplicable = isEmailValid,
                DoNotSendStatements = dontSendStatements,
                EmailStatements = emailStatements,
                OpenEdgeCustomerId = "",
                TextStatements = true,
                LocationId = 0
            }; // connected
            ffpmDbContext.DmgPatients.Add(newPatient);

            ffpmDbContext.SaveChanges();

            var newRace = new Brady_s_Conversion_Program.ModelsA.MntRace {
                Race = patient.PatientRace
            };// connected
            ffpmDbContext.MntRaces.Add(newRace);

            ffpmDbContext.SaveChanges();

            var newEthnicity = new Brady_s_Conversion_Program.ModelsA.MntEthnicity {
                Ethnicity = ethnicityString
            }; // connected
            ffpmDbContext.MntEthnicities.Add(newEthnicity);

            ffpmDbContext.SaveChanges();

            // new address here


            var newMedicareSecondary = new Brady_s_Conversion_Program.ModelsA.MntMedicareSecondary {
                MedicareSecondarryCode = medicareSecondary,
                MedicareSecondaryDescription = patient.MedicareSecondaryNotes
            }; // connected
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

            return;
        }

        public static void ConvertAccountXref(Models.AccountXref accountXref, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            // currently not implementing renumbering
        }

        public static void ConvertAddress(Models.Address address, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            // Existing logic for creating and adding a new Address
            var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
            var ConvPatient = convDbContext.Patients.Find(address.Id);
            if (ConvPatient == null) {
                logger.Log("Patient not found for address with ID: " + address.Id);
                return;
            }
            DmgPatient ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
            if (ffpmPatient == null) {
                logger.Log("Patient not found for address with ID: " + address.Id);
                return;
            }
            DmgPatientAdditionalDetail ffpmPatientAdditional = null;
            foreach (var details in ffpmDbContext.DmgPatientAdditionalDetails.ToList()) {
                if (details.PatientId == ffpmPatient.PatientId) {
                    ffpmPatientAdditional = details;
                }
            }
            if (ffpmPatientAdditional == null) {
                logger.Log("Patient not found for address with ID: " + address.Id);
                return;
            }
            string? zipCode = null;
            if (address.Zip == null) {
                if (address.Zip4 == null) {
                    zipCode = null;
                } else {
                    zipCode = address.Zip4;
                }
            } else {
                zipCode = address.Zip;
            }
            string? baseZipCode = null;
            string? zipExtension = null;

            if (zipCode != null) {
                Regex zipRegex = new Regex(@"\b(\d{5})(?:[-\s]?(\d{4}))?\b"); // Regex for US ZIP codes
                Match match = zipRegex.Match(zipCode);
                if (match.Success) {
                    // Always assign the 5-digit base zip code
                    baseZipCode = match.Groups[1].Value;

                    // Assign the 4-digit extension if present, otherwise leave it as null
                    zipExtension = !string.IsNullOrEmpty(match.Groups[2].Value) ? match.Groups[2].Value : null;
                }
            }

            // You can now use baseZipCode and zipExtension as needed, for example:
            Console.WriteLine($"Base Zip Code: {baseZipCode}");
            if (zipExtension != null) {
                Console.WriteLine($"Zip Extension: {zipExtension}");
            }
            else {
                Console.WriteLine("No Zip Extension provided.");
            }
            bool isPrimary = false;
            bool isAlternate = false;
            bool isActive = false;
            bool isEmergency = false;
            bool isPreferred = false;
            if (address.TypeOfAddress == "primary" || address.TypeOfAddress == "Primary") {
                isPrimary = true;
                isActive = true;
                isPreferred = true;
            } else if (address.TypeOfAddress == "alternate" || address.TypeOfAddress == "Alternate") {
                isAlternate = true;
                isActive = true;
            } else if (address.TypeOfAddress == "emergency" || address.TypeOfAddress == "Emergency") {
                isEmergency = true;
                isActive = true;
            }

            var newAddress = new Brady_s_Conversion_Program.ModelsA.DmgPatientAddress {
                PatientId = ffpmPatient.PatientId, // a little complicated, but this should track
                Address1 = address.Address1,
                Address2 = address.Address2,
                City = address.City,
                StateId = ffpmPatientAdditional.DriversLicenseStateId,
                Zip = zipCode,
                ZipExt = zipExtension,
                // Need to connect Email via location ID to the contactinfo table
                Email = ConvPatient.PatientEmail,
                Notes = address.Note,
                IsPrimary = isPrimary,
                IsActive = isActive,
                IsPreferred = isPreferred,
                IsEmergencyContactAddress = isEmergency,
                IsAlternateAddress = isAlternate
            };
            ffpmDbContext.DmgPatientAddresses.Add(newAddress); // I think I will change this behavior to create the address first
                                                               // when creating the dmg patient, then add details down here later.
                                                               // This means I will have to change this to update instead of new
            /* Not using:
             * primary_id
             * primary file
             * type of address
             * from conv address. 
             * from patient address:
             * is preferred
             * is emergency contact address
             * is alternate address
             */
            ffpmDbContext.SaveChanges();
        }

        public static void ConvertAppointment(Models.Appointment appointment, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            // Where is this supposed to go?
        }

        public static void ConvertAppointmentType(Models.AppointmentType appointmentType, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            // Same as above
        }

        public static void ConvertEmployer(Models.Employer employer, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
            var ConvPatient = convDbContext.Patients.Find(employer.Id);
            if (ConvPatient == null) {
                logger.Log("Patient not found for address with ID: " + employer.Id);
                return;
            }
            DmgPatient ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
            if (ffpmPatient == null) {
                logger.Log("Patient not found for address with ID: " + employer.Id);
                return;
            }
            DmgPatientAdditionalDetail ffpmPatientAdditional = null;
            foreach (var details in ffpmDbContext.DmgPatientAdditionalDetails.ToList()) {
                if (details.PatientId == ffpmPatient.PatientId) {
                    ffpmPatientAdditional = details;
                }
            }
            ffpmPatientAdditional.EmployerName = employer.EmployerName;
            
            ffpmDbContext.SaveChanges();
        }

        public static void ConvertInsurance(Models.Insurance insurance, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
            var ConvPatient = convDbContext.Patients.Find(insurance.Id);
            if (ConvPatient == null) {
                logger.Log("Patient not found for address with ID: " + insurance.Id);
                return;
            }
            DmgPatient ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
            if (ffpmPatient == null) {
                logger.Log("Patient not found for address with ID: " + insurance.Id);
                return;
            }
            DmgPatientAdditionalDetail ffpmPatientAdditional = null;
            foreach (var details in ffpmDbContext.DmgPatientAdditionalDetails.ToList()) {
                if (details.PatientId == ffpmPatient.PatientId) {
                    ffpmPatientAdditional = details;
                }
            }
            int? companyCode = null;
            if (insurance.InsCompanyCode != null) {
                if (int.TryParse(insurance.InsCompanyCode, out int code)) {
                    companyCode = code;
                }
            }

            var newPatientInsurance = new DmgPatientInsurance {
                PatientId = ffpmPatient.PatientId,
                PlanId = 0, // definitely incorrect, will need to change later
                IsMedicalInsurance = false, // just not null
                IsVisionInsurance = false, // also just not null
                IsAdditionalInsurance = false, // also just not null
                InsuranceCompanyId = companyCode

            };
            // insurance policy type is bool? what does that even mean
            // many fields are not used in the insurance table
            ffpmDbContext.DmgPatientInsurances.Add(newPatientInsurance);

            ffpmDbContext.SaveChanges();
        }

        public static void ConvertLocation(Models.Location location, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            // Seemingly not part of patient demographics, will have to return later
        }

        public static void ConvertName(Models.Name name, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
            var ConvPatient = convDbContext.Patients.Find(name.Id);
            if (ConvPatient == null) {
                logger.Log("Patient not found for address with ID: " + name.Id);
                return;
            }
            DmgPatient ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
            if (ffpmPatient == null) {
                logger.Log("Patient not found for address with ID: " + name.Id);
                return;
            }
            DmgPatientAdditionalDetail ffpmPatientAdditional = null;
            foreach (var details in ffpmDbContext.DmgPatientAdditionalDetails.ToList()) {
                if (details.PatientId == ffpmPatient.PatientId) {
                    ffpmPatientAdditional = details;
                }
            }
            if (ffpmPatientAdditional == null) {
                logger.Log("Patient not found for address with ID: " + name.Id);
                return;
            }
            long? accNum = null;
            long? addId = null;
            if (name.AccountNumber != null) {
                DmgPatient tempPatient = ffpmPatients.Find(p => p.AccountNumber == name.AccountNumber);
                DmgPatientAdditionalDetail tempAdditionalDetail = null;
                foreach (var details in ffpmDbContext.DmgPatientAdditionalDetails.ToList()) {
                    if (details.PatientId == tempPatient.PatientId) {
                        tempAdditionalDetail = details;
                    }
                }
                accNum = tempPatient.PatientId;
                addId = tempPatient.AddressId;
            }
            string ssnPattern = @"^(?:\d{3}[-/]\d{2}[-/]\d{4}|\d{9})$";
            string? ssn = null;
            if (name.Ssn != null && !Regex.IsMatch(name.Ssn, ssnPattern)) {
                ssn = name.Ssn;
            }
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
                // have not set system for emergency contact relation id; wouldnt be too hard, will add later if needed
                ffpmPatientAdditional.EmergencyAddressId = addId;
            } else if (name.Relationship == "guarantor") {
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
                    // no system for relation id still. this will need to match the one in emergency patient.
                    MiddleName = name.MiddleName,
                    Ssn = ssn,
                    Dob = dob,
                    GenderId = genderInt
                };
                ffpmDbContext.DmgGuarantors.Add(newGuarantor);

                ffpmDbContext.SaveChanges();
            } else if (name.Relationship == "employer") {
                ffpmPatientAdditional.EmployerName = name.LastName;
                ffpmPatientAdditional.EmployerWebsite = name.FirstName;
                ffpmPatientAdditional.EmployerAddressId = addId; // im not positive how to handle this, there are no places of input for employer address
            } else {
                logger.Log("Invalid relationship for name with ID: " + name.Id);
                return;
            }
            ffpmDbContext.SaveChanges();
        }

        public static void ConvertPatientAlert(Models.PatientAlert patientAlert, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
            var ConvPatient = convDbContext.Patients.Find(patientAlert.Id);
            if (ConvPatient == null) {
                logger.Log("Patient not found for address with ID: " + patientAlert.Id);
                return;
            }
            DmgPatient ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
            if (ffpmPatient == null) {
                logger.Log("Patient not found for address with ID: " + patientAlert.Id);
                return;
            }
            DmgPatientAdditionalDetail ffpmPatientAdditional = null;
            foreach (var details in ffpmDbContext.DmgPatientAdditionalDetails.ToList()) {
                if (details.PatientId == ffpmPatient.PatientId) {
                    ffpmPatientAdditional = details;
                }
            }
            short? priorityID = null;
            if (patientAlert.PriorityId != null) {
                if (short.TryParse(patientAlert.PriorityId, out short priority)) {
                    priorityID = priority;
                }
            }
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

        public static void ConvertPatientDocument(Models.PatientDocument patientDocument, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
            var ConvPatient = convDbContext.Patients.Find(patientDocument.Id);
            if (ConvPatient == null) {
                logger.Log("Patient not found for address with ID: " + patientDocument.Id);
                return;
            }
            DmgPatient ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
            if (ffpmPatient == null) {
                logger.Log("Patient not found for address with ID: " + patientDocument.Id);
                return;
            }
            DmgPatientAdditionalDetail ffpmPatientAdditional = null;
            foreach (var details in ffpmDbContext.DmgPatientAdditionalDetails.ToList()) {
                if (details.PatientId == ffpmPatient.PatientId) {
                    ffpmPatientAdditional = details;
                }
            }
            short? imageType = null;
            if (patientDocument.DocumentImageType != null) {
                if (short.TryParse(patientDocument.DocumentImageType, out short type)) {
                    imageType = type;
                }
            }
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
                DocumentLocation = patientDocument.FilePathName
            };
            // not using some from patient document:
            // insurance company
            ffpmDbContext.ImgPatientDocuments.Add(newPatientDocument);

            ffpmDbContext.SaveChanges();
        }

        public static void ConvertPatientInsurance(Models.PatientInsurance patientInsurance, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle patient insurance actions
            var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
            var ConvPatient = convDbContext.Patients.Find(patientInsurance.Id);
            if (ConvPatient == null) {
                logger.Log("Patient not found for address with ID: " + patientInsurance.Id);
                return;
            }
            DmgPatient ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
            if (ffpmPatient == null) {
                logger.Log("Patient not found for address with ID: " + patientInsurance.Id);
                return;
            }
            DmgPatientAdditionalDetail ffpmPatientAdditional = null;
            foreach (var details in ffpmDbContext.DmgPatientAdditionalDetails.ToList()) {
                if (details.PatientId == ffpmPatient.PatientId) {
                    ffpmPatientAdditional = details;
                }
            }
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
            DateTime? startDate = null;
            if (patientInsurance.StartDate != null) {
                DateTime tempDateTime;
                if (!DateTime.TryParseExact(patientInsurance.StartDate, dateFormats,
                                                                             CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                    startDate = tempDateTime;
                }
            }
            DateOnly? EndDate = null;
            if (patientInsurance.EndDate != null) {
                DateOnly tempDateTime;
                if (!DateOnly.TryParseExact(patientInsurance.EndDate, dateFormats,
                                                                                                CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                    EndDate = tempDateTime;
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

            var newPatientInsurance = new Brady_s_Conversion_Program.ModelsA.DmgPatientInsurance {
                PatientId = ffpmPatient.PatientId,
                StartDate = startDate,
                EndDate = EndDate,
                Copay = copay,
                Deductible = deductible,
                PlanId = 0, // need to make a plan id system
                IsMedicalInsurance = false, 
                IsVisionInsurance = false,
                IsAdditionalInsurance = false,
                InsuranceCompanyId = 0
            }; // tons of questions here. what is cert? what is code? medical vision, rank, plan?
            ffpmDbContext.DmgPatientInsurances.Add(newPatientInsurance);

            ffpmDbContext.SaveChanges();
        }

        public static void ConvertPatientNote(Models.PatientNote patientNote, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle patient note actions
            var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
            var ConvPatient = convDbContext.Patients.Find(patientNote.Id);
            if (ConvPatient == null) {
                logger.Log("Patient not found for address with ID: " + patientNote.Id);
                return;
            }
            DmgPatient ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
            if (ffpmPatient == null) {
                logger.Log("Patient not found for address with ID: " + patientNote.Id);
                return;
            }
            DmgPatientAdditionalDetail ffpmPatientAdditional = null;
            foreach (var details in ffpmDbContext.DmgPatientAdditionalDetails.ToList()) {
                if (details.PatientId == ffpmPatient.PatientId) {
                    ffpmPatientAdditional = details;
                }
            }

            var newPatientRemarks = new Brady_s_Conversion_Program.ModelsA.DmgPatientRemark {
                PatientId = ffpmPatient.PatientId,
                Remarks = patientNote.Note
            };
            ffpmDbContext.DmgPatientRemarks.Add(newPatientRemarks);

            ffpmDbContext.SaveChanges();
        }

        public static void ConvertPhone(Models.Phone phone, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
            var ConvPatient = convDbContext.Patients.Find(phone.Id);
            var ffpmAddresses = ffpmDbContext.DmgPatientAddresses.ToList();
            if (ConvPatient == null) {
                logger.Log("Patient not found for phone with ID: " + phone.Id);
                return;
            }
            if (ffpmPatients == null) {
                logger.Log("Patient not found for phone with ID: " + phone.Id);
                return;
            }
            if (ffpmAddresses == null) {
                logger.Log("Patient not found for phone with ID: " + phone.Id);
                return;
            }
            DmgPatient ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
            if (ffpmPatient == null) {
                logger.Log("Patient not found for phone with ID: " + phone.Id);
                return;
            }
            DmgPatientAddress address = ffpmAddresses.Find(p => p.PatientId == ffpmPatient.PatientId);
            if (address == null) {
                logger.Log("Patient not found for phone with ID: " + phone.Id);
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
            

            /* is this all? there is also:
             * primary_id
             * primary file
             * note
             * in dbo.Phone that is not used
             */

            ffpmDbContext.SaveChanges();
        }

        public static void ConvertProvider(Models.Provider provider, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
            var ConvPatient = convDbContext.Patients.Find(provider.Id);
            if (ConvPatient == null) {
                logger.Log("Patient not found for address with ID: " + provider.Id);
                return;
            }
            DmgPatient ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
            if (ffpmPatient == null) {
                logger.Log("Patient not found for address with ID: " + provider.Id);
                return;
            }
            DmgPatientAdditionalDetail ffpmPatientAdditional = null;
            foreach (var details in ffpmDbContext.DmgPatientAdditionalDetails.ToList()) {
                if (details.PatientId == ffpmPatient.PatientId) {
                    ffpmPatientAdditional = details;
                }
            }

            var newPatientProvider = new Brady_s_Conversion_Program.ModelsA.DmgProvider {
                // will need to consult with dave to understand this table
            };
        }

        public static void ConvertRecall(Models.Recall recall, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
            var ConvPatient = convDbContext.Patients.Find(recall.Id);
            if (ConvPatient == null) {
                logger.Log("Patient not found for address with ID: " + recall.Id);
                return;
            }
            DmgPatient ffpmPatient = ffpmPatients.Find(p => p.AccountNumber == ConvPatient.PatientAccountNumber);
            if (ffpmPatient == null) {
                logger.Log("Patient not found for address with ID: " + recall.Id);
                return;
            }
            DmgPatientAdditionalDetail ffpmPatientAdditional = null;
            foreach (var details in ffpmDbContext.DmgPatientAdditionalDetails.ToList()) {
                if (details.PatientId == ffpmPatient.PatientId) {
                    ffpmPatientAdditional = details;
                }
            }

            // This seems to be for scheduling
        }

        public static void ConvertRecallType(Models.RecallType recallType, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle recall type actions
            
        }

        public static void ConvertReferral(Models.Referral referral, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            
            // No new entity creation, just process existing logic
        }

        public static void ConvertSchedCode(Models.SchedCode schedCode, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle sched code-related actions
            
        }

        public static void ConvertEyeMD(FoxfireConvContext convDbContext, EyeMdContext eyeMDDbContext, ILogger logger) {
            
            // EyeMD conversion logic here
        }

    }
}
