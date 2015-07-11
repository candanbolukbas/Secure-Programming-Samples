//Extra name space
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System;

namespace CaptchaByPass
{
    public class RandomImage
    {
        //Default Constructor 
        public RandomImage() { }
        //property
        public string Text
        {
            get { return this.text; }
        }
        public Bitmap Image
        {
            get { return this.image; }
        }
        public int Width
        {
            get { return this.width; }
        }
        public int Height
        {
            get { return this.height; }
        }
        //Private variable
        private string text;
        private int width;
        private int height;
        private Bitmap image;
        private Random random = new Random();
        //Methods declaration
        public RandomImage(string s, int width, int height)
        {
            this.text = s;
            this.SetDimensions(width, height);
            this.GenerateImage();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                this.image.Dispose();
        }
        private void SetDimensions(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        private void GenerateImage()
        {
            Bitmap bitmap = new Bitmap
              (this.width, this.height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, this.width, this.height);
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti,
                Color.LightGray, Color.White);
            g.FillRectangle(hatchBrush, rect);
            SizeF size;
            float fontSize = rect.Height + 1;
            Font font;

            do
            {
                fontSize--;
                font = new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold);
                size = g.MeasureString(this.text, font);
            } while (size.Width > rect.Width);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            GraphicsPath path = new GraphicsPath();
            //path.AddString(this.text, font.FontFamily, (int) font.Style, 
            //    font.Size, rect, format);
            path.AddString(this.text, font.FontFamily, (int)font.Style, 75, rect, format);
            float v = 4F;
            PointF[] points =
          {
                new PointF(this.random.Next(rect.Width) / v, this.random.Next(
                   rect.Height) / v),
                new PointF(rect.Width - this.random.Next(rect.Width) / v, 
                    this.random.Next(rect.Height) / v),
                new PointF(this.random.Next(rect.Width) / v, 
                    rect.Height - this.random.Next(rect.Height) / v),
                new PointF(rect.Width - this.random.Next(rect.Width) / v,
                    rect.Height - this.random.Next(rect.Height) / v)
          };
            Matrix matrix = new Matrix();
            matrix.Translate(0F, 0F);
            path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);
            hatchBrush = new HatchBrush(HatchStyle.Percent10, Color.Black, Color.FromArgb(this.random.Next(255), this.random.Next(255), this.random.Next(255)));
            g.FillPath(hatchBrush, path);
            int m = Math.Max(rect.Width, rect.Height);
            for (int i = 0; i < (int)(rect.Width * rect.Height / 30F); i++)
            {
                int x = this.random.Next(rect.Width);
                int y = this.random.Next(rect.Height);
                int w = this.random.Next(m / 50);
                int h = this.random.Next(m / 50);
                g.FillEllipse(hatchBrush, x, y, w, h);
            }
            font.Dispose();
            hatchBrush.Dispose();
            g.Dispose();
            this.image = bitmap;
        }
    }
}