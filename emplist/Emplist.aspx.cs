using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace emplist
{
    public partial class Emplist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] != null)
            {
                string name = Session["Name"].ToString();
                Button4.Text = name;
            }
            if (!IsPostBack)
            {
                get();
            }
        }
        private void get(string searchKeyword = "")
        {
            //SqlConnection con = new SqlConnection("data source=SASHA;database=emprojectasp.net;integrated security=true");
            //con.Open();

            //string query = "select Id,ImgUpload,Name,Email,MobileNo,Designation,Gender,Course,CreatedDate from register";
            //SqlCommand cmd =new SqlCommand(query, con);
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds);
            //GridView1.DataSource = ds;

            //GridView1.DataBind();

            //con.Close();
            //Label8.Text = GridView1.Rows.Count.ToString();
            SqlConnection con = new SqlConnection("data source=SASHA;database=emprojectasp.net;integrated security=true");
            con.Open();

            string query = "SELECT Id, ImgUpload, Name, Email, MobileNo, Designation, Gender, Course, CreatedDate FROM register";
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                query += " WHERE Name LIKE @SearchKeyword";
            }

            // Set up the SqlCommand and SqlDataAdapter
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    // Add search parameter
                    cmd.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Bind the data to GridView
                GridView1.DataSource = dt;
                GridView1.DataBind();

                // Display the total record count
                Label8.Text = GridView1.Rows.Count.ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("Home.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
        private void BindGridView(string searchQuery = "")
        {
            //string query = "SELECT * FROM Employees";  // Adjust to your actual SQL query/table
            //if (!string.IsNullOrEmpty(searchQuery))
            //{
            //    query += " WHERE Name LIKE @Name";  // Adjust query to match your database
            //}

            //// Use your preferred data retrieval method (SqlDataSource, DataTable, etc.)
            //// Example with SqlDataSource
            //SqlDataSource1.SelectCommand = query;

            //if (!string.IsNullOrEmpty(searchQuery))
            //{
            //    SqlDataSource1.SelectParameters.Clear();
            //    SqlDataSource1.SelectParameters.Add("Name", "%" + searchQuery + "%");
            //}

            //// Bind to GridView
            //GridView1.DataBind();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string searchKeyword = TextBox4.Text.Trim();


            get(searchKeyword);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            Label lb = (Label)row.FindControl("Label1");
            SqlConnection con = new SqlConnection("data source=SASHA;database=emprojectasp.net;integrated security=true");
            con.Open();

            string query = "delete from register where Id='" + lb.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            get();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            get();


            //***********************************************************************************************************

            //GridViewRow row = GridView1.Rows[e.NewEditIndex];

            //// Retrieve values from row controls
            //string name = ((Label)row.FindControl("Label2")).Text;
            //string email = ((Label)row.FindControl("Label8")).Text;
            //string mobile = ((Label)row.FindControl("Label7")).Text;


            //string designation = (row.FindControl("Label3") as Label).Text;
            //string gender = (row.FindControl("Label4") as Label).Text;
            //string course = (row.FindControl("Label5") as Label).Text;
            //string imgUpload = (row.FindControl("Image1") as System.Web.UI.WebControls.Image).ImageUrl;
            //string createdDate = (row.FindControl("Label6") as Label).Text;


            //Session["name"] = name;
            //Session["email"] = email;
            //Session["mobile"] = mobile;
            //Session["designation"] = designation;
            //Session["gender"]=gender;
            //Session["course"]=course;
            //Session["imgUpload"] = imgUpload;


            //// Store the image file path

            //// Redirect to the edit page with the ID
            //string id = GridView1.DataKeys[e.NewEditIndex].Value.ToString();
            //Session["Id"] = id;
            //Response.Redirect($"Register.aspx?Id={id}");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Get the image URL from the data-bound row
                string imgUpload = DataBinder.Eval(e.Row.DataItem, "ImgUpload").ToString();

                // Optionally, display it or store it in a session
                Session["ImgUpload"] = imgUpload;
            }
        }
    }
}