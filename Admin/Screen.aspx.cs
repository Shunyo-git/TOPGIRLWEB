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
public partial class Admin_Screen : System.Web.UI.Page
{
    string _UploadPath = "/download/screen/";
    string _BackupPath = ConfigurationManager.AppSettings["UploadBackupPath"] + "/download/screen/{0}/";
    protected void Page_Load(object sender, EventArgs e)
    {

        BindAttributes();

        if (!Page.IsPostBack)
        {
            lblSuccess.Visible = false;
        }
    }

    private void BindAttributes()
    {
        Button1.Attributes.Add("onclick", "return chkConfirmUploadImage()");
        lbtnDelete01.Attributes.Add("onclick", "return chkConfirmDelete()");
        lbtnDelete02.Attributes.Add("onclick", "return chkConfirmDelete()");
        lbtnDelete03.Attributes.Add("onclick", "return chkConfirmDelete()");
        lbtnDelete04.Attributes.Add("onclick", "return chkConfirmDelete()");
        lbtnDelete05.Attributes.Add("onclick", "return chkConfirmDelete()");
        lbtnDelete06.Attributes.Add("onclick", "return chkConfirmDelete()");
        lbtnDelete07.Attributes.Add("onclick", "return chkConfirmDelete()");
        lbtnDelete08.Attributes.Add("onclick", "return chkConfirmDelete()");
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
                string FileName = string.Empty;

                if (rbtnUploadType.SelectedIndex == 0)
                {
                    FileName = string.Format("sc_{0}.jpg", ImgID);
                    MoveBackupItem(ItemType.ThumbImage, ImgID);
                }

                if (rbtnUploadType.SelectedIndex == 1)
                {
                    FileName = string.Format("sc_{0}.exe", ImgID);
                    MoveBackupItem(ItemType.ScreenApp, ImgID);
                }

                //We can safely upload the file here because it has passed all validation.
                //Remeber to add the fullstop before the FileExt variable as it comes without.

                string FullFileName = Server.MapPath(UploadPath + FileName);
                //string BackupPath = Server.MapPath(string.Format(_BackupPath, DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")));
                //if (File.Exists(FullFileName))
                //{

                //    if (!Directory.Exists(BackupPath)) { Directory.CreateDirectory(BackupPath); }

                //    File.Move(FullFileName, BackupPath + FileName);
                //}



                if (rbtnUploadType.SelectedIndex == 0)
                {
                    string TempFileName = FullFileName.Replace(".jpg", "_temp.jpg");
                    UC.FilePost.SaveAs(TempFileName);
                    ResizeImageFile(TempFileName, FullFileName);
                    File.Delete(TempFileName);
                }
                else
                {
                    UC.FilePost.SaveAs(FullFileName);
                }





                lblSuccess.Visible = true;
            }
        }
        else
        {
            lblSuccess.Visible = false;
        }
    }

    enum ItemType { ThumbImage, ScreenApp };
    private void MoveBackupItem(ItemType itype, int ImgID)
    {
        string FileName = string.Empty;

        switch (itype)
        {
            case ItemType.ThumbImage:
                FileName = string.Format("sc_{0}.jpg", ImgID);
                break;
            case ItemType.ScreenApp:
                FileName = string.Format("sc_{0}.exe", ImgID);
                break;
        }

        string FullFileName = Server.MapPath(_UploadPath + FileName);
        string BackupPath = Server.MapPath(string.Format(_BackupPath, DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")));
        if (File.Exists(FullFileName))
        {
            if (!Directory.Exists(BackupPath)) { Directory.CreateDirectory(BackupPath); }
            File.Move(FullFileName, BackupPath + FileName);
        }
    }

    private void ResizeImageFile(string imageFile, string TargetFile)
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
                    newImage.Save(TargetFile, ImageFormat.Jpeg);
                }
            }
        }
    }

    protected void lbtnDelete01_Click(object sender, EventArgs e)
    {
        MoveBackupItem(ItemType.ThumbImage, 1);
        MoveBackupItem(ItemType.ScreenApp, 1);
    }
    protected void lbtnDelete02_Click(object sender, EventArgs e)
    {
        MoveBackupItem(ItemType.ThumbImage, 2);
        MoveBackupItem(ItemType.ScreenApp, 2);
    }
    protected void lbtnDelete03_Click(object sender, EventArgs e)
    {
        MoveBackupItem(ItemType.ThumbImage, 3);
        MoveBackupItem(ItemType.ScreenApp, 3);
    }
    protected void lbtnDelete04_Click(object sender, EventArgs e)
    {
        MoveBackupItem(ItemType.ThumbImage, 4);
        MoveBackupItem(ItemType.ScreenApp, 4);
    }
    protected void lbtnDelete05_Click(object sender, EventArgs e)
    {
        MoveBackupItem(ItemType.ThumbImage, 5);
        MoveBackupItem(ItemType.ScreenApp, 5);
    }
    protected void lbtnDelete06_Click(object sender, EventArgs e)
    {
        MoveBackupItem(ItemType.ThumbImage, 6);
        MoveBackupItem(ItemType.ScreenApp, 6);
    }
    protected void lbtnDelete07_Click(object sender, EventArgs e)
    {
        MoveBackupItem(ItemType.ThumbImage, 7);
        MoveBackupItem(ItemType.ScreenApp, 7);
    }
    protected void lbtnDelete08_Click(object sender, EventArgs e)
    {
        MoveBackupItem(ItemType.ThumbImage, 8);
        MoveBackupItem(ItemType.ScreenApp, 8);
    }
}
