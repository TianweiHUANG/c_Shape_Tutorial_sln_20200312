using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTypeConversion_20200327
{
    class Program
    {
        static void Main(string[] args)
        {
            //- 隐式类型转换 -
            int i = 75;
            float f = 53.005f;
            double d = 2345.7652;
            bool b = true;
            Console.WriteLine(i.ToString());
            Console.WriteLine(f.ToString());
            Console.WriteLine(d.ToString());
            Console.WriteLine(b.ToString());
            //- 显式类型转换 - 
            double d1 = 5673.74;
            int i1;
            i1 = (int)d1;
            Console.WriteLine(i1);
            Console.ReadKey();
        }
    }
}
