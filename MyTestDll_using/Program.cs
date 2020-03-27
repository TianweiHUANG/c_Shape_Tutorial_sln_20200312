using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyTestDll;  //添加引用

namespace MyTestDll_using
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDll1 td1 = new TestDll1();
            TestDll2 td2 = new TestDll2();

            Console.WriteLine(td1.MathAdd(3, 5));
            //Console.WriteLine(td1.MathSubtract(3, 5));
            //提示MyTestDll.TestDll1中不包含MathSubtract的定义.
            Console.WriteLine(td2.MathMultiplication(3, 5));
            Console.WriteLine(td2.MathDivision(3, 5));
            Console.ReadKey();
        }
    }
}
