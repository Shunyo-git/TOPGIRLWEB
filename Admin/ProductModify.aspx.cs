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
using System.IO;

public partial class Admin_ProductModify : System.Web.UI.Page
{
    private Product CurrentProduct = null;
    private int _ID = 0;
    private string _backto = "ProductList.aspx";

    string _UploadThumbPath = "/images/product/Thumb/";
    string _UploadMainPath = "/images/product/Main/";
    string _BackupPath = ConfigurationManager.AppSettings["UploadBackupPath"] + "/images/product/{0}/";

    void GetCurrentProduct()
    {

        if (Request.QueryString["ID"] != null && Int32.TryParse((string)Request.QueryString["ID"], out _ID))
        {
            CurrentProduct = Product.GetProductById(_ID);

        }
        if (Request.QueryString["back"] != null)
        {
            _backto = (string)Request.QueryString["back"];
            _backto += "?ID=";
            _backto += (string)Request.QueryString["ID"];
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        

        GetCurrentProduct();
        if (CurrentProduct == null)
        {
            UploadControl1.Required = true;
            UploadControl2.Required = true;
        }
        if (!Page.IsPostBack)
        {
            BindCategory();
            BindProduct();
        }

    }

    private void BindProduct()
    {
        if (CurrentProduct != null)
        {
            lblID.Text = Convert.ToString(CurrentProduct.ID);
          
            rbtnIsDisplay.SelectedValue = CurrentProduct.IsDisplay.ToString();

            ddlCategory.SelectedIndex = CurrentProduct.CategoryID;
            txtSKU.Text = CurrentProduct.SKU;

            imgThumb.ImageUrl = _UploadThumbPath + CurrentProduct.FileName_Thumb ;
            linkThumbImage.NavigateUrl = _UploadThumbPath + CurrentProduct.FileName_Thumb;

            imgMain.ImageUrl = _UploadMainPath + CurrentProduct.FileName_Main;
            linkMainImage.NavigateUrl = _UploadMainPath + CurrentProduct.FileName_Main;
        }
        else
        {

            imgThumb.Visible = false;
            imgMain.Visible = false;
          
        }
    }

    private void BindCategory()
    {
        List<Category> ctList = Category.GetCategory();
        ddlCategory.DataSource = ctList;
        ddlCategory.DataBind();
    }
    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        bool blnResult;
 

        if (Page.IsValid)
        {

            if (CurrentProduct == null)
            {
                CurrentProduct = new Product();
                CurrentProduct.FileName_Thumb = string.Empty;
                CurrentProduct.FileName_Main = string.Empty;
            }

            CurrentProduct.ID = _ID;
            CurrentProduct.SKU = txtSKU.Text;
            CurrentProduct.IsDisplay = Convert.ToBoolean(rbtnIsDisplay.SelectedValue);
            CurrentProduct.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);

            blnResult = CurrentProduct.Save();

            if (blnResult)
            {
                if (UploadFile(UploadControl1, _UploadThumbPath , CurrentProduct.ID))
                {
                    CurrentProduct.FileName_Thumb = StringHelper.GetFileName(string.Format(_UploadThumbPath + "Thumb_{0}.jpg", CurrentProduct.ID), new Char[] { '/' });
                    CurrentProduct.Save();
                }
                if (UploadFile(UploadControl2, _UploadMainPath  , CurrentProduct.ID))
                {
                    CurrentProduct.FileName_Main = StringHelper.GetFileName(string.Format(_UploadMainPath + "Main_{0}.jpg", CurrentProduct.ID), new Char[] { '/' });
                    CurrentProduct.Save();
                }
               
            }


            if (!blnResult)
            {
                ValidatorResult.Text = "儲存失敗，請檢查您的資料後重新再試一次。";
                ValidatorResult.IsValid = false;
                Response.Write("There was an error.  Please fix it and try it again.");
            }
            else
            {


              //  Response.Redirect(_backto);

            }
        }
    }

    private bool UploadFile(UploadControl UC, string UploadPath, int ImgID)
    {
        //First We Check if the page is valid or if we need to flag up an error message
        if (Page.IsValid)
        {
            //Second we need to check if the user has browsed for a file
            if (UC.GotFile)
            {
                //We can safely upload the file here because it has passed all validation.
                //Remeber to add the fullstop before the FileExt variable as it comes without.
                string FileNameTemplate = "{0}.jpg";
                if(UploadPath.IndexOf("Thumb")>0){
                    FileNameTemplate = "Thumb_{0}.jpg";
                }

                if (UploadPath.IndexOf("Main") > 0)
                {
                    FileNameTemplate = "Main_{0}.jpg";
                }
                string FileName = string.Format(FileNameTemplate, ImgID);
               
                string FullFileName = Server.MapPath(UploadPath + FileName);
                string BackupPath = Server.MapPath(string.Format(_BackupPath, DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")));
                if (File.Exists(FullFileName))
                {
                    if (!Directory.Exists(BackupPath)) { Directory.CreateDirectory(BackupPath); }
                    File.Move(FullFileName, BackupPath + FileName);
                }
               

                UC.FilePost.SaveAs(FullFileName );
               return true;
            }
        }
        
            return false;
        
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(_backto);
    }
}
