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
    public partial class cust_receipt : Form
    {
        SqlConnection con = new SqlConnection(data.con);
        public cust_receipt()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            //SqlConnection con = new SqlConnection("data source=DESKTOP - V0AC5GU\\SQLEXPRESS;integrated security=true;initial catalog=ATM;");
            string connectionString = "server=(local)\\SQLExpress;database=ATM;integrated Security=SSPI;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //  using (SqlConnection connection = new SqlConnection(connectionString))
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into transactions(user_name,account_no,date_time,credit,total) values('" + label14.Text + "','" + label10.Text + "','" + label3.Text + "','" + label9.Text + "','" + label11.Text + "')", con);
                cmd.ExecuteNonQuery();
                cust_trans_cont ctc = new cust_trans_cont();
                ctc.Show();
            }
            con.Close();
        }

        private void cust_receipt_Load(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString();
            string connectionString = "server=(local)\\SQLExpress;database=ATM;integrated Security=SSPI;";
            using (SqlConnection con = new SqlConnection(connectionString))
       //     using (SqlConnection connection = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("select count(*) from transactions", con);
                //   int count = Convert.ToInt16(command.ExecuteScalar()) + 1;
                // label8.Text = ("100015101" + count);
                 label8.Text= ("100015101" );
                //SqlCommand command = new SqlCommand(queryString, connection);
                //SqlDataReader reader = command.ExecuteReader();
            }
            //     string con = "server=(local)\\SQLExpress;database=ATM;integrated Security=SSPI;";
            // SqlConnection con = new SqlConnection("data source=DESKTOP - V0AC5GU\\SQLEXPRESS;integrated security=true;initial catalog=ATM;");
            //     con.Open();
            //  SqlCommand com = new SqlCommand("select count(*) from transactions", con);
            // int count = Convert.ToInt16(com.ExecuteScalar()) + 1;
             con.Close();
        }
    }
}
