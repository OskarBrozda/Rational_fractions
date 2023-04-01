using System.Numerics;
using BigRationalLib;

namespace BigRationalDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            T1();
            Console.WriteLine("tutut");
            Console.WriteLine(Math.Pow(2, -2));
        }
                
        static void T1()
        {
            BigRational u = default;
            Console.WriteLine(u);

            BigRational v = new BigRational();
            Console.WriteLine(v);

            BigRational w = new BigRational(2, 5);
            BigRational w1 = new BigRational(2, 5);
            Console.WriteLine("MAXXXXXX");
            Console.WriteLine(BigRational.Sum(w, w1));
            Console.WriteLine(Equals(w1, w));


            BigRational w2 = new BigRational("2/4");
            Console.WriteLine(w2);

            var k = new BigRational(1, 2);
            string s = k.ToString();
            var g = new BigRational(s);
            Console.WriteLine(k);
            Console.WriteLine(s);
            Console.WriteLine(k == g);


            var l = new BigRational(1.2);            
            Console.WriteLine(l.ToInt());

            var rational = new BigRational(1, 3);
            var actual = rational.ToDecimal();
            Console.WriteLine(actual == 1m / 3);
            string oss = "0.5";
            decimal osk = decimal.Parse(oss);
            Console.WriteLine(osk);
            
            Console.WriteLine("tutu");
            Console.WriteLine(rational);
            Console.WriteLine(rational.ToDouble());

        }

    }
}
