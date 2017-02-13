using experitestClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeeTest_SparApp.Utility;

namespace SeeTest_SparApp.MySpar
{
    [TestClass]
    public class MySparOverview
    {
        private string host = "localhost";
        private int port = 8889;
        private string projectBaseDirectory = "C:\\Users\\domenf\\Google Drive\\project2";
        protected Client client = null;

        [TestInitialize()]
        public void SetupTest()
        {
            client = new Client(host, port, true);
            client.SetProjectBaseDirectory(projectBaseDirectory);
            client.SetReporter("xml", "reports", "MySpar");
            client.SetShowPassImageInReport(false);
        }

        [TestMethod]
        public void TestMySpar()
        {
            client.SetDevice(Utility.Utility.DeviceName);
            client.Launch(Utility.Utility.Activity, true, true);
            client.Click("Navigation", "MySpar", 0, 1);
            if (client.WaitForElement("MySpar", "CardNumber", 0, 60000)) {

                if (client.SwipeWhileNotFound("Down", 500, 2000, "MySpar", "CardNumber", 0, 1000, 5, false))
                {
                    // If statement
                }
                if (client.SwipeWhileNotFound("Down", 500, 2000, "MySpar", "MyCouponsTitle", 0, 1000, 5, false)) ;
                {
                    // If statement
                }
                if (client.SwipeWhileNotFound("Down", 500, 2000, "MySpar", "UseCoupon", 0, 1000, 5, false)) ;
                {
                    // If statement
                }
               
            }  else {
                client.Click("MySpar", "MyProfile", 0, 1);
                client.Click("default", "Scan", 0, 1);
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