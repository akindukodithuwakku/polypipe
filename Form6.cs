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
using System.Data.SqlClient;

namespace polypipe
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-P124HSRI\\SQLEXPRESS;Initial Catalog=\"staff management\";Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string updatesql = "update equipment set eqName = '" + tb_name.Text + "' , eqType = '" + tb_type.Text + "' eqQuantity = '" + tb_quan.Text + "'  where eqId = '" + tb_id.Text + "'";
                SqlCommand cmd = new SqlCommand(updatesql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("record updated successfully ");


            }
            catch(Exception ex)
            {
                MessageBox.Show("Error While Updating" + ex);
            }
            finally
            {
                con.Close();
                disp_data();

                tb_id.Clear();
                tb_name.Clear();
                tb_quan.Clear();
                tb_type.Clear();
                tb_search.Clear();

                tb_search.Focus();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from equipment where eqId = '" + tb_search.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Error While Searching");
            }
            finally
            {
                con.Close();
                tb_search.Text = "";
                disp_data();
                tb_search.Focus();
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            tb_search.Focus();
        }

        private void BTN_ADD_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into equipment values ('" + tb_id.Text + "', '" + tb_name.Text + "' ,'" + tb_type.Text + "' , '" + tb_quan.Text + "')";
                cmd.ExecuteNonQuery();
               
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error While Saving" + ex);

            }
            finally
            {
                con.Close();
                disp_data();
                MessageBox.Show("Data Inserted Successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tb_id.Clear();
                tb_name.Clear();
                tb_quan.Clear();
                tb_type.Clear();
                tb_search.Clear();

                tb_search.Focus();

            }

        }

        private void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from equipment";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult d;

            d = MessageBox.Show("Are You Sure, All the Unsave Details Will Be Lost !", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if(d == DialogResult.OK)
            {
                Form2 form2 = new Form2();
                this.Hide();
                form2.Show();
            }
            else
            {
                this.Show();
            }
        }

        private void BTN_DELETE_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from equipment where  eqId = '" + tb_id.Text + "'";
            MessageBox.Show("Are u sure ? ", "delete", MessageBoxButtons.OK, MessageBoxIcon.Question);
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("record deleted successfully");

            tb_id.Clear();
            tb_search.Focus();

        }

        private void btn_viewall_Click(object sender, EventArgs e)
        {
            disp_data();

        }
    }
}
