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
using System.Collections.Generic;
using System.Text;

public partial class ProductList : System.Web.UI.Page
{

    private Category CurrentCategory = null;
    private int _CategoryID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetCurrentCategory();
        BindData();
        imgCategoryTitle.Src = string.Format("/images/category/Category_{0}.gif",_CategoryID);
    }

    void GetCurrentCategory()
    {

        if (Request.QueryString["CategoryID"] != null)
        {
            string DecodeingID = WebUtility.FromBase64String((string)Request.QueryString["CategoryID"]);

            if (Int32.TryParse(DecodeingID, out _CategoryID))
            {
                CurrentCategory = Category.GetCategoryById(_CategoryID);
            }
        }

        if (CurrentCategory == null)
        {
            CurrentCategory = Category.GetFirstDisplayCategory();
            _CategoryID = CurrentCategory.ID;
        }
         
       
    }

    void BindData()
    {

        List<Product> records = Product.GetDisplayProductByCategoryID(_CategoryID);
        PagedDataSource pds = new PagedDataSource();

        pds.DataSource = records;
        pds.AllowPaging = true;
        pds.PageSize = 12;

        int CurrentPage;
        if (Request.QueryString["Page"] != null)
            CurrentPage = Convert.ToInt32(Request.QueryString["Page"]);
        else
            CurrentPage = 1;

        pds.CurrentPageIndex = CurrentPage - 1;
        lblCurrentPage.Text = CurrentPage.ToString();
        lblPageCount.Text = pds.PageCount.ToString();
        if (!pds.IsFirstPage)
        {
            lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?CategoryID=" + WebUtility.ToBase64String(_CategoryID.ToString()) + "&Page=" + Convert.ToInt32(CurrentPage - 1);
            lnkFirst.NavigateUrl = Request.CurrentExecutionFilePath + "?CategoryID=" + WebUtility.ToBase64String(_CategoryID.ToString()) + "&Page=1";
        }
        if (!pds.IsLastPage)
        {
            lnkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?CategoryID=" + WebUtility.ToBase64String(_CategoryID.ToString()) + "&Page=" + Convert.ToInt32(CurrentPage + 1);
            lnkLast.NavigateUrl = Request.CurrentExecutionFilePath + "?CategoryID=" + WebUtility.ToBase64String(_CategoryID.ToString()) + "&Page=" + pds.PageCount;
        }
        dListProduct.DataSource = pds;
        dListProduct.DataBind();



    }
     
}
