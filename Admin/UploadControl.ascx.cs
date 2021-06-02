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

public partial class UploadControl : System.Web.UI.UserControl
{
    //Has the user browsed for a file?
    private bool pGotFile;
    //The file extension of the Posted File
    private string pFileExt;
    //The File itself
    private HttpPostedFile pFilePost;
    //Is the user required to upload an image?
    private bool pRequired;
    //The validation group that the Custom Validator belongs to on the page
    private string pVgroup;
    //Extensions you allow to be uploaded
    private string[] pFileTypeRange;
    private string pFileType = string.Empty;
    //Boolean indicator to check if file extension is allowed
    private bool Ind = false;
    //The Image Minimum Width
    private int minWidth = 0;
    //The Image Maximum Width
    private int maxWidth = 0;
    //The Image Minimum Height
    private int minHeight = 0;
    //The Image Maximum Height
    private int maxHeight = 0;
    private string icon_validate_tick = "icon_validate_tick.gif";
    private string icon_validate_spacer = "icon_validate_spacer.gif";
    private string icon_validate_cross = "icon_validate_cross.gif";

    private Unit fileControlWidth = Unit.Parse("50%");
    /*
     * 
 
     * Get and Sets for the above private variables.
     * */
    public bool GotFile
    {
        get { return pGotFile; }
    }
    public string FileExt
    {
        get { return pFileExt; }
    }
    public HttpPostedFile FilePost
    {
        get { return pFilePost; }
    }
    public bool Required
    {
        get { return pRequired; }
        set { pRequired = value; }
    }
    public string ValidationGroup
    {
        set { pVgroup = value; }
    }
    public string FileTypeRange
    {
        set { pFileTypeRange = value.ToString().Split(','); pFileType = value; }
    }
    public int MinWidth
    {
        set { minWidth = value; }
    }
    public int MaxWidth
    {
        set { maxWidth = value; }
    }
    public int MinHeight
    {
        set { minHeight = value; }
    }
    public int MaxHeight
    {
        set { maxHeight = value; }
    }

