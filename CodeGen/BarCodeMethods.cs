using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using corel = Corel.Interop.VGCore;
using System.IO;

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

        /// <summary>
        /// Расчет строки для штрих-кода
        /// </summary>
        /// <param name="chain">Входное число для расчета строки штрих-кода</param>
        /// <returns></returns>
        public string CalculateBarcodeString(string chain)
        {
            int i; //i-e цифра штрих-кода (нумерация с нуля)
            int first; //Первое ЧИСЛО штрих-кода
            string barcode = ""; //Вычисляемая строка штрих-кода
            bool tableA;

            barcode = chain.Substring(0, 1) + (char)(65 + Convert.ToInt32(chain.Substring(1, 1)));
            first = Convert.ToInt32(chain.Substring(0, 1));

            for (i = 2; i <= 6; i++)
            {
                tableA = false;
                switch (i)
                {
                    case 2:
                        if (first >= 0 && first <= 3) tableA = true;                        
                        break;
                    case 3:
                        if (first == 0 || first == 4 || first == 7 || first == 8) tableA = true;                        
                        break;
                    case 4:
                        if (first == 0 || first == 1 || first == 4 || first == 5 || first == 9) tableA = true;
                        break;
                    case 5:
                        if (first == 0 || first == 2 || first == 5 || first == 6 || first == 7) tableA = true;
                        break;
                    case 6:
                        if (first == 0 || first == 3 || first == 6 || first == 8 || first == 9) tableA = true;
                        break;
                }
                if (tableA)
                {
                    barcode += (char)(65 + Convert.ToInt32(chain.Substring(i, 1)));
                }
                else
                {
                    barcode += (char)(75 + Convert.ToInt32(chain.Substring(i, 1)));
                }
            }
            barcode += "*"; //Добавить символ-разделитель

            for (i = 7; i <= 12; i++)
            {
                barcode += (char)(97 + Convert.ToInt32(chain.Substring(i, 1)));
            }
            barcode += "+"; //Добавить финишный символ

            return barcode;
        }        
    }
}
