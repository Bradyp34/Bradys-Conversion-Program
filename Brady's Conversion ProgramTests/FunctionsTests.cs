using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brady_s_Conversion_Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brady_s_Conversion_Program.Tests {
    [TestClass()]
    public class FunctionsTests {
        [TestMethod()]
        public void UploadFileTest() {
            string path = "C:/Users/brady/Documents/testfiles/test.txt";
            File.Create(path); // Create a file at the path (and close it so it can be copied)
            File.WriteAllText(path, "This is a test file."); // Write to the file
            string result = Functions.UploadFile(path);
            Assert.AreEqual("UploadedFiles/test.txt", result);
            File.Delete("../../../../UploadedFiles/test.txt"); // Clean up the file
            File.Delete(path); // Clean up the file
        }
    }
}