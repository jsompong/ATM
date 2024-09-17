using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace ATM
{
    public partial class bal_enq : Form
    {
        SqlConnection con = new SqlConnection(data.con);
        public bal_enq()
        {
            InitializeComponent();
        }

        // Change PIN
        private void button1_Click(object sender, EventArgs e)          
        {
            string strConnection = "server=(local)\\SQLExpress;database=ATM;integrated Security=SSPI;";          // Define connection string connectionString
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                using (SqlCommand cmd = new SqlCommand("update customer_details set pin='" + textBox3.Text + "' where pin='" + textBox1.Text + "'", conn))
                {
                    cmd.CommandType = CommandType.Text;
                   // cmd.Parameters.AddWithValue("@isbn", isbn);                  // Add parameters    
                    conn.Open();                    // Open the connection
                   cmd.ExecuteNonQuery();               // Exucute the command using ExecuteNonQuery()
                    MessageBox.Show("PIN Changed Successfully");
                    conn.Close();                    // Close the connection
                  }
            }
        }
    }
}
