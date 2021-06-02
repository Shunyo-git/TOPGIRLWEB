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
using TopGirl.Web;
using System.Collections.Generic;
using System.IO;

public partial class Admin_MiniSiteModify : System.Web.UI.Page
{
    private MiniSite CurrentMiniSite = null;
    private int _ID = 0;
    private string _backto = "MiniSiteList.aspx";

    string _UploadPath = "/images/MiniSite/";
    string _BackupPath = ConfigurationManager.AppSettings["UploadBackupPath"] + "/images/MiniSite/{0}/";

    void GetCurrentMiniSite()
    {

        if (Request.QueryString["ID"] != null && Int32.TryParse((string)Request.QueryString["ID"], out _ID))
        {
            CurrentMiniSite = MiniSite.GetMiniSiteById(_ID);

        }
        if (Request.QueryString["back"] != null)
        {
            _backto = (string)Request.QueryString["back"];
            _backto += "?ID=";
            _backto += (string)Request.QueryString["ID"];
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {


        GetCurrentMiniSite();
        if (CurrentMiniSite == null)
        {
            UploadControl1.Required = true;
        }
        if (!Page.IsPostBack)
        {
            BindData();
        }

    }

    private void BindData()
    {
        if (CurrentMiniSite != null)
        {
            lblID.Text = Convert.ToString(CurrentMiniSite.ID);
          
            rbtnIsDisplay.SelectedValue = CurrentMiniSite.IsDisplay.ToString();

           
            txtURL.Text = CurrentMiniSite.URL;

            imgSite.ImageUrl = string.Format("/images/MiniSite/MiniSite_{0}.jpg", CurrentMiniSite.ID);
            linkSiteImage.NavigateUrl = string.Format("/images/MiniSite/MiniSite_{0}.jpg", CurrentMiniSite.ID);
           
        }
        else
        {

            imgSite.Visible = false;

          
        }
    }
 

    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        bool blnResult;
 

        if (Page.IsValid)
        {

            if (CurrentMiniSite == null)
            {
                CurrentMiniSite = new MiniSite();
                CurrentMiniSite.SortID = MiniSite.GetMiniSite().Count;
            }

            CurrentMiniSite.ID = _ID;
            CurrentMiniSite.URL = txtURL.Text;
            CurrentMiniSite.IsDisplay = Convert.ToBoolean(rbtnIsDisplay.SelectedValue);
      

            blnResult = CurrentMiniSite.Save();

            if (blnResult)
            {
                UploadFile(UploadControl1, _UploadPath, CurrentMiniSite.ID);
            }


            if (!blnResult)
            {
                ValidatorResult.Text = "儲存失敗，請檢查您的資料後重新再試一次。";
                ValidatorResult.IsValid = false;
                Response.Write("There was an error.  Please fix it and try it again.");
            }
            else
            {


                Response.Redirect(_backto);

            }
        }
    }

    private bool UploadFile(UploadControl UC, string UploadPath, int ImgID)
    {
        //First We Check if the page is valid or if we need to flag up an error message
        if (Page.IsValid)
        {
            //Second we need to check if the user has browsed for a file
            if (UC.GotFile)
            {
                //We can safely upload the file here because it has passed all validation.
                //Remeber to add the fullstop before the FileExt variable as it comes without.
                string FileName = string.Format("minisite_{0}.gif", ImgID);
                string FullFileName = Server.MapPath(UploadPath + FileName);
                string BackupPath = Server.MapPath(string.Format(_BackupPath, DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")));
                if (File.Exists(FullFileName))
                {
                    if (!Directory.Exists(BackupPath)) { Directory.CreateDirectory(BackupPath); }
                    File.Move(FullFileName, BackupPath + FileName);
                }

                UC.FilePost.SaveAs(FullFileName);
               return true;
            }
        }
        
            return false;
        
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(_backto);
    }
}
