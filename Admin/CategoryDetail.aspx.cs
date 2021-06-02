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

public partial class Admin_CategoryDetail : System.Web.UI.Page
{
    private Category CurrentCategory = null;
    private int _ID = 0;


    void GetCurrentCategory()
    {

        if (Request.QueryString["ID"] != null && Int32.TryParse((string)Request.QueryString["ID"], out _ID))
        {
            CurrentCategory = Category.GetCategoryById(_ID);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        lbtnDelete.Attributes.Add("onclick", "return chkConfirmDelete()");
        GetCurrentCategory();
        if (!Page.IsPostBack)
        {
            BindCategory();
        }
    }
    void BindCategory()
    {
        if (CurrentCategory != null)
        {
            lblID.Text = Convert.ToString(CurrentCategory.ID);

            if (CurrentCategory.IsDisplay)
            {
                lblIsDisplay.Text = "<img src='/Admin/image/icon_okay.png'> 顯示";
            }
            else
            {
                lblIsDisplay.Text = "<img src='/Admin/image/icon_no.png'> 不顯示";
            }

            if (CurrentCategory.IsHomePageDisplay)
            {
                lblIsHomePageDisplay.Text = "<img src='/Admin/image/icon_okay.png'> 顯示";
            }
            else
            {
                lblIsHomePageDisplay.Text = "<img src='/Admin/image/icon_no.png'> 不顯示";
            }

            lblName.Text = CurrentCategory.Name;

            imgCategory.ImageUrl = string.Format("/images/category/Category_{0}.gif", CurrentCategory.ID);
            linkCategoryImage.NavigateUrl = string.Format("/images/category/Category_{0}.gif", CurrentCategory.ID);

        }
    }



    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("CategoryModify.aspx?ID={0}&&back=CategoryDetail.aspx", _ID));
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        Category.Remove(_ID);
        Response.Redirect("CategoryList.aspx");
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CategoryList.aspx");
    }
}
