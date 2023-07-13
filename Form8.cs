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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-P124HSRI\\SQLEXPRESS;Initial Catalog=\"staff management\";Integrated Security=True");

        private void Form8_Load(object sender, EventArgs e)
        {
            tb_search.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d;

            d = MessageBox.Show("Are You Sure, All the Unsave Details Will Be Lost !", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (d == DialogResult.OK)
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

        private void button4_Click(object sender, EventArgs e)
        {
            tb_eqid.Clear();
            tb_ID.Clear();  
            tb_name.Clear();
            tb_staff.Clear();
            tb_type.Clear ();
            tb_staff.Focus();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            disp_data();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into installation values ('"+tb_ID.Text+"' , '"+tb_name.Text+"' , '"+tb_type.Text+"' , '"+tb_eqid.Text+"' , '"+tb_start.Text+"' , '"+tb_end.Text+"' , '"+tb_staff.Text+"')";
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error While Saving" + ex);

            }
            finally
            {
                con.Close();
                MessageBox.Show("Data Inserted Successfully ! " , "Information" ,MessageBoxButtons.OK , MessageBoxIcon.Information );
            }

        }

        private void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from installation";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from installation where  instID = '" + tb_ID.Text + "'";
                MessageBox.Show("Are u sure ? ", "delete", MessageBoxButtons.OK, MessageBoxIcon.Question);
                cmd.ExecuteNonQuery();
            }
            catch( Exception ex)
            {
                MessageBox.Show("Error while Deleting" + ex);

            }
            finally
            {
                con.Close();
                disp_data();
                MessageBox.Show("record deleted successfully");

                tb_ID.Clear();
                tb_search.Focus();
            }
            

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                string updatesql = "update installation set instName = '" + tb_name.Text + "' , instType = '" + tb_type.Text + "' eqid = '" + tb_eqid.Text + "' , jobStart= '"+tb_start.Text+"' , where instID = '" + tb_ID.Text + "'";
                SqlCommand cmd = new SqlCommand(updatesql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("record updated successfully ");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error While Updating" + ex);
            }
            finally
            {
                con.Close();
                disp_data();

                tb_eqid.Clear();
                tb_ID.Clear();
                tb_name.Clear();
                tb_staff.Clear();
                tb_type.Clear();
                tb_staff.Focus();

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from  installation where instID = '" + tb_search.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error while Searching" + ex);
            }
            finally
            {
                con.Close();
                tb_search.Text = "";
                disp_data();
                tb_search.Focus();
            }
            
        }
    }
}
