using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace cadDll
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Debug.Print("This is a test.");
            GlobalVarible.ed.WriteMessage("helllo\n");
            new form().Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //config file will be automatically loaded from xxxx.exe.config in xxxx.exe'folder in most .net program
            string str = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            string key = ConfigurationManager.AppSettings.AllKeys[0];
            string value = ConfigurationManager.AppSettings[key];
            textBox1.Text += $"key:{key},value:{value}\nPath:{str}";
        }
    }
}
