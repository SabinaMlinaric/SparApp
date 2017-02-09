using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using experitestClient;
using SeeTest_SparApp.Utility;

namespace SeeTest_SparApp.FirstTimeUse
{
    class NoSPARCard
    {
        private string host = "localhost";
        private int port = 8889;
        private string projectBaseDirectory = Utility.Utility.projectBaseDirectory;
        protected Client client = null;

        [SetUp]
        public void SetupTest()
        {
            client = new Client(host, port, true);
            client.SetProjectBaseDirectory(projectBaseDirectory);
            client.SetReporter("xml", "reports", "NoSPARCard_SkipAll");
        }

        [Test]
        public void TestNoSPARCard_SkipAll()
        {
            client.SetDevice("adb:Nexus 6");
            client.Launch("plus.spar.si/.ui.splash.SplashActivity", true, true);
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

        [TearDown]
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
