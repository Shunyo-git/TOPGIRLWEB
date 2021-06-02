using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using TopGirl.BusinessLogicLayer;
using TopGirl.DataAccessLayer;
using TopGirl.Web;
 
public partial class Template_inc_Category_Left : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindCategory();
    }
    void BindCategory()
    {

        DataListCategory.DataSource = Category.GetDisplayCategory();
        DataListCategory.DataBind();

        
    }
    
}
