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
using TopGirl.Web;
public partial class PromotionDetail : System.Web.UI.Page
{

    private int _GroupID = 0;
    private int _EventID = 0;
    private Event CurrentEvent = null;
    private void GetCurrentEvent()
    {

        if (Request.QueryString["EventID"] != null)
        {
            string DecodeingID = WebUtility.FromBase64String((string)Request.QueryString["EventID"]);

            if (Int32.TryParse(DecodeingID, out _EventID))
            {
                CurrentEvent = Event.GetEventById(_EventID);
            }
        }
        else if (Request.QueryString["TypeID"] != null && Int32.TryParse((string)Request.QueryString["TypeID"], out _GroupID))
        {
            CurrentEvent = Event.GetDisplayEventByGroupID(_GroupID)[0];
        }

        if (CurrentEvent == null)
        {
            CurrentEvent = Event.GetLastDisplayEvent();
        }

        _GroupID = CurrentEvent.GroupID;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        GetCurrentEvent();
        BindEvent();

    }

    private void BindEvent()
    {
        lblSubTitle.Text = CurrentEvent.SubTitle;
     
        	lblReleaseDate.Text = StringHelper.FormatDateTimeString(CurrentEvent.ReleaseDate,"yyyy/MM/dd")  ;
       
        lblContent.Text = WebUtility.CrToBr(WebUtility.ReplaceSpaces(CurrentEvent.Content, "&nbsp;&nbsp;", false));

        if (String.IsNullOrEmpty(CurrentEvent.FileName))
        {
            imgEvent.Visible = false;
            TableEventImage.Visible = false;
        }
        else
        {
            imgEvent.ImageUrl = string.Format("/images/Event/{0}", CurrentEvent.FileName);
            linkEventImage.NavigateUrl = string.Format("/images/Event/{0}", CurrentEvent.FileName);
        }
    }

}
