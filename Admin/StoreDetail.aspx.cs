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

public partial class Admin_StoreDetail : System.Web.UI.Page
{
    private Store CurrentStore = null;
    private int _ID = 0;


    void GetCurrentStore()
    {

        if (Request.QueryString["ID"] != null && Int32.TryParse((string)Request.QueryString["ID"], out _ID))
        {
            CurrentStore = Store.GetStoreById(_ID);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        lbtnDelete.Attributes.Add("onclick", "return chkConfirmDelete()");
        GetCurrentStore();
        if (!Page.IsPostBack)
        {
            BindStore();
        }
    }
    void BindStore()
    {
        if (CurrentStore != null)
        {
            lblID.Text = Convert.ToString(CurrentStore.ID);

            if (CurrentStore.IsDisplay)
            {
                lblIsDisplay.Text = "<img src='/Admin/image/icon_okay.png'> 顯示";
            }
            else
            {
                lblIsDisplay.Text = "<img src='/Admin/image/icon_no.png'> 不顯示";
            }


            lblAreaName.Text = CurrentStore.AreaName;
            lblStoreName.Text = CurrentStore.StoreName;
            lblTel.Text = CurrentStore.Tel;
            lblAddress.Text = CurrentStore.Address;
        }
    }



    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("StoreModify.aspx?ID={0}&&back=StoreDetail.aspx", _ID));
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        Store.Remove(_ID);
        Response.Redirect("StoreList.aspx");
    }

    protected void lbtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("StoreList.aspx");
    }
}
