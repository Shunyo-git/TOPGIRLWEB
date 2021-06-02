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
using System.IO;

public partial class Download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DisplayScreenLink();

    }

    private void DisplayScreenLink()
    {
        bool isImgExists;
        bool isExeExists;
        for (int i = 1; i <= 8; i++)
        {

            isImgExists = File.Exists(Server.MapPath(string.Format("/download/screen/sc_{0}.jpg", i)));
            isExeExists = File.Exists(Server.MapPath(string.Format("/download/screen/sc_{0}.exe", i)));


            ContentPlaceHolder con = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
            if (con != null)
            {
                Image img = (Image)con.FindControl(string.Format("imgScreen{0}", i));

                if (img != null)
                {
                    img.Visible = isImgExists;
                }

                Label link = (Label)con.FindControl(string.Format("lblScnLink{0}", i));
                if (link != null)
                {
                    link.Visible = isExeExists;
                }
            }
        }
    }
    protected void LbtnDesktop_Click(object sender, EventArgs e)
    {
        PanelDesktop.Visible = true;
        PanelScreen.Visible = false;
    }
    protected void LbtnScreen_Click(object sender, EventArgs e)
    {
        PanelDesktop.Visible = false;
        PanelScreen.Visible = true;
    }
}
