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
    public partial class SummaryPage : Form
    {
        BindingSource recordBindingSource = new BindingSource();

        public SummaryPage()
        {
            InitializeComponent();
        }

        private void SummaryPage_Load(object sender, EventArgs e)
        {
            // Show page at front most
            this.BringToFront();

            DisplaySummaryRecords();
        }

        public void DisplaySummaryRecords()
        {
            RecordsDAO recordsDAO = new RecordsDAO();

            // Connect the list to grid view control
            recordBindingSource.DataSource = recordsDAO.GetPastRecords();

            dataGridView1.DataSource = recordBindingSource;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
