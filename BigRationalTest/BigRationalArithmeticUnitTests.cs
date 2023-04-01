using System;
using BigRationalLib;

namespace BigRationalTests
{
    [TestClass]
    public class BigRationalArithmeticUnitTests
    {
        [TestMethod]
        [DataRow(1, 2, 2, 5, 9, 10)]
        public void TestOpertorPlus(int num1, int den1, int num2, int den2, int expNum, int expDen)
        {
            BigRational expected = new BigRational(expNum, expDen);
            BigRational rational1 = new BigRational(num1, den1);
            BigRational rational2 = new BigRational(num2, den2);

            Assert.AreEqual(rational1 + 0, rational1);
            Assert.AreEqual(0 + rational1, rational1);
            Assert.AreEqual(rational1 + rational2, expected);
            Assert.AreEqual(rational2 + rational1, expected);
            Assert.AreEqual(rational1 + (-1) * rational1, rational1 * (-1) + rational1);
            Assert.AreEqual(rational1 + (-1) * rational1, 0);
        }

        [TestMethod]
        [DataRow(1, 2, 2, 5, 1, 10)]
        public void TestOpertorMinus(int num1, int den1, int num2, int den2, int expNum, int expDen)
        {
            BigRational expected = new BigRational(expNum, expDen);
            BigRational rational1 = new BigRational(num1, den1);
            BigRational rational2 = new BigRational(num2, den2);

            Assert.AreEqual(rational1 - 0, rational1);
            Assert.AreEqual(0 - rational1, (-1) * rational1);
            Assert.AreEqual(rational1 - rational2, expected);
        }

        [TestMethod]
        [DataRow(1, 2, 2, 5, 1, 5)]
        public void TestOpertorMultiplication(int num1, int den1, int num2, int den2, int expNum, int expDen)
        {
            BigRational expected = new BigRational(expNum, expDen);
            BigRational rational1 = new BigRational(num1, den1);
            BigRational rationalOpposite = new BigRational(den1, num1);
            BigRational rational2 = new BigRational(num2, den2);

            Assert.AreEqual(rational1 * 1, rational1);
            Assert.AreEqual(1 * rational1, rational1);
            Assert.AreEqual(rational1 * rational2, expected);
            Assert.AreEqual(rational2 * rational1, expected);
            Assert.AreEqual(rational1 * rationalOpposite, 1);
            Assert.AreEqual(rationalOpposite * rational1, 1);
        }

        [TestMethod]
        [DataRow(1, 2, 2, 5, 5, 4)]
        public void TestOpertorDivision(int num1, int den1, int num2, int den2, int expNum, int expDen)
        {
            BigRational expected = new BigRational(expNum, expDen);
            BigRational rational1 = new BigRational(num1, den1);
            BigRational rational2 = new BigRational(num2, den2);

            Assert.AreEqual(rational1 / rational2, expected);
            Assert.AreEqual(rational1 / 1, rational1);
        }

        [TestMethod]
        [DataRow(1, 2, 3, 2)]
        public void TestOpertorIncrement(int num, int den, int expNum, int expDen)
        {
            BigRational expected = new BigRational(expNum, expDen);
            BigRational rational1 = new BigRational(num, den);
            rational1++;

            Assert.AreEqual(rational1, expected);
        }

        [TestMethod]
        [DataRow(1, 2, -1, 2)]
        public void TestOpertorDecrement(int num, int den, int expNum, int expDen)
        {
            BigRational expected = new BigRational(expNum, expDen);
            BigRational rational1 = new BigRational(num, den);
            rational1--;

            Assert.AreEqual(rational1, expected);
        }

        [TestMethod]
        [DataRow(1, 2, 2, 5, 9, 10)]
        public void TestPlusMethod(int num1, int den1, int num2, int den2, int expNum, int expDen)
        {
            BigRational expected = new BigRational(expNum, expDen);
            BigRational rational1 = new BigRational(num1, den1);
            BigRational rational2 = new BigRational(num2, den2);

            Assert.AreEqual(rational1.Plus(0), rational1);
            Assert.AreEqual(((BigRational)0).Plus(rational1), rational1);
            Assert.AreEqual(rational1.Plus(rational2), expected);
            Assert.AreEqual(rational2.Plus(rational1), expected);
            Assert.AreEqual(rational1.Plus((-1) * rational1), (rational1 * (-1)).Plus(rational1));
            Assert.AreEqual(rational1.Plus((-1) * rational1), 0);
        }

