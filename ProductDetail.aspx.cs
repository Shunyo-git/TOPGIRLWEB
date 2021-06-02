using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using TopGirl.BusinessLogicLayer;
using TopGirl.DataAccessLayer;
using TopGirl.Web;
using System.Collections.Generic;
using System.Text;

public partial class ProductDetail : System.Web.UI.Page
{

    private Product CurrentProduct = null;
    private int _ProductID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetCurrentProduct();
         BindData();
    }
    void GetCurrentProduct()
    {

        if (Request.QueryString["ID"] != null)
        {
            string DecodeingID = WebUtility.FromBase64String((string)Request.QueryString["ID"]);

            if (Int32.TryParse(DecodeingID, out _ProductID))
            {
                CurrentProduct = Product.GetProductById(_ProductID);
            }
        }

        if (CurrentProduct == null)
        {
            CurrentProduct = Product.GetLastDisplayProduct();
            _ProductID = CurrentProduct.ID;
        }


    }
     void BindData()
    {
        imgProduct.Src = String.Format("/images/product/Main/{0}", CurrentProduct.FileName_Main);
        imgCategoryTitle.Src = string.Format("/images/category/Category_{0}.gif", CurrentProduct.CategoryID);
     }
    
}
