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
using System.Collections.Generic;
using TopGirl.BusinessLogicLayer;
using TopGirl.DataAccessLayer;
using TopGirl.Web;
using System.Text;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack && Session["IntroDisplay"] == null)
        {
            Session["IntroDisplay"] = true;
            Server.Transfer("index.html");
        }
        BindHomeArea();
        BindCategory();
        BindMiniSite();
    }

    void BindCategory()
    {
        DataListCategory.DataSource = Category.GetHomePageDisplayCategory();
        DataListCategory.DataBind();
    }

    void BindHomeArea()
    {

        DataListArea1.DataSource = Event.GetDisplayEventByHomePageAreaID(1);
        DataListArea1.DataBind();

        DataListArea2.DataSource = Event.GetDisplayEventByHomePageAreaID(2);
        DataListArea2.DataBind();
    }

    void BindMiniSite()
    {
        MiniSiteList.DataSource = MiniSite.GetDisplayMiniSite();
        MiniSiteList.DataBind();
    }
    void ResponseClientScript(string ScriptKey, string Msg)
    {
        ClientScriptManager cs = Page.ClientScript;
        Type cstype = this.GetType();

        if (!cs.IsStartupScriptRegistered(cstype, ScriptKey))
        {
            cs.RegisterStartupScript(cstype, ScriptKey, Msg, true);
        }
    }
    public string EncodingRecordID(int RecordID)
    {

        return Convert.ToBase64String(Encoding.Unicode.GetBytes(RecordID.ToString()));
    }
}
