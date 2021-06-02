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
 
public partial class Admin_EventDetail : System.Web.UI.Page
{
    private Event CurrentEvent = null;
    private int _ID = 0;


    void GetCurrentEvent()
    {

        if (Request.QueryString["ID"] != null && Int32.TryParse((string)Request.QueryString["ID"], out _ID))
        {
            CurrentEvent = Event.GetEventById(_ID);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        lbtnDelete.Attributes.Add("onclick", "return chkConfirmDelete()");
        GetCurrentEvent();
        if (!Page.IsPostBack)
        {
            BindEvent();
        }
    }
    void BindEvent()
    {
        if (CurrentEvent != null)
        {
            lblID.Text = Convert.ToString(CurrentEvent.ID);
            lblGroupName.Text = EventGroup.GetGroupName(CurrentEvent.GroupID);
            if (CurrentEvent.IsDisplay)
            {
                lblIsDisplay.Text = "<img src='/Admin/image/icon_okay.png'> 顯示";
            }
            else
            {
                lblIsDisplay.Text = "<img src='/Admin/image/icon_no.png'> 不顯示";
            }

            string HopageAreaDisplay = "<img src='/Admin/image/icon_no.png'> 不顯示";
            switch (CurrentEvent.HomePageAreaID){
              
                case 1:
                    HopageAreaDisplay = "<img src='/Admin/image/icon_okay.png'> 本季活動快訊";
                    break;
                case 2:
                    HopageAreaDisplay = "<img src='/Admin/image/icon_okay.png'> 最新消息 ";
                    break;
            }
            lblHopageAreaDisplay.Text = HopageAreaDisplay;
           

            lblSubTitle.Text = CurrentEvent.SubTitle;
            lblTitle.Text = CurrentEvent.Title;
            lblReleaseDate.Text = CurrentEvent.ReleaseDate;
            lblContent.Text = CurrentEvent.Content.Replace("\n", "<BR>");

            if (String.IsNullOrEmpty(CurrentEvent.FileName))
            {
                imgEvent.Visible = false;

            }
            else
            {
                imgEvent.ImageUrl = string.Format("/images/Event/{0}", CurrentEvent.FileName);
                linkEventImage.NavigateUrl = string.Format("/images/Event/{0}", CurrentEvent.FileName);
            }

         //   lblCreationDate.Text = CurrentEvent.CreationDate.ToLongDateString() + "　" + CurrentEvent.CreationDate.ToLongTimeString();

        }
    }



    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("EventModify.aspx?ID={0}&&back=EventDetail.aspx", _ID));
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        Event.Remove(_ID);
        Response.Redirect("EventList.aspx");
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EventList.aspx");
    }
}
