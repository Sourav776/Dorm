using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePage : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        string userType = "";
        string userName = "";
        if (Session["userName"] != null)
        {
            userType = Session["userType"].ToString();
            userName = Session["userName"].ToString();
        }
        
        if (userType == "1")
        {
            user.InnerText = "Student";
            Response.Redirect("AddInformation.aspx");
        }
        else if (userType == "2")
        {
            user.InnerText = "Provost";
            Response.Redirect("Hall_Review.aspx");
        }
        else if (userType == "3")
        {
            user.InnerText = "Director";
            Response.Redirect("Department_Review.aspx");
        }
        else if (userType == "4")
        {
            user.InnerText = "Chairman";
        }
        else if (userType == "5")
        {
            user.InnerText = "Admin-Personnel";
            Response.Redirect("Admin_Review.aspx");
        }
        else if (userType == "10")
        {
            user.InnerText = "Super-Admin";
            Response.Redirect("SpecialUser.aspx");
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string userName = Name_TB.Text;
        string password = Pass_TB.Text;

        //Establish Database Connection
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DormitoryConnectionString"].ToString());
        SqlDataReader dr;
        SqlCommand cmd;
        con.Open();
        string query = "SELECT * FROM Users WHERE UserName = '" + userName + "'";
        cmd = new SqlCommand(query, con);
        dr = cmd.ExecuteReader();
        
        while (dr.Read())
        {
            if (password == dr[3].ToString())
            {
                HttpContext.Current.Session.Add("userName", userName);
                HttpContext.Current.Session.Add("userType", dr[4].ToString());
                //Response.Redirect("AddInformation.aspx");
            }
        }
        con.Close();
    }
}