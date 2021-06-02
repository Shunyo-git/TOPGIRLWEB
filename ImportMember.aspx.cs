using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TopGirl.BusinessLogicLayer;
using TopGirl.DataAccessLayer;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.OleDb;

public partial class Admin_ImportMember : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Tran(string SourceType)
    {

        string _DatabaseFileName = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|member.mdb;";

       

           
                string UserName;
                string Password;
                string Email;
                string ChineseName;
                 MemberInfo.GenderType Gender = MemberInfo.GenderType.unknown;
                DateTime Birthday;
                string Telphone = string.Empty;
                string MobilePhone = string.Empty;
                string Address = string.Empty;
                string Career = string.Empty;
                string Marital = string.Empty;
                bool IsSubscription = false;
                bool IsMemberCard = false;

                using (OleDbConnection connection = new OleDbConnection(_DatabaseFileName))
                {

                    string sql = "SELECT m_username,m_passwd,m_name,m_sex,m_birthday,m_email,m_phone,m_cellphone,m_address,m_epaper FROM " + SourceType;
                    OleDbCommand command = new OleDbCommand();
                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        UserName = reader.GetString(0);
                        Password = reader.GetString(1);
                        ChineseName = reader.GetString(2);
                        if (reader.GetString(3) == "m")
                        {
                            Gender = MemberInfo.GenderType.male;
                        }
                        if (reader.GetString(3) == "w")
                        {
                            Gender = MemberInfo.GenderType.female;
                        }
                        Birthday = reader.GetDateTime(4);
                        Email = reader.GetString(5);
                        Telphone = reader.GetString(6);
                        MobilePhone = reader.GetString(7);
                        Address = reader.GetString(8);
                        if (reader.GetString(9) == "o")
                        {
                            IsSubscription = true;
                        }

                        if (SourceType == "membervip")
                        {
                            IsMemberCard = true;
                        }

                        if (Membership.GetUser(UserName) == null)
                        {
                            MembershipUser user = Membership.CreateUser(UserName, Password, Email);
                            Response.Write(string.Format("CreateUser.....{0}",UserName) );
                            ProfileCommon p = Profile.GetProfile(UserName);

                            if (p != null)
                            {
                                p.MemberInfo = new MemberInfo(ChineseName, Gender, Birthday, Telphone, MobilePhone, Address, Career, Marital, IsSubscription, IsMemberCard);
                                p.Save();
                                Response.Write(string.Format("<BR / >MemberInfo.....{0}", ChineseName));
                            }
                            Response.Write("<BR / >");
                        }

                        
                    }
                }
            
       
       

    }
   
    protected void Button2_Click(object sender, EventArgs e)
    {
        Tran("memberData");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Tran("membervip");
    }



}
