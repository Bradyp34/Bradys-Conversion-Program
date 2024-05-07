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

namespace Brady_s_Conversion_Program
{
    public class Functions
    {
        public static string UploadFile(string path) {
            string fileName = Path.GetFileName(path);
            string newPath = "UploadedFiles/" + fileName;
            try {
                File.Copy(path, "../../../../" + newPath);
                return newPath;
            }
            catch (Exception e) {
                return "File Copy Failed.\n" + e + "\n";
            }
        }

        public static string ConvertToDB(string connection, string FFPMConnection, string EyeMDConnection) {
            try {
                // Using block to ensure disposal of DbContexts
                using (var sqlDbContext = new FoxfireConvContext(connection))
                using (var convDbContext = new FfpmContext(FFPMConnection))
                using (var eyeMDDbContext = new EyeMdContext(EyeMDConnection)) {
                    // Perform your data operations here using EF Core
                    // Example: querying, updating, inserting via the DbContexts
                    // You might perform operations like:
                    // var data = sqlDbContext.YourDbSet.Where(x => x.Condition).ToList();

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



        public static string ClearFiles() {
            try {
                foreach (string file in Directory.GetFiles("../../../../UploadedFiles/")) {
                    File.Delete(file);
                }

                return "Files Cleared.\n";
            } catch (Exception e) {
                return "File Clear Failed.\n" + e + "\n";
            }
        }

        public static string OpenDialogBox() {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                string filePath = dialog.FileName;
                return filePath;
            }
            else {
                return "File Copy Failed.";
            }
        }

    }
}
