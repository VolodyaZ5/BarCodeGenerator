using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using corel = Corel.Interop.VGCore;

namespace CodeGen
{
    public partial class BarCode
    {
        private corel.Application corelApp;
        /// <summary>
        /// Метод добавляет недостающие нули до необходимой длины штрих-кода
        /// </summary>
        /// <returns></returns>
        public string AddZeroToInput()
        {
            countSymb = FirstNumbBarCode.ToString().Length + PrefixBarCode.ToString().Length;           

            if (countSymb < ean13Length)
            {
                countAddZeros = ean13Length - countSymb;
                for (int i = 0; i < countAddZeros; i++)
                {
                    OutputEan13Str += "0";
                }
                return OutputEan13Str = PrefixBarCode.ToString() + outputEan13Str + FirstNumbBarCode.ToString();
            }
            else
            {
                if (PrefixBarCode == 0)
                {
                    return OutputEan13Str = FirstNumbBarCode.ToString();
                }
                else
                {
                    return OutputEan13Str = PrefixBarCode.ToString() + FirstNumbBarCode.ToString();
                }
            }            
        }

        /// <summary>
        /// Вычисление контрольной цифры числа
        /// </summary>
        /// <returns></returns>
        public int CalculateControlDigit()
        {            
            int odd = 0, even = 0; //Четные и нечетные позиции кода ean13
            for (int i = 1; i < OutputEan13Str.Length; i+=2)
            {
                odd += int.Parse(OutputEan13Str[i].ToString());                
            }            
            odd *= 3;            
            for (int i = 0; i < OutputEan13Str.Length - 1; i+=2)
            {
                even += int.Parse(OutputEan13Str[i].ToString());                
            }
            return controlDigit = 10 - (odd + even) % 10;            
        }
    }
}
