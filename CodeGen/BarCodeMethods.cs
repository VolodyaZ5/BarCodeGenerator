using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using corel = Corel.Interop.VGCore;

namespace CodeGen
{
    public partial class BarCode
    {        
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
                    outputEan13Str += "0";
                }
                return outputEan13Str = PrefixBarCode.ToString() + outputEan13Str + FirstNumbBarCode.ToString();
            }
            else
            {
                if (PrefixBarCode == 0)
                {
                    return outputEan13Str = FirstNumbBarCode.ToString();
                }
                else
                {
                    return outputEan13Str = PrefixBarCode.ToString() + FirstNumbBarCode.ToString();
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
            for (int i = 1; i < outputEan13Str.Length; i+=2)
            {
                odd += int.Parse(outputEan13Str[i].ToString());                
            }            
            odd *= 3;            
            for (int i = 0; i < outputEan13Str.Length - 1; i+=2)
            {
                even += int.Parse(outputEan13Str[i].ToString());                
            }
            return controlDigit = 10 - (odd + even) % 10;            
        }
    }
}
