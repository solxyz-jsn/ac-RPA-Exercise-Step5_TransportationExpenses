using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace 交通費精算
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // このメソッドを追加
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // ログイン画面を表示する前に設定する
            this.MainWindow = new MainWindow();

            // ログイン画面を表示
            var loginWindow = new Login();
            bool? dialogResult = loginWindow.ShowDialog();

            if ((bool)!dialogResult)
            {
                this.Shutdown();
                return;
            }

            // メイン画面を表示
            this.MainWindow.Show();
        }

    }
}
