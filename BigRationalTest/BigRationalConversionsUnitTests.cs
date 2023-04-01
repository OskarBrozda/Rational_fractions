using System;
using BigRationalLib;

namespace BigRationalTests
{
    [TestClass]
    public class BigRationalConversionsUnitTests
    {
        [TestMethod]
        [DataRow(12, 5)]
        public void TestToIntMethod(int a, int b)
        {
            int expected = a / b;
            BigRational rational = new BigRational(a, b);
            var result = rational.ToInt();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(12, 5)]
        public void TestToDoubleMethod(int a, int b)
        {

            double expected = (double)a / (double)b;
            BigRational rational = new BigRational(a, b);
            var result = rational.ToDouble();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(12, 5)]
        public void TestToDecimalMethod(int a, int b)
        {
            decimal expected = (decimal)a / (decimal)b;
            BigRational rational = new BigRational(a, b);
            var result = rational.ToDecimal();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(long.MinValue)]
        public void TestConvertLongToBigRationala(long a)
        {
            BigRational expected = new BigRational(a);
            BigRational result = a;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestConvertUlongToBigRationala()
        {
            ulong value = 123456789;
            BigRational expected = new BigRational((long)value);
            BigRational result = value;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(int.MinValue)]
        public void TestConvertIntToBigRationala(int value)
        {
            BigRational expected = new BigRational(value);
            BigRational result = value;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(uint.MaxValue)]
        public void TestConvertUintToBigRationala(uint value)
        {
            BigRational expected = new BigRational(value);
            BigRational result = value;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(short.MinValue)]
        public void TestConvertShortToBigRationala(short value)
        {
            BigRational expected = new BigRational(value);
            BigRational result = value;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(ushort.MaxValue)]
        public void TestConvertUshortToBigRationala(ushort value)
        {
            BigRational expected = new BigRational(value);
            BigRational result = value;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(byte.MaxValue)]
        public void TestConvertByteToBigRationala(byte value)
        {
            BigRational expected = new BigRational(value);
            BigRational result = value;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(SByte.MinValue)]
        public void TestConvertSbyteToBigRationala(sbyte value)
        {
            BigRational expected = new BigRational(value);
            BigRational result = value;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(12, 5)]
        public void TestConvertToInt64(int a, int b)
        {
            long expected = (long)a / (long)b;
            BigRational rational = new BigRational(a, b);
            long result = Convert.ToInt64(rational);

            Assert.AreEqual(expected, result);
        }
    }
}

