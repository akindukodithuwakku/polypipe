using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace polypipe
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-P124HSRI\\SQLEXPRESS;Initial Catalog=\"staff management\";Integrated Security=True");


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_contact.Clear();
            tb_fname.Clear();   
            tb_job.Clear();
            tb_lname.Clear();
            tb_nic.Clear();
            tb_staff.Clear();

            tb_staff.Focus();

                    
        }

        

       
        private void btn_viewall_Click(object sender, EventArgs e)
        {
            display_data();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            DialogResult  d;

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

        private void btn_save_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into staff values('"+tb_staff.Text+"','" + tb_fname.Text + "','" + tb_lname.Text + "','" + tb_contact.Text + "','" + tb_nic.Text + "','" + tb_job.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            display_data();
            MessageBox.Show("Data inserted Successfully.");

            tb_staff.Clear();
            tb_nic.Clear();
            tb_job.Clear();
            tb_contact.Clear();
            tb_fname.Clear();
            tb_lname.Clear();

            tb_staff.Focus();

        }

        private void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from  staff ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            tb_staff.Focus();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from staff where staffNo = '" + tb_staff.Text + "'";
            MessageBox.Show("Are u sure ? ", "delete", MessageBoxButtons.OK, MessageBoxIcon.Question); 
            cmd.ExecuteNonQuery();
            con.Close();
            display_data();
            MessageBox.Show("record deleted successfully");
            tb_staff.Clear();
            tb_nic.Clear();
            tb_job.Clear();
            tb_contact.Clear();
            tb_fname .Clear();
            tb_lname .Clear();

            tb_staff.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from staff where staffNo = '"+tb_search.Text +"'";
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
            try
            {
                string updatesql = "update staff set FirstName ='" + tb_fname.Text + "', LastName = '" + tb_lname.Text + "',Contact ='" + tb_contact.Text + "', NIC = '" + tb_nic.Text + "', [job type] = '" + tb_job.Text + "' where staffNO = '" + tb_staff.Text + "'";
                SqlCommand cmd = new SqlCommand(updatesql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("record updated successfully ");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error While Updating" + ex );
            }
            finally
            {

                con.Close();
                display_data();

                tb_staff.Clear();
                tb_nic.Clear();
                tb_job.Clear();
                tb_contact.Clear();
                tb_fname.Clear();
                tb_lname.Clear();

                tb_staff.Focus();
            }

           
           
        }
    }
}
