using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCreation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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
        }
        else if (userType == "10")
        {
            user.InnerText = "Super-Admin";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string First = First_TB.Text;
        string Last = Last_TB.Text;
        string UserName = Name_TB.Text;
        string Password = Pass_TB.Text;
        if (UserName == "")
        {
            Response.Redirect("HomePage.aspx");
        }
        else if (!IsValidUser(UserName))
        {
            //ClientScript.RegisterStartupScript(Page.GetType(), "SomeKey", "alert('Please Enter a valid Email');", true);
            UserMessage.Visible = true;
        }
        else
        {
                UserMessage.Visible = false;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DormitoryConnectionString"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Users ([FirstName],[LastName],[UserName],[Password],[UserType]) VALUES (@First, @Last, @UserName,@Password,@UserType)", con);
                cmd.Parameters.AddWithValue("First", First);
                cmd.Parameters.AddWithValue("Last", Last);
                cmd.Parameters.AddWithValue("UserName",UserName);
                cmd.Parameters.AddWithValue("Password",Password);
                cmd.Parameters.AddWithValue("UserType",1);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("HomePage.aspx");
         
        }
    }


    protected bool PassCheck(string a, string b)
    {
        if (a == b)
            return true;
        else
            return false;
    }

    protected bool IsValidUser(string UserName)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DormitoryConnectionString"].ToString());
        SqlDataReader dr;
        SqlCommand cmd;
        string user = null;
        con.Open();
        string query = "SELECT * FROM Users WHERE UserName='" + UserName + "'";
        cmd = new SqlCommand(query, con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            user = dr[2].ToString();
        }

        if (user == null)
            return true;
        else
            return false;

    }
    protected void logout(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("HomePage.aspx");
    }
}