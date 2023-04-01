using System;
namespace BigRationalLib
{
    public readonly partial struct BigRational : IEquatable<BigRational>
    {
        //przyrównanie
        public bool Equals(BigRational other)
        {
            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;

            return (Numerator * other.Denominator == Denominator * other.Numerator);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj is BigRational) return this.Equals((BigRational)obj);
            else return false;
        }

        public static bool Equals(BigRational? p1, BigRational? p2)
        {
            if (p1 is null && p2 is null) return true;
            if (p1 is null) return false;
            return p1.Equals(p2);
        }

        public override int GetHashCode() => (Numerator, Denominator).GetHashCode();
        public static bool operator ==(BigRational p1, BigRational p2) => Equals(p1, p2);
        public static bool operator !=(BigRational p1, BigRational p2) => !(p1 == p2);
    }
}

