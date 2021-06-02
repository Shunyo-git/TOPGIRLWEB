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

public partial class Admin_EventModify : System.Web.UI.Page
{
    private Event CurrentEvent = null;
    private int _ID = 0;
    private string _backto = "EventList.aspx";

    string _UploadPath = "/images/event/";
    string _BackupPath = ConfigurationManager.AppSettings["UploadBackupPath"] + "/images/Event/{0}/";

    void GetCurrentEvent()
    {

        if (Request.QueryString["ID"] != null && Int32.TryParse((string)Request.QueryString["ID"], out _ID))
        {
            CurrentEvent = Event.GetEventById(_ID);

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


        GetCurrentEvent();
        if (!Page.IsPostBack)
        {
            BindEventGroup();
            BindEvent();
        }

    }

    private void BindEvent()
    {
        if (CurrentEvent != null)
        {
            lblID.Text = Convert.ToString(CurrentEvent.ID);
            ddlEventGroup.SelectedValue = Convert.ToString(CurrentEvent.GroupID);
            rbtnIsDisplay.SelectedValue = CurrentEvent.IsDisplay.ToString();
            txtReleaseDate.Text = CurrentEvent.ReleaseDate;
            rbtnIsHomepageDisplay.SelectedIndex = CurrentEvent.HomePageAreaID;
          
            txtSubTitle.Text = CurrentEvent.SubTitle;
            txtTitle.Text = CurrentEvent.Title;
            txtContent.Text = CurrentEvent.Content;

            Calendar1.SelectedDate = Convert.ToDateTime(CurrentEvent.ReleaseDate);

            if (String.IsNullOrEmpty(CurrentEvent.FileName))
            {
                imgEvent.Visible = false;
              
            }
            else
            {
                imgEvent.ImageUrl = string.Format("/images/Event/{0}", CurrentEvent.FileName);
                linkEventImage.NavigateUrl = string.Format("/images/Event/{0}", CurrentEvent.FileName);
            }

        }
        else
        {
            txtReleaseDate.Text = DateTime.Now.ToShortDateString();
         

        }
    }

    private void BindEventGroup()
    {
        List<EventGroup> groupList = EventGroup.GetGroup();
        ddlEventGroup.DataSource = groupList;
        ddlEventGroup.DataBind();
    }

    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        bool blnResult;

        if (CurrentEvent == null)
        {
            CurrentEvent = new Event();
            CurrentEvent.FileName = string.Empty;
        }

        CurrentEvent.ID = _ID;
        CurrentEvent.GroupID = Convert.ToInt32(ddlEventGroup.SelectedValue);
        CurrentEvent.Title = txtTitle.Text;
        CurrentEvent.SubTitle = txtSubTitle.Text;
        CurrentEvent.Content = txtContent.Text;
        CurrentEvent.IsDisplay = Convert.ToBoolean(rbtnIsDisplay.SelectedValue);
        CurrentEvent.ReleaseDate = txtReleaseDate.Text;
        CurrentEvent.HomePageAreaID = rbtnIsHomepageDisplay.SelectedIndex;
        
        blnResult = CurrentEvent.Save();

        if (UploadFile(UploadControl1, _UploadPath, CurrentEvent.ID))
        {
            CurrentEvent.FileName = string.Format("{0}.jpg", CurrentEvent.ID);
            blnResult = CurrentEvent.Save();
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
                string FileName = string.Format("{0}.jpg", ImgID);
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
