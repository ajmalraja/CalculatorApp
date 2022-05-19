using CalculatorApp.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorApp.Core.Tests
{
    [TestClass]
    public class SimpleCalculatorTests
    {
        private readonly ISimpleCalculator _simpleCalculator;

        public SimpleCalculatorTests()
        {
            _simpleCalculator=new SimpleCalculator();
        }
        [TestMethod]
        public void Add_Operation_Test_Postive_Integer()
        {

            var res = _simpleCalculator.Add(0, 1);
            Assert.AreEqual(1, res);
        }
        [TestMethod]
        public void Add_Operation_Test_Negative_Integer()
        {

            var res = _simpleCalculator.Add(0, -1);
            Assert.AreEqual(-1, res);
        }
        [TestMethod]
        public void Add_Operation_Test_MaxValue()
        {

            var res = _simpleCalculator.Add(1, int.MaxValue);
            Assert.AreEqual(int.MinValue, res);
        }
        [TestMethod]
        public void Subtract_Operation_Test_Postive_Integer()
        {

            var res = _simpleCalculator.Subtract(0, 1);
            Assert.AreEqual(-1, res);
        }
        [TestMethod]
        public void Subtract_Operation_Test_Negative_Integer()
        {

            var res = _simpleCalculator.Subtract(0, -1);
            Assert.AreEqual(1, res);
        }
        [TestMethod]
        public void Multiply_Operation_Test_Postive_Integer()
        {

            var res = _simpleCalculator.Multiply(0, 1);
            Assert.AreEqual(0, res);
        }
        [TestMethod]
        public void Multiply_Operation_Test_Negative_Integer()
        {

            var res = _simpleCalculator.Multiply(1, - 1);
            Assert.AreEqual(-1, res);
        }
        [TestMethod]
        public void Divide_Operation_Test_Postive_Integer()
        {

            var res = _simpleCalculator.Divide(int.MaxValue, 1);
            Assert.AreEqual(int.MaxValue, res);
        }
        [TestMethod]
        public void Divide_Operation_Test_Divisor_Greater_Than_Dividend_Returns_Zero()
        {

            var res = _simpleCalculator.Divide(int.MaxValue - 1, int.MaxValue );
            Assert.AreEqual(0, res);
        }
    }
}
