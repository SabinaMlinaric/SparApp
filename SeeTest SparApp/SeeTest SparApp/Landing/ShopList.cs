using experitestClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using SeeTest_SparApp.Utility;

namespace SeeTest_SparApp.Landing
{
    [TestClass]
    public class ShopList
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
            client.SetReporter("xml", "reports", "ShopList");
            client.SetShowPassImageInReport(false);
        }

        [TestMethod]
        public void TestShopList()
        {
           // try
           // {

                client.SetDevice(Utility.Utility.DeviceName);
                client.Launch(Utility.Utility.Activity, true, true);
                client.Click("default", "NoCard", 0, 1);
                client.Click("Boarding", "Join", 0, 1);
                client.CloseKeyboard();
                if (client.SwipeWhileNotFound("Down", 500, 2000, "Boarding", "Skip", 0, 1000, 3, true))
                {
                    // If statement
                }
                client.VerifyElementFound("TEXT", "Prebrskaj", 0);
                client.VerifyElementFound("TEXT", "Trgovine Spar in Interspar", 0);
                client.Click("Landing", "ShopsOpen", 0, 1);
                //client.WaitForElement("Landing", "Show Only Opened", 0, 6000);
                client.VerifyElementFound("TEXT", "Lokacije", 0);
                client.Click("Landing", "Show Only Opened", 0, 1);
                client.VerifyElementNotFound("Landing", "Zaprto", 0);
           // }
            //catch(Exception)
            //{

            //}

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
