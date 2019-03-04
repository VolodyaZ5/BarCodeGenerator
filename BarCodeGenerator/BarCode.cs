using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarCodeGenerator
{
    public partial class BarCode
    {
        private int countBarCode; //количество штрих-кодов
        private int firstNumb; //номер начального штрих-кода
        private int prefixBarCode; //префикс штрих-кода

        #region Properties
        public int PrefixBarCode
        {
            get { return prefixBarCode; }
            set { prefixBarCode = value; }
        }

        public int FirstNumbBarCode
        {
            get { return firstNumb; }
            set { firstNumb = value; }
        }

        public int CountBarCode
        {
            get { return countBarCode; }
            set { countBarCode = value; }
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
        /// Инициализация объекта BarCod'a
        /// </summary>
        /// <param name="countBC">Общее количество</param>
        /// <param name="firstNumb">Первый номер</param>
        /// <param name="prefixBC">Префикс</param>
        public BarCode(int countBC, int firstNumb, int prefixBC)
        {
            CountBarCode = countBC;
            FirstNumbBarCode = firstNumb;
            PrefixBarCode = prefixBC;
        }
        #endregion
    }
}
