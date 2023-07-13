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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-P124HSRI\\SQLEXPRESS;Initial Catalog=\"staff management\";Integrated Security=True");



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_staff_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void btn_customer_Click(object sender, EventArgs e)
        {
            Form4 c = new Form4();
            c.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult p;

            p  = MessageBox.Show("You Are Going To Sign OUT, Are You Sure?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (p == DialogResult.Yes)
            {
                Form1 q = new Form1();
                q.Show();
                this.Hide();
            }
            else
            {
                this.Show();
            }




        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 z = new Form5();
            this.Hide();
            z.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 d = new Form6();
            d.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            Form8 x = new Form8();
            x.Show();
            this.Hide();
        }
    }
}
