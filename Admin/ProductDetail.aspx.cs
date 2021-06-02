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
 
public partial class Admin_ProductDetail : System.Web.UI.Page
{
    private Product CurrentProduct = null;
    private int _ID = 0;
    string _UploadThumbPath = "/images/product/Thumb/";
    string _UploadMainPath = "/images/product/Main/";

    void GetCurrentProduct()
    {

        if (Request.QueryString["ID"] != null && Int32.TryParse((string)Request.QueryString["ID"], out _ID))
        {
            CurrentProduct = Product.GetProductById(_ID);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        lbtnDelete.Attributes.Add("onclick", "return chkConfirmDelete()");
        GetCurrentProduct();
        if (!Page.IsPostBack)
        {
            BindProduct();
        }
    }
    void BindProduct()
    {
        if (CurrentProduct != null)
        {
            lblID.Text = Convert.ToString(CurrentProduct.ID);
            lblCategory.Text = Category.GetCategoryById(CurrentProduct.CategoryID).Name;
            if (CurrentProduct.IsDisplay)
            {
                lblIsDisplay.Text = "<img src='/Admin/image/icon_okay.png'> 顯示";
            }
            else
            {
                lblIsDisplay.Text = "<img src='/Admin/image/icon_no.png'> 不顯示";
            }

           
           

            lblSKU.Text = CurrentProduct.SKU;
       

            if (String.IsNullOrEmpty(CurrentProduct.FileName_Thumb))
            {
                imgThumb.Visible = false;

            }
            else
            {
                imgThumb.ImageUrl = string.Format(_UploadThumbPath + "{0}", CurrentProduct.FileName_Thumb);
                linkThumbImage.NavigateUrl = string.Format(_UploadThumbPath + "{0}", CurrentProduct.FileName_Thumb);
            }

            if (String.IsNullOrEmpty(CurrentProduct.FileName_Main))
            {
                imgMain.Visible = false;

            }
            else
            {
                imgMain.ImageUrl = string.Format(_UploadMainPath + "{0}", CurrentProduct.FileName_Main);
                linkMainImage.NavigateUrl = string.Format(_UploadMainPath + "{0}", CurrentProduct.FileName_Main);
            }

        }
    }



    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("ProductModify.aspx?ID={0}&&back=ProductDetail.aspx", _ID));
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        Product.Remove(_ID);
        Response.Redirect("ProductList.aspx");
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductList.aspx");
    }
}
