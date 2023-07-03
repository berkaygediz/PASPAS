using System;
using System.Windows.Forms;

namespace PASPAS
{
    public partial class Error : Form
    {
        public Error()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
