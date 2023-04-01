using System;

namespace BigRationalLib
{
    public readonly partial struct BigRational : IComparable, IComparable<BigRational>
    {
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (ReferenceEquals(this, obj)) return 0;

            if (obj is BigRational) return CompareTo((BigRational)obj);
            else throw new ArgumentException("Object is not a BigRational"); ;
        }

        public int CompareTo(BigRational other)
        {
            if (other == null) return 1;
            if (ReferenceEquals(this, other)) return 0;
            
            return (Numerator*other.Denominator).CompareTo(other.Numerator*Denominator);
        }

        public static bool operator >(BigRational p1, BigRational p2) => p1.CompareTo(p2) > 0;
        public static bool operator <=(BigRational p1, BigRational p2) => p1.CompareTo(p2) >= 0;
        public static bool operator <(BigRational p1, BigRational p2) => p1.CompareTo(p2) < 0;
        public static bool operator >=(BigRational p1, BigRational p2) => p1.CompareTo(p2) <= 0;
    }
}

