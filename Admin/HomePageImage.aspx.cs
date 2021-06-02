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

public partial class Admin_HomePageImage : System.Web.UI.Page
{
    string _UploadPath = "/images/index/";
    string _BackupPath = ConfigurationManager.AppSettings["UploadBackupPath"] + "/images/Index/{0}/";
    protected void Page_Load(object sender, EventArgs e)
    {

        Button1.Attributes.Add("onclick", "return chkConfirmUploadImage()");
        Button2.Attributes.Add("onclick", "return chkConfirmUploadImage()");
        Button3.Attributes.Add("onclick", "return chkConfirmUploadImage()");

        if (!Page.IsPostBack)
        {
            lblSuccess.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UploadFile(UploadControl1, _UploadPath, 1);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        UploadFile(UploadControl2, _UploadPath, 2);
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        UploadFile(UploadControl3, _UploadPath, 3);
    }

    void UploadFile(UploadControl UC, string UploadPath, int ImgID)
    {
        //First We Check if the page is valid or if we need to flag up an error message
        if (Page.IsValid)
        {
            //Second we need to check if the user has browsed for a file
            if (UC.GotFile)
            {
                //We can safely upload the file here because it has passed all validation.
                //Remeber to add the fullstop before the FileExt variable as it comes without.
                string FileName = string.Format("{0}.jpg", ImgID);
                string FullFileName = Server.MapPath(UploadPath + FileName);
                string BackupPath = Server.MapPath(string.Format(_BackupPath, DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")));
                if (File.Exists(FullFileName))
                {
                    
                   if (!Directory.Exists(BackupPath)) { Directory.CreateDirectory(BackupPath); }

                   File.Move(FullFileName, BackupPath + FileName);
                }

                UC.FilePost.SaveAs(FullFileName);
                lblSuccess.Visible = true;
            }
        }
        else
        {
            lblSuccess.Visible = false;
        }
    }

    //void DisplayAlert(string Msg)
    //{
    //    ClientScriptManager cs = Page.ClientScript;
    //    Type cstype = this.GetType();
    //    String csname1 = "AlertScript";
    //    if (!cs.IsStartupScriptRegistered(cstype, csname1))
    //    {
    //        cs.RegisterStartupScript(cstype, csname1, Msg, true);
    //    }
    //}
}
