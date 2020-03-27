using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTestDll
{
    /// <summary>
    /// TestDll2类
    /// </summary>
    public class TestDll2
    {
        /// <summary>
        /// 乘法函数
        /// </summary>
        /// <param name="number1">参数一</param>
        /// <param name="number2">参数二</param>
        /// <returns>两个参数的乘积</returns>
        public int MathMultiplication(int number1, int number2)
        {
            return (number1 * number2);
        }
 
        /// <summary>
        /// 除法函数
        /// </summary>
        /// <param name="number1">参数一</param>
        /// <param name="number2">参数二</param>
        /// <returns>两个参数的商</returns>
        public double MathDivision(int number1, int number2)
        {
            return (number1 / number2);
        }
    }
}
