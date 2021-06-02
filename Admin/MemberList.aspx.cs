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
public partial class Admin_Member_memberList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindUser( );
        }
    }

    void BindUser( )
    {
        MembershipUserCollection UserList = Membership.GetAllUsers();
        if (!string.IsNullOrEmpty(Keyword))
        {
            
            if (ddlSearchType.SelectedIndex == 0)
            {
                  UserList = Membership.FindUsersByName(Keyword);
            }
            else {
                  UserList = Membership.FindUsersByEmail(Keyword);
            }
        }

      
 
        
        lblTotalCount.Text = UserList.Count.ToString();

        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = UserList;
        pds.AllowPaging = true;
        pds.PageSize = 15;

        int CurrentPage;
        if (Request.QueryString["Page"] != null)
            CurrentPage = Convert.ToInt32(Request.QueryString["Page"]);
        else
            CurrentPage = 1;

        pds.CurrentPageIndex = CurrentPage - 1;
        lblCurrentPage.Text = "第" + CurrentPage.ToString() + "頁";
        lblPageCount.Text ="共"+ pds.PageCount.ToString() + "頁";
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

        for (int i = 1; i <= pds.PageCount; i++) {
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
            string strDatalID = (string)GridView1.DataKeys[e.Row.RowIndex].Value;
            HyperLink linkView = (HyperLink)e.Row.FindControl("linkView");
            if (linkView != null)
            {
                linkView.Text = "檢視";
                linkView.NavigateUrl = string.Format("MemberDetail.aspx?user={0}", strDatalID);
            }
             

        }
    }
  
    
 

    public string IsAdmin(string UserName)
    {

       
        if (Roles.IsUserInRole(UserName,"Admin"))
        {
            return "<img src='/Admin/image/icon_okay.png'>";
        }
        else
        {
            return "<img src='/Admin/image/icon_no.png'>";
        }

        //return string.Empty;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtKeyword.Text))
        {

            Keyword = txtKeyword.Text;

        }
        else {
            Keyword = string.Empty;
        }
        BindUser( );
    }
    public string Keyword
    {
        get
        {
            object o = Session["Keyword"];
            if (o == null)
                return string.Empty;
            return (string)(o);
        }
        set
        {
            Session["Keyword"] = value;
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string UserName = Convert.ToString(e.CommandArgument);
        switch (e.CommandName)
        {
            case "RoleModify":

                if (Roles.IsUserInRole(UserName, "Admin"))
                {
                    Roles.RemoveUserFromRole(UserName, "Admin");
                }
                else {
                    Roles.AddUserToRole(UserName, "Admin");
                }

                break;
           
        }
        BindUser( );

    }

    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Request.CurrentExecutionFilePath + "?Page="+ ddlPage.SelectedValue);
       
    }
}
