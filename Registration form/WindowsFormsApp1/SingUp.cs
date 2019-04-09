using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    public partial class SingUp : Form
    {
        string connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\USER\DOCUMENTS\DATA.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        public SingUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("please fill required fields");
            }
            else if (textBox6.Text != textBox5.Text)
            {
                MessageBox.Show("password don't match");
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connection))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("AddUser", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@username", textBox7.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@password", textBox6.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@name", textBox1.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@surname", textBox2.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@phone", textBox3.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@adress", textBox4.Text.Trim());
                
                    sqlCmd.ExecuteNonQuery();
                }
                MessageBox.Show("You data has been successfully saved!");
                this.Hide();
                Form1 f = new Form1();
                f.Show();
            }
        }
    }
}
