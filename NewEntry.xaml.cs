using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace 交通費精算
{
    /// <summary>
    /// NewEntry.xaml の相互作用ロジック
    /// </summary>
    public partial class NewEntry : Window
    {
        public NewEntry()
        {
            InitializeComponent();
        }

        private void Button_Click_Entry(object sender, RoutedEventArgs e)
        {
            if (DatePickerDate.Text == "" || TextBoxRoute.Text == "" || (CheckBoxCategory1.IsChecked == false && CheckBoxCategory2.IsChecked == false && CheckBoxCategory3.IsChecked == false) || TextBoxDestination.Text == "" || TextBoxExpense.Text == "")
            {
                MessageBox.Show("未入力の項目があります。", "エラー");
                return;
            }
            else
            {
                string pass = GeneratePassword(8);

                string categories = "";
                if (CheckBoxCategory1.IsChecked == true)
                {
                    categories = "電車";
                }
                if (CheckBoxCategory2.IsChecked == true)
                {
                    if (categories != "")
                    {
                        categories = categories + ",";
                    }
                    categories = categories + "バス";
                }
                if (CheckBoxCategory3.IsChecked == true)
                {
                    if (categories != "")
                    {
                        categories = categories + ",";
                    }
                    categories = categories + "タクシー";
                }
                int expense;
                if(int.TryParse(TextBoxExpense.Text, out expense)) {
                    expense = int.Parse(TextBoxExpense.Text);
                }
                else
                {
                    expense = 0;
                }
                prntWindow.InsertRowData(DatePickerDate.Text, TextBoxRoute.Text, categories, TextBoxDestination.Text, expense, pass);
                this.DialogResult = true;
            }
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        //パスワードに使用する文字
        //private static readonly string passwordChars = "0123456789abcdefghijklmnopqrstuvwxyz";
        private static readonly string passwordChars = "0123456789";

        /// <summary>
        /// ランダムな文字列を生成する
        /// </summary>
        /// <param name="length">生成する文字列の長さ</param>
        /// <returns>生成された文字列</returns>
        public string GeneratePassword(int length)
        {
            StringBuilder sb = new StringBuilder(length);
            Random r = new Random();

            for (int i = 0; i < length; i++)
            {
                //文字の位置をランダムに選択
                int pos = r.Next(passwordChars.Length);
                //選択された位置の文字を取得
                char c = passwordChars[pos];
                //パスワードに追加
                sb.Append(c);
            }

            return sb.ToString();
        }

        private void tbExpenses_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // 0-9のみ
            e.Handled = !new Regex("[0-9]").IsMatch(e.Text);
        }

        private void tbExpenses_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // 貼り付けを許可しない
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        MainWindow prntWindow;
        public void setParent(MainWindow parent)
        {
            prntWindow = parent;
        }
    }
}
