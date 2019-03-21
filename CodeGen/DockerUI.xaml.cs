using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using corel = Corel.Interop.VGCore;
using System.IO;

namespace CodeGen
{
    public partial class DockerUI : UserControl
    {
        private corel.Application corelApp;
        private string currentTheme;

        private int countBarCode; //Количество штрих-кодов
        private int firstNumbBarCode; //Номер первого штрих-кода
        private int prefixBarCode; //Префикс штрих-кодов
        private const int ean13Length = 12; //Длина данных для штрих кода


        public DockerUI(object app)
        {
            InitializeComponent();
            try
            {
                this.corelApp = app as corel.Application;
                this.corelApp.OnApplicationEvent += CorelApp_OnApplicationEvent;
            }
            catch (Exception)
            {
                global::System.Windows.MessageBox.Show("VGCore Error");
            }

        }
        
        #region theme select
        //Keys resources name follow the resource order to add a new value, order to works you need add 5 resources colors and Resources/Colors.xaml
        //1º is default, is the same name of StyleKeys string array
        //2º add LightestGrey. in start name of 1º for LightestGrey style in corel
        //3º MediumGrey
        //4º DarkGrey
        //5º Black
        public readonly string[] StyleKeys = new string[] {
         "TabControl.Static.Border",
         "TabItem.Static.Border" ,
         "TabItem.Disabled.Background",
         "TabItem.Selected.Background",
         "TabItem.Static.Background",
         "TabItem.Selected.MouseOver.Background" ,
         "TabItem.Static.MouseOver.Background",
         "Button.MouseOver.Background" ,
         "Button.MouseOver.Border",
         "Button.Static.Border" ,
         "Button.Static.Background" ,
         "Button.Pressed.Background" ,
         "Button.Pressed.Border" ,
         "Button.Disabled.Foreground",
         "Button.Disabled.Background",
         "Default.Static.Foreground" ,
         "Container.Text.Static.Background" ,
         "Container.Text.Static.Foreground" ,
         "Container.Static.Background" ,
         "Default.Static.Inverted.Foreground" ,
         "ComboBox.Border.Popup.Item.MouseOver"
        };
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadThemeFromPreference();
        }
        public void LoadStyle(string name)
        {

            string style = name.Substring(name.LastIndexOf("_") + 1);
            for (int i = 0; i < StyleKeys.Length; i++)
            {
                this.Resources[StyleKeys[i]] = this.Resources[string.Format("{0}.{1}", style, StyleKeys[i])];
            }
        }
        private void CorelApp_OnApplicationEvent(string EventName, ref object[] Parameters)
        {
            if (EventName.Equals("WorkspaceChanged") || EventName.Equals("OnColorSchemeChanged"))
            {
                LoadThemeFromPreference();
            }
        }
        public void LoadThemeFromPreference()
        {
            try
            {
                string result = "1";
#if X8
                result = corelApp.GetApplicationPreferenceValue("WindowScheme", "Colors").ToString();
#endif
#if X9
                 result = corelApp.GetApplicationPreferenceValue("WindowScheme", "Colors").ToString();
#endif
#if X10
                 result = corelApp.GetApplicationPreferenceValue("WindowScheme", "Colors").ToString();
#endif
#if X11
                 result = corelApp.GetApplicationPreferenceValue("WindowScheme", "Colors").ToString();
#endif
                if (!result.Equals(currentTheme))
                {
                    currentTheme = result;
                    LoadStyle(currentTheme);
                }
            }
            catch { }

        }
        #endregion

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            txtShowBarCode.Text = string.Empty;
            if (CheckEmptyTxtBoxes())
            {
                int.TryParse(txtCountBarCode.Text, out countBarCode);
                int.TryParse(txtFirstNumb.Text, out firstNumbBarCode);
                int.TryParse(txtPrefixBarCode.Text, out prefixBarCode);

                BarCode bc = new BarCode(countBarCode, firstNumbBarCode, prefixBarCode);

                using (StreamWriter sw = new StreamWriter("eanCodes.txt", false))
                {
                    for (int i = firstNumbBarCode; i < (firstNumbBarCode + countBarCode); i++)
                    {
                        BarCode bcWrite = new BarCode(countBarCode, i, prefixBarCode);
                        sw.WriteLine(bcWrite.CalculateBarcodeString(bcWrite.OutputEan13Str + bcWrite.ControlDigit.ToString()));
                    }
                }

                using (StreamReader sr = new StreamReader("eanCodes.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        txtShowBarCode.Text += sr.ReadLine() + $"\r";
                    }
                }

            }
        }

        #region Проверки ошибочного ввода
        /// <summary>
        /// Проверка на пустые textBox'ы
        /// </summary>
        /// <returns></returns>
        private bool CheckEmptyTxtBoxes()
        {
            if (txtCountBarCode.Text.Length == 0 | txtFirstNumb.Text.Length == 0 | txtPrefixBarCode.Text.Length == 0)
            {
                MessageBox.MsgShow(corelApp, "Заполните пустые поля!", "Недопустимый ввод", MessageBox.DialogButtons.Ok);
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
                    txtPrefixBarCode.Focus();
                }
                return false;
            }
            else
            {
                return true;
            }


        }

        /// <summary>
        /// Обработчик на ввод только цифр
        /// </summary>
        /// <param name="sender">Элемент инициирующий событие</param>
        /// <param name="e">Аргумент textBox'a</param>
        private void txtInputOnlyDigits_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (IsNumber(e.Text) == false)
            {
                e.Handled = true;
            }
            txtFirstNumb.MaxLength = ean13Length - txtPrefixBarCode.Text.Length;
            txtPrefixBarCode.MaxLength = ean13Length - txtFirstNumb.Text.Length;
        }

        /// <summary>
        /// Проверка на число
        /// </summary>
        /// <param name="text">Входная строка на проверку</param>
        /// <returns></returns>
        private bool IsNumber(string text)
        {
            int tempInt;
            return int.TryParse(text, out tempInt);
        } 
        #endregion
    }
}
