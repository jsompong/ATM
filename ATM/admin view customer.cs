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
    public partial class admin_view_customer : Form
    {
        SqlConnection con = new SqlConnection(data.con);
        public admin_view_customer()
        {
            InitializeComponent();
        }

        private void admin_view_customer_Load(object sender, EventArgs e)
        {
          string connectionString = "server=(local)\\SQLExpress;database=ATM;integrated Security=SSPI;";          // Define connection string
          string query = "SELECT * FROM  customer_details";                  // Create a SQL query             
          SqlDataAdapter da = new SqlDataAdapter(query, connectionString);         // Initialize the SqlDataAdapter with the query and connection string
                                                                                   //SqlDataAdapter da = new SqlDataAdapter("select * from customer_details", con);
            DataSet ds = new DataSet();         // Create a DataSet to hold the data
          da.Fill(ds,"customer_details");            // Fill the DataSet with data from the database
          //da.Fill(ds);
          // Now you can work with the data in the DataSet
            BindingSource bs = new BindingSource();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "customer_details".ToString();
                }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
