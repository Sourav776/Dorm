using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Hall_Review : System.Web.UI.Page
{

     static DataTable table = new DataTable();
    static int pos = 1;
    protected void Page_Init(object sender, EventArgs e)
    {
        string userType = "";
        string userName = "";
        if (Session["userName"] != null)
        {
            userType = Session["userType"].ToString();
            userName = Session["userName"].ToString();
        }
        if (userType!="2")
        {
            Response.Redirect("HomePage.aspx");
        }
        if (userType == "1")
        {
            user.InnerText = "Student";
        }
        else if (userType == "2")
        {
            user.InnerText = "Provost";
        }
        else if (userType == "3")
        {
            user.InnerText = "Director";
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

        table.Clear();
        func();
        showData(pos, table);
        message.Visible = false;

    }
    public void showData( int index, DataTable table)
    {
        try
        {

            Name1.InnerText = table.Rows[index-1][19].ToString() + " " + table.Rows[index-1][20].ToString();
            Hall1.InnerText = table.Rows[index-1][1].ToString();
            ExamName1.InnerText = table.Rows[index-1][2].ToString();
            Dept1.InnerText = table.Rows[index-1][3].ToString();
            ClassRoll1.InnerHtml = table.Rows[index-1][4].ToString();
            RegisNum1.InnerHtml = table.Rows[index-1][5].ToString();
            Sessi1.InnerHtml = table.Rows[index-1][6].ToString();
            FatherName1.InnerHtml = table.Rows[index-1][7].ToString();
            MotherName1.InnerHtml = table.Rows[index-1][8].ToString();
            Session["ID"] = table.Rows[index-1][9].ToString();
        }
        catch(Exception ex)
        {
            //Response.Write("Currently no forms pending");
        }
    }
    protected void func()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DormitoryConnectionString"].ToString()))
            try
            {
                con.Open();
                SqlDataAdapter da;
                string query = "select * from StudentInfo A Left join Users B ON A.UserName=B.UserName AND " +
                    "A.UserType=B.UserType where A.HallStatus=1 AND A.DeptStatus=2 AND A.HTime IS NULL order by A.ID,A.DTime";
                da = new SqlDataAdapter(query, con);
                da.Fill(table);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        pos++;
        table.Clear();
        func();
        if (pos <= table.Rows.Count)
        {
            showData(pos, table);
        }
        if (pos > table.Rows.Count)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "SomeKey", "alert('No more data');", true);
            pos = table.Rows.Count;
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        pos--;
        table.Clear();
        func();
        if (pos >= 1)
        {
            showData(pos, table);
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "SomeKey", "alert('No more data');", true);
            pos = 1;
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string ID = Session["ID"].ToString();
        string time = DateTime.Now.ToString("yyyy-MM-dd");
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DormitoryConnectionString"].ToString());
        con.Open();
        string query = "UPDATE StudentInfo SET  HallStatus=@Status,HTime =@Time WHERE ID=@ID";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Status", 2);
        cmd.Parameters.AddWithValue("@Time", time);
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.ExecuteNonQuery();
        message.Visible = true;
        message.Text = "This form has been approved.Please click next/previous button";
        con.Close();
    }
    protected void logout(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("HomePage.aspx");
    }
}

