using System.Numerics;
using System;

namespace BigRationalLib
{
    public readonly partial struct BigRational
    {
        //properties
        public BigInteger Numerator { get; init; }
        public BigInteger Denominator { get; init; }
        public static readonly BigRational Zero = new BigRational(0, 1);
        public static readonly BigRational One = new BigRational(1, 1);
        public static readonly BigRational Half = new BigRational(1, 2);
        public static readonly BigRational NaN = new BigRational(0, 0);
                       
        #region ctor's 
        public BigRational(BigInteger numerator, BigInteger denominator)
        {
            Numerator = numerator;
            Denominator = denominator;

            if (denominator == 0) throw new ArgumentException("Denominator cannot be zero.");
            if (numerator == 0)
            {
                Numerator = BigInteger.Zero;
                Denominator = BigInteger.One;
            }
            else
            {
                BigInteger gcd = BigInteger.GreatestCommonDivisor(numerator, denominator);
                Numerator /=  gcd;
                Denominator /=  gcd;

                if (Denominator.Sign == -1)
                {
                    Numerator *= -1;
                    Denominator *= -1;
                }
            }
        }

        public BigRational(BigInteger numerator) : this(numerator, BigInteger.One) { }        
        public BigRational(long numerator) : this(new BigInteger(numerator)) { }       

        public BigRational(double value)
        {
            if (double.IsNaN(value)) throw new ArgumentException("Cannot convert NaN to BigRational.");
            if (double.IsInfinity(value)) throw new ArgumentException("Cannot convert Infinity to BigRational.");

            long denominator = 1;
            while (value != Math.Floor(value))
            {
                value *= 10;
                denominator *= 10;
            }

            Numerator = (BigInteger)value;
            Denominator = denominator;

            BigInteger gcd = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        //string ctor
        public BigRational(string representation)
        {
            if (string.IsNullOrWhiteSpace(representation)) throw new ArgumentException("Representation cannot be null or whitespace.");

            string[] parts = representation.Split('/');
            if (parts.Length != 2) throw new ArgumentException("Representation must contain exactly one '/'.");
            
            BigInteger numerator, denominator;
            if (!BigInteger.TryParse(parts[0], out numerator)) throw new ArgumentException("Invalid numerator.");          
            if (!BigInteger.TryParse(parts[1], out denominator)) throw new ArgumentException("Invalid denominator.");   
            if (denominator == BigInteger.Zero) throw new ArgumentException("Denominator cannot be zero.");
            
            Numerator = numerator;
            Denominator = denominator;

            if (Denominator.Sign == -1)
            {
                Numerator *= -1;
                Denominator *= -1;
            }

            BigInteger gcd = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }
        #endregion

        // ToString
        public override string ToString() => $"{Numerator}/{Denominator}";  
    }
}