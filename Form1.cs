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

namespace polypipe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-P124HSRI\SQLEXPRESS;Initial Catalog=""staff management"";Integrated Security=True");

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username, password;
            username = tb_user.Text;
            password = tb_pass.Text; 
            
            try
            {
                string querry = "SELECT * FROM Login WHERE username = '"+ tb_user.Text+"' AND password = '"+tb_pass.Text+"' ";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0) 
                {
                    username = tb_user.Text;
                    password = tb_pass.Text;

                    MessageBox.Show("Login Successfull");

                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid Login details.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    tb_pass.Clear();
                    tb_user.Clear();

                    tb_user.Focus();
                }



            }
            catch
            {
                MessageBox.Show("Fatal Error.");
            }
            finally
            {
                conn.Close();
            }

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_user.Clear();
            tb_pass.Clear();

            tb_user.Focus();

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult res;

            res = MessageBox.Show("Do you want to exit ?", "Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
                tb_user.Focus();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (tb_pass.PasswordChar == '*')
            {
                tb_pass.PasswordChar = '\0';

            }
            else
            {
                tb_pass.PasswordChar = '*';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tb_user.Focus();
        }
    }
}
