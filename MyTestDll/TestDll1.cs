using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTestDll
{
    /// <summary>
    /// TestDll1类
    /// </summary>
    public class TestDll1
    {
        /// <summary>
        /// 加法函数
        /// </summary>
        /// <param name="number1">参数一</param>
        /// <param name="number2">参数二</param>
        /// <returns>两个参数之和</returns>
        public int MathAdd(int number1, int number2)
        {
            return (number1 + number2);//返回两个参数的和
        }
 
        /// <summary>
        /// 减法函数
        /// </summary>
        /// <param name="number1">参数一</param>
        /// <param name="number2">参数二</param>
        /// <returns>两个参数的差</returns>
        private int MathSubtract(int number1, int number2)
        { 
            return (number1 - number2);
        }
    } 
}
