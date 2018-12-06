
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPag.master" AutoEventWireup="true" CodeFile="AddInformation.aspx.cs" Inherits="AddInformation" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title> Form Filling</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="List" runat="Server">
    <li class="nav-item active">
        <a class="nav-link" href="HomePage.aspx">Home Page<span class="sr-only"></span></a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="UserCreation.aspx">Register New User <span class="sr-only"></span></a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="#">About <span class="sr-only"></span></a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="AddInformation.aspx">Fill out Form</a>
    </li>
    <li class="nav-item active">
        <a class="nav-link" href="Final.aspx">Print form</a>
    </li>
    <li>
      <a id="user" href="#" runat="server"></a>
    </li>
    <asp:Button ID="log" CssClass="logout" runat="server" Text="Log Out" borber="none" OnClick="logout" />
</asp:Content>


 <asp:Content ID="Content3" ContentPlaceHolderID="Control" Runat="Server">

   <div class="text-center">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                     <asp:ScriptManager ID="ScriptManager1" runat="server">
                      </asp:ScriptManager>
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                          <ContentTemplate>
                              <div>
                                  <asp:Label ID="Label1" CssClass="YouL" runat="server" Text="You are"></asp:Label>
                                  
                                  <asp:RadioButton ID="Male" CssClass="MaleR" runat="server" Text="Male" GroupName="Hall" AutoPostBack="true" OnCheckedChanged="Male_CheckedChanged" />
                                  <asp:RadioButton ID="Female" CssClass="FemaleR" runat="server" Text="Female" GroupName="Hall" AutoPostBack="true" OnCheckedChanged="Female_CheckedChanged" />

                              </div>
                              
                              <div>
                                  <asp:DropDownList ID="Hall_DDL" CssClass="HallDDL" runat="server" AppendDataBoundItems="true">
                                  </asp:DropDownList>
                              </div>
                              <br />
                              <div>
                                  
                                  <asp:Label ID="Label2" runat="server" CssClass="TypeL" Text="Examination Type"></asp:Label>
                                  <asp:RadioButton ID="Year" CssClass="YearR" runat="server" AutoPostBack="true" GroupName="Type" OnCheckedChanged="Year_CheckedChanged" Text="Yaer" />
                                  <asp:RadioButton ID="Semester" CssClass="SemesterR" runat="server" AutoPostBack="true" GroupName="Type" OnCheckedChanged="Semester_CheckedChanged" Text="Semester" />
                              </div>

                              <div>
                                  <asp:DropDownList ID="ExamName_DDL" CssClass="TypeDDL" runat="server" AppendDataBoundItems="true">
                                      
                                  </asp:DropDownList>
                                  
                              </div>
                              <div>
                                  <br />
                                  <asp:Label ID="Label3" CssClass="DeptL" runat="server" Text="Select Department/Institute"></asp:Label>
                                  </br>
                                  <asp:DropDownList ID="Dept_DDL" CssClass="DeptDDL" runat="server" DataSourceID="SqlDataSource1" DataTextField="Dept" DataValueField="Dept" AppendDataBoundItems="true">
                                      <asp:ListItem Text="<Select Department>" Value="0" />
                                  </asp:DropDownList>
                                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DormitoryConnectionString %>" SelectCommand="SELECT [Dept] FROM [Department] ORDER BY [Dept]"></asp:SqlDataSource>
                              </div>
                              <br />
                              <div>
                                  <asp:Label ID="Label4" CssClass="RollL" runat="server" Text="Class Roll"></asp:Label>
                                  <asp:TextBox ID="ClassRoll_TB" CssClass="RollT" runat="server"></asp:TextBox>
                              </div>
                              <br />
                              <div>
                                  <asp:Label ID="Label10" CssClass="RegiL" runat="server" Text="Registration Number"></asp:Label>
                                  <asp:TextBox ID="RegistrationNumber_TB" CssClass="RegiT" runat="server"></asp:TextBox>
                              </div>
                              <br />
                              <div>
                                  <asp:Label ID="Label5" CssClass="SessionL" runat="server" Text="Session"></asp:Label>
                                  <asp:DropDownList ID="Session_DDL" CssClass="SessionDDL" runat="server" DataSourceID="SqlDataSource2" DataTextField="Session" DataValueField="Session" AppendDataBoundItems="true">
                                      <asp:ListItem Text="<Select Session>" Value="0" />
                                  </asp:DropDownList>

                                  <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DormitoryConnectionString %>" SelectCommand="SELECT [Session] FROM [Session] ORDER BY [Session]"></asp:SqlDataSource>
                              </div>
                              <br />
                              <div>
                                  <asp:Label ID="Label6" CssClass="FatherL" runat="server" Text="Father Name"></asp:Label>
                                  <asp:TextBox ID="FatherName_TB" CssClass="FatherT" runat="server"></asp:TextBox>
                              </div>
                              <br />
                              <div>
                                  <asp:Label ID="Label7" CssClass="MotherL" runat="server" Text="Mother Name"></asp:Label>
                                  <asp:TextBox ID="MotherName_TB" CssClass="MotherT" runat="server"></asp:TextBox>
                              </div>

                              <br />

                          </ContentTemplate>
              </asp:UpdatePanel>
                    <div>
                        <asp:Label ID="Label8" CssClass="SignL" runat="server" Text="Upload Signature"></asp:Label>
                        <asp:FileUpload ID="FileUpload1" CssClass="Upload" runat="server" />
                        <div>
                            <div>
                                <asp:Button ID="Button1" CssClass="SaveB" runat="server" OnClick="Button1_Click" Text="Save Data" />
                            </div>
                            <asp:Label ID="Label9" CssClass="MesL" runat="server" Text="" Visible="false"></asp:Label>
                        </div>

                    </div>
                    </div>
                </div>
            </div>
          </div>


     </asp:Content>