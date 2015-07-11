using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUploadTest
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
            {
                string SourceImage = "";
                bool IsImageStatus = IsImage(FileUpload1.PostedFile);
                if (IsImageStatus == true)
                {
                    SourceImage = Server.MapPath("~") + FileUpload1.PostedFile.FileName;

                    try
                    {
                        FileUpload1.PostedFile.SaveAs(SourceImage);
                        lblStatus.Text = "Success!";
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = "Failure! " + ex.Message;
                    }
                }
                else
                {
                    lblStatus.Text = "This is not an image file!";
                }
            }
        }

        public static bool IsImage(HttpPostedFile myFile)
        {
            if (myFile.ContentType == "image/jpg" |
                myFile.ContentType == "image/gif" |
                myFile.ContentType == "image/bmp" |
                myFile.ContentType == "image/x-png" |
                myFile.ContentType == "image/jpeg" |
                myFile.ContentType == "image/png")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}