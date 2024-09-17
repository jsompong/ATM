using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATM
{
    public partial class cust_pin : Form
    {
        public cust_pin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cust_pin_Load(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // SqlConnection con = new SqlConnection("data source=DESKTOP - V0AC5GU\\SQLEXPRESS;integrated security=true;initial catalog=ATM;");
            string connectionString = "server=(local)\\SQLExpress;database=ATM;integrated Security=SSPI;";          // Define connection string
            string queryString = "select * from customer_details where pin='" + textBox1.Text + "'";          // Create a SQL quer y
            using (SqlConnection con = new SqlConnection(connectionString))
            {
               con.Open();
              SqlCommand command = new SqlCommand(queryString, con);
              SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    cust_main cm = new cust_main();
                    cm.label1.Text = label7.Text;
                    cm.label2.Text = label6.Text;
                    cm.label4.Text = label8.Text;
                    cm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Pin");
                }
                con.Close();
            }
        }
    }
}

