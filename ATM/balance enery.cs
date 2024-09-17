using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

    namespace ATM
{
    public partial class balance_enery : Form
    {
        SqlConnection con = new SqlConnection(data.con);
        public balance_enery()
        {
            InitializeComponent();
        }

        private void balance_enery_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            string connectionString = "server=(local)\\SQLExpress;database=ATM;integrated Security=SSPI;";
            string queryString = "select  * from transactions where account_no='" + label3.Text + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader rdr = command.ExecuteReader();
                if (rdr.Read())
                {
                    label2.Text = rdr["total"].ToString();
                }
                rdr.Close();
                rdr.Dispose();           
                connection.Close();
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
