using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarCodeGenerator
{
    public partial class frmMain : Form
    {
        private int countBarCode; //количество штрих-кодов
        private int firstNumbBarCode; //номер начального штрих-кода
        private int prefixBarCode; //префикс штрих-кода        

        public frmMain()
        {
            InitializeComponent();            
        }
        

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (CheckEmptyTxtBoxes())
            {
                int.TryParse(txtCountBarCode.Text, out countBarCode);

                int.TryParse(txtFirstNumb.Text, out firstNumbBarCode);

                int.TryParse(txtPrefix.Text, out prefixBarCode);

                BarCode bc = new BarCode(countBarCode, firstNumbBarCode, prefixBarCode);
                MessageBox.Show($"count: {countBarCode}, firstNumb: {firstNumbBarCode}, " +
                    $"prefix: {prefixBarCode}");
            }            
        }
        /// <summary>
        /// Проверка на пустые значения textBox'ов
        /// </summary>
        /// <returns></returns>
        private bool CheckEmptyTxtBoxes()
        {
            if (txtCountBarCode.Text.Length == 0 | txtFirstNumb.Text.Length == 0 | 
                txtPrefix.Text.Length == 0)
            {
                MessageBox.Show($"Заполните пустые поля!", "Недопустимый ввод", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                if (txtCountBarCode.Text.Length == 0)
                {
                    txtCountBarCode.Focus();
                }
                else if (txtFirstNumb.Text.Length == 0)
                {
                    txtFirstNumb.Focus();
                }
                else
                {
                    txtPrefix.Focus();
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Обработчик ввода только цифр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }
    }    
}
