using System;
using BigRationalLib;


namespace BigRationalTests
{
    [TestClass]
    public class BigRationalEqualsUnitTests
    {
        [DataTestMethod]
        [DataRow(2, -5, -4, 10)]
        [DataRow(-2, -5, 4, 10)]
        public void TestEqualsTwoRationals_other(int a, int b, int c, int d)
        {
            BigRational u = new BigRational(a, b);
            BigRational w = new BigRational(c, d);

            Assert.IsTrue(u.Equals(w));
        }

        [DataTestMethod]
        [DataRow(2, -5, -4, 10)]
        [DataRow(-2, -5, 4, 10)]
        public void TestEqualsTwoRationals_obj(int a, int b, int c, int d)
        {
            BigRational u = new BigRational(a, b);
            BigRational w = new BigRational(c, d);

            Assert.IsTrue(Equals(u, w));
        }

        [DataTestMethod]
        [DataRow(2, -5, -4, 10)]
        [DataRow(-2, -5, 4, 10)]
        public void TestEqualsTwoRationals_byOperatorEqual(int a, int b, int c, int d)
        {
            BigRational u = new BigRational(a, b);
            BigRational w = new BigRational(c, d);

            Assert.IsTrue(u == w);
        }

        [DataTestMethod]
        [DataRow(2, -5, -3, 10)]
        public void TestEqualsTwoRationals_byOperatorNotEqual(int a, int b, int c, int d)
        {
            BigRational u = new BigRational(a, b);
            BigRational w = new BigRational(c, d);

            Assert.IsFalse(u == w);
        }

        [DataTestMethod]
        [DataRow(1, 2, 1, 2, 1, 2)]
        [DataRow(1, 2, 2, 4, 3, 6)]
        [DataRow(-1, 2, 2, -4, -3, 6)]
        [DataRow(1, 2, -1, 2, 1, 2)]
        [DataRow(1, 2, 1, 3, 1, 3)]
        [DataRow(1, 2, 1, 2, 1, 3)]
        public void Equals_Transitivity_LawsOfLogic_Any(int u1l, int u1m, int u2l, int u2m, int u3l, int u3m)
        {
            BigRational x = new(u1l, u1m);
            BigRational y = new(u2l, u2m);
            BigRational z = new(u3l, u3m);

            Assert.IsTrue(!x.Equals(y) || !y.Equals(z) || x.Equals(z));
        }
    }  
}

