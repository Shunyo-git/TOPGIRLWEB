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

public partial class MemberRegister : System.Web.UI.Page
{
    System.Web.UI.WebControls.DropDownList selYear;
    System.Web.UI.WebControls.DropDownList selMonth;
    System.Web.UI.WebControls.DropDownList selDay;
    OboutInc.Calendar2.Calendar calDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadTemplateControls();
        if (!Page.IsPostBack)
        {
            BindDate();
            BindDatePickerID();
            AddBirthdayAttributes();
        }
    }

    private void LoadTemplateControls()
    {
        selYear = (System.Web.UI.WebControls.DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("selYear");
        selMonth = (System.Web.UI.WebControls.DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("selMonth");
        selDay = (System.Web.UI.WebControls.DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("selDay");
        calDate = (OboutInc.Calendar2.Calendar)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("calDate");
    }


    void BindDate()
    {
        if (selYear != null)
        {
            if (selYear.Items.Count <= 0)
            {
                for (int i = 1900; i < DateTime.Now.Year ; i++)
                {
                    selYear.Items.Add(i.ToString());
                }
            }
        }


        if (selMonth != null)
        {
            if (selMonth.Items.Count <= 0)
            {
                for (int i = 1; i <= 12; i++)
                {
                    selMonth.Items.Add(i.ToString());
                }
            }
        }


        if (selDay != null)
        {
            if (selDay.Items.Count <= 0)
            {
                for (int i = 1; i <= 31; i++)
                {
                    selDay.Items.Add(i.ToString());
                }
            }

        }


    }

    private void AddBirthdayAttributes()
    {

        if (selYear != null)
        {
            selYear.Attributes.Add("onChange", "selectDate()");
        }
        if (selMonth != null)
        {
            selMonth.Attributes.Add("onChange", "selectDate()");
        }
        if (selDay != null)
        {
            selDay.Attributes.Add("onChange", "selectDate()");
        }
    }


    void BindDatePickerID()
    {

        String ScriptKey = "DatePickerScript";
        string Msg = string.Empty;
        Msg += "selMonthID = \"" + selMonth.ClientID + "\";";
        Msg += "selDayID = \"" + selDay.ClientID + "\";";
        Msg += "selYearID = \"" + selYear.ClientID + "\";";
        Msg += "calDateID = \"" + calDate.ClientID + "\";";

        ResponseClientScript(ScriptKey, Msg);
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
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {

        if (SaveProfile())
        {
            Response.Redirect("MemberRegisterSuccess.aspx");
        }
        else {
            string UserName = GetTextBoxControlValue("UserName");
            Membership.DeleteUser(UserName);
            CreateUserWizard1.ActiveStepIndex = 1;
        }
    }

    private bool SaveProfile()
    {

       
        string ChineseName = string.Empty;
        MemberInfo.GenderType Gender = MemberInfo.GenderType.unknown;
        DateTime Birthday = DateTime.MinValue;
        string Telphone = string.Empty;
        string MobilePhone = string.Empty;
        string Address = string.Empty;
        string Career = string.Empty;
        string Marital = string.Empty;
        bool IsSubscription = false;
        bool IsMemberCard = false;
         
        ChineseName = GetTextBoxControlValue("txtChineseName");
        RadioButtonList rbtnGender = (RadioButtonList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("rbtnGender");
        if (rbtnGender.SelectedValue == "male")
        {
            Gender = MemberInfo.GenderType.male;
        }
        if (rbtnGender.SelectedValue == "female")
        {
            Gender = MemberInfo.GenderType.female;
        }

        if (selYear == null || selMonth == null || selDay==null) { LoadTemplateControls(); }
        if (!DateTime.TryParse(selYear.SelectedValue + "/" + selMonth.SelectedValue + "/" + selDay.SelectedValue, out Birthday))
        {
            Birthday = DateTime.MinValue;
        }

        Telphone = GetTextBoxControlValue("txtTelphone");
        MobilePhone = GetTextBoxControlValue("txtMobilePhone");
        Address = GetTextBoxControlValue("txtAddress");
        Career = GetTextBoxControlValue("txtCareer");
        Marital = GetTextBoxControlValue("txtMarital");

        Marital = GetTextBoxControlValue("txtMarital");

        IsSubscription =  Convert.ToBoolean(GetRadioButtonListControlValue("rbtnIsSubscription"));
        IsMemberCard = Convert.ToBoolean(GetRadioButtonListControlValue("rbtnIsMemberCard"));

        string UserName =  GetTextBoxControlValue("UserName");

        if(!string.IsNullOrEmpty(UserName)){
            ProfileCommon p = Profile.GetProfile(UserName);

            if(p!=null){
                p.MemberInfo = new MemberInfo(ChineseName, Gender, Birthday, Telphone, MobilePhone, Address, Career, Marital, IsSubscription, IsMemberCard);
                p.Save();
                return true;
            }
           
        }
        return false;
        
    }

    private string GetTextBoxControlValue(string ControlID)
    {
        TextBox obj = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl(ControlID);
        if (obj != null) { return obj.Text; } else { return string.Empty; }
    }

    private string GetRadioButtonListControlValue(string ControlID)
    {
        RadioButtonList obj = (RadioButtonList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl(ControlID);
        if (obj != null) { return obj.SelectedValue; } else { return string.Empty; }
    }

}
