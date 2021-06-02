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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
public partial class Admin_Desktop : System.Web.UI.Page
{
    string _UploadPath = "/download/desktop/";
    string _BackupPath = ConfigurationManager.AppSettings["UploadBackupPath"] + "/download/desktop/{0}/";
    protected void Page_Load(object sender, EventArgs e)
    {

        Button1.Attributes.Add("onclick", "return chkConfirmUploadImage()");

        if (!Page.IsPostBack)
        {
            lblSuccess.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UploadFile(UploadControl1, _UploadPath, ddlImageID.SelectedIndex + 1);
    }


    void UploadFile(UploadControl UC, string UploadPath, int ImgID)
    {
        //First We Check if the page is valid or if we need to flag up an error message
        if (Page.IsValid)
        {
            //Second we need to check if the user has browsed for a file
            if (UC.GotFile)
            {

                //We can safely upload the file here because it has passed all validation.
                //Remeber to add the fullstop before the FileExt variable as it comes without.
                string FileName = string.Format("{0}_{1}.jpg", ImgID, rbtnImageSize.SelectedValue);
                string FullFileName = Server.MapPath(UploadPath + FileName);
                string BackupPath = Server.MapPath(string.Format(_BackupPath, DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")));
                if (File.Exists(FullFileName))
                {

                    if (!Directory.Exists(BackupPath)) { Directory.CreateDirectory(BackupPath); }

                    File.Move(FullFileName, BackupPath + FileName);
                }

                UC.FilePost.SaveAs(FullFileName);

                //Save Thumb Image
                if (chkThumb.Checked)
                {
                    string ThumbFileName = string.Format("{0}_Thumb.jpg", ImgID);
                    string FullThumbFileName = Server.MapPath(UploadPath + ThumbFileName);
                    if (File.Exists(FullThumbFileName))
                    {
                        File.Move(FullThumbFileName, BackupPath + ThumbFileName);
                    }

                    ResizeImageFile(FullFileName, FullThumbFileName);
                }


                lblSuccess.Visible = true;
            }
        }
        else
        {
            lblSuccess.Visible = false;
        }
    }


    private void ResizeImageFile(string imageFile, string ThumbFileName)
    {
        using (System.Drawing.Image oldImage = System.Drawing.Image.FromFile(imageFile))
        {
            Size newSize = new Size(199, 149);
            using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format24bppRgb))
            {
                using (Graphics canvas = Graphics.FromImage(newImage))
                {
                    canvas.SmoothingMode = SmoothingMode.AntiAlias;
                    canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSize));
                    newImage.Save(ThumbFileName, ImageFormat.Jpeg);

                }
            }
        }
    }

}
