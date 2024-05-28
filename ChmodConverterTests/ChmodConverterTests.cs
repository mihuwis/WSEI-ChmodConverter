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
        [DataRow("r--rw-rwx", 467)]
        [DataRow("rwx--x--x", 711)]
        [DataRow("rw-rw-r-x", 665)]
        [DataRow("r-xrwxr-x", 575)]
        public void SymbolicToNumericTest_ValidInput(string symbolic, int expected)
        {
            int result = ChmodConverter.SymbolicToNumeric(symbolic);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [DataRow(467, "r--rw-rwx")]
        [DataRow(711, "rwx--x--x")]
        [DataRow(665, "rw-rw-r-x")]
        [DataRow(575, "r-xrwxr-x")]
        public void NumericToSymbolicTest_ValidInput(int numeric, string expected)
        {
            string result = ChmodConverter.NumericToSymbolic(numeric);
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("")]
        [DataRow("rwx")]
        [DataRow("costggamcostam")]
        [DataRow("rwxrwxrwggggxr")]
        public void SymbolicToNumericTest_InvalidInput(string symbolic)
        {
            ChmodConverter.SymbolicToNumeric(symbolic);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(-109)]
        [DataRow(888)]
        [DataRow(999)]
        public void NumericToSymbolicTest_InvalidInput(int numeric)
        {
            ChmodConverter.NumericToSymbolic(numeric);
        }
    }
}