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
using System.Collections.Generic;
using TopGirl.BusinessLogicLayer;
using TopGirl.DataAccessLayer;
using TopGirl.Web;

public partial class Promotion : System.Web.UI.Page
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
        
        if (CurrentEvent==null)
        {
        CurrentEvent = Event.GetLastDisplayEvent();
        }
        
        _GroupID = CurrentEvent.GroupID;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        GetCurrentEvent();
        //BindEvent();
        BindList();
        BindTypeImage();

        lblFrame.Text = string.Format("<iframe   name=\"showDetail\" src=\"PromotionDetail.aspx?EventID={0}\" width=\"565\" height=\"370\" frameborder=\"0\" scrolling=\"yes\" ></iframe>", WebUtility.ToBase64String(CurrentEvent.ID.ToString()));
    }

    //private void BindEvent()
    //{
    //    lblSubTitle.Text = CurrentEvent.SubTitle;
    //    lblReleaseDate.Text = CurrentEvent.ReleaseDate;
    //    lblContent.Text = WebUtility.CrToBr(WebUtility.ReplaceSpaces(CurrentEvent.Content, "&nbsp;&nbsp;", false));

    //    if (String.IsNullOrEmpty(CurrentEvent.FileName))
    //    {
    //        imgEvent.Visible = false;
    //        TableEventImage.Visible = false;
    //    }
    //    else {
    //        imgEvent.ImageUrl = string.Format("/images/Event/{0}", CurrentEvent.FileName);
    //    }
    //}


    private void BindList()
    {

        GridView1.DataSource = Event.GetDisplayEventByGroupID(_GroupID);
        GridView1.DataBind();

       
    }
    private void BindTypeImage()
    {
        string imgUrl = string.Empty; 
   
        if (_GroupID > 0)
        {
            imgUrl = string.Format("img/promotion/type{0}_bt_1.gif", _GroupID);
            imgSubType.Src = string.Format("img/promotion/sub_type{0}.gif", _GroupID);  

        }
        else {
            imgUrl = string.Format("/img/promotion/type{0}_bt.gif", _GroupID);
        }

       

        switch (_GroupID) {
            case 1:
                imgType1.Src = imgUrl;
                
                break;
            case 2:
                imgType2.Src = imgUrl;
                break;
            case 3:
                imgType3.Src = imgUrl;
                break;
            case 4:
                imgType4.Src = imgUrl;
                break;
            case 5:
                imgType5.Src = imgUrl;
                break;
        }
      
       
    }
}