        [TestMethod]
        [DataRow(1, 2, 2, 5, 1, 10)]
        public void TestMinusMethod(int num1, int den1, int num2, int den2, int expNum, int expDen)
        {
            BigRational expected = new BigRational(expNum, expDen);
            BigRational rational1 = new BigRational(num1, den1);
            BigRational rational2 = new BigRational(num2, den2);

            Assert.AreEqual(rational1.Minus(0), rational1);
            Assert.AreEqual(((BigRational)0).Minus(rational1), (-1) * rational1);
            Assert.AreEqual(rational1.Minus(rational2), expected);
        }

        [TestMethod]
        [DataRow(1, 2, 2, 5, 9, 10)]
        public void TestSumMethod(int num1, int den1, int num2, int den2, int expNum, int expDen)
        {
            BigRational expected = new BigRational(expNum, expDen);
            BigRational rational1 = new BigRational(num1, den1);
            BigRational rational2 = new BigRational(num2, den2);

            Assert.AreEqual(BigRational.Sum(rational1, 0), rational1);
            Assert.AreEqual(BigRational.Sum(0, rational1), rational1);
            Assert.AreEqual(BigRational.Sum(rational1, rational2), expected);
            Assert.AreEqual(BigRational.Sum(rational2, rational1), expected);
            Assert.AreEqual(BigRational.Sum(rational1, (-1) * rational1), BigRational.Sum(rational1 * (-1), rational1));
            Assert.AreEqual(BigRational.Sum(rational1, (-1) * rational1), 0);
        }

        [TestMethod]
        [DataRow(-1, 2, 1, 2)]
        [DataRow(2, 5, 2, 5)]
        public void TestAbsMethod(int num, int den, int expNum, int expDen)
        {
            BigRational expexted = new BigRational(expNum, expDen);
            BigRational rational = new BigRational(num, den);

            Assert.AreEqual(expexted, BigRational.Abs(rational));
        }

        [TestMethod]
        [DataRow(-1, 2, -1)]
        [DataRow(2, 5, 1)]
        [DataRow(0, 5, 0)]
        public void TestSignMethod(int num, int den, int expected)
        {
            BigRational rational = new BigRational(num, den);

            Assert.AreEqual(expected, BigRational.Sign(rational));
        }

        [TestMethod]
        [DataRow(-1, 2, 0)]
        [DataRow(2, 5, 1)]
        public void TestCeilingMethod(int num, int den, long expected)
        {
            BigRational rational = new BigRational(num, den);

            Assert.AreEqual(expected, BigRational.Ceiling(rational));
        }

        [TestMethod]
        [DataRow(-1, 2, -1)]
        [DataRow(2, 5, 0)]
        public void TestFloorMethod(int num, int den, long expected)
        {
            BigRational rational = new BigRational(num, den);

            Assert.AreEqual(expected, BigRational.Floor(rational));
        }

        [TestMethod]
        [DataRow(1, 2, 2, 5, 1, 2)]
        [DataRow(1, 2, 1, 2, 1, 2)]
        public void TestMaxMethod(int num1, int den1, int num2, int den2, int expNum, int expDen)
        {
            BigRational expected = new BigRational(expNum, expDen);
            BigRational rational1 = new BigRational(num1, den1);
            BigRational rational2 = new BigRational(num2, den2);

            Assert.AreEqual(expected, BigRational.Max(rational1, rational2));
        }

        [TestMethod]
        [DataRow(1, 2, 2, 5, 2, 5)]
        [DataRow(1, 2, 1, 2, 1, 2)]
        public void TestMinMethod(int num1, int den1, int num2, int den2, int expNum, int expDen)
        {
            BigRational expected = new BigRational(expNum, expDen);
            BigRational rational1 = new BigRational(num1, den1);
            BigRational rational2 = new BigRational(num2, den2);

            Assert.AreEqual(expected, BigRational.Min(rational1, rational2));
        }

        [TestMethod]
        [DataRow(1, 2, 2, 1, 4)]
        [DataRow(2, 3, -2, 9, 4)]
        [DataRow(-2, 3, 0, 1)]
        public void TestPowMethod(int num, int den, int pow, int expNum, int expDen = 1)
        {
            BigRational expected = new BigRational(expNum, expDen);
            BigRational rational = new BigRational(num, den);

            Assert.AreEqual(expected, BigRational.Pow(rational, pow));
        }
    }
}