using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using experitestClient;
namespace Experitest
{
    [TestClass]
    public class className
    {
        private String host = "localhost";
        private int port = 8888;
        private string projectBaseDirectory = "";
        private string activeDevice = "";
        protected Client client = null;

        [TestInitialize()]
        public void SetupTest()
        {
            client = new Client(host, port);
            client.SetProjectBaseDirectory(projectBaseDirectory);
            client.SetReporter("xml", "reports");
        }

        [TestMethod]
        public void TestUntitled()
        {
            // it is recommanded to start your script with SetApplicationTitle command:
            // client.SetApplicationTitle( activeDevice);
        }
        [TestCleanup()]
        public void TearDown()
        {
            client.GenerateReport();
        }
    }
}