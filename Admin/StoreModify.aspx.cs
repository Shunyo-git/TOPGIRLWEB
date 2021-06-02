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

public partial class Admin_StoreModify : System.Web.UI.Page
{
    private Store CurrentStore = null;
    private int _ID = 0;
    private string _backto = "StoreList.aspx";
 
    void GetCurrentStore()
    {

        if (Request.QueryString["ID"] != null && Int32.TryParse((string)Request.QueryString["ID"], out _ID))
        {
            CurrentStore = Store.GetStoreById(_ID);

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


        GetCurrentStore();
         
        if (!Page.IsPostBack)
        {
            BindStore();
        }

    }
   
    private void BindStore()
    {
        if (CurrentStore != null)
        {
            lblID.Text = Convert.ToString(CurrentStore.ID);

           
            rbtnIsDisplay.SelectedValue = CurrentStore.IsDisplay.ToString();
            ddlArea.SelectedValue = CurrentStore.AreaID.ToString();
            
            txtStoreName.Text = CurrentStore.StoreName;
            txtTel.Text = CurrentStore.Tel;
            txtAddress.Text = CurrentStore.Address;
           
        }
        
    }
 

    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        bool blnResult;
  

            if (CurrentStore == null)
            {
                CurrentStore = new Store();
                 
            }

            CurrentStore.ID = _ID;
            CurrentStore.StoreName = txtStoreName.Text;
            CurrentStore.IsDisplay = Convert.ToBoolean(rbtnIsDisplay.SelectedValue);
            CurrentStore.AreaID = Convert.ToInt32(ddlArea.SelectedValue);

            
             CurrentStore.Tel = txtTel.Text;
             CurrentStore.Address = txtAddress.Text;

            blnResult = CurrentStore.Save();
 

            if (!blnResult)
            {
                ValidatorResult.Text = "儲存失敗，請檢查您的資料後重新再試一次。";
                ValidatorResult.IsValid = false;
                Response.Write("There was an error.  Please fix it and try it again.");
            }
            else
            {


                Response.Redirect(_backto);

            }
        
    }

    

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(_backto);
    }
}
