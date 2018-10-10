using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using Mono;
using CoreGraphics;
using CoreImage;
using Foundation;
using Filters.Forms.iOS;
using UIKit;
using Xamarin.Forms;
[assembly: Dependency(typeof(ImageiOS))]
namespace Filters.Forms.iOS
{
    public class ImageiOS : IFilterImage
    {
        //public byte[] Sepia(Stream imageStream)
        //{
        //    byte[] ImageConv = new byte[0];
        //    var imageData = NSData.FromStream(imageStream);
        //    CIImage flower = CIImage.FromCGImage(UIImage.LoadFromData(imageData).CGImage);
        //    //var flower = UIImage.LoadFromData(imageData);
        //    var sepia = new CISepiaTone()
        //    {
        //        Image = flower,
        //        Intensity = .8f
        //    };
        //    CIImage output = sepia.OutputImage;
        //    var context = CIContext.FromOptions(null);
        //    var cgimage = context.CreateCGImage(output, output.Extent);

        //    //-------------------Return
        //    CGSize size = new CGSize(100, 100); //modify as necessary
        //    UIGraphics.BeginImageContext(size);
        //    CGRect rect = new CGRect(CGPoint.Empty, size);
        //    UIImage.FromImage(cgimage).Draw(rect);
        //    UIImage image = UIGraphics.GetImageFromCurrentImageContext();
        //    NSData jpegData = image.AsJPEG();
        //    UIGraphics.EndImageContext();


        //    byte[] dataBytes = new byte[jpegData.Length];
        //    System.Runtime.InteropServices.Marshal.Copy(jpegData.Bytes, dataBytes, 0, Convert.ToInt32(jpegData.Length));
        //    return dataBytes;
        //}

        public byte[] Sepia(byte[] imageIos)
        {
            byte[] ImageConv = new byte[0];
            var imageData = NSData.FromArray(imageIos);
            CIImage ImageOriginal = CIImage.FromCGImage(UIImage.LoadFromData(imageData).CGImage);
            var sepia = new CISepiaTone()
            {
                Image = ImageOriginal,
                Intensity = 1.0f
            };
            //---------Added
            CIContext ctx = CIContext.FromOptions(null);
            var output = sepia.OutputImage;
            var cgImage = ctx.CreateCGImage(output, output.Extent);
            //---------
            CGSize size = new CGSize(400, 400); //modify as necessary
            UIGraphics.BeginImageContext(size);
            CGRect rect = new CGRect(CGPoint.Empty, size);
            //UIImage.FromImage(flower).Draw(rect);
            UIImage.FromImage(cgImage).Draw(rect);

            UIImage image = UIGraphics.GetImageFromCurrentImageContext();
            //NSData jpegData = image.AsJPEG(1);
            NSData jpegData = image.AsPNG();
            UIGraphics.EndImageContext();

            byte[] bt = jpegData.ToArray();

            return bt;
        }
        void monovoid()
        {

            byte[] ImageConv = new byte[0];
            var imageData = NSData.FromArray(ImageConv);
            CIImage flower = CIImage.FromCGImage(UIImage.LoadFromData(imageData).CGImage);
            var sepia = new CISepiaTone()
            {
                Image = flower,
                Intensity = 0.9f
            };
            CIContext ctx = CIContext.FromOptions(null);
            var output = sepia.OutputImage;
            var cgImage = ctx.CreateCGImage(output, output.Extent);

            CGSize size = new CGSize(400, 400); //modify as necessary
            UIGraphics.BeginImageContext(size);
            CGRect rect = new CGRect(CGPoint.Empty, size);
            UIImage.FromImage(cgImage).Draw(rect);

            UIImage image = UIGraphics.GetImageFromCurrentImageContext();
            //NSData jpegData = image.AsJPEG(1);
            NSData jpegData = image.AsPNG();
            UIGraphics.EndImageContext();

            byte[] bt = jpegData.ToArray();

            
        }
    }
}