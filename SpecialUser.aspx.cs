using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SpecialUser : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        Label9.Visible = false;
        string userType = "";
        string userName = "";
        if (Session["userName"] != null)
        {
            userType = Session["userType"].ToString();
            userName = Session["userName"].ToString();
        }
        if(userType!="10")
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
        string Entity=Entity_DDL.SelectedValue;
        string First = First_TB.Text;
        string Last = Last_TB.Text;
        string UserName = Name_TB.Text;
        string Password = Pass_TB.Text;
        string Type="";
        string Signature = Request.PhysicalApplicationPath + "Signatures\\" + UserName + ".PNG";

        
          if(Entity=="Provost") {Type="2";}
          if(Entity=="Director") {Type="3";}
          if(Entity=="Admin-personnel") {Type="5";}

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
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DormitoryConnectionString"].ToString()))
            {
                try
                {
                    bool b = true;
                    Label9.Visible = true;
                    string uploadFolder = Request.PhysicalApplicationPath + "Signatures\\";
                    if (FileUpload1.HasFile)
                    {
                        string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                        FileUpload1.SaveAs(uploadFolder + UserName + extension);
                        Label9.Text = "File uploaded successfully";
                        b = true;
                    }
                    else
                    {
                        Label9.Text = "First select a signature picture.";
                        b = false;
                    }
                    if (b == true)
                    {

                        UserMessage.Visible = false;

                        con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO Users ([FirstName],[LastName],[UserName],[Password],[UserType],[Signature],[Entity]) VALUES (@First, @Last, @UserName,@Password,@Type,@Signature,@Entity)", con);
                        cmd.Parameters.AddWithValue("First", First);
                        cmd.Parameters.AddWithValue("Last", Last);
                        cmd.Parameters.AddWithValue("UserName", UserName);
                        cmd.Parameters.AddWithValue("Password", Password);
                        cmd.Parameters.AddWithValue("UserType", Type);
                        cmd.Parameters.AddWithValue("Signature", Signature);
                        cmd.Parameters.AddWithValue("Entity", Entity);
                        cmd.ExecuteNonQuery();
                        if(Type=="2")
                        {
                            SqlCommand c = new SqlCommand("INSERT INTO Provost ([FirstName],[LastName],[Hall]," +
                                "[UserType],[Signature]) VALUES (@First, @Last, @Hall,@Type,@Signature)", con);

                            c.Parameters.AddWithValue("First", First);
                            c.Parameters.AddWithValue("Last", Last);
                            c.Parameters.AddWithValue("Hall", Entity);
                            c.Parameters.AddWithValue("UserType", Type);
                            c.Parameters.AddWithValue("Signature", Signature);
                            c.ExecuteNonQuery();
                        }
                        if (Type == "3")
                        {
                            SqlCommand c = new SqlCommand("INSERT INTO Director ([FirstName],[LastName],[Dept]," +
                                "[UserType],[Signature]) VALUES (@First, @Last, @Dept,@Type,@Signature)", con);

                            c.Parameters.AddWithValue("First", First);
                            c.Parameters.AddWithValue("Last", Last);
                            c.Parameters.AddWithValue("Dept", Entity);
                            c.Parameters.AddWithValue("UserType", Type);
                            c.Parameters.AddWithValue("Signature", Signature);
                            c.ExecuteNonQuery();
                        }
                        if (Type == "5")
                        {
                            SqlCommand c = new SqlCommand("INSERT INTO Admin ([FirstName],[LastName]," +
                                "[UserType],[Signature]) VALUES (@First, @Last,@Type,@Signature)", con);

                            c.Parameters.AddWithValue("First", First);
                            c.Parameters.AddWithValue("Last", Last);
                            c.Parameters.AddWithValue("UserType", Type);
                            c.Parameters.AddWithValue("Signature", Signature);
                            c.ExecuteNonQuery();
                        }
                        con.Close();
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("There is a problem while uploading data");
                }
                finally
                {
                    con.Close();
                }
            }

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

    protected void Director_CheckedChanged(object sender, EventArgs e)
    {
        LoadDept();
    }

    protected void Provost_CheckedChanged(object sender, EventArgs e)
    {
        LoadHall();

    }
    protected void Admin_CheckedChanged(object sender, EventArgs e)
    {
        LoadAdmin();
    }

    

    private void LoadHall()
    {

        Entity_DDL.Items.Clear();
        DataTable Hall = new DataTable();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DormitoryConnectionString"].ToString()))
        {

            try
            {
                string query = "SELECT  HallName FROM Hall";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(Hall);

                Entity_DDL.DataSource = Hall;
                Entity_DDL.DataTextField = "HallName";
                Entity_DDL.DataValueField = "HallName";
                Entity_DDL.DataBind();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

        }
        Entity_DDL.Items.Insert(0, new ListItem("<Select hall>", "0"));


    }

    private void LoadDept()
    {

        Entity_DDL.Items.Clear();
        DataTable Dept = new DataTable();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DormitoryConnectionString"].ToString()))
        {

            try
            {
                string query = "select Dept from Department";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(Dept);

                Entity_DDL.DataSource =Dept;
                Entity_DDL.DataTextField = "Dept";
                Entity_DDL.DataValueField = "Dept";
                Entity_DDL.DataBind();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

        }
        Entity_DDL.Items.Insert(0, new ListItem("<Select Department/Institute>", "0"));


    }
    private void LoadAdmin()
    {
        Entity_DDL.Items.Clear();
        Entity_DDL.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void logout(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("HomePage.aspx");
    }
}
