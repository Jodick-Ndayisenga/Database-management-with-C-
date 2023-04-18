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
    public partial class UPDATE : Form
    {
        static OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=studentRecords.accdb");
        static OleDbCommand cmd = con.CreateCommand();
        static OleDbDataReader reader;
        public UPDATE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" &&
                textBox6.Text != "" &&
                textBox4.Text != "")
            {
                if(textBox3.Text == textBox2.Text)
                {
                    con.Open();
                    cmd.CommandText = "UPDATE Credentials SET [FIRST NAME] = '" + textBox1.Text + "', [SECOND NAME] = '" + textBox6.Text + "',  [EMAIL] = '" + textBox5.Text + "', [STUDENT ID] = '" + textBox4.Text + "', [PASSWORD] = '" + textBox3.Text + "', [CONFIRM PASSWORD] = '" + textBox2.Text + "' WHERE [STUDENT ID] = '" + textBox7.Text + "'";
                    cmd.Connection = con;
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    con.Close();
                    reader.Close();
                    MessageBox.Show($"{textBox1.Text}'s records is successfully updated !");
                }
                else
                {
                    MessageBox.Show("You can not update on passwords that are different !!");
                } 
            }
            else
            {
                MessageBox.Show("You are trying to update empty record!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "SELECT * FROM Credentials WHERE [STUDENT ID] = '" + textBox7.Text + "'";
            cmd.Connection = con;
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                textBox1.Text = reader.GetString(0);
                textBox2.Text = reader.GetString(5);
                textBox3.Text = reader.GetString(4);
                textBox4.Text = reader.GetString(3);
                textBox5.Text = reader.GetString(2);
                textBox6.Text = reader.GetString(1);
                con.Close();
                reader.Close();
            }
            else
            {
                MessageBox.Show("Student not found");
                con.Close();
                reader.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" &&
                textBox6.Text != "" &&
                textBox4.Text != "")
            {
                con.Open();
                cmd.CommandText = "DELETE FROM Credentials WHERE [STUDENT ID] = '" + textBox7.Text + "'";
                cmd.Connection = con;
                reader = cmd.ExecuteReader();
                reader.Read();
                con.Close();
                reader.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                MessageBox.Show($"{textBox1.Text}'records is successfully deleted !");
            }
            else
            {
                MessageBox.Show("You are trying to update empty record!");
            }
        }
    }
}
