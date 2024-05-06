using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brady_s_Conversion_Program
{
    public class Functions
    {
        public static string UploadFile(string path) {
            string newPath = "UploadedFiles/" + path.LastIndexOf("\\") + path.Length;
            try {
                File.Copy(path, newPath);
                return newPath;
            } catch (Exception e) {
                return "File Copy Failed.\n" + e + "\n";
            }
        }

        public static string ConvertToDB() {
            
            try {
                
            } catch (Exception e) {
                return "Database Upload Failed.\n" + e + "\n";
            }
            return "";
        }

        public static string ClearFiles() {
            try {
                foreach (string file in Directory.GetFiles("UploadedFiles/")) {
                    File.Delete(file);
                }
                return "Files Cleared.\n";
            } catch (Exception e) {
                return "File Clear Failed.\n" + e + "\n";
            }
        }
    }
}
