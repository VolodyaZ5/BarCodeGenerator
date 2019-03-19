using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGen
{
    public partial class BarCode
    {
        private int countBarCode; //Количество штрих-кодов
        private int firstNumbBarCode; //Номер первого штрих-кода
        private int prefixBarCode; //Префикс штрих-кодов        

        private int countSymb; //Количество символов номера первого штрих-кода и префикса
        private int countAddZeros; //Количество нулей, которые нужно добавить
        private const int ean13Length = 12; //Длина данных для штрих кода
        private string outputEan13Str; //Выходная строка с добавлением недостающих нулей и контрольной цифры
        private int controlDigit; //Контрольная цифра штрих-кода

        #region Properties
        public int CountBarCode
        {
            get { return countBarCode; }
            set { countBarCode = value; }
        }
        public int FirstNumbBarCode
        {
            get { return firstNumbBarCode; }
            set { firstNumbBarCode = value; }
        }


        public int PrefixBarCode
        {
            get { return prefixBarCode; }
            set { prefixBarCode = value; }
        }
        public string OutputEan13Str
        {
            get { return outputEan13Str + controlDigit; }
            set { outputEan13Str = value; }
        }
        #endregion

        #region Constructors
        public BarCode()
        {
            CountBarCode = 0;            
            FirstNumbBarCode = 0;
            PrefixBarCode = 0;
        }

        /// <summary>
        /// Кастомный конструктор
        /// </summary>
        /// <param name="count">Общее количество штрих-кодов</param>
        /// <param name="firstNumb">Номер первого</param>
        /// <param name="prefix">Префикс штрих-кода</param>
        public BarCode(int count, int firstNumb, int prefix)
        {
            CountBarCode = count;
            FirstNumbBarCode = firstNumb;
            PrefixBarCode = prefix;
        }
        #endregion
    }
}
