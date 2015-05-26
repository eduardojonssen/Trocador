using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Trocador.Core.Processors;
using System.Collections.Generic;

namespace Trocador.Test.Trocador.Core.Test {

    [ExcludeFromCodeCoverage]
    [TestClass]
    public class BillProcessorTest {

        [TestMethod]
        public void CalculateChange_ChangeFor400_Test() {

            BillProcessor billProcessor = new BillProcessor();

            PrivateObject privateObject = new PrivateObject(billProcessor);
            object result = privateObject.Invoke("CalculateChange", Convert.ToInt32(400));

            Dictionary<int, int> typedResult = result as Dictionary<int, int>;

            Assert.IsNotNull(typedResult);
            Assert.IsTrue(typedResult.Count == 1);
            Assert.IsTrue(typedResult[200] == 2);
        }
    }
}
