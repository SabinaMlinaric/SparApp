using experitestClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeeTest_SparApp.Boarding
{
    [TestClass]
    public class NoSPARCard
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
            client.SetReporter("xml", "reports", "NoSPARCard");
            client.SetShowPassImageInReport(false);
        }

        [TestMethod]
        public void TestNoSPARCard_SkipAll()
        {
            client.SetDevice(Utility.Utility.DeviceName);
            client.ApplicationClearData(Utility.Utility.App);
            client.Launch(Utility.Utility.Activity, true, true);
            if (client.WaitForElement("default", "NoCard", 0, 60000))
            {
                // If statement
            }
            client.Click("default", "NoCard", 0, 1);
            client.VerifyElementFound("NATIVE", "text=Postani član SPAR plus", 0);
            client.VerifyElementFound("NATIVE", "text=Ekskluzivni kuponi in ugodnosti", 0);
            client.VerifyElementFound("NATIVE", "text=Zbiranje dobropisa na kartici", 0);
            client.VerifyElementFound("NATIVE", "text=Dostop do SPAR plus kartice kar na telefonu", 0);
            client.VerifyElementFound("Boarding", "Join", 0);
            client.Click("Boarding", "Skip", 0, 1);
            client.VerifyElementFound("NATIVE", "text=Ne spreglejte kuponov in promocij", 0);
            client.VerifyElementFound("NATIVE", "text=Želite biti pravočasno obveščeni o kuponih ugodnosti, tedenski letakih in drugih aktualnih promocijah?", 0);
            client.VerifyElementFound("Boarding", "Boarding_Step1Allow", 0);
            client.Click("Boarding", "Skip_Step1", 0, 1);
            client.VerifyElementFound("NATIVE", "text=Kje je najbližji Spar?", 0);
            client.VerifyElementFound("NATIVE", "text=Preverite odpiralni čas vaše najbližje trgovine Spar ter bodite obveščeni o inventurah in posebnih odpiralnih časih.", 0);
            client.VerifyElementFound("Boarding", "Boarding_Step2Allow", 0);
            client.Click("Boarding", "Skip_Step2", 0, 1);
            client.VerifyElementFound("NATIVE", "text=SPAR plus kartica vedno pri roki", 0);
            client.VerifyElementFound("NATIVE", "text=Namestite si SPAR plus kartico v Center za obvestila kjer vam bo dostopna z enim gibom.", 0);
            client.VerifyElementFound("Boarding", "Boarding_Step3Finish", 0);
            client.Click("Boarding", "Boarding_Step3Finish", 0, 1);
            client.VerifyElementFound("Navigation", "Landing", 0);
            client.VerifyElementFound("Navigation", "MySpar", 0);
            client.VerifyElementFound("Navigation", "ShoppingLists", 0);
        }

        [TestMethod]
        public void testNoCard_AllowNotificationsAndLocation()
        {
            client.SetShowPassImageInReport(false);
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
            client.VerifyElementFound("NATIVE", "text=Registracija", 0);
            client.Click("default", "Back", 0, 1);
            client.Click("Boarding", "Skip", 0, 1);
            client.Click("Boarding", "Boarding_Step1Allow", 0, 1);
            if (client.WaitForElement("Boarding", "Boarding_Step2Allow", 0, 30000))
            {
                // If statement
            }
            client.Click("Boarding", "Boarding_Step2Allow", 0, 1);
            client.Click("default", "Permission_Allow", 0, 1);
            client.Click("Boarding", "Boarding_Step3Finish", 0, 1);
            client.VerifyElementFound("Navigation", "Landing", 0);
            client.VerifyElementFound("Navigation", "MySpar", 0);
            client.VerifyElementFound("Navigation", "ShoppingLists", 0);
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