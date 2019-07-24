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
    public partial class ShowEmployeeRecord : Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlCommand cmd;
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GetGridViewData();
                DataShow();
            }

        }
        private void GetGridViewData()
        {
            using (con = new SqlConnection(ConnectionString))
            {
                string cmdText = "select Reg_id, Name,FatherName,Age,Email,Address,PinCode from [dbo].[Registration]";
                using (cmd = new SqlCommand(cmdText, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    grvEmployee.DataSource = ds;
                    grvEmployee.DataBind();
                }
            }
        }
        protected void grvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvEmployee.PageIndex = e.NewPageIndex;
            DataShow();
        }
        protected void grvEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                con = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("DELETE FROM [dbo].[Registration] WHERE Reg_id=@EmpId", con);
                Label id = (Label)grvEmployee.Rows[e.RowIndex].FindControl("lblEmpId");
                cmd.Parameters.AddWithValue("@EmpId", Convert.ToInt32(id.Text));
                con.Open();
                int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                con.Close();
                if (result > 0)
                {
                    ShowAlertMessage("Record Is Deleted Successfully");
                    grvEmployee.EditIndex = -1;
                    GetGridViewData();
                }
                else
                {
                    lblMessage.Text = "Failed";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    GetGridViewData();
                }
            }
            catch (Exception ex)
            {
                ShowAlertMessage("Check your input data");
            }
        }
        private static void ShowAlertMessage(string error)
        {
            System.Web.UI.Page page = System.Web.HttpContext.Current.Handler as System.Web.UI.Page;
            if (page != null)
            {
                error = error.Replace("'", "\'");
                System.Web.UI.ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
            }
        }
        //ShowData method for Displaying Data in Gridview  
        private void DataShow()
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" SELECT * FROM [dbo].[Registration] ORDER BY Name, FatherName,Age,Email,Address,PinCode ;", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            grvEmployee.DataSource = ds;
            grvEmployee.DataBind();
            con.Close();
        }

        protected void grvEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.  
            int index = e.NewEditIndex;
            Label empid = (Label)grvEmployee.Rows[index].FindControl("lblEmpId");
            var formData = new EmployeeModel
            {
                Id = Convert.ToInt32(empid.Text),
                Name = ((Label)grvEmployee.Rows[index].FindControl("lblName")).Text.ToString(),
                FatherName = ((Label)grvEmployee.Rows[index].FindControl("lblFatherName")).Text.ToString(),
                Age = ((Label)grvEmployee.Rows[index].FindControl("lblAge")).Text.ToString(),
                Email = ((Label)grvEmployee.Rows[index].FindControl("lblEmail")).Text.ToString(),
                Address = ((Label)grvEmployee.Rows[index].FindControl("lblAddress")).Text.ToString(),
                Pincode = ((Label)grvEmployee.Rows[index].FindControl("lblPinCode")).Text.ToString(),
            };

            Session["FormDataToEdit"] = formData;
            Response.Redirect("EditEmployeeRecord.aspx");
        }
      
    }
}