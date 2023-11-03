using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogbookFE
{
    public partial class LoginPage : Form
    {
        SummaryPage sp = new SummaryPage();
        CurrentInPersonnelPage cp = new CurrentInPersonnelPage();

        public LoginPage()
        {
            InitializeComponent();
        }

        // Show past records
        private void button1_Click(object sender, EventArgs e)
        {
            if (sp.IsDisposed)
                sp = new SummaryPage();
            else
            {
                sp.Show();
                sp.BringToFront();
                sp.DisplaySummaryRecords();
            }
        }

        // Show current logged in personnel
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cp.IsDisposed)
                cp = new CurrentInPersonnelPage();
            else
            {
                cp.Show();
                cp.BringToFront();
                cp.DisplaySummaryRecords();
            }
        }
    }
}
