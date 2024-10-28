using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_CoffeShop_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "admin" && txtPass.Text == "1234")
            {
                MessageBox.Show("Login Succesfully", "Login", MessageBoxButtons.OK);
                this.Hide();

                Coffee co =new Coffee();
                co.Show();

            }
            else
            {
                MessageBox.Show("Username and Password incorrect", "error", MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPass.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
