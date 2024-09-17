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
    public partial class admin_add_acc_cust : Form
    {
        SqlConnection con = new SqlConnection(data.con);
        public admin_add_acc_cust()
        {
            InitializeComponent();
        }

   //   public Promotion retrievePromotion(int email_ID)
      /*   {
            Promotion promo = null;
          //  var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MainConnStr"].ConnectionString;
            string connectionString = "server=(local)\\SQLExpress;database=ATM;integrated Security=SSPI;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               // var queryString = "SELECT PromotionID, PromotionTitle, PromotionURL FROM Promotion WHERE PromotionID=@PromotionID";
                var queryString = "SELECT email_id, account_number, name FROM Promotion WHERE email_id=@email_id";
                using (var da = new SqlDataAdapter(queryString, connection))
                {
                    // you could also use a SqlDataReader instead
                    // note that a DataTable does not need to be disposed since it does not implement IDisposable
                    var tblPromotion = new DataTable();
                    // avoid SQL-Injection
                    da.SelectCommand.Parameters.Add("@email_id", SqlDbType.Int);
                    da.SelectCommand.Parameters["@email_id"].Value = email_ID;
                   // da.SelectCommand.Parameters["@PromotionID"].Value = promotionID;
                    try
                    {
                        connection.Open(); // not necessarily needed in this case because DataAdapter.Fill does it otherwise 
                        da.Fill(tblPromotion);
                        if (tblPromotion.Rows.Count != 0)
                        {
                            var promoRow = tblPromotion.Rows[0];
                            promo = new Promotion()
                            {
                                email_ID = email_ID,
                                promotionTitle = promoRow.Field<String>("PromotionTitle"),
                                promotionUrl = promoRow.Field<String>("PromotionURL")
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                        // log this exception or throw it up the StackTrace
                        // we do not need a finally-block to close the connection since it will be closed implicitly in an using-statement
                        throw;
                    }
                }
            }
            return promo;
        }     */

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void admin_add_acc_cust_Load(object sender, EventArgs e)
        {
            string connectionString = "server=(local)\\SQLExpress;database=ATM;integrated Security=SSPI;";
            // SqlConnection con = new SqlConnection("data source=DESKTOP - V0AC5GU\\SQLEXPRESS;integrated security=true;initial catalog=ATM;");
            string queryString = "select * from customer_details";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["account_number"]).ToString();
                    // string column = reader["ColumnName"].ToString();
                    //    int columnValue = Convert.ToInt32(rdr["ColumnName"]);
                    //    Console.Write(String.Format("{0}", reader[0]));      Console.Write("  ");     Console.WriteLine(String.Format("{0}", reader[1]));
                } 
                label6.Visible = false;
                label5.Visible = false;
                connection.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = "server=(local)\\SQLExpress;database=ATM;integrated Security=SSPI;";
            string queryString = "select * from customer_details where account_number='" + comboBox1.Text + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader["name"].ToString();
                    textBox2.Text = reader["balance"].ToString();
                }
                   connection.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label5.Text = (double.Parse(textBox2.Text) + double.Parse(textBox3.Text)).ToString();       //BUG :  to add  string checking
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_Layout(object sender, LayoutEventArgs e)
        {
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
             label6.Visible = true;
            label5.Visible = true;
            label6.Text = "Account Credited By:";
            textBox3.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
