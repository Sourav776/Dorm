using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Final : System.Web.UI.Page
{
    ReportDocument rprt = new ReportDocument();
    protected void Page_Init(object sender, EventArgs e)
    {
        string userType = "";
        string userName = "";
        if (Session["userName"] != null)
        {
            userType = Session["userType"].ToString();
            userName = Session["userName"].ToString();
        }
        if (userType != "1")
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
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string UserName = Session["userName"].ToString();
        rprt.Load(Server.MapPath("~/CrystalReport.rpt"));
        rprt.SetDatabaseLogon("sa", "sqladmin", "SOURAV", "Dormitory", true);
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DormitoryConnectionString"].ToString());
        SqlCommand cmdRpt = new SqlCommand("report", con);
        cmdRpt.CommandType = CommandType.StoredProcedure;
        cmdRpt.Parameters.AddWithValue("@UserName", UserName);
        SqlDataAdapter sda = new SqlDataAdapter(cmdRpt);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        rprt.SetDataSource(ds);
        crv.ReportSource = rprt;
        ParameterField field1 = this.crv.ParameterFieldInfo[0];
        ParameterDiscreteValue val1 = new ParameterDiscreteValue();
        val1.Value = UserName;
        field1.CurrentValues.Add(val1);
       // Response.Write(UserName);

    }
    protected void page_Unload(object sender, EventArgs e)
    {
        rprt.Dispose();
        rprt.Close();
    }

    protected void logout(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("HomePage.aspx");
    }
}