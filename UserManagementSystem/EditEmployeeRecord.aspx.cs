using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagementSystem.Model;

namespace UserManagementSystem
{
    public partial class EditEmployeeRecord : System.Web.UI.Page
    {
        private string connString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDataToEdit();
            }
        }

        private void GetDataToEdit()
        {
            var Data = (EmployeeModel)Session["FormDataToEdit"];
            if (Data != null)
            {
                hdnfldEmployeeID.Value = Data.Id.ToString();
                txtName.Text = Data.Name;
                txtFatherName.Text = Data.FatherName;
                txtAge.Text = Data.Age;
                txtEmail.Text = Data.Email;
                txtAddress.Text = Data.Address;
                txtPinCode.Text = Data.Pincode;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(connString);
            cmd = new SqlCommand("update[dbo].[Registration] set Name = @Name, FatherName = @FatherName, Age = @Age, Email = @Email, Address = @Address, PinCode = @PinCode where Reg_id = @emp_id; ", con);
            cmd.Parameters.AddWithValue("emp_id", hdnfldEmployeeID.Value);
            cmd.Parameters.AddWithValue("Name", txtName.Text);
            cmd.Parameters.AddWithValue("FatherName", txtFatherName.Text);
            cmd.Parameters.AddWithValue("Age", txtAge.Text);
            cmd.Parameters.AddWithValue("Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("PinCode", txtPinCode.Text);
            con.Open();
            int response = cmd.ExecuteNonQuery();
            con.Close();

            if (response > 0)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Data saved successfully!";
                Response.Redirect("ShowEmployeeRecord.aspx");
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Data not valid and not saved!";
            }

            txtName.Text = "";
            txtFatherName.Text = "";
            txtAge.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtPinCode.Text = "";
        }

    }
}
