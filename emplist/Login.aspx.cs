using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace emplist
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //string UserID =TextBox1.Text;
            //string Password=TextBox2.Text;

            //SqlConnection con = new SqlConnection("data source=SASHA;database=emprojectasp.net;integrated security=true");
            //con.Open();
            //string query = "select Name from admin where Password='" + Password + "'";
            //SqlCommand cmd = new SqlCommand(query, con);
            //cmd.ExecuteNonQuery();

            string UserID = TextBox1.Text;
            string Password = TextBox2.Text;


            SqlConnection con = new SqlConnection("data source=SASHA;database=emprojectasp.net;integrated security=true");
            con.Open();
            string query = "SELECT Name FROM admin WHERE Name ='" + UserID + "' AND Password='" + Password + "'";


            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    string adminName = reader["Name"].ToString();

                    Session["Name"] = adminName;
                }

                // Redirect to the dashboard page after successful login
                Response.Redirect("Home.aspx");
            }
            else
            {
                // If no matching rows are found, display an invalid login message
                Label4.Text = "Invalid username or password.";
            }

            // Close the reader
            reader.Close();




        }
    }
}