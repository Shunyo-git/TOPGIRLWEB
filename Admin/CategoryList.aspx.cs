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
public partial class Admin_CategoryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindCategory(SortAscending);
        }
    }
    protected void lbtnNew_Click(object sender, EventArgs e)
    {

        Server.Transfer("CategoryModify.aspx");
    }

    void BindCategory(string sortParameter)
    {
       
        GridView1.DataSource = Category.GetCategory(sortParameter);
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
                linkView.NavigateUrl = string.Format("CategoryDetail.aspx?ID={0}", intDatalID);
            }

            HyperLink linkModify = (HyperLink)e.Row.FindControl("linkModify");
            if (linkModify != null)
            {
                linkModify.Text = "編輯";
                linkModify.NavigateUrl = string.Format("CategoryModify.aspx?ID={0}&back=CategoryList.aspx", intDatalID);

            }

            LinkButton lbtnDelete = (LinkButton)e.Row.FindControl("lbtnDelete");
            if (lbtnDelete != null)
            {
                lbtnDelete.Attributes.Add("onclick", "return chkConfirmDelete()");
            }
        }
    }

    protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView1.PageIndex = e.NewPageIndex;
        BindCategory(SortParameter);
    }

    protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
    {

        string sortParameter = e.SortExpression + " " + SortAscending;
        SortParameter = sortParameter;
        BindCategory(sortParameter);

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



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int RowID = 0;
        List<Category> categoryList;
        switch(e.CommandName){
            case "Delete":
                RowID = Convert.ToInt32(e.CommandArgument);
                Category.Remove(RowID);
                break;
            case "SortUp":
               RowID = Convert.ToInt32(e.CommandArgument);
                 categoryList = Category.GetCategory();
                foreach (Category c in categoryList) { 
                    if(c.ID == RowID){
                        int nowIndex = categoryList.IndexOf(c);
                        if (nowIndex>0) {
                            int NowSortID = c.SortID;
                            int UpdateSortID = categoryList[nowIndex - 1].SortID;

                            c.SortID = UpdateSortID;
                            c.Save();

                            categoryList[nowIndex - 1].SortID = NowSortID;
                            categoryList[nowIndex - 1].Save();
                        }
                    }
                }

                BindCategory(SortParameter);
                break;
            case "SortDown":
              RowID = Convert.ToInt32(e.CommandArgument);
                 categoryList = Category.GetCategory();
                foreach (Category c in categoryList)
                {
                    if (c.ID == RowID)
                    {
                        int nowIndex = categoryList.IndexOf(c);
                        if (nowIndex < categoryList.Count)
                        {
                            int NowSortID = c.SortID;
                            int UpdateSortID = categoryList[nowIndex + 1].SortID;

                            c.SortID = UpdateSortID;
                            c.Save();

                            categoryList[nowIndex + 1].SortID = NowSortID;
                            categoryList[nowIndex + 1].Save();
                        }
                    }
                }
                BindCategory(SortParameter);
                break;
        }
         
    }
    
   
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BindCategory(SortParameter);
    }
}
