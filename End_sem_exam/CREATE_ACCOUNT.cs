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
    public partial class CREATE_ACCOUNT : Form
    {
        static OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=studentRecords.accdb");
        static OleDbCommand cmd = con.CreateCommand();
        static OleDbDataReader reader;
        public CREATE_ACCOUNT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >2)
            {
                if (textBox6.Text.Length>2)
                {
                    if (textBox5.Text.Length >5)
                    {
                        if (textBox4.Text.Length > 5)
                        {
                            if (textBox3.Text.Length > 5)
                            {
                                if (textBox3.Text == textBox2.Text)
                                {

                                    con.Open();
                                    cmd.CommandText = "INSERT INTO Credentials VALUES ('"
                                        + textBox1.Text + "', '" +
                                        textBox6.Text + "', '" + textBox5.Text + "','" + textBox4.Text + "', '" + textBox3.Text + "', '" + textBox2.Text + "');";
                                    cmd.Connection = con;
                                    reader = cmd.ExecuteReader();
                                    reader.Read();
                                    con.Close();
                                    reader.Close();
                                    MessageBox.Show("Account created succssfully !!");
                                    this.Close();
                                }
                                else
                                {
                                    label7.Text = "Password do not match !!";
                                }
                            }
                            else
                            {
                                label7.Text = "Your password is not strong !!";
                            }

                        }
                        else
                        {
                            label7.Text = "Your student ID is too short !!";
                        }
                    }
                    else
                    {
                        label7.Text = "Your email is incorrect !!";
                    }

                }
                else
                {
                    label7.Text = "Your second name should be 3 or more char";
                }
            }
            else
            {
                label7.Text = "Your first name should be 3 or more char";
            }
        }
    }
}
