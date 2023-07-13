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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-P124HSRI\\SQLEXPRESS;Initial Catalog=\"staff management\";Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d;

            d = MessageBox.Show("Are you sure ? all unsave details will be lost!", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {
                Form2 p = new Form2();
                p.Show();
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {

            tb_con.Clear();
            tb_cusid.Clear();
            tb_address.Clear();
            tb_name.Clear();

            tb_cusid.Focus();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into customerManagement values('" + tb_cusid.Text + "','" + tb_name.Text + "','" + tb_address.Text + "','" + tb_con.Text + "' )";
            cmd.ExecuteNonQuery();
            con.Close();
            display_data();
            MessageBox.Show("Data inserted Successfully.");


            tb_con.Clear();
            tb_cusid.Clear();   
            tb_address.Clear();
            tb_name.Clear();

            tb_cusid.Focus();
        }
        private void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from customerManagement ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            tb_search.Focus();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from customerManagement where customerID = '" + tb_cusid.Text+"' " ;
            MessageBox.Show("Are u sure ? ", "delete", MessageBoxButtons.OK, MessageBoxIcon.Question);
            cmd.ExecuteNonQuery();
            con.Close();
            display_data();
            MessageBox.Show("record deleted successfully");

            tb_con.Clear();
            tb_cusid.Clear();
            tb_address.Clear();
            tb_name.Clear();
            tb_cusid.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from customerManagement where customerID = '" + tb_search.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            tb_search.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            string updatesql = "update customerManagement set customerName = '" + tb_name.Text + "', address = '" + tb_address.Text + "' , contact = '" + tb_con.Text + "' where customerID = '" + tb_cusid.Text + "'";
            SqlCommand cmd = new SqlCommand(updatesql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("record updated successfully ");
            
            con.Close();
            display_data();

            tb_con.Clear();
            tb_cusid.Clear();
            tb_address.Clear();
            tb_name.Clear();
            tb_cusid.Focus();

        }


        private void btn_viewall_Click(object sender, EventArgs e)
        {
            display_data();
        }

    }
}
