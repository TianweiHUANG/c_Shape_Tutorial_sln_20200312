using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_Shape_method_20200320
{
    class NumberManipulator
    {
        public int FindMax(int num1, int num2)
        {
            int result;

            if (num1 > num2)
                result = num1;
            else
                result = num2;
            return result;
        }
     }
    class Program
    {

        static void Main(string[] args)
        {
            int a = 100;
            int b = 200;
            int ret;

            NumberManipulator n = new NumberManipulator();
            ret = n.FindMax(a, b);
            Console.WriteLine("最大值是： {0}", ret);
            Console.ReadLine();
        }
    }
}
