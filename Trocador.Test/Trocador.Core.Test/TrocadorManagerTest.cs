using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trocador.Core;
using Trocador.Core.DataContracts;
using System.Diagnostics.CodeAnalysis;
using Trocador.Test.Trocador.Core.Test.Mocks;
using System.IO;
using Trocador.Core.Utility;

namespace Trocador.Test.Trocador.Core.Test {

    [ExcludeFromCodeCoverage]
    [TestClass]
    public class TrocadorManagerTest {

		[ClassInitialize]
		public static void InitializeTests(TestContext context) {

			ConfigurationUtilityMock mock = new ConfigurationUtilityMock();
			mock.LogFileName = "log.log";
			mock.LogPath = "C:\\Logs\\Test\\";
			mock.LogFullPath = Path.Combine(mock.LogPath, mock.LogFileName);
			mock.LogType = "File";

			ConfigurationUtilityMock = mock;
		}

		public static IConfigurationUtility ConfigurationUtilityMock { get; set; }

        [TestMethod]
        public void CalculateChange_NegativeProductAmount_Test() {

			TrocadorManager trocadorManager = new TrocadorManager(ConfigurationUtilityMock);

            CalculateChangeRequest request = new CalculateChangeRequest();

            request.PaidAmount = 100;
            request.ProductAmount = -50;

            CalculateChangeResponse response = trocadorManager.CalculateChange(request);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.Success);
            Assert.IsNull(response.TotalChangeAmount);
            Assert.AreEqual(0, response.Change.Count);
            Assert.IsTrue(response.ErrorReportList.Count == 1);
            Assert.IsNotNull(response.ErrorReportList.SingleOrDefault(p => p.FieldName.EndsWith("ProductAmount")));
        }

        [TestMethod]
        public void CalculateChange_ExactChange375_Test() {

			TrocadorManager trocadorManager = new TrocadorManager(ConfigurationUtilityMock);

            CalculateChangeRequest request = new CalculateChangeRequest();

            request.PaidAmount = 500;
            request.ProductAmount = 125;

            CalculateChangeResponse response = trocadorManager.CalculateChange(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.TotalChangeAmount);

            Assert.AreEqual(4, response.Change.Count);
            Assert.AreEqual(375, response.TotalChangeAmount);

            Assert.IsTrue(response.Change.Any(c => c.Key == 1 && c.Value.AmountInCents == 200 && c.Value.Name == "BILL"));
            Assert.IsTrue(response.Change.Any(c => c.Key == 1 && c.Value.AmountInCents == 100 && c.Value.Name == "COIN"));
            Assert.IsTrue(response.Change.Any(c => c.Key == 1 && c.Value.AmountInCents == 50 && c.Value.Name == "COIN"));
            Assert.IsTrue(response.Change.Any(c => c.Key == 1 && c.Value.AmountInCents == 25 && c.Value.Name == "COIN"));

            Assert.IsTrue(response.ErrorReportList.Count == 0);
        }

        
    }
}
