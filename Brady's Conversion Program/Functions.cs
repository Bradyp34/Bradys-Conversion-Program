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
using Brady_s_Conversion_Program.ModelsC;
using Brady_s_Conversion_Program.ModelsD;
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
using System.Web;
using System.CodeDom;
using Microsoft.Identity.Client.NativeInterop;
using static Azure.Core.HttpHeader;
using System.Windows.Forms;
using System.Configuration;
using System.ComponentModel;

namespace Brady_s_Conversion_Program {
    public static class Functions {
        public interface ILogger {
            void Log(string message);
        }

        public class FileLogger : ILogger { // the log file is a txt file in the filepath in convertodb function
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

        public static string TruncateString(string? input, int maxLength) { // make sure strings are of proper length, this did happen in my tests
            if (string.IsNullOrEmpty(input))
                return "";

            return input.Length <= maxLength ? input : input.Substring(0, maxLength);
        }


        public static readonly DateTime minAcceptableDate = DateTime.Parse("1/2/1900");
        public static readonly DateTime overFlowDate = DateTime.Parse("12/31/2100");
        public static DateTime isValidDate(DateTime date) { // in an attempt to easily regulated unruly dates
            if (!(date >= minAcceptableDate && date <= overFlowDate)) {
                return minAcceptableDate;
            }
            return date;
        }

        public static string CleanUpDateString(string input) {
            input = input.Trim();

            // Replace multiple spaces with a single space
            input = Regex.Replace(input, @"\s+", " ");

            return input;
        }

        public static readonly string[] dateFormats = new string[] {
            // Date-only formats with numeric months
            "MM/dd/yyyy",
            "yyyy/MM/dd",
            "MM-dd-yyyy",
            "yyyy-MM-dd",
            "M/d/yyyy",
            "yyyy-M-d",
            "M-d-yyyy",

            // Date with 12-hour time formats (AM/PM) with numeric months
            "MM/dd/yyyy hh:mmtt",
            "MM/dd/yyyy hh:mm:ss tt",
            "yyyy/MM/dd hh:mm:ss tt",
            "MM-dd-yyyy hh:mm:ss tt",
            "yyyy-MM-dd hh:mm:ss tt",
            "M/d/yyyy hh:mm:ss tt",
            "yyyy-M-d hh:mm:ss tt",
            "MM/dd/yyyy h:mm:ss tt",
            "yyyy/MM/dd h:mm:ss tt",
            "MM-dd-yyyy h:mm:ss tt",
            "yyyy-MM-dd h:mm:ss tt",
            "M/d/yyyy h:mm:ss tt",
            "yyyy-M-d h:mm:ss tt",

            // Date with 12-hour time formats (AM/PM) with abbreviated months
            "MMM dd, yyyy hh:mm:ss tt",
            "MMM dd yyyy hh:mm:ss tt",
            "yyyy MMM dd hh:mm:ss tt",
            "MMM dd, yyyy h:mm:ss tt",
            "MMM dd yyyy h:mm:ss tt",
            "yyyy MMM dd h:mm:ss tt",

            // Date with 12-hour time formats (AM/PM) with full month names
            "MMMM dd, yyyy hh:mm:ss tt",
            "MMMM dd yyyy hh:mm:ss tt",
            "yyyy MMMM dd hh:mm:ss tt",
            "MMMM dd, yyyy h:mm:ss tt",
            "MMMM dd yyyy h:mm:ss tt",
            "yyyy MMMM dd h:mm:ss tt",

            // Date with 12-hour time formats (AM/PM) without seconds with numeric months
            "MM/dd/yyyy hh:mm tt",
            "yyyy/MM/dd hh:mm tt",
            "MM-dd-yyyy hh:mm tt",
            "yyyy-MM-dd hh:mm tt",
            "M/d/yyyy hh:mm tt",
            "yyyy-M-d hh:mm tt",
            "MM/dd/yyyy h:mm tt",
            "yyyy/MM/dd h:mm tt",
            "MM-dd-yyyy h:mm tt",
            "yyyy-MM-dd h:mm tt",
            "M/d/yyyy h:mm tt",
            "yyyy-M-d h:mm tt",

            // Date with 12-hour time formats (AM/PM) without seconds with abbreviated months
            "MMM dd, yyyy hh:mm tt",
            "MMM dd yyyy hh:mm tt",
            "yyyy MMM dd hh:mm tt",
            "MMM dd, yyyy h:mm tt",
            "MMM dd yyyy h:mm tt",
            "yyyy MMM dd h:mm tt",

            // Date with 12-hour time formats (AM/PM) without seconds with full month names
            "MMMM dd, yyyy hh:mm tt",
            "MMMM dd yyyy hh:mm tt",
            "yyyy MMMM dd hh:mm tt",
            "MMMM dd, yyyy h:mm tt",
            "MMMM dd yyyy h:mm tt",
            "yyyy MMMM dd h:mm tt",
        };


        private static Regex ssnRegex = new Regex(@"^(?:\d{3}[-/]\d{2}[-/]\d{4}|\d{9})$");
        private static Regex zipRegex = new Regex(@"\b(\d{5})(?:[-\s]?(\d{4}))?\b");
        private static Regex phoneRegex = new Regex(@"^(\+\d{1,3}\s)?(\(\d{3}\)|\d{3})[\s.-]?\d{3}[\s.-]?\d{4}$"); 

        public static string FFPMString = "";
        public static string EyeMDString = "";

        public static Dictionary<int, string> insuranceCodes = new Dictionary<int, string> {};

        public static string ConvertToDB(string convConnection, string ehrConnection, string invConnection, string FFPMConnection, string EyeMDConnection,
            bool conv, bool ehr, bool inv, bool newFfpm, bool newEyemd, ProgressBar progress, RichTextBox resultsBox, string customerInfoConnection) {
            FFPMString = FFPMConnection;
            EyeMDString = EyeMDConnection;
            try {
				ILogger logger = new FileLogger("LogFiles/log.txt"); // Log file path


                int totalEntries = 0;

                if (conv == true) { // if it is an ffpm conversion
                    // do customer info stuff here
                    using (SqlConnection conn = new SqlConnection(customerInfoConnection)) {
                        conn.Open();

                        // SQL query to fetch OldInsCompanyId and InsCode, without hardcoding the database name
                        string query = @"
                        SELECT  
                            i.InsId,
                            i.InsCode
                        FROM [dbo].[Insurance_Xref] i  -- Use just the schema and table name";

                        // Execute the query and read the results
                        using (SqlCommand cmd = new SqlCommand(query, conn)) {
                            using (SqlDataReader reader = cmd.ExecuteReader()) {
                                while (reader.Read()) {
                                    // Get the OldInsCompanyId (int) and InsCode (string)
                                    int oldInsCompanyId = reader.GetInt32(0);  // InsId is at index 0
                                    string insCode = reader.GetString(1);  // InsCode is at index 1

                                    // Add them as key-value pairs into the dictionary
                                    if (!insuranceCodes.ContainsKey(oldInsCompanyId)) {
                                        insuranceCodes.Add(oldInsCompanyId, insCode);
                                    }
                                }
                            }
                        }
                    }
                    using (var convDbContext = new FoxfireConvContext(convConnection)) {
                        convDbContext.Database.OpenConnection();
                        if (newFfpm) { // if it is a new ffpm database
                            new FfpmContext(FFPMConnection).Database.EnsureCreated();
                            new EyeMdContext(EyeMDConnection).Database.EnsureCreated();
                        }
                        using (var ffpmDbContext = new FfpmContext(FFPMConnection)) {
                            
                            resultsBox.Invoke((MethodInvoker)delegate { // change the results box text
                                resultsBox.Text += "Foxfire Conversion Started\n";
                            });
                            ffpmDbContext.Database.OpenConnection();

                            // Calculate total number of entries for progress tracking
                            totalEntries = convDbContext.Patients.Count() +
                                            convDbContext.Locations.Count() +
                                            convDbContext.Appointments.Count() +
                                            convDbContext.AppointmentTypes.Count() +
                                            convDbContext.Insurances.Count() +
                                            convDbContext.Providers.Count() +
                                            convDbContext.Guarantors.Count() +
                                            convDbContext.PolicyHolders.Count() +
                                            convDbContext.PatientAlerts.Count() +
                                            convDbContext.PatientDocuments.Count() +
                                            convDbContext.PatientInsurances.Count() +
                                            convDbContext.PatientNotes.Count() +
                                            convDbContext.Recalls.Count() +
                                            convDbContext.RecallTypes.Count() +
                                            convDbContext.Referrals.Count() +
                                            convDbContext.SchedCodes.Count() +
                                            convDbContext.Addresses.Count() +
                                            convDbContext.Phones.Count();


                            // Set progress bar properties on UI thread
                            progress.Invoke((MethodInvoker)delegate {
                                progress.Maximum = totalEntries;
                                progress.Step = 1;
                                progress.Value = 0;
                            });


                            ConvertFFPM(convDbContext, ffpmDbContext, logger, progress, resultsBox);

                            // Save changes to databases
                            ffpmDbContext.SaveChanges();
                            convDbContext.SaveChanges();
                        }
                    }
                    resultsBox.Invoke((MethodInvoker)delegate { // change the results box text
                        resultsBox.Text += "Foxfire Conversion Successful\n";
                    });
                }
                if (ehr == true) { // if it is (also) eyemd/ehr conversion
                    using (var eHRDbContext = new EHRDbContext(ehrConnection)) {
                        using (var ffpmDbContext = new FfpmContext(FFPMConnection)) {
                            using (var convDbContext = new FoxfireConvContext(convConnection)) {
                                if (newEyemd) { // if it is a new eyemd database
                                    new EyeMdContext(EyeMDConnection).Database.EnsureCreated();
                                }
                                using (var eyeMDDbContext = new EyeMdContext(EyeMDConnection)) {
                                    resultsBox.Invoke((MethodInvoker)delegate { // change results box text
                                        resultsBox.Text += "EHR Conversion Started\n";
                                    });
                                    ffpmDbContext.Database.OpenConnection();
                                    eyeMDDbContext.Database.OpenConnection();

                                    totalEntries = eHRDbContext.MedicalHistories.Count() + // count total entries for progress bar
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
                                                    eHRDbContext.PatientNotes.Count();




                                    progress.Invoke((MethodInvoker)delegate { // set progress bar to 0 again
                                        progress.Maximum = totalEntries;
                                        progress.Step = 1;
                                        progress.Value = 0;
                                    });



                                    eyeMDDbContext.Database.OpenConnection();
                                    ConvertEyeMD(eHRDbContext, eyeMDDbContext, ffpmDbContext, convDbContext, logger, progress, resultsBox); // convert eyemd data
                                    eyeMDDbContext.SaveChanges();
                                }
                            }
                        }
                    }
                    resultsBox.Invoke((MethodInvoker)delegate { // change results box text
                        resultsBox.Text += "EHR Conversion Successful\n";
                    });
                }
                if (inv == true) { // if it is an inv conversion
                    using (var invDbContext = new InvDbContext(invConnection)) {
                        using (var ffpmDbContext = new FfpmContext(FFPMConnection)) {
                            resultsBox.Invoke((MethodInvoker)delegate { // change results box text
                                resultsBox.Text += "Inv Conversion Started\n";
                            });
                            totalEntries = invDbContext.Clbrands.Count() + // count total entries for progress bar
                                            invDbContext.Clinventories.Count() +
                                            invDbContext.Cllenses.Count() +
                                            invDbContext.Cptdepts.Count() +
                                            invDbContext.Cptmappings.Count() +
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
                            progress.Invoke((MethodInvoker)delegate { // set progress bar to 0 again
                                progress.Maximum = totalEntries;
                                progress.Step = 1;
                                progress.Value = 0;
                            });



                            ffpmDbContext.Database.OpenConnection();
                            ConvertInv(invDbContext, ffpmDbContext, logger, progress, resultsBox); // convert inv data
                            ffpmDbContext.SaveChanges();
                        }
                    }
                    resultsBox.Invoke((MethodInvoker)delegate { // change results box text
                        resultsBox.Text += "Inv Conversion Successful\n";
                    });
                    return "Program run completed.\n";
                }
            }
            catch (Exception e) { // if there is an error, log it
                return "Database Upload Failed.\n" + e + "\n";
            }
            return "Operation Successful";
        }

        #region FFPMConversion
        public static void ConvertFFPM(FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress, RichTextBox resultsBox) {
            var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
            var raceXrefs = ffpmDbContext.MntRaces.ToList();
            var ethnicityXrefs = ffpmDbContext.MntEthnicities.ToList();
            var titleXrefs = ffpmDbContext.MntTitles.ToList();
            var suffixXrefs = ffpmDbContext.MntSuffixes.ToList();
            var maritalStatusXrefs = ffpmDbContext.MntMaritalStatuses.ToList();
            var stateXrefs = ffpmDbContext.MntStates.ToList();
            var patientAdditionalDetails = ffpmDbContext.DmgPatientAdditionalDetails.ToList();
            var medicareSecondarys = ffpmDbContext.MntMedicareSecondaries.ToList();
            var convPatients = convDbContext.Patients.ToList();
            var appointmentTypes = ffpmDbContext.SchedulingAppointmentTypes.ToList();
            var appointments = ffpmDbContext.SchedulingAppointments.ToList();
            var locations = ffpmDbContext.BillingLocations.ToList();
            var guarantors = ffpmDbContext.DmgGuarantors.ToList();
            var insurances = ffpmDbContext.InsInsuranceCompanies.ToList();
            var relationshipXrefs = ffpmDbContext.MntRelationships.ToList();
            var genderXrefs = ffpmDbContext.MntGenders.ToList();
            var countryXrefs = ffpmDbContext.MntCountries.ToList();
            var addressTypes = ffpmDbContext.MntAddressTypes.ToList();
            var otherAddresses = ffpmDbContext.DmgOtherAddresses.ToList();
            var ffpmPatientAddresses = ffpmDbContext.DmgPatientAddresses.ToList();
            var convProviders = convDbContext.Providers.ToList();
            var ffpmProviders = ffpmDbContext.DmgProviders.ToList();
            var convGuarantors = convDbContext.Guarantors.ToList();
            var convLocations = convDbContext.Locations.ToList();
            var priorityXrefs = ffpmDbContext.MntPriorities.ToList();
            var patientAlerts = ffpmDbContext.DmgPatientAlerts.ToList();
            var patientDocuments = ffpmDbContext.ImgPatientDocuments.ToList();
            var patientInsurances = ffpmDbContext.DmgPatientInsurances.ToList();
            var patientNotes = ffpmDbContext.DmgPatientRemarks.ToList();
            var convPatientInsurances = convDbContext.PatientInsurances.ToList();
            var convInsurances = convDbContext.Insurances.ToList();
            var subscribers = ffpmDbContext.DmgSubscribers.ToList();
            var patientRecallLists = ffpmDbContext.SchedulingPatientRecallLists.ToList();
            var schedulingAppointmentTypes = ffpmDbContext.SchedulingAppointmentTypes.ToList();
            var referringProviders = ffpmDbContext.ReferringProviders.ToList();
            var schedulingCodes = ffpmDbContext.SchedulingCodes.ToList();
            var convAppointmentTypes = convDbContext.AppointmentTypes.ToList();
            var convAppointments = convDbContext.Appointments.ToList();
            var convPatientAlerts = convDbContext.PatientAlerts.ToList();
            var convPatientDocuments = convDbContext.PatientDocuments.ToList();
            var convPatientNotes = convDbContext.PatientNotes.ToList();
            var policyHolders = convDbContext.PolicyHolders.ToList();
            var convRecallTypes = convDbContext.RecallTypes.ToList();
            var convRecalls = convDbContext.Recalls.ToList();
            var convReferrals = convDbContext.Referrals.ToList();
            var convSchedCodes = convDbContext.SchedCodes.ToList();
            var convAddresses = convDbContext.Addresses.ToList();
            var phones = convDbContext.Phones.ToList();




            var newLocations = new List<BillingLocation>();
            var newAppointmentTypes = new List<SchedulingAppointmentType>();
            var newGuarantors = new List<DmgGuarantor>();
            var newProviders = new List<DmgProvider>();
            var newInsuranceCompanies = new List<InsInsuranceCompany>();
            var newAppointments = new List<SchedulingAppointment>();
            var newPatientAlerts = new List<DmgPatientAlert>();
            var newPatientDocuments = new List<ImgPatientDocument>();
            var newPatientInsurances = new List<DmgPatientInsurance>();
            var newPatientNotes = new List<DmgPatientRemark>();
            var newSchedulingAppointmentTypes = new List<SchedulingAppointmentType>();
            var newPatientRecallLists = new List<SchedulingPatientRecallList>();
            var newReferringProviders = new List<ReferringProvider>();
            var newOtherAddresses = new List<DmgOtherAddress>();
            var newSchedulingCodes = new List<SchedulingCode>();



            ConvertLocation(convLocations, convDbContext, ffpmDbContext, logger, progress, locations, newLocations);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "Locations Converted\n";
            });


            PatientConvert(convPatients, convDbContext, ffpmDbContext, logger, progress, ffpmPatients, patientAdditionalDetails, medicareSecondarys,
                raceXrefs, ethnicityXrefs, titleXrefs, suffixXrefs, maritalStatusXrefs, stateXrefs);

            ffpmPatients = ffpmDbContext.DmgPatients.ToList();
            resultsBox.Invoke((MethodInvoker)delegate { // change the results box text to show this completed
                resultsBox.Text += "Patients Converted\n";
            });

            // moved the foreach loops into the functions
            ConvertAppointmentType(convAppointmentTypes, convDbContext, ffpmDbContext, logger, progress, appointmentTypes, newAppointmentTypes);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "AppointmentTypes Converted\n";
            });


            ConvertAppointment(convAppointments, convDbContext, ffpmDbContext, logger, progress, convPatients, ffpmPatients, appointmentTypes, appointments, newAppointments);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "Appointments Converted\n";
            });


            ConvertInsurance(convInsurances, convDbContext, ffpmDbContext, logger, progress, insurances, stateXrefs, newInsuranceCompanies);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "Insurances Converted\n";
            });


            ConvertProvider(convProviders, convDbContext, ffpmDbContext, logger, progress, suffixXrefs, titleXrefs, ffpmProviders, newProviders);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "Providers Converted\n";
            });


            ConvertGuarantor(convGuarantors, convDbContext, ffpmDbContext, logger, progress, relationshipXrefs, genderXrefs, guarantors, ffpmPatients, newGuarantors, convPatients);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "Guarantors Converted\n";
            });


            ConvertPatientAlert(convPatientAlerts, convDbContext, ffpmDbContext, logger, progress, convPatients, ffpmPatients, priorityXrefs, patientAlerts, newPatientAlerts);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "PatientAlerts Converted\n";
            });


            ConvertPatientDocument(convPatientDocuments, convDbContext, ffpmDbContext, logger, progress, convPatients, ffpmPatients, patientDocuments, newPatientDocuments);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "PatientDocuments Converted\n";
            });


            ConvertPatientInsurance(convPatientInsurances, convDbContext, ffpmDbContext, logger, progress, convPatients, ffpmPatients, insurances, patientInsurances,
                newPatientInsurances);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "PatientInsurances Converted\n";
            });


            ConvertPatientNote(convPatientNotes, convDbContext, ffpmDbContext, logger, progress, convPatients, ffpmPatients, patientNotes, newPatientNotes);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "PatientNotes Converted\n";
            });


            ConvertPolicyHolder(policyHolders, convDbContext, ffpmDbContext, logger, progress, convPatientInsurances, convPatients, ffpmPatients,
                patientInsurances, titleXrefs, suffixXrefs, relationshipXrefs, subscribers);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "PolicyHolders Converted\n";
            });


            ConvertRecallType(convRecallTypes, convDbContext, ffpmDbContext, logger, progress, schedulingAppointmentTypes, newSchedulingAppointmentTypes);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "RecallTypes Converted\n";
            });


            ConvertRecall(convRecalls, convDbContext, ffpmDbContext, logger, progress, convPatients, ffpmPatients, convLocations, locations, patientRecallLists, newPatientRecallLists);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "Recalls Converted\n";
            });


            ConvertReferral(convReferrals, convDbContext, ffpmDbContext, logger, progress, suffixXrefs, titleXrefs, referringProviders, ffpmProviders, newReferringProviders, newProviders);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "Referrals Converted\n";
            });


            ConvertSchedCode(convSchedCodes, convDbContext, ffpmDbContext, logger, progress, schedulingCodes, newSchedulingCodes);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "SchedCodes Converted\n";
            });


            ConvertAddress(convAddresses, convDbContext, ffpmDbContext, logger, progress, addressTypes, stateXrefs, countryXrefs, convPatients, ffpmPatients, ffpmPatientAddresses,
                otherAddresses, referringProviders, convProviders, ffpmProviders, convGuarantors, guarantors, suffixXrefs, patientAdditionalDetails, convLocations,
                locations, convReferrals);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "Addresses Converted\n";
            });


            ConvertPhone(phones, convDbContext, ffpmDbContext, logger, progress, convPatients, ffpmPatients, ffpmPatientAddresses, convGuarantors, guarantors, convProviders, newProviders,
                otherAddresses, convReferrals, convLocations, locations);


            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.Text += "Phones Converted\n";
            });
        }

        public static void PatientConvert(List<Models.Patient> convPatients, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress, 
            List<DmgPatient> ffpmPatients, List<DmgPatientAdditionalDetail> patientAdditionals,
                List<MntMedicareSecondary> medicareSecondaries, List<MntRace> raceXrefs, List<MntEthnicity> ethnicityXrefs, List<MntTitle> titleXrefs,
                    List<MntSuffix> suffixXrefs, List<MntMaritalStatus> maritalStatusXrefs, List<MntState> stateXrefs) {
            long patientId = 1;
            long tempPatientId = patientId;
            if (ffpmDbContext.DmgPatients.Any()) {
                patientId = ffpmDbContext.DmgPatients.Max(p => p.PatientId) + 1;
            }
            foreach (var patient in convPatients) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try { // all patients need first and last name and for active to be yes or null (not no)
                    if (patient.LastName == null) {
                        logger.Log($"Conv: Conv Patient Last Name is null for patient with ID: {patient.Id}");
                        continue;
                    }
                    else if (patient.FirstName == null) {
                        logger.Log($"Conv: Conv Patient First Name is null for patient with ID: {patient.Id}");
                        continue;
                    }
                    else if (patient.Active != null && patient.Active.ToUpper() == "NO" || patient.Active == "0") {
                        logger.Log($"Conv: Conv Patient is not active for patient with ID: {patient.Id}");
                        continue;
                    }
                    string? ssn = patient.Ssn;
                    if (patient.Ssn == null || !ssnRegex.IsMatch(patient.Ssn)) {
                        ssn = "";
                    }

                    short? licenseShort = null; // dave spoke to me about xrefs, so if you see this, its an xref table. will be changing the rest to match
                    var stateXref = stateXrefs.FirstOrDefault(s => s.StateCode == patient.LicenseState);
                    if (stateXref != null) {
                        licenseShort = stateXref.StateId;
                    }

                    DateTime dob = minAcceptableDate;
                    if (patient.Dob != null && (patient.Dob != "")) {
                        string dobString = CleanUpDateString(patient.Dob.Trim());
                        if (DateTime.TryParseExact(dobString, dateFormats,
                        CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out dob)) {
                            dob = isValidDate(dob);
                        }
                    }
                    short? maritalStatusInt = null;
                    var maritalStatusXref = maritalStatusXrefs.FirstOrDefault(m => m.MaritalStatus == patient.MaritalStatus);
                    if (maritalStatusXref != null) {
                        maritalStatusInt = maritalStatusXref.MaritalStatusId;
                    }


                    short? titleInt = null;
                    var titleXref = titleXrefs.FirstOrDefault(t => t.Title == patient.Title);
                    if (titleXref != null) {
                        titleInt = titleXref.TitleId;
                    }

                    short? suffixInt = null;
                    var suffixXref = suffixXrefs.FirstOrDefault(s => s.Suffix == patient.Suffix);
                    if (suffixXref != null) {
                        suffixInt = suffixXref.SuffixId;
                    }

                    short? genderInt = null; // im not gonna bother with an xref here
                    if (patient.Sex != null) {
                        genderInt = patient.Sex.ToLower() == "m" ? (short)1 : (short)2;
                    }

                    short? race = null;
                    var raceXref = raceXrefs.FirstOrDefault(s => s.Race == patient.Race);
                    if (raceXref != null) {
                        race = raceXref.RaceId;
                    }

                    short? ethnicity = null;
                    var ethnicityXref = ethnicityXrefs.FirstOrDefault(s => s.Ethnicity == patient.Ethnicity);
                    if (ethnicityXref != null) {
                        ethnicity = ethnicityXref.EthnicityId;
                    }

                    bool? patientIsActive = true; // default is active, has to be explicitely no to be inactive
                    if (patient.Active != null) {
                        if (patient.Active.ToUpper() == "NO" || patient.Active == "0") {
                            patientIsActive = false;
                        }
                    }

                    bool? deceased = null;
                    if (patient.Deceased != null) {
                        deceased = (patient.Deceased.ToUpper() == "NO" || patient.Deceased.ToUpper() == "FALSE") ? false : true;
                    }

                    bool? consent = null;
                    if (patient.Consent != null) {
                        if (patient.Consent.ToUpper() == "YES" || patient.Consent == "1" || patient.Consent.ToUpper() == "TRUE") {
                            consent = true;
                        }
                        else if (patient.Consent.ToUpper() == "NO" || patient.Consent == "0" || patient.Consent.ToUpper() == "FALSE") {
                            consent = false;
                        }
                    }

                    DateTime? consentDate = null;
                    if (patient.ConsentDate != null && (patient.ConsentDate != "")) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(patient.ConsentDate, dateFormats,
                            CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            consentDate = isValidDate(tempDateTime);
                        }
                    }
                    DateOnly? deceasedDate = null;
                    if (patient.DateOfDeath != null && (patient.DateOfDeath != "")) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(patient.DateOfDeath, dateFormats,
                                                   CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            deceasedDate = DateOnly.FromDateTime(isValidDate(tempDateTime));
                        }
                    }
                    DateTime lastExamDate = minAcceptableDate;
                    if (patient.LastExamDate != null && (patient.LastExamDate != "")) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(patient.LastExamDate, dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            lastExamDate = isValidDate(tempDateTime);
                        }
                    }
                    if (patient.Email != null) {
                        string email = TruncateString(patient.Email, 50);
                    }
                    bool isEmailValid = new EmailAddressAttribute().IsValid(patient.Email);
                    bool dontSendStatements = false;
                    bool emailStatements = false;
                    short? prefContact1 = null;
                    if (patient.PreferredContact1 != null) {
                        if (short.TryParse(patient.PreferredContact1, out short prefContact1Int)) {
                            prefContact1 = prefContact1Int;
                        }
                    }
                    short? prefContact2 = null;
                    if (patient.PreferredContact2 != null) {
                        if (short.TryParse(patient.PreferredContact2, out short prefContact2Int)) {
                            prefContact2 = prefContact2Int;
                        }
                    }
                    short? prefContact3 = null;
                    if (patient.PreferredContact3 != null) {
                        if (short.TryParse(patient.PreferredContact3, out short prefContact3Int)) {
                            prefContact3 = prefContact3Int;
                        }
                    }
                    string preferredContactsNotes = patient.PreferredContact1 + "; " + patient.PreferredContact2 + "; " + patient.PreferredContact3;

                    short? medicareSecondaryId = null;
                    string medicareSecondaryNotes = "";
                    var medicareSecondary = medicareSecondaries.FirstOrDefault(m => m.MedicareSecondarryCode == patient.MedicareSecondaryCode);
                    if (medicareSecondary != null) {
                        medicareSecondaryId = medicareSecondary.MedicareSecondaryId;
                        if (medicareSecondary.MedicareSecondaryDescription != null) {
                            medicareSecondaryNotes = medicareSecondary.MedicareSecondaryDescription;
                        }
                    }

                    DmgPatient? ffpmOrig = null;
                    ffpmOrig = ffpmPatients.FirstOrDefault(p => p.AccountNumber == patient.OldPatientAccountNumber || (p.FirstName == patient.FirstName
                        && p.LastName == patient.LastName && p.MiddleName == patient.MiddleName && p.Ssn == ssn));

                    if (ffpmOrig == null) {
                        var newPatient = new Brady_s_Conversion_Program.ModelsA.DmgPatient {
                            DateCreated = minAcceptableDate,
                            AccountNumber = TruncateString(patient.OldPatientAccountNumber, 10),
                            AltAccountNumber = TruncateString(patient.OldPatientAltAccountNumber, 10),
                            LastName = TruncateString(patient.LastName, 50),
                            MiddleName = TruncateString(patient.MiddleName, 50),
                            FirstName = TruncateString(patient.FirstName, 50),
                            PreferredName = TruncateString(patient.PreferredName, 50),
                            Ssn = TruncateString(patient.Ssn, 15),
                            DateOfBirth = dob,
                            MaritialStatusId = maritalStatusInt,
                            TitleId = titleInt,
                            IsActive = patientIsActive,
                            IsDeceased = deceased,
                            DeceasedDate = deceasedDate,
                            LastExamDate = lastExamDate,
                            PatientBalance = -1,
                            InsuranceBalance = -1,
                            OtherBalance = -1,
                            GenderId = genderInt,
                            SuffixId = suffixInt,
                            BalanceLastUpdatedDateTime = minAcceptableDate,
                            EmailNotApplicable = isEmailValid,
                            DoNotSendStatements = dontSendStatements,
                            EmailStatements = emailStatements,
                            OpenEdgeCustomerId = TruncateString("", 100),
                            TextStatements = true,
                            LocationId = 0,
                            LastModifiedDate = DateTime.Now,
                            LastModifiedBy = -1
                        };
						tempPatientId = patientId;
						patientId++;
                        ffpmPatients.Add(newPatient);

                        var patientAdditionalDetail = patientAdditionals.FirstOrDefault(ad => ad.PatientId == tempPatientId);
                        if (patientAdditionalDetail == null) {
                            var newAdditionDetails = new Brady_s_Conversion_Program.ModelsA.DmgPatientAdditionalDetail {
                                PatientId = tempPatientId,
                                DriversLicenseNumber = TruncateString(patient.LicenseNo, 25),
                                DriversLicenseStateId = licenseShort,
                                RaceId = race,
                                EthnicityId = ethnicity,
                                MedicareSecondaryId = medicareSecondaryId,
                                MedicareSecondaryNotes = medicareSecondaryNotes,
                                HippaConsent = consent,
                                HippaConsentDate = consentDate,
                                PreferredContactFirstId = prefContact1,
                                PreferredContactSecondId = prefContact2,
                                PreferredContactThirdId = prefContact3,
                                PreferredContactNotes = TruncateString(preferredContactsNotes, 500),
                                DefaultLocationId = 0
                            };
                            patientAdditionals.Add(newAdditionDetails);
                        }
                    } else {
                        tempPatientId = ffpmOrig.PatientId;
					}
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the patient with ID: {patient.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.DmgPatients.UpdateRange(ffpmPatients);
            ffpmDbContext.DmgPatientAdditionalDetails.UpdateRange(patientAdditionals);
            ffpmDbContext.SaveChanges();
            patientAdditionals = ffpmDbContext.DmgPatientAdditionalDetails.ToList();
        }

        public static void ConvertAppointmentType(List<Models.AppointmentType> convAppointmentTypes, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext,
           ILogger logger, ProgressBar progress, List<SchedulingAppointmentType> appointmentTypes, List<SchedulingAppointmentType> newAppointmentTypes) {
            foreach (var appointmentType in convAppointmentTypes) {
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
                    if (appointmentType.Active != null && (appointmentType.Active.ToLower() == "yes" || appointmentType.Active == "1")) {
                        isActive = true;
                    }
                    bool schedule = false;
                    if (appointmentType.CanSchedule != null && (appointmentType.CanSchedule.ToLower() == "yes" || appointmentType.CanSchedule == "1")) {
                        schedule = true;
                    }
                    bool required = false;
                    if (appointmentType.PatientRequired != null && (appointmentType.PatientRequired.ToLower() == "yes" || appointmentType.PatientRequired == "1")) {
                        required = true;
                    }
                    bool examType = false;
                    if (appointmentType.IsExamType != null && (appointmentType.IsExamType.ToLower() == "yes" || appointmentType.IsExamType == "1")) {
                        examType = true;
                    }
                    string code = "";
                    if (appointmentType.OldAppointmentTypeCode != null) {
                        code = appointmentType.OldAppointmentTypeCode;
                    }
                    string description = "";
                    if (appointmentType.Description != null) {
                        description = appointmentType.Description;
                    }
                    string notes = "";
                    if (appointmentType.Notes != null) {
                        notes = appointmentType.Notes;
                    }

                    var ffpmOrig = appointmentTypes.FirstOrDefault(p => p.Code == code);

                    if (ffpmOrig == null) {
                        var newAppointmentType = new SchedulingAppointmentType {
                            Code = TruncateString(code, 200), 
                            Description = TruncateString(description, 1000),
                            LocationId = 0,
                            PatientRequired = required,
                            Notes = TruncateString(notes, 5000),
                            IsExamType = examType,
                            IsAppointmentType = true,
                            IsRecallType = false, // Will set this to true for recall types
                            DefaultDuration = duration,
                            Active = isActive,
                            CanSchedule = schedule
                        };
                        newAppointmentTypes.Add(newAppointmentType);
                        appointmentTypes.Add(newAppointmentType);
                    }
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the appointment type with ID: {appointmentType.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.SchedulingAppointmentTypes.AddRange(newAppointmentTypes);
            ffpmDbContext.SaveChanges();
            appointmentTypes.AddRange(newAppointmentTypes);
            newAppointmentTypes.Clear();
        }

        public static void ConvertAppointment(List<Models.Appointment> convAppointments, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext,
            ILogger logger, ProgressBar progress, List<Models.Patient> convPatients, List<DmgPatient> ffpmPatients, List<SchedulingAppointmentType> appointmentTypes,
                List<SchedulingAppointment> appointments, List<SchedulingAppointment> newAppointments) {
            foreach (var appointment in convAppointments) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    int locationId = -1;
                    int patientId = -1;
                    if (appointment.PatientId > 0) {
                        var convPatient = convPatients.FirstOrDefault(p => p.Id == appointment.PatientId);
                        if (convPatient != null) {
                            var ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber && (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
                            if (ffpmPatient != null) {
                                patientId = (int)ffpmPatient.PatientId;
                                locationId = ffpmPatient.LocationId;
                            }
                        }
                    }

                    long resource = -1;
                    if (appointment.OldResourceId != null) {
                        long.TryParse(appointment.OldResourceId, out resource);
                    }

                    DateTime start = minAcceptableDate;
                    if (appointment.StartDate != null && (appointment.StartDate != "" && !int.TryParse(appointment.StartDate, out int dontCare))) {
                        if (DateTime.TryParseExact(CleanUpDateString(appointment.StartDate), dateFormats,
                                       CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out DateTime temp)) {
                            start = isValidDate(temp);
                        }
                    }
                    DateTime end = minAcceptableDate;
                    if (appointment.EndDate != null && (appointment.EndDate != "" && !int.TryParse(appointment.EndDate, out dontCare))) {
                        if (DateTime.TryParseExact(CleanUpDateString(appointment.EndDate), dateFormats,
                                     CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out DateTime temp)) {
                            end = isValidDate(temp);
                        }
                    }
                    int duration = -1;
                    if (appointment.Duration != null) {
                        if (int.TryParse(appointment.Duration, out int durationInt)) {
                            duration = durationInt;
                        }
                    }
                    DateTime created = minAcceptableDate;
                    if (appointment.DateTimeCreated != null && (appointment.DateTimeCreated != "" && !int.TryParse(appointment.DateTimeCreated, out dontCare))) {
                        if (DateTime.TryParseExact(CleanUpDateString(appointment.DateTimeCreated), dateFormats,
                                                                    CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out created)) {
                            created = isValidDate(created);
                        }
                    }
                    int billingLocId = 0;
                    if (appointment.OldBillingLocationId != null) {
                        if (int.TryParse(appointment.OldBillingLocationId, out int billingLocIdInt)) {
                            billingLocId = billingLocIdInt;
                        }
                    }
                    bool confirmed = false;
                    if (appointment.Confirmed != null && appointment.Confirmed.ToLower() == "yes" || appointment.Confirmed == "1") {
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
                    if (appointment.CheckInDateTime != null && (appointment.CheckInDateTime != "" && !int.TryParse(appointment.CheckInDateTime, out dontCare))) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(CleanUpDateString(appointment.CheckInDateTime), dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            checkIn = isValidDate(tempDateTime);
                        }
                    }
                    DateTime? takeback = null;
                    if (appointment.TakeBackDateTime != null && (appointment.TakeBackDateTime != "" && !int.TryParse(appointment.TakeBackDateTime, out dontCare))) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(CleanUpDateString(appointment.TakeBackDateTime), dateFormats,
                                                  CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            takeback = isValidDate(tempDateTime);
                        }
                    }
                    DateTime? checkOut = null;
                    if (appointment.CheckOutDateTime != null && (appointment.TakeBackDateTime != "" && !int.TryParse(appointment.CheckOutDateTime, out dontCare))) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(CleanUpDateString(appointment.CheckOutDateTime), dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            checkOut = isValidDate(tempDateTime);
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
                    int type = -1;
                    var typeXref = appointmentTypes.FirstOrDefault(s => s.Code == appointment.OldAppointmentTypeId);
                    if (typeXref != null) {
                        type = (int)typeXref.AppointmentTypeId;
                    }
                    DateTime? updated = null;
                    if (appointment.DateTimeUpdated != null && (appointment.DateTimeUpdated != "" && !int.TryParse(appointment.DateTimeUpdated, out dontCare))) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(CleanUpDateString(appointment.DateTimeUpdated), dateFormats,
                                                                      CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            updated = isValidDate(tempDateTime);
                        }
                    }
                    if (updated == DateTime.Parse("1/1/0001 12:00:00 AM")) {
                        updated = null;
                    }
                    if (checkIn == DateTime.Parse("1/1/0001 12:00:00 AM")) {
                        checkIn = null;
                    }
                    if (takeback == DateTime.Parse("1/1/0001 12:00:00 AM")) {
                        takeback = null;
                    }
                    if (checkOut == DateTime.Parse("1/1/0001 12:00:00 AM")) {
                        checkOut = null;
                    }
                    if (start == DateTime.Parse("1/1/0001 12:00:00 AM")) {
                        start = minAcceptableDate;
                    }
                    if (end == DateTime.Parse("1/1/0001 12:00:00 AM")) {
                        end = minAcceptableDate;
                    }
                    if (created == DateTime.Parse("1/1/0001 12:00:00 AM")) {
                        created = minAcceptableDate;
                    }
                    if (updated == DateTime.Parse("1/1/0001 12:00:00 AM")) {
                        updated = null;
                    }



                    var newAppointment = new SchedulingAppointment {
                        PatientId = patientId,
                        ResourceId = resource,
                        BillingLocationId = billingLocId,
                        StartDate = start,
                        EndDate = end,
                        Notes = TruncateString(appointment.Notes, 2000),
                        Duration = duration,
                        DateTimeCreated = created,
                        LocationId = locationId,
                        Confirmed = confirmed,
                        Sequence = sequence,
                        RequestId = requestId,
                        Status = status,
                        CheckInDateTime = minAcceptableDate,
                        TakeBackDateTime = takeback,
                        CheckOutDateTime = checkOut,
                        Description = TruncateString(appointment.Description, 2000),
                        PriorAppointmentId = prior,
                        LinkedAppointmentId = linked,
                        SchedulingCodeId = schedulingCode,
                        SchedulingCodeNotes = TruncateString(appointment.SchedulingCodeNotes, 2000),
                        AppointmentTypeId = type,
                        DateTimeUpdated = minAcceptableDate
                    };
                    newAppointments.Add(newAppointment);
                    appointments.Add(newAppointment);
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the appointment with ID: {appointment.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.SchedulingAppointments.AddRange(newAppointments);
            ffpmDbContext.SaveChanges();
            newAppointments.Clear();
        }

        public static void ConvertInsurance(List<Models.Insurance> convInsurances, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<InsInsuranceCompany> insuranceCompanies, List<MntState> stateXrefs, List<InsInsuranceCompany> newInsuranceCompanies) {
            foreach (var insurance in convInsurances) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    foreach (var company in ffpmDbContext.InsInsuranceCompanies) {
                        if (company.InsCompanyName == insurance.InsCompanyName) {
                            logger.Log($"Conv: Conv duplicate insurance company with name: {insurance.InsCompanyName}");
                            continue;
                        }
                    }

                    int stateId = -1;
                    var stateXref = stateXrefs.FirstOrDefault(s => s.StateCode == insurance.InsCompanyState);
                    if (stateXref != null) {
                        stateId = stateXref.StateId;
                    }

                    string insZip = "";
                    if (insurance.InsCompanyZip != null) {
                        if (zipRegex.IsMatch(insurance.InsCompanyZip)) {
                            insZip = insurance.InsCompanyZip;
                        }
                    }

                    string insEmail = "";
                    if (insurance.InsCompanyEmail != null) {
                        insEmail = TruncateString(insurance.InsCompanyEmail, 50);
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
                    

                    bool active = false;
                    if (insurance.Active != null && (insurance.Active.ToLower() == "yes" || insurance.Active == "1")) {
                        active = true;
                    }

                    bool collections = false;
                    if (insurance.IsCollections != null && (insurance.IsCollections.ToLower() == "yes" || insurance.IsCollections == "1")) {
                        collections = true;
                    }

                    bool dmerc = false;
                    if (insurance.IsDmerc != null && (insurance.IsDmerc.ToLower() == "yes" || insurance.IsDmerc == "1")) {
                        dmerc = true;
                    }
                    string companyName = "";
                    if (insurance.InsCompanyName != null) {
                        companyName = insurance.InsCompanyName;
                    }
                    string? code = "";
                    if (insurance.InsuranceCompanyCode != null) {
                        int temp = -1;
                        if (int.TryParse(insurance.InsuranceCompanyCode, out int dontCare))
                            temp = dontCare;
                        if (temp <= -1) {
                            logger.Log($"FFPM: FFPM Insurance company code not found for insurance with ID: {insurance.Id}");
                        }
                        code = insuranceCodes.GetValueOrDefault(temp);

                        if (code == null) {
                            logger.Log($"FFPM: FFPM Insurance company code not found for insurance with ID: {insurance.Id}");
                        }
                    }
                    int companyId = 0;
                    if (insurance.OldInsCompanyId != null) {
                        if (int.TryParse(insurance.OldInsCompanyId, out int companyIdInt)) {
                            companyId = companyIdInt;
                        }
                    }
                    int claimTypeId = 0;
                    if (insurance.InsCompanyClaimType != null) {
                        if (insurance.InsCompanyClaimType.ToLower() == "medical") {
                            claimTypeId = 1;
                        }
                        else if (insurance.InsCompanyClaimType.ToLower() == "vision") {
                            claimTypeId = 2;
                        }
                    }
                    int policyTypeId = 0;
                    if (insurance.InsCompanyPolicyType != null) {
                        if (insurance.InsCompanyPolicyType.ToLower() == "medical") {
                            policyTypeId = 1;
                        }
                        else if (insurance.InsCompanyPolicyType.ToLower() == "vision") {
                            policyTypeId = 2;
                        }
                    }
                    int? carrierTypeId = 0;
                    if (insurance.InsCompanyCarrierType == "medical") {
                        carrierTypeId = 1;
                    }
                    else if (insurance.InsCompanyCarrierType == "vision") {
                        carrierTypeId = 2;
                    }

                    var ffpmOrig = insuranceCompanies.FirstOrDefault(p => p.InsCompanyName == companyName);

                    if (ffpmOrig == null) {
                        var newInsuranceCompany = new Brady_s_Conversion_Program.ModelsA.InsInsuranceCompany {
                            InsCompanyName = TruncateString(companyName, 150),
                            InsCompanyAddress1 = TruncateString(insurance.InsCompanyAddress1, 100),
                            InsCompanyAddress2 = TruncateString(insurance.InsCompanyAddress2, 100),
                            InsCompanyCity = TruncateString(insurance.InsCompanyCity, 50),
                            InsCompanyStateId = stateId,
                            InsCompanyZip = TruncateString(insZip, 10),
                            InsCompanyPhone = TruncateString(insPhone, 25),
                            InsCompanyFax = TruncateString(insFax, 25),
                            InsCompanyCode = TruncateString(code, 15),
                            InsCompanyEmail = TruncateString(insEmail, 25),
                            InsCompanyPayerId = TruncateString(payerId, 25),
                            IsActive = active,
                            IsCollectionsInsurance = collections,
                            IsDmercPlaceOfService = dmerc,
                            CategoryId = 0,
                            ResponsibilityId = 0,
                            PaymentTransaction = "",  // No truncation specified but should be managed if needed
                            AdjustmentTransaction = "",  // Ditto
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
                        newInsuranceCompanies.Add(newInsuranceCompany);
                        insuranceCompanies.Add(newInsuranceCompany);
                    }
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the insurance with ID: {insurance.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.InsInsuranceCompanies.AddRange(newInsuranceCompanies);
            ffpmDbContext.SaveChanges();
            insuranceCompanies = ffpmDbContext.InsInsuranceCompanies.ToList();
            newInsuranceCompanies.Clear();
        }

        public static void ConvertLocation(List<Models.Location> convLocations, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<BillingLocation> locations, List<BillingLocation> newLocations) {
            foreach (var location in convLocations) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    string? name = null;
                    if (location.LocationName != null && location.LocationName != "") {
                        name = location.LocationName;
                    }
                    else {
                        logger.Log($"Conv: Conv Location Name is null for location with ID: {location.Id}");
                        continue;
                    }

                    #region taxonomys
                    int primaryTaxId = 0;
                    if (int.TryParse(name, out int dontCare)) {
                        primaryTaxId = dontCare;
                    }
                    else {
                        logger.Log($"Conv: Conv Primary taxonomy ID not found for location with ID: {location.Id}");
                    }

                    int tax1Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy1Id, out int tax1IdInt)) {
                        tax1Id = tax1IdInt;
                    }

                    int tax2Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy2Id, out int tax2IdInt)) {
                        tax2Id = tax2IdInt;
                    }

                    int tax3Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy3Id, out int tax3IdInt)) {
                        tax3Id = tax3IdInt;
                    }

                    int tax4Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy4Id, out int tax4IdInt)) {
                        tax4Id = tax4IdInt;
                    }

                    int tax5Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy5Id, out int tax5IdInt)) {
                        tax5Id = tax5IdInt;
                    }

                    int tax6Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy6Id, out int tax6IdInt)) {
                        tax6Id = tax6IdInt;
                    }

                    int tax7Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy7Id, out int tax7IdInt)) {
                        tax7Id = tax7IdInt;
                    }

                    int tax8Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy8Id, out int tax8IdInt)) {
                        tax8Id = tax8IdInt;
                    }

                    int tax9Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy9Id, out int tax9IdInt)) {
                        tax9Id = tax9IdInt;
                    }

                    int tax10Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy10Id, out int tax10IdInt)) {
                        tax10Id = tax10IdInt;
                    }

                    int tax11Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy11Id, out int tax11IdInt)) {
                        tax11Id = tax11IdInt;
                    }

                    int tax12Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy12Id, out int tax12IdInt)) {
                        tax12Id = tax12IdInt;
                    }

                    int tax13Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy13Id, out int tax13IdInt)) {
                        tax13Id = tax13IdInt;
                    }

                    int tax14Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy14Id, out int tax14IdInt)) {
                        tax14Id = tax14IdInt;
                    }

                    int tax15Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy15Id, out int tax15IdInt)) {
                        tax15Id = tax15IdInt;
                    }

                    int tax16Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy16Id, out int tax16IdInt)) {
                        tax16Id = tax16IdInt;
                    }

                    int tax17Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy17Id, out int tax17IdInt)) {
                        tax17Id = tax17IdInt;
                    }

                    int tax18Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy18Id, out int tax18IdInt)) {
                        tax18Id = tax18IdInt;
                    }

                    int tax19Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy19Id, out int tax19IdInt)) {
                        tax19Id = tax19IdInt;
                    }

                    int tax20Id = 0;
                    if (int.TryParse(location.AlternateTaxonomy20Id, out int tax20IdInt)) {
                        tax20Id = tax20IdInt;
                    }
                    #endregion taxonomys

                    bool isBilling = false;
                    if (location.IsBilling != null && (location.IsBilling.ToLower() == "yes" || location.IsBilling == "1")) {
                        isBilling = true;
                    }
                    bool isSchedule = false;
                    if (location.IsScheduling != null && (location.IsScheduling.ToLower() == "yes" || location.IsScheduling == "1")) {
                        isSchedule = true;
                    }

                    int treatmentPlaceId = 0;
                    if (int.TryParse(location.PlaceOfTreatment, out int temp)) {
                        treatmentPlaceId = temp;
                    }

                    var ffpmOrig = locations.FirstOrDefault(x => x.Name != null && x.Name.ToLower() == name.ToLower());

                    if (ffpmOrig == null) {
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

                            Name = TruncateString(name, 500),
                            IsBillingLocation = isBilling,
                            CliaIdNo = TruncateString(location.Clia, 15),
                            Npi = TruncateString(location.Npi, 10),
                            FederalIdNo = TruncateString(location.FederalEin, 15),
                            IsSchedulingLocation = isSchedule,
                            PlaceOfTreatmentId = treatmentPlaceId,
                            LocationId = 0,
                            IsActive = true,
                            CaculateTaxOnEstimatedPatientBalance = false,
                            IsDefaultLocation = true,
                            CaculateTaxOnTotalFee = false
                        };
                        locations.Add(newLocation);
                        newLocations.Add(newLocation);
                    }
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the location with ID: {location.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.BillingLocations.AddRange(newLocations);
            ffpmDbContext.SaveChanges();
            locations = ffpmDbContext.BillingLocations.ToList();
            newLocations.Clear();
        }

        public static void ConvertGuarantor(List<Models.Guarantor> convGuarantors, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<MntRelationship> relationshipXrefs, List<MntGender> genderXrefs, List<DmgGuarantor> guarantors, List<DmgPatient> ffpmPatients, List<DmgGuarantor> newGuarantors,
                List<Models.Patient> convPatients) {
            foreach (var guarantor in convGuarantors) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    var convPatient = convPatients.FirstOrDefault(cp => cp.Id == guarantor.PatientId);
                    if (convPatient == null) {
                        logger.Log($"Conv: Conv Patient not found for guarantor with ID: {guarantor.Id}");
                        continue;
                    }
                    var ffpmPatient = ffpmPatients.FirstOrDefault(p => (p.AccountNumber == convPatient.OldPatientAccountNumber) ||
                        (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
                    if (ffpmPatient == null) {
                        logger.Log($"Conv: FFPM Patient not found for guarantor with ID: {guarantor.Id}");
                        continue;
                    }

                    string ssn = "";
                    if (guarantor.Ssn != null) {
                        if (ssnRegex.IsMatch(guarantor.Ssn)) {
                            ssn = guarantor.Ssn;
                        }
                    }
                    DateTime? dob = null;
                    if (guarantor.Dob != null && guarantor.Dob != "" && !int.TryParse(guarantor.Dob, out int dontCare)) {
                        if (DateTime.TryParseExact(guarantor.Dob, dateFormats,
                                                   CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out DateTime tempDate)) {
                            dob = isValidDate(tempDate);
                        }
                    }
                    short? relationID = null;
                    var relationXref = relationshipXrefs.FirstOrDefault(r => r.Relationship == guarantor.Relationship);
                    if (relationXref != null) {
                        relationID = relationXref.RelationshipId;
                    }
                    short? titleID = null;
                    // no titleID in incoming tables
                    short? suffixID = null;
                    // no suffixID in incoming tables
                    short? genderID = null;
                    var genderXref = genderXrefs.FirstOrDefault(g => g.Gender == guarantor.Sex);
                    if (genderXref != null) {
                        genderID = genderXref.GenderId;
                    }
                    bool? isActive = null;
                    if (guarantor.Active != null && guarantor.Active.ToLower() == "yes" || guarantor.Active == "1") {
                        isActive = true;
                    }
                    bool? guarantorIsPatient = null;
                    if (guarantor.OldGuarantorAccount != "" && guarantor.OldGuarantorAccount != null) {
                        guarantorIsPatient = true;
                    }
                    long? guarantorIsPatientID = null;
                    if (guarantorIsPatient == true) {
                        guarantorIsPatient = true;
                        if (long.TryParse(guarantor.OldGuarantorAccount, out long id)) {
                            guarantorIsPatientID = id;
                        }
                    }

                    short? employmentStatusID = null;
                    // no employmentStatusID in incoming tables
                    DateTime? addedDate = null;
                    // no addedDate in incoming tables
                    DateTime? removedDate = null;
                    // no removedDate in incoming tables
                    DateTime? lastModified = null;
                    // no lastModified in incoming tables


                    var existingGuarantor = guarantors.FirstOrDefault(p => p.PatientId == ffpmPatient.PatientId);

                    if (existingGuarantor == null) {
                        var newGuarantor = new Brady_s_Conversion_Program.ModelsA.DmgGuarantor {
                            PatientId = ffpmPatient.PatientId,
                            FirstName = TruncateString(guarantor.FirstName, 50),
                            LastName = TruncateString(guarantor.LastName, 50),
                            MiddleName = TruncateString(guarantor.MiddleName, 50),
                            Ssn = TruncateString(ssn, 15),
                            Dob = dob,
                            RelationId = relationID,
                            TitleId = titleID,
                            SuffixId = suffixID,
                            GenderId = genderID,
                            IsActive = isActive,
                            EmploymentStatusId = employmentStatusID,
                            AddedDate = addedDate,
                            RemovedDate = removedDate,
                            LastModifiedDate = lastModified,
                            GuarantorExistingPatientId = guarantorIsPatientID,
                            AddressId = null,
                            IsGuarantorExistingPatient = guarantorIsPatient,
                            LastModifiedBy = null
                        };
                        newGuarantors.Add(newGuarantor);
                    }
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the guarantor with ID: {guarantor.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.DmgGuarantors.AddRange(newGuarantors);
            ffpmDbContext.SaveChanges();
            guarantors = ffpmDbContext.DmgGuarantors.ToList();
            newGuarantors.Clear();
        }

        public static void ConvertAddress(List<Models.Address> convAddresses, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<MntAddressType> addressTypes, List<MntState> stateXrefs, List<MntCountry> countryXrefs, List<Models.Patient> convPatients, List<DmgPatient> ffpmPatients,
                List<DmgPatientAddress> ffpmPatientAddresses, List<DmgOtherAddress> otherAddresses, List<ReferringProvider> referringProviders, List<Provider> convProviders,
                    List<DmgProvider> ffpmProviders, List<Guarantor> convGuarantors, List<DmgGuarantor> guarantors, List<MntSuffix> suffixXrefs,
                        List<DmgPatientAdditionalDetail> patientAdditionalDetails, List<Models.Location> convLocations, List<BillingLocation> locations, List<Referral> referrals) {
            var newOtherAddresses = new List<DmgOtherAddress>();
            long patientAddressId = 1;
            long otherAddressId = 1;
            if (ffpmDbContext.DmgPatientAddresses.Any())
                patientAddressId = ffpmDbContext.DmgPatientAddresses.Max(p => p.PatientAddressId) + 1;
            if (ffpmDbContext.DmgOtherAddresses.Any())
                otherAddressId = ffpmDbContext.DmgOtherAddresses.Max(p => p.AddressId) + 1;
            guarantors = ffpmDbContext.DmgGuarantors.ToList();
            patientAdditionalDetails = ffpmDbContext.DmgPatientAdditionalDetails.ToList();
            foreach (var address in convAddresses) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    short? addressType = null;
                    var addressTypeXref = addressTypes.FirstOrDefault(s => s.AddressTypeName == address.TypeOfAddress && s.IsActive);
                    if (addressTypeXref != null) {
                        addressType = addressTypeXref.AddressTypeId;
                    }

                    short? state = null;
                    var stateXref = stateXrefs.FirstOrDefault(s => s.StateCode == address.State);
                    if (stateXref != null) {
                        state = stateXref.StateId;
                    }

                    short? country = null;
                    var countryXref = countryXrefs.FirstOrDefault(s => s.CountryName.ToUpper() == "US" || s.CountryName.ToUpper() == "USA");
                    if (countryXref != null) {
                        country = countryXref.CountryId;
                    }

                    string? zipCode = null;
                    if (address.Zip != null && zipRegex.IsMatch(address.Zip)) {
                        zipCode = address.Zip;
                    }

                    bool isActive = true;
                    if (address.Active != null && (address.Active.ToLower() == "no" || address.Active == "0")) {
                        isActive = false;
                    }

                    string? primaryFile = address.PrimaryFile;
                    if (primaryFile == null) {
                        primaryFile = "";
                    }
                    switch (primaryFile.ToLower()) {
                        case "pat":
                            var convPatient = convPatients.FirstOrDefault(p => p.Id.ToString() == address.PrimaryFileId);
                            if (convPatient == null) {
                                logger.Log($"Conv: Conv Patient not found for address with ID: {address.Id}");
                                continue;
                            }

                            var ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber ||
                                (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
                            if (ffpmPatient == null) {
                                logger.Log($"Conv: Conv Patient not found for address with ID: {address.Id}");
                                continue;
                            }

                            var ffpmPatientAdditional = patientAdditionalDetails.FirstOrDefault(p => p.PatientId == ffpmPatient.PatientId);
                            if (ffpmPatientAdditional == null) {
                                logger.Log($"Conv: FFPM Patient additional not found for address with ID: {address.Id}");
                                continue;
                            }

                            bool isPrimary = false;
                            bool isAlternate = false;
                            bool isEmergency = false;
                            bool isPreferred = false;

                            string zipExt = "";
                            if (zipCode != null && zipCode.Length > 5) {
                                zipExt = zipCode.Substring(5);
                            }

                            short? tempSuffixID = null;
                            var suffixXref = suffixXrefs.FirstOrDefault(s => s.Suffix == convPatient.Suffix);
                            if (suffixXref != null) {
                                tempSuffixID = suffixXref.SuffixId;
                            }

                            if (address.TypeOfAddress != null) {
                                switch (address.TypeOfAddress.ToLower()) {
                                    case "primary":
                                        isPrimary = true;
                                        isPreferred = true;
                                        break;
                                    case "alternate":
                                        isAlternate = true;
                                        break;
                                    case "emergency":
                                        isEmergency = true;
                                        break;
                                    default:
                                        break;
                                }
                            }

                            var ffpmOrig = ffpmPatientAddresses.FirstOrDefault(p => isPrimary && (p.PatientId == ffpmPatient.PatientId &&
                                    p.IsPrimary == true));

                            if (ffpmOrig == null) {
                                var newAddress = new Brady_s_Conversion_Program.ModelsA.DmgPatientAddress {
                                    PatientId = ffpmPatient.PatientId,
                                    Address1 = TruncateString(address.Address1, 50),
                                    Address2 = TruncateString(address.Address2, 50),
                                    City = TruncateString(address.City, 50),
                                    StateId = state,
                                    Zip = TruncateString(zipCode, 10),
                                    Email = TruncateString(convPatient.Email, 50),
                                    Notes = TruncateString(address.Note, 1000),
                                    IsPrimary = isPrimary,
                                    IsActive = isActive,
                                    IsPreferred = isPreferred,
                                    IsEmergencyContactAddress = isEmergency,
                                    IsAlternateAddress = isAlternate,
                                    AddressType = addressType
                                };
                                ffpmPatientAddresses.Add(newAddress);
                                if (isPrimary) {
                                    ffpmPatient.AddressId = patientAddressId;
                                }
                                patientAddressId++;
                            }
                            break;
                        case "guar":
                            int primaryFileId = -1;
                            if (int.TryParse(address.PrimaryFileId, out int primaryFileIdInt)) {
                                primaryFileId = primaryFileIdInt;
                            }
                            if (primaryFileId == -1) {
                                logger.Log($"Conv: Conv Guarantor ID not found for address (guarantor) with ID: {address.Id}");
                                continue;
                            }
                            var convGuarantor = convGuarantors.FirstOrDefault(g => g.Id == primaryFileId);
                            if (convGuarantor == null) {
                                logger.Log($"Conv: Conv Guarantor not found for address (guarantor) with ID: {address.Id}");
                                continue;
                            }
                            convPatient = convPatients.FirstOrDefault(cp => cp.Id == convGuarantor.PatientId);
                            if (convPatient == null) {
                                logger.Log($"Conv: Conv Patient not found for address (guarantor) with ID: {address.Id}");
                                continue;
                            }
                            if (convPatient.OldPatientAccountNumber == null) {
                                logger.Log($"Conv: Conv Patient account number not found for address (guarantor) with ID: {address.Id}");
                                continue;
                            }
                            ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber.Trim() == convPatient.OldPatientAccountNumber.Trim());
                            if (ffpmPatient == null) {
                                logger.Log($"Conv: FFPM Patient not found for address (guarantor) with ID: {address.Id}");
                                continue;
                            }
                            var guarantor = guarantors.FirstOrDefault(g => g.PatientId == ffpmPatient.PatientId);
                            if (guarantor == null) {
                                logger.Log($"Conv: FFPM Guarantor not found for address (guarantor) with ID: {address.Id}");
                                continue;
                            }

                            var otherAddress = otherAddresses.FirstOrDefault(p => p.OwnerId == guarantor.GuarantorId && p.OwnerType == 0);

                            if (otherAddress == null) {
                                var newOtherAddress = new Brady_s_Conversion_Program.ModelsA.DmgOtherAddress {
                                    OwnerId = guarantor.GuarantorId,
                                    Address1 = TruncateString(address.Address1, 50),
                                    Address2 = TruncateString(address.Address2, 50),
                                    City = TruncateString(address.City, 50),
                                    CountryId = country,
                                    StateId = state,
                                    Zip = TruncateString(zipCode, 10),
                                    IsActive = isActive,
                                    AddressType = addressType,
                                    OwnerType = 1
                                };
                                otherAddresses.Add(newOtherAddress);
                                guarantor.AddressId = otherAddressId;
                                otherAddressId++;
                            }
                            break;
                        case "loc":
                            var billingLocation = convLocations.FirstOrDefault(l => l.OldLocationId == address.PrimaryFileId);
                            if (billingLocation == null) {
                                logger.Log($"Conv: Conv no billing location for location for address with ID: {address.Id}");
                                continue;
                            }
                            var ffpmLocation = locations.FirstOrDefault(l => l.Name == billingLocation.LocationName);
                            if (ffpmLocation == null) {
                                logger.Log($"Conv: Conv no FFPM billing location for location for address with ID: {address.Id}");
                                continue;
                            }


                            var newDmgOtherAddress = new Brady_s_Conversion_Program.ModelsA.DmgOtherAddress {
                                OwnerId = ffpmLocation.LocationId,
                                Address1 = TruncateString(address.Address1, 50),
                                Address2 = TruncateString(address.Address2, 50),
                                City = TruncateString(address.City, 50),
                                StateId = state,
                                CountryId = country,
                                Zip = TruncateString(zipCode, 10),
                                IsActive = isActive,
                                AddressType = addressType,
                                OwnerType = 2
                            };
                            otherAddresses.Add(newDmgOtherAddress);
                            ffpmLocation.AddressId = otherAddressId;
                            otherAddressId++;
                            break;
                        case "prov":
                            var convProvider = convProviders.FirstOrDefault(cp => cp.Id.ToString() == address.PrimaryFileId);

                            if (convProvider == null) {
                                logger.Log($"Conv: Conv Provider not found for address with ID: {address.Id}");
                                continue;
                            }

                            var ffpmProvider = ffpmProviders.FirstOrDefault(p => p.ProviderCode == convProvider.OldProviderCode);
                            if (ffpmProvider == null) {
                                logger.Log($"Conv: FFPM Provider not found for address with ID: {address.Id}");
                                continue;
                            }

                            var newDmgOtherAddress2 = new Brady_s_Conversion_Program.ModelsA.DmgOtherAddress {
                                OwnerId = ffpmProvider.ProviderId,
                                Address1 = TruncateString(address.Address1, 50),
                                Address2 = TruncateString(address.Address2, 50),
                                City = TruncateString(address.City, 50),
                                StateId = state,
                                CountryId = country,
                                Zip = TruncateString(zipCode, 10),
                                IsActive = isActive,
                                AddressType = addressType,
                                OwnerType = 3
                            };
                            otherAddresses.Add(newDmgOtherAddress2);
                            ffpmProvider.ProviderAddressId = otherAddressId;
                            otherAddressId++;
                            break;
                        case "ref":
                            var convReferral = referrals.FirstOrDefault(r => r.Id.ToString() == address.PrimaryFileId);
                            if (convReferral == null) {
                                logger.Log($"Conv: Conv Referral not found for address with ID: {address.Id}");
                                continue;
                            }

                            var ffpmReferral = referringProviders.FirstOrDefault(p => p.FirstName == convReferral.FirstName && p.LastName == convReferral.LastName
                                                            && p.MiddleName == convReferral.MiddleName && p.RefProviderCode == convReferral.OldReferralCode);
                            if (ffpmReferral == null) {
                                logger.Log($"Conv: FFPM Referral not found for address with ID: {address.Id}");
                                continue;
                            }

                            var newDmgOtherAddress3 = new Brady_s_Conversion_Program.ModelsA.DmgOtherAddress {
                                OwnerId = ffpmReferral.RefProviderId,
                                Address1 = TruncateString(address.Address1, 50),
                                Address2 = TruncateString(address.Address2, 50),
                                City = TruncateString(address.City, 50),
                                StateId = state,
                                CountryId = country,
                                Zip = TruncateString(zipCode, 10),
                                IsActive = isActive,
                                AddressType = addressType,
                                OwnerType = 4
                            };
                            otherAddresses.Add(newDmgOtherAddress3);
                            // appears to only be connected by the address and not the referring provider
                            break;
                        case "emp":
                            var localconvPatient = convPatients.FirstOrDefault(cp => cp.Id.ToString() == address.PrimaryFileId);
                            if (localconvPatient == null) {
                                logger.Log($"Conv: Conv Patient not found for address with ID: {address.Id}");
                                continue;
                            }
                            var ffpmPatient3 = ffpmPatients.FirstOrDefault(p => p.AccountNumber == localconvPatient.OldPatientAccountNumber);
                            if (ffpmPatient3 == null) {
                                logger.Log($"Conv: FFPM Patient not found for address with ID: {address.Id}");
                                continue;
                            }
                            var ffpmPatientAdditional2 = patientAdditionalDetails.FirstOrDefault(p => p.PatientId == ffpmPatient3.PatientId);
                            if (ffpmPatientAdditional2 == null) {
                                logger.Log($"Conv: Conv Patient additional not found for address with ID: {address.Id}");
                                continue;
                            }

                            var newOtherAddress4 = new Brady_s_Conversion_Program.ModelsA.DmgOtherAddress {
                                OwnerId = ffpmPatientAdditional2.PatientAdditionalDetailsId,
                                Address1 = TruncateString(address.Address1, 50),
                                Address2 = TruncateString(address.Address2, 50),
                                City = TruncateString(address.City, 50),
                                StateId = state,
                                CountryId = country,
                                Zip = TruncateString(zipCode, 10),
                                IsActive = isActive,
                                AddressType = addressType,
                                OwnerType = 5
                            };
                            otherAddresses.Add(newOtherAddress4);
                            ffpmPatientAdditional2.EmployerAddressId = otherAddressId;
                            otherAddressId++;
                            break;
                        default:
                            logger.Log($"Conv: Conv Primary File not found for address with ID: {address.Id}");
                            break;
                    };
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the address with ID: {address.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.DmgPatientAddresses.UpdateRange(ffpmPatientAddresses);
            ffpmDbContext.DmgOtherAddresses.UpdateRange(otherAddresses);
            ffpmDbContext.DmgPatients.UpdateRange(ffpmPatients);
            ffpmDbContext.DmgGuarantors.UpdateRange(guarantors);
            ffpmDbContext.DmgProviders.UpdateRange(ffpmProviders);
            ffpmDbContext.BillingLocations.UpdateRange(locations);
            ffpmDbContext.SaveChanges();
            ffpmPatientAddresses = ffpmDbContext.DmgPatientAddresses.ToList();
            otherAddresses = ffpmDbContext.DmgOtherAddresses.ToList();
        }

        public static void ConvertPatientAlert(List<Models.PatientAlert> convPatientAlerts, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext,
            ILogger logger, ProgressBar progress, List<Models.Patient> convPatients, List<DmgPatient> ffpmPatients, List<MntPriority> priorityXrefs,
                List<DmgPatientAlert> patientAlerts, List<DmgPatientAlert> newPatientAlerts) {
            foreach (var patientAlert in convPatientAlerts) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    int patientId = -1;
                    if (int.TryParse(patientAlert.PatientId, out int temp)) {
                        patientId = temp;
                    }
                    else {
                        logger.Log($"Conv: Conv Patient ID not found for patient alert with ID: {patientAlert.Id}");
                        continue;
                    }
                    if (patientId == -1) {
                        logger.Log($"Conv: Conv Patient ID not found (-1) for patient alert with ID: {patientAlert.Id}");
                        continue;
                    }
                    var convPatient = convPatients.FirstOrDefault(cp => cp.Id == patientId);
                    if (convPatient == null) {
                        logger.Log($"Conv: Conv Patient not found for patient alert with ID: {patientAlert.Id}");
                        continue;
                    }
                    var ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber && (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
                    if (ffpmPatient == null) {
                        logger.Log($"Conv: FFPM Patient not found for patient alert with ID: {patientAlert.Id}");
                        continue;
                    }
                    short? priorityID = null;
                    var priorityXref = priorityXrefs.FirstOrDefault(p => p.PriorityId == priorityID);
                    if (priorityXref != null) {
                        priorityID = priorityXref.PriorityId;
                    }

                    DateTime? alertDate = null;
                    if (patientAlert.AlertCreatedDate != null && patientAlert.AlertCreatedDate != "" && !int.TryParse(patientAlert.AlertCreatedDate, out int dontCare)) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(patientAlert.AlertCreatedDate, dateFormats,
                                               CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            alertDate = tempDateTime;
                        }
                    }
                    DateTime? alertEndDate = null;
                    if (patientAlert.AlertExpiryDate != null && patientAlert.AlertExpiryDate != "" && !int.TryParse(patientAlert.AlertExpiryDate, out dontCare)) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(patientAlert.AlertExpiryDate, dateFormats,
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
                    bool? isActive = true;
                    if (patientAlert.Active != null) {
                        if (patientAlert.Active.ToLower() == "no" || patientAlert.Active == "0") {
                            isActive = false;
                        }
                    }
                    bool? alertFlash = null;
                    if (patientAlert.AlertFlash != null) {
                        if (bool.TryParse(patientAlert.AlertFlash, out bool flash)) {
                            alertFlash = flash;
                        }
                    }

                    var ffpmOrig = patientAlerts.FirstOrDefault(p => p.PatientId == ffpmPatient.PatientId && p.AlertMessage == patientAlert.AlertMessage);

                    if (ffpmOrig == null) {
                        var newPatientAlert = new Brady_s_Conversion_Program.ModelsA.DmgPatientAlert {
                            PatientId = ffpmPatient.PatientId,
                            AlertMessage = patientAlert.AlertMessage,  // No need to truncate due to VARCHAR(MAX)
                            PriorityId = priorityID,
                            AlertCreatedDate = alertDate,
                            AlertCreatedBy = alertCreatedBy,
                            AlertExpiryDate = alertEndDate,
                            IsActive = isActive,
                            AlertFlash = alertFlash
                        };
                        patientAlerts.Add(newPatientAlert);
                        newPatientAlerts.Add(newPatientAlert);
                    }
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the patient alert with ID: {patientAlert.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.DmgPatientAlerts.AddRange(newPatientAlerts);
            ffpmDbContext.SaveChanges();
            patientAlerts = ffpmDbContext.DmgPatientAlerts.ToList();
            newPatientAlerts.Clear();
        }

        public static void ConvertPatientDocument(List<Models.PatientDocument> convPatientDocuments, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext,
            ILogger logger, ProgressBar progress, List<Models.Patient> convPatients, List<DmgPatient> ffpmPatients, List<ImgPatientDocument> patientDocuments,
                List<ImgPatientDocument> newPatientDocuments) {
            foreach (var patientDocument in convPatientDocuments) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    var convPatient = convPatients.FirstOrDefault(cp => cp.Id == patientDocument.PatientId);
                    if (convPatient == null) {
                        logger.Log($"Conv: Conv Patient not found for patient document with ID: {patientDocument.Id}");
                        continue;
                    }
                    DmgPatient? ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber ||
                    (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
                    if (ffpmPatient == null) {
                        logger.Log($"Conv: Conv Patient not found for patient document with ID: {patientDocument.Id}");
                        continue;
                    }
                    short? imageType = null;
                    if (patientDocument.DocumentImageType != null) {
                        if (short.TryParse(patientDocument.DocumentImageType, out short type)) {
                            imageType = type;
                        }
                    }
                    DateTime? dateDocument = null;
                    if (patientDocument.Date != null && patientDocument.Date != "" && !int.TryParse(patientDocument.Date, out int dontCare)) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(patientDocument.Date, dateFormats,
                                                      CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            dateDocument = tempDateTime;
                        }
                    }
                    bool? isActive = true;
                    if (patientDocument.Active != null) {
                        if (patientDocument.Active.ToLower() == "no" || patientDocument.Active == "0") {
                            isActive = false;
                        }
                    }

                    var ffpmOrig = patientDocuments.FirstOrDefault(p => p.PatientId == ffpmPatient.PatientId && p.DocumentName == patientDocument.DocumentDescription);

                    if (ffpmOrig == null) {
                        var newPatientDocument = new Brady_s_Conversion_Program.ModelsA.ImgPatientDocument {
                            PatientId = ffpmPatient.PatientId,
                            DocumentType = imageType,
                            DocumentRemarks = patientDocument.DocumentNotes,  // No need to truncate due to VARCHAR(MAX)
                            AddedDate = dateDocument,
                            DocumentName = TruncateString(patientDocument.DocumentDescription, 250),
                            DocumentLocation = TruncateString(patientDocument.FilePathName, 250),
                            IsActive = isActive
                        };
                        patientDocuments.Add(newPatientDocument);
                        newPatientDocuments.Add(newPatientDocument);
                    }
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the patient document with ID: {patientDocument.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.ImgPatientDocuments.AddRange(newPatientDocuments);
            ffpmDbContext.SaveChanges();
            newPatientDocuments.Clear();
        }

        public static void ConvertPatientInsurance(List<Models.PatientInsurance> convPatientInsurances, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext,
            ILogger logger, ProgressBar progress, List<Models.Patient> convPatients, List<DmgPatient> ffpmPatients, List<InsInsuranceCompany> insuranceCompanies,
                List<DmgPatientInsurance> patientInsurances, List<DmgPatientInsurance> newPatientInsurances) {
            foreach (var patientInsurance in convPatientInsurances) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    int oldpatientId = 0;
                    if (int.TryParse(patientInsurance.PrimaryId, out int temp)) {
                        oldpatientId = temp;
                    }
                    else {
                        logger.Log($"Conv: Conv Patient ID not found for patient insurance with ID: {patientInsurance.Id}");
                        continue;
                    }
                    var convPatient = convPatients.FirstOrDefault(cp => cp.Id == oldpatientId);
                    if (convPatient == null) {
                        logger.Log($"Conv: Conv Patient not found for patient insurance with ID: {patientInsurance.Id}");
                        continue;
                    }
                    DmgPatient? ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber ||
                    (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
                    if (ffpmPatient == null) {
                        logger.Log($"Conv: FFPM Patient not found for patient insurance with ID: {patientInsurance.Id}");
                        continue;
                    }
                    var convInsuranceCompany = insuranceCompanies.FirstOrDefault(p => p.InsCompanyCode == patientInsurance.InsuranceCompanyCode);
                    if (convInsuranceCompany == null) {
                        logger.Log($"Conv: Conv Insurance company not found for patient insurance with ID: {patientInsurance.Id}");
                        continue;
                    }
                    int insCompanyCode = -1;
                    if (int.TryParse(patientInsurance.InsuranceCompanyCode, out temp)) {
                        insCompanyCode = temp;
                    }
                    else {
                        logger.Log($"Conv: Conv Insurance company code not found for patient insurance with ID: {patientInsurance.Id}");
                        continue;
                    }
                    var patientInsuranceCompany = insuranceCompanies.FirstOrDefault(p => p.InsCompanyCode == insuranceCodes.GetValueOrDefault(insCompanyCode));
                    if (patientInsuranceCompany == null) {
                        logger.Log($"Conv: Conv Insurance company not found for patient insurance with ID: {patientInsurance.Id}");
                        continue;
                    }

                    DateTime? startDate = null;
                    if (patientInsurance.StartDate != null && patientInsurance.StartDate != "" && !int.TryParse(patientInsurance.StartDate, out int dontCare)) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(patientInsurance.StartDate, dateFormats,
                                                 CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            startDate = tempDateTime;
                        }
                    }
                    DateOnly? endDate = null;
                    if (patientInsurance.EndDate != null && patientInsurance.EndDate != "" && !int.TryParse(patientInsurance.EndDate, out dontCare)) {
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
                        rank = -1;
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
                    int insCompId = patientInsuranceCompany.InsCompanyId;
                    int plan_id = 0;
                    if (patientInsurance.Plan != null) {
                        if (int.TryParse(patientInsurance.Plan, out int planId)) {
                            plan_id = planId;
                        }
                    }
                    bool? active = true;
                    if (patientInsurance.Active != null) {
                        if (patientInsurance.Active.ToLower() == "no" || patientInsurance.Active == "0") {
                            active = false;
                        }
                    }
                    bool? isSubscriberExistingPatient = null;


                    var ffpmOrig = patientInsurances.FirstOrDefault(p => p.PatientId == ffpmPatient.PatientId && p.PolicyNumber == patientInsurance.Cert);

                    if (ffpmOrig == null) {
                        var newPatientInsurance = new Brady_s_Conversion_Program.ModelsA.DmgPatientInsurance {
                            PatientId = ffpmPatient.PatientId,
                            IsActive = active,
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
                            PolicyNumber = TruncateString(patientInsurance.Cert, 50),
                            GroupId = TruncateString(patientInsurance.Group, 50),
                            IsSubscriberExistingPatient = isSubscriberExistingPatient
                        };
                        patientInsurances.Add(newPatientInsurance);
                        newPatientInsurances.Add(newPatientInsurance);
                    }
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the patient insurance with ID: {patientInsurance.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.DmgPatientInsurances.AddRange(newPatientInsurances);
            ffpmDbContext.SaveChanges();
            newPatientInsurances.Clear();
        }

        public static void ConvertPatientNote(List<Models.PatientNote> convPatientNotes, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext,
            ILogger logger, ProgressBar progress, List<Models.Patient> convPatients, List<DmgPatient> ffpmPatients, List<DmgPatientRemark> patientNotes,
                List<DmgPatientRemark> newPatientNotes) {
            foreach (var patientNote in convPatientNotes) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    int patientId = -1;
                    if (patientNote.PatientId == null) {
                        logger.Log($"Conv: Conv Patient ID is null for patient note with ID: {patientNote.Id}");
                        continue;
                    }
                    else {
                        if (int.TryParse(patientNote.PatientId, out int temp)) {
                            patientId = temp;
                        }
                        else {
                            logger.Log($"Conv: Conv Patient ID not found for patient note with ID: {patientNote.Id}");
                            continue;
                        }
                    }
                    var convPatient = convPatients.FirstOrDefault(cp => cp.Id == patientId);
                    if (convPatient == null) {
                        logger.Log($"Conv: Conv Patient not found for patient note with ID: {patientNote.Id}");
                        continue;
                    }
                    DmgPatient? ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber ||
                    (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
                    if (ffpmPatient == null) {
                        logger.Log($"Conv: Conv Patient not found for patient note with ID: {patientNote.Id}");
                        continue;
                    }


                    DateTime? created = null;
                    if (patientNote.CreatedDate != null && patientNote.CreatedDate != "" && !int.TryParse(patientNote.CreatedDate, out int dontCare)) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(patientNote.CreatedDate, dateFormats,
                                                   CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            created = tempDateTime;
                        }
                    }
                    long? createdBy = null;
                    if (patientNote.CreatedBy != null) {
                        if (long.TryParse(patientNote.CreatedBy, out long createdByLong)) {
                            createdBy = createdByLong;
                        }
                    }
                    DateTime? lastUpdated = null;
                    if (patientNote.LastUpdated != null && patientNote.LastUpdated != "" && !int.TryParse(patientNote.LastUpdated, out dontCare)) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(patientNote.LastUpdated, dateFormats,
                                                                          CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            lastUpdated = tempDateTime;
                        }
                    }
                    bool? active = true;
                    if (patientNote.Active != null) {
                        if (patientNote.Active.ToLower() == "no" || patientNote.Active == "0") {
                            active = false;
                        }
                    }


                    var newPatientRemarks = new Brady_s_Conversion_Program.ModelsA.DmgPatientRemark {
                        PatientId = ffpmPatient.PatientId,
                        Remarks = patientNote.Note,
                        CreatedDate = created,
                        CreatedBy = createdBy,
                        LastUpdated = lastUpdated,
                        IsActive = active
                    };
                    patientNotes.Add(newPatientRemarks);
                    newPatientNotes.Add(newPatientRemarks);
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the patient note with ID: {patientNote.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.DmgPatientRemarks.AddRange(newPatientNotes);
            ffpmDbContext.SaveChanges();
            newPatientNotes.Clear();
        }

        public static void ConvertPolicyHolder(List<Models.PolicyHolder> policyHolders, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext,
            ILogger logger, ProgressBar progress, List<Models.PatientInsurance> convPatientInsurances, List<Models.Patient> convPatients,
                List<DmgPatient> ffpmPatients, List<DmgPatientInsurance> ffpmPatientInsurances, List<MntTitle> titleXrefs, List<MntSuffix> suffixXrefs,
                    List<MntRelationship> relationshipXrefs, List<DmgSubscriber> subscribers) {
            long subscriberId = 1;
            if (ffpmDbContext.DmgSubscribers.Any())
                subscriberId = ffpmDbContext.DmgSubscribers.Max(p => p.SubscriberId) + 1;

            foreach (var policyHolder in policyHolders) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    var convPatientInsurance = convPatientInsurances.FirstOrDefault(cp => cp.Id == policyHolder.PatientInsuranceId);
                    if (convPatientInsurance == null) {
                        logger.Log($"Conv: Conv Patient insurance not found for policy holder with ID: {policyHolder.Id}");
                        continue;
                    }
                    string? policyPatientID = convPatientInsurance.OldPatientId;

                    var convPolicyPatient = convPatients.FirstOrDefault(cp => cp.Id.ToString() == policyPatientID);
                    if (convPolicyPatient == null) {
                        logger.Log($"Conv: Conv Patient (subject) not found for policy holder with ID: {policyHolder.Id}");
                        continue;
                    }
                    var FFPMPolicyPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPolicyPatient.OldPatientAccountNumber);
                    if (FFPMPolicyPatient == null) {
                        logger.Log($"Conv: FFPM Patient (subject) not found for policy holder with ID: {policyHolder.Id} (patient insurance has subscriber as patient, cant find patient)");
                        continue;
                    }
                    var ffpmPatientInsurance = ffpmPatientInsurances.FirstOrDefault(p => p.PatientId == FFPMPolicyPatient.PatientId);
                    if (ffpmPatientInsurance == null) {
                        logger.Log($"Conv: FFPM Patient insurance not found for policy holder with ID: {policyHolder.Id}");
                        continue;
                    }
                    int? patientInsuranceID = (int)ffpmPatientInsurance.PatientInsuranceId;
                    if (ffpmPatientInsurance.IsSubscriberExistingPatient == true) {
                        ffpmPatientInsurance.SubscriberId = FFPMPolicyPatient.PatientId;
                        continue;
                    }


                    long patientId = FFPMPolicyPatient.PatientId;
                    string? ssn = null;
                    if (convPolicyPatient.Ssn != null) {
                        if (ssnRegex.IsMatch(convPolicyPatient.Ssn)) {
                            ssn = convPolicyPatient.Ssn;
                        }
                    }
                    DateTime? dob = null;
                    if (convPolicyPatient.Dob != null && convPolicyPatient.Dob != "" && !int.TryParse(convPolicyPatient.Dob, out int dontCare)) {
                        if (DateTime.TryParseExact(convPolicyPatient.Dob, dateFormats,
                                                                                CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out DateTime dobDate)) {
                            dob = isValidDate(dobDate);
                        }
                    }
                    short? titleID = null;
                    var titleXref = titleXrefs.FirstOrDefault(t => t.Title == convPolicyPatient.Title);
                    if (titleXref != null) {
                        titleID = titleXref.TitleId;
                    }
                    short? suffixID = null;
                    var suffixXref = suffixXrefs.FirstOrDefault(s => s.Suffix == convPolicyPatient.Suffix);
                    if (suffixXref != null) {
                        suffixID = suffixXref.SuffixId;
                    }
                    short? relationshipID = null;
                    var relationshipXref = relationshipXrefs.FirstOrDefault(r => r.Relationship == policyHolder.Relationship);
                    if (relationshipXref != null) {
                        relationshipID = relationshipXref.RelationshipId;
                    }
                    short? genderID = null;
                    // no genderID in incoming tables
                    short? employmentStatusID = null;
                    // no employmentStatusID in incoming tables
                    long? addressID = null;
                    // no addressID in incoming tables
                    string ssn1 = "";
                    if (convPolicyPatient.Ssn != null) {
                        if (ssnRegex.IsMatch(convPolicyPatient.Ssn)) {
                            ssn1 = convPolicyPatient.Ssn;
                        }
                    }
                    DateTime? addedDate = null;
                    // no addedDate in incoming tables
                    DateTime? removedDate = null;
                    // no removedDate in incoming tables
                    DateTime? lastModifiedDate = null;
                    // no lastModifiedDate in incoming tables
                    int? lastModifiedBy = null;
                    // no lastModifiedBy in incoming tables
                    bool active = true;
                    if (convPolicyPatient.Active != null && (convPolicyPatient.Active.ToLower() == "no" || convPolicyPatient.Active == "0")) {
                        active = false;
                    }


                    var newSubscriber = new Brady_s_Conversion_Program.ModelsA.DmgSubscriber {
                        PatientId = patientId,
                        FirstName = TruncateString(convPolicyPatient.FirstName, 50),
                        LastName = TruncateString(convPolicyPatient.LastName, 50),
                        MiddleName = TruncateString(convPolicyPatient.MiddleName, 50),
                        Ssn = TruncateString(ssn1, 15),
                        Dob = dob,
                        TitleId = titleID,
                        SuffixId = suffixID,
                        RelationshipId = relationshipID,
                        GenderId = genderID,
                        EmploymentStatusId = employmentStatusID,
                        AddressId = addressID,
                        AddedDate = addedDate,
                        RemovedDate = removedDate,
                        LastModifiedDate = lastModifiedDate,
                        LastModifiedBy = lastModifiedBy,
                        IsActive = active
                    };
                    subscribers.Add(newSubscriber);

                    ffpmPatientInsurance.SubscriberId = subscriberId;
                    subscriberId++;
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the policy holder with ID: {policyHolder.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.DmgPatientInsurances.UpdateRange(ffpmPatientInsurances);
            ffpmDbContext.DmgSubscribers.UpdateRange(subscribers);
            ffpmDbContext.SaveChanges();
        }

        public static void ConvertProvider(List<Models.Provider> convProviders, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<MntSuffix> suffixXrefs, List<MntTitle> titleXrefs, List<DmgProvider> ffpmProviders, List<DmgProvider> newProviders) {
            foreach (var provider in convProviders) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    short? suffixInt = null;
                    var suffixXref = suffixXrefs.FirstOrDefault(s => s.Suffix == provider.Suffix);
                    if (suffixXref != null) {
                        suffixInt = suffixXref.SuffixId;
                    }

                    short? titleInt = null;
                    var titleXref = titleXrefs.FirstOrDefault(t => t.Title == provider.Title);
                    if (titleXref != null) {
                        titleInt = titleXref.TitleId;
                    }

                    string? ssnString = null;
                    if (provider.Ssn != null) {
                        if (ssnRegex.IsMatch(provider.Ssn)) {
                            ssnString = provider.Ssn;
                        }
                    }

                    DateTime? dobDate = null;
                    if (provider.Dob != null && provider.Dob != "" && !int.TryParse(provider.Dob, out int dontCare)) {
                        if (DateTime.TryParseExact(provider.Dob, dateFormats,
                                                   CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out DateTime dob)) {
                            dobDate = isValidDate(dob);
                        }
                    }

                    string? einString = null;
                    if (provider.Ein != null) {
                        einString = provider.Ein;
                    }

                    string? upinString = null;
                    if (provider.Upin != null) {
                        upinString = provider.Upin;
                    }

                    string? npiString = null;
                    if (provider.Npi != null) {
                        npiString = provider.Npi;
                    }

                    bool? isActive = null;
                    if (provider.Active != null && (provider.Active.ToLower() == "yes" || provider.Active == "1")) {
                        isActive = true;
                    }

                    int clExpId = 0;
                    if (provider.Clexpiration != null) {
                        if (int.TryParse(provider.Clexpiration, out int clExpIdInt)) {
                            clExpId = clExpIdInt;
                        }
                    }

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
                    if (provider.SpecialtyId != null) {
                        if (int.TryParse(provider.SpecialtyId, out int specialtyIdInt)) {
                            specialtyId = specialtyIdInt;
                        }
                    }


                    #region taxonomys
                    int primaryTaxId = 0;
                    if (int.TryParse(provider.PrimaryTaxonomyId, out int primaryTaxIdInt)) {
                        primaryTaxId = primaryTaxIdInt;
                    }

                    int taxId1 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy1Id, out int taxId1Int)) {
                        taxId1 = taxId1Int;
                    }

                    int taxId2 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy2Id, out int taxId2Int)) {
                        taxId2 = taxId2Int;
                    }

                    int taxId3 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy3Id, out int taxId3Int)) {
                        taxId3 = taxId3Int;
                    }

                    int taxId4 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy4Id, out int taxId4Int)) {
                        taxId4 = taxId4Int;
                    }

                    int taxId5 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy5Id, out int taxId5Int)) {
                        taxId5 = taxId5Int;
                    }

                    int taxId6 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy6Id, out int taxId6Int)) {
                        taxId6 = taxId6Int;
                    }

                    int taxId7 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy7Id, out int taxId7Int)) {
                        taxId7 = taxId7Int;
                    }

                    int taxId8 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy8Id, out int taxId8Int)) {
                        taxId8 = taxId8Int;
                    }

                    int taxId9 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy9Id, out int taxId9Int)) {
                        taxId9 = taxId9Int;
                    }

                    int taxId10 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy10Id, out int taxId10Int)) {
                        taxId10 = taxId10Int;
                    }

                    int taxId11 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy11Id, out int taxId11Int)) {
                        taxId11 = taxId11Int;
                    }

                    int taxId12 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy12Id, out int taxId12Int)) {
                        taxId12 = taxId12Int;
                    }

                    int taxId13 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy13Id, out int taxId13Int)) {
                        taxId13 = taxId13Int;
                    }

                    int taxId14 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy14Id, out int taxId14Int)) {
                        taxId14 = taxId14Int;
                    }

                    int taxId15 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy15Id, out int taxId15Int)) {
                        taxId15 = taxId15Int;
                    }

                    int taxId16 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy16Id, out int taxId16Int)) {
                        taxId16 = taxId16Int;
                    }

                    int taxId17 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy17Id, out int taxId17Int)) {
                        taxId17 = taxId17Int;
                    }

                    int taxId18 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy18Id, out int taxId18Int)) {
                        taxId18 = taxId18Int;
                    }

                    int taxId19 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy19Id, out int taxId19Int)) {
                        taxId19 = taxId19Int;
                    }

                    int taxId20 = 0;
                    if (int.TryParse(provider.AlternateTaxonomy20Id, out int taxId20Int)) {
                        taxId20 = taxId20Int;
                    }
                    #endregion taxonomys


                    var ffpmOrig = ffpmProviders.FirstOrDefault(p => p.ProviderCode == provider.OldProviderCode);

                    if (ffpmOrig == null) {
                        var newPatientProvider = new Brady_s_Conversion_Program.ModelsA.DmgProvider {
                            FirstName = TruncateString(provider.FirstName, 50),
                            MiddleName = TruncateString(provider.MiddleName, 10),
                            LastName = TruncateString(provider.LastName, 50),
                            ProviderCode = TruncateString(provider.OldProviderCode, 15),
                            SuffixId = suffixInt,
                            TitleId = titleInt,
                            ProviderSsn = TruncateString(ssnString, 15),
                            ProviderEin = TruncateString(einString, 15),
                            ProviderUpin = TruncateString(upinString, 15),
                            ProviderDob = dobDate,
                            ProviderNpi = TruncateString(npiString, 10),
                            IsActive = isActive,
                            IsReferringProvider = false,
                            SignatureUrl = "",  // No value given, assumed not to require truncation
                            GroupId = 0,
                            SpectacleExpiration = specExpId,
                            SpectacleExpirationTypeId = specExpTypeId,
                            ClExpiration = clExpId,
                            ClExpirationTypeId = -1,
                            LicenseIssuingStateId = stateId,
                            LicenseIssuingCountryId = countryId,
                            ProviderDeaNumber = TruncateString(provider.Deanumber, 10),
                            PrimaryTaxonomyId = primaryTaxId,

                            AlternateTaxonomy1Id = taxId1,
                            AlternateTaxonomy2Id = taxId2,
                            AlternateTaxonomy3Id = taxId3,
                            AlternateTaxonomy4Id = taxId4,
                            AlternateTaxonomy5Id = taxId5,
                            AlternateTaxonomy6Id = taxId6,
                            AlternateTaxonomy7Id = taxId7,
                            AlternateTaxonomy8Id = taxId8,
                            AlternateTaxonomy9Id = taxId9,
                            AlternateTaxonomy10Id = taxId10,
                            AlternateTaxonomy11Id = taxId11,
                            AlternateTaxonomy12Id = taxId12,
                            AlternateTaxonomy13Id = taxId13,
                            AlternateTaxonomy14Id = taxId14,
                            AlternateTaxonomy15Id = taxId15,
                            AlternateTaxonomy16Id = taxId16,
                            AlternateTaxonomy17Id = taxId17,
                            AlternateTaxonomy18Id = taxId18,
                            AlternateTaxonomy19Id = taxId19,
                            AlternateTaxonomy20Id = taxId20
                        };
                        newProviders.Add(newPatientProvider);
                        ffpmProviders.Add(newPatientProvider);
                    }
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the provider with ID: {provider.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.DmgProviders.AddRange(newProviders);
            ffpmDbContext.SaveChanges();
            newProviders.Clear();
        }

        public static void ConvertRecall(List<Models.Recall> convRecalls, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<Models.Patient> convPatients, List<DmgPatient> ffpmPatients, List<Models.Location> convLocations, List<BillingLocation> ffpmLocations,
                List<SchedulingPatientRecallList> patientRecallLists, List<SchedulingPatientRecallList> newPatientRecallLists) {
            foreach (var recall in convRecalls) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    var convPatient = convPatients.FirstOrDefault(p => p.Id == recall.PatientId);
                    if (convPatient == null) {
                        logger.Log($"Conv: Conv Patient not found for recall with ID: {recall.Id}");
                        continue;
                    }
                    var ffpmPatient = ffpmPatients.FirstOrDefault(p => (p.AccountNumber == convPatient.OldPatientAccountNumber) ||
                        (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
                    if (ffpmPatient == null) {
                        logger.Log($"Conv: FFPM Patient not found for recall with ID: {recall.Id}");
                        continue;
                    }

                    int appointmentType = -1;
                    if (recall.OldRecallTypeId != null) {
                        if (int.TryParse(recall.OldRecallTypeId, out int apptType)) {
                            appointmentType = apptType;
                        }
                    }
                    int resource = -1;
                    if (int.TryParse(recall.OldResourceId, out int temp)) {
                        resource = temp;
                    }
                    int billingLocation = -1;
                    var convLocation = convLocations.FirstOrDefault(l => l.Id.ToString() == recall.OldBillingLocationId);
                    if (convLocation != null) {
                        var ffpmLocation = ffpmLocations.FirstOrDefault(l => l.Name == convLocation.LocationName);
                        if (ffpmLocation != null) {
                            billingLocation = ffpmLocation.LocationId;
                        }
                    }
                    DateOnly recallDate = new DateOnly();
                    if (recall.RecallDate != null && recall.RecallDate != "" && !int.TryParse(recall.RecallDate, out int dontCare)) {
                        DateOnly tempDate;
                        if (!DateOnly.TryParseExact(recall.RecallDate, dateFormats,
                                                      CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDate)) {
                            recallDate = tempDate;
                        }
                    }
                    bool isActive = true;
                    if (recall.Active != null && (recall.Active.ToLower() == "no" || recall.Active == "0")) {
                        isActive = false;
                    }

                    int location = 0;
                    int number = 0;
                    string note = "";
                    if (recall.Notes != null) {
                        note = recall.Notes;
                    }

                    var ffpmOrig = patientRecallLists.FirstOrDefault(p => p.PatientId == ffpmPatient.PatientId && p.AppointmentTypeId == appointmentType && p.RecallListDate == recallDate);

                    if (ffpmOrig == null) {
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
                        newPatientRecallLists.Add(newRecallList);
                        patientRecallLists.Add(newRecallList);
                    }
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the recall with ID: {recall.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.SchedulingPatientRecallLists.AddRange(newPatientRecallLists);
            ffpmDbContext.SaveChanges();
            newPatientRecallLists.Clear();
        }

        public static void ConvertRecallType(List<Models.RecallType> convRecallTypes, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<SchedulingAppointmentType> schedulingAppointmentTypes, List<SchedulingAppointmentType> newSchedulingAppointmentTypes) {
            foreach (var recallType in convRecallTypes) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    string code = "";
                    if (recallType.OldRecallTypeCode != null) {
                        code = recallType.OldRecallTypeCode;
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
                    if (recallType.Active != null && (recallType.Active.ToLower() == "yes" || recallType.Active == "1")) {
                        isActive = true;
                    }
                    string note = "";
                    if (recallType.Notes != null) {
                        note = recallType.Notes;
                    }

                    var ffpmOrig = schedulingAppointmentTypes.FirstOrDefault(p => p.Code == code);

                    if (ffpmOrig == null) {
                        var newRecallType = new Brady_s_Conversion_Program.ModelsA.SchedulingAppointmentType {
                            IsRecallType = true,
                            IsAppointmentType = false,
                            IsExamType = false,
                            Code = TruncateString(code, 200),  // Truncating to meet VARCHAR(200) limit
                            Description = TruncateString(description, 1000),  // Truncating to meet VARCHAR(1000) limit
                            DefaultDuration = defaultDuration,
                            Active = isActive,
                            Notes = TruncateString(note, 5000),  // Assuming large text but truncating as a safeguard
                            LocationId = 0,
                            PatientRequired = false
                        };
                        schedulingAppointmentTypes.Add(newRecallType);
                        newSchedulingAppointmentTypes.Add(newRecallType);
                    }
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the recall type with ID: {recallType.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.SchedulingAppointmentTypes.AddRange(newSchedulingAppointmentTypes);
            ffpmDbContext.SaveChanges();
            newSchedulingAppointmentTypes.Clear();
        }

        public static void ConvertReferral(List<Models.Referral> convReferrals, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<MntSuffix> suffixXrefs, List<MntTitle> titleXrefs, List<ReferringProvider> referringProviders, List<DmgProvider> ffpmProviders,
                List<ReferringProvider> newReferringProviders, List<DmgProvider> newProviders) {
            foreach (var referral in convReferrals) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    long providerID = 0;
                    if (long.TryParse(referral.OldReferralCode, out providerID)) {
                        if (long.TryParse(referral.OldReferralCode, out long providerIDLong)) {
                            providerID = providerIDLong;
                        }
                    }
                    else {
                        logger.Log($"Conv: Conv Provider ID not found for referral with ID: {referral.Id}");
                    }

                    short? suffixInt = null;
                    var suffixXref = suffixXrefs.FirstOrDefault(s => s.Suffix == referral.Suffix);
                    if (suffixXref != null) {
                        suffixInt = suffixXref.SuffixId;
                    }

                    short? titleInt = null;
                    var titleXref = titleXrefs.FirstOrDefault(t => t.Title == referral.Title);
                    if (titleXref != null) {
                        titleInt = titleXref.TitleId;
                    }

                    string? ssnString = null;
                    if (referral.Ssn != null) {
                        if (ssnRegex.IsMatch(referral.Ssn)) {
                            ssnString = referral.Ssn;
                        }
                    }

                    DateTime? dobDate = null;
                    if (referral.Dob != null && referral.Dob != "" && referral.Dob != "") {
                        if (DateTime.TryParseExact(referral.Dob, dateFormats,
                                                                          CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out DateTime dob)) {
                            dobDate = isValidDate(dob);
                        }
                    }

                    string? einString = null;
                    if (referral.Ein != null) {
                        einString = referral.Ein;
                    }

                    string? upinString = null;
                    if (referral.Upin != null) {
                        upinString = referral.Upin;
                    }

                    string? npiString = null;
                    if (referral.Npi != null) {
                        npiString = referral.Npi;
                    }

                    bool? isActive = null;
                    if (referral.Active != null && (referral.Active.ToLower() == "yes" || referral.Active == "1")) {
                        isActive = true;
                    }

                    int? country = null;
                    if (referral.LicenseIssuingCountryId != null) {
                        if (int.TryParse(referral.LicenseIssuingCountryId, out int countryInt)) {
                            country = countryInt;
                        }
                    }
                    int? state = null;
                    if (referral.LicenseIssuingStateId != null) {
                        if (int.TryParse(referral.LicenseIssuingStateId, out int stateInt)) {
                            state = stateInt;
                        }
                    }

                    long? providerAddressId = null;
                    // no address

                    int? providerSpecialtyId = null;
                    if (referral.SpecialtyId != null) {
                        if (int.TryParse(referral.SpecialtyId, out int providerSpecialtyIdInt)) {
                            providerSpecialtyId = providerSpecialtyIdInt;
                        }
                    }

                    int? providerUserId = null;
                    // no userId

                    short? TitleId = null;
                    if (referral.Title != null) {
                        if (short.TryParse(referral.Title, out short TitleIdInt)) {
                            TitleId = TitleIdInt;
                        }
                    }

                    short? suffixId = null;
                    if (referral.Suffix != null) {
                        if (short.TryParse(referral.Suffix, out short suffixIdInt)) {
                            suffixId = suffixIdInt;
                        }
                    }


                    #region taxonomys
                    int primaryTaxId = 0;
                    if (int.TryParse(referral.PrimaryTaxonomyId, out int primaryTaxIdInt)) {
                        primaryTaxId = primaryTaxIdInt;
                    }

                    int tax1Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy1Id, out int tax1IdInt)) {
                        tax1Id = tax1IdInt;
                    }

                    int tax2Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy2Id, out int tax2IdInt)) {
                        tax2Id = tax2IdInt;
                    }

                    int tax3Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy3Id, out int tax3IdInt)) {
                        tax3Id = tax3IdInt;
                    }

                    int tax4Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy4Id, out int tax4IdInt)) {
                        tax4Id = tax4IdInt;
                    }

                    int tax5Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy5Id, out int tax5IdInt)) {
                        tax5Id = tax5IdInt;
                    }

                    int tax6Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy6Id, out int tax6IdInt)) {
                        tax6Id = tax6IdInt;
                    }

                    int tax7Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy7Id, out int tax7IdInt)) {
                        tax7Id = tax7IdInt;
                    }

                    int tax8Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy8Id, out int tax8IdInt)) {
                        tax8Id = tax8IdInt;
                    }

                    int tax9Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy9Id, out int tax9IdInt)) {
                        tax9Id = tax9IdInt;
                    }

                    int tax10Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy10Id, out int tax10IdInt)) {
                        tax10Id = tax10IdInt;
                    }

                    int tax11Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy11Id, out int tax11IdInt)) {
                        tax11Id = tax11IdInt;
                    }

                    int tax12Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy12Id, out int tax12IdInt)) {
                        tax12Id = tax12IdInt;
                    }

                    int tax13Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy13Id, out int tax13IdInt)) {
                        tax13Id = tax13IdInt;
                    }

                    int tax14Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy14Id, out int tax14IdInt)) {
                        tax14Id = tax14IdInt;
                    }

                    int tax15Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy15Id, out int tax15IdInt)) {
                        tax15Id = tax15IdInt;
                    }

                    int tax16Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy16Id, out int tax16IdInt)) {
                        tax16Id = tax16IdInt;
                    }

                    int tax17Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy17Id, out int tax17IdInt)) {
                        tax17Id = tax17IdInt;
                    }

                    int tax18Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy18Id, out int tax18IdInt)) {
                        tax18Id = tax18IdInt;
                    }

                    int tax19Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy19Id, out int tax19IdInt)) {
                        tax19Id = tax19IdInt;
                    }

                    int tax20Id = 0;
                    if (int.TryParse(referral.AlternateTaxonomy20Id, out int tax20IdInt)) {
                        tax20Id = tax20IdInt;
                    }

                    #endregion taxonomys

                    var ffpmOrig = referringProviders.FirstOrDefault(p => p.RefProviderCode == referral.OldReferralCode);
                    var ffpmOrigProvider = ffpmProviders.FirstOrDefault(p => p.ProviderCode == referral.OldReferralCode);


                    if (ffpmOrigProvider == null) {
                        var newProvider = new Brady_s_Conversion_Program.ModelsA.DmgProvider {
                            FirstName = TruncateString(referral.FirstName, 50),
                            MiddleName = TruncateString(referral.MiddleName, 10),
                            LastName = TruncateString(referral.LastName, 50),
                            ProviderCode = TruncateString(referral.OldReferralCode, 15),
                            IsActive = isActive,
                            IsReferringProvider = true,
                            SignatureUrl = "",
                            GroupId = 0,
                            SpectacleExpiration = 0,
                            ClExpiration = 0,
                            SpectacleExpirationTypeId = 0,
                            ClExpirationTypeId = 0,
                            ProviderDeaNumber = TruncateString(referral.Deanumber, 10),
                            ProviderEin = TruncateString(einString, 15),
                            ProviderNpi = TruncateString(npiString, 10),
                            ProviderLicenseNo = TruncateString(referral.LicenseNo, 15),
                            ProviderMedicaidNumber = TruncateString(referral.MedicaidNumber, 15),
                            ProviderSsn = TruncateString(ssnString, 15),
                            ProviderUpin = TruncateString(upinString, 15),
                            ProviderExternalPmCode = "",
                            LicenseIssuingCountryId = country,
                            LicenseIssuingStateId = state,
                            ProviderAddressId = providerAddressId,
                            ProviderDob = dobDate,
                            ProviderSpecialityId = providerSpecialtyId,
                            ProviderUserId = providerUserId,
                            TitleId = titleInt,
                            SuffixId = suffixInt,

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
                        ffpmProviders.Add(newProvider);
                        newProviders.Add(newProvider);

                        // Handling the existing referring provider
                        if (ffpmOrig == null) {
                            var newReferral1 = new Brady_s_Conversion_Program.ModelsA.ReferringProvider {
                                LocationId = 0,
                                FirstName = TruncateString(referral.FirstName, 50),
                                MiddleName = TruncateString(referral.MiddleName, 10),
                                LastName = TruncateString(referral.LastName, 50),
                                RefProviderCode = TruncateString(referral.OldReferralCode, 50),
                                Active = isActive
                            };
                            newReferringProviders.Add(newReferral1);
                            referringProviders.Add(newReferral1);
                        }
                        
                    }
                }
                catch (Exception e) {
                    logger.Log($"Conv: Conv An error occurred while converting the referral with ID: {referral.Id}. Error: {e.Message}");
                }
            }
            ffpmDbContext.DmgProviders.AddRange(newProviders);
            ffpmDbContext.ReferringProviders.AddRange(newReferringProviders);
            ffpmDbContext.SaveChanges();
            newReferringProviders.Clear();
            newProviders.Clear();
        }

        public static void ConvertSchedCode(List<Models.SchedCode> convSchedCodes, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<SchedulingCode> schedulingCodes, List<SchedulingCode> newSchedulingCodes) {
            foreach (var schedCode in convSchedCodes) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    int type = -1;
                    if (int.TryParse(schedCode.TypeId, out int typeInt)) {
                        type = typeInt;
                    }
                    string code = "";
                    if (schedCode.Code != null) {
                        code = schedCode.Code;
                    }
                    string description = "";
                    if (schedCode.Description != null) {
                        description = schedCode.Description;
                    }
                    bool isActive = true;
                    if (schedCode.Active != null && (schedCode.Active.ToLower() == "no" || schedCode.Active == "0")) {
                        isActive = true;
                    }
                    int location = 0;
                    bool isDefault = false;
                    bool noShow = false;
                    if (schedCode.IsNoShow != null && (schedCode.IsNoShow.ToLower() == "no" || schedCode.IsNoShow == "0")) {
                        noShow = false;
                    }

                    var ffpmOrig = schedulingCodes.FirstOrDefault(p => p.Code == code);

                    if (ffpmOrig != null) {
                        var newSchedulingCode = new Brady_s_Conversion_Program.ModelsA.SchedulingCode {
                            TypeId = type,
                            Code = TruncateString(code, 200),
                            Description = TruncateString(description, 2000),
                            Active = isActive,
                            LocationId = location,
                            IsDefaultCode = isDefault,
                            IsNoShow = noShow
                        };
                        newSchedulingCodes.Add(newSchedulingCode);
                        schedulingCodes.Add(newSchedulingCode);
                    }
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the scheduling code with ID: {schedCode.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.SchedulingCodes.AddRange(newSchedulingCodes);
            ffpmDbContext.SaveChanges();
            newSchedulingCodes.Clear();
        }

        // IMPORTANT, THE OWNER TYPES IN OTHER ADDRESSES IS A SHORT, BUT I CANNOT FIND THE REFERENCE FOR SHORTS TO ACTUAL VALUE. WILL NEED TO CHANGE ACCORDINGLY.
        public static void ConvertPhone(List<Models.Phone> phones, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<Models.Patient> convPatients, List<DmgPatient> ffpmPatients, List<DmgPatientAddress> patientAddresses, List<Guarantor> convGuarantors, List<DmgGuarantor> guarantors,
                List<Provider> convProviders, List<DmgProvider> providers, List<DmgOtherAddress> otherAddresses, List<Referral> convReferrals, List<Models.Location> convLocations,
                    List<BillingLocation> locations) {
            phones = convDbContext.Phones.ToList();
            guarantors = ffpmDbContext.DmgGuarantors.ToList();
            providers = ffpmDbContext.DmgProviders.ToList();
            otherAddresses = ffpmDbContext.DmgOtherAddresses.ToList();
            locations = ffpmDbContext.BillingLocations.ToList();
            ffpmPatients = ffpmDbContext.DmgPatients.ToList();

            foreach (var phone in phones) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    if (phone.PrimaryFile == null) {
                        logger.Log($"Conv: Conv Primary file not found for phone with ID: {phone.Id}");
                        continue;
                    }
                    switch (phone.PrimaryFile.Trim().ToUpper()) {
                        case "PAT":
                            var convPatient = convPatients.FirstOrDefault(cp => cp.Id == phone.PrimaryFileId);
                            if (convPatient == null) {
                                logger.Log($"Conv: Conv Patient not found for phone (patient) with ID: {phone.Id}");
                                continue;
                            }
                            DmgPatient? ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber);
                            if (ffpmPatient == null) {
                                logger.Log($"Conv: FFPM Patient not found for phone with ID: {phone.Id}");
                                continue;
                            }
                            DmgPatientAddress? address = patientAddresses.FirstOrDefault(p => p.PatientId == ffpmPatient.PatientId);
                            if (address == null) {
                                var newPatientAddress = new DmgPatientAddress {
                                    PatientId = ffpmPatient.PatientId
                                };
                                patientAddresses.Add(newPatientAddress);
                                address = newPatientAddress;
                            }

                            if (phone.Type != null) {
                                switch (phone.Type.ToLower()) {
                                    case "home":
                                        address.HomePhone = TruncateString(phone.PhoneNumber, 15);
                                        break;
                                    case "work":
                                        address.WorkPhone = TruncateString(phone.PhoneNumber, 15);
                                        break;
                                    case "cell":
                                        address.CellPhone = TruncateString(phone.PhoneNumber, 15);
                                        break;
                                    default:
                                        address.CellPhone = TruncateString(phone.PhoneNumber, 15);
                                        break;
                                }
                                address.Extension = TruncateString(phone.Extension, 10);
                            }
                            else {
                                address.CellPhone = TruncateString(phone.PhoneNumber, 15);
                                address.Extension = TruncateString(phone.Extension, 10);
                            }
                            break;
                        case "PROV":
                            var convProvider = convProviders.FirstOrDefault(p => p.Id == phone.PrimaryFileId);
                            if (convProvider == null) {
                                logger.Log($"Conv: Conv Provider not found for phone with ID: {phone.Id}");
                                continue;
                            }
                            var ffpmProvider = providers.FirstOrDefault(p => p.ProviderCode == convProvider.OldProviderCode); // given that this is what it sounds like
                            if (ffpmProvider == null) {
                                logger.Log($"Conv: FFPM Provider not found for phone with ID: {phone.Id}");
                                continue;
                            }
                            short ownerType = 3;
                            /*
                             SWAP OUT THE OWNER TYPE SHORTS
                            I need the table or reference for the owner types first
                            var ownerType = ownerTypes.FirstOrDefault(o => o.OwnerType == "PROV");
                             */
                            var ffpmProviderAddress = otherAddresses.FirstOrDefault(p => p.OwnerId == ffpmProvider.ProviderId && p.OwnerType == ownerType);
                            if (ffpmProviderAddress == null) {
                                var newProviderAddress = new DmgOtherAddress {
                                    OwnerId = ffpmProvider.ProviderId,
                                    OwnerType = ownerType
                                };
                                otherAddresses.Add(newProviderAddress);
                                ffpmProviderAddress = newProviderAddress;
                            }
                            if (phone.Type == null) {
                                ffpmProviderAddress.HomePhone = TruncateString(phone.PhoneNumber, 15);
                                ffpmProviderAddress.Extension = TruncateString(phone.Extension, 10);
                                continue;
                            }
                            switch (phone.Type.ToLower()) {
                                case "home":
                                    ffpmProviderAddress.HomePhone = TruncateString(phone.PhoneNumber, 15);
                                    ffpmProviderAddress.Extension = TruncateString(phone.Extension, 10);
                                    break;
                                case "work":
                                    ffpmProviderAddress.WorkPhone = TruncateString(phone.PhoneNumber, 15);
                                    ffpmProviderAddress.Extension = TruncateString(phone.Extension, 10);
                                    break;
                                case "cell":
                                    ffpmProviderAddress.CellPhone = TruncateString(phone.PhoneNumber, 15);
                                    ffpmProviderAddress.Extension = TruncateString(phone.Extension, 10);
                                    break;
                                default:
                                    ffpmProviderAddress.CellPhone = TruncateString(phone.PhoneNumber, 15);
                                    ffpmProviderAddress.Extension = TruncateString(phone.Extension, 10);
                                    break;
                            }
                            break;
                        case "REF":
                            var convReferral = convReferrals.FirstOrDefault(r => r.Id == phone.PrimaryFileId);
                            if (convReferral == null) {
                                logger.Log($"Conv: Conv Referral not found for phone with ID: {phone.Id}");
                                continue;
                            }
                            var ffpmReferral = providers.FirstOrDefault(p => p.ProviderCode == convReferral.OldReferralCode && p.IsReferringProvider == true);
                            if (ffpmReferral == null) {
                                logger.Log($"Conv: FFPM Referral not found for phone with ID: {phone.Id}");
                                continue;
                            }
                            ownerType = 4;
                            // ALSO SWAP OUT HERE
                            var ffpmReferralAddress = otherAddresses.FirstOrDefault(p => p.OwnerId == ffpmReferral.ProviderId && p.OwnerType == ownerType);
                            if (ffpmReferralAddress == null) {
                                var newReferralAddress = new DmgOtherAddress {
                                    OwnerId = ffpmReferral.ProviderId,
                                    OwnerType = ownerType
                                };
                                otherAddresses.Add(newReferralAddress);
                                ffpmReferralAddress = newReferralAddress;
                            }
                            if (phone.Type == null) {
                                ffpmReferralAddress.HomePhone = TruncateString(phone.PhoneNumber, 15);
                                ffpmReferralAddress.Extension = TruncateString(phone.Extension, 10);
                                continue;
                            }
                            switch (phone.Type.ToLower()) {
                                case "home":
                                    ffpmReferralAddress.HomePhone = TruncateString(phone.PhoneNumber, 15);
                                    ffpmReferralAddress.Extension = TruncateString(phone.Extension, 10);
                                    break;
                                case "work":
                                    ffpmReferralAddress.WorkPhone = TruncateString(phone.PhoneNumber, 15);
                                    ffpmReferralAddress.Extension = TruncateString(phone.Extension, 10);
                                    break;
                                case "cell":
                                    ffpmReferralAddress.CellPhone = TruncateString(phone.PhoneNumber, 15);
                                    ffpmReferralAddress.Extension = TruncateString(phone.Extension, 10);
                                    break;
                                default:
                                    ffpmReferralAddress.CellPhone = TruncateString(phone.PhoneNumber, 15);
                                    ffpmReferralAddress.Extension = TruncateString(phone.Extension, 10);
                                    break;
                            }
                            break;
                        case "GUAR":
                            var convGuarantor = convGuarantors.FirstOrDefault(g => g.Id == phone.PrimaryFileId);
                            if (convGuarantor == null) {
                                logger.Log($"Conv: Conv Guarantor not found for phone with ID: {phone.Id}");
                                continue;
                            }
                            convPatient = convPatients.FirstOrDefault(p => p.Id == convGuarantor.PatientId);
                            if (convPatient == null) {
                                logger.Log($"Conv: Conv Patient not found for phone (guarantor) with ID: {phone.Id}");
                                continue;
                            }
                            ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber && (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
                            if (ffpmPatient == null) {
                                logger.Log($"Conv: FFPM Patient not found for phone with ID: {phone.Id}");
                                continue;
                            }
                            var guarantor = guarantors.FirstOrDefault(g => g.PatientId == ffpmPatient.PatientId);
                            if (guarantor == null) {
                                logger.Log($"Conv: FFPM Guarantor not found for phone with ID: {phone.Id}");
                                continue;
                            }
                            ownerType = 1;
                            // ALSO SWAP OUT HERE
                            var guarantorAddress = otherAddresses.FirstOrDefault(p => p.OwnerId == guarantor.GuarantorId && p.OwnerType == ownerType);
                            if (guarantorAddress == null) {
                                var newGuarantorAddress = new DmgOtherAddress {
                                    OwnerId = guarantor.GuarantorId,
                                    OwnerType = ownerType
                                };
                                otherAddresses.Add(newGuarantorAddress);
                                guarantorAddress = newGuarantorAddress;
                            }
                            if (phone.Type == null) {
                                guarantorAddress.HomePhone = TruncateString(phone.PhoneNumber, 15);
                                guarantorAddress.Extension = TruncateString(phone.Extension, 10);
                                continue;
                            }
                            break;
                        case "LOC":
                            var convLocation = convLocations.FirstOrDefault(l => l.Id == phone.PrimaryFileId);
                            if (convLocation == null) {
                                logger.Log($"Conv: Conv Location not found for phone with ID: {phone.Id}");
                                continue;
                            }
                            var ffpmLocation = locations.FirstOrDefault(l => l.Npi == convLocation.Npi || l.Name == convLocation.LocationName);
                            if (ffpmLocation == null) {
                                logger.Log($"Conv: FFPM Location not found for phone with ID: {phone.Id}");
                                continue;
                            }
                            ownerType = 2;
                            // ALSO SWAP OUT HERE
                            var ffpmLocationAddress = otherAddresses.FirstOrDefault(p => p.OwnerId == ffpmLocation.LocationId && p.OwnerType == ownerType);
                            if (ffpmLocationAddress == null) {
                                var newLocationAddress = new DmgOtherAddress {
                                    OwnerId = ffpmLocation.LocationId,
                                    OwnerType = ownerType
                                };
                                otherAddresses.Add(newLocationAddress);
                                ffpmLocationAddress = newLocationAddress;
                            }
                            if (phone.Type == null) {
                                ffpmLocationAddress.HomePhone = TruncateString(phone.PhoneNumber, 15);
                                ffpmLocationAddress.Extension = TruncateString(phone.Extension, 10);
                                continue;
                            }
                            switch (phone.Type.ToLower()) {
                                case "home":
                                    ffpmLocationAddress.HomePhone = TruncateString(phone.PhoneNumber, 15);
                                    ffpmLocationAddress.Extension = TruncateString(phone.Extension, 10);
                                    break;
                                case "work":
                                    ffpmLocationAddress.WorkPhone = TruncateString(phone.PhoneNumber, 15);
                                    ffpmLocationAddress.Extension = TruncateString(phone.Extension, 10);
                                    break;
                                case "cell":
                                    ffpmLocationAddress.CellPhone = TruncateString(phone.PhoneNumber, 15);
                                    ffpmLocationAddress.Extension = TruncateString(phone.Extension, 10);
                                    break;
                                default:
                                    ffpmLocationAddress.CellPhone = TruncateString(phone.PhoneNumber, 15);
                                    ffpmLocationAddress.Extension = TruncateString(phone.Extension, 10);
                                    break;
                            }
                            break;
                        default:
                            logger.Log($"Conv: Address PrimaryFile is unexpected type of {phone.PrimaryFile} on phone with ID: {phone.Id}");
                            break;
                    }
                }
                catch (Exception ex) {
                    logger.Log($"Conv: Conv An error occurred while converting the phone with ID: {phone.Id}. Error: {ex.Message}");
                }
            }
            ffpmDbContext.DmgPatients.UpdateRange(ffpmPatients);
            ffpmDbContext.DmgGuarantors.UpdateRange(guarantors);
            ffpmDbContext.DmgProviders.UpdateRange(providers);
            ffpmDbContext.DmgOtherAddresses.UpdateRange(otherAddresses);
            ffpmDbContext.DmgPatientAddresses.UpdateRange(patientAddresses);
            ffpmDbContext.SaveChanges();
        }

        public static void ConvertAccountXref(Models.AccountXref accountXref, FoxfireConvContext convDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress) {
            // currently not implementing renumbering
        }
        #endregion FFPMConversion

        #region EyeMDConversion
        public static void ConvertEyeMD(EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, FfpmContext ffpmDbContext, FoxfireConvContext convDbContext, 
            ILogger logger, ProgressBar progress, RichTextBox resultsBox) {
            if (eyeMDDbContext.Emrpatients.Count() == 0) {
                logger.Log("EyeMD: EyeMD No patients found in the database.");
                return;
            }
            var visits = eyeMDDbContext.Emrvisits.ToList();
            var eyeMDPatients = eyeMDDbContext.Emrpatients.ToList();
            var ehrVisits = eHRDbContext.Visits.ToList();
            var eyeMDVisitOrders = eyeMDDbContext.EmrvisitOrders.ToList();
            var visitDoctors = eyeMDDbContext.EmrvisitDoctors.ToList();
            var medicalHistories = eyeMDDbContext.EmrvisitMedicalHistories.ToList();
            var allergies = eyeMDDbContext.EmrvisitAllergies.ToList();
            var contactLenses = eyeMDDbContext.EmrvisitContactLenses.ToList();
            var diagCodePools = eyeMDDbContext.EmrvisitDiagCodePools.ToList();
            var diagTests = eyeMDDbContext.EmrvisitDiagTests.ToList();
            var visitOrders = eyeMDDbContext.EmrvisitOrders.ToList();
            var examConditions = eyeMDDbContext.EmrvisitExamConditions.ToList();
            var familyHistories = eyeMDDbContext.EmrvisitFamilyHistories.ToList();
            var iops = eyeMDDbContext.EmrvisitIops.ToList();
            var patientNotes = eyeMDDbContext.EmrptNotes.ToList();
            var planNarratives = eyeMDDbContext.EmrvisitPlanNarratives.ToList();
            var procDiagPools = eyeMDDbContext.EmrvisitProcCodePoolDiags.ToList();
            var procCodePools = eyeMDDbContext.EmrvisitProcCodePools.ToList();
            var refractions = eyeMDDbContext.EmrvisitRefractions.ToList();
            var rxMedications = eyeMDDbContext.EmrvisitRxMedications.ToList();
            var surgicalHistories = eyeMDDbContext.EmrvisitSurgicalHistories.ToList();
            var techs = eyeMDDbContext.EmrvisitTeches.ToList();
            var tech2s = eyeMDDbContext.EmrvisitTech2s.ToList();
            var ffpmPatients = ffpmDbContext.DmgPatients.ToList();
            var ehrMedicalHistories = eHRDbContext.MedicalHistories.ToList();
            var ehrAllergies = eHRDbContext.Allergies.ToList();
            var ehrContactLenses = eHRDbContext.ContactLens.ToList();
            var ehrDiagCodePools = eHRDbContext.DiagCodePools.ToList();
            var ehrDiagTests = eHRDbContext.DiagTests.ToList();
            var ehrVisitOrders = eHRDbContext.VisitOrders.ToList();
            var ehrVisitDoctors = eHRDbContext.VisitDoctors.ToList();
            var ehrExamConditions = eHRDbContext.ExamConditions.ToList();
            var ehrFamilyHistories = eHRDbContext.FamilyHistories.ToList();
            var ehrIops = eHRDbContext.Iops.ToList();
            var ehrPatientNotes = eHRDbContext.PatientNotes.ToList();
            var ehrPlanNarratives = eHRDbContext.PlanNarratives.ToList();
            var ehrProcDiagPools = eHRDbContext.ProcDiagPools.ToList();
            var ehrProcPools = eHRDbContext.ProcPools.ToList();
            var ehrRefractions = eHRDbContext.Refractions.ToList();
            var ehrRos = eHRDbContext.Ros.ToList();
            var ehrRxMedications = eHRDbContext.RxMedications.ToList();
            var ehrSurgHistories = eHRDbContext.SurgHistories.ToList();
            var ehrRxs = eHRDbContext.RxMedications.ToList();
            var ehrTechs = eHRDbContext.Teches.ToList();
            var ehrTech2s = eHRDbContext.Tech2s.ToList();
            var ross = eyeMDDbContext.Emrrosdefaults.ToList();
            var convPatients = convDbContext.Patients.ToList();



            // not even using this
            // PatientsConvert(ehrPatients, eHRDbContext, eyeMDDbContext, logger, progress);
            
            //resultsBox.Invoke((MethodInvoker)delegate {
            //    resultsBox.AppendText("Patients converted.\n");
            //});

            
            VisitsConvert(ehrVisits, eHRDbContext, eyeMDDbContext, logger, progress, visits, eyeMDVisitOrders, ffpmPatients, eyeMDPatients, convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Visits converted.\n");
            });

            
            VisitOrdersConvert(ehrVisitOrders, eHRDbContext, eyeMDDbContext, logger, progress, ehrVisits, visits, eyeMDPatients,
                    eyeMDVisitOrders, visitOrders, ffpmPatients, convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Visit orders converted.\n");
            });

            
            VisitDoctorsConvert(ehrVisitDoctors, eHRDbContext, eyeMDDbContext, logger, progress, visitDoctors, ehrVisits, visits, eyeMDPatients, ffpmPatients,
                convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Visit doctors converted.\n");
            });

            
            MedicalHistoriesConvert(ehrMedicalHistories, eHRDbContext, eyeMDDbContext, logger, progress, ehrVisits, visits, eyeMDPatients, medicalHistories, 
                ffpmPatients, convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Medical histories converted.\n");
            });

            
            AllergiesConvert(ehrAllergies, eHRDbContext, eyeMDDbContext, logger, progress, allergies, visits, eyeMDPatients, ffpmPatients, convPatients, ehrVisits);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Allergies converted.\n");
            });

            // only for in in case we need it, we shouldnt
            /*foreach (var appointments in eHRDbContext.Appointments) {
                AppointmentsConvert(appointments, eHRDbContext, eyeMDDbContext, logger, progress);
            }
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Appointments converted.\n");
            });*/


            ContactLensesConvert(ehrContactLenses, eHRDbContext, eyeMDDbContext, logger, progress, ehrVisits, visits, eyeMDPatients, contactLenses, ffpmPatients, 
                convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Contact lenses converted.\n");
            });


            DiagCodePoolsConvert(ehrDiagCodePools, eHRDbContext, eyeMDDbContext, logger, progress, ehrVisits, visits, eyeMDPatients, diagCodePools, ffpmPatients, 
                convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Diag code pools converted.\n");
            });

            
            DiagTestsConvert(ehrDiagTests, eHRDbContext, eyeMDDbContext, logger, progress, ehrVisits, visits, eyeMDPatients, diagTests, ffpmPatients, convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Diag tests converted.\n");
            });

            
            ExamConditionsConvert(ehrExamConditions, eHRDbContext, eyeMDDbContext, logger, progress, ehrVisits, visits, eyeMDPatients, examConditions, ffpmPatients, 
                convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Exam conditions converted.\n");
            });


            FamilyHistoriesConvert(ehrFamilyHistories, eHRDbContext, eyeMDDbContext, logger, progress, ehrVisits, visits, eyeMDPatients, familyHistories, ffpmPatients,
				convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Family histories converted.\n");
            });


            IopsConvert(ehrIops, eHRDbContext, eyeMDDbContext, logger, progress, ehrVisits, visits, eyeMDPatients, iops, ffpmPatients, convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("IOPs converted.\n");
            });

            
           /* PatientDocumentsConvert(patientDocument, eHRDbContext, eyeMDDbContext, logger, progress);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Patient documents converted.\n");
            });*/

            
            PatientNotesConvert(ehrPatientNotes, eHRDbContext, eyeMDDbContext, logger, progress, patientNotes, ehrVisits, visits, eyeMDPatients, ffpmPatients,
				convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Patient notes converted.\n");
            });
            
            PlanNarrativesConvert(ehrPlanNarratives, eHRDbContext, eyeMDDbContext, logger, progress, ehrVisits, visits, eyeMDPatients, planNarratives, ffpmPatients,
				convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Plan narratives converted.\n");
            });

            ProcDiagPoolsConvert(ehrProcDiagPools, eHRDbContext, eyeMDDbContext, logger, progress, ehrVisits, visits, procDiagPools, ffpmPatients, eyeMDPatients,
				convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Proc diag pools converted.\n");
            });

            ProcPoolsConvert(ehrProcPools, eHRDbContext, eyeMDDbContext, logger, progress, ehrVisits, visits, procCodePools, eyeMDPatients, ffpmPatients,
				convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Proc pools converted.\n");
            });

            RefractionsConvert(ehrRefractions, eHRDbContext, eyeMDDbContext, logger, progress, ehrVisits, visits, eyeMDPatients, refractions, ffpmPatients,
				convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Refractions converted.\n");
            });

            RosConvert(ehrRos, eHRDbContext, eyeMDDbContext, logger, progress, ross, convPatients, ehrVisits);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("ROS converted.\n");
            });


            RxConvert(ehrRxs, eHRDbContext, eyeMDDbContext, logger, progress, ehrVisits, visits, rxMedications, eyeMDPatients, ffpmPatients, convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Rx medications converted.\n");
            });


            SurgHistoriesConvert(ehrSurgHistories, eHRDbContext, eyeMDDbContext, logger, progress, visits, surgicalHistories, eyeMDPatients, ehrVisits, 
                ffpmPatients, convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Surg histories converted.\n");
            });


            TechsConvert(ehrTechs, eHRDbContext, eyeMDDbContext, logger, progress, ehrVisits, visits, eyeMDPatients, techs, ffpmPatients, convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Techs converted.\n");
            });
            

            Tech2sConvert(ehrTech2s, eHRDbContext, eyeMDDbContext, logger, progress, ehrVisits, visits, eyeMDPatients, tech2s, ffpmPatients, convPatients);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Tech2s converted.\n");
            });
        }
/*
        public static void PatientsConvert(List<ModelsC.Patient> ehrPatients, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            foreach (var ehrPatient in ehrPatients) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    // This is only in case the situation arises where we do eyemd and not ffpm
                    return;
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the patient with ID: {ehrPatient.Id}. Error: {e.Message}");
                }
            }
        }*/

        public static void AllergiesConvert(List<ModelsC.Allergy> ehrAllergies, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<EmrvisitAllergy> allergies, List<Emrvisit> visits, List<Emrpatient> eyeMDPatients, List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients,
                List<ModelsC.Visit> ehrVisits) {
            foreach (var allergy in ehrAllergies) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    int? visitId = null;
                    int? ptId = null;
                    DmgPatient? ffpmPatient = null;
                    Emrvisit? EyeMDVisit = null;
                    Emrpatient? eyeMDPatient = null;
                    if (allergy.PtId > 0) {
                        ptId = allergy.PtId;
                        var convPatient = convPatients.FirstOrDefault(p => p.Id == ptId);
                        if (convPatient == null) {
                            var ehrVisit = ehrVisits.FirstOrDefault(v => v.OldVisitId == visitId.ToString());
                            if (ehrVisit == null) {
                                logger.Log($"EHR: EHR Visit and Patient not found for allergy (1) with ID: {allergy.Id}");
                                continue;
                            }
                            else {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == ehrVisit.Id);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for allergy with ID: {allergy.Id}");
                                    continue;
                                }
                                else {
                                    ptId = EyeMDVisit.PtId;
                                    eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                    if (eyeMDPatient == null) {
                                        logger.Log($"EHR: EyeMD Patient not found for allergy with ID: {allergy.Id}");
                                        continue;
                                    }
                                    else {
                                        visitId = EyeMDVisit.VisitId;
                                        continue;
                                    }
                                }
                            }
                        }
                        ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber && (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
                        if (ffpmPatient == null) {
                            if (allergy.VisitId > 0) {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == allergy.VisitId);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for allergy with ID: {allergy.Id}");
                                    continue;
                                }
                                else {
                                    ptId = EyeMDVisit.PtId;
                                    eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                    if (eyeMDPatient == null) {
                                        logger.Log($"EHR: EyeMD Patient not found for allergy with ID: {allergy.Id}");
                                        continue;
                                    }
                                    else {
                                        visitId = EyeMDVisit.VisitId;
                                    }
                                }
                            }
                            else {
                                logger.Log($"EHR: FFPM Patient not found for allergy with ID: {allergy.Id}");
                                continue;
                            }
                        }
                        else {
                            eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ffpmPatient.PatientId);
                            if (eyeMDPatient == null) {
                                ptId = null;
                            }
                            if (allergy.VisitId > 0) {
                                var ehrVisit = ehrVisits.FirstOrDefault(v => v.Id == allergy.VisitId);
                                if (ehrVisit == null) {
                                    logger.Log($"EHR: EHR Visit and Patient not found for allergy (2) with ID: {allergy.Id}");
                                    continue;
                                }
                                else {
                                    visitId = ehrVisit.Id;
                                    ptId = ehrVisit.PtId;
                                }
                            }
                        }
                    }
                    else if (allergy.VisitId > 0) {
                        visitId = allergy.VisitId;
                        EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
                        if (EyeMDVisit == null) {
                            logger.Log($"EHR: EyeMD visit and patient not found for allergy with ID: {allergy.Id}");
                            continue;
                        }
                        else {
                            ptId = EyeMDVisit.PtId;
                            eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                        }
                    }
                    
                    DateTime? dosDate = null;
                    if (allergy.Dosdate != null && allergy.Dosdate != "" && !int.TryParse(allergy.Dosdate, out int dontCare)) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(allergy.Dosdate, dateFormats,
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
                    if (allergy.Created != null && allergy.Created != "" && !int.TryParse(allergy.Created, out dontCare)) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(allergy.Created, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            created = tempDateTime;
                        }
                    }
                    int? empId = null;
                    if (allergy.CreatedEmpId != null) {
                        if (int.TryParse(allergy.CreatedEmpId, out int locum)) {
                            empId = locum;
                        }
                    }

                    var ehrOrig = allergies.FirstOrDefault(a => a.PtId == ptId && a.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newVisitAllergy = new Brady_s_Conversion_Program.ModelsB.EmrvisitAllergy {
                            AllergyName = TruncateString(allergy.AllergyName, 255),
                            VisitId = visitId,
                            PtId = ptId,
                            Dosdate = dosDate,
                            Severity = TruncateString(allergy.Severity, 100),
                            Reaction = TruncateString(allergy.Reaction, 100),
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
                            // No add and save as per instruction
                        };
                        allergies.Add(newVisitAllergy);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the allergy with ID: {allergy.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.UpdateRange(allergies);
            eyeMDDbContext.SaveChanges();
            allergies = eyeMDDbContext.EmrvisitAllergies.ToList();
        }

        public static void MedicalHistoriesConvert(List<ModelsC.MedicalHistory> ehrMedicalHistories, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger,
            ProgressBar progress, List<Visit> ehrVisits, List<Emrvisit> visits, List<Emrpatient> eyeMDPatients, List<EmrvisitMedicalHistory> medicalHistories, 
                List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients) {
            foreach (var medicalHistory in ehrMedicalHistories) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
					int? visitId = null;
					int? ptId = null;
					DmgPatient? ffpmPatient = null;
					Emrvisit? EyeMDVisit = null;
					Emrpatient? eyeMDPatient = null;
					if (medicalHistory.PtId > 0) {
						ptId = medicalHistory.PtId;
						var convPatient = convPatients.FirstOrDefault(p => p.Id == ptId);
						if (convPatient == null) {
                            var ehrVisit = ehrVisits.FirstOrDefault(v => v.OldVisitId == visitId.ToString());
                            if (ehrVisit == null) {
                                logger.Log($"EHR: EHR Visit and Patient not found for medicalHistory (1) with ID: {medicalHistory.Id}");
                                continue;
                            }
                            else {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == ehrVisit.Id);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for medicalHistory with ID: {medicalHistory.Id}");
                                    continue;
                                }
                                else {
                                    ptId = EyeMDVisit.PtId;
                                    eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                    if (eyeMDPatient == null) {
                                        logger.Log($"EHR: EyeMD Patient not found for medicalHistory with ID: {medicalHistory.Id}");
                                        continue;
                                    }
                                    else {
                                        visitId = EyeMDVisit.VisitId;
                                        continue;
                                    }
                                }
                            }
                        }
						ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber && (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
						if (ffpmPatient == null) {
							if (medicalHistory.VisitId > 0) {
								EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == medicalHistory.VisitId);
								if (EyeMDVisit == null) {
									logger.Log($"EHR: EyeMD visit and FFPM patient not found for medicalHistory with ID: {medicalHistory.Id}");
									continue;
								}
								else {
									ptId = EyeMDVisit.PtId;
									eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
									if (eyeMDPatient == null) {
										logger.Log($"EHR: EyeMD Patient not found for medicalHistory with ID: {medicalHistory.Id}");
										continue;
									}
									else {
										visitId = EyeMDVisit.VisitId;
									}
								}
							}
							else {
								logger.Log($"EHR: FFPM Patient not found for medicalHistory with ID: {medicalHistory.Id}");
								continue;
							}
						}
						else {
							eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ffpmPatient.PatientId);
							if (eyeMDPatient == null) {
								ptId = null;
							}
							if (medicalHistory.VisitId > 0) {
								var ehrVisit = ehrVisits.FirstOrDefault(v => v.Id == medicalHistory.VisitId);
								if (ehrVisit == null) {
									logger.Log($"EHR: EHR Visit and Patient not found for medicalHistory (2) with ID: {medicalHistory.Id}");
									continue;
								}
								else {
									visitId = ehrVisit.Id;
									ptId = ehrVisit.PtId;
								}
							}
                        }
                    }
                    else if (medicalHistory.VisitId > 0) {
							visitId = medicalHistory.VisitId;
							EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
							if (EyeMDVisit == null) {
								logger.Log($"EHR: EyeMD visit and patient not found for medicalHistory with ID: {medicalHistory.Id}");
								continue;
							}
							else {
								ptId = EyeMDVisit.PtId;
								eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
							}
						}

						DateTime? dosDate = null;
                    if (medicalHistory.Dosdate != null && medicalHistory.Dosdate != "" && !int.TryParse(medicalHistory.Dosdate, out int dontCare)) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(medicalHistory.Dosdate, dateFormats,
                            CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            dosDate = tempDateTime;
                        }
                    }

                    int? controlId = null;
                    if (medicalHistory.ControlId != null) {
                        if (int.TryParse(medicalHistory.ControlId, out int locum)) {
                            controlId = locum;
                        }
                    }
                    int? origVisMedHisID = null;
                    if (medicalHistory.OrigVisitMedicalHistoryId != null) {
                        if (int.TryParse(medicalHistory.OrigVisitMedicalHistoryId, out int locum)) {
                            origVisMedHisID = locum;
                        }
                    }
                    int? origVismedicalHistoryID = null;
                    if (medicalHistory.OrigVisitDiagCodePoolId != null) {
                        if (int.TryParse(medicalHistory.OrigVisitDiagCodePoolId, out int locum)) {
                            origVismedicalHistoryID = locum;
                        }
                    }
                    DateTime? origDosDate = null;
                    // No origDosDate
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
                    int? resolvedReqProcID1 = null;
                    if (medicalHistory.ResolvedRequestedProcedureId1 != null) {
                        if (int.TryParse(medicalHistory.ResolvedRequestedProcedureId1, out int locum)) {
                            resolvedReqProcID1 = locum;
                        }
                    }
                    DateTime? resolvedDate1 = null;
                    if (medicalHistory.ResolvedDate1 != null) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(medicalHistory.ResolvedDate1, dateFormats,
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
                        if (DateTime.TryParseExact(medicalHistory.ResolvedDate2, dateFormats,
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
                    if (medicalHistory.DoNotReconcile != null && medicalHistory.DoNotReconcile.ToLower() == "yes" || medicalHistory.DoNotReconcile == "1") {
                        doNotReconcile = true;
                    }
                    DateTime? lastModified = null;
                    if (medicalHistory.LastModified != null) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(medicalHistory.LastModified, dateFormats,
                                    CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            lastModified = tempDateTime;
                        }
                    }
                    DateTime? created = null;
                    if (medicalHistory.Created != null) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(medicalHistory.Created, dateFormats,
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

                    var ehrOrig = medicalHistories.FirstOrDefault(mh => mh.PtId == ptId && mh.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newMedicalHistory = new Brady_s_Conversion_Program.ModelsB.EmrvisitMedicalHistory {
                            PtId = ptId,
                            VisitId = visitId,
                            ControlId = controlId,
                            Dosdate = dosDate,
                            OrigVisitMedicalHistoryId = origVisMedHisID,
                            OrigVisitDiagCodePoolId = origVismedicalHistoryID,
                            OrigDosdate = origDosDate,
                            Description = TruncateString(description, 255),
                            Code = TruncateString(code, 50),
                            Modifier = TruncateString(modifier, 50),
                            CodeIcd10 = TruncateString(codeICD10, 50),
                            CodeSnomed = TruncateString(codeSnomed, 50),
                            TypeId = typeId,
                            Location1 = TruncateString(location1, 50),
                            Severity1 = severity1,
                            OnsetMonth1 = TruncateString(onsetMonth1, 10),
                            OnsetDay1 = TruncateString(onsetDay1, 10),
                            OnsetYear1 = TruncateString(onsetYear1, 10),
                            Location2 = TruncateString(location2, 50),
                            Severity2 = severity2,
                            OnsetMonth2 = TruncateString(onsetMonth2, 10),
                            OnsetDay2 = TruncateString(onsetDay2, 10),
                            OnsetYear2 = TruncateString(onsetYear2, 10),
                            IsResolved1 = isResolved1,
                            ResolvedVisitId1 = resolvedVisitID1,
                            ResolvedRequestedProcedureId1 = resolvedReqProcID1,
                            ResolvedDate1 = resolvedDate1,
                            ResolveType1 = TruncateString(resolveType1, 75),
                            IsResolved2 = isResolved2,
                            ResolvedVisitId2 = resolvedVisitID2,
                            ResolvedRequestedProcedureId2 = resolvedReqProcID2,
                            ResolvedDate2 = resolvedDate2,
                            ResolveType2 = TruncateString(resolveType2, 75),
                            Notes = notes,
                            InsertGuid = TruncateString(insertGUID, 50),
                            DoNotReconcile = doNotReconcile,
                            LastModified = lastModified,
                            Created = created,
                            CreatedEmpId = createdEmpId,
                            LastModifiedEmpId = lastModifiedEmpId,
                            Location2OnsetVisitId = null
                        };
                        medicalHistories.Add(newMedicalHistory);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the medical history with ID: {medicalHistory.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.UpdateRange(medicalHistories);
            eyeMDDbContext.SaveChanges();
            medicalHistories = eyeMDDbContext.EmrvisitMedicalHistories.ToList();
        }

        public static void VisitsConvert(List<Visit> ehrVisits, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger,
            ProgressBar progress, List<Emrvisit> visits, List<EmrvisitOrder> newVisitOrders, List<DmgPatient> ffpmPatients, List<Emrpatient> eyeMDPatients,
                List<Models.Patient> convPatients) {
            foreach (var visit in ehrVisits) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    int ptId = -1;
                    if (visit.PtId > 0) {
                        ptId = visit.PtId;
                    }
                    else {
                        logger.Log($"EHR: EHR Patient ID not found for visit with ID: {visit.Id}");
                        continue;
                    }
                    var convPatient = convPatients.FirstOrDefault(cp => cp.Id == ptId);
                    if (convPatient == null) {
                        logger.Log($"EHR: conv Patient not found for visit with ID: {visit.Id}");
                        continue;
                    }
                    var ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber && (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
                    if (ffpmPatient == null) {
                        logger.Log($"EHR: FFPM Patient not found for visit with ID: {visit.Id}");
                        continue;
                    }
                    var eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.ClientSoftwarePtId == ffpmPatient.PatientId.ToString());
                    if (eyeMDPatient == null) {
                        logger.Log($"EHR: EHR Patient not found for visit with ID: {visit.Id}");
                        continue;
                    }
                    ptId = eyeMDPatient.PtId;

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

                    int clientSoftwareApptId = visit.Id;

                    int? clientSoftwarePtId = null;
                    if (visit.PtId > 0) {
                        clientSoftwarePtId = visit.PtId;
                    }
                    else {
                        logger.Log($"EHR: EHR Patient ID not found for visit with ID: {visit.Id}");
                        continue;
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
                        if (DateTime.TryParseExact(visit.Dosdate, dateFormats,
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
                        if (DateTime.TryParseExact(visit.MdsignedOffDate, dateFormats,
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
                        if (DateTime.TryParseExact(visit.InitialSignedOffDate, dateFormats,
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
                    if (visit.ReconciledCcda != null && visit.ReconciledCcda.ToLower() == "yes" || visit.ReconciledCcda == "1") {
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
                        PtId = ptId,
                        ClientSoftwareApptId = clientSoftwareApptId,
                        ClientSoftwarePtId = clientSoftwarePtId,
                        LocationId = locationId,
                        ProviderEmpId = providerEmpId,
                        ExamType = examTypeId,
                        Dosdate = dosDate,
                        VisitTech = visitTech,
                        VisitDoctor = visitDoctor,
                        VisitRefProviderId = visitRefProviderId,
                        VisitPriCareProviderId = visitPriCareProviderId,
                        VisitType = TruncateString(visitType, 50),
                        VisitTypeId = visitTypeId,
                        VisitClassId = visitClassId,
                        LinkedProcedureVisitId = linkedProcVisitId,
                        LocationSpecific = TruncateString(locationSpecific, 50),
                        MdsignedOffDate = mdSignedOffDate,
                        MdsignedOffEmpId = mdSignedOffEmpId,
                        CodeId = codeId,
                        ProcVisitTypeId = procVisitTypeId,
                        TabVitals = tabVitals,
                        VisitEyeCareProviderId = visitEyeCareProvId,
                        TechIsDirty = techIsDirty,
                        TechDirtyInfo = TruncateString(techDirtyInfo, 255),
                        TechWu2isDirty = techWU2IsDirty,
                        TechWu2dirtyInfo = TruncateString(techWU2DirtyInfo, 255),
                        TechRosisDirty = techROSIsDirty,
                        TechRosdirtyInfo = TruncateString(techROSDirtyInfo, 255),
                        DiagTestIsDirty = diagTestIsDirty,
                        DiagTestDirtyInfo = TruncateString(diagTestDirtyInfo, 255),
                        DoctorIsDirty = doctorIsDirty,
                        DoctorDirtyInfo = TruncateString(doctorDirtyInfo, 255),
                        ReconciledCcda = reconciledCCDA,
                        ProvidedPtEducation = providedPtEducation,
                        TabImmunizations = tabImmunizations,
                        InsertGuid = TruncateString(insertGUID, 50),
                        ProcIsDirty = procIsDirty,
                        ProcDirtyInfo = TruncateString(procDirtyInfo, 255),
                        ExcludeVisit = excludedVisit,
                        ClrefNoteRemember = clrefNoteRemember,
                        ServiceType = serviceType,
                        InitialSignedOffRole = TruncateString(initialSignedOffRole, 50),
                        InitialSignedOff = initialSignedOff,
                        InitialSignedOffDate = initialSignedOffDate,
                        InitialSignedOffEmpId = initialSignedOffEmpId,
                        TabExam = tabExam,
                        TabDrawing = tabDrawing,
                        Wu2visitTypeId = null
                    };
                    visits.Add(newVisit);
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the visit with ID: {visit.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.UpdateRange(visits);
            eyeMDDbContext.SaveChanges();
            visits = eyeMDDbContext.Emrvisits.ToList();
        }

        public static void VisitOrdersConvert(List<ModelsC.VisitOrder> ehrVisitOrders, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext,
            ILogger logger, ProgressBar progress, List<Visit> ehrVisits, List<Emrvisit> visits, List<Emrpatient> eyeMDPatients,
                List<EmrvisitOrder> eyeMDVisitOrders, List<EmrvisitOrder> visitOrders, List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients) {
            foreach (var visitOrder in ehrVisitOrders) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
					int? visitId = null;
					int? ptId = null;
					DmgPatient? ffpmPatient = null;
					Emrvisit? EyeMDVisit = null;
					Emrpatient? eyeMDPatient = null;
					if (visitOrder.PtId > 0) {
						ptId = visitOrder.PtId;
						var convPatient = convPatients.FirstOrDefault(p => p.Id == ptId);
						if (convPatient == null) {
							logger.Log($"EHR: Conv Patient not found for visitOrder with ID: {visitOrder.Id}");
							continue;
						}
						ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber && (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
						if (ffpmPatient == null) {
							if (visitOrder.VisitId > 0) {
								EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitOrder.VisitId);
								if (EyeMDVisit == null) {
									logger.Log($"EHR: EyeMD visit and FFPM patient not found for visitOrder with ID: {visitOrder.Id}");
									continue;
								}
								else {
									ptId = EyeMDVisit.PtId;
									eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
									if (eyeMDPatient == null) {
										logger.Log($"EHR: EyeMD Patient not found for visitOrder with ID: {visitOrder.Id}");
										continue;
									}
									else {
										visitId = EyeMDVisit.VisitId;
									}
								}
							}
							else {
								logger.Log($"EHR: FFPM Patient not found for visitOrder with ID: {visitOrder.Id}");
								continue;
							}
						}
						else {
							eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ffpmPatient.PatientId);
							if (eyeMDPatient == null) {
								ptId = null;
							}
							if (visitOrder.VisitId > 0) {
								var ehrVisit = ehrVisits.FirstOrDefault(v => v.Id == visitOrder.VisitId);
								if (ehrVisit == null) {
									logger.Log($"EHR: EHR Visit and Patient not found for visitOrder (1) with ID: {visitOrder.Id}");
									continue;
								}
								else {
									visitId = ehrVisit.Id;
									ptId = ehrVisit.PtId;
								}
							}
                        }
                    }
                    else if (visitOrder.VisitId > 0) {
							visitId = visitOrder.VisitId;
							EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
							if (EyeMDVisit == null) {
								logger.Log($"EHR: EyeMD visit and patient not found for visitOrder with ID: {visitOrder.Id}");
								continue;
							}
							else {
								ptId = EyeMDVisit.PtId;
								eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
							}
						}

						DateTime? dosdate = null;
                    if (visitOrder.Dosdate != null) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(visitOrder.Dosdate, dateFormats,
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
                        if (DateTime.TryParseExact(visitOrder.OrderLabResultFulfilledDate, dateFormats,
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

                    var ehrOrig = eyeMDVisitOrders.FirstOrDefault(vo => vo.PtId == ptId && vo.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newVisitOrder = new Brady_s_Conversion_Program.ModelsB.EmrvisitOrder {
                            VisitId = visitId,
                            PtId = ptId,
                            Dosdate = dosdate,
                            OrderDescription = description, // Assuming NVARCHAR(MAX), no truncation needed
                            OrderWhen = TruncateString(orderWhen, 255),
                            OrderScheduledDate = orderScheduledDate, // Assuming the date is stored as string
                            DoNotPrintRx = doNotPrintRx,
                            AddedbyFastPlanId = addedbyFastPlanId,
                            OrderTypeId = orderTypeId,
                            OrderHasSpecimen = orderHasSpecimen,
                            OrderSpecimenType = orderSpecimenType, // Assuming NVARCHAR(MAX), no truncation needed
                            OrderSpecimenId = orderSpecimenId, // Assuming NVARCHAR(MAX), no truncation needed
                            OrderLabResultFulfilledDate = orderLabResultFulfilledDate,
                            OrderLabResultId = orderLabResultId,
                            OrderNeedsFollowup = orderNeedsFollowUp,
                            OrderWasFollowedup = orderWasFollowedUp,
                            OrderNotes = orderNotes, // Assuming NVARCHAR(MAX), no truncation needed
                            SummarySent = summarySent,
                            OrderRemarks = TruncateString(orderRemarks, 255),
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
                        visitOrders.Add(newVisitOrder);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the visit order with ID: {visitOrder.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.UpdateRange(visitOrders);
            eyeMDDbContext.SaveChanges();
            eyeMDVisitOrders = eyeMDDbContext.EmrvisitOrders.ToList();
        }

        public static void VisitDoctorsConvert(List<ModelsC.VisitDoctor> ehrVisitDoctors, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<EmrvisitDoctor> visitDoctors, List<Visit> ehrVisits, List<Emrvisit> visits, List<Emrpatient> eyeMDPatients, List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients) {
            foreach (var visitDoctor in ehrVisitDoctors) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
					int? visitId = null;
					int? ptId = null;
					DmgPatient? ffpmPatient = null;
					Emrvisit? EyeMDVisit = null;
					Emrpatient? eyeMDPatient = null;
					if (visitDoctor.PtId > 0) {
						ptId = visitDoctor.PtId;
						var convPatient = convPatients.FirstOrDefault(p => p.Id == ptId);
						if (convPatient == null) {
							logger.Log($"EHR: Conv Patient not found for visitDoctor with ID: {visitDoctor.Id}");
							continue;
						}
						ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber && (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
						if (ffpmPatient == null) {
							if (visitDoctor.OldVisitId > 0) {
								EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitDoctor.OldVisitId);
								if (EyeMDVisit == null) {
									logger.Log($"EHR: EyeMD visit and FFPM patient not found for visitDoctor with ID: {visitDoctor.Id}");
									continue;
								}
								else {
									ptId = EyeMDVisit.PtId;
									eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
									if (eyeMDPatient == null) {
										logger.Log($"EHR: EyeMD Patient not found for visitDoctor with ID: {visitDoctor.Id}");
										continue;
									}
									else {
										visitId = EyeMDVisit.VisitId;
									}
								}
							}
							else {
								logger.Log($"EHR: FFPM Patient not found for visitDoctor with ID: {visitDoctor.Id}");
								continue;
							}
						}
						else {
							eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ffpmPatient.PatientId);
							if (eyeMDPatient == null) {
								ptId = null;
							}
							if (visitDoctor.OldVisitId > 0) {
								var ehrVisit = ehrVisits.FirstOrDefault(v => v.Id == visitDoctor.OldVisitId);
								if (ehrVisit == null) {
									logger.Log($"EHR: EHR Visit and Patient not found for visitDoctor (1) with ID: {visitDoctor.Id}");
									continue;
								}
								else {
									visitId = ehrVisit.Id;
									ptId = ehrVisit.PtId;
								}
							}
                        }
                    }
                    else if (visitDoctor.OldVisitId > 0) {
							visitId = visitDoctor.OldVisitId;
							EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
							if (EyeMDVisit == null) {
								logger.Log($"EHR: EyeMD visit and patient not found for visitDoctor with ID: {visitDoctor.Id}");
								continue;
							}
							else {
								ptId = EyeMDVisit.PtId;
								eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
							}
						}

						DateTime? dosdate = null;
                    if (visitDoctor.Dosdate != null) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(visitDoctor.Dosdate, dateFormats,
                                                   CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            dosdate = tempDateTime;
                        }
                    }
                                        string sleDiagOd = "";
                    if (visitDoctor.SlediagOd != null) {
                        sleDiagOd = visitDoctor.SlediagOd;
                    }
                    string sleDiagOs = "";
                    if (visitDoctor.SlediagOs != null) {
                        sleDiagOs = visitDoctor.SlediagOs;
                    }
                    string sleComments = "";
                    if (visitDoctor.Slecomments != null) {
                        sleComments = visitDoctor.Slecomments;
                    }
                    string dfeCdRatioVertOd = "";
                    if (visitDoctor.DfecdratioVertOd != null) {
                        dfeCdRatioVertOd = visitDoctor.DfecdratioVertOd;
                    }
                    string dfeCdRatioVertOs = "";
                    if (visitDoctor.DfecdratioVertOs != null) {
                        dfeCdRatioVertOs = visitDoctor.DfecdratioVertOs;
                    }
                    string dfeCdRatioHorizOd = "";
                    if (visitDoctor.DfecdratioHorizOd != null) {
                        dfeCdRatioHorizOd = visitDoctor.DfecdratioHorizOd;
                    }
                    string dfeCdRatioHorizOs = "";
                    if (visitDoctor.DfecdratioHorizOs != null) {
                        dfeCdRatioHorizOs = visitDoctor.DfecdratioHorizOs;
                    }
                    string dfeDiagOd = "";
                    if (visitDoctor.DfediagOd != null) {
                        dfeDiagOd = visitDoctor.DfediagOd;
                    }
                    string dfeDIagOs = "";
                    if (visitDoctor.DfediagOs != null) {
                        dfeDIagOs = visitDoctor.DfediagOs;
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
                    if (visitDoctor.PlanTargetIopod != null) {
                        planTargetIOPOd = visitDoctor.PlanTargetIopod;
                    }
                    string planTargetIOPOs = "";
                    if (visitDoctor.PlanTargetIopos != null) {
                        planTargetIOPOs = visitDoctor.PlanTargetIopos;
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
                    short? sleAbutehl = null;
                    if (visitDoctor.Sleabutehl != null) {
                        if (short.TryParse(visitDoctor.Sleabutehl, out short locum)) {
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
                    if (visitDoctor.PddistOu != null) {
                        pdDistOu = visitDoctor.PddistOu;
                    }
                    string pdNearOu = "";
                    if (visitDoctor.PdnearOu != null) {
                        pdNearOu = visitDoctor.PdnearOu;
                    }

                    var ehrOrig = visitDoctors.FirstOrDefault(vd => vd.PtId == ptId && vd.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newVisitDoctor = new Brady_s_Conversion_Program.ModelsB.EmrvisitDoctor {
                            VisitId = visitId,
                            PtId = ptId,
                            Dosdate = dosdate,
                            SleDiagOd = TruncateString(sleDiagOd, int.MaxValue),
                            SleDiagOs = TruncateString(sleDiagOs, int.MaxValue),
                            Slecomments = TruncateString(sleComments, int.MaxValue),
                            DfeCdratioVertOd = TruncateString(dfeCdRatioVertOd, 255),
                            DfeCdratioVertOs = TruncateString(dfeCdRatioVertOs, 255),
                            DfeCdratioHorizOd = TruncateString(dfeCdRatioHorizOd, 255),
                            DfeCdratioHorizOs = TruncateString(dfeCdRatioHorizOs, 255),
                            DfeDiagOd = TruncateString(dfeDiagOd, int.MaxValue),
                            DfeDiagOs = TruncateString(dfeDIagOs, int.MaxValue),
                            Dfecomments = TruncateString(dfeComments, int.MaxValue),
                            DiagOtherDiagnoses = TruncateString(diagOtherDiagnoses, int.MaxValue),
                            PlanStaffOrderComments = TruncateString(planStaffOrderComments, int.MaxValue),
                            PlanRtowhen = TruncateString(planRTOWhen, 255),
                            PlanRtoreason = TruncateString(PlanRTOReason, 255),
                            PlanNextScheduledAppt = TruncateString(planNextScheduledAppt, 255),
                            CodingMdm = codingMDM,
                            CodingAdditionalProcedures = TruncateString(codingAdditionalProcs, 255),
                            PlanRxMedRemarks = TruncateString(planRxMedRemarks, int.MaxValue),
                            PlanRxOrdersRemarks = TruncateString(planRxOrdersRemarks, int.MaxValue),
                            DfeextOpth = dfeExtOpth,
                            DfelensUsed = TruncateString(dfeLensUsed, 255),
                            PlanTargetIopOd = TruncateString(planTargetIOPOd, 50),
                            PlanTargetIopOs = TruncateString(planTargetIOPOs, 50),
                            DfedilatedPupilSizeOd = TruncateString(dfeDilatedPupilSizeOd, 50),
                            DfedilatedPupilSizeOs = TruncateString(dfeDilatedPupilSizeOs, 50),
                            PlanDictateEyeCareDoc = planDictateEyeCareDoc,
                            SleAbutehl = sleAbutehl,
                            ScribeEmpId = scribeEmpId,
                            // Further details and assignments as necessary
                            CodingQrautoCheckStatus = null,
                            CodingChargesSent = null,
                            SentToWebPortal = null,
                            SentToWebPortalDays = null
                        };
                        visitDoctors.Add(newVisitDoctor);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the visit doctor with ID: {visitDoctor.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.UpdateRange(visitDoctors);
            eyeMDDbContext.SaveChanges();
            visitDoctors = eyeMDDbContext.EmrvisitDoctors.ToList();
        }

        public static void AppointmentsConvert(ModelsC.Appointment appointment, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
            progress.Invoke((MethodInvoker)delegate {
                progress.PerformStep();
            });
            try {
                // this table is only for the situation where we do eyemd and not ffpm
            }
            catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the appointment with ID: {appointment.Id}. Error: {e.Message}");
            }
        }

        public static void ContactLensesConvert(List<ModelsC.ContactLen> ehrContactLenses, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<Visit> ehrVisits, List<Emrvisit> visits, List<Emrpatient> eyeMDPatients, List<EmrvisitContactLense> contactLenses, List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients) {
            foreach (var contactLens in ehrContactLenses) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    int? visitId = null;
                    int ptId = -1;
                    DmgPatient? ffpmPatient = null;
                    Emrvisit? EyeMDVisit = null;
                    Emrpatient? eyeMDPatient = null;
                    if (contactLens.PtId > 0) {
                        ptId = contactLens.PtId;
                        ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == ptId.ToString());
                        if (ffpmPatient == null) {
                            if (contactLens.VisitId > 0) {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == contactLens.VisitId);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for contactLens with ID: {contactLens.Id}");
                                    continue;
                                }
                                else {
                                    if (EyeMDVisit.PtId != null) {
                                        ptId = (int)EyeMDVisit.PtId;
                                        eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                        if (eyeMDPatient == null) {
                                            logger.Log($"EHR: EyeMD Patient not found for contactLens with ID: {contactLens.Id}");
                                            continue;
                                        }
                                        else {
                                            visitId = EyeMDVisit.VisitId;
                                        }
                                    }
                                    else {
                                        logger.Log($"EHR: EyeMD Patient not found for contactLens with ID: {contactLens.Id}");
                                        continue;
                                    }
                                }
                            }
                            else {
                                logger.Log($"EHR: FFPM Patient not found for contactLens with ID: {contactLens.Id}");
                                continue;
                            }
                        }
                        else if (eyeMDPatient == null) {
                            ptId = (int)ffpmPatient.PatientId;
                            EyeMDVisit = visits.FirstOrDefault(v => v.PtId == ptId);
                            if (EyeMDVisit == null) {
                                visitId = null;
                            }
                        }
                    }
                    else if (contactLens.VisitId > 0) {
                        visitId = contactLens.VisitId;
                        EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
                        if (EyeMDVisit == null) {
                            logger.Log($"EHR: EyeMD visit and patient not found for contactLens with ID: {contactLens.Id}");
                            continue;
                        }
                        else {
                            if (EyeMDVisit.PtId != null) {
                                ptId = (int)EyeMDVisit.PtId;
                                eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                if (eyeMDPatient == null) {
                                    logger.Log($"EHR: EyeMD Patient not found for contactLens with ID: {contactLens.Id}");
                                    continue;
                                }
                            }
                            else {
                                logger.Log($"EHR: EyeMD Patient not found for contactLens with ID: {contactLens.Id}");
                                continue;
                            }
                        }
                    }

                    DateTime dosdate = minAcceptableDate;
                    if (contactLens.Dosdate != null) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(contactLens.Dosdate, dateFormats,
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
                    if (contactLens.Bcod != null) {
                        bcOd = contactLens.Bcod;
                    }
                    string bcOs = "";
                    if (contactLens.Bcos != null) {
                        bcOs = contactLens.Bcos;
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
                    if (contactLens.VaDod != null) {
                        vaDOd = contactLens.VaDod;
                    }
                    string vaDOs = "";
                    if (contactLens.VaDos != null) {
                        vaDOs = contactLens.VaDos;
                    }
                    string vaDOu = "";
                    if (contactLens.VaDou != null) {
                        vaDOu = contactLens.VaDou;
                    }
                    string VaNOd = "";
                    if (contactLens.VaNod != null) {
                        VaNOd = contactLens.VaNod;
                    }
                    string VaNOs = "";
                    if (contactLens.VaNos != null) {
                        VaNOs = contactLens.VaNos;
                    }
                    string VaNOu = "";
                    if (contactLens.VaNou != null) {
                        VaNOu = contactLens.VaNou;
                    }
                    string vaIOd = "";
                    if (contactLens.VaIod != null) {
                        vaIOd = contactLens.VaIod;
                    }
                    string vaIOs = "";
                    if (contactLens.VaIos != null) {
                        vaIOs = contactLens.VaIos;
                    }
                    string vaIOu = "";
                    if (contactLens.VaIou != null) {
                        vaIOu = contactLens.VaIou;
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
                    if (contactLens.Kod != null) {
                        kOd = contactLens.Kod;
                    }
                    string kOs = "";
                    if (contactLens.Kos != null) {
                        kOs = contactLens.Kos;
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
                    if (contactLens.WageOd != null) {
                        wAgeOd = contactLens.WageOd;
                    }
                    string wAgeOs = "";
                    if (contactLens.WageOs != null) {
                        wAgeOs = contactLens.WageOs;
                    }
                    string wTimeTodayOd = "";
                    if (contactLens.WtimeTodayOd != null) {
                        wTimeTodayOd = contactLens.WtimeTodayOd;
                    }
                    string wTimeTodayOs = "";
                    if (contactLens.WtimeTodayOs != null) {
                        wTimeTodayOs = contactLens.WtimeTodayOs;
                    }
                    string wAvgWearTimeOd = "";
                    if (contactLens.WavgWearTimeOd != null) {
                        wAvgWearTimeOd = contactLens.WavgWearTimeOd;
                    }
                    string wAvgWearTimeOs = "";
                    if (contactLens.WavgWearTimeOs != null) {
                        wAvgWearTimeOs = contactLens.WavgWearTimeOs;
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
                    if (contactLens.RgplayoutOd != null) {
                        if (int.TryParse(contactLens.RgplayoutOd, out int locum)) {
                            rgpLayoutOd = locum;
                        }
                    }
                    int? rgpLayoutOs = null;
                    if (contactLens.RgplayoutOs != null) {
                        if (int.TryParse(contactLens.RgplayoutOs, out int locum)) {
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
                    if (contactLens.Bc2od != null) {
                        bc2Od = contactLens.Bc2od;
                    }
                    string bc2Os = "";
                    if (contactLens.Bc2os != null) {
                        bc2Os = contactLens.Bc2os;
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
                    if (contactLens.Upcod != null) {
                        upcOd = contactLens.Upcod;
                    }
                    string upcOs = "";
                    if (contactLens.Upcos != null) {
                        upcOs = contactLens.Upcos;
                    }
                    int? catalogSource = null;
                    if (contactLens.CatalogSource != null) {
                        if (int.TryParse(contactLens.CatalogSource, out int locum)) {
                            catalogSource = locum;
                        }
                    }
                    string catalogManufacturerIdOd = "";
                    if (contactLens.CatalogManufacturerIdod != null) {
                        catalogManufacturerIdOd = contactLens.CatalogManufacturerIdod;
                    }
                    string catalogManufacturerIdOs = "";
                    if (contactLens.CatalogManufacturerIdos != null) {
                        catalogManufacturerIdOs = contactLens.CatalogManufacturerIdos;
                    }
                    string catalogBrandIdOd = "";
                    if (contactLens.CatalogBrandIdod != null) {
                        catalogBrandIdOd = contactLens.CatalogBrandIdod;
                    }
                    string catalogBrandIdOs = "";
                    if (contactLens.CatalogBrandIdos != null) {
                        catalogBrandIdOs = contactLens.CatalogBrandIdos;
                    }
                    string catalogProductIdOd = "";
                    if (contactLens.CatalogProductIdod != null) {
                        catalogProductIdOd = contactLens.CatalogProductIdod;
                    }
                    string catalogProductIdOs = "";
                    if (contactLens.CatalogProductIdos != null) {
                        catalogProductIdOs = contactLens.CatalogProductIdos;
                    }
                    string trialNumber = "";
                    if (contactLens.TrialNumber != null) {
                        trialNumber = contactLens.TrialNumber;
                    }
                    string orSphereOd = "";
                    if (contactLens.OrsphereOd != null) {
                        orSphereOd = contactLens.OrsphereOd;
                    }
                    string orSphereOs = "";
                    if (contactLens.OrsphereOs != null) {
                        orSphereOs = contactLens.OrsphereOs;
                    }
                    string orCylinderOd = "";
                    if (contactLens.OrcylinderOd != null) {
                        orCylinderOd = contactLens.OrcylinderOd;
                    }
                    string orCylinderOs = "";
                    if (contactLens.OrcylinderOs != null) {
                        orCylinderOs = contactLens.OrcylinderOs;
                    }
                    string orAxisOd = "";
                    if (contactLens.OraxisOd != null) {
                        orAxisOd = contactLens.OraxisOd;
                    }
                    string orAxisOs = "";
                    if (contactLens.OraxisOs != null) {
                        orAxisOs = contactLens.OraxisOs;
                    }
                    string orVaDOd = "";
                    if (contactLens.OrvaDod != null) {
                        orVaDOd = contactLens.OrvaDod;
                    }
                    string orVaDOs = "";
                    if (contactLens.OrvaDos != null) {
                        orVaDOs = contactLens.OrvaDos;
                    }
                    string orVaNOd = "";
                    if (contactLens.OrvaNod != null) {
                        orVaNOd = contactLens.OrvaNod;
                    }
                    string orVaNOs = "";
                    if (contactLens.OrvaNos != null) {
                        orVaNOs = contactLens.OrvaNos;
                    }
                    string rotationDirectionOd = "";
                    if (contactLens.RotationDirectionOd != null) {
                        rotationDirectionOd = contactLens.RotationDirectionOd;
                    }
                    string rotationDirectionOs = "";
                    if (contactLens.RotationDirectionOs != null) {
                        rotationDirectionOs = contactLens.RotationDirectionOs;
                    }

                    var ehrOrig = contactLenses.FirstOrDefault(x => x.PtId == ptId);

                    if (ehrOrig == null) {
                        var newContactLens = new Brady_s_Conversion_Program.ModelsB.EmrvisitContactLense {
                            VisitId = visitId,
                            PtId = ptId,
                            Dosdate = dosdate,
                            RxId = rxId,
                            ContactClass = TruncateString(contactClass, 50),
                            LensType = TruncateString(lensType, 50),
                            PowerOd = TruncateString(powerOd, 50),
                            PowerOs = TruncateString(powerOs, 50),
                            CylinderOd = TruncateString(cylinderOd, 50),
                            CylinderOs = TruncateString(cylinderOs, 50),
                            AxisOd = TruncateString(axisOd, 50),
                            AxisOs = TruncateString(axisOs, 50),
                            BcOd = TruncateString(bcOd, 50),
                            BcOs = TruncateString(bcOs, 50),
                            AddOd = TruncateString(addOd, 50),
                            AddOs = TruncateString(addOs, 50),
                            ColorOd = TruncateString(colorOd, 50),
                            ColorOs = TruncateString(colorOs, 50),
                            PupilOd = TruncateString(pupilOd, 50),
                            PupilOs = TruncateString(pupilOs, 50),
                            VaDOd = TruncateString(vaDOd, 50),
                            VaDOs = TruncateString(vaDOs, 50),
                            VaDOu = TruncateString(vaDOu, 50),
                            VaNOd = TruncateString(VaNOd, 50),
                            VaNOs = TruncateString(VaNOs, 50),
                            VaNOu = TruncateString(VaNOu, 50),
                            VaIOd = TruncateString(vaIOd, 50),
                            VaIOs = TruncateString(vaIOs, 50),
                            VaIOu = TruncateString(vaIOu, 50),
                            ComfortOd = TruncateString(comfortOd, 50),
                            ComfortOs = TruncateString(comfortOs, 50),
                            CentrationOd = TruncateString(centrationOd, 50),
                            CentrationOs = TruncateString(centrationOs, 50),
                            CoverageOd = TruncateString(coverageOd, 50),
                            CoverageOs = TruncateString(coverageOs, 50),
                            MovementOd = TruncateString(movementOd, 50),
                            MovementOs = TruncateString(movementOs, 50),
                            DiameterOd = TruncateString(diameterOd, 50),
                            DiameterOs = TruncateString(diameterOs, 50),
                            RotationDegOd = TruncateString(rotationDegOd, 20),
                            RotationDegOs = TruncateString(rotationDegOs, 20),
                            RotationDirectionOd = TruncateString(rotationDirectionOd, 50),
                            RotationDirectionOs = TruncateString(rotationDirectionOs, 50),
                            KOd = TruncateString(kOd, 50),
                            KOs = TruncateString(kOs, 50),
                            EdgeLiftOd = TruncateString(edgeLiftOd, 50),
                            EdgeLiftOs = TruncateString(edgeLiftOs, 50),
                            DistNearOd = TruncateString(distNearOd, 10),
                            DistNearOs = TruncateString(distNearOs, 10),
                            PtInsertedRemoved = ptInsertedRemoved, // smallint, no truncation needed
                            WAgeOd = TruncateString(wAgeOd, 50),
                            WAgeOs = TruncateString(wAgeOs, 50),
                            WTimeTodayOd = TruncateString(wTimeTodayOd, 50),
                            WTimeTodayOs = TruncateString(wTimeTodayOs, 50),
                            WAvgWearTimeOd = TruncateString(wAvgWearTimeOd, 50),
                            WAvgWearTimeOs = TruncateString(wAvgWearTimeOs, 50),
                            Solution = TruncateString(solution, 50),
                            ProductOd = TruncateString(productOd, 255),
                            ProductOs = TruncateString(productOs, 255),
                            LensDesignOd = TruncateString(lensDesignOd, 50),
                            LensDesignOs = TruncateString(lensDesignOs, 50),
                            MaterialOd = TruncateString(materialOd, 50),
                            MaterialOs = TruncateString(materialOs, 50),
                            ReplacementSchedule = TruncateString(replacementSchedule, 50),
                            WearingInstructions = TruncateString(wearingInstructions, 255),
                            Expires = TruncateString(expires, 50),
                            RgpLayoutOd = rgpLayoutOd, // int, no truncation needed
                            RgpLayoutOs = rgpLayoutOs, // int, no truncation needed
                            Power2Od = TruncateString(power2Od, 50),
                            Power2Os = TruncateString(power2Os, 50),
                            Cylinder2Od = TruncateString(cylinder2Od, 50),
                            Cylinder2Os = TruncateString(cylinder2Os, 50),
                            Axis2Od = TruncateString(axis2Od, 50),
                            Axis2Os = TruncateString(axis2Os, 50),
                            Bc2Od = TruncateString(bc2Od, 50),
                            Bc2Os = TruncateString(bc2Os, 50),
                            Diameter2Od = TruncateString(diameter2Od, 50),
                            Diameter2Os = TruncateString(diameter2Os, 50),
                            PeriphCurveOd = TruncateString(periphCurveOd, 50),
                            PeriphCurveOs = TruncateString(periphCurveOs, 50),
                            PeriphCurve2Od = TruncateString(peripheralCurve2Od, 50),
                            PeriphCurve2Os = TruncateString(peripheralCurve2Os, 50),
                            SecondaryCurveOd = TruncateString(secondaryCurveOd, 20),
                            SecondaryCurveOs = TruncateString(secondaryCurveOs, 20),
                            EquivalentCurveOd = TruncateString(equivalentCurveOd, 50),
                            EquivalentCurveOs = TruncateString(equivalentCurveOs, 50),
                            CenterThicknessOd = TruncateString(centerThicknessOd, 50),
                            CenterThicknessOs = TruncateString(centerThicknessOs, 50),
                            OpticalZoneDiaOd = TruncateString(opticalZoneDiaOd, 50),
                            OpticalZoneDiaOs = TruncateString(opticalZoneDiaOs, 50),
                            EdgeOd = TruncateString(edgeOd, 50),
                            EdgeOs = TruncateString(edgeOs, 50),
                            BlendOd = TruncateString(blendOd, 50),
                            BlendOs = TruncateString(blendOs, 50),
                            NaFlPatternOd = TruncateString(naFlPatternOd, 50),
                            NaFlPatternOs = TruncateString(naFlPatternOs, 50),
                            SurfaceWettingOd = TruncateString(surfaceWettingOd, 50),
                            SurfaceWettingOs = TruncateString(surfaceWettingOs, 50),
                            DkOd = TruncateString(dkOd, 50),
                            DkOs = TruncateString(dkOs, 50),
                            SegHeightOd = TruncateString(segHeightOd, 50),
                            SegHeightOs = TruncateString(segHeightOs, 50),
                            SpecialInstructionsOd = TruncateString(specialInstructionsOd, 100),
                            SpecialInstructionsOs = TruncateString(specialInstructionsOs, 100),
                            InsertGuid = TruncateString(insertGUID, 50),
                            TreeviewTableIdOd = treeviewTableIdOd, // int, no truncation needed
                            TreeviewTableIdOs = treeviewTableIdOs, // int, no truncation needed
                            Notes = TruncateString(notes, int.MaxValue),
                            Remarks = TruncateString(remarks, int.MaxValue),
                            Printed = printed, // bit, no truncation needed
                            SentToOptical = sentToOptical, // bit, no truncation needed
                            UpcOd = TruncateString(upcOd, 50),
                            UpcOs = TruncateString(upcOs, 50),
                            CatalogSource = catalogSource, // int, no truncation needed
                            CatalogManufacturerIdOd = TruncateString(catalogManufacturerIdOd, 50),
                            CatalogManufacturerIdOs = TruncateString(catalogManufacturerIdOs, 50),
                            CatalogBrandIdOd = TruncateString(catalogBrandIdOd, 50),
                            CatalogBrandIdOs = TruncateString(catalogBrandIdOs, 50),
                            CatalogProductIdOd = TruncateString(catalogProductIdOd, 50),
                            CatalogProductIdOs = TruncateString(catalogProductIdOs, 50),
                            TrialNumber = TruncateString(trialNumber, 100),
                            OrSphereOd = TruncateString(orSphereOd, 50),
                            OrSphereOs = TruncateString(orSphereOs, 50),
                            OrCylinderOd = TruncateString(orCylinderOd, 50),
                            OrCylinderOs = TruncateString(orCylinderOs, 50),
                            OrAxisOd = TruncateString(orAxisOd, 50),
                            OrAxisOs = TruncateString(orAxisOs, 50),
                            OrVaDOd = TruncateString(orVaDOd, 50),
                            OrVaDOs = TruncateString(orVaDOs, 50),
                            OrVaNOd = TruncateString(orVaNOd, 50),
                            OrVaNOs = TruncateString(orVaNOs, 50)
                        };
                        contactLenses.Add(newContactLens);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the contact lens with ID: {contactLens.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.UpdateRange(contactLenses);
            eyeMDDbContext.SaveChanges();
            contactLenses = eyeMDDbContext.EmrvisitContactLenses.ToList();
        }

        public static void DiagCodePoolsConvert(List<ModelsC.DiagCodePool> ehrDiagCodePools, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<Visit> ehrVisits, List<Emrvisit> visits, List<Emrpatient> eyeMDPatients, List<EmrvisitDiagCodePool> diagCodePools, List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients) {
            foreach (var diagCodePool in ehrDiagCodePools) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
					int? visitId = null;
					int? ptId = null;
					DmgPatient? ffpmPatient = null;
					Emrvisit? EyeMDVisit = null;
					Emrpatient? eyeMDPatient = null;
                    if (diagCodePool.PtId > 0) {
                        ptId = diagCodePool.PtId;
                        var convPatient = convPatients.FirstOrDefault(p => p.Id == ptId);
                        if (convPatient == null) {
                            var ehrVisit = ehrVisits.FirstOrDefault(v => v.OldVisitId == visitId.ToString());
                            if (ehrVisit == null) {
                                logger.Log($"EHR: EHR Visit and Patient not found for diagCodePool (1) with ID: {diagCodePool.Id}");
                                continue;
                            }
                            else {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == ehrVisit.Id);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for diagCodePool (1) with ID: {diagCodePool.Id}");
                                    continue;
                                }
                                else {
                                    ptId = EyeMDVisit.PtId;
                                    eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                    if (eyeMDPatient == null) {
                                        logger.Log($"EHR: EyeMD Patient not found for diagCodePool with ID: {diagCodePool.Id}");
                                        continue;
                                    }
                                    else {
                                        visitId = EyeMDVisit.VisitId;
                                        continue;
                                    }
                                }
                            }
                        }
                        ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber && (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
                        if (ffpmPatient == null) {
                            if (diagCodePool.VisitId > 0) {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == diagCodePool.VisitId);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for diagCodePool (2) with ID: {diagCodePool.Id}");
                                    continue;
                                }
                                else {
                                    ptId = EyeMDVisit.PtId;
                                    eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                    if (eyeMDPatient == null) {
                                        logger.Log($"EHR: EyeMD Patient not found for diagCodePool with ID: {diagCodePool.Id}");
                                        continue;
                                    }
                                    else {
                                        visitId = EyeMDVisit.VisitId;
                                    }
                                }
                            }
                            else {
                                logger.Log($"EHR: FFPM Patient not found for diagCodePool with ID: {diagCodePool.Id}");
                                continue;
                            }
                        }
                        else {
                            eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ffpmPatient.PatientId);
                            if (eyeMDPatient == null) {
                                ptId = null;
                            }
                            if (diagCodePool.VisitId > 0) {
                                var ehrVisit = ehrVisits.FirstOrDefault(v => v.Id == diagCodePool.VisitId);
                                if (ehrVisit == null) {
                                    logger.Log($"EHR: EHR Visit and Patient not found for diagCodePool (2) with ID: {diagCodePool.Id}");
                                    continue;
                                }
                                else {
                                    visitId = ehrVisit.Id;
                                    ptId = ehrVisit.PtId;
                                }
                            }
                        }
                    }
                    else if (diagCodePool.VisitId > 0) {
                        visitId = diagCodePool.VisitId;
                        EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
                        if (EyeMDVisit == null) {
                            logger.Log($"EHR: EyeMD visit and patient not found for diagCodePool with ID: {diagCodePool.Id}");
                            continue;
                        }
                        else {
                            ptId = EyeMDVisit.PtId;
                            eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                        }
                    }

						DateTime? dosDate = null;
                    if (diagCodePool.Dosdate != null) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(diagCodePool.Dosdate, dateFormats,
                            CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            dosDate = tempDateTime;
                        }
                    }
                    int? controlId = null;
                    // no controlId
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
                    if (short.TryParse(diagCodePool.Active, out short temp)) {
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
                        if (DateTime.TryParseExact(diagCodePool.Dosdate, dateFormats,
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
                        if (DateTime.TryParseExact(diagCodePool.Dosdate, dateFormats,
                                                   CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            resolvedDate2 = tempDateTime;
                        }
                    }
                    string resolveType2 = "";
                    if (diagCodePool.ResolveType2 != null) {
                        resolveType2 = diagCodePool.ResolveType2;
                    }
                    bool doNotReconcile = false;
                    if (diagCodePool.DoNotReconcile != null && diagCodePool.DoNotReconcile.ToLower() == "yes" || diagCodePool.DoNotReconcile == "1") {
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

                    var ehrOrig = diagCodePools.FirstOrDefault(dc => dc.PtId == ptId && dc.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newDiagCodePool = new Brady_s_Conversion_Program.ModelsB.EmrvisitDiagCodePool {
                            PtId = ptId,
                            VisitId = visitId,
                            ControlId = controlId,
                            DiagText = TruncateString(diagText, int.MaxValue),
                            Code = TruncateString(code, 50),
                            Modifier = TruncateString(modifier, 50),
                            SourceField = TruncateString(sourceField, 50),
                            IsActive = isactive, // smallint, no truncation needed
                            CodeIcd10 = TruncateString(codeICD10, 50),
                            CodeSnomed = TruncateString(codeSNOMED, 50),
                            InsertGuid = TruncateString(insertGUID, 50),
                            RequestedProcedureId = requestedProcId,
                            Location1 = TruncateString(location1, 50),
                            OnsetMonth1 = TruncateString(onsetMonth1, 10),
                            OnsetDay1 = TruncateString(onsetDay1, 10),
                            OnsetYear1 = TruncateString(onsetYear1, 10),
                            Location2 = TruncateString(location2, 50),
                            Location2OnsetVisitId = location2onsetVisitId,
                            OnsetMonth2 = TruncateString(onsetMonth2, 10),
                            OnsetDay2 = TruncateString(onsetDay2, 10),
                            OnsetYear2 = TruncateString(onsetYear2, 10),
                            IsResolved1 = isResolved1, // smallint, no truncation needed
                            ResolvedVisitId1 = resolvedVisitId1,
                            ResolvedRequestedProcedureId1 = resolvedRequestedProcId1,
                            ResolvedDate1 = resolvedDate1,
                            ResolveType1 = TruncateString(resolveType1, 75),
                            IsResolved2 = isResolved2, // smallint, no truncation needed
                            ResolvedVisitId2 = resolvedVisitId2,
                            ResolvedRequestedProcedureId2 = resolvedRequestedProc2,
                            ResolvedDate2 = resolvedDate2,
                            ResolveType2 = TruncateString(resolveType2, 75),
                            DoNotReconcile = doNotReconcile, // bit, no truncation needed
                            ConditionId = conditionId,
                            LastModified = lastModified,
                            Created = created,
                            CreatedEmpId = createdEmpId,
                            Dosdate = dosDate
                        };

                        diagCodePools.Add(newDiagCodePool);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the diag code pool with visit ID: {diagCodePool.VisitId}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.EmrvisitDiagCodePools.UpdateRange(diagCodePools);
            eyeMDDbContext.SaveChanges();
            diagCodePools = eyeMDDbContext.EmrvisitDiagCodePools.ToList();
        }

        public static void DiagTestsConvert(List<ModelsC.DiagTest> ehrDiagTests, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<Visit> ehrVisits, List<Emrvisit> visits, List<Emrpatient> eyeMDPatients, List<EmrvisitDiagTest> diagTests, List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients) {
            foreach (var diagTest in ehrDiagTests) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
					int? visitId = null;
					int? ptId = null;
					DmgPatient? ffpmPatient = null;
					Emrvisit? EyeMDVisit = null;
					Emrpatient? eyeMDPatient = null;
                    if (diagTest.PtId > 0) {
                        ptId = diagTest.PtId;
                        var convPatient = convPatients.FirstOrDefault(p => p.Id == ptId);
                        if (convPatient == null) {
                            var ehrVisit = ehrVisits.FirstOrDefault(v => v.OldVisitId == visitId.ToString());
                            if (ehrVisit == null) {
                                logger.Log($"EHR: EHR Visit and Patient not found for diagTest (1) with ID: {diagTest.Id}");
                                continue;
                            }
                            else {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == ehrVisit.Id);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for diagTest with ID: {diagTest.Id}");
                                    continue;
                                }
                                else {
                                    ptId = EyeMDVisit.PtId;
                                    eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                    if (eyeMDPatient == null) {
                                        logger.Log($"EHR: EyeMD Patient not found for diagTest with ID: {diagTest.Id}");
                                        continue;
                                    }
                                    else {
                                        visitId = EyeMDVisit.VisitId;
                                        continue;
                                    }
                                }
                            }
                        }
                        ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber && (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
                        if (ffpmPatient == null) {
                            if (diagTest.VisitId > 0) {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == diagTest.VisitId);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for diagTest with ID: {diagTest.Id}");
                                    continue;
                                }
                                else {
                                    ptId = EyeMDVisit.PtId;
                                    eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                    if (eyeMDPatient == null) {
                                        logger.Log($"EHR: EyeMD Patient not found for diagTest with ID: {diagTest.Id}");
                                        continue;
                                    }
                                    else {
                                        visitId = EyeMDVisit.VisitId;
                                    }
                                }
                            }
                            else {
                                logger.Log($"EHR: FFPM Patient not found for diagTest with ID: {diagTest.Id}");
                                continue;
                            }
                        }
                        else {
                            eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ffpmPatient.PatientId);
                            if (eyeMDPatient == null) {
                                ptId = null;
                            }
                            if (diagTest.VisitId > 0) {
                                var ehrVisit = ehrVisits.FirstOrDefault(v => v.Id == diagTest.VisitId);
                                if (ehrVisit == null) {
                                    logger.Log($"EHR: EHR Visit and Patient not found for diagTest (2) with ID: {diagTest.Id}");
                                    continue;
                                }
                                else {
                                    visitId = ehrVisit.Id;
                                    ptId = ehrVisit.PtId;
                                }
                            }
                        }
                    }
                    else if (diagTest.VisitId > 0) {
                        visitId = diagTest.VisitId;
                        EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
                        if (EyeMDVisit == null) {
                            logger.Log($"EHR: EyeMD visit and patient not found for diagTest with ID: {diagTest.Id}");
                            continue;
                        }
                        else {
                            ptId = EyeMDVisit.PtId;
                            eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                        }
                    }

						DateTime? dosDate = null;
                    if (diagTest.Dosdate != null) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(diagTest.Dosdate, dateFormats,
                                                   CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            dosDate = tempDateTime;
                        }
                    }

                    #region diagTests
                    string gonioAngleDepthSuOd = diagTest.GonioAngleDepthSuOd ?? "";
                    string gonioAngleDepthMedialOd = diagTest.GonioAngleDepthMedialOd ?? "";
                    string gonioAngleDepthInOd = diagTest.GonioAngleDepthInOd ?? "";
                    string gonioAngleDepthTemporalOd = diagTest.GonioAngleDepthTemporalOd ?? "";
                    string gonioAngleStructureSuOd = diagTest.GonioAngleStructureSuOd ?? "";
                    string gonioAngleStructureMedialOd = diagTest.GonioAngleStructureMedialOd ?? "";
                    string gonioAngleStructureInOd = diagTest.GonioAngleStructureInOd ?? "";
                    string gonioAngleStructureTemporalOd = diagTest.GonioAngleStructureTemporalOd ?? "";
                    string gonioAngleDepthSuOs = diagTest.GonioAngleDepthSuOs ?? "";
                    string gonioAngleDepthMedialOs = diagTest.GonioAngleDepthMedialOs ?? "";
                    string gonioAngleDepthInOs = diagTest.GonioAngleDepthInOs ?? "";
                    string gonioAngleDepthTemporalOs = diagTest.GonioAngleDepthTemporalOs ?? "";
                    string gonioAngleStructureSuOs = diagTest.GonioAngleStructureSuOs ?? "";
                    string gonioAngleStructureMedialOs = diagTest.GonioAngleStructureMedialOs ?? "";
                    string gonioAngleStructureInOs = diagTest.GonioAngleStructureInOs ?? "";
                    string gonioAngleStructureTemporalOs = diagTest.GonioAngleStructureTemporalOs ?? "";
                    string gonioComments = diagTest.GonioComments ?? "";

                    short mBalanceScOrtho = short.TryParse(diagTest.MbalanceScortho, out short temp) ? temp : (short)-1;
                    string mBalanceHorizScPriGaze = diagTest.MbalanceHorizScpriGaze ?? "";
                    string mBalanceHorizTypeScPriGaze = diagTest.MbalanceHorizTypeScpriGaze ?? "";
                    string mBalanceVertScPriGaze = diagTest.MbalanceVertScpriGaze ?? "";
                    string mBalanceVertTypeScPriGaze = diagTest.MbalanceVertTypeScpriGaze ?? "";
                    string mBalanceHorizScupGaze = diagTest.MbalanceHorizScupGaze ?? "";
                    string mBalanceHorizTypeScupGaze = diagTest.MbalanceHorizTypeScupGaze ?? "";
                    string mBalanceVertScupGaze = diagTest.MbalanceVertScupGaze ?? "";
                    string mBalanceVertTypeScupGaze = diagTest.MbalanceVertTypeScupGaze ?? "";
                    string mBalanceHorizScdownGaze = diagTest.MbalanceHorizScdownGaze ?? "";
                    string mBalanceHorizTypeScdownGaze = diagTest.MbalanceHorizTypeScdownGaze ?? "";
                    string mBalanceVertScdownGaze = diagTest.MbalanceVertScdownGaze ?? "";
                    string mBalanceVertTypeScdownGaze = diagTest.MbalanceVertTypeScdownGaze ?? "";
                    string mBalanceHorizScRtGaze = diagTest.MbalanceHorizScrtGaze ?? "";
                    string mBalanceHorizTypeScRtGaze = diagTest.MbalanceHorizTypeScrtGaze ?? "";
                    string mBalanceVertScRtGaze = diagTest.MbalanceVertScrtGaze ?? "";
                    string mBalanceVertTypeScRtGaze = diagTest.MbalanceVertTypeScrtGaze ?? "";
                    string mBalanceHorizScLtGaze = diagTest.MbalanceHorizScltGaze ?? "";
                    string mBalanceHorizTypeScLtGaze = diagTest.MbalanceHorizTypeScltGaze ?? "";
                    string mBalanceVertScLtGaze = diagTest.MbalanceVertScltGaze ?? "";
                    string mBalanceVertTypeScLtGaze = diagTest.MbalanceVertTypeScltGaze ?? "";

                    short mBalanceCCOrtho = short.TryParse(diagTest.MbalanceCcortho, out short temp3) ? temp3 : (short)-1;
                    string mBalanceHorizCcPriGaze = diagTest.MbalanceHorizCcpriGaze ?? "";
                    string mBalanceHorizTypeCcPriGaze = diagTest.MbalanceHorizTypeCcpriGaze ?? "";
                    string mBalanceVertCcPriGaze = diagTest.MbalanceVertCcpriGaze ?? "";
                    string mBalanceVertTypeCcPriGaze = diagTest.MbalanceVertTypeCcpriGaze ?? "";
                    string mBalanceHorizCcupGaze = diagTest.MbalanceHorizCcupGaze ?? "";
                    string mBalanceHorizTypeCcupGaze = diagTest.MbalanceHorizTypeCcupGaze ?? "";
                    string mBalanceVertCcupGaze = diagTest.MbalanceVertCcupGaze ?? "";
                    string mBalanceVertTypeCcupGaze = diagTest.MbalanceVertTypeCcupGaze ?? "";
                    string mBalanceHorizCcdownGaze = diagTest.MbalanceHorizCcdownGaze ?? "";
                    string mBalanceHorizTypeCcdownGaze = diagTest.MbalanceHorizTypeCcdownGaze ?? "";
                    string mBalanceVertCcdownGaze = diagTest.MbalanceVertCcdownGaze ?? "";
                    string mBalanceVertTypeCcdownGaze = diagTest.MbalanceVertTypeCcdownGaze ?? "";
                    string mBalanceHorizCcRtGaze = diagTest.MbalanceHorizCcrtGaze ?? "";
                    string mBalanceHorizTypeCcRtGaze = diagTest.MbalanceHorizTypeCcrtGaze ?? "";
                    string mBalanceVertCcRtGaze = diagTest.MbalanceVertCcrtGaze ?? "";
                    string mBalanceVertTypeCcRtGaze = diagTest.MbalanceVertTypeCcrtGaze ?? "";
                    string mBalanceHorizCcLtGaze = diagTest.MbalanceHorizCcltGaze ?? "";
                    string mBalanceHorizTypeCcLtGaze = diagTest.MbalanceHorizTypeCcltGaze ?? "";
                    string mBalanceVertCcLtGaze = diagTest.MbalanceVertCcltGaze ?? "";
                    string mBalanceVertTypeCcLtGaze = diagTest.MbalanceVertTypeCcltGaze ?? "";

                    string mBalanceMethod = diagTest.MbalanceMethod ?? "";
                    string gonioPigmentOd = diagTest.GonioPigmentOd ?? "";
                    string gonioPigmentOs = diagTest.GonioPigmentOs ?? "";
                    string mBalanceScType = diagTest.MbalanceSctype ?? "";
                    string mBalanceCcType = diagTest.MbalanceCctype ?? "";
                    string mbalanceHorizScupRtGaze = diagTest.MbalanceHorizScupRtGaze ?? "";
                    string mBalancehorizTypeScupRtGaze = diagTest.MbalanceHorizTypeScupRtGaze ?? "";
                    string mBalanceVertScupRtGaze = diagTest.MbalanceVertScupRtGaze ?? "";
                    string mBalanceVertTypeScupRtGaze = diagTest.MbalanceVertTypeScupRtGaze ?? "";
                    string mBalanceHorizScupLtGaze = diagTest.MbalanceHorizScupLtGaze ?? "";
                    string mBalanceHorizTypeScupLtGaze = diagTest.MbalanceHorizTypeScupLtGaze ?? "";
                    string mBalanceVertScupLtGaze = diagTest.MbalanceVertScupLtGaze ?? "";
                    string mBalanceVertTypeScupLtGaze = diagTest.MbalanceVertTypeScupLtGaze ?? "";
                    string mBalanceHorizScdownRtGaze = diagTest.MbalanceHorizScdownRtGaze ?? "";
                    string mBalanceHorizTypeScdownRtGaze = diagTest.MbalanceHorizTypeScdownRtGaze ?? "";
                    string mBalanceVertScdownRtGaze = diagTest.MbalanceVertScdownRtGaze ?? "";
                    string mBalanceVertTypeScdownRtGaze = diagTest.MbalanceVertTypeScdownRtGaze ?? "";
                    string mBalanceHorizScdownLtGaze = diagTest.MbalanceHorizScdownLtGaze ?? "";
                    string mBalanceHorizTypeScdownLtGaze = diagTest.MbalanceHorizTypeScdownLtGaze ?? "";
                    string mBalanceVertScdownLtGaze = diagTest.MbalanceVertScdownLtGaze ?? "";
                    string mBalanceVertTypeScdownLtGaze = diagTest.MbalanceVertTypeScdownLtGaze ?? "";
                    string mBalanceHorizCcupRtGaze = diagTest.MbalanceHorizCcupRtGaze ?? "";
                    string mBalanceHorizTypeCcupRtGaze = diagTest.MbalanceHorizTypeCcupRtGaze ?? "";
                    string mBalanceVertCcupRtGaze = diagTest.MbalanceVertCcupRtGaze ?? "";
                    string mBalanceVertTypeCcupRtGaze = diagTest.MbalanceVertTypeCcupRtGaze ?? "";
                    string mBalanceHorizCcupLtGaze = diagTest.MbalanceHorizCcupLtGaze ?? "";
                    string mBalanceHorizTypeCcupLtGaze = diagTest.MbalanceHorizTypeCcupLtGaze ?? "";
                    string mBalanceVertCcupLtGaze = diagTest.MbalanceVertCcupLtGaze ?? "";
                    string mBalanceVertTypeCcupLtGaze = diagTest.MbalanceVertTypeCcupLtGaze ?? "";
                    string mBalanceHorizCcdownRtGaze = diagTest.MbalanceHorizCcdownRtGaze ?? "";
                    string mBalanceHorizTypeCcdownRtGaze = diagTest.MbalanceHorizTypeCcdownRtGaze ?? "";
                    string mBalanceVertCcdownRtGaze = diagTest.MbalanceVertCcdownRtGaze ?? "";
                    string mBalanceVertTypeCcdownRtGaze = diagTest.MbalanceVertTypeCcdownRtGaze ?? "";
                    string mBalanceHorizCcdownLtGaze = diagTest.MbalanceHorizCcdownLtGaze ?? "";
                    string mBalanceHorizTypeCcdownLtGaze = diagTest.MbalanceHorizTypeCcdownLtGaze ?? "";
                    string mBalanceVertCcdownLtGaze = diagTest.MbalanceVertCcdownLtGaze ?? "";
                    string mBalanceVertTypeCcdownLtGaze = diagTest.MbalanceVertTypeCcdownLtGaze ?? "";

                    string smotorFixPrefDist = diagTest.SmotorFixPrefDist ?? "";
                    string smotorFixPrefNear = diagTest.SmotorFixPrefNear ?? "";
                    string smotorNystagmus = diagTest.SmotorNystagmus ?? "";
                    string smotorFrisby = diagTest.SmotorFrisby ?? "";
                    string smotorLang = diagTest.SmotorLang ?? "";
                    string smotorTitmusStereoFly = diagTest.SmotorTitmusStereoFly ?? "";
                    string smotorTitmusStereoCircles = diagTest.SmotorTitmusStereoCircles ?? "";
                    string smotorTitmusStereoAnimals = diagTest.SmotorTitmusStereoAnimals ?? "";
                    string smotorRandotCircles = diagTest.SmotorRandotCircles ?? "";
                    string smotorWorth4DotDist = diagTest.SmotorWorth4DotDist ?? "";
                    string smotorWorth4DotNear = diagTest.SmotorWorth4DotNear ?? "";
                    string smotorAvPattern = diagTest.SmotorAvpattern ?? "";
                    string smotorDistStereo = diagTest.SmotorDistStereo ?? "";
                    string smotorDistVectograph = diagTest.SmotorDistVectograph ?? "";
                    string smotorNPC = diagTest.SmotorNpc ?? "";
                    string smotorHorizVergBobreak = diagTest.SmotorHorizVergBobreak ?? "";
                    string smotorHorizVergBorecover = diagTest.SmotorHorizVergBorecover ?? "";
                    string smotorHorizVergBibreak = diagTest.SmotorHorizVergBibreak ?? "";
                    string smotorHorizVergBirecover = diagTest.SmotorHorizVergBirecover ?? "";
                    string smotorVertVergBubreak = diagTest.SmotorVertVergBubreak ?? "";
                    string smotorVertVergBurecover = diagTest.SmotorVertVergBurecover ?? "";
                    string smotorVertVergBdbreak = diagTest.SmotorVertVergBdbreak ?? "";
                    string smotorVertVergBdrecover = diagTest.SmotorVertVergBdrecover ?? "";
                    string smotorDMadRodOd = diagTest.SmotorDmadRodOd ?? "";
                    string smotorDMadRodOs = diagTest.SmotorDmadRodOs ?? "";
                    string smotorDMadRodTorsionOd = diagTest.SmotorDmadRodTorsionOd ?? "";
                    string smotorMadRodTorsionOs = diagTest.SmotorDmadRodTorsionOs ?? "";
                    string smotorColorVisionOd = diagTest.SmotorColorVisionOd ?? "";
                    string smotorColorVisionOs = diagTest.SmotorColorVisionOs ?? "";
                    string smotorColorVisionType = diagTest.SmotorColorVisionType ?? "";

                    short? smotorAbute = short.TryParse(diagTest.SmotorAbute, out short temp4) ? temp4 : (short?)null;
                    string smotorHtrtHorizSc = diagTest.SmotorHtrtHorizSc ?? "";
                    string smotorHtrtHorizTypeSc = diagTest.SmotorHtrtHorizTypeSc ?? "";
                    string smotorHtrtVertSc = diagTest.SmotorHtrtVertSc ?? "";
                    string smotorHtrtVertTypeSc = diagTest.SmotorHtrtVertTypeSc ?? "";
                    string smotorHtltHorizSc = diagTest.SmotorHtltHorizSc ?? "";
                    string smotorHtltHorizTypeSc = diagTest.SmotorHtltHorizTypeSc ?? "";
                    string smotorHtltVertSc = diagTest.SmotorHtltVertSc ?? "";
                    string smotorHtltVertTypeSc = diagTest.SmotorHtltVertTypeSc ?? "";
                    string smotorHtrtHorizCc = diagTest.SmotorHtrtHorizCc ?? "";
                    string smotorHtrtHorizTypeCc = diagTest.SmotorHtrtHorizTypeCc ?? "";
                    string smotorHtrtVertCc = diagTest.SmotorHtrtVertCc ?? "";
                    string smotorHtrtVertTypeCc = diagTest.SmotorHtrtVertTypeCc ?? "";
                    string smotorHtltHorizCc = diagTest.SmotorHtltHorizCc ?? "";
                    string smotorHtltHorizTypeCc = diagTest.SmotorHtltHorizTypeCc ?? "";
                    string smotorHtltVertCc = diagTest.SmotorHtltVertCc ?? "";
                    string smotorHtltVertTypeCc = diagTest.SmotorHtltVertTypeCc ?? "";

                    string smotorHtrtHorizScnear = diagTest.SmotorHtrtHorizSc ?? "";
                    string smotorHtrtHorizTypeScnear = diagTest.SmotorHtrtHorizTypeSc ?? "";
                    string smotorVertScnear = diagTest.SmotorVertScnear ?? "";
                    string smotorVertTypeScnear = diagTest.SmotorVertTypeScnear ?? "";
                    string smotorHorizCcnear = diagTest.SmotorHorizCcnear ?? "";
                    string smotorHorizTypeCcnear = diagTest.SmotorHorizTypeCcnear ?? "";
                    string smotorVertCcnear = diagTest.SmotorVertCcnear ?? "";
                    string smotorVertTypeCcnear = diagTest.SmotorVertTypeCcnear ?? "";
                    string smotorHorizScdist = diagTest.SmotorHorizScdist ?? "";
                    string smotorHorizTypeScdist = diagTest.SmotorHorizTypeScdist ?? "";
                    string smotorVertScdist = diagTest.SmotorVertScdist ?? "";
                    string smotorVertTypeScdist = diagTest.SmotorVertTypeScdist ?? "";
                    string smotorHorizCcdist = diagTest.SmotorHorizCcdist ?? "";
                    string smotorHorizTypeCcdist = diagTest.SmotorHorizTypeCcdist ?? "";
                    string smotorVertCcdist = diagTest.SmotorVertCcdist ?? "";
                    string smotorVertTypeCcdist = diagTest.SmotorVertTypeCcdist ?? "";
                    string mbalanceMethodSc = diagTest.MbalanceMethodSc ?? "";
                    string mbalanceMethodCc = diagTest.MbalanceMethodCc ?? "";
                    string smotorPrismOd = diagTest.SmotorPrismOd ?? "";
                    string smotorPrismOs = diagTest.SmotorPrismOs ?? "";
                    string smotorDirectionOd = diagTest.SmotorDirectionOd ?? "";
                    string smotorDirectionOs = diagTest.SmotorDirectionOs ?? "";
                    string smotorComments = diagTest.SmotorComments ?? "";
                    string mBalanceHorizTypeScupRtGaze = diagTest.MbalanceHorizTypeScupRtGaze ?? "";
                    string smotorHorizCcnear3Plus = diagTest.SmotorHorizCcnear3Plus ?? "";
                    string smotorHorizScnear = diagTest.SmotorHorizScnear ?? "";
                    string smotorHorizTypeScnear = diagTest.SmotorHorizTypeScnear ?? "";
                    string smotorVertCcnear3Plus = diagTest.SmotorVertCcnear3Plus ?? "";
                    string smotorVertTypeCcnear3Plus = diagTest.SmotorVertTypeCcnear3Plus ?? "";
                    #endregion diagTests


                    var ehrOrig = diagTests.FirstOrDefault(dt => dt.PtId == ptId && dt.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newDiagTest = new Brady_s_Conversion_Program.ModelsB.EmrvisitDiagTest {
                            VisitId = visitId,
                            PtId = ptId,
                            Dosdate = dosDate,
                            GonioAngleDepthInOd = TruncateString(gonioAngleDepthInOd, 50),
                            GonioAngleDepthInOs = TruncateString(gonioAngleDepthInOs, 50),
                            GonioAngleDepthMedialOd = TruncateString(gonioAngleDepthMedialOd, 50),
                            GonioAngleDepthMedialOs = TruncateString(gonioAngleDepthMedialOs, 50),
                            GonioAngleDepthSuOd = TruncateString(gonioAngleDepthSuOd, 50),
                            GonioAngleDepthSuOs = TruncateString(gonioAngleDepthSuOs, 50),
                            GonioAngleDepthTemporalOd = TruncateString(gonioAngleDepthTemporalOd, 50),
                            GonioAngleDepthTemporalOs = TruncateString(gonioAngleDepthTemporalOs, 50),
                            GonioAngleStructureInOd = TruncateString(gonioAngleStructureInOd, 50),
                            GonioAngleStructureInOs = TruncateString(gonioAngleStructureInOs, 50),
                            GonioAngleStructureMedialOd = TruncateString(gonioAngleStructureMedialOd, 50),
                            GonioAngleStructureMedialOs = TruncateString(gonioAngleStructureMedialOs, 50),
                            GonioAngleStructureSuOd = TruncateString(gonioAngleStructureSuOd, 50),
                            GonioAngleStructureSuOs = TruncateString(gonioAngleStructureSuOs, 50),
                            GonioAngleStructureTemporalOd = TruncateString(gonioAngleStructureTemporalOd, 50),
                            GonioAngleStructureTemporalOs = TruncateString(gonioAngleStructureTemporalOs, 50),
                            GonioComments = TruncateString(gonioComments, int.MaxValue),
                            GonioPigmentOd = TruncateString(gonioPigmentOd, 255),
                            GonioPigmentOs = TruncateString(gonioPigmentOs, 255),
                            // Continue mapping all other properties as needed
                        };
                        diagTests.Add(newDiagTest);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the diag test with ID: {diagTest.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.EmrvisitDiagTests.UpdateRange(diagTests);
            eyeMDDbContext.SaveChanges();
            diagTests = eyeMDDbContext.EmrvisitDiagTests.ToList();
        }

        public static void ExamConditionsConvert(List<ModelsC.ExamCondition> ehrExamConditions, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<Visit> ehrVisits, List<Emrvisit> visits, List<Emrpatient> eyeMDPatients, List<EmrvisitExamCondition> examConditions, List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients) {
            foreach (var examCondition in ehrExamConditions) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    int? visitId = null;
                    int ptId = -1;
                    DmgPatient? ffpmPatient = null;
                    Emrvisit? EyeMDVisit = null;
                    Emrpatient? eyeMDPatient = null;
                    if (examCondition.PtId > 0) {
                        ptId = examCondition.PtId;
                        ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == ptId.ToString());
                        if (ffpmPatient == null) {
                            if (examCondition.VisitId > 0) {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == examCondition.VisitId);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for examCondition with ID: {examCondition.Id}");
                                    continue;
                                }
                                else {
                                    if (EyeMDVisit.PtId != null) {
                                        ptId = (int)EyeMDVisit.PtId;
                                        eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                        if (eyeMDPatient == null) {
                                            logger.Log($"EHR: EyeMD Patient not found for examCondition with ID: {examCondition.Id}");
                                            continue;
                                        }
                                        else {
                                            visitId = EyeMDVisit.VisitId;
                                        }
                                    }
                                    else {
                                        logger.Log($"EHR: EyeMD Patient not found for examCondition with ID: {examCondition.Id}");
                                        continue;
                                    }
                                }
                            }
                            else {
                                logger.Log($"EHR: FFPM Patient not found for examCondition with ID: {examCondition.Id}");
                                continue;
                            }
                        }
                        else if (eyeMDPatient == null) {
                            ptId = (int)ffpmPatient.PatientId;
                            EyeMDVisit = visits.FirstOrDefault(v => v.PtId == ptId);
                            if (EyeMDVisit == null) {
                                visitId = null;
                            }
                        }
                    }
                    else if (examCondition.VisitId > 0) {
                        visitId = examCondition.VisitId;
                        EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
                        if (EyeMDVisit == null) {
                            logger.Log($"EHR: EyeMD visit and patient not found for examCondition with ID: {examCondition.Id}");
                            continue;
                        }
                        else {
                            if (EyeMDVisit.PtId != null) {
                                ptId = (int)EyeMDVisit.PtId;
                                eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                if (eyeMDPatient == null) {
                                    logger.Log($"EHR: EyeMD Patient not found for examCondition with ID: {examCondition.Id}");
                                    continue;
                                }
                            }
                            else {
                                logger.Log($"EHR: EyeMD Patient not found for examCondition with ID: {examCondition.Id}");
                                continue;
                            }
                        }
                    }

                    DateTime dosDate = minAcceptableDate;
                    if (examCondition.Dosdate != null) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(examCondition.Dosdate, dateFormats,
                                                   CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            dosDate = tempDateTime;
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
                        }
                        else if (examCondition.Eye == "L") {
                            eye = "OS";
                        }
                        else {
                            eye = examCondition.Eye;
                        }
                    }

                    var ehrOrig = examConditions.FirstOrDefault(ec => ec.PtId == ptId && ec.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newExamCondition = new Brady_s_Conversion_Program.ModelsB.EmrvisitExamCondition {
                            Snomed = null,
                            PtId = ptId,
                            VisitId = visitId,
                            Dosdate = dosDate,
                            Comment = TruncateString(examCondition.Comment, int.MaxValue),
                            Condition = TruncateString(condition, int.MaxValue),
                            Laterality = TruncateString(eye, 10),
                            ConditionId = conditionId,
                            LocationId = locationId
                        };
                        examConditions.Add(newExamCondition);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the exam condition with ID: {examCondition.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.EmrvisitExamConditions.UpdateRange(examConditions);
            eyeMDDbContext.SaveChanges();
            examConditions = eyeMDDbContext.EmrvisitExamConditions.ToList();
        }

        public static void FamilyHistoriesConvert(List<ModelsC.FamilyHistory> ehrFamilyHistories, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<Visit> ehrVisits, List<Emrvisit> visits, List<Emrpatient> eyeMDPatients, List<EmrvisitFamilyHistory> familyHistories, List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients) {
            foreach (var familyHistory in ehrFamilyHistories) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
					int? visitId = null;
					int? ptId = null;
					DmgPatient? ffpmPatient = null;
					Emrvisit? EyeMDVisit = null;
					Emrpatient? eyeMDPatient = null;
					if (familyHistory.PtId > 0) {
						ptId = familyHistory.PtId;
						var convPatient = convPatients.FirstOrDefault(p => p.Id == ptId);
						if (convPatient == null) {
                            var ehrVisit = ehrVisits.FirstOrDefault(v => v.OldVisitId == visitId.ToString());
                            if (ehrVisit == null) {
                                logger.Log($"EHR: EHR Visit and Patient not found for familyHistory (1) with ID: {familyHistory.Id}");
                                continue;
                            }
                            else {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == ehrVisit.Id);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for familyHistory with ID: {familyHistory.Id}");
                                    continue;
                                }
                                else {
                                    ptId = EyeMDVisit.PtId;
                                    eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                    if (eyeMDPatient == null) {
                                        logger.Log($"EHR: EyeMD Patient not found for familyHistory with ID: {familyHistory.Id}");
                                        continue;
                                    }
                                    else {
                                        visitId = EyeMDVisit.VisitId;
                                        continue;
                                    }
                                }
                            }
                        }
						ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber && (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
						if (ffpmPatient == null) {
							if (familyHistory.VisitId > 0) {
								EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == familyHistory.VisitId);
								if (EyeMDVisit == null) {
									logger.Log($"EHR: EyeMD visit and FFPM patient not found for familyHistory with ID: {familyHistory.Id}");
									continue;
								}
								else {
									ptId = EyeMDVisit.PtId;
									eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
									if (eyeMDPatient == null) {
										logger.Log($"EHR: EyeMD Patient not found for familyHistory with ID: {familyHistory.Id}");
										continue;
									}
									else {
										visitId = EyeMDVisit.VisitId;
									}
								}
							}
							else {
								logger.Log($"EHR: FFPM Patient not found for familyHistory with ID: {familyHistory.Id}");
								continue;
							}
						}
						else {
							eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ffpmPatient.PatientId);
							if (eyeMDPatient == null) {
								ptId = null;
							}
							if (familyHistory.VisitId > 0) {
								var ehrVisit = ehrVisits.FirstOrDefault(v => v.Id == familyHistory.VisitId);
								if (ehrVisit == null) {
									logger.Log($"EHR: EHR Visit and Patient not found for familyHistory (2) with ID: {familyHistory.Id}");
									continue;
								}
								else {
									visitId = ehrVisit.Id;
									ptId = ehrVisit.PtId;
								}
							}
                        }
                    }
                    else if (familyHistory.VisitId > 0) {
							visitId = familyHistory.VisitId;
							EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
							if (EyeMDVisit == null) {
								logger.Log($"EHR: EyeMD visit and patient not found for familyHistory with ID: {familyHistory.Id}");
								continue;
							}
							else {
								ptId = EyeMDVisit.PtId;
								eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
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

                    var ehrOrig = familyHistories.FirstOrDefault(fh => fh.PtId == ptId && fh.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newFamilyHistory = new Brady_s_Conversion_Program.ModelsB.EmrvisitFamilyHistory {
                            PtId = ptId,
                            VisitId = visitId,
                            Dosdate = dosDate,
                            Description = TruncateString(description, 255),
                            Relation = TruncateString(relation, 50),
                            Comments = TruncateString(comments, int.MaxValue),
                            Age = TruncateString(age, 50),
                            Status = TruncateString(status, 50),
                            Code = TruncateString(code, 50),
                            CodeIcd10 = TruncateString(codeIcd10, 50),
                            CodeSnomed = TruncateString(codeSnomed, 50)
                        };
                        familyHistories.Add(newFamilyHistory);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the family history with ID: {familyHistory.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.EmrvisitFamilyHistories.UpdateRange(familyHistories);
            eyeMDDbContext.SaveChanges();
            familyHistories = eyeMDDbContext.EmrvisitFamilyHistories.ToList();
        }

        public static void IopsConvert(List<ModelsC.Iop> ehrIops, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<Visit> ehrVisits, List<Emrvisit> visits, List<Emrpatient> eyeMDPatients, List<EmrvisitIop> iops, List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients) {
            foreach (var iop in ehrIops) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
					int? visitId = null;
					int? ptId = null;
					DmgPatient? ffpmPatient = null;
					Emrvisit? EyeMDVisit = null;
					Emrpatient? eyeMDPatient = null;
					if (iop.PtId > 0) {
						ptId = iop.PtId;
						var convPatient = convPatients.FirstOrDefault(p => p.Id == ptId);
						if (convPatient == null) {
                            var ehrVisit = ehrVisits.FirstOrDefault(v => v.OldVisitId == visitId.ToString());
                            if (ehrVisit == null) {
                                logger.Log($"EHR: EHR Visit and Patient not found for iop (1) with ID: {iop.Id}");
                                continue;
                            }
                            else {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == ehrVisit.Id);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for iop with ID: {iop.Id}");
                                    continue;
                                }
                                else {
                                    ptId = EyeMDVisit.PtId;
                                    eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                    if (eyeMDPatient == null) {
                                        logger.Log($"EHR: EyeMD Patient not found for iop with ID: {iop.Id}");
                                        continue;
                                    }
                                    else {
                                        visitId = EyeMDVisit.VisitId;
                                        continue;
                                    }
                                }
                            }
                        }
						ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber && (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
						if (ffpmPatient == null) {
							if (iop.VisitId > 0) {
								EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == iop.VisitId);
								if (EyeMDVisit == null) {
									logger.Log($"EHR: EyeMD visit and FFPM patient not found for iop with ID: {iop.Id}");
									continue;
								}
								else {
									ptId = EyeMDVisit.PtId;
									eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
									if (eyeMDPatient == null) {
										logger.Log($"EHR: EyeMD Patient not found for iop with ID: {iop.Id}");
										continue;
									}
									else {
										visitId = EyeMDVisit.VisitId;
									}
								}
							}
							else {
								logger.Log($"EHR: FFPM Patient not found for iop with ID: {iop.Id}");
								continue;
							}
						}
						else {
							eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ffpmPatient.PatientId);
							if (eyeMDPatient == null) {
								ptId = null;
							}
							if (iop.VisitId > 0) {
								var ehrVisit = ehrVisits.FirstOrDefault(v => v.Id == iop.VisitId);
								if (ehrVisit == null) {
									logger.Log($"EHR: EHR Visit and Patient not found for iop (2) with ID: {iop.Id}");
									continue;
								}
								else {
									visitId = ehrVisit.Id;
									ptId = ehrVisit.PtId;
								}
							}
                        }
                    }
                    else if (iop.VisitId > 0) {
							visitId = iop.VisitId;
							EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
							if (EyeMDVisit == null) {
								logger.Log($"EHR: EyeMD visit and patient not found for iop with ID: {iop.Id}");
								continue;
							}
							else {
								ptId = EyeMDVisit.PtId;
								eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
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
                    if (iop.Iopod != null) {
                        iopOd = iop.Iopod;
                    }
                    string iopOs = "";
                    if (iop.Iopos != null) {
                        iopOs = iop.Iopos;
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
                    if (iop.Iopccod != null) {
                        iopCcOd = iop.Iopccod;
                    }
                    string iopCcOs = "";
                    if (iop.Iopccos != null) {
                        iopCcOs = iop.Iopccos;
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

                    var ehrOrig = iops.FirstOrDefault(i => i.PtId == ptId && i.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newIop = new Brady_s_Conversion_Program.ModelsB.EmrvisitIop {
                            PtId = ptId,
                            VisitId = visitId,
                            Dosdate = dosDate,
                            IopOd = TruncateString(iopOd, 50),
                            IopOs = TruncateString(iopOs, 50),
                            IopdeviceUsed = TruncateString(iopDeviceUsed, 50),
                            IoptimeTaken = iopTimeTaken, // datetime, no truncation needed
                            Iopnotes = TruncateString(iopNotes, int.MaxValue),
                            IopccOd = TruncateString(iopCcOd, 50),
                            IopccOs = TruncateString(iopCcOs, 50),
                            CornealHysteresisOd = cornealHysteresisOd, // decimal, no truncation needed
                            CornealHysteresisOs = cornealHysteresisOs // decimal, no truncation needed
                        };
                        iops.Add(newIop);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the iop with ID: {iop.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.EmrvisitIops.UpdateRange(iops);
            eyeMDDbContext.SaveChanges();
            iops = eyeMDDbContext.EmrvisitIops.ToList();
        }

        public static void PatientDocumentsConvert(ModelsC.PatientDocument patientDocument, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress) {
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
            }
            catch (Exception e) {
                logger.Log($"EHR: EHR An error occurred while converting the patient document with ID: {patientDocument.Id}. Error: {e.Message}");
            }
        }

        public static void PatientNotesConvert(List<ModelsC.PatientNote> ehrPatientNotes, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<EmrptNote> patientNotes, List<Visit> ehrVisits, List<Emrvisit> visits, List<Emrpatient> eyeMDPatients, List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients) {
            foreach (var patientNote in ehrPatientNotes) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try { // assuming this is also spare, but will give it conversion functionality since it is small and easy, save for guid
					int? visitId = null;
					int? ptId = null;
					DmgPatient? ffpmPatient = null;
					Emrvisit? EyeMDVisit = null;
					Emrpatient? eyeMDPatient = null;
                    if (patientNote.PtId > 0) {
                        ptId = patientNote.PtId;
                        var convPatient = convPatients.FirstOrDefault(p => p.Id == ptId);
                        if (convPatient == null) {
                            var ehrVisit = ehrVisits.FirstOrDefault(v => v.OldVisitId == visitId.ToString());
                            if (ehrVisit == null) {
                                logger.Log($"EHR: EHR Visit and Patient not found for patientNote (1) with ID: {patientNote.Id}");
                                continue;
                            }
                            else {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == ehrVisit.Id);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for patientNote with ID: {patientNote.Id}");
                                    continue;
                                }
                                else {
                                    ptId = EyeMDVisit.PtId;
                                    eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                    if (eyeMDPatient == null) {
                                        logger.Log($"EHR: EyeMD Patient not found for patientNote with ID: {patientNote.Id}");
                                        continue;
                                    }
                                    else {
                                        visitId = EyeMDVisit.VisitId;
                                        continue;
                                    }
                                }
                            }
                        }
                        ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber && (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
                        if (ffpmPatient == null) {
                            if (patientNote.VisitId > 0) {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == patientNote.VisitId);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for patientNote with ID: {patientNote.Id}");
                                    continue;
                                }
                                else {
                                    ptId = EyeMDVisit.PtId;
                                    eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                    if (eyeMDPatient == null) {
                                        logger.Log($"EHR: EyeMD Patient not found for patientNote with ID: {patientNote.Id}");
                                        continue;
                                    }
                                    else {
                                        visitId = EyeMDVisit.VisitId;
                                    }
                                }
                            }
                            else {
                                logger.Log($"EHR: FFPM Patient not found for patientNote with ID: {patientNote.Id}");
                                continue;
                            }
                        }
                        else {
                            eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ffpmPatient.PatientId);
                            if (eyeMDPatient == null) {
                                ptId = null;
                            }
                            if (patientNote.VisitId > 0) {
                                var ehrVisit = ehrVisits.FirstOrDefault(v => v.Id == patientNote.VisitId);
                                if (ehrVisit == null) {
                                    logger.Log($"EHR: EHR Visit and Patient not found for patientNote (1) with ID: {patientNote.Id}");
                                    continue;
                                }
                                else {
                                    visitId = ehrVisit.Id;
                                    ptId = ehrVisit.PtId;
                                }
                            }
                        }
                    }
                    else if (patientNote.VisitId > 0) {
                        visitId = patientNote.VisitId;
                        EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
                        if (EyeMDVisit == null) {
                            logger.Log($"EHR: EyeMD visit and patient not found for patientNote with ID: {patientNote.Id}");
                            continue;
                        }
                        else {
                            ptId = EyeMDVisit.PtId;
                            eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
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

                    var ehrOrig = patientNotes.FirstOrDefault(pn => pn.PtId == ptId);

                    if (ehrOrig == null) {
                        var newPatientNote = new Brady_s_Conversion_Program.ModelsB.EmrptNote {
                            PtId = ptId,
                            Notes = TruncateString(notes, int.MaxValue),
                            CreatedDate = createdDate,
                            EmpId = empId,
                            ShowInVisitSummary = showInVisitSummary, // smallint, no truncation needed
                            InsertGuid = TruncateString(guid, 50)
                        };
                        patientNotes.Add(newPatientNote);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the patient note with ID: {patientNote.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.EmrptNotes.UpdateRange(patientNotes);
            eyeMDDbContext.SaveChanges();
            patientNotes = eyeMDDbContext.EmrptNotes.ToList();
        }

        public static void PlanNarrativesConvert(List<ModelsC.PlanNarrative> ehrPlanNarratives, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<Visit> ehrVisits, List<Emrvisit> visits, List<Emrpatient> eyeMDPatients, List<EmrvisitPlanNarrative> planNarratives, List<DmgPatient> ffpmPatients,
                List<Models.Patient> convPatients) {
            foreach (var planNarrative in ehrPlanNarratives) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    int? visitId = null;
                    int ptId = -1;
                    DmgPatient? ffpmPatient = null;
                    Emrvisit? EyeMDVisit = null;
                    Emrpatient? eyeMDPatient = null;
                    if (planNarrative.PtId > 0) {
                        ptId = planNarrative.PtId;
                        ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == ptId.ToString());
                        if (ffpmPatient == null) {
                            if (planNarrative.VisitId > 0) {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == planNarrative.VisitId);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for planNarrative with ID: {planNarrative.Id}");
                                    continue;
                                }
                                else {
                                    if (EyeMDVisit.PtId != null) {
                                        ptId = (int)EyeMDVisit.PtId;
                                        eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                        if (eyeMDPatient == null) {
                                            logger.Log($"EHR: EyeMD Patient not found for planNarrative with ID: {planNarrative.Id}");
                                            continue;
                                        }
                                        else {
                                            visitId = EyeMDVisit.VisitId;
                                        }
                                    }
                                    else {
                                        logger.Log($"EHR: EyeMD Patient not found for planNarrative with ID: {planNarrative.Id}");
                                        continue;
                                    }
                                }
                            }
                            else {
                                logger.Log($"EHR: FFPM Patient not found for planNarrative with ID: {planNarrative.Id}");
                                continue;
                            }
                        }
                        else if (eyeMDPatient == null) {
                            ptId = (int)ffpmPatient.PatientId;
                            EyeMDVisit = visits.FirstOrDefault(v => v.PtId == ptId);
                            if (EyeMDVisit == null) {
                                visitId = null;
                            }
                        }
                    }
                    else if (planNarrative.VisitId > 0) {
                        visitId = planNarrative.VisitId;
                        EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
                        if (EyeMDVisit == null) {
                            logger.Log($"EHR: EyeMD visit and patient not found for planNarrative with ID: {planNarrative.Id}");
                            continue;
                        }
                        else {
                            if (EyeMDVisit.PtId != null) {
                                ptId = (int)EyeMDVisit.PtId;
                                eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                if (eyeMDPatient == null) {
                                    logger.Log($"EHR: EyeMD Patient not found for planNarrative with ID: {planNarrative.Id}");
                                    continue;
                                }
                            }
                            else {
                                logger.Log($"EHR: EyeMD Patient not found for planNarrative with ID: {planNarrative.Id}");
                                continue;
                            }
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

                    var ehrOrig = planNarratives.FirstOrDefault(n => n.PtId == ptId && n.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newPlanNarrative = new Brady_s_Conversion_Program.ModelsB.EmrvisitPlanNarrative {
                            PtId = ptId,
                            VisitId = visitId,
                            Dosdate = dosDate,
                            VisitDoctorId = visitDoctorId,
                            Snomedcode = TruncateString(snomedCode, 50),
                            VisitDiagCodePoolId = visitDiagCodePoolId,
                            Icd10code = TruncateString(ICD10Code, 50),
                            Icd9code = TruncateString(ICD9Code, 50),
                            NarrativeHeader = TruncateString(narrativeHeader, 255),
                            NarrativeText = TruncateString(narrativeText, int.MaxValue),
                            NarrativeType = TruncateString(narrativeType, 50),
                            DisplayOrder = displayOrder,
                            InsertGuid = TruncateString(insertGUID, 50)
                        };
                        planNarratives.Add(newPlanNarrative);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the plan narrative with ID: {planNarrative.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.EmrvisitPlanNarratives.UpdateRange(planNarratives);
            eyeMDDbContext.SaveChanges();
            planNarratives = eyeMDDbContext.EmrvisitPlanNarratives.ToList();
        }

        public static void ProcDiagPoolsConvert(List<ModelsC.ProcDiagPool> ehrProcDiagPools, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<Visit> ehrVisits, List<Emrvisit> visits, List<EmrvisitProcCodePoolDiag> procDiagPools, List<DmgPatient> ffpmPatients, List<Emrpatient> eyeMDPatients, List<Models.Patient> convPatients) {
            foreach (var procDiagPool in ehrProcDiagPools) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
					int? visitId = null;
					int? ptId = null;
					DmgPatient? ffpmPatient = null;
					Emrvisit? EyeMDVisit = null;
					Emrpatient? eyeMDPatient = null;
					if (procDiagPool.PtId > 0) {
						ptId = procDiagPool.PtId;
						var convPatient = convPatients.FirstOrDefault(p => p.Id == ptId);
						if (convPatient == null) {
                            var ehrVisit = ehrVisits.FirstOrDefault(v => v.OldVisitId == visitId.ToString());
                            if (ehrVisit == null) {
                                logger.Log($"EHR: EHR Visit and Patient not found for procDiagPool (1) with ID: {procDiagPool.Id}");
                                continue;
                            }
                            else {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == ehrVisit.Id);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for procDiagPool with ID: {procDiagPool.Id}");
                                    continue;
                                }
                                else {
                                    ptId = EyeMDVisit.PtId;
                                    eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                    if (eyeMDPatient == null) {
                                        logger.Log($"EHR: EyeMD Patient not found for procDiagPool with ID: {procDiagPool.Id}");
                                        continue;
                                    }
                                    else {
                                        visitId = EyeMDVisit.VisitId;
                                        continue;
                                    }
                                }
                            }
                        }
						ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber && (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
						if (ffpmPatient == null) {
							if (procDiagPool.VisitId > 0) {
								EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == procDiagPool.VisitId);
								if (EyeMDVisit == null) {
									logger.Log($"EHR: EyeMD visit and FFPM patient not found for procDiagPool with ID: {procDiagPool.Id}");
									continue;
								}
								else {
									ptId = EyeMDVisit.PtId;
									eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
									if (eyeMDPatient == null) {
										logger.Log($"EHR: EyeMD Patient not found for procDiagPool with ID: {procDiagPool.Id}");
										continue;
									}
									else {
										visitId = EyeMDVisit.VisitId;
									}
								}
							}
							else {
								logger.Log($"EHR: FFPM Patient not found for procDiagPool with ID: {procDiagPool.Id}");
								continue;
							}
						}
						else {
							eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ffpmPatient.PatientId);
							if (eyeMDPatient == null) {
								ptId = null;
							}
							if (procDiagPool.VisitId > 0) {
								var ehrVisit = ehrVisits.FirstOrDefault(v => v.Id == procDiagPool.VisitId);
								if (ehrVisit == null) {
									logger.Log($"EHR: EHR Visit and Patient not found for procDiagPool (1) with ID: {procDiagPool.Id}");
									continue;
								}
								else {
									visitId = ehrVisit.Id;
									ptId = ehrVisit.PtId;
								}
							}
                        }
                    }
                    else if (procDiagPool.VisitId > 0) {
							visitId = procDiagPool.VisitId;
							EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
							if (EyeMDVisit == null) {
								logger.Log($"EHR: EyeMD visit and patient not found for procDiagPool with ID: {procDiagPool.Id}");
								continue;
							}
							else {
								ptId = EyeMDVisit.PtId;
								eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
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
                    int? visitprocDiagPoolId = null;
                    if (procDiagPool.VisitDiagCodePoolId != null) {
                        if (int.TryParse(procDiagPool.VisitDiagCodePoolId, out int locum)) {
                            visitprocDiagPoolId = locum;
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

                    var ehrOrig = procDiagPools.FirstOrDefault(pcp => pcp.PtId == ptId && pcp.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newProcDiagPool = new Brady_s_Conversion_Program.ModelsB.EmrvisitProcCodePoolDiag {
                            PtId = ptId,
                            VisitId = visitId,
                            Dosdate = dosDate,
                            ControlId = controlId,
                            VisitProcCodePoolId = visitProcCodePoolId,
                            VisitDiagCodePoolId = visitprocDiagPoolId,
                            RequestedProcedureId = requestedProcId,
                            InsertGuid = TruncateString(insertGUID, 50)
                        };
                        procDiagPools.Add(newProcDiagPool);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the proc diag pool with ID: {procDiagPool.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.EmrvisitProcCodePoolDiags.UpdateRange(procDiagPools);
            eyeMDDbContext.SaveChanges();
            procDiagPools = eyeMDDbContext.EmrvisitProcCodePoolDiags.ToList();
        }

        public static void ProcPoolsConvert(List<ModelsC.ProcPool> ehrProcPools, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<Visit> ehrVisits, List<Emrvisit> visits, List<EmrvisitProcCodePool> procCodePools, List<Emrpatient> eyeMDPatients, List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients) {
            foreach (var procPool in ehrProcPools) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
					int? visitId = null;
					int? ptId = null;
					DmgPatient? ffpmPatient = null;
					Emrvisit? EyeMDVisit = null;
					Emrpatient? eyeMDPatient = null;
					if (procPool.PtId > 0) {
						ptId = procPool.PtId;
						var convPatient = convPatients.FirstOrDefault(p => p.Id == ptId);
						if (convPatient == null) {
                            var ehrVisit = ehrVisits.FirstOrDefault(v => v.OldVisitId == visitId.ToString());
                            if (ehrVisit == null) {
                                logger.Log($"EHR: EHR Visit and Patient not found for procPool (1) with ID: {procPool.Id}");
                                continue;
                            }
                            else {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == ehrVisit.Id);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for procPool with ID: {procPool.Id}");
                                    continue;
                                }
                                else {
                                    ptId = EyeMDVisit.PtId;
                                    eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                    if (eyeMDPatient == null) {
                                        logger.Log($"EHR: EyeMD Patient not found for procPool with ID: {procPool.Id}");
                                        continue;
                                    }
                                    else {
                                        visitId = EyeMDVisit.VisitId;
                                        continue;
                                    }
                                }
                            }
                        }
						ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == convPatient.OldPatientAccountNumber && (p.FirstName == convPatient.FirstName && p.LastName == convPatient.LastName && p.MiddleName == convPatient.MiddleName));
						if (ffpmPatient == null) {
							if (procPool.VisitId > 0) {
								EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == procPool.VisitId);
								if (EyeMDVisit == null) {
									logger.Log($"EHR: EyeMD visit and FFPM patient not found for procPool with ID: {procPool.Id}");
									continue;
								}
								else {
									ptId = EyeMDVisit.PtId;
									eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
									if (eyeMDPatient == null) {
										logger.Log($"EHR: EyeMD Patient not found for procPool with ID: {procPool.Id}");
										continue;
									}
									else {
										visitId = EyeMDVisit.VisitId;
									}
								}
							}
							else {
								logger.Log($"EHR: FFPM Patient not found for procPool with ID: {procPool.Id}");
								continue;
							}
						}
						else {
							eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ffpmPatient.PatientId);
							if (eyeMDPatient == null) {
								ptId = null;
							}
							if (procPool.VisitId > 0) {
								var ehrVisit = ehrVisits.FirstOrDefault(v => v.Id == procPool.VisitId);
								if (ehrVisit == null) {
									logger.Log($"EHR: EHR Visit and Patient not found for procPool (2) with ID: {procPool.Id}");
									continue;
								}
								else {
									visitId = ehrVisit.Id;
									ptId = ehrVisit.PtId;
								}
							}
                        }
                    }
                    else if (procPool.VisitId > 0) {
						visitId = procPool.VisitId;
						EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
						if (EyeMDVisit == null) {
							logger.Log($"EHR: EyeMD visit and patient not found for procPool with ID: {procPool.Id}");
							continue;
						}
						else {
							ptId = EyeMDVisit.PtId;
							eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
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

                    var ehrOrig = procCodePools.FirstOrDefault(pc => pc.PtId == ptId && pc.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newProcPool = new Brady_s_Conversion_Program.ModelsB.EmrvisitProcCodePool {
                            Qrcomponent = TruncateString(qrComponent, 50),
                            PtId = ptId,
                            VisitId = visitId,
                            Dosdate = dosDate,
                            ControlId = controlId,
                            ProcText = TruncateString(procText, 255),
                            Code = TruncateString(code, 50),
                            Modifier = TruncateString(modifier, 50),
                            OriginalModifier = TruncateString(originalModifier, 50),
                            Location = TruncateString(location, 50),
                            SourceField = TruncateString(sourceField, 50),
                            IsBilled = isBilled, // smallint, no truncation needed
                            ProcLocationType = procLocationType,
                            ProcDiagTestComponents = procDiagTestComponents, // smallint, no truncation needed
                            NotPorelated = notPoRelated, // smallint, no truncation needed
                            ProcType = procType,
                            BillMultiProcId = billMultiProcId,
                            BillMultiProcControlId = billMultiProcControlId,
                            AdditionalModifier = TruncateString(additionalModifier, 50),
                            IsQr = isQr, // smallint, no truncation needed
                            EyeMdqrnum = TruncateString(eyeMDQRNum, 50),
                            Pqrsnum = TruncateString(pqrsNum, 50),
                            Nqfnum = TruncateString(nqfNum, 50),
                            Numerator = numerator,
                            Denominator = denominator,
                            IsHidden = isHidden, // smallint, no truncation needed
                            InsertGuid = TruncateString(insertGUID, 50),
                            Units = units,
                            RequestedProcedureId = requestedProcedureId,
                            SentInVisit = sentInVisit, // smallint, no truncation needed
                            SourceRecordId = sourceRecordId,
                            InitialPatientPopulation = initialPatientPopulation,
                            DenominatorExclusion = denominatorExclusion,
                            DenominatorException = denominatorException,
                            BillingOrder = billingOrder
                        };
                        procCodePools.Add(newProcPool);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the proc pool with ID: {procPool.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.EmrvisitProcCodePools.UpdateRange(procCodePools);
            eyeMDDbContext.SaveChanges();
            procCodePools = eyeMDDbContext.EmrvisitProcCodePools.ToList();
        }

        public static void RefractionsConvert(List<ModelsC.Refraction> ehrRefractions, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<Visit> ehrVisits, List<Emrvisit> visits, List<Emrpatient> eyeMDPatients, List<EmrvisitRefraction> refractions, List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients) {
            foreach (var refraction in ehrRefractions) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    int? visitId = null;
                    int ptId = -1;
                    DmgPatient? ffpmPatient = null;
                    Emrvisit? EyeMDVisit = null;
                    Emrpatient? eyeMDPatient = null;
                    if (refraction.PtId > 0) {
                        ptId = refraction.PtId;
                        ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == ptId.ToString());
                        if (ffpmPatient == null) {
                            if (refraction.VisitId > 0) {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == refraction.VisitId);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for refraction with ID: {refraction.Id}");
                                    continue;
                                }
                                else {
                                    if (EyeMDVisit.PtId != null) {
                                        ptId = (int)EyeMDVisit.PtId;
                                        eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                        if (eyeMDPatient == null) {
                                            logger.Log($"EHR: EyeMD Patient not found for refraction with ID: {refraction.Id}");
                                            continue;
                                        }
                                        else {
                                            visitId = EyeMDVisit.VisitId;
                                        }
                                    }
                                    else {
                                        logger.Log($"EHR: EyeMD Patient not found for refraction with ID: {refraction.Id}");
                                        continue;
                                    }
                                }
                            }
                            else {
                                logger.Log($"EHR: FFPM Patient not found for refraction with ID: {refraction.Id}");
                                continue;
                            }
                        }
                        else if (eyeMDPatient == null) {
                            ptId = (int)ffpmPatient.PatientId;
                            EyeMDVisit = visits.FirstOrDefault(v => v.PtId == ptId);
                            if (EyeMDVisit == null) {
                                visitId = null;
                            }
                        }
                    }
                    else if (refraction.VisitId > 0) {
                        visitId = refraction.VisitId;
                        EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
                        if (EyeMDVisit == null) {
                            logger.Log($"EHR: EyeMD visit and patient not found for refraction with ID: {refraction.Id}");
                            continue;
                        }
                        else {
                            if (EyeMDVisit.PtId != null) {
                                ptId = (int)EyeMDVisit.PtId;
                                eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                if (eyeMDPatient == null) {
                                    logger.Log($"EHR: EyeMD Patient not found for refraction with ID: {refraction.Id}");
                                    continue;
                                }
                            }
                            else {
                                logger.Log($"EHR: EyeMD Patient not found for refraction with ID: {refraction.Id}");
                                continue;
                            }
                        }
                    }

                    DateTime dosDate = minAcceptableDate;
                    if (refraction.Dosdate != null) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(refraction.Dosdate, dateFormats,
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
                    string prism360Od = "";
                    if (refraction.Prism360Od != null) {
                        prism360Od = refraction.Prism360Od;
                    }
                    string prism360Os = "";
                    if (refraction.Prism360Os != null) {
                        prism360Os = refraction.Prism360Os;
                    }
                    string directionHod = "";
                    if (refraction.DirectionHod != null) {
                        directionHod = refraction.DirectionHod;
                    }
                    string directionHos = "";
                    if (refraction.DirectionHos != null) {
                        directionHos = refraction.DirectionHos;
                    }
                    string pdDistOd = "";
                    if (refraction.PddistOd != null) {
                        pdDistOd = refraction.PddistOd;
                    }
                    string pdDistOs = "";
                    if (refraction.PddistOs != null) {
                        pdDistOs = refraction.PddistOs;
                    }
                    string pdNearOd = "";
                    if (refraction.PdnearOd != null) {
                        pdNearOd = refraction.PdnearOd;
                    }
                    string pdNearOs = "";
                    if (refraction.PdnearOs != null) {
                        pdNearOs = refraction.PdnearOs;
                    }
                    string age = "";
                    if (refraction.Age != null) {
                        age = refraction.Age;
                    }
                    string? vaDOd = "";
                    if (refraction.VaDos != null) {
                        vaDOd = refraction.VaDod;
                    }
                    string vaDOs = "";
                    if (refraction.VaDos != null) {
                        vaDOs = refraction.VaDos;
                    }
                    string vaDOu = "";
                    if (refraction.VaDou != null) {
                        vaDOu = refraction.VaDou;
                    }
                    string vaNOd = "";
                    if (refraction.VaNod != null) {
                        vaNOd = refraction.VaNod;
                    }
                    string vaNOs = "";
                    if (refraction.VaNos != null) {
                        vaNOs = refraction.VaNos;
                    }
                    string vaNOu = "";
                    if (refraction.VaNou != null) {
                        vaNOu = refraction.VaNou;
                    }
                    string vaIOd = "";
                    if (refraction.VaIod != null) {
                        vaIOd = refraction.VaIod;
                    }
                    string vaIOs = "";
                    if (refraction.VaIos != null) {
                        vaIOs = refraction.VaIos;
                    }
                    string vaIOu = "";
                    if (refraction.VaIou != null) {
                        vaIOu = refraction.VaIou;
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
                    string prismTypeOd = "";
                    // no prismTypeOd in source table
                    string prismTypeOs = "";
                    // no prismTypeOs in source table

                    var ehrOrig = refractions.FirstOrDefault(r => r.PtId == ptId && r.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newRefraction = new Brady_s_Conversion_Program.ModelsB.EmrvisitRefraction {
                            PtId = ptId,
                            VisitId = visitId,
                            Dosdate = dosDate,
                            RefractionClass = TruncateString(refractionClass, 5),
                            RefractionType = TruncateString(refractionType, 50),
                            SphereOd = TruncateString(sphereOd, 50),
                            SphereOs = TruncateString(sphereOs, 50),
                            CylinderOd = TruncateString(cylinderOd, 50),
                            CylinderOs = TruncateString(cylinderOs, 50),
                            AxisOd = TruncateString(axisOd, 50),
                            AxisOs = TruncateString(axisOs, 50),
                            BifocalAddOd = TruncateString(bifocalAddOd, 50),
                            BifocalAddOs = TruncateString(bifocalAddOs, 50),
                            PrismTypeOd = TruncateString(prismTypeOd, 255),
                            PrismTypeOs = TruncateString(prismTypeOs, 255),
                            Prism360Od = TruncateString(prism360Od, 50),
                            Prism360Os = TruncateString(prism360Os, 50),
                            DirectionOd = TruncateString(directionHod, 50),
                            DirectionOs = TruncateString(directionHos, 50),
                            PdDistOd = TruncateString(pdDistOd, 50),
                            PdDistOs = TruncateString(pdDistOs, 50),
                            PdNearOd = TruncateString(pdNearOd, 50),
                            PdNearOs = TruncateString(pdNearOs, 50),
                            Age = TruncateString(age, 50),
                            VaDOd = TruncateString(vaDOd, 50),
                            VaDOs = TruncateString(vaDOs, 50),
                            VaDOu = TruncateString(vaDOu, 50),
                            VaNOd = TruncateString(vaNOd, 50),
                            VaNOs = TruncateString(vaNOs, 50),
                            VaNOu = TruncateString(vaNOu, 50),
                            VaIOd = TruncateString(vaIOd, 50),
                            VaIOs = TruncateString(vaIOs, 50),
                            VaIOu = TruncateString(vaIOu, 50),
                            Expires = TruncateString(expires, 50),
                            Remarks = TruncateString(remarks, int.MaxValue),
                            InsertGuid = TruncateString(insertGUID, 40),
                            Printed = printed, // bit, no truncation needed
                            SentToOptical = sentToOptical, // bit, no truncation needed
                            EnteredBy = TruncateString(enteredBy, 200)
                        };
                        refractions.Add(newRefraction);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the refraction with ID: {refraction.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.EmrvisitRefractions.UpdateRange(refractions);
            eyeMDDbContext.SaveChanges();
            refractions = eyeMDDbContext.EmrvisitRefractions.ToList();
        }

        public static void RosConvert(List<ModelsC.Ro> ehrRos, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<Emrrosdefault> ross, List<Models.Patient> convPatients, List<ModelsC.Visit> ehrVisits) {
            foreach (var ros in ehrRos) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    var newRos = new Brady_s_Conversion_Program.ModelsB.Emrrosdefault {
                        RosbloodCustomDesc1 = TruncateString(ros.RosbloodCustomDesc1, 50),
                        RosbloodCustomDesc2 = TruncateString(ros.RosbloodCustomDesc2, 50),
                        RoscardioCustomDesc1 = TruncateString(ros.RoscardioCustomDesc1, 50),
                        RoscardioCustomDesc2 = TruncateString(ros.RoscardioCustomDesc2, 50),
                        RosconsCustomDesc1 = TruncateString(ros.RosconsCustomDesc1, 50),
                        RosconsCustomDesc2 = TruncateString(ros.RosconsCustomDesc2, 50),
                        RosendoCustomDesc1 = TruncateString(ros.RosendoCustomDesc1, 50),
                        RosendoCustomDesc2 = TruncateString(ros.RosendoCustomDesc2, 50),
                        RosentcustomDesc1 = TruncateString(ros.RosentcustomDesc1, 50),
                        RosentcustomDesc2 = TruncateString(ros.RosentcustomDesc2, 50),
                        RoseyeCustomDesc1 = TruncateString(ros.RoseyeCustomDesc1, 50),
                        RoseyeCustomDesc2 = TruncateString(ros.RoseyeCustomDesc2, 50),
                        RoseyeCustomDesc3 = TruncateString(ros.RoseyeCustomDesc3, 50),
                        RoseyeCustomDesc4 = TruncateString(ros.RoseyeCustomDesc4, 50),
                        RosgasCustomDesc1 = TruncateString(ros.RosgasCustomDesc1, 50),
                        RosgasCustomDesc2 = TruncateString(ros.RosgasCustomDesc2, 50),
                        RosimmuCustomDesc1 = TruncateString(ros.RosimmuCustomDesc1, 50),
                        RosimmuCustomDesc2 = TruncateString(ros.RosimmuCustomDesc2, 50),
                        RosmusSkeCustomDesc1 = TruncateString(ros.RosmusSkeCustomDesc1, 50),
                        RosmusSkeCustomDesc2 = TruncateString(ros.RosmusSkeCustomDesc2, 50),
                        RosneuroCustomDesc1 = TruncateString(ros.RosneuroCustomDesc1, 50),
                        RosneuroCustomDesc2 = TruncateString(ros.RosneuroCustomDesc2, 50),
                        RospsycCustomDesc1 = TruncateString(ros.RospsycCustomDesc1, 50),
                        RospsycCustomDesc2 = TruncateString(ros.RospsycCustomDesc2, 50),
                        RosrespCustomDesc1 = TruncateString(ros.RosrespCustomDesc1, 50),
                        RosrespCustomDesc2 = TruncateString(ros.RosrespCustomDesc2, 50),
                        RosskinCustomDesc1 = TruncateString(ros.RosskinCustomDesc1, 50),
                        RosskinCustomDesc2 = TruncateString(ros.RosskinCustomDesc2, 50),
                        RosurinaryCustomDesc1 = TruncateString(ros.RosurinaryCustomDesc1, 50),
                        RosurinaryCustomDesc2 = TruncateString(ros.RosurinaryCustomDesc2, 50)
                    };
                    ross.Add(newRos);
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the ros with ID: {ros.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.Emrrosdefaults.UpdateRange(ross);
            eyeMDDbContext.SaveChanges();
            ross = eyeMDDbContext.Emrrosdefaults.ToList();
        }

        public static void RxConvert(List<ModelsC.RxMedication> ehrRxs, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<Visit> ehrVisits, List<Emrvisit> visits, List<EmrvisitRxMedication> rxMedications, List<Emrpatient> eyeMDPatients, List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients) {
            foreach (var rx in ehrRxs) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    int? visitId = null;
                    int ptId = -1;
                    DmgPatient? ffpmPatient = null;
                    Emrvisit? EyeMDVisit = null;
                    Emrpatient? eyeMDPatient = null;
                    if (rx.PtId > 0) {
                        ptId = rx.PtId;
                        ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == ptId.ToString());
                        if (ffpmPatient == null) {
                            if (rx.VisitId > 0) {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == rx.VisitId);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for rx with ID: {rx.Id}");
                                    continue;
                                }
                                else {
                                    if (EyeMDVisit.PtId != null) {
                                        ptId = (int)EyeMDVisit.PtId;
                                        eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                        if (eyeMDPatient == null) {
                                            logger.Log($"EHR: EyeMD Patient not found for rx with ID: {rx.Id}");
                                            continue;
                                        }
                                        else {
                                            visitId = EyeMDVisit.VisitId;
                                        }
                                    }
                                    else {
                                        logger.Log($"EHR: EyeMD Patient not found for rx with ID: {rx.Id}");
                                        continue;
                                    }
                                }
                            }
                            else {
                                logger.Log($"EHR: FFPM Patient not found for rx with ID: {rx.Id}");
                                continue;
                            }
                        }
                        else if (eyeMDPatient == null) {
                            ptId = (int)ffpmPatient.PatientId;
                            EyeMDVisit = visits.FirstOrDefault(v => v.PtId == ptId);
                            if (EyeMDVisit == null) {
                                visitId = null;
                            }
                        }
                    }
                    else if (rx.VisitId > 0) {
                        visitId = rx.VisitId;
                        EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
                        if (EyeMDVisit == null) {
                            logger.Log($"EHR: EyeMD visit and patient not found for rx with ID: {rx.Id}");
                            continue;
                        }
                        else {
                            if (EyeMDVisit.PtId != null) {
                                ptId = (int)EyeMDVisit.PtId;
                                eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                if (eyeMDPatient == null) {
                                    logger.Log($"EHR: EyeMD Patient not found for rx with ID: {rx.Id}");
                                    continue;
                                }
                            }
                            else {
                                logger.Log($"EHR: EyeMD Patient not found for rx with ID: {rx.Id}");
                                continue;
                            }
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
                    if (rx.DoNotReconcile != null && rx.DoNotReconcile.ToLower() == "yes" || rx.DoNotReconcile == "1") {
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

                    var ehrOrig = rxMedications.FirstOrDefault(rx => rx.PtId == ptId && rx.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newRx = new Brady_s_Conversion_Program.ModelsB.EmrvisitRxMedication {
                            PtId = ptId,
                            VisitId = visitId,
                            Dosdate = dosDate,
                            MedName = TruncateString(medName, 255),
                            MedSig = TruncateString(medSig, 255),
                            MedDisp = TruncateString(medDisp, 255),
                            MedRefill = TruncateString(medRefill, 255),
                            MedType = medType,
                            BrandMedOnly = brandMedOnly, // smallint, no truncation needed
                            DoNotPrintRx = doNotPrintRx, // smallint, no truncation needed
                            SampleGiven = sampleGiven, // smallint, no truncation needed
                            Notes = TruncateString(notes, int.MaxValue),
                            Description = TruncateString(description, int.MaxValue),
                            MedTableId = medTableId,
                            MedDispType = medDispType, // smallint, no truncation needed
                            DrugStrength = TruncateString(drugStrength, 100),
                            DrugRoute = TruncateString(drugRoute, 100),
                            DrugForm = TruncateString(drugForm, 100),
                            DrugMappingId = TruncateString(drugMappingId, 100),
                            DrugAltMappingId = TruncateString(drugAltMappingId, 100),
                            DrugName = TruncateString(drugName, 200),
                            DrugNameId = TruncateString(drugNameId, 100),
                            ErxGuid = TruncateString(erxGUID, 50),
                            ErxPendingTransmit = erxPendingTransmit, // smallint, no truncation needed
                            CalledInLocationId = calledInLocationId,
                            CalledInProviderEmpId = calledInProviderEmpId,
                            MedDispUnitType = TruncateString(medDispUnitType, 100),
                            Rxcui = TruncateString(rxcui, 50),
                            IsRefill = isRefill, // smallint, no truncation needed
                            OriginalMedicationId = TruncateString(originalMedicationId, 255),
                            OriginalMedicationDate = TruncateString(originalMedicationDate, 50),
                            SentViaErx = sentViaErx, // smallint, no truncation needed
                            Snomed = TruncateString(snomed, 50),
                            DrugFdastatus = TruncateString(drugFdaStatus, 50),
                            DrugDeaclass = TruncateString(drugDeaClass, 25),
                            RxRemarks = TruncateString(rxRemarks, 255),
                            InsertGuid = TruncateString(insertGUID, 50),
                            RecordedEmpRole = recordedEmpRole,
                            AdministeredMed = administeredMed, // smallint, no truncation needed
                            FormularyChecked = formularyChecked, // smallint, no truncation needed
                            PrintedRx = printedRx, // smallint, no truncation needed
                            DoNotReconcile = doNotReconcile, // bit, no truncation needed
                            RxStartDate = rxStartDate,
                            RxEndDate = rxEndDate,
                            RxDurationDays = rxDurationDays,
                            LastModified = lastModified,
                            VisitDiagCodePoolId = visitDiagCodePoolId,
                            Created = created,
                            CreatedEmpId = createdEmpId,
                            LastModifiedEmpId = lastModifiedEmpId,
                            ErxStatus = TruncateString(erxStatus, 100)
                        };
                        rxMedications.Add(newRx);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the rx with ID: {rx.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.EmrvisitRxMedications.UpdateRange(rxMedications);
            eyeMDDbContext.SaveChanges();
            rxMedications = eyeMDDbContext.EmrvisitRxMedications.ToList();
        }

        public static void SurgHistoriesConvert(List<ModelsC.SurgHistory> ehrSurgHistories, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<Emrvisit> visits, List<EmrvisitSurgicalHistory> surgicalHistories, List<Emrpatient> eyeMDPatients, List<Visit> ehrVisits, List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients) {
            foreach (var surgHistory in ehrSurgHistories) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    int? visitId = null;
                    int ptId = -1;
                    DmgPatient? ffpmPatient = null;
                    Emrvisit? EyeMDVisit = null;
                    Emrpatient? eyeMDPatient = null;
                    if (surgHistory.PtId > 0) {
                        ptId = surgHistory.PtId;
                        ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == ptId.ToString());
                        if (ffpmPatient == null) {
                            if (surgHistory.VisitId > 0) {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == surgHistory.VisitId);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for surgHistory with ID: {surgHistory.Id}");
                                    continue;
                                }
                                else {
                                    if (EyeMDVisit.PtId != null) {
                                        ptId = (int)EyeMDVisit.PtId;
                                        eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                        if (eyeMDPatient == null) {
                                            logger.Log($"EHR: EyeMD Patient not found for surgHistory with ID: {surgHistory.Id}");
                                            continue;
                                        }
                                        else {
                                            visitId = EyeMDVisit.VisitId;
                                        }
                                    }
                                    else {
                                        logger.Log($"EHR: EyeMD Patient not found for surgHistory with ID: {surgHistory.Id}");
                                        continue;
                                    }
                                }
                            }
                            else {
                                logger.Log($"EHR: FFPM Patient not found for surgHistory with ID: {surgHistory.Id}");
                                continue;
                            }
                        }
                        else if (eyeMDPatient == null) {
                            ptId = (int)ffpmPatient.PatientId;
                            EyeMDVisit = visits.FirstOrDefault(v => v.PtId == ptId);
                            if (EyeMDVisit == null) {
                                visitId = null;
                            }
                        }
                    }
                    else if (surgHistory.VisitId > 0) {
                        visitId = surgHistory.VisitId;
                        EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
                        if (EyeMDVisit == null) {
                            logger.Log($"EHR: EyeMD visit and patient not found for surgHistory with ID: {surgHistory.Id}");
                            continue;
                        }
                        else {
                            if (EyeMDVisit.PtId != null) {
                                ptId = (int)EyeMDVisit.PtId;
                                eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                if (eyeMDPatient == null) {
                                    logger.Log($"EHR: EyeMD Patient not found for surgHistory with ID: {surgHistory.Id}");
                                    continue;
                                }
                            }
                            else {
                                logger.Log($"EHR: EyeMD Patient not found for surgHistory with ID: {surgHistory.Id}");
                                continue;
                            }
                        }
                    }

                    DateTime? dosDate = null;
                    if (surgHistory.Dosdate != null) {
                        DateTime tempDateTime;
                        if (DateTime.TryParseExact(surgHistory.Dosdate, dateFormats,
                                                   CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out tempDateTime)) {
                            dosDate = tempDateTime;
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
                    if (surgHistory.DoNotReconcile != null && surgHistory.DoNotReconcile.ToLower() == "yes" || surgHistory.DoNotReconcile == "1") {
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

                    var ehrOrig = surgicalHistories.FirstOrDefault(s => s.PtId == ptId && s.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newSurgHistory = new Brady_s_Conversion_Program.ModelsB.EmrvisitSurgicalHistory {
                            PtId = ptId,
                            VisitId = visitId,
                            VisitDate = dosDate,
                            ControlId = controlId,
                            OrigVisitSurgicalHistoryId = origVisitSurgicalHistoryId,
                            OrigVisitDate = origVisitDate,
                            Description = TruncateString(description, 255),
                            TypeId = typeId,
                            CodeId = codeId,
                            Code = TruncateString(code, 50),
                            Modifier = TruncateString(modifier, 50),
                            CodeIcd10 = TruncateString(codeICD10, 50),
                            CodeSnomed = TruncateString(codeSnomed, 50),
                            ComanageEmpId1 = performedByEmpId1,
                            ComanageRefProviderId1 = comanageRefProviderId1,
                            ComanageFullName1 = TruncateString(comanageFullName1, 100),
                            ComanageEmpId2 = performedByEmpId2,
                            ComanageRefProviderId2 = performedbyRefProviderId2,
                            ComanageFullName2 = TruncateString(comanageFullName2, 100),
                            Notes = TruncateString(notes, int.MaxValue),
                            Created = created,
                            LastModified = lastModified,
                            CreatedEmpId = createdEmpId,
                            LastModifiedEmpId = lastModifiedEmpId,
                            DoNotReconcile = doNotReconcile, // bit, no truncation needed
                            PtDeviceId = ptDeviceId,
                            InsertGuid = TruncateString(insertGUID, 50),
                            Location1 = TruncateString(location1, 50),
                            ProcedureMonth1 = TruncateString(procedureMonth1, 10),
                            ProcedureDay1 = TruncateString(procedureDay1, 10),
                            ProcedureYear1 = TruncateString(procedureYear1, 10),
                            PerformedbyEmpId1 = performedByEmpId1,
                            PerformedbyFullName1 = TruncateString(comanageFullName1, 100),
                            PerformedbyRefProviderId1 = performedByRefProvider1,
                            Location2 = TruncateString(location2, 50),
                            ProcedureMonth2 = TruncateString(procedureMonth2, 10),
                            ProcedureDay2 = TruncateString(procedureDay2, 10),
                            ProcedureYear2 = TruncateString(procedureYear2, 10),
                            PerformedbyEmpId2 = performedByEmpId2,
                            PerformedbyFullName2 = TruncateString(comanageFullName2, 100),
                            PerformedbyRefProviderId2 = performedbyRefProviderId2
                        };
                        surgicalHistories.Add(newSurgHistory);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the surg history with ID: {surgHistory.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.EmrvisitSurgicalHistories.UpdateRange(surgicalHistories);
            eyeMDDbContext.SaveChanges();
            surgicalHistories = eyeMDDbContext.EmrvisitSurgicalHistories.ToList();
        }

        public static void TechsConvert(List<ModelsC.Tech> ehrTechs, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<Visit> ehrVisits, List<Emrvisit> visits, List<Emrpatient> eyeMDPatients, List<EmrvisitTech> techs, List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients) {
            foreach (var tech in ehrTechs) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    int? visitId = null;
                    int ptId = -1;
                    DmgPatient? ffpmPatient = null;
                    Emrvisit? EyeMDVisit = null;
                    Emrpatient? eyeMDPatient = null;
                    if (tech.PtId > 0) {
                        ptId = tech.PtId;
                        ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == ptId.ToString());
                        if (ffpmPatient == null) {
                            if (tech.OldVisitId > 0) {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == tech.OldVisitId);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for tech with ID: {tech.Id}");
                                    continue;
                                }
                                else {
                                    if (EyeMDVisit.PtId != null) {
                                        ptId = (int)EyeMDVisit.PtId;
                                        eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                        if (eyeMDPatient == null) {
                                            logger.Log($"EHR: EyeMD Patient not found for tech with ID: {tech.Id}");
                                            continue;
                                        }
                                        else {
                                            visitId = EyeMDVisit.VisitId;
                                        }
                                    }
                                    else {
                                        logger.Log($"EHR: EyeMD Patient not found for tech with ID: {tech.Id}");
                                        continue;
                                    }
                                }
                            }
                            else {
                                logger.Log($"EHR: FFPM Patient not found for tech with ID: {tech.Id}");
                                continue;
                            }
                        }
                        else if (eyeMDPatient == null) {
                            ptId = (int)ffpmPatient.PatientId;
                            EyeMDVisit = visits.FirstOrDefault(v => v.PtId == ptId);
                            if (EyeMDVisit == null) {
                                visitId = null;
                            }
                        }
                    }
                    else if (tech.OldVisitId > 0) {
                        visitId = tech.OldVisitId;
                        EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
                        if (EyeMDVisit == null) {
                            logger.Log($"EHR: EyeMD visit and patient not found for tech with ID: {tech.Id}");
                            continue;
                        }
                        else {
                            if (EyeMDVisit.PtId != null) {
                                ptId = (int)EyeMDVisit.PtId;
                                eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                if (eyeMDPatient == null) {
                                    logger.Log($"EHR: EyeMD Patient not found for tech with ID: {tech.Id}");
                                    continue;
                                }
                            }
                            else {
                                logger.Log($"EHR: EyeMD Patient not found for tech with ID: {tech.Id}");
                                continue;
                            }
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
                    if (tech.Wuvacctype != null) {
                        if (int.TryParse(tech.Wuvacctype, out int locum)) {
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
                    if (tech.Wucvfabute != null) {
                        if (short.TryParse(tech.Wucvfabute, out short locum)) {
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
                    if (tech.IntakeReconciled != null && tech.IntakeReconciled.ToLower() == "yes" || tech.IntakeReconciled == "1") {
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
                    if (tech.Wuiopabute != null) {
                        if (short.TryParse(tech.Wuiopabute, out short locum)) {
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

                    var ehrOrig = techs.FirstOrDefault(t => t.PtId == ptId && t.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newTech = new Brady_s_Conversion_Program.ModelsB.EmrvisitTech {
                            PtId = ptId,
                            VisitId = visitId,
                            Dosdate = dosDate,
                            Pmhsmoking = pmhSmoking,
                            Pmhalcohol = pmhAlcohol,
                            Pmhdrugs = pmhDrugs,
                            WuvaCcType = wuvaCcType,
                            Pmhfhother = TruncateString(tech.Pmhfhother, int.MaxValue),
                            PmhsmokeHowMuch = TruncateString(tech.PmhsmokeHowMuch, 50),
                            PmhsmokeHowLong = TruncateString(tech.PmhsmokeHowLong, 50),
                            PmhsmokeWhenQuit = TruncateString(tech.PmhsmokeWhenQuit, 50),
                            PmhalcoholHowMuch = TruncateString(tech.PmhalcoholHowMuch, 50),
                            PmhdrugsNames = TruncateString(tech.PmhdrugsNames, int.MaxValue),
                            PmhdrugsHowMuch = TruncateString(tech.PmhdrugsHowMuch, 50),
                            PmhdrugsHowLong = TruncateString(tech.PmhdrugsHowLong, 50),
                            PmhdrugsWhenQuit = TruncateString(tech.PmhdrugsWhenQuit, 50),
                            HpichiefComplaint = TruncateString(tech.HpichiefComplaint, 255),
                            Hpilocation1 = TruncateString(tech.Hpilocation1, 255),
                            Hpiquality1 = TruncateString(tech.Hpiquality1, 255),
                            Hpiseverity1 = TruncateString(tech.Hpiseverity1, 255),
                            Hpitiming1 = TruncateString(tech.Hpitiming1, 255),
                            Hpiduration1 = TruncateString(tech.Hpiduration1, 255),
                            Hpicontext1 = TruncateString(tech.Hpicontext1, 255),
                            HpimodFactors1 = TruncateString(tech.HpimodFactors1, 255),
                            HpiassoSignsSymp1 = TruncateString(tech.HpiassoSignsSymp1, 255),
                            Hpi1letterText = TruncateString(tech.Hpi1letterText, int.MaxValue),
                            WuvaCcOd = TruncateString(tech.Wuvaccod, 50),
                            WuvaCcOs = TruncateString(tech.Wuvaccos, 50),
                            WuvaCcOu = TruncateString(tech.Wuvaccou, 50),
                            WuvaPhOd = TruncateString(tech.Wuvaphod, 50),
                            WuvaPhOs = TruncateString(tech.Wuvaphos, 50),
                            WuvaScOd = TruncateString(tech.Wuvascod, 50),
                            WuvaScOs = TruncateString(tech.Wuvascos, 50),
                            WuvaScOu = TruncateString(tech.Wuvascou, 50),
                            WuvaTestUsed = TruncateString(tech.WuvatestUsed, 50),
                            WunCcOd = TruncateString(tech.Wunccod, 50),
                            WunCcOs = TruncateString(tech.Wunccos, 50),
                            WunCcOu = TruncateString(tech.Wunccou, 50),
                            Wunotes = TruncateString(tech.Wunotes, int.MaxValue),
                            WunScOd = TruncateString(tech.Wunscod, 50),
                            WunScOs = TruncateString(tech.Wunscos, 50),
                            WunScOu = TruncateString(tech.Wunscou, 50),
                            WudomEye = TruncateString(tech.WudomEye, 50),
                            WutcvfOd = TruncateString(tech.Wutcvfod, 50),
                            WutcvfOs = TruncateString(tech.Wutcvfos, 50),
                            WucvfdiagOd = TruncateString(tech.WucvfdiagOd, int.MaxValue),
                            WucvfdiagOs = TruncateString(tech.WucvfdiagOs, int.MaxValue),
                            WueomSuTmOd = TruncateString(tech.WueomsuTmOd, 50),
                            WueomSuTmOs = TruncateString(tech.WueomsuTmOs, 50),
                            WueomMedialOd = TruncateString(tech.WueommedialOd, 50),
                            WueomMedialOs = TruncateString(tech.WueommedialOs, 50),
                            WueomInNaOs = TruncateString(tech.WueominNaOs, 50),
                            WueomInNaOd = TruncateString(tech.WueominNaOd, 50),
                            WueomInTmOd = TruncateString(tech.WueominTmOd, 50),
                            WueomInTmOs = TruncateString(tech.WueominTmOs, 50),
                            WueomSuNaOd = TruncateString(tech.WueomsuNaOd, 50),
                            WueomSuNaOs = TruncateString(tech.WueomsuNaOs, 50),
                            WupupilNearOd = TruncateString(tech.WupupilNearOd, 50),
                            WupupilNearOs = TruncateString(tech.WupupilNearOs, 50),
                            WorkupMdreviewed = workupMdReviewed, // smallint, no truncation needed
                            WorkupMdreviewedDate = workupMdReviewedDate,
                            WorkupMdreviewedEmpId = workupMdReviewedEmpId,
                            WuamslerOd = TruncateString(tech.WuamslerOd, 255),
                            WuamslerOs = TruncateString(tech.WuamslerOs, 255),
                            WucvfAbute = wucvfAbute, // smallint, no truncation needed
                            Wudilated = wuDilated, // smallint, no truncation needed
                            WudilatedAgent = TruncateString(tech.WudilatedAgent, 255),
                            WudilatedEye = TruncateString(tech.WudilatedEye, 50),
                            WudilatedFrequency = TruncateString(tech.WudilatedFrequency, 255),
                            VitalsTemp = TruncateString(tech.VitalsTemp, 50),
                            VitalsTempUnits = TruncateString(tech.VitalsTempUnits, 50),
                            VitalsPulse = TruncateString(tech.VitalsPulse, 50),
                            VitalsBpsys = TruncateString(tech.VitalsBpsys, 50),
                            VitalsBpdia = TruncateString(tech.VitalsBpdia, 50),
                            VitalsRespRate = TruncateString(tech.VitalsRespRate, 255),
                            VitalsWeight = TruncateString(tech.VitalsWeight, 50),
                            VitalsWeightUnits = TruncateString(tech.VitalsWeightUnits, 50),
                            VitalsHeight = TruncateString(tech.VitalsHeight, 50),
                            VitalsHeightUnits = TruncateString(tech.VitalsHeightUnits, 50),
                            VitalsBmi = TruncateString(tech.VitalsBmi, 50),
                            VitalsBmipercentile = vitalsBmiPercentile, // decimal(9, 8), no truncation needed
                            VitalsBgl = TruncateString(tech.VitalsBgl, 50),
                            VitalsBglunits = TruncateString(tech.VitalsBglunits, 50),
                            VitalsHofcpercentile = vitalsHofcPercentile, // decimal(9, 8), no truncation needed
                            VitalsInhaled02Concentration = vitalsInhaled02Concentration, // decimal(9, 8), no truncation needed
                            VitalsPulseOximetry = vitalsPulseOximetry, // decimal(9, 8), no truncation needed
                            VitalsWflpercentile = vitalsWflPercentile, // decimal(9, 8), no truncation needed
                            HistoryMdreviewed = historyReviewed, // smallint, no truncation needed
                            HistoryMdreviewedDate = historyMdReviewedDate,
                            HistoryMdreviewedEmpId = historyMdReviewedEmpId,
                            Created = created,
                            CreatedEmpId = createdEmpId,
                            WupupilShapeOs = TruncateString(tech.WupupilShapeOs, 50),
                            WupupilShapeOd = TruncateString(tech.WupupilShapeOd, 50),
                            WudilatedTimeZone = wuDilatedTimeZone, // smallint, no truncation needed
                            WudilatedTime = wuDilatedTime,
                            WueomTemporalOd = TruncateString(tech.WueomtemporalOd, 50),
                            WueomTemporalOs = TruncateString(tech.WueomtemporalOs, 50),
                            WueomType = TruncateString(tech.Wueomtype, 255),
                            Wuextlids = TruncateString(tech.Wuextlids, int.MaxValue),
                            Wuextorbits = TruncateString(tech.Wuextorbits, int.MaxValue),
                            PmhsmokingStatus = TruncateString(tech.PmhsmokingStatus, 100),
                            WupupilReactionOs = TruncateString(tech.WupupilReactionOs, 50),
                            WupupilReactionOd = TruncateString(tech.WupupilReactionOd, 50),
                            WupupilLightSizeOs = TruncateString(tech.WupupilLightSizeOs, 50),
                            WupupilLightSizeOd = TruncateString(tech.WupupilLightSizeOd, 50),
                            WupupilApdOd = TruncateString(tech.WupupilApdod, 50),
                            WupupilApdOs = TruncateString(tech.WupupilApdos, 50),
                            WupupilDarkSizeOd = TruncateString(tech.WupupilDarkSizeOd, 50),
                            WupupilDarkSizeOs = TruncateString(tech.WupupilDarkSizeOs, 50),
                            HpiadditionalComments1 = TruncateString(tech.HpiadditionalComments1, int.MaxValue),
                            IntakeReconciled = intakeReconciled, // bit, no truncation needed
                            LastModified = lastModified,
                            LastModifiedEmpId = lastModifiedEmpId,
                            MedRecNotPerformed = medRecNotPerformed, // smallint, no truncation needed
                            UpsizeTs = null,
                            Wumood = wuMood, // smallint, no truncation needed
                            Wuextpan = wuextPan, // int, no truncation needed
                            WuiopAbute = wuiopAbute, // smallint, no truncation needed
                            WuorientPerson = wuOrientPerson, // int, no truncation needed
                            WuorientPlace = wuOrientPlace, // int, no truncation needed
                            WuorientTime = wuOrientTime, // int, no truncation needed
                            WuorientSituation = wuOrientSituation // int, no truncation needed
                        };
                        techs.Add(newTech);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the tech with ID: {tech.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.EmrvisitTeches.UpdateRange(techs);
            eyeMDDbContext.SaveChanges();
            techs = eyeMDDbContext.EmrvisitTeches.ToList();
        }

        public static void Tech2sConvert(List<ModelsC.Tech2> ehrTech2s, EHRDbContext eHRDbContext, EyeMdContext eyeMDDbContext, ILogger logger, ProgressBar progress,
            List<Visit> ehrVisits, List<Emrvisit> visits, List<Emrpatient> eyeMDPatients, List<EmrvisitTech2> tech2s, List<DmgPatient> ffpmPatients, List<Models.Patient> convPatients) {
            foreach (var tech2 in ehrTech2s) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    int? visitId = null;
                    int ptId = -1;
                    DmgPatient? ffpmPatient = null;
                    Emrvisit? EyeMDVisit = null;
                    Emrpatient? eyeMDPatient = null;
                    if (tech2.PtId > 0) {
                        ptId = tech2.PtId;
                        ffpmPatient = ffpmPatients.FirstOrDefault(p => p.AccountNumber == ptId.ToString());
                        if (ffpmPatient == null) {
                            if (tech2.OldVisitId > 0) {
                                EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == tech2.OldVisitId);
                                if (EyeMDVisit == null) {
                                    logger.Log($"EHR: EyeMD visit and FFPM patient not found for tech2 with ID: {tech2.Id}");
                                    continue;
                                }
                                else {
                                    if (EyeMDVisit.PtId != null) {
                                        ptId = (int)EyeMDVisit.PtId;
                                        eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                        if (eyeMDPatient == null) {
                                            logger.Log($"EHR: EyeMD Patient not found for tech2 with ID: {tech2.Id}");
                                            continue;
                                        }
                                        else {
                                            visitId = EyeMDVisit.VisitId;
                                        }
                                    }
                                    else {
                                        logger.Log($"EHR: EyeMD Patient not found for tech2 with ID: {tech2.Id}");
                                        continue;
                                    }
                                }
                            }
                            else {
                                logger.Log($"EHR: FFPM Patient not found for tech2 with ID: {tech2.Id}");
                                continue;
                            }
                        }
                        else if (eyeMDPatient == null) {
                            ptId = (int)ffpmPatient.PatientId;
                            EyeMDVisit = visits.FirstOrDefault(v => v.PtId == ptId);
                            if (EyeMDVisit == null) {
                                visitId = null;
                            }
                        }
                    }
                    else if (tech2.OldVisitId > 0) {
                        visitId = tech2.OldVisitId;
                        EyeMDVisit = visits.FirstOrDefault(v => v.ClientSoftwareApptId == visitId);
                        if (EyeMDVisit == null) {
                            logger.Log($"EHR: EyeMD visit and patient not found for tech2 with ID: {tech2.Id}");
                            continue;
                        }
                        else {
                            if (EyeMDVisit.PtId != null) {
                                ptId = (int)EyeMDVisit.PtId;
                                eyeMDPatient = eyeMDPatients.FirstOrDefault(p => p.PtId == ptId);
                                if (eyeMDPatient == null) {
                                    logger.Log($"EHR: EyeMD Patient not found for tech2 with ID: {tech2.Id}");
                                    continue;
                                }
                            }
                            else {
                                logger.Log($"EHR: EyeMD Patient not found for tech2 with ID: {tech2.Id}");
                                continue;
                            }
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

                    var ehrOrig = tech2s.FirstOrDefault(t2 => t2.PtId == ptId && t2.VisitId == visitId);

                    if (ehrOrig == null) {
                        var newTech2 = new Brady_s_Conversion_Program.ModelsB.EmrvisitTech2 {
                            PtId = ptId,
                            VisitId = visitId,
                            Dosdate = dosDate,
                            Wu2vaOrxOd = tech2.Wu2vaorxOd,
                            Wu2vaOrxOs = tech2.Wu2vaorxOs,
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
                            Wu2custom1Data = TruncateString(tech2.Wu2custom1Data, int.MaxValue),
                            Wu2custom1Desc = TruncateString(tech2.Wu2custom1Desc, 50),
                            Wu2custom2Data = TruncateString(tech2.Wu2custom2Data, int.MaxValue),
                            Wu2custom2Desc = TruncateString(tech2.Wu2custom2Desc, 50),
                            Wu2custom3Data = TruncateString(tech2.Wu2custom3Data, int.MaxValue),
                            Wu2custom3Desc = TruncateString(tech2.Wu2custom3Desc, 50),
                            Wu2custom4Data = TruncateString(tech2.Wu2custom4Data, int.MaxValue),
                            Wu2custom4Desc = TruncateString(tech2.Wu2custom4Desc, 50),
                            Wu2custom5Data = TruncateString(tech2.Wu2custom5Data, int.MaxValue),
                            Wu2custom5Desc = TruncateString(tech2.Wu2custom5Desc, 50),
                            Wu2custom6Data = TruncateString(tech2.Wu2custom6Data, int.MaxValue),
                            Wu2custom6Desc = TruncateString(tech2.Wu2custom6Desc, 50),
                            Wu2custom7Data = TruncateString(tech2.Wu2custom7Data, int.MaxValue),
                            Wu2custom7Desc = TruncateString(tech2.Wu2custom7Desc, 50),
                            Wu2custom8Data = TruncateString(tech2.Wu2custom8Data, int.MaxValue),
                            Wu2custom8Desc = TruncateString(tech2.Wu2custom8Desc, 50),
                            Wu2custom9Data = TruncateString(tech2.Wu2custom9Data, int.MaxValue),
                            Wu2custom9Desc = TruncateString(tech2.Wu2custom9Desc, 50),
                            Wu2custom10Data = TruncateString(tech2.Wu2custom10Data, int.MaxValue),
                            Wu2custom10Desc = TruncateString(tech2.Wu2custom10Desc, 50),
                            Wu2custom11Data = TruncateString(tech2.Wu2custom11Data, int.MaxValue),
                            Wu2custom11Desc = TruncateString(tech2.Wu2custom11Desc, 50),
                            Wu2custom12Data = TruncateString(tech2.Wu2custom12Data, int.MaxValue),
                            Wu2custom12Desc = TruncateString(tech2.Wu2custom12Desc, 50),
                            Wu2custom13Data = TruncateString(tech2.Wu2custom13Data, int.MaxValue),
                            Wu2custom13Desc = TruncateString(tech2.Wu2custom13Desc, 50),
                            Wu2custom14Data = TruncateString(tech2.Wu2custom14Data, int.MaxValue),
                            Wu2custom14Desc = TruncateString(tech2.Wu2custom14Desc, 50),
                            Wu2custom15Data = TruncateString(tech2.Wu2custom15Data, int.MaxValue),
                            Wu2custom15Desc = TruncateString(tech2.Wu2custom15Desc, 50),
                            Wu2custom16Data = TruncateString(tech2.Wu2custom16Data, int.MaxValue),
                            Wu2custom16Desc = TruncateString(tech2.Wu2custom16Desc, 50),
                            Wu2custom17Data = TruncateString(tech2.Wu2custom17Data, int.MaxValue),
                            Wu2custom17Desc = TruncateString(tech2.Wu2custom17Desc, 50),
                            Wu2custom18Data = TruncateString(tech2.Wu2custom18Data, int.MaxValue),
                            Wu2custom18Desc = TruncateString(tech2.Wu2custom18Desc, 50),
                            Wu2custom19Data = TruncateString(tech2.Wu2custom19Data, int.MaxValue),
                            Wu2custom19Desc = TruncateString(tech2.Wu2custom19Desc, 50),
                            Wu2custom20Data = TruncateString(tech2.Wu2custom20Data, int.MaxValue),
                            Wu2custom20Desc = TruncateString(tech2.Wu2custom20Desc, 50),
                            Wu2custom21Data = TruncateString(tech2.Wu2custom21Data, int.MaxValue),
                            Wu2custom21Desc = TruncateString(tech2.Wu2custom21Desc, 50),
                            Wu2custom22Data = TruncateString(tech2.Wu2custom22Data, int.MaxValue),
                            Wu2custom22Desc = TruncateString(tech2.Wu2custom22Desc, 50),
                            Wu2GlareHighOd = tech2.Wu2glareHighOd,
                            Wu2GlareHighOs = tech2.Wu2glareHighOs,
                            Wu2GlareLowOd = tech2.Wu2glareLowOd,
                            Wu2GlareLowOs = tech2.Wu2glareLowOs,
                            Wu2GlareMedOd = tech2.Wu2glareMedOd,
                            Wu2GlareMedOs = tech2.Wu2glareMedOs,
                            Wu2GlareType = TruncateString(tech2.Wu2glareType, 50),
                            Wu2hertelBase = TruncateString(tech2.Wu2hertelBase, 100),
                            Wu2hertelOd = TruncateString(tech2.Wu2hertelOd, 100),
                            Wu2hertelOs = TruncateString(tech2.Wu2hertelOs, 100),
                            Wu2ktype = TruncateString(tech2.Wu2ktype, 255),
                            Wu2pachCctOd = TruncateString(tech2.Wu2pachCctod, 50),
                            Wu2pachCctOs = TruncateString(tech2.Wu2pachCctos, 50),
                            Wu2ttvOd = TruncateString(tech2.Wu2ttvod, 50),
                            Wu2ttvOs = TruncateString(tech2.Wu2ttvos, 50),
                            Wu2ttvtype = TruncateString(tech2.Wu2ttvtype, int.MaxValue),
                            Wu2vaPamOd = TruncateString(tech2.Wu2vapamod, 50),
                            Wu2vaPamOs = TruncateString(tech2.Wu2vapamos, 50)
                        };
                        tech2s.Add(newTech2);
                    }
                }
                catch (Exception e) {
                    logger.Log($"EHR: EHR An error occurred while converting the tech2 with ID: {tech2.Id}. Error: {e.Message}");
                }
            }
            eyeMDDbContext.EmrvisitTech2s.UpdateRange(tech2s);
            eyeMDDbContext.SaveChanges();
            tech2s = eyeMDDbContext.EmrvisitTech2s.ToList();
        }
        #endregion EyeMDConversion

        #region InvConversion
        public static void ConvertInv(InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress, RichTextBox resultsBox) {
            var clnsBrands = ffpmDbContext.ClnsBrands.ToList();
            var clLenses = ffpmDbContext.ClnsContactLens.ToList();
            var clInventories = ffpmDbContext.ClnsInventories.ToList();
            var cptDepts = ffpmDbContext.CptDepartments.ToList();
            var cptMappings = ffpmDbContext.CptGroupMappings.ToList();
            var cpts = ffpmDbContext.Cptids.ToList();
            var frameCategories = ffpmDbContext.FrameCategories.ToList();
            var frameCollections = ffpmDbContext.FrameCollections.ToList();
            var frameColors = ffpmDbContext.FrameColors.ToList();
            var frameShapes = ffpmDbContext.FrameShapes.ToList();
            var frameStatuses = ffpmDbContext.FrameStatuses.ToList();
            var frameTemples = ffpmDbContext.FrameTempleStyles.ToList();
            var frameEtypes = ffpmDbContext.FrameEtypes.ToList();
            var frameFtypes = ffpmDbContext.FrameFtypes.ToList();
            var frameInventories = ffpmDbContext.Inventories.ToList();
            var frameLensColors = ffpmDbContext.FrameDblensColors.ToList();
            var frameMaterials = ffpmDbContext.FrameMaterials.ToList();
            var frameOrders = ffpmDbContext.FrameOrderInfos.ToList();
            var frames = ffpmDbContext.Frames.ToList();
            var clnsContactlens = ffpmDbContext.ClnsContactLens.ToList();
            var cptGroupMappings = ffpmDbContext.CptGroupMappings.ToList();
            var invClBrands = invDbContext.Clbrands.ToList();
            var invClLenses = invDbContext.Cllenses.ToList();
            var invClInventories = invDbContext.Clinventories.ToList();
            var invCptDepts = invDbContext.Cptdepts.ToList();
            var invCptMappings = invDbContext.Cptmappings.ToList();
            var invCpts = invDbContext.Cpts.ToList();
            var invFrameCategories = invDbContext.FrameCategories.ToList();
            var invFrameCollections = invDbContext.FrameCollections.ToList();
            var invFrameColors = invDbContext.FrameColors.ToList();
            var invFrameShapes = invDbContext.FrameShapes.ToList();
            var invFrameStatuses = invDbContext.FrameStatuses.ToList();
            var invFrameTemples = invDbContext.FrameTemples.ToList();
            var invFrameEtypes = invDbContext.FrameEtypes.ToList();
            var invFrameFtypes = invDbContext.FrameFtypes.ToList();
            var invFrameInventories = invDbContext.FrameInventories.ToList();
            var invFrameLensColors = invDbContext.FrameLensColors.ToList();
            var invFrameMaterials = invDbContext.FrameMaterials.ToList();
            var invFrameOrders = invDbContext.FrameOrders.ToList();
            var invFrames = invDbContext.Frames.ToList();
            var invFrameManufacturers = invDbContext.FrameManufacturers.ToList();
            var locations = ffpmDbContext.BillingLocations.ToList();
            var otherAddresses = ffpmDbContext.DmgOtherAddresses.ToList();
            var vendors = ffpmDbContext.Vendors.ToList();
            var invFrameVendors = invDbContext.FrameVendors.ToList();
            var invPhones = invDbContext.Phones.ToList();
            var invFrameBrands = invDbContext.FrameBrands.ToList();
            var invAddresses = invDbContext.Addresses.ToList();
            var frameManufacturers = ffpmDbContext.Manufacturers.ToList();
            var frameBrands = ffpmDbContext.Brands.ToList();
            var stateXrefs = ffpmDbContext.MntStates.ToList();



            CLBrandsConvert(invClBrands, invDbContext, ffpmDbContext, logger, progress, clnsBrands);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("CL Brands converted\n");
            });

            CLLensesConvert(invClLenses, invDbContext, ffpmDbContext, logger, progress, clLenses);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("CL Lenses converted\n");
            });

            clInventoryConvert(invClInventories, invDbContext, ffpmDbContext, logger, progress, clInventories);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("CL Inventory converted\n");
            });

            CPTDeptConvert(invCptDepts, invDbContext, ffpmDbContext, logger, progress, cptDepts);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("CPT Depts converted\n");
            });

            CPTMappingConvert(invCptMappings, invDbContext, ffpmDbContext, logger, progress, cptMappings);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("CPT Mappings converted\n");
            });

            CPTConvert(invCpts, invDbContext, ffpmDbContext, logger, progress, cpts);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("CPTs converted\n");
            });

            FrameCategoryConvert(invFrameCategories, invDbContext, ffpmDbContext, logger, progress, frameCategories);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Frame Categories converted\n");
            });

            FrameCollectionConvert(invFrameCollections, invDbContext, ffpmDbContext, logger, progress, frameCollections);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Frame Collections converted\n");
            });

            FrameColorConvert(invFrameColors, invDbContext, ffpmDbContext, logger, progress, frameColors);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Frame Colors converted\n");
            });

            FrameShapeConvert(invFrameShapes, invDbContext, ffpmDbContext, logger, progress, frameShapes);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Frame Shapes converted\n");
            });

            FrameStatusConvert(invFrameStatuses, invDbContext, ffpmDbContext, logger, progress, frameStatuses);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Frame Statuses converted\n");
            });

            FrameTempleConvert(invFrameTemples, invDbContext, ffpmDbContext, logger, progress, frameTemples);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Frame Temples converted\n");
            });

            FrameETypeConvert(invFrameEtypes, invDbContext, ffpmDbContext, logger, progress, frameEtypes);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Frame ETypes converted\n");
            });

            FrameFTypeConvert(invFrameFtypes, invDbContext, ffpmDbContext, logger, progress, frameFtypes);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Frame FTypes converted\n");
            });

            FrameInventoryConvert(invFrameInventories, invDbContext, ffpmDbContext, logger, progress, frameInventories, invFrames, frames);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Frame Inventories converted\n");
            });

            FrameLensColorConvert(invFrameLensColors, invDbContext, ffpmDbContext, logger, progress, frameLensColors);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Frame Lens Colors converted\n");
            });

            FrameMaterialConvert(invFrameMaterials, invDbContext, ffpmDbContext, logger, progress, frameMaterials);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Frame Materials converted\n");
            });

            FrameOrderConvert(invFrameOrders, invDbContext, ffpmDbContext, logger, progress, frameOrders);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Frame Orders converted\n");
            });

            FrameConvert(invFrames, invDbContext, ffpmDbContext, logger, progress, frames);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Frames converted\n");
            });

            FrameVendorConvert(invFrameVendors, invDbContext, ffpmDbContext, logger, progress, vendors, otherAddresses, locations);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Frame Vendors converted\n");
            });

            FrameManufacturerConvert(invFrameManufacturers, invDbContext, ffpmDbContext, logger, progress, frameManufacturers);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Frame Manufacturers converted\n");
            });

            FrameBrandConvert(invFrameBrands, invDbContext, ffpmDbContext, logger, progress, frameBrands, locations);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Frame Brands converted\n");
            });

            AddressConvert(invAddresses, invDbContext, ffpmDbContext, logger, progress, otherAddresses, vendors, stateXrefs);

            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Addresses converted\n");
            });

            PhoneConvert(invPhones, invDbContext, ffpmDbContext, logger, progress, otherAddresses);
            
            resultsBox.Invoke((MethodInvoker)delegate {
                resultsBox.AppendText("Phones converted\n");
            });
        }

        public static void CLBrandsConvert(List<Clbrand> invClBrands, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<ModelsA.ClnsBrand> clnsBrands) {
            foreach (var clBrand in invClBrands) {
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
                    if (clBrand.Active != null) {
                        if (bool.TryParse(clBrand.Active, out bool locum)) {
                            isActive = locum;
                        }
                    }

                    var invList = clnsBrands.FirstOrDefault(x => x.BrandName == clBrand.BrandName);

                    if (invList != null) {
					    var newClbrand = new Brady_s_Conversion_Program.ModelsA.ClnsBrand {
						    BrandName = TruncateString(clBrand.BrandName, 50),
						    BrandCode = TruncateString(clBrand.BrandCode, 10),
						    AddedBy = addedBy,
						    AddedDate = addedDate,
						    LocationId = locationId,
						    IsActive = isActive
					    };
                        clnsBrands.Add(newClbrand);
				    }
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the CL Brand with ID {clBrand.Id}. Error: {e.Message}");
                }
            }
            ffpmDbContext.ClnsBrands.UpdateRange(clnsBrands);
			ffpmDbContext.SaveChanges();
			clnsBrands = ffpmDbContext.ClnsBrands.ToList();
		}

        public static void clInventoryConvert(List<Clinventory> invClInventories, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<ModelsA.ClnsInventory> clnsInventories) {
            foreach (var clInventory in invClInventories) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    if (clInventory.ContactLensId <= -1) {
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

                    var invList = clnsInventories.FirstOrDefault(x => x.ContactLensId == clInventory.ContactLensId);

                    if (invList != null) {
						var newClInventory = new Brady_s_Conversion_Program.ModelsA.ClnsInventory {
							ContactLensId = clInventory.ContactLensId,
							Barcode = TruncateString(clInventory.Barcode, 8),
							InvoiceNumber = TruncateString(clInventory.InvoiceNumber, 20),
							ItemCost = TruncateString(clInventory.ItemCost, 20),
							WholesalePrice = TruncateString(clInventory.WholesalePrice, 20),
							RetailPrice = TruncateString(clInventory.RetailPrice, 20),
							Notes = clInventory.Notes,  // Notes is varchar(MAX), no truncation needed
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
                        clnsInventories.Add(newClInventory);
					}
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the CL Inventory with ID {clInventory.Id}. Error: {e.Message}");
                }
            }
			ffpmDbContext.ClnsInventories.UpdateRange(clnsInventories);
			ffpmDbContext.SaveChanges();
			clnsInventories = ffpmDbContext.ClnsInventories.ToList();
		}

        public static void CLLensesConvert(List<Cllense> invClLenses, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<ModelsA.ClnsContactLen> clLenses) {
            foreach (var clLense in invClLenses) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                int clnsBrandId = -1;
                if (clLense.ClndbrandId != null) {
                    if (int.TryParse(clLense.ClndbrandId, out int locum)) {
                        clnsBrandId = locum;
                    }
                }
                if (clnsBrandId == -1) {
                    logger.Log($"INV: INV Brand ID not found for CL Lense with ID {clLense.Id}");
                    return;
                }
                int? clnsManufacturerId = null;
                if (clLense.ClnsmanufacturerId != null) {
                    if (int.TryParse(clLense.ClnsmanufacturerId, out int locum)) {
                        clnsManufacturerId = locum;
                    }
                }
                int? clnsLensTypeId = null;
                if (clLense.ClnslensTypeId != null) {
                    if (int.TryParse(clLense.ClnslensTypeId, out int locum)) {
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
                if (clLense.Active != null) {
                    if (bool.TryParse(clLense.Active, out bool locum)) {
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
                if (clLense.IsLensFromClxcatalog != null) {
                    if (bool.TryParse(clLense.IsLensFromClxcatalog, out bool locum)) {
                        isLensFromClxCatalog = locum;
                    }
                }

                var invList = clLenses.FirstOrDefault(x => x.ClnsBrandId == clnsBrandId);

                if (invList != null) {
					var newClLens = new Brady_s_Conversion_Program.ModelsA.ClnsContactLen {
						ClnsBrandId = clnsBrandId,
						ClnsManufacturerId = clnsManufacturerId,
						Sphere = TruncateString(clLense.Sphere, 10),
						Cylinder = TruncateString(clLense.Cylinder, 10),
						Axis = TruncateString(clLense.Axis, 10),
						BaseCurve = TruncateString(clLense.BaseCurve, 10),
						Diameter = TruncateString(clLense.Diameter, 10),
						AddPower = TruncateString(clLense.AddPower, 10),
						AddPowerName = TruncateString(clLense.AddPowerName, 20),
						Multifocal = TruncateString(clLense.Multifocal, 50),
						Color = TruncateString(clLense.Color, 50),
						Upc = TruncateString(clLense.Upc, 15),
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
                        clLenses.Add(newClLens);
				}
            }
            catch (Exception e) {
                logger.Log($"INV: INV An error occurred while converting the CL Lens with ID {clLense.Id}. Error: {e.Message}");
            }
            }
			ffpmDbContext.ClnsContactLens.UpdateRange(clLenses);
			ffpmDbContext.SaveChanges();
            clLenses = ffpmDbContext.ClnsContactLens.ToList();
		}

        public static void CPTDeptConvert(List<Cptdept> invCptDepts, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<ModelsA.CptDepartment> cptDepartments) {
            foreach (var cptDept in invCptDepts) {
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
                    if (cptDept.Active != null && cptDept.Active.ToLower() == "yes" || cptDept.Active == "1") {
                        active = true;
                    }
                    string sortNumber = "";
                    if (cptDept.SortNumber != null) {
                        sortNumber = cptDept.SortNumber;
                    } // max size here is 3. it is a number in string form.

                    var invList = cptDepartments.FirstOrDefault(x => x.Code == code);

                    if (invList != null) {
						var newCptdept = new Brady_s_Conversion_Program.ModelsA.CptDepartment {
							Code = TruncateString(code, 10),
							Description = TruncateString(description, 500),
							LocationId = locationId,
							Active = active,
							SortNumber = TruncateString(sortNumber, 3)
						};
                        cptDepartments.Add(newCptdept);
					}
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the CPT Dept with ID {cptDept.Id}. Error: {e.Message}");
                }
            }
		    ffpmDbContext.CptDepartments.UpdateRange(cptDepartments);
            ffpmDbContext.SaveChanges();
            cptDepartments = ffpmDbContext.CptDepartments.ToList();
        }

        public static void CPTMappingConvert(List<Cptmapping> invCptMappings, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<ModelsA.CptGroupMapping> cptMappings) {
            foreach (var cptMapping in invCptMappings) {
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
                    if (cptMapping.Active != null && cptMapping.Active.ToLower() == "yes" || cptMapping.Active == "1") {
                        Active = true;
                    }
                    else if (cptMapping.Active != null && cptMapping.Active.ToLower() == "no") {
                        Active = false;
                    }

                    var invList = cptMappings.FirstOrDefault(x => x.CptId == cptId && x.GroupId == groupId);

                    if (invList != null) {
					    var newCptmapping = new Brady_s_Conversion_Program.ModelsA.CptGroupMapping {
						    CptId = cptId,
						    GroupId = groupId,
						    LocationId = locationId,
						    Active = Active
					    };
                        cptMappings.Add(newCptmapping);
			        }
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the CPT Mapping with ID {cptMapping.Id}. Error: {e.Message}");
                }
            }
			ffpmDbContext.CptGroupMappings.UpdateRange(cptMappings);
			ffpmDbContext.SaveChanges();
			cptMappings = ffpmDbContext.CptGroupMappings.ToList();
		}

        public static void CPTConvert(List<Cpt> invCpts, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<ModelsA.Cptid> cptIds) {
            foreach (var cpt in invCpts) {
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
                    if (cpt.Active != null && cpt.Active.ToLower() == "yes" || cpt.Active == "1") {
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
                    if (cpt.Taxable != null && cpt.Taxable.ToLower() == "yes" || cpt.Taxable == "1") {
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
                    if (cpt.UseClianumber != null && cpt.UseClianumber.ToLower() == "yes" || cpt.UseClianumber == "1") {
                        useCliaNumber = true;
                    }
                    int units = -1;
                    if (cpt.Units != null) {
                        if (int.TryParse(cpt.Units, out int locum)) {
                            units = locum;
                        }
                    }
                    bool ndcActive = false;
                    if (cpt.Ndcactive != null && cpt.Ndcactive.ToLower() == "yes" || cpt.Ndcactive == "1") {
                        ndcActive = true;
                    }
                    decimal? ndcCost = null;
                    if (cpt.Ndccost != null) {
                        if (decimal.TryParse(cpt.Ndccost, out decimal locum)) {
                            ndcCost = locum;
                        }
                    }
                    int? ndcUnitsMeasurementId = null;
                    if (cpt.NdcunitsMeasurementId != null) {
                        if (int.TryParse(cpt.NdcunitsMeasurementId, out int locum)) {
                            ndcUnitsMeasurementId = locum;
                        }
                    }
                    decimal? ndcQuantity = null;
                    if (cpt.Ndcquantity != null) {
                        if (decimal.TryParse(cpt.Ndcquantity, out decimal locum)) {
                            ndcQuantity = locum;
                        }
                    }
                    bool autoUpdateReferringProvider = false;
                    if (cpt.AutoUpdateReferringProvider != null && cpt.AutoUpdateReferringProvider.ToLower() == "yes" || cpt.AutoUpdateReferringProvider == "1") {
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

                    var invList = cptIds.FirstOrDefault(x => x.Cpt == cpt.Cpt1);

                    if (invList != null) {
					    var newCpt = new Brady_s_Conversion_Program.ModelsA.Cptid {
						    Cpt = cpt.Cpt1,
						    Description = TruncateString(cpt.Description, 250),
						    SortOrder = sortOrder,
						    Active = active,
						    LocationId = locationId,
						    Fee = fee,
						    Taxable = taxable,
						    DepartmentId = departmentId,
						    TypeOfServiceId = typeOfServiceId,
						    TaxTypeId = taxTypeId,
						    PrivateStatementDescription = TruncateString(privateStatementDescription, 250),
						    AlternateCode = TruncateString(alternateCode, 20),
						    UseClianumber = useCliaNumber,
						    Units = units,
						    NdcActive = ndcActive,
						    NdcCost = ndcCost,
						    NdcCode = TruncateString(cpt.Ndccode, 11),
						    NdcUnitsMeasurementId = ndcUnitsMeasurementId,
						    NdcQuantity = ndcQuantity,
						    AutoUpdateReferringProvider = autoUpdateReferringProvider
					    };
                        cptIds.Add(newCpt);
				    }
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the CPT with ID {cpt.Id}. Error: {e.Message}");
                }
            }
			ffpmDbContext.Cptids.UpdateRange(cptIds);
			ffpmDbContext.SaveChanges();
			cptIds = ffpmDbContext.Cptids.ToList();
		}

        public static void FrameCategoryConvert(List<ModelsD.FrameCategory> invFrameCategories, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<ModelsA.FrameCategory> frameCategories) {
            foreach (var frameCategory in invFrameCategories) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    string categoryName = "";
                    if (frameCategory.CategoryName != null) {
                        categoryName = frameCategory.CategoryName;
                    }
                    bool? active = null;
                    if (frameCategory.Active != null && frameCategory.Active.ToLower() == "yes" || frameCategory.Active == "1") {
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

                    var invList = frameCategories.FirstOrDefault(x => x.CategoryName == categoryName);

                    if (invList != null) {
						var newFrameCategory = new Brady_s_Conversion_Program.ModelsA.FrameCategory {
							CategoryName = TruncateString(categoryName, 150),
							CategoryDescription = TruncateString(frameCategory.CategoryDescription, 250),
							Active = active,
							SortOrder = sortOrder,
							LocationId = locationId
						};
                        frameCategories.Add(newFrameCategory);
					}
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame Category with ID {frameCategory.Id}. Error: {e.Message}");
                }
            }
            ffpmDbContext.FrameCategories.UpdateRange(frameCategories);
			ffpmDbContext.SaveChanges();
			frameCategories = ffpmDbContext.FrameCategories.ToList();
		}

        public static void FrameCollectionConvert(List<ModelsD.FrameCollection> invFrameCollections, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<ModelsA.FrameCollection> frameCollections) {
            foreach (var frameCollection in invFrameCollections) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    string collectionName = "";
                    if (frameCollection.CollectionName != null) {
                        collectionName = frameCollection.CollectionName;
                    }
                    bool active = false;
                    if (frameCollection.Active != null && frameCollection.Active.ToLower() == "yes" || frameCollection.Active == "1") {
                        active = true;
                    }
                    long locationId = -1;
                    if (frameCollection.LocationId != null) {
                        if (long.TryParse(frameCollection.LocationId, out long locum)) {
                            locationId = locum;
                        }
                    }

                    var invList = frameCollections.FirstOrDefault(x => x.CollectionName == collectionName);

                    if (invList != null) {
						var newFrameCollection = new Brady_s_Conversion_Program.ModelsA.FrameCollection {
							CollectionName = TruncateString(collectionName, 250),
							Active = active,
							LocationId = locationId
						};
						frameCollections.Add(newFrameCollection);
					}
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame Collection with ID {frameCollection.Id}. Error: {e.Message}");
                }
            }
			ffpmDbContext.FrameCollections.UpdateRange(frameCollections);
			ffpmDbContext.SaveChanges();
			frameCollections = ffpmDbContext.FrameCollections.ToList();
		}

        public static void FrameColorConvert(List<ModelsD.FrameColor> invFrameColors, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<ModelsA.FrameColor> frameColors) {
            foreach (var frameColor in invFrameColors) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    bool active = false;
                    if (frameColor.Active != null && frameColor.Active.ToLower() == "yes" || frameColor.Active == "1") {
                        active = true;
                    }
                    long locationId = -1;
                    if (frameColor.LocationId != null) {
                        if (long.TryParse(frameColor.LocationId, out long locum)) {
                            locationId = locum;
                        }
                    }

                    var invList = frameColors.FirstOrDefault(x => x.ColorCode == frameColor.ColorCode);

                    if (invList != null) {
					    var newFrameColor = new Brady_s_Conversion_Program.ModelsA.FrameColor {
						    ColorCode = TruncateString(frameColor.ColorCode, 50),
						    ColorDescription = TruncateString(frameColor.ColorDescription, 150),
						    Active = active,
						    LocationId = locationId
					    };
                        frameColors.Add(newFrameColor);
			        }
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame Color with ID {frameColor.Id}. Error: {e.Message}");
                }
            }
			ffpmDbContext.FrameColors.UpdateRange(frameColors);
            ffpmDbContext.SaveChanges();
            frameColors = ffpmDbContext.FrameColors.ToList();
		}

        public static void FrameShapeConvert(List<ModelsD.FrameShape> invFrameShapes, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<ModelsA.FrameShape> frameShapes) {
            foreach (var frameShape in invFrameShapes) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    string shape = "";
                    if (frameShape.FrameShape1 != null) {
                        shape = frameShape.FrameShape1;
                    }
                    bool active = false;
                    if (frameShape.Active != null && frameShape.Active.ToLower() == "yes" || frameShape.Active == "1") {
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
                        invList.ShapeDescription = TruncateString(frameShape.ShapeDescription, 250);
                        invList.Active = active;
                        invList.SortOrder = sortOrder;
                        invList.LocationId = locationId;
                        ffpmDbContext.SaveChanges();
                        return;
                    }


                    var newFrameShape = new Brady_s_Conversion_Program.ModelsA.FrameShape {
                        FrameShape1 = TruncateString(shape, 50),
                        ShapeDescription = TruncateString(frameShape.ShapeDescription, 250),
                        Active = active,
                        SortOrder = sortOrder,
                        LocationId = locationId
                    };
                    ffpmDbContext.FrameShapes.Add(newFrameShape);

                    ffpmDbContext.SaveChanges();
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame Shape with ID {frameShape.Id}. Error: {e.Message}");
                }
            }
            ffpmDbContext.FrameShapes.UpdateRange(frameShapes);
			ffpmDbContext.SaveChanges();
			frameShapes = ffpmDbContext.FrameShapes.ToList();
		}

        public static void FrameStatusConvert(List<ModelsD.FrameStatus> invFrameStatuses, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
			List<ModelsA.FrameStatus> frameStatuses) {
            foreach (var frameStatus in invFrameStatuses) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    string status = "";
                    if (frameStatus.OldStatusId != null) {
                        status = frameStatus.OldStatusId;
                    }

                    var invList = ffpmDbContext.FrameStatuses.FirstOrDefault(x => x.Status == status);

                    if (invList != null) {
                        invList.Description = TruncateString(frameStatus.Description, 100);
                        invList.LabCode = TruncateString(frameStatus.LabCode, 25);
                        ffpmDbContext.SaveChanges();
                        return;
                    }

                    var newFrameStatus = new Brady_s_Conversion_Program.ModelsA.FrameStatus {
                        Status = TruncateString(status, 100),
                        Description = TruncateString(frameStatus.Description, 100),
                        LabCode = TruncateString(frameStatus.LabCode, 25)
                    };
                    ffpmDbContext.FrameStatuses.Add(newFrameStatus);

                    ffpmDbContext.SaveChanges();
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame Status with ID {frameStatus.Id}. Error: {e.Message}");
                }
            }
			ffpmDbContext.FrameStatuses.UpdateRange(frameStatuses);
			ffpmDbContext.SaveChanges();
			frameStatuses = ffpmDbContext.FrameStatuses.ToList();
		}

        public static void FrameTempleConvert(List<ModelsD.FrameTemple> invFrameTemples, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
			List<ModelsA.FrameTempleStyle> frameTemples) {
            foreach (var frameTemple in invFrameTemples) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    string temple = "";
                    if (frameTemple.OldTempleId != null) {
                        temple = frameTemple.OldTempleId;
                    }

                    var invList = ffpmDbContext.FrameTempleStyles.FirstOrDefault(x => x.Temple == temple);

                    if (invList != null) {
                        invList.Description = TruncateString(frameTemple.Description, 100);
                        invList.LabCode = TruncateString(frameTemple.LabCode, 25);
                        ffpmDbContext.SaveChanges();
                        return;
                    }

                    var newFrameTemple = new Brady_s_Conversion_Program.ModelsA.FrameTempleStyle {
                        Temple = TruncateString(temple, 100),
                        Description = TruncateString(frameTemple.Description, 100),
                        LabCode = TruncateString(frameTemple.LabCode, 25)
                    };
                    ffpmDbContext.FrameTempleStyles.Add(newFrameTemple);

                    ffpmDbContext.SaveChanges();
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame Temple with ID {frameTemple.Id}. Error: {e.Message}");
                }
            }
			ffpmDbContext.FrameTempleStyles.UpdateRange(frameTemples);
			ffpmDbContext.SaveChanges();
			frameTemples = ffpmDbContext.FrameTempleStyles.ToList();
		}

        public static void FrameETypeConvert(List<ModelsD.FrameEtype> invFrameETypes, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
			List<ModelsA.FrameEtype> frameEtypes) {
            foreach (var frameEType in invFrameETypes) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    string eType = "";
                    if (frameEType.OldEtypeId != null) {
                        eType = frameEType.OldEtypeId;
                    }

                    var invList = ffpmDbContext.FrameEtypes.FirstOrDefault(x => x.Etype == eType);

                    if (invList != null) {
                        invList.Description = TruncateString(frameEType.Description, 100);
                        invList.LabCode = TruncateString(frameEType.LabCode, 25);
                        ffpmDbContext.SaveChanges();
                        return;
                    }

                    var newFrameEType = new Brady_s_Conversion_Program.ModelsA.FrameEtype {
                        Etype = TruncateString(eType, 100),
                        Description = TruncateString(frameEType.Description, 100),
                        LabCode = TruncateString(frameEType.LabCode, 25)
                    };
                    ffpmDbContext.FrameEtypes.Add(newFrameEType);

                    ffpmDbContext.SaveChanges();
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame EType with ID {frameEType.Id}. Error: {e.Message}");
                }
            }
			ffpmDbContext.FrameEtypes.UpdateRange(frameEtypes);
			ffpmDbContext.SaveChanges();
			frameEtypes = ffpmDbContext.FrameEtypes.ToList();
		}

        public static void FrameFTypeConvert(List<ModelsD.FrameFtype> invFrameFTypes, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
			List<ModelsA.FrameFtype> frameFtypes) {
            foreach (var frameFType in invFrameFTypes) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    string fType = "";
                    if (frameFType.OldFtypeId != null) {
                        fType = frameFType.OldFtypeId;
                    }

                    var invList = frameFtypes.FirstOrDefault(x => x.Ftype == fType);

                    if (invList != null) {
						var newFrameFType = new Brady_s_Conversion_Program.ModelsA.FrameFtype {
							Ftype = TruncateString(fType, 100),
							Description = TruncateString(frameFType.Description, 100),
							LabCode = TruncateString(frameFType.LabCode, 25)
						};
                        frameFtypes.Add(newFrameFType);
					}
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame FType with ID {frameFType.Id}. Error: {e.Message}");
                }
            }
			ffpmDbContext.FrameFtypes.UpdateRange(frameFtypes);
			ffpmDbContext.SaveChanges();
			frameFtypes = ffpmDbContext.FrameFtypes.ToList();
		}

        public static void FrameInventoryConvert(List<ModelsD.FrameInventory> invFrameInventories, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
			List<ModelsA.Inventory> frameInventories, List<ModelsD.Frame> invFrames, List<ModelsA.Frame> frames) {
            foreach (var frameInventory in invFrameInventories) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    var convFrame = invFrames.FirstOrDefault(f => f.Id.ToString() == frameInventory.OldFrameId);
                    if (convFrame == null) {
                        logger.Log($"INV: INV Frame not found for Frame Inventory with ID {frameInventory.Id}");
                        return;
                    }
                    var ffpmFrame = frames.FirstOrDefault(x => x.Upc == convFrame.Upc);
                    if (ffpmFrame == null) {
                        logger.Log($"INV: INV Frame not found for Frame Inventory with ID {frameInventory.Id}");
                        return;
                    }
                    long locationID = -1;
                    if (frameInventory.OldLocationId != null) {
                        if (long.TryParse(frameInventory.OldLocationId, out long locum)) {
                            locationID = locum;
                        }
                    }
                    int? quantityOrdered = null;
                    if (frameInventory.QuantityOrdered != null) {
                        if (int.TryParse(frameInventory.QuantityOrdered, out int locum)) {
                            quantityOrdered = locum;
                        }
                    }
                    decimal? cost = null;
                    if (frameInventory.Cost != null) {
                        if (decimal.TryParse(frameInventory.Cost, out decimal locum)) {
                            cost = locum;
                        }
                    }
                    decimal? wholesale = null;
                    if (frameInventory.WholeSale != null) {
                        if (decimal.TryParse(frameInventory.WholeSale, out decimal locum)) {
                            wholesale = locum;
                        }
                    }
                    decimal? retail = null;
                    if (frameInventory.Retail != null) {
                        if (decimal.TryParse(frameInventory.Retail, out decimal locum)) {
                            retail = locum;
                        }
                    }
                    int? received = null;
                    if (frameInventory.Received != null) {
                        if (int.TryParse(frameInventory.Received, out int locum)) {
                            received = locum;
                        }
                    }
                    int? onHand = null;
                    if (frameInventory.OnHand != null) {
                        if (int.TryParse(frameInventory.OnHand, out int locum)) {
                            onHand = locum;
                        }
                    }
                    int? dispensed = null;
                    if (frameInventory.Dispensed != null) {
                        if (int.TryParse(frameInventory.Dispensed, out int locum)) {
                            dispensed = locum;
                        }
                    }
                    int? returnedToVendor = null;
                    if (frameInventory.ReturnedToVendor != null) {
                        if (int.TryParse(frameInventory.ReturnedToVendor, out int locum)) {
                            returnedToVendor = locum;
                        }
                    }
                    int? scrapped = null;
                    if (frameInventory.Scrapped != null) {
                        if (int.TryParse(frameInventory.Scrapped, out int locum)) {
                            scrapped = locum;
                        }
                    }
                    int? returnedByCustomer = null;
                    if (frameInventory.ReturnedByCustomer != null) {
                        if (int.TryParse(frameInventory.ReturnedByCustomer, out int locum)) {
                            returnedByCustomer = locum;
                        }
                    }
                    int? lost = null;
                    if (frameInventory.Lost != null) {
                        if (int.TryParse(frameInventory.Lost, out int locum)) {
                            lost = locum;
                        }
                    }
                    int? donation = null;
                    if (frameInventory.Donation != null) {
                        if (int.TryParse(frameInventory.Donation, out int locum)) {
                            donation = locum;
                        }
                    }
                    bool? consignment = null;
                    if (frameInventory.Consignment != null && frameInventory.Consignment.ToLower() == "yes" || frameInventory.Consignment == "1") {
                        consignment = true;
                    }
                    else if (frameInventory.Consignment != null && frameInventory.Consignment.ToLower() == "no" || frameInventory.Consignment == "0") {
                        consignment = false;
                    }
                    int? transferredIn = null;
                    if (frameInventory.TransferredIn != null) {
                        if (int.TryParse(frameInventory.TransferredIn, out int locum)) {
                            transferredIn = locum;
                        }
                    }
                    int? transferredOut = null;
                    if (frameInventory.TransferredOut != null) {
                        if (int.TryParse(frameInventory.TransferredOut, out int locum)) {
                            transferredOut = locum;
                        }
                    }
                    DateTime? invoiceDate = null;
                    if (frameInventory.InvoiceDate != null) {
                        if (DateTime.TryParseExact(frameInventory.InvoiceDate, dateFormats,
                            CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out DateTime locum)) {
                            invoiceDate = locum;
                        }
                    }
                    bool? validInventory = null;
                    if (frameInventory.ValidInventory != null && frameInventory.ValidInventory.ToLower() == "yes" || frameInventory.ValidInventory == "1") {
                        validInventory = true;
                    }
                    else if (frameInventory.ValidInventory != null && frameInventory.ValidInventory.ToLower() == "no" || frameInventory.ValidInventory == "0") {
                        validInventory = false;
                    }
                    DateTime? dateAdded = null;
                    if (frameInventory.DateAdded != null) {
                        if (DateTime.TryParseExact(frameInventory.DateAdded, dateFormats,
                                                   CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out DateTime locum)) {
                            dateAdded = locum;
                        }
                    }

                    var newInventory = new Brady_s_Conversion_Program.ModelsA.Inventory {
                        FrameId = ffpmFrame.FrameId,
                        LocationId = locationID,
                        InvoiceNumber = TruncateString(frameInventory.InvoiceNumber, 20),
                        QuantityOrdered = quantityOrdered,
                        Cost = cost,
                        WholeSale = wholesale,
                        Retail = retail,
                        Received = received,
                        OnHand = onHand,
                        Dispensed = dispensed,
                        ReturnedToVendor = returnedToVendor,
                        Scrapped = scrapped,
                        ReturnedByCustomer = returnedByCustomer,
                        Lost = lost,
                        Donation = donation,
                        Consignment = consignment,
                        TransferredIn = transferredIn,
                        TransferredOut = transferredOut,
                        Note = frameInventory.Note,
                        InvoiceDate = invoiceDate,
                        ValidInventory = validInventory,
                        DateAdded = dateAdded
                    };
                    frameInventories.Add(newInventory);
				}
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame Inventory with ID {frameInventory.Id}. Error: {e.Message}");
                }
            }
            ffpmDbContext.Inventories.UpdateRange(frameInventories);
			ffpmDbContext.SaveChanges();
			frameInventories = ffpmDbContext.Inventories.ToList();
		}

        public static void FrameLensColorConvert(List<ModelsD.FrameLensColor> invFrameLensColors, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
			List<ModelsA.FrameDblensColor> frameLensColors) {
            foreach (var frameLensColor in invFrameLensColors) {
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

                    var invList = frameLensColors.FirstOrDefault(x => x.ColorCode == colorCode);

                    if (invList != null) {
					    var newFrameLensColor = new Brady_s_Conversion_Program.ModelsA.FrameDblensColor {
						    ColorCode = TruncateString(colorCode, 50),
						    ColorDescription = TruncateString(colorDescription, 150),
						    StatusId = statusId,
						    LocationId = locationId
					    };
					    frameLensColors.Add(newFrameLensColor);
				    }
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame Lens Color with ID {frameLensColor.Id}. Error: {e.Message}");
                }
            }
			ffpmDbContext.FrameDblensColors.UpdateRange(frameLensColors);
			ffpmDbContext.SaveChanges();
			frameLensColors = ffpmDbContext.FrameDblensColors.ToList();
		}

        public static void FrameMaterialConvert(List<ModelsD.FrameMaterial> invFrameMaterials, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
			List<ModelsA.FrameMaterial> frameMaterials) {
            foreach (var frameMaterial in invFrameMaterials) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    string materialName = "";
                    if (frameMaterial.MaterialName != null) {
                        materialName = frameMaterial.MaterialName;
                    }
                    bool active = false;
                    if (frameMaterial.Active != null && frameMaterial.Active.ToLower() == "yes" || frameMaterial.Active == "1") {
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

                    var invList = frameMaterials.FirstOrDefault(x => x.MaterialName == materialName);

                    if (invList != null) {
					    var newFrameMaterial = new Brady_s_Conversion_Program.ModelsA.FrameMaterial {
						    MaterialName = TruncateString(materialName, 50),
						    MaterialDescription = TruncateString(frameMaterial.MaterialDescription, 250),
						    Active = active,
						    SortOrder = sortOrder,
						    LocationId = locationId
					    };
					    frameMaterials.Add(newFrameMaterial);
				    }
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame Material with ID {frameMaterial.Id}. Error: {e.Message}");
                }
            }
			ffpmDbContext.FrameMaterials.UpdateRange(frameMaterials);
			ffpmDbContext.SaveChanges();
			frameMaterials = ffpmDbContext.FrameMaterials.ToList();
		}

        public static void FrameMountConvert(List<ModelsD.FrameMount> invFrameMounts, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
			List<ModelsA.FrameMount> frameMounts) {
            foreach (var frameMount in invFrameMounts) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    string frameMount1 = "";
                    if (frameMount.FrameMount1 != null) {
                        frameMount1 = frameMount.FrameMount1;
                    }
                    bool active = false;
                    if (frameMount.Active != null && frameMount.Active.ToLower() == "yes" || frameMount.Active == "1") {
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

                    var invList = frameMounts.FirstOrDefault(x => x.FrameMount1 == frameMount1);

                    if (invList != null) {
					    var newFrameMount = new Brady_s_Conversion_Program.ModelsA.FrameMount {
						    FrameMount1 = TruncateString(frameMount1, 50),
						    MountDescription = TruncateString(frameMount.MountDescription, 250),
						    Active = active,
						    SortOrder = sortOrder,
						    LocationId = locationId
					    };
					    frameMounts.Add(newFrameMount);
				    }
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame Mount with ID {frameMount.Id}. Error: {e.Message}");
                }
            }
			ffpmDbContext.FrameMounts.UpdateRange(frameMounts);
			ffpmDbContext.SaveChanges();
            frameMounts = ffpmDbContext.FrameMounts.ToList();
		}

        public static void FrameOrderConvert(List<ModelsD.FrameOrder> invFrameOrders, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
			List<ModelsA.FrameOrderInfo> frameOrders) {
            foreach (var frameOrder in invFrameOrders) {
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
                    if (frameOrder.IsLmsframe != null && frameOrder.IsLmsframe.ToLower() == "yes" || frameOrder.Active == "1") {
                        isLmsFrame = true;
                    }

                    // since it is orders, there can be multiple that are the exact same
                    // because of this, I wont check for duplicate orders



                    var newFrameOrder = new Brady_s_Conversion_Program.ModelsA.FrameOrderInfo {
                        Name = TruncateString(name, 50),
                        MaterialId = materialId,
                        StatusId = statusId,
                        CptId = cptId,
                        EtypId = eTypId,
                        FtypId = fTypId,
                        Color = TruncateString(color, 20),
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
                    frameOrders.Add(newFrameOrder);
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame Order with ID {frameOrder.Id}. Error: {e.Message}");
                }
            }
			ffpmDbContext.FrameOrderInfos.UpdateRange(frameOrders);
			ffpmDbContext.SaveChanges();
			frameOrders = ffpmDbContext.FrameOrderInfos.ToList();
		}

        public static void FrameConvert(List<ModelsD.Frame> invFrames, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
			List<ModelsA.Frame> frames) {
            foreach (var frame in invFrames) {
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
                    if (frame.StyleNew != null && frame.StyleNew.ToLower() == "yes" || frame.StyleNew == "1") {
                        styleNew = true;
                    }
                    else if (frame.StyleNew != null && frame.StyleNew.ToLower() == "no") {
                        styleNew = false;
                    }
                    bool? changedPrice = null;
                    if (frame.ChangedPrice != null && frame.ChangedPrice.ToLower() == "yes" || frame.ChangedPrice == "1") {
                        changedPrice = true;
                    }
                    else if (frame.ChangedPrice != null && frame.ChangedPrice.ToLower() == "no") {
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
                    if (frame.Active != null && frame.Active.ToLower() == "yes" || frame.Active == "1") {
                        active = true;
                    }
                    else if (frame.Active != null && frame.Active.ToLower() == "no") {
                        active = false;
                    }
                    DateTime? dateAdded = null;
                    if (frame.DateAdded != null) {
                        if (DateTime.TryParseExact(frame.DateAdded, dateFormats,
                            CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out DateTime locum)) {
                            dateAdded = locum;
                        }
                    }
                    DateTime? lastUpdated = null;
                    if (frame.LastUpdated != null) {
                        if (DateTime.TryParseExact(frame.LastUpdated, dateFormats,
                            CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out DateTime locum)) {
                            lastUpdated = locum;
                        }
                    }

                    // how do we know if a frame is a duplicate?




                    var newFrame = new Brady_s_Conversion_Program.ModelsA.Frame {
                        Fpc = TruncateString(frame.Fpc, 14),
                        Upc = TruncateString(upc, 14),
                        StyleId = styleId,
                        StyleName = TruncateString(frame.StyleName, 37),
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
                        Sku = TruncateString(frame.Sku, 30),
                        YearIntroduced = TruncateString(frame.YearIntroduced, 4),
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
                    frames.Add(newFrame);
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame with ID {frame.Id}. Error: {e.Message}");
                }
            }
			ffpmDbContext.Frames.UpdateRange(frames);
			ffpmDbContext.SaveChanges();
			frames = ffpmDbContext.Frames.ToList();
		}

        public static void FrameVendorConvert(List<ModelsD.FrameVendor> invFrameVendors, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List <ModelsA.Vendor> vendors, List<DmgOtherAddress> otherAddresses, List<BillingLocation> locations) {
            foreach (var vendor in invFrameVendors) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    int? discount = null;
                    // no discount
                    int? terms = null;
                    // no terms
                    long locationId = -1;
                    var location = locations.FirstOrDefault(l => l.LocationId.ToString() == vendor.LocationId);
                    if (location != null) {
                        locationId = location.LocationId;
                    }
                    long? contactId = null;
                    // no contact
                    long? addressId = null;
                    // will assign later
                    long? manufacturerId = null;
                    // no manufacturer
                    int? statusId = null;
                    // no status

                    var origVendor = vendors.FirstOrDefault(ov => ov.VendorName == vendor.VendorName);

                    if (origVendor == null) {
                        var newVendor = new Brady_s_Conversion_Program.ModelsA.Vendor {
                            AccountNumber = TruncateString(vendor.Id.ToString(), 50),
                            VendorName = TruncateString(vendor.VendorName, 100),
                            AccountRep1 = TruncateString(vendor.VendorAccount, 255),
                            AccountRep2 = null,
                            Discount = discount,
                            Terms = terms,
                            Website = TruncateString(vendor.VendorWebSite, 250),
                            LocationId = locationId,
                            ContactId = contactId,
                            AddressId = addressId,
                            ManufacturerId = manufacturerId,
                            StatusId = statusId
                        };
                        vendors.Add(newVendor);
                    }
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame Vendor with ID {vendor.Id}. Error: {e.Message}");
                }
            }
            ffpmDbContext.Vendors.UpdateRange(vendors);
            ffpmDbContext.SaveChanges();
            vendors = ffpmDbContext.Vendors.ToList();
        }

        public static void FrameManufacturerConvert(List<ModelsD.FrameManufacturer> invFrameManufacturers, InvDbContext invDbContext, FfpmContext ffpmDbContext, 
            ILogger logger, ProgressBar progress, List<Manufacturer> frameManufacturers) {
            foreach (var frameManufacturer in invFrameManufacturers) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    long locationId = -1;
                    if (frameManufacturer.LocationId > 0) {
                        var location = frameManufacturers.FirstOrDefault(l => l.LocationId == frameManufacturer.LocationId);
                        if (location != null) {
                            locationId = location.LocationId;
                        }
                    }
                    long? contactId = frameManufacturer.ContactId;
                    long? addressId = null;
                    int? statusId = null;
                    // no statusId
                    bool? contacts = frameManufacturer.Contacts;
                    bool? frames = frameManufacturer.Frames;
                    bool? lenses = frameManufacturer.Lenses;
                    bool? misc = frameManufacturer.Misc;
                    bool? active = frameManufacturer.Active;


                    var newFrameManufacturer = new Brady_s_Conversion_Program.ModelsA.Manufacturer {
                        ManufacturerName = TruncateString(frameManufacturer.ManufacturerName, 100),
                        AccountNumber = TruncateString(frameManufacturer.AccountNumber, 50),
                        AccountRep1 = TruncateString(frameManufacturer.AccountRep1, 255),
                        AccountRep2 = TruncateString(frameManufacturer.AccountRep2, 255),
                        AccountRep3 = TruncateString(frameManufacturer.AccountRep3, 255),
                        AccountRep4 = TruncateString(frameManufacturer.AccountRep4, 255),
                        Website = TruncateString(frameManufacturer.Website, 255),
                        ContactId = contactId,
                        AddressId = addressId,
                        LocationId = locationId,
                        StatusId = statusId,
                        Contacts = contacts,
                        Frames = frames,
                        Lenses = lenses,
                        Misc = misc,
                        Active = active
                    };
                    frameManufacturers.Add(newFrameManufacturer);
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame Manufacturer with ID {frameManufacturer.Id}. Error: {e.Message}");
                }
            }
            ffpmDbContext.Manufacturers.UpdateRange(frameManufacturers);
            ffpmDbContext.SaveChanges();
            frameManufacturers = ffpmDbContext.Manufacturers.ToList();
        }

        public static void FrameBrandConvert(List<ModelsD.FrameBrand> invFrameBrands, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, 
            ProgressBar progress, List<Brand> frameBrands, List<BillingLocation> locations) {
            foreach (var frameBrand in invFrameBrands) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    if (frameBrand.Active != null && frameBrand.Active.ToLower() == "no" || frameBrand.Active == "0")
                        continue;
                    int statusId = -1;
                    // statusId doesnt seem connected to anything
                    long locationId = -1;
                    if (frameBrand.LocationId != null) {
                        var location = locations.FirstOrDefault(l => l.LocationId.ToString() == frameBrand.LocationId);
                        if (location != null) {
                            locationId = location.LocationId;
                        }
                    }

                    var origBrand = frameBrands.FirstOrDefault(fb => fb.BrandName == frameBrand.BrandName);

                    if (origBrand == null) {
                        var newFrameBrand = new Brady_s_Conversion_Program.ModelsA.Brand {
                            BrandName = TruncateString(frameBrand.BrandName, 150),
                            StatusId = statusId,
                            LocationId = locationId
                        };
                        frameBrands.Add(newFrameBrand);
                    }
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Frame Brand with ID {frameBrand.Id}. Error: {e.Message}");
                }
            }
            ffpmDbContext.Brands.UpdateRange(frameBrands);
            ffpmDbContext.SaveChanges();
            frameBrands = ffpmDbContext.Brands.ToList();
        }

        public static void AddressConvert(List<ModelsD.Address> invAddresses, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<DmgOtherAddress> otherAddresses, List<Vendor> vendors, List<MntState> stateXrefs) {
            foreach (var address in invAddresses) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    if (address.PrimaryFile == null || address.PrimaryFileId == null) {
                        continue;
                    }

                    string? zip = null;
                    if (address.Zip == null || !zipRegex.IsMatch(address.Zip)) {
                        zip = "";
                    }
                    short? stateId = null;
                    short? countryId = null;
                    if (address.State != null) {
                        var stateXref = stateXrefs.FirstOrDefault(s => s.StateCode == address.State);
                        if (stateXref != null) {
                            stateId = stateXref.StateId;
                            countryId = (short?)stateXref.CountryId;
                        }
                    }


                    // looks like the only incoming primary file is "VEND" for vendor
                    switch (address.PrimaryFile.ToLower()) {
                        default:
                        case "vend":
                            string? email = null;

                            var vendor = vendors.FirstOrDefault(v => v.AccountNumber == address.PrimaryFileId.ToString());
                            if (vendor != null) {
                                var invVendor = otherAddresses.FirstOrDefault(v => v.OwnerId == vendor.VendorId && v.OwnerType == 5);
                                if (invVendor != null)
                                    email = invVendor.Email;
                                var newAddress = new Brady_s_Conversion_Program.ModelsA.DmgOtherAddress {
                                    Address1 = TruncateString(address.Address1, 100),
                                    Address2 = TruncateString(address.Address2, 100),
                                    City = TruncateString(address.City, 50),
                                    StateId = stateId,
                                    Zip = TruncateString(zip, 10),
                                    CountryId = countryId,
                                    Email = TruncateString(email, 100),
                                    OwnerId = vendor.VendorId,
                                    OwnerType = 5
                                };
                                otherAddresses.Add(newAddress);
                            }
                            break;
                    }
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Address with ID {address.Id}. Error: {e.Message}");
                }
            }
            ffpmDbContext.DmgOtherAddresses.UpdateRange(otherAddresses);
            ffpmDbContext.SaveChanges();
            otherAddresses = ffpmDbContext.DmgOtherAddresses.ToList();
        }

        public static void PhoneConvert(List<ModelsD.Phone> invPhones, InvDbContext invDbContext, FfpmContext ffpmDbContext, ILogger logger, ProgressBar progress,
            List<DmgOtherAddress> otherAddresses) {
            foreach (var phone in invPhones) {
                progress.Invoke((MethodInvoker)delegate {
                    progress.PerformStep();
                });
                try {
                    if (phone.PrimaryFile == null || phone.PrimaryFileId !> 0) {
                        continue;
                    }
                    switch (phone.PrimaryFile.ToLower()) {
                        case "vend":
                        default:
                            var vendorAddress = otherAddresses.FirstOrDefault(v => v.AddressId == phone.PrimaryFileId);
                            if (vendorAddress != null) {
                                if (phone.Type == null) {
                                    vendorAddress.CellPhone = TruncateString(phone.PhoneNumber, 15);
                                    vendorAddress.Extension = TruncateString(phone.Extension, 10);
                                    continue;
                                }
                                switch (phone.Type.ToLower()) {
                                    case "cell":
                                        vendorAddress.CellPhone = TruncateString(phone.PhoneNumber, 15);
                                        vendorAddress.Extension = TruncateString(phone.Extension, 10);
                                        break;
                                    case "home":
                                        vendorAddress.HomePhone = TruncateString(phone.PhoneNumber, 15);
                                        vendorAddress.Extension = TruncateString(phone.Extension, 10);
                                        break;
                                    case "work":
                                        vendorAddress.WorkPhone = TruncateString(phone.PhoneNumber, 15);
                                        vendorAddress.Extension = TruncateString(phone.Extension, 10);
                                        break;
                                    default:
                                        vendorAddress.CellPhone = TruncateString(phone.PhoneNumber, 15);
                                        vendorAddress.Extension = TruncateString(phone.Extension, 10);
                                        break;
                                }
                            }
                            break;
                    }
                }
                catch (Exception e) {
                    logger.Log($"INV: INV An error occurred while converting the Phone with ID {phone.Id}. Error: {e.Message}");
                }
            }
            ffpmDbContext.DmgOtherAddresses.UpdateRange(otherAddresses);
            ffpmDbContext.SaveChanges();
            otherAddresses = ffpmDbContext.DmgOtherAddresses.ToList();
        }

        #endregion InvConversion
    }
}
