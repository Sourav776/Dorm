using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string First = First_TB.Text;
        string Last = Last_TB.Text;
        string Email = Email_TB.Text;
        string Cell = Cell_TB.Text;
        string Dept = Dept_DDL.SelectedValue;
        string Session = Session_DDL.SelectedValue;
        String Pass = Pass_TB.Text;
        String Repass = Repass_TB.Text;

        if (IsValidEmail(Email) == false)
        {
            Response.Redirect("Default.aspx");
            Response.Write("This aint a valid email");
        }
        else
        {
           // Response.Write("Here is something going on");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DormitoryConnectionString"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO UserInfo ([FirstName],[LastName],[Email],[CellNo],[Dept],[Session],[Time],[pass],[UserType]) VALUES (@First, @Last, @Email,@Cell,@Dept,@Session,@Time,@Pass,@Type)", con);
            cmd.Parameters.AddWithValue("First", First);
            cmd.Parameters.AddWithValue("Last", Last);
            cmd.Parameters.AddWithValue("Email", Email);
            cmd.Parameters.AddWithValue("Cell", Cell);
            cmd.Parameters.AddWithValue("Dept", Dept);
            cmd.Parameters.AddWithValue("Session", Session);
            cmd.Parameters.AddWithValue("Time", DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"));
            cmd.Parameters.AddWithValue("Pass", Pass);
            cmd.Parameters.AddWithValue("Type", 1);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }

   protected  bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }


}