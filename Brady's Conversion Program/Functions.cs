﻿using System;
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
            short? licenseShort = null;
            if (patient.DriversLicenseState != null) {
                if (short.TryParse(patient.DriversLicenseState, out short license)) {
                    licenseShort = license;
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
            short? medicareSecondary = null;
            if (patient.MedicareSecondaryCode != null) {
                if (short.TryParse(patient.MedicareSecondaryCode, out short medicareSecondaryInt)) {
                    medicareSecondary = medicareSecondaryInt;
                }
            }
            bool? patientIsActive = null;
            if (patient.Active != null) {
                if (bool.TryParse(patient.Active, out bool isActive)) {
                    patientIsActive = isActive;
                }
            }
            bool? deceased = null;
            if (patient.DeceasedFlag != null) {
                if (bool.TryParse(patient.DeceasedFlag, out bool isDeceased)) {
                    deceased = isDeceased;
                }
            }
            bool? consent = null;
            if (patient.Consent != null) {
                if (bool.TryParse(patient.Consent, out bool hippaConsent)) {
                    consent = hippaConsent;
                }
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
                TextStatements = false,
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
                MedicareSecondarryCode = patient.MedicareSecondaryCode,
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

            var newAddress = new Brady_s_Conversion_Program.ModelsA.DmgPatientAddress {
                PatientId = ffpmPatient.PatientId, // a little complicated, but this should track
                Address1 = address.Address1,
                Address2 = address.Address2,
                City = address.City,
                StateId = ffpmPatientAdditional.DriversLicenseStateId,
                Zip = zipCode,
                ZipExt = zipExtension,
                IsActive = true,
                IsPrimary = true,
                // Need to connect Email via location ID to the contactinfo table
                Email = ConvPatient.PatientEmail,
                Notes = address.Note
            };
            ffpmDbContext.DmgPatientAddresses.Add(newAddress); // I think I will change this behavior to create the address first
                                                               // when creating the dmg patient, then add details down here later.
                                                               // This means I will have to change this to update instead of new
            /* Not using:
             * primary_id
             * primary file
             * type of address
             * from conv address. from patient address:
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
            // I can only assume that this is a blueprint for people, such as emergency contact
            // Everything here can be found in the patient table, so I am not sure what to do with this
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
            
        }

        public static void ConvertPatientNote(Models.PatientNote patientNote, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            // Log or handle patient note actions
            
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
            
            address.CellPhone = phone.PhoneNumber;
            address.Extension = phone.Extension;
            /* is this all? there is also:
             * primary_id
             * primary file
             * type of phone
             * note
             * in dbo.Phone that is not used
             */

            ffpmDbContext.SaveChanges();
        }

        public static void ConvertProvider(Models.Provider provider, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            
            // No new entity creation, just process existing logic
        }

        public static void ConvertRecall(Models.Recall recall, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger) {
            
            // No new entity creation, just process existing logic
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
