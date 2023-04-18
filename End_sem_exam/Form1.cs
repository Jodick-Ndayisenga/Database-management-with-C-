using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace End_sem_exam
{
    public partial class Form1 : Form
    {
        static OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=studentRecords.accdb");
        static OleDbCommand cmd = con.CreateCommand();
        static OleDbDataReader reader;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CREATE_ACCOUNT myAccount = new CREATE_ACCOUNT();
            myAccount.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LOGIN letLog = new LOGIN();
            letLog.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SEARCH mySearch = new SEARCH();
            mySearch.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UPDATE letUpdate = new UPDATE();
            letUpdate.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Exercice tr = new Exercice();
            tr.Show();
        }
    }
}
