﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace ATM
{
    public partial class cust_card_no : Form
    {
        SqlConnection con = new SqlConnection(data.con);
        public cust_card_no()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             //SqlConnection con = new SqlConnection("data source=DESKTOP - V0AC5GU\\SQLEXPRESS;integrated security=true;initial catalog=ATM;");
            string connectionString = "server=(local)\\SQLExpress;database=ATM;integrated Security=SSPI;";          // Define connection string
            string queryString = "select * from customer_details where card_number='" + textBox1.Text + "'";          // Create a SQL quer y  
          //  using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    label2.Text = reader["name"].ToString();
                    label3.Text = reader["balance"].ToString();
                    label4.Text = reader["account_number"].ToString();
                    cust_pin cp = new cust_pin();
                    cp.label2.Text = textBox1.Text;
                    cp.label6.Text = label2.Text;
                    cp.label7.Text = label3.Text;
                    cp.label8.Text = label4.Text;
                    cp.Show();
                }
                else
                {
                    MessageBox.Show("Enter Valid Card Number");
                    textBox1.Text = " ";
                    textBox1.Focus();
                }
                connection.Close();
            }
          }

        private void cust_card_no_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
        }
    }
}
