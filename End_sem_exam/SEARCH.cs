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
    public partial class SEARCH : Form
    {
        static OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=studentRecords.accdb");
        static OleDbCommand cmd = con.CreateCommand();
        static OleDbDataReader reader;
        public SEARCH()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "SELECT * FROM Credentials WHERE [STUDENT ID] = '" + textBox4.Text + "'";
            cmd.Connection = con;
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                // MessageBox.Show("You are there !!");
                

                textBox1.Text = reader.GetString(0);
                //textBox2.Text = reader.GetString(5);
                //textBox3.Text = reader.GetString(4);
                textBox5.Text = reader.GetString(2);
                textBox6.Text = reader.GetString(1);
                textBox1.Show();
                label1.Show();

               // textBox2.Show();
                label2.Show();

               // textBox3.Show();
                label3.Show();

                textBox5.Show();
                //label5.Show();

                textBox6.Show();
               // label6.Show();
                con.Close();
                reader.Close();
            }
            else
            {
                MessageBox.Show("Student not found");
                con.Close();
                reader.Close();
                this.Close();
            }

        }

        private void SEARCH_Load(object sender, EventArgs e)
        {
            textBox1.Hide();
            label1.Hide();

           // textBox2.Hide();
            label2.Hide();

           // textBox3.Hide();
            label3.Hide();

           
            textBox5.Hide();
           // label5.Hide();

            textBox6.Hide();
           // label6.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
