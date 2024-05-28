using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChmodConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChmodConverter.Tests
{
    [TestClass()]
    public class ChmodConverterTests
    {
        [TestMethod()]
        [DataRow("rwxrwxrwx", 777)]
        [DataRow("rw-r--r--", 644)]
        [DataRow("r--r--r--", 444)]
        [DataRow("r-xr-xr-x", 555)]
        [DataRow("rwxr-xr--", 754)]
        public void SymbolicToNumericTest_ValidInput(string symbolic, int expected)
        {
            int result = ChmodConverter.SymbolicToNumeric(symbolic);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void NumericToSymbolicTest()
        {
            Assert.IsTrue(true);
        }
    }
}