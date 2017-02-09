using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using experitestClient;
using System.IO;
using SeeTest_SparApp.Utility;

namespace SeeTest_SparApp.Registration
{
    [TestClass]
    public class Register_Success
    {
        private string host = "localhost";
        private int port = 8889;
        private string projectBaseDirectory = Utility.Utility.projectBaseDirectory;
        protected Client client = null;

        [TestInitialize()]
        public void SetupTest()
        {
            client = new Client(host, port, true);
            client.SetProjectBaseDirectory(projectBaseDirectory);
            client.SetReporter("xml", "reports", "Register");
            client.SetShowPassImageInReport(false);
        }

        [TestMethod]
        public void TestNoSPARCard_SkipAll()
        {
            String Username = null;
            String Surname = null;
            String DateOfBirth = null;
            String Country = null;
            String Address = null;
            String PostalNumber = null;
            String City = null;
            String PhoneNumber = null;
            String Email = null;
            String Password = null;

            StreamReader inputStream;
            try
            {
                inputStream = new StreamReader(File.OpenRead("C:\\Users\\sabinam\\workspace\\project2\\scenarios\\DDD\\Registration.csv"));
                inputStream.ReadLine();

                while (!inputStream.EndOfStream)
                {
                    String data = inputStream.ReadLine(); // Read line
                    String[] values = data.Split(','); // Split the line to an array

                    Username = values[0];
                    Surname = values[1];
                    DateOfBirth = values[2];
                    Country = values[3];
                    Address = values[4];
                    PostalNumber = values[5];
                    City = values[6];
                    PhoneNumber = values[7];
                    Email = values[8];
                    Password = values[9];

                    client.SetDevice(Utility.Utility.DeviceName);
                    client.ApplicationClearData(Utility.Utility.App);
                    client.Launch(Utility.Utility.Activity, true, true);
                    if (client.WaitForElement("default", "NoCard", 0, 60000))
                    {
                        // If statement
                    }
                    client.Click("default", "NoCard", 0, 1);
                    client.VerifyElementFound("Boarding", "Join", 0);
                    client.Click("Boarding", "Join", 0, 1);
                    client.CloseKeyboard();
                    client.ElementSendText("Registration", "Name", 0, Username);
                    client.ElementSendText("Registration", "Surname", 0, Surname);
                    client.Click("Registration", "DateOfBirth", 0, 1);
                    String str0 = client.ElementSetProperty("Registration", "DatePicker", 0, "date", DateOfBirth);
                    client.Click("Registration", "DatePicker_Done", 0, 1);
                    client.Click("Registration", "Gender", 0, 1);
                    client.Click("Registration", "Gender_Female", 0, 1);
                    client.Click("Registration", "Next", 0, 1);
                    client.CloseKeyboard();
                    client.ElementSendText("Registration", "Country", 0, Country);
                    client.ElementSendText("Registration", "Address", 0, Address);
                    client.ElementSendText("Registration", "PostalNumber", 0, PostalNumber);
                    client.ElementSendText("Registration", "City", 0, City);
                    client.Click("Registration", "Next", 0, 1);
                    client.CloseKeyboard();
                    client.ElementSendText("Registration", "PhoneNumber", 0, PhoneNumber);
                    client.ElementSendText("Registration", "Email", 0, Email);
                    client.ElementSendText("Registration", "Password", 0, Password);
                    client.ElementSendText("Registration", "RepeatPassword", 0, Password);
                    String str1 = client.ElementGetProperty("Registration", "Next", 0, "enabled");
                    Assert.AreEqual(true, Boolean.Parse(str1));

                    client.Click("Registration", "Next", 0, 1);

                }
            }
            catch (FileNotFoundException e)
            {
                // TODO Auto-generated catch block
                e.StackTrace.ToString();
            }
        }

        [TestCleanup()]
        public void TearDown()
        {
            // Generates a report of the test case.
            // For more information - https://docs.experitest.com/display/public/SA/Report+Of+Executed+Test
            client.GenerateReport(false);
            // Releases the client so that other clients can approach the agent in the near future. 
            client.ReleaseClient();
        }
    }
}