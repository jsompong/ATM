using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;

namespace ATM
{

   

    public partial class admin_create_cust : Form
    {
        SqlConnection con = new SqlConnection(data.con);
        public admin_create_cust()
        {
            InitializeComponent();
        }

        public int DeleteBook(string isbn)
        {
            string strConnection = "Data Source=DESKTOP-V0AC5GU\\SQLEXPRESS; Initial Catalog=ATM;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                // DELETE SQL command
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE ISBN =" + isbn, conn))
                {
                    cmd.CommandType = CommandType.Text;                    // Pass the isbn as a parameter
                    cmd.Parameters.AddWithValue("@ISBN", isbn);
                    conn.Open();              // Open the connection
                    // Exucute the command using ExecuteNonQuery()
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();        // Close the connection
                    // Return the number of deleted rows
                    return i;
                }
            }
        }

        public int InsertBook(string isbn, string bookTitle, string author, string Contactnum,string Cardnum)
        {
            string strConnection = "Data Source=DESKTOP-V0AC5GU\\SQLEXPRESS; Initial Catalog=ATM;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                // SqlCommand cmd = new SqlCommand("insert into customer_details(name,address,email_id,contact_number,card_number,pin,city,account_type,balance) values('" + nametextBox.Text + "','" + AddressBox2.Text + "','" + emailBox.Text + "','" + ContactBox.Text + "','" + CardBox.Text + "','" + PINBox.Text + "','" + CityBox.Text + "','" + comboBox1.Text + "','" + textBox9.Text + "')", con);
                using (SqlCommand cmd = new SqlCommand("INSERT INTO customer_details (name,address,email_id,contact_number,card_number) VALUES (@isbn, @BookTitle, @Author, @Contactnum, @Cardnum)", conn))
                {
                   cmd.CommandType = CommandType.Text;
                   cmd.Parameters.AddWithValue("@isbn", isbn);                  // Add parameters
                    cmd.Parameters.AddWithValue("@Booktitle", bookTitle);
                    cmd.Parameters.AddWithValue("@Author", author);
                    cmd.Parameters.AddWithValue("@Contactnum", Contactnum);
                    cmd.Parameters.AddWithValue("@Cardnum", Cardnum);
                    conn.Open();                    // Open the connection
                    int i = cmd.ExecuteNonQuery();               // Exucute the command using ExecuteNonQuery()
                    conn.Close();                    // Close the connection
                    return i;                    // Return the number of deleted rows
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void admin_create_cust_Load(object sender, EventArgs e)
        {
            string connectionString = "server=(local)\\SQLExpress;database=ATM;integrated Security=SSPI;";
             using (SqlConnection con = new SqlConnection(connectionString))
                //SqlConnection con = new SqlConnection("data source=CLIENT-07\\SQLEXPRESS;integrated security=true;initial catalog=ATM;");
                //   DataTable customerTable = new DataTable("Top5Customers");
                //            SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
                //   SqlConnection con = new SqlConnection("data source=DESKTOP - V0AC5GU\\SQLEXPRESS;integrated security=true;initial catalog=ATM;");
                con.Open();
                //_con.Open();
            SqlCommand com = new SqlCommand("select count(*) from customer_details", con);
            //con.Open();
            //int count = Convert.ToInt16(com.ExecuteScalar()) + 1;
            int count = 1 ;
           // textBox8.Text = ("3241100011" + count);
           con.Close();
            //_con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameCust  = nameBox1.Text;            string Addressname = AddressBox2.Text;
            string Emailname = emailBox.Text;            string ContACtname = contactBox.Text;
            string Cardname = CardBox.Text;            string PINname = PINBox.Text;
            string CITyname = CityBox.Text;                 string aCcounType =  comboBox1.Text;

            string strConnection = "Data Source=DESKTOP-V0AC5GU\\SQLEXPRESS; Initial Catalog=ATM;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                //city,account_type,balance) values('" + nametextBox.Text + "','" + AddressBox2.Text + "','" + emailBox.Text + "','" + ContactBox.Text + "','" + CardBox.Text + "','" + PINBox.Text + "','" + CityBox.Text + "','" + comboBox1.Text + "','" + textBox9.Text + "')", con);
                using (SqlCommand cmd = new SqlCommand("INSERT INTO customer_details (name,address,email_id,contact_number,card_number,pin,city,account_type) VALUES (@nameCust, @Addressname, @Emailname, @ContACtname, @Cardname, @PINname, @CITyname, @aCcounType)", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nameCust", nameCust);                  // Add parameters
                    cmd.Parameters.AddWithValue("@Addressname", Addressname);
                    cmd.Parameters.AddWithValue("@Emailname", Emailname);
                    cmd.Parameters.AddWithValue("@ContACtname", ContACtname);
                    cmd.Parameters.AddWithValue("@Cardname", Cardname);
                    cmd.Parameters.AddWithValue("@PINname", PINname);
                    cmd.Parameters.AddWithValue("@CITyname", CITyname);
                    cmd.Parameters.AddWithValue("@aCcounType", aCcounType);
                    conn.Open();                    // Open the connection
                    cmd.ExecuteNonQuery();               // Exucute the command using ExecuteNonQuery()
                    conn.Close();                    // Close the connection
                    MessageBox.Show("จัดเก็บข้อมูล แล้ว");
                }
            }
            comboBox1.Text = " ";
                    textBox9.Text = " ";
                    textBox8.Text = " ";
                    CityBox.Text = " ";
                    PINBox.Text = " ";
                    CardBox.Text = " ";
                    contactBox.Text = " ";
                    emailBox.Text = " ";
                    AddressBox2.Text = " ";
                    nameBox1.Text = " ";
                    nameBox1.Focus();     
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i;
            i = DeleteBook("987-6-54-321012-3");
            if (i == 0)
            {
                 MessageBox.Show("Book not found !");
            }
            else
            {
                Console.WriteLine("Book has been deleted.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i;
            string nameCust = nameBox1.Text;
            string Addressname = AddressBox2.Text;
            string Emailname = emailBox.Text;
            string ContACtname = contactBox.Text;
            string Cardname = CardBox.Text;
            // SqlCommand cmd = new SqlCommand("insert into customer_details(name,address,email_id,contact_number,card_number,pin,city,account_type,balance) values('" + nametextBox.Text + "','" + AddressBox2.Text + "','" + emailBox.Text + "','" + ContactBox.Text + "','" + CardBox.Text + "','" + PINBox.Text + "','" + CityBox.Text + "','" + comboBox1.Text + "','" + textBox9.Text + "')", con);
            i = InsertBook(@nameCust, @Addressname, @Emailname,@ContACtname,@Cardname);
            if (i == 0)
            {
                MessageBox.Show("Nothing inserted !");
            }
            else
            {
                MessageBox.Show("เก็บข้อมูล ลูกค้า แล้ว");
             }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void PINBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
