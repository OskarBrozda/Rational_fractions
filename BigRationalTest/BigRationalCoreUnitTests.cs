using BigRationalLib;
using System.Numerics;

namespace BigRationalTests
{
    [TestClass]
    public class BigRationalCoreUnitTests
    {
        [DataTestMethod]
        [DataRow(1, 2, 1, 2)]
        [DataRow(2, 4, 1, 2)]   //upraszczanie          //jeśli dostanę 2/4 to oczekuję w wyniku 1/2
        [DataRow(32, 12, 8, 3)]
        [DataRow(1, -2, -1, 2)] //normalizacja znaku
        [DataRow(-1, 2, -1, 2)]
        [DataRow(-1, -2, 1, 2)]
        public void TestConstructorWithTwoArguments(int a, int b, int c, int d)
        {
            //Assert - Datarow

            // Act
            BigRational t = new BigRational(a, b);

            // Assert
            Assert.AreEqual(c, t.Numerator);
            Assert.AreEqual(d, t.Denominator);
        }

        [DataTestMethod]
        [DataRow(-2, 0)] 
        public void TestConstructorWithTwoArguments_DenominatorIsZero(int a, int b)
        {
            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => new BigRational(a, b));
        }

        [DataTestMethod]
        [DataRow(-2)]
        public void TestConstructorWithOneArgument(int a)
        {            
            // Act
            var t = new BigRational(a);

            // Assert
            Assert.AreEqual(a, t.Numerator);
            Assert.AreEqual(new BigInteger(1), t.Denominator);
        }

        [DataTestMethod]
        [DataRow(-2)]
        public void TestConstructorWithLongArgument(int a)
        {
            // Arrange
            long numerator = a;

            // Act
            var t = new BigRational(numerator);

            // Assert
            Assert.AreEqual(a, t.Numerator);
            Assert.AreEqual(new BigInteger(1), t.Denominator);
        }

        [DataTestMethod]
        [DataRow("1/2", 1, 2)]
        [DataRow("2/4", 1, 2)]   
        [DataRow("32/12", 8, 3)]
        [DataRow("1/-2", -1, 2)]
        [DataRow("-1/2", -1, 2)]
        [DataRow("-1/-2", 1, 2)]
        public void TestConstructorWithStringArgument(string a, int x, int y)
        {
            // Arrange - zrealizowane jako DataRow

            // Act
            var u = new BigRational(a);

            //Assert
            Assert.AreEqual(x, u.Numerator);
            Assert.AreEqual(y, u.Denominator);
        }

        [TestMethod]
        [DataRow(0.0, 0, 1)]
        [DataRow(1.0, 1, 1)]
        [DataRow(-1.0, -1, 1)]
        public void TestDoubleConstructor(double a, long b, long c)
        {
            var rational = new BigRational((double)a);
            Assert.AreEqual(b, rational.Numerator);
            Assert.AreEqual(c, rational.Denominator);
        }

        [TestMethod]
        [DataRow(0, 1, 0.0)]
        [DataRow(1, 2, 0.5)]
        [DataRow(-1, 2, -0.5)]
        [DataRow(1, 3, 1.0 / 3)]
        [DataRow(2, 3, 2.0 / 3)]    
        public void TestToDouble(long numerator, long denominator, double expected)
        {
            var rational = new BigRational(numerator, denominator);
            var actual = rational.ToDouble();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(0, 1, 0f)]
        [DataRow(1, 2, 0.5f)]
        [DataRow(-1, 2, -0.5f)]
        [DataRow(1, 3, 1f / 3)]
        [DataRow(2, 3, 2f / 3)]
        public void TestToSingle(long numerator, long denominator, float expected)
        {
            var rational = new BigRational(numerator, denominator);
            var actual = rational.ToSingle();
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //[DataRow(0, 1, 0)]
        ////[DataRow(1, 2, "0.5m")]
        //[DataRow(-1, 2, -0.5)]
        ////[DataRow(1, 3, 1m / 3)]
        ////[DataRow(2, 3, 2m / 3)]
        ////[DataRow(long.MaxValue, 1, decimal.MaxValue)]
        ////[DataRow(long.MinValue, 1, decimal.MinValue)]
        //public void TestToDecimal(long numerator, long denominator, decimal expected)
        //{
        //    //decimal expectedDec = decimal.Parse(expected);
        //    var rational = new BigRational(numerator, denominator);
        //    var actual = rational.ToDecimal();
        //    Assert.AreEqual(expected, actual);
        //}

        [DataTestMethod]
        [DataRow(2, -5)]
        public void TestToStringMethod(int a, int b)
        {
            BigRational u = new BigRational(a, b);
            Assert.AreEqual(u.ToString(), $"{u.Numerator}/{u.Denominator}");
        }
    }
}
