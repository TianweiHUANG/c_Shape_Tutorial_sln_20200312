using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_Shape_Nullable_20200320
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ------ ? : 单问号用于对 int,double,bool 等无法直接赋值为 null 的数据类型进行 null 的赋值，
                       意思是这个数据类型是 NullAble 类型的。
            ------ int? i = 3 等同于 Nullable<int> i = new Nullable<int>(3);
            ------ int i; //默认值0 
            ------ int? ii; //默认值null
            */
            int? num1 = null;
            int? num2 = 45;
            double? num3 = new double?();
            double? num4 = 3.14157;
            bool? boolval = new bool?();

            Console.WriteLine("可空的类型值： {0}, {1}, {2}, {3}", num1, num2, num3, num4);
            Console.WriteLine("可空的布尔值： {0}", boolval);

            //------ ?? : 双问号用于判断一个变量在为 null 时返回一个指定的值。
            double? num10 = null;
            double? num20 = 3.14157;
            double num30;
            num30 = num10 ?? 5.34; // num10 如果为空值则返回 5.34
            Console.WriteLine("num30 的值： {0}", num30);
            num30 = num20 ?? 5.34;
            Console.WriteLine("num30 的值： {0}", num30);
            Console.ReadLine();
        }
    }
}
