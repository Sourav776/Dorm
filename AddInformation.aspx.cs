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

public partial class AddInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //LoadHall("");
        //LoadExam("");
        string userType = "";
        string userName = "";
        if (Session["userName"] != null)
        {
            userType = Session["userType"].ToString();
            userName = Session["userName"].ToString();
        }
        if (Session["userName"] == null)
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
        if (Check())
        {
            string UserName = Session["userName"].ToString();
            string Hall = Hall_DDL.SelectedValue;
            string ExamName = ExamName_DDL.SelectedValue;
            string Dept = Dept_DDL.SelectedValue;
            string ClassRoll = ClassRoll_TB.Text;
            string RegistrationNumber = RegistrationNumber_TB.Text;
            string Sessi = Session_DDL.SelectedValue;
            string FatherName = FatherName_TB.Text;
            string MotherName = MotherName_TB.Text;
            string UserType = Session["userType"].ToString();
            string Time = DateTime.Now.ToString("yyyy-MM-dd");
            string Signature = Request.PhysicalApplicationPath + "Signatures\\" + UserName + ".PNG";

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
                        con.Open();
                        string query = "INSERT INTO StudentInfo ([UserName],[Hall],[ExamName],[Dept],[ClassRoll]" +
                                ",[RegistrationNumber],[Session],[FatherName],[MotherName],[UserType],[Time],[HallStatus]" +
                                ",[DeptStatus],[AdminStatus],[Signature]) VALUES (@UserName,@Hall,@ExamName,@Dept,@ClassRoll," +
                                "@RegistrationNumber,@Session,@FatherName,@MotherName,@UserType,@Time,@HallStatus,@DeptStatus,@AdminStatus,@Signature)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("UserName", UserName);
                        cmd.Parameters.AddWithValue("Hall", Hall);
                        cmd.Parameters.AddWithValue("ExamName", ExamName);
                        cmd.Parameters.AddWithValue("Dept", Dept);
                        cmd.Parameters.AddWithValue("ClassRoll", ClassRoll);
                        cmd.Parameters.AddWithValue("RegistrationNumber", RegistrationNumber);
                        cmd.Parameters.AddWithValue("Session", Sessi);
                        cmd.Parameters.AddWithValue("FatherName", FatherName);
                        cmd.Parameters.AddWithValue("MotherName", MotherName);
                        cmd.Parameters.AddWithValue("UserType", UserType);
                        cmd.Parameters.AddWithValue("Time", Time);
                        cmd.Parameters.AddWithValue("HallStatus", 1);
                        cmd.Parameters.AddWithValue("DeptStatus", 1);
                        cmd.Parameters.AddWithValue("AdminStatus", 1);
                        cmd.Parameters.AddWithValue("Signature", Signature);
                        cmd.ExecuteNonQuery();
                        Response.Write("Data Uploaded");
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


            //Label9.Visible = true;
            //string uploadFolder = Request.PhysicalApplicationPath + "Signatures\\";
            //if (FileUpload1.HasFile)
            //{
            //    string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            //    FileUpload1.SaveAs(uploadFolder + UserName + extension);
            //    Label9.Text = "File uploaded successfully";
            //}
            //else
            //{
            //    Label9.Text = "First select a file.";
            //}
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "SomeKey", "alert('You have already filled up your form.');", true);
        }
    }
    
    protected bool Check()
    {
       string UserName = Session["userName"].ToString();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DormitoryConnectionString"].ToString()))
            try
            {
                //SqlDataReader dr;
                SqlCommand cmd;
                SqlDataReader dr;
                con.Open();
                string query = "SELECT * FROM StudentInfo WHERE UserName = '" + UserName + "'";
                cmd = new SqlCommand(query, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr[0].ToString() == "") return true;
                    else if (dr[2].ToString() == ExamName_DDL.SelectedValue && dr[4].ToString() == ClassRoll_TB.Text && dr[5].ToString() == RegistrationNumber_TB.Text && dr[6].ToString() == Session_DDL.SelectedValue)
                    {
                        return false;
                    }
                }

                string q = "select count(*) from StudentInfo where HallStatus=1 and UserName='" + UserName + "'";
                cmd = new SqlCommand(q, con);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        return true;
    }
    protected void Male_CheckedChanged(object sender, EventArgs e)
    {
        LoadHall("Male");
    }

    protected void Female_CheckedChanged(object sender, EventArgs e)
    {
        LoadHall("Female");

    }
    protected void Year_CheckedChanged(object sender, EventArgs e)
    {
        LoadExam("Year");
    }

    protected void Semester_CheckedChanged(object sender, EventArgs e)
    {
        LoadExam("Semester");

    }

    private void LoadHall( string allotee )
    {

        Hall_DDL.Items.Clear();
        DataTable subjects = new DataTable();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DormitoryConnectionString"].ToString()))
        {

            try
            {
                string query = "SELECT  HallName,Allotee FROM Hall where Allotee='" + allotee + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(subjects);

                Hall_DDL.DataSource = subjects;
                Hall_DDL.DataTextField = "HallName";
                Hall_DDL.DataValueField = "HallName";
                Hall_DDL.DataBind();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                con.Close();
            }

        }
        Hall_DDL.Items.Insert(0, new ListItem("<Select your hall>", "0"));


    }
    private void LoadExam(string type)
    {

        ExamName_DDL.Items.Clear();
        DataTable subjects = new DataTable();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DormitoryConnectionString"].ToString()))
        {

            try
            {
                string query = "select Type,ExamName from Exam where Type='" + type + "'order by [Order]";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(subjects);

                ExamName_DDL.DataSource = subjects;
                ExamName_DDL.DataTextField = "ExamName";
                ExamName_DDL.DataValueField = "ExamName";
                ExamName_DDL.DataBind();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

        }
        ExamName_DDL.Items.Insert(0, new ListItem("<You will appear for>", "0"));


    }

    protected void logout(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("HomePage.aspx");
    }

}