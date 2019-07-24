using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagementSystem.Model;

namespace UserManagementSystem
{
    public partial class RegisterEmployee : Page
    {
        private string connString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDataToEdit();
                GetQualificationlist();
            }
        }

        private void GetDataToEdit()
        {
            var Data = (EmployeeModel)Session["FormDataToEdit"];
            if (Data != null)
            {
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
            cmd = new SqlCommand("insert into Registration values (@Name, @FatherName,@Age, @Email, @Address, @PinCode)", con);
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
                Response.Redirect("ShowEmployeeRecord .aspx");
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
        private void GetQualificationlist()
        {
            con = new SqlConnection(connString);
            string cmdText = "select qual_id, Name from Qualification";
            using (cmd = new SqlCommand(cmdText, con))
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                ddlQualification.DataSource = ds;
                ddlQualification.DataBind();
                con.Close();

            }
        }
    }
}