using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

 
    public class redimensionarImagen
    {
        public static MemoryStream Redimensiona(Stream imagen, int targetW, int targetH, int resolucion)
        {
            System.Drawing.Image original = System.Drawing.Image.FromStream(imagen);
            System.Drawing.Image imgPhoto = System.Drawing.Image.FromStream(imagen);

            int alto= imgPhoto.Height;
            int ancho = imgPhoto.Width;

            if (alto > targetH)
            {

                ancho = sf.entero((ancho * targetH) / alto);
                alto = targetH;
            }

            // No vamos a permitir que la imagen final sea más grande que la inicial
            //targetH = targetH <= original.Height ? targetH : original.Height;
            //targetW = targetW <= original.Width ? targetW : original.Width;

            targetH = alto;
            targetW = ancho;
            Bitmap bmPhoto = new Bitmap(targetW, targetH, PixelFormat.Format24bppRgb);

            // No vamos a permitir dar una resolución mayor de la que tiene
            resolucion = resolucion <= Convert.ToInt32(bmPhoto.HorizontalResolution) ? resolucion : Convert.ToInt32(bmPhoto.HorizontalResolution);
            resolucion = resolucion <= Convert.ToInt32(bmPhoto.VerticalResolution) ? resolucion : Convert.ToInt32(bmPhoto.VerticalResolution);

            bmPhoto.SetResolution(resolucion, resolucion);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);

            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;
            grPhoto.DrawImage(imgPhoto, new Rectangle(0, 0, targetW, targetH), new Rectangle(0, 0, original.Width, original.Height), GraphicsUnit.Pixel);

            MemoryStream mm = new MemoryStream();
            bmPhoto.Save(mm, System.Drawing.Imaging.ImageFormat.Jpeg);

            original.Dispose();
            imgPhoto.Dispose();
            bmPhoto.Dispose();
            grPhoto.Dispose();

            return mm;
        }
    }
 