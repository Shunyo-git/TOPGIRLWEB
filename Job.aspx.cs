using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Job : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ibtnSubmit.Attributes.Add("onmouseout","MM_swapImgRestore()");
        ibtnSubmit.Attributes.Add("onmouseover", "MM_swapImage('" + ibtnSubmit.UniqueID + "','','img/hire/send_1.gif',1)");
        BindDate();
    }

    void BindDate()
    {


        if (selYear.Items.Count <= 0)
        {
            for (int i = 1900; i < DateTime.Now.Year ; i++)
            {
                selYear.Items.Add(i.ToString());
            }
        }
        if (selMonth.Items.Count <= 0)
        {
            for (int i = 1; i <= 12; i++)
            {
                selMonth.Items.Add(i.ToString());
            }
        }
        if (selDay.Items.Count <= 0)
        {
            for (int i = 1; i <= 31; i++)
            {
                selDay.Items.Add(i.ToString());
            }
        }

        if (ddlOnDutyYear.Items.Count <= 0)
        {
            for (int i = DateTime.Now.Year; i < DateTime.Now.Year+3; i++)
            {
                ddlOnDutyYear.Items.Add(i.ToString());
            }
        }
        if (ddlOnDutyMonth.Items.Count <= 0)
        {
            for (int i = 1; i <= 12; i++)
            {
                ddlOnDutyMonth.Items.Add(i.ToString());
            }
        }
        if (ddlOnDutyDay.Items.Count <= 0)
        {
            for (int i = 1; i <= 31; i++)
            {
                ddlOnDutyDay.Items.Add(i.ToString());
            }
        }
       
        selYear.SelectedValue = "1980";
        ddlOnDutyYear.SelectedValue = DateTime.Now.AddMonths(1).Year.ToString();
        ddlOnDutyMonth.SelectedValue = DateTime.Now.AddMonths(1).Month.ToString();

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

    protected void ibtnSubmit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        if (sendEMail())
        {
            Response.Redirect("JobSend.aspx");
        }
    }

    private bool sendEMail()
    {
        String ScriptKey = "sendPassword Message";
        Boolean blnResult = false;
        string subject = ConfigurationManager.AppSettings["HireMail_Subject"];
        string mailto = ConfigurationManager.AppSettings["HireMail_MailTo"];
        string ccMailto = ConfigurationManager.AppSettings["HireMail_CCMailTo"];
        string mailServer = ConfigurationManager.AppSettings["SMTP Server"];
        string FileName = Server.MapPath("Template/JobTemplate.txt");
        StreamReader reader = new StreamReader(FileName, System.Text.Encoding.Default);
        string body = reader.ReadToEnd();
        reader.Close();

        int port;
        if (!Int32.TryParse(ConfigurationManager.AppSettings["SMTP Port"], out port))
        {
            port = 25;
        }

        string mailfrom = string.Format("{0}<{1}>", txtName.Text, txtEmail.Text);

        body = string.Format(body, txtJobTitle.Text, txtName.Text, rbtnGender.SelectedValue, txtTelArea.Text, txtTelphone.Text, txtMobile.Text, txtEmail.Text, selYear.SelectedValue + "" + selMonth.SelectedValue + "/" + selDay.SelectedValue, rbtnMarital.SelectedValue, txtExpectedSalary.Text, txtCurrentSalary.Text, ddlOnDutyYear.SelectedValue + "/" + ddlOnDutyMonth.SelectedValue + "/" + ddlOnDutyDay.SelectedValue, txtSchool.Text, txtStudy.Text, txtCareer.Text, txtIntro.Text,Request.ServerVariables["REMOTE_ADDR"],DateTime.Now.ToLongDateString() + " " +DateTime.Now.ToLongTimeString() );

        try
        {

            MailMessage message = new MailMessage(mailfrom, mailto, subject, body);
            if (ccMailto.Length > 0 || ccMailto != string.Empty)
            {
                string[] strCC = ccMailto.Split(new Char[] { ';', ',' });


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
            ResponseClientScript(ScriptKey, "alert(\"Format Exception: " + e.Message + "\");");

        }
        catch (SmtpException e)
        {
            ResponseClientScript(ScriptKey, "alert(\"SmtpException Exception: " + e.Message + "\");");
        }
        catch (Exception e)
        {
            ResponseClientScript(ScriptKey, "alert(\"Exception: " + e.Message + "\");");
        }

        return blnResult;
    }
}
