using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using TopGirl.BusinessLogicLayer;
using TopGirl.DataAccessLayer;
using TopGirl.Web;

public partial class StoreDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindArea();
    }
    void BindArea()
    {

        DataListArea_1.DataSource = Store.GetDisplayStoreByArea(1);
        DataListArea_1.DataBind();

        DataListArea_2.DataSource = Store.GetDisplayStoreByArea(2);
        DataListArea_2.DataBind();

        DataListArea_3.DataSource = Store.GetDisplayStoreByArea(3);
        DataListArea_3.DataBind();
 
    }
}
