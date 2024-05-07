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

namespace Brady_s_Conversion_Program
{
    public class Functions
    {
        public static string ConvertToDB(string connection, string FFPMConnection, string EyeMDConnection) {
            try {
                // Using block to ensure disposal of DbContexts
                using (var sqlDbContext = new FoxfireConvContext(connection))
                using (var convDbContext = new FfpmContext(FFPMConnection))
                using (var eyeMDDbContext = new EyeMdContext(EyeMDConnection)) {
                    // Start with FFPM only, do EyeMD later

                    sqlDbContext.Database.OpenConnection();
                    convDbContext.Database.OpenConnection();
                    eyeMDDbContext.Database.OpenConnection();

                    // Optionally perform a simple operation like a 'CanConnect' check
                    if (!sqlDbContext.Database.CanConnect() ||
                        !convDbContext.Database.CanConnect() ||
                        !eyeMDDbContext.Database.CanConnect()) {
                        throw new InvalidOperationException("One or more database connections cannot be established.");
                    }


                    // Save changes if any modifications were made
                    sqlDbContext.SaveChanges();
                    convDbContext.SaveChanges();
                    eyeMDDbContext.SaveChanges();

                    // EF Core automatically handles connection closing when DbContext is disposed
                }
            }
            catch (Exception e) {
                return "Database Upload Failed.\n" + e + "\n";
            }
            return "Operation Successful";
        }
    }
}