    public string Icon_Validate_Tick
    {
        set { icon_validate_tick = value; }
    }
    public string Icon_Validate_Cross
    {
        set { icon_validate_cross = value; }
    }
    public string Icon_Validate_Spacer
    {
        set { icon_validate_spacer = value; }
    }
    public Unit FileControlWidth
    {
        set { fileControlWidth = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //here we assign the validation group to the Custom Validator, which I have inefficiently named ErrorMsg
        ErrorMsg.ValidationGroup = pVgroup;
        ErrorMsg.Text = string.Format("<IMG  src=\"{0}\" align=\"absmiddle\" />", icon_validate_cross);
        FilUpl.CssClass = string.Empty;
        FilUpl.Width = fileControlWidth;
    }

    protected void ErrorMsg_ServerValidate(object source, ServerValidateEventArgs args)
    {

        if (FilUpl.HasFile)
        {
            pGotFile = true;
            pFileExt = GetExtension(FilUpl.PostedFile.FileName);
            pFilePost = FilUpl.PostedFile;


            foreach (string str in pFileTypeRange)
            {
                if (str.ToLower() == pFileExt.ToLower())
                {
                    Ind = true;
                }
            }

            if (!Ind)
            {
                args.IsValid = false;
                ErrorMsg.ErrorMessage = "�W�Ǫ��ɮ׮榡���䴩�A���\���榡�� " + pFileType + "�C";
                FilUpl.CssClass = "input-warn-content";
                //Stop the function
                return;
            }

            bool chkMinWidth = (minWidth > 0);
            bool chkMaxWidth = (maxWidth > 0);
            bool chkMinHeight = (minHeight > 0);
            bool chkMaxHeight = (maxHeight > 0);

            if (chkMinWidth || chkMaxWidth || chkMinHeight || chkMaxHeight)
            {
                bool blnIsValid = true;
                string strErrMsg = "�W�Ǫ��Ϥ��ؤo���šC";

                System.Drawing.Image CheckSize = System.Drawing.Image.FromStream(FilUpl.PostedFile.InputStream);

                //�̤p�e��
                if (blnIsValid && chkMinWidth && CheckSize.PhysicalDimension.Width < minWidth)
                {
                    blnIsValid = false;
                    if (minWidth != maxWidth) { strErrMsg += "�̤p�e��(Width)��" + minWidth.ToString() + "����(px)�C"; }
                    else { strErrMsg += "�e��(Width)�ݬ�" + minWidth.ToString() + "����(px)�C"; }
                }
                //�̤j�e��
                if (blnIsValid && chkMaxWidth && CheckSize.PhysicalDimension.Width > maxWidth)
                {
                    blnIsValid = false;
                    if (minWidth != maxWidth) { strErrMsg += "�̤j�e��(Width)��" + maxWidth.ToString() + "����(px)�C"; }

                }
                //�̤p����
                if (blnIsValid && chkMinHeight && CheckSize.PhysicalDimension.Height < minHeight)
                {
                    blnIsValid = false;
                    if (minHeight != maxHeight) { strErrMsg += "�̤p����(Height)��" + minHeight.ToString() + "����(px)�C"; }
                    else { strErrMsg += "����(Height)�ݬ�" + minHeight.ToString() + "����(px)�C"; }
                }
                //�̤j����
                if (blnIsValid && chkMaxHeight && CheckSize.PhysicalDimension.Height > maxHeight)
                {
                    blnIsValid = false;
                    if (minHeight != maxHeight) { strErrMsg += "�̤j����(Height)��" + maxHeight.ToString() + "����(px)�C"; }

                }

                if (!blnIsValid)
                {
                    args.IsValid = false;
                    ErrorMsg.ErrorMessage = strErrMsg;
                    FilUpl.CssClass = "input-warn-content";
                    return;
                }
            }
            //if (minWidth > 0)
            //{
            //    //If you get here then you have set the MinWidth because you are expecting an image,
            //    //and due to validation once at this stage in the code, we know that the user has uploaded
            //    //some sort of image type
            //    System.Drawing.Image CheckSize = System.Drawing.Image.FromStream(FilUpl.PostedFile.InputStream);
            //    if (CheckSize.PhysicalDimension.Width < minWidth)
            //    {
            //        args.IsValid = false;
            //        ErrorMsg.ErrorMessage = "�W�Ǫ��Ϥ��ؤo���šA�̤p�e�ץ����j�� " + minWidth.ToString() + "����(px)�C";

            //        FilUpl.CssClass = "input-warn-content";
            //        //Stop the function
            //        return;
            //    } 

            //}
            //if (maxWidth > 0)
            //{
            //    //If you get here then you have set the MaxWidth because you are expecting an image,
            //    //and due to validation once at this stage in the code, we know that the user has uploaded
            //    //some sort of image type
            //    System.Drawing.Image CheckSize = System.Drawing.Image.FromStream(FilUpl.PostedFile.InputStream);
            //    if (CheckSize.PhysicalDimension.Width > maxWidth)
            //    {
            //        args.IsValid = false;
            //        ErrorMsg.ErrorMessage = "�W�Ǫ��Ϥ��ؤo���šA�̤j�e�ץ����p��  " + maxWidth.ToString() + "����(px)�C";

            //        FilUpl.CssClass = "input-warn-content";
            //        //Stop the function
            //        return;
            //    }
            //}
            //if (minHeight > 0)
            //{
            //    //If you get here then you have set the MinWidth because you are expecting an image,
            //    //and due to validation once at this stage in the code, we know that the user has uploaded
            //    //some sort of image type
            //    System.Drawing.Image CheckSize = System.Drawing.Image.FromStream(FilUpl.PostedFile.InputStream);
            //    if (CheckSize.PhysicalDimension.Height < minHeight)
            //    {
            //        args.IsValid = false;
            //        ErrorMsg.ErrorMessage = "�W�Ǫ��Ϥ��ؤo���šA�Ϥ��̤p����(Height)�����j�� " + minHeight.ToString() + "����(px)�C";

            //        FilUpl.CssClass = "input-warn-content";
            //        //Stop the function
            //        return;
            //    }
            //}
            //if (maxHeight > 0)
            //{
            //    //If you get here then you have set the MaxWidth because you are expecting an image,
            //    //and due to validation once at this stage in the code, we know that the user has uploaded
            //    //some sort of image type
            //    System.Drawing.Image CheckSize = System.Drawing.Image.FromStream(FilUpl.PostedFile.InputStream);
            //    if (CheckSize.PhysicalDimension.Height > maxHeight)
            //    {
            //        args.IsValid = false;
            //        ErrorMsg.ErrorMessage = "�W�Ǫ��Ϥ��ؤo���šA�Ϥ��̤j����(Height)�����p��  " + maxHeight.ToString() + "����(px)�C";

            //        FilUpl.CssClass = "input-warn-content";
            //        //Stop the function
            //        return;
            //    }
            //}
        }
        else
        {
            //So if we get here the user has not browsed for a file
            pGotFile = false;
            //If you have stated that the user has to browse for a file.
            //then we must stop now and inform the user of such.
            if (pRequired)
            {
                args.IsValid = false;
                ErrorMsg.ErrorMessage = "�z�|����ܭn�W�Ǫ��ɮסC";

                FilUpl.CssClass = "input-warn-content";
            }
        }
    }
    /// <summary>
    /// This returns the file extension.  It does not contain the preceding full stop
    /// so it would return jpg and NOT .jpg . Please adjust your coding accordingly.
    /// </summary>
    /// <param name="FileName">string</param>
    /// <returns>string: the file extension e.g. jpg</returns>
    private string GetExtension(string FileName)
    {
        string[] split = FileName.Split('.');
        string Extension = split[split.Length - 1];
        return Extension;
    }
}
