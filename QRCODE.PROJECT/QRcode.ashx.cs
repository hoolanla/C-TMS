using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Text;

namespace QRCODE.PROJECT
{
    /// <summary>
    /// Summary description for QRcode
    /// </summary>
    public class QRcode : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            //string myText = context.Request.QueryString.Get("code");
            //context.Response.ContentType = "image/gif";
            //if (myText.Length > 0)
            //{
            //    MessagingToolkit.QRCode.Codec.QRCodeEncoder qe = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
            //    System.Drawing.Bitmap bm = qe.Encode(myText);
            //   // bm.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);
            //    bm.Save("C://QR.jpg", System.Drawing.Imaging.ImageFormat.Gif);
            //    context.Response.Write("Done.");
                
            //}   
            string values;

            using (var reader = new StreamReader(context.Request.InputStream,Encoding.GetEncoding("utf-8")))
            {
                // This will equal to "charset = UTF-8 & param1 = val1 & param2 = val2 & param3 = val3 & param4 = val4"
                 values = reader.ReadToEnd();
            }


            if (values.Length > 0)
            {
                MessagingToolkit.QRCode.Codec.QRCodeEncoder qe = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
                System.Drawing.Bitmap bm = qe.Encode(values);
                // bm.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);
                bm.Save("C://QR.jpg", System.Drawing.Imaging.ImageFormat.Gif);
                context.Response.Write("Done.");

            }   

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}