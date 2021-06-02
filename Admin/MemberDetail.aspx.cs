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

public partial class Admin_Member_MemberDetail : System.Web.UI.Page
{
    private string _UserName = string.Empty;
    private MembershipUser CurrentUser = null;
    private MemberInfo UserInfo = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetCurrentUser();

        if (!Page.IsPostBack)
        {
            BindUser();
        }
    }

    void GetCurrentUser()
    {

        if (Request.QueryString["user"] != null)
        {
            _UserName = Request.QueryString["user"];
            CurrentUser = Membership.GetUser(_UserName);
            UserInfo = Profile.GetProfile(_UserName).MemberInfo;
        }
        else
        {
            Response.Redirect("MemberList.aspx", true);
        }
    }

    void BindUser()
    {
        if (CurrentUser != null)
        {
            lblUserName.Text = CurrentUser.UserName;
            lblEmail.Text = CurrentUser.Email;

            lblUserType.Text = Roles.IsUserInRole(CurrentUser.UserName, "Admin") ? "管理員" : "一般會員";

            lblCreationDate.Text = CurrentUser.CreationDate.ToLongDateString() + "　" + CurrentUser.CreationDate.ToLongTimeString();
            lblLastActivityDate.Text = CurrentUser.LastActivityDate.ToLongDateString() + "　" + CurrentUser.LastActivityDate.ToLongTimeString();
            lblLastLoginDate.Text = CurrentUser.LastLoginDate.ToLongDateString() + "　" + CurrentUser.LastLoginDate.ToLongTimeString();
            lblLastPasswordChangedDate.Text = CurrentUser.LastPasswordChangedDate.ToLongDateString() + "　" + CurrentUser.LastPasswordChangedDate.ToLongTimeString();
            if (CurrentUser.IsApproved)
            {
                lblIsApproved.Text = "<img src='/Admin/image/icon_okay.png'> 啟用";
            }
            else
            {
                lblIsApproved.Text = "<img src='/Admin/image/icon_no.png'> 停用";
            }

            if (UserInfo != null)
            {
                //ProfileCommon p = Profile.GetProfile(_UserName);

                lblChineseName.Text = UserInfo.ChineseName;

                switch (UserInfo.Gender)
                {
                    case MemberInfo.GenderType.unknown:
                        lblGender.Text = "未設定";
                        break;
                    case MemberInfo.GenderType.male:
                        lblGender.Text = "男";
                        break;
                    case MemberInfo.GenderType.female:
                        lblGender.Text = "女";
                        break;
                }
                lblBirthday.Text = UserInfo.Birthday.ToLongDateString();
                lblAddr.Text =   UserInfo.Address;
                lblMobilePhone.Text = UserInfo.MobilePhone;
                lblTelPhone.Text = UserInfo.Telphone;
                lblCareer.Text = UserInfo.Career;
                lblMarital.Text = UserInfo.Marital;
               // lblLastUpdateDate.Text = p.LastUpdatedDate.ToLongDateString() + "　" + p.LastUpdatedDate.ToLongTimeString();
                if (UserInfo.IsSubscription)
                {
                    lblIsSubscription.Text = "<img src='/Admin/image/icon_okay.png'> 訂閱";
                }
                else
                {
                    lblIsSubscription.Text = "<img src='/Admin/image/icon_no.png'> 不訂閱";
                }

                if (UserInfo.IsMemberCard)
                {
                    lblIsMemberCard.Text = "<img src='/Admin/image/icon_okay.png'> 是";
                }
                else
                {
                    lblIsMemberCard.Text = "<img src='/Admin/image/icon_no.png'> 否";
                }
            }




        }
    }
}
