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
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    enum DisplayStatus { None, Error, Success }
    private void DisplayMsg(DisplayStatus st)
    {
        string Msg = string.Empty;
        switch (st)
        {
            case DisplayStatus.Error:
                Msg = "alert(\"會員帳號與Email不符合！\");";
                break;
            case DisplayStatus.Success:
                Msg = "alert(\"您的新密碼已經寄出，請檢查您的Email信箱！\");location.href=\"/\";"; 
                break;
        }

        ResponseClientScript("SendPassword",Msg);
      
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string userName = UserName.Text;
        string email = Email.Text;

        if (Membership.GetUserNameByEmail(email) != userName)
        {
            DisplayMsg(DisplayStatus.Error);
        }
        else
        {
            GeneratePassword();
        }
    }
    private static string GeneratePasswordString()
    {
        string newPassword = Membership.GeneratePassword(8, 0);

        newPassword = newPassword.Replace("&", DateTime.Now.Hour.ToString());
        newPassword = newPassword.Replace("$", DateTime.Now.Minute.ToString());
        newPassword = newPassword.Replace("^", DateTime.Now.Second.ToString());
        newPassword = newPassword.Replace("{", DateTime.Now.Hour.ToString());
        newPassword = newPassword.Replace("}", DateTime.Now.Minute.ToString());
        newPassword = newPassword.Replace("(", DateTime.Now.Second.ToString());
        newPassword = newPassword.Replace(")", DateTime.Now.Second.ToString());
        newPassword = newPassword.Replace("[", DateTime.Now.Millisecond.ToString());
        newPassword = newPassword.Replace("]", DateTime.Now.Millisecond.ToString());
        newPassword = newPassword.Replace(";", DateTime.Now.Hour.ToString());
        newPassword = newPassword.Replace("_", DateTime.Now.Minute.ToString());
        newPassword = newPassword.Replace(":", DateTime.Now.Millisecond.ToString());
        newPassword = newPassword.Replace("|", DateTime.Now.Millisecond.ToString());
        return newPassword;
    }
    private void GeneratePassword()
    {
        string userName = UserName.Text;
        MembershipUser m = Membership.GetUser(userName);
        if (m != null)
        {
 
            string newPassword = GeneratePasswordString();

            if (sendPassword(m.Email, newPassword))
            {
                m.ChangePassword(m.GetPassword(), newPassword);
                DisplayMsg(DisplayStatus.Success);
            }

        }


    }
    private Boolean sendPassword(string email, string userPassword)
    {
        String ScriptKey = "sendPassword Message";
        Boolean blnResult = false;
        string subject = ConfigurationManager.AppSettings["ForgetPassword_Subject"];
        string fromEmail = ConfigurationManager.AppSettings["ForgetPassword_FromEmail"];
        string fromName = ConfigurationManager.AppSettings["ForgetPassword_FromName"];
        string ccEmail = ConfigurationManager.AppSettings["ForgetPassword_CCEmail"];
        string mailServer = ConfigurationManager.AppSettings["SMTP Server"];
        string FileName = Server.MapPath("/Template/ForgetPasswordTemplate.txt");
        StreamReader reader = new StreamReader(FileName, System.Text.Encoding.Default);
        string body = reader.ReadToEnd();
        reader.Close();

        int port;
        if (!Int32.TryParse(ConfigurationManager.AppSettings["MTP Port"], out port))
        {
            port = 25;
        }

        string mailfrom = string.Format("{0}<{1}>", fromName, fromEmail);
        string mailto = email;
        body = string.Format(body, userPassword);

        try
        {

            MailMessage message = new MailMessage(mailfrom, mailto, subject, body);
            if (ccEmail.Length > 0 || ccEmail != string.Empty)
            {
                string[] strCC = ccEmail.Split(new Char[] { ';', ',' });


                foreach (string strThisCC in strCC)
                {
                    message.CC.Add(strThisCC);
                }
            }

            SmtpClient mySmtpClient = new SmtpClient(mailServer, port);
            mySmtpClient.UseDefaultCredentials = true;
            mySmtpClient.Send(message);
            blnResult = true;
        }
        catch (FormatException e)
        {
            ResponseClientScript(ScriptKey, "Format Exception: " + e.Message);

        }
        catch (SmtpException e)
        {
            ResponseClientScript(ScriptKey, "SmtpException Exception: " + e.Message);
        }
        catch (Exception e)
        {
            ResponseClientScript(ScriptKey, " Exception: " + e.Message);
        }

        return blnResult;
        // throw new Exception("The method or operation is not implemented.");
    }
    void ResponseClientScript(string ScriptKey, string Msg)
    {
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();

        if (!cs.IsStartupScriptRegistered(cstype, ScriptKey))
        {
            cs.RegisterStartupScript(cstype, ScriptKey, Msg, true);
        }
    }
}
