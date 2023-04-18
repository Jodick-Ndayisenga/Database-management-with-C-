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
    public partial class LOGIN : Form
    {
        static OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=studentRecords.accdb");
        static OleDbCommand cmd = con.CreateCommand();
        static OleDbDataReader reader;
        int times = 3;
        public LOGIN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                if(times <= 0)
                {
                    this.Close();
                }
                else
                {
                    con.Open();
                    cmd.CommandText = "SELECT [FIRST NAME] FROM Credentials WHERE [EMAIL] = '"
                        + textBox1.Text + "' AND PASSWORD = '" + textBox2.Text + "';";
                    cmd.Connection = con;
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        //MessageBox.Show("Connected successfully !!");
                        Connected Conne = new Connected();
                        con.Close();
                        reader.Close();
                        Conne.Show();
                        this.Close();
                    }
                    else
                    {
                        times--;
                        label4.Text = $"Wrong credentials; Remaing attempts {times}";
                        con.Close();
                        reader.Close();
                    }
                }
            
            
            




            //MessageBox.Show(reader.GetString(0));

        }
    }
}
