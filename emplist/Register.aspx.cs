using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace emplist
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                Button6.Visible = false;
                string name = Session["name"].ToString();
                TextBox1.Text = name;
                string email = Session["email"].ToString();
                TextBox2.Text = email;
                string mobile = Session["mobile"].ToString();
                TextBox3.Text = mobile;

                // Assuming you have the session values
                // Always check for null to avoid exceptions
                string designation = Session["designation"]?.ToString();
                string gender = Session["gender"]?.ToString();

                // Assign mobile to TextBox3
                TextBox3.Text = mobile;

                // Set the DropDownList selection by matching the designation text
                if (designation != null)
                {
                    ListItem item = DropDownList1.Items.FindByText(designation);
                    if (item != null)
                    {
                        DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(item);
                    }
                }

                // Set the gender (assuming it's a RadioButtonList)
                if (gender != null)
                {
                    ListItem genderItem = RadioButtonList1.Items.FindByText(gender);
                    if (genderItem != null)
                    {
                        genderItem.Selected = true;
                    }
                }

                //string designation = Session["designation"].ToString();
                //DropDownList1.SelectedItem.Text = designation;



                // Set the selected item in RadioButtonList



                string course = Session["course"].ToString();
                string image = Session["imgUpload"].ToString();
                // Set the retrieved values into respective controls



                foreach (ListItem item in CheckBoxList1.Items)
                {
                    if (item.Text == course)
                    {
                        item.Selected = true;
                    }
                }
                //string imgUpload = (string)Session["ImgUpload"];
                Image1.ImageUrl = image;  // Set the image URL to the image control


            }

        }
        protected void Button6_Click(object sender, EventArgs e)
        {



            string Designation = DropDownList1.SelectedItem.ToString();


            //if (RadioButton1.Checked == true)
            //{
            //    Gender =RadioButton1.Text;
            //}
            //else if (RadioButton2.Checked == true)
            //{
            //    Gender =RadioButton2.Text;
            //}
            string Gender = "";
            if (RadioButtonList1.SelectedItem != null)
            {
                Gender = RadioButtonList1.SelectedItem.Text;  // Or use SelectedValue if that's how you've structured your List
            }


            string Course = "";

            // Loop through all selected items in the CheckBoxList and append their text values to the Course string
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    Course += item.Text + ",";  // Append the selected item text
                }
            }

            // Remove the last comma (if there are any selected items)
            if (Course.EndsWith(","))
            {
                Course = Course.Substring(0, Course.Length - 1);
            }



            if (FileUpload1.HasFile)
            {
                string fileExtension = Path.GetExtension(FileUpload1.FileName).ToLower();
                if (fileExtension == ".jpg" || fileExtension == ".png")
                {
                    // Define folder path to save the image
                    string folderPath = Server.MapPath("~/UploadedImages/");
                    //if (!Directory.Exists(folderPath))
                    //{
                    //    Directory.CreateDirectory(folderPath); // Create folder if it doesn't exist
                    //}

                    // Generate a unique file name to avoid overwriting
                    string uniqueFileName = Guid.NewGuid().ToString() + fileExtension;

                    // Save the image file to the server folder
                    string filePath = Path.Combine(folderPath, uniqueFileName);
                    FileUpload1.SaveAs(filePath);

                    // Store the relative file path in the database
                    string imagePath = "~/UploadedImages/" + uniqueFileName;

                    SqlConnection con = new SqlConnection("data source=SASHA;database=emprojectasp.net;integrated security=true");
                    con.Open();

                    string query = "INSERT INTO register (Name, Email, MobileNo, Designation, Gender, Course, ImgUpload) VALUES (@Name, @Email, @MobileNo, @Designation, @Gender, @Course, @ImgUpload)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@Email", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@MobileNo", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@Course", Course);
                    cmd.Parameters.AddWithValue("@ImgUpload", imagePath); // Store the image path

                    //  SqlDataAdapter adapter = new SqlDataAdapter(cmd);



                    cmd.ExecuteNonQuery();


                    Response.Redirect("Emplist.aspx");
                    // Display success message
                    Response.Write("Data saved successfully!");
                    con.Close();
                }
                else
                {
                    // Invalid file type
                    Response.Write("Only .jpg and .png files are allowed.");
                }
            }
            else
            {

                Response.Write("Please upload an image.");
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Emplist.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {



            string id = Session["Id"]?.ToString();
            if (string.IsNullOrEmpty(id))
            {
                Response.Write("ID not found in session.");
                return; // Exit if ID is not found
            }



            string Name = TextBox1.Text;
            string Email = TextBox2.Text;
            string MobileNo = TextBox3.Text;
            string Designation = DropDownList1.SelectedItem.Text; // or Value
            string Gender = RadioButtonList1.SelectedItem?.Text ?? string.Empty; // or Value

            // Handle the CheckBoxList (if multiple courses can be selected)
            string Course = string.Empty;
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    Course += item.Text + ", ";
                }
            }
            // Remove the trailing comma and space if any
            if (!string.IsNullOrEmpty(Course))
            {
                Course = Course.Substring(0, Course.Length - 2);
            }

            // Handle the ImgUpload field (default value if no file uploaded)
            string ImgUpload = string.Empty;

            // Check if a file is uploaded
            if (FileUpload1.HasFile)
            {
                try
                {
                    // Save the uploaded file to the server (in a folder named 'UploadedImages')
                    string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string filePath = Server.MapPath("~/UploadedImages/") + fileName;

                    // Save the file to the server
                    FileUpload1.SaveAs(filePath);

                    // Set ImgUpload to the relative file path
                    ImgUpload = "~/UploadedImages/" + fileName;
                }
                catch (Exception ex)
                {
                    // Handle any errors that may occur during file upload
                    Response.Write("Error uploading file: " + ex.Message);
                    return; // Exit the method to prevent proceeding with the database update
                }
            }

            // SQL connection and query
            using (SqlConnection conn = new SqlConnection("data source=SASHA;database=emprojectasp.net;integrated security=true"))
            {

                conn.Open();
                string query = "UPDATE register SET Name ='" + Name + "', Email = '" + Email + "', MobileNo = '" + MobileNo + "', Designation = '" + Designation + "', Gender = '" + Gender + "', Course = '" + Course + "', ImgUpload = '" + ImgUpload + "' WHERE ID = '" + id + "'";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.ExecuteNonQuery();
                Response.Write("Update Successful");
                Response.Redirect("Emplist.aspx");




            }




        }
    }
}