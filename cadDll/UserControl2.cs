using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeFirst;

namespace cadDll
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new MainWindow().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new CodeFirst.MainWindow().Show();
        }
    }
}
