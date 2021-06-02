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
using System.Collections.Generic;

public partial class Admin_EventList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindEvent(SortAscending);
        }
    }
    protected void lbtnNew_Click(object sender, EventArgs e)
    {

        Server.Transfer("EventModify.aspx");
    }

    void BindEvent(string sortParameter)
    {
        List<Event> eList = Event.GetEvent(sortParameter);
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = eList;
        pds.AllowPaging = true;
        pds.PageSize = 15;

        int CurrentPage;
        if (Request.QueryString["Page"] != null)
            CurrentPage = Convert.ToInt32(Request.QueryString["Page"]);
        else
            CurrentPage = 1;

        pds.CurrentPageIndex = CurrentPage - 1;
        lblCurrentPage.Text = "第" + CurrentPage.ToString() + "頁";
        lblPageCount.Text = "共" + pds.PageCount.ToString() + "頁";
        if (!pds.IsFirstPage)
        {
            lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToInt32(CurrentPage - 1);
            lnkFirst.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=1";
        }
        if (!pds.IsLastPage)
        {
            lnkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToInt32(CurrentPage + 1);
            lnkLast.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + pds.PageCount;
        }

        for (int i = 1; i <= pds.PageCount; i++)
        {
            ddlPage.Items.Add(i.ToString());
        }
        ddlPage.SelectedIndex = pds.CurrentPageIndex;

        GridView1.DataSource = pds;
        GridView1.DataBind();
    }

    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int intDatalID = (int)GridView1.DataKeys[e.Row.RowIndex].Value;
            HyperLink linkView = (HyperLink)e.Row.FindControl("linkView");
            if (linkView != null)
            {
                linkView.Text = "檢視";
                linkView.NavigateUrl = string.Format("EventDetail.aspx?ID={0}", intDatalID);
            }

            HyperLink linkModify = (HyperLink)e.Row.FindControl("linkModify");
            if (linkModify != null)
            {
                linkModify.Text = "編輯";
                linkModify.NavigateUrl = string.Format("EventModify.aspx?ID={0}&back=EventList.aspx", intDatalID);

            }


            LinkButton lbtnDelete = (LinkButton)e.Row.FindControl("lbtnDelete");
            if (lbtnDelete != null)
            {
                lbtnDelete.Attributes.Add("onclick", "return chkConfirmDelete()");
            }

        }
    }

     

    protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
    {
       
        string sortParameter = e.SortExpression + " " + SortAscending;
        SortParameter = sortParameter;
        BindEvent(sortParameter);

        bool _reverse;
        _reverse = SortAscending.ToLowerInvariant().EndsWith(" desc");
        if (_reverse)
        {
            SortAscending = string.Empty;
        }
        else
        {
            SortAscending = " desc";
        }
       
    }

    public string SortParameter
    {
        get
        {
            object o = ViewState["SortParameter"];
            if (o == null)
                return string.Empty;
            return (string)(o);
        }
        set
        {
            ViewState["SortParameter"] = value;
        }
    }

    public string SortAscending
    {
        get
        {
            object o = ViewState["SortAscending"];
            if (o == null)
                return string.Empty;
            return (string)(o);
        }
        set
        {
            ViewState["SortAscending"] = value;
        }
    }

    public string IsWebDisplay(bool IsDisplay)
    {


        if (IsDisplay)
        {
            return "<img src='/Admin/image/icon_okay.png'>";
        } return string.Empty;
    }

    public string GetHomePageAreaName(int ID)
    {
        return Event.GetHomePageAreaName(ID);

        
    }

    public string GetEventGroupName(int ID)
    {
        return EventGroup.GetGroupName(ID);

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Delete":
                int RowID = Convert.ToInt32(e.CommandArgument);
                Event.Remove(RowID);
                
                break;

        }
   
    }
   
 
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BindEvent(SortParameter);
    }
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Request.CurrentExecutionFilePath + "?Page=" + ddlPage.SelectedValue);

    }
}
