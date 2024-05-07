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
            FFPMBatchRunPatients(convDbContext, ffpmDbContext);
            
        }

        public static void FFPMBatchRunPatients(FoxfireConvContext convDbContext, FfpmContext ffpmDbContext) {
            var patients = convDbContext.Patients.ToList();

            int batchSize = 100; // Define an appropriate batch size
            int numberOfRecords = convDbContext.Patients.Count();
            int numberOfBatches = (numberOfRecords / batchSize) + (numberOfRecords % batchSize > 0 ? 1 : 0);

            for (int batchNumber = 0; batchNumber < numberOfBatches; batchNumber++) {
                var patientBatch = convDbContext.Patients.Skip(batchNumber * batchSize).Take(batchSize).ToList();
                // Process each batch as shown above
                using (var transaction = ffpmDbContext.Database.BeginTransaction()) {
                    try {
                        foreach (var patient in patientBatch) {
                            // Convert patient data
                            PatientConvert(patient, ffpmDbContext);
                        }

                        ffpmDbContext.SaveChanges();
                        transaction.Commit();
                    } catch (Exception e) {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
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

        public static void PatientConvert(Models.Patient patient, FfpmContext ffpmDbContext) {
            var newPatient = new Brady_s_Conversion_Program.ModelsA.DmgPatient {
                // Map properties
            };
        }
    }
}
