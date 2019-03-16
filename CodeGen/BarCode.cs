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
