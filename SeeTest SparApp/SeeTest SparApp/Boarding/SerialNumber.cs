using experitestClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeTest_SparApp.Utility;

namespace SeeTest_SparApp.Boarding
{
    [TestClass]
    public class SerialNumber
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
            client.SetReporter("xml", "reports", "SerialNumber");
            client.SetShowPassImageInReport(false);
        }

        [TestMethod]
        public void TestSerialNumber()
        {
            client.SetDevice(Utility.Utility.DeviceName);
            client.Launch(Utility.Utility.Activity, true, true);
            client.Click("LoginSerialNumber", "InsertCardNumberManually", 0, 1);
            client.ElementSendText("LoginSerialNumber", "CardNumberField", 0, "12345678");
            client.Click("Registration", "Next", 0, 1);
            client.Click("LoginSerialNumber", "RegisterDOB", 0, 1);
            string str0 = client.ElementSetProperty("LoginSerialNumber", "datePicker", 0, "date", "13.01.1988");
            client.Click("LoginSerialNumber", "V redu", 0, 1);
            client.Click("LoginSerialNumber", "Prijava", 0, 1);
            if (client.WaitForElement("LoginSerialNumber", "Email", 0, 10000))
            {
                // If statement
            }
            client.CloseKeyboard();
            client.Click("LoginSerialNumber", "Email", 0, 1);
            client.ElementSendText("LoginSerialNumber", "Email", 0, "domen.fras@gmail.com");
            client.Click("LoginSerialNumber", "RepeatEmail", 0, 1); 
            client.ElementSendText("LoginSerialNumber", "RepeatEmail", 0, "domen.fras@gmail.com"); //Doesn't work through Visual Studio
            client.ElementSendText("LoginSerialNumber", "Password", 0, "Abcd1234");
            client.ElementSendText("LoginSerialNumber", "RepeatPassword", 0, "Abcd1234");
            if (client.SwipeWhileNotFound("Down", 500, 2000, "TEXT", "Registriraj se", 0, 1000, 5, true))
            {
                // If statement
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