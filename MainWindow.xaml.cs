using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Collections.ObjectModel;

namespace 交通費精算
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var data = new ObservableCollection<Expenses>(
            Enumerable.Range(1, 1).Select(i => new Expenses
            {
                Date = "2021/07/01",
                Route = "品川 - 田町",
                Categories = "電車",
                Destination = "A社",
                Expense = 140,
                RegNumber = GeneratePassword(8)
            }));
            this.DataGridExpenses.ItemsSource = data;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnNewEntry_Click(object sender, RoutedEventArgs e)
        {
            var NewEntry = new NewEntry();
            NewEntry.setParent(this);
            NewEntry.ShowDialog();
            if ((bool)NewEntry.DialogResult)
            {
                // 登録時
            }
            else
            {
                // キャンセル時
            }
        }

        public void InsertRowData(string dt, string rt, string ct, string ds,int ex, string rn)
        {
            // データグリッドに行を追加します。
            var dataList = DataGridExpenses.ItemsSource as ObservableCollection<Expenses>;
            var data = new Expenses { Date = dt, Route = rt, Categories = ct, Destination = ds, Expense = ex, RegNumber = rn };
            dataList.Insert(0, data);
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

    }
}
