using System;

namespace BigRationalLib
{
    public readonly partial struct BigRational
    {
        public static BigRational operator +(BigRational b1, BigRational b2)
        {
            var denominator = b1.Denominator * b2.Denominator;
            var numerator = b1.Numerator * b2.Denominator + b2.Numerator * b1.Denominator;
            return new BigRational(numerator, denominator);
        }
        public static BigRational operator -(BigRational b1, BigRational b2)
        {
            var denominator = b1.Denominator * b2.Denominator;
            var numerator = b1.Numerator * b2.Denominator - b2.Numerator * b1.Denominator;
            return new BigRational(numerator, denominator);
        }

        public static BigRational operator *(BigRational b1, BigRational b2)
        {            
            var numerator = b1.Numerator * b2.Numerator;
            var denominator = b1.Denominator * b2.Denominator;
            return new BigRational(numerator, denominator);
        }

        public static BigRational operator /(BigRational b1, BigRational b2)
        {
            var numerator = b1.Numerator * b2.Denominator;
            var denominator = b1.Denominator * b2.Numerator;
            return new BigRational(numerator, denominator);
        }

        public static BigRational operator ++(BigRational b1) => b1 += 1;
        public static BigRational operator --(BigRational b1) => b1 -= 1;

        public BigRational Plus(BigRational other)
        {
            var denominator = Denominator * other.Denominator;
            var numerator = Numerator * other.Denominator + other.Numerator * Denominator;
            return new BigRational(numerator, denominator);
        }

        public BigRational Minus(BigRational other)
        {
            var denominator = Denominator * other.Denominator;
            var numerator = Numerator * other.Denominator - other.Numerator * Denominator;
            return new BigRational(numerator, denominator);
        }

        public static BigRational Sum(params BigRational[] list)
        {
            if (list.Length < 2) throw new ArgumentException();

            BigRational br = list[0];
            for (int i = 1; i < list.Length; i++) br += list[i];
            
            return br;
        }

        public static BigRational Abs(BigRational u) => u < 0 ? u * (-1) : u;
        public static int Sign(BigRational u) => u == 0 ? 0 : u > 0 ? 1 : -1;
        public static long Ceiling(BigRational u) => (long)Math.Ceiling(u.ToDecimal());
        public static long Floor(BigRational u) => (long)Math.Floor(u.ToDecimal());
        public static BigRational Max(BigRational u, BigRational w) => u == w ? u : u > w ? u : w;
        public static BigRational Min(BigRational u, BigRational w) => u == w ? u : u < w ? u : w;
        public static BigRational Pow(BigRational u, int w)
        {
            if (w > 0)
            {
                long num = (long)Math.Pow((double)u.Numerator, w);
                long den = (long)Math.Pow((double)u.Denominator, w);
                return new BigRational(num, den);
            }
            else if (w < 0)
            {
                long num = (long)Math.Pow((double)u.Denominator, -w);
                long den = (long)Math.Pow((double)u.Numerator, -w);
                return new BigRational(num, den);
            }
            return new BigRational(1);
        }
    }
}

