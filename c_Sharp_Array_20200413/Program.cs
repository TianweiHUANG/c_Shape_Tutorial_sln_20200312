﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_Sharp_Array_20200413
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = new int[10]; /* n 是一个带有 10 个整数的数组 */
            //int i, j;

            /* 初始化数组 n 中的元素 */
            for (int i = 0; i < 10; i++)
            {
                n[i] = i + 100;
            }

            /* 输出每个数组元素的值 */
            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine("Element[{0}] = {1}", j, n[j]);
            }
            Console.ReadKey();
        }
        static void Main_1(string[] args)
        {
            int[] n = new int[10]; /* n 是一个带有 10 个整数的数组 */

            /* 初始化数组 n 中的元素 */
            for (int i = 0; i < 10; i++)
            {
                n[i] = i + 100;
            }

            /* 输出每个数组元素的值 */
            foreach (int j in n)
            {
                int i = j - 100;
                Console.WriteLine("Element[{0}] = {1}", i, j);
            }
            Console.ReadKey();
        }
    }
}
