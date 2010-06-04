<%@ webHandler  Language="C#" Class="Thumbnail" %>

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

public class Thumbnail : IHttpHandler {
    private Regex _nameValidationExpression = new Regex(@"[^\w/]");
    private int _thumbnailSize = 350;

    public void ProcessRequest(HttpContext context) {

        string directorioBase = "";
        string servidor = context.Request.ServerVariables["SERVER_NAME"];
        switch (servidor)
        {
            case "webserver":   
                directorioBase = "/museomca/abserver";
                break;
                
            default:
                 directorioBase = "/";
                break;
                
        }     
        
        string url  = context.Request.QueryString["url"];
        
        string photoName = HttpContext.Current.Server.MapPath(directorioBase + url);

        if (context.Request.QueryString["maxDimention"]!=null)
        {
            int maxDimention = int.Parse(context.Request.QueryString["maxDimention"]);
            if (maxDimention >= 10)
                _thumbnailSize = maxDimention;
        }
      
        
        //context.Response.Write(photoName);
        //context.Response.End();
        
        
        //  quitamos esta comprobacion..
        //if (_nameValidationExpression.IsMatch(photoName)) {
        //    throw new HttpException(404, "Invalid photo name.");
        //}
		
        // context.Response.Write(Path.Combine(HttpRuntime.CodegenDir, photoName ));
        // context.Response.End();	

        // si url al principio tiene un / hay que quitarselo...
        if (url.Substring(0, 1) == "/")
            url = url.Substring(1, url.Length - 1);
        
        string cachePath = Path.Combine(HttpRuntime.CodegenDir, url);
       
        //context.Response.Write(HttpRuntime.CodegenDir + "<br>");
        //context.Response.Write(url + "<br>");
        //context.Response.Write(cachePath);
        //context.Response.End();	
        
        //if (File.Exists(cachePath)) {
        //    context.Response.Write(cachePath);
        //     context.Response.End();	
           
        //    OutputCacheResponse(context, File.GetLastWriteTime(cachePath));
        //    context.Response.WriteFile(cachePath);
        //    return;
        //}
      
        string photoPath = photoName; // context.Server.MapPath("~/Photo/" + photoName + ".jpg");
        Bitmap photo;
        try {
            photo = new Bitmap(photoPath);
        }
        catch (ArgumentException) {
            throw new HttpException(403, "Photo not found.");
        }
        //context.Response.ContentType = "image/png";
       
        
        
        int width, height;
        if (photo.Width > photo.Height) {
            width = _thumbnailSize;
            height = photo.Height * _thumbnailSize / photo.Width;
        }
        else {
            width = photo.Width * _thumbnailSize / photo.Height;
            height = _thumbnailSize;
        }
        Bitmap target = new Bitmap(width, height);
        using (Graphics graphics = Graphics.FromImage(target)) {
            graphics.CompositingQuality = CompositingQuality.HighSpeed;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.DrawImage(photo, 0, 0, width, height);

            // utilizar este otro si queremos gran calidad...
            //graphics.CompositingQuality = CompositingQuality.HighQuality;
             //graphics.SmoothingMode = SmoothingMode.AntiAlias;
             // graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
             //graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //graphics.DrawImage(photo, 0, 0, width, height);

            
            using (MemoryStream memoryStream = new MemoryStream()) {
                HttpContext.Current.Response.ContentType = "image/jpeg";
                target.Save(memoryStream, ImageFormat.Jpeg);
                memoryStream.WriteTo(context.Response.OutputStream);
            }
        }
    }

    private static void OutputCacheResponse(HttpContext context, DateTime lastModified) {
        HttpCachePolicy cachePolicy = context.Response.Cache;
        cachePolicy.SetCacheability(HttpCacheability.Public);
        cachePolicy.VaryByParams["url"] = true;
        cachePolicy.SetOmitVaryStar(true);
        cachePolicy.SetExpires(DateTime.Now + TimeSpan.FromDays(365));
        cachePolicy.SetValidUntilExpires(true);
        cachePolicy.SetLastModified(lastModified);
    }
 
    public bool IsReusable {
        get {
            return true;
        }
    }
}