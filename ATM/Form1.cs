using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_login al = new admin_login();
            al.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cust_card_no ccn = new cust_card_no();
            ccn.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         string connectionString = "server=(local)\\SQLExpress;database=ATM;integrated Security=SSPI;";
            using (SqlConnection _con = new SqlConnection(connectionString))
           {
               string queryStatement = "SELECT TOP 5 * FROM customer_details ORDER BY email_id";
                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
              {
                   DataTable customerTable = new DataTable("Top5Customers");
                 SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                _con.Open();
                 _dap.Fill(customerTable);
                 _con.Close();  
              }  
            }
             // SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI");
            //   string connectionString = "server=(local)\SQLExpress;database=Northwind;integrated Security=SSPI;";
            //  using (SqlConnection _con = new SqlConnection(connectionString))
            //    SqlConnection conn = new SqlConnection("Data Source=DatabaseServer; Initial Catalog=Northwind; User ID=YourUserID; Password=YourPassword");
        }
    }
}
