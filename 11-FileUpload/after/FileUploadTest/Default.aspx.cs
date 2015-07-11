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
                bool IsImageStatus = IsImage();
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
                    lblStatus.Text += "<br />This is not an image file!";
                }
            }
        }

        public bool IsImage()
        {
            string[] validFileTypes = { "JPG", "JPEG", "PNG", "TIF", "TIFF", "GIF", "BMP", "ICO" };
            string ext = FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.') + 1).ToUpper();
            bool isValidFileExtention = false;
            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == validFileTypes[i])
                {
                    isValidFileExtention = true;
                    break;
                }
            }
            if (!isValidFileExtention)
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Invalid File. Please upload a File with extension " +
                               string.Join(",", validFileTypes);
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Valid extention, chechking the true file type...";
            }

            if (isValidFileExtention)
                isValidFileExtention = CheckTrueImageType();
            return isValidFileExtention;
        }

        public bool CheckTrueImageType()
        {
            // DICTIONARY OF ALL IMAGE FILE HEADER
            Dictionary<string, byte[][]> imageHeader = new Dictionary<string, byte[][]>();
            imageHeader.Add("JPG", new byte[][] { new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }, 
                                                  new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 }, 
                                                  new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 }, 
                                                  new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 }, 
                                                  new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 }, 
                                                  new byte[] { 0xFF, 0xD8, 0xFF, 0xDB } });
            imageHeader.Add("JPEG", new byte[][] { new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }, 
                                                   new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 }, 
                                                   new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 }, 
                                                   new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 }, 
                                                   new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 }, 
                                                   new byte[] { 0xFF, 0xD8, 0xFF, 0xDB }  });
            imageHeader.Add("PNG", new byte[][] { new byte[] { 0x89, 0x50, 0x4E, 0x47 } });
            imageHeader.Add("TIF", new byte[][] { new byte[] { 0x49, 0x49, 0x2A, 0x00 }, 
                                                  new byte[] { 0x49, 0x20, 0x49 }, 
                                                  new byte[] { 0x4D, 0x4D, 0x00, 0x2A }, 
                                                  new byte[] { 0x4D, 0x4D, 0x00, 0x2B } });
            imageHeader.Add("TIFF", new byte[][] { new byte[] { 0x49, 0x49, 0x2A, 0x00 }, 
                                                   new byte[] { 0x49, 0x20, 0x49 }, 
                                                   new byte[] { 0x4D, 0x4D, 0x00, 0x2A }, 
                                                   new byte[] { 0x4D, 0x4D, 0x00, 0x2B } });
            imageHeader.Add("GIF", new byte[][] { new byte[] { 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 }, 
                                                  new byte[] { 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 } });
            imageHeader.Add("BMP", new byte[][] { new byte[] { 0x42, 0x4D } });
            imageHeader.Add("ICO", new byte[][] { new byte[] { 0x00, 0x00, 0x01, 0x00 } });

            bool isTrueImage = false;
            if (FileUpload1.HasFile)
            {
                // GET FILE EXTENSION
                string fileExt = FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf('.') + 1).ToUpper();

                // CUSTOM VALIDATION GOES HERE BASED ON FILE EXTENSION IF ANY
                
                byte[][] tmp = imageHeader[fileExt];

                foreach (byte[] validHeader in tmp)
                {
                    byte[] header = new byte[validHeader.Length];

                    // GET HEADER INFORMATION OF UPLOADED FILE
                    FileUpload1.FileContent.Seek(0, System.IO.SeekOrigin.Begin);
                    FileUpload1.FileContent.Read(header, 0, header.Length);

                    if (CompareArray(validHeader, header))
                    {
                        // VALID HEADER INFORMATION 
                        isTrueImage = true;
                        break;
                    }
                }
            }

            if (!isTrueImage)
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text += "<br />Invalid file header! ";
            }

            return isTrueImage;
        }

        private bool CompareArray(byte[] a1, byte[] a2)
        {
            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i])
                    return false;
            }

            return true;
        }
    }
}