﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Brady_s_Conversion_Program.Form1;
using System.Data.SqlClient;
using Brady_s_Conversion_Program.Models;

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

                using (SqlConnection sqlConnection = new SqlConnection(connection)) {
                    using (SqlConnection convDatabase = new SqlConnection(FFPMConnection)) {
                        using (SqlConnection EyeMD = new SqlConnection(EyeMDConnection)) {
                            // Open the connection
                            sqlConnection.Open();
                            convDatabase.Open();
                            EyeMD.Open();

                            // Perform your SQL operations here
                            // For example, you can execute a SQL command using SqlCommand

                            // Close the connection
                            sqlConnection.Close();
                            convDatabase.Close();
                            EyeMD.Close();
                        }   
                    }
                }
            }
            catch (Exception e) {
                return "Database Upload Failed.\n" + e + "\n";
            }
            return "";
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
