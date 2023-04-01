using BigRationalLib;
using System.Numerics;

namespace BigRationalTests
{
    [TestClass]
    public class BigRationalRelationsUnitTests
    {
        [DataTestMethod]
        [DataRow(2, -5)]
        [DataRow(-2, -5)]
        public void TestCompareToRationalToItself(int a, int b)
        {
            BigRational u = new BigRational(a, b);

            Assert.AreEqual(0, u.CompareTo(u));
        }

        [DataTestMethod]
        [DataRow(2, -5, -4, 10)]
        [DataRow(-2, -5, 4, 10)]
        public void TestCompareToTwoEquivalentRationals(int a, int b, int c, int d)
        {
            BigRational u = new BigRational(a, b);
            BigRational w = new BigRational(c, d);

            Assert.AreEqual(0, u.CompareTo(w));
            Assert.AreEqual(0, w.CompareTo(u));

        }

        [DataTestMethod]
        [DataRow(2, -5, 4, 10)]
        [DataRow(-2, -5, 5, 10)]
        public void TestCompareToTwoDifferenceRationals(int a, int b, int c, int d)
        {
            BigRational u = new BigRational(a, b);
            BigRational w = new BigRational(c, d);

            Assert.IsTrue(0 > u.CompareTo(w));
            Assert.IsTrue(0 < w.CompareTo(u));
        }

        [DataTestMethod]
        [DataRow(2, -5, 4, 10, 7, 8)]
        [DataRow(-2, -5, 5, 10, 2, 3)]
        public void TestCompareToReturnSameSign(int a, int b, int c, int d, int e, int f)
        {
            var x = new BigRational(a, b);
            var y = new BigRational(c, d);
            var z = new BigRational(e, f);

            Assert.IsTrue(x.CompareTo(y) < 0);
            Assert.IsTrue(y.CompareTo(z) < 0);
            Assert.IsTrue(x.CompareTo(z) < 0);
        }
    }
}

