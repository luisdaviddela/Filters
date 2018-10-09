using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CoreGraphics;
using CoreImage;
using Foundation;
using UIKit;

namespace Filters.Forms.iOS
{
    public class ImageiOS : IFilterImage
    {
        public byte[] Sepia(Stream imageStream)
        {
            byte[] ImageConv = new byte[0];
            var imageData = NSData.FromStream(imageStream);
            CIImage flower = CIImage.FromCGImage(UIImage.LoadFromData(imageData).CGImage);
            //var flower = UIImage.LoadFromData(imageData);
            var sepia = new CISepiaTone()
            {
                Image = flower,
                Intensity = .8f
            };
            CIImage output = sepia.OutputImage;
            var context = CIContext.FromOptions(null);
            var cgimage = context.CreateCGImage(output, output.Extent);

            //-------------------Return
            CGSize size = new CGSize(100, 100); //modify as necessary
            UIGraphics.BeginImageContext(size);
            CGRect rect = new CGRect(CGPoint.Empty, size);
            UIImage.FromImage(cgimage).Draw(rect);
            UIImage image = UIGraphics.GetImageFromCurrentImageContext();
            NSData jpegData = image.AsJPEG();
            UIGraphics.EndImageContext();


            byte[] dataBytes = new byte[jpegData.Length];
            System.Runtime.InteropServices.Marshal.Copy(jpegData.Bytes, dataBytes, 0, Convert.ToInt32(jpegData.Length));
            return dataBytes;
        }
    }
}