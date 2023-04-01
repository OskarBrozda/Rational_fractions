using System;
using System.Numerics;

namespace BigRationalLib
{
    public readonly partial struct BigRational : IConvertible
    {
        public decimal ToInt() => (int)Numerator / (int)Denominator;
        public double ToDouble() => (double)Numerator / (double)Denominator;
        public float ToSingle() => (float)Numerator / (float)Denominator;
        public decimal ToDecimal() => (decimal)Numerator / (decimal)Denominator;

        public TypeCode GetTypeCode()                           => throw new NotImplementedException();       
        public bool ToBoolean(IFormatProvider provider)         => throw new NotImplementedException();       
        public byte ToByte(IFormatProvider provider)            => throw new NotImplementedException();
        public char ToChar(IFormatProvider provider)            => throw new NotImplementedException();
        public DateTime ToDateTime(IFormatProvider provider)    => throw new NotImplementedException();       
        public decimal ToDecimal(IFormatProvider provider)      => throw new NotImplementedException();       
        public double ToDouble(IFormatProvider provider)        => throw new NotImplementedException();       
        public short ToInt16(IFormatProvider provider)          => throw new NotImplementedException();        
        public int ToInt32(IFormatProvider provider)            => throw new NotImplementedException();
        public sbyte ToSByte(IFormatProvider provider)          => throw new NotImplementedException();
        public float ToSingle(IFormatProvider provider)         => throw new NotImplementedException();   
        public string ToString(IFormatProvider provider)        => throw new NotImplementedException();        
        public ushort ToUInt16(IFormatProvider provider)        => throw new NotImplementedException();
        public uint ToUInt32(IFormatProvider provider)          => throw new NotImplementedException();
        public ulong ToUInt64(IFormatProvider provider)         => throw new NotImplementedException();
        public object ToType(Type conversionType, IFormatProvider provider) => throw new NotImplementedException();
        public long ToInt64(IFormatProvider provider)           => (long)Numerator / (long)Denominator;
       
        public static implicit operator BigRational(long value)     => new BigRational(value);
        public static implicit operator BigRational(ulong value)    => new BigRational((long)value);
        public static implicit operator BigRational(int value)      => new BigRational(value);
        public static implicit operator BigRational(uint value)     => new BigRational(value);
        public static implicit operator BigRational(short value)    => new BigRational(value);
        public static implicit operator BigRational(ushort value)   => new BigRational(value);
        public static implicit operator BigRational(byte value)     => new BigRational(value);
        public static implicit operator BigRational(sbyte value)    => new BigRational(value);        

        public static explicit operator decimal(BigRational rational)   => (decimal)rational.Numerator / (decimal)rational.Denominator;
        public static explicit operator float(BigRational rational)     => (float)rational.Numerator   / (float)rational.Denominator;
        public static explicit operator double(BigRational rational)    => (double)rational.Numerator  / (double)rational.Denominator;
        public static explicit operator long(BigRational rational)      => (long)rational.Numerator    / (long)rational.Denominator;
        public static explicit operator ulong(BigRational rational)     => (ulong)rational.Numerator   / (ulong)rational.Denominator;
        public static explicit operator int(BigRational rational)       => (int)rational.Numerator     / (int)rational.Denominator;
        public static explicit operator uint(BigRational rational)      => (uint)rational.Numerator    / (uint)rational.Denominator;
        public static explicit operator short(BigRational rational)     => (short)(rational.Numerator  / rational.Denominator);
        public static explicit operator ushort(BigRational rational)    => (ushort)(rational.Numerator / rational.Denominator);
        public static explicit operator byte(BigRational rational)      => (byte)(rational.Numerator   / rational.Denominator);
        public static explicit operator sbyte(BigRational rational)     => (sbyte)(rational.Numerator  / rational.Denominator);
        public static explicit operator BigRational(double value)
        {
            long denominator = 1;
            while (value != Math.Floor(value))
            {
                value *= 10;
                denominator *= 10;
            }

            var Numerator = (BigInteger)value;
            var Denominator = (BigInteger)denominator;

            BigInteger gcd = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;

            return new BigRational(Numerator, Denominator);
        }

    }
}

