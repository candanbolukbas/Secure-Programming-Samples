using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;

namespace DirectoryTraversal
{
    public partial class Resize : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string untrustedPath = Request.QueryString["image"];
            if (!Regex.IsMatch(untrustedPath, @"^(\/images\/[a-zA-Z0-9]+.(jpg|png|gif|jpeg))$"))
            {
                Response.Write("<span style=\"color:red\">Directory traversal attempt!</span><br />" + untrustedPath + " is not a valid image path.");
                Response.End();
                return;
            }
            else
            {
                string fileName = Server.MapPath("") + Request.QueryString["image"];

                int width = int.Parse(Request.QueryString["w"]);
                int height = int.Parse(Request.QueryString["h"]);

                Response.Clear();
                Response.ContentType = "image/jpeg";

                try
                {
                    byte[] byteData = System.IO.File.ReadAllBytes(fileName);
                    Image image = ResizeImage(byteArrayToImage(byteData), width, height);
                    Response.BinaryWrite(imageToByteArray(image));
                }
                catch
                {
                    Image image = DrawText("    Image\nnot found!", new Font("Calibri", 24), Color.Red, Color.White);
                    Response.BinaryWrite(imageToByteArray(image));
                }
                finally
                {
                    Response.End();
                }
            }
        }

        public static Image ResizeImage(Image sourceImage, int maxWidth, int maxHeight)
        {
            // Determine which ratio is greater, the width or height, and use
            // this to calculate the new width and height. Effectually constrains
            // the proportions of the resized image to the proportions of the original.
            double xRatio = (double)sourceImage.Width / maxWidth;
            double yRatio = (double)sourceImage.Height / maxHeight;
            double ratioToResizeImage = Math.Max(xRatio, yRatio);
            int newWidth = (int)Math.Floor(sourceImage.Width / ratioToResizeImage);
            int newHeight = (int)Math.Floor(sourceImage.Height / ratioToResizeImage);

            // Create new image canvas -- use maxWidth and maxHeight in this function call if you wish
            // to set the exact dimensions of the output image.
            Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb);

            // Render the new image, using a graphic object
            using (Graphics newGraphic = Graphics.FromImage(newImage))
            {
                // Set the background color to be transparent (can change this to any color)
                newGraphic.Clear(Color.Transparent);

                // Set the method of scaling to use -- HighQualityBicubic is said to have the best quality
                newGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Apply the transformation onto the new graphic
                Rectangle sourceDimensions = new Rectangle(0, 0, sourceImage.Width, sourceImage.Height);
                Rectangle destinationDimensions = new Rectangle(0, 0, newWidth, newHeight);
                newGraphic.DrawImage(sourceImage, destinationDimensions, sourceDimensions, GraphicsUnit.Pixel);
            }

            // Image has been modified by all the references to it's related graphic above. Return changes.
            return newImage;
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private Image DrawText(String text, Font font, Color textColor, Color backColor)
        {
            //first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap((int)textSize.Width, (int)textSize.Height);

            drawing = Graphics.FromImage(img);

            //paint the background
            drawing.Clear(backColor);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text, font, textBrush, 0, 0);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;

        }
    }
}