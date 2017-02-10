using experitestClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeTest_SparApp.Utility;

namespace SeeTest_SparApp.Landing
{
    [TestClass]
    class JedelBi
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
            client.SetReporter("xml", "reports", "JedelBi");
            client.SetShowPassImageInReport(false);
        }

        [TestMethod]
        public void TestJedelBi()
        {
            client.SetDevice(Utility.Utility.DeviceName);
            client.Launch(Utility.Utility.Activity, true, true);
            client.Click("default", "NoCard", 0, 1);
            client.Click("Boarding", "Join", 0, 1);
            client.CloseKeyboard();
            if (client.SwipeWhileNotFound("Down", 500, 2000, "Boarding", "Skip", 0, 1000, 3, true))
            {
                // If statement
            }
            if (client.SwipeWhileNotFound("Down", 500, 2000, "Landing", "JedelBi_Img", 0, 1000, 5, true))
            {
                // If statement
            }
            client.VerifyElementFound("Landing", "JedelBi_Title", 0);
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