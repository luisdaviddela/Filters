//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xamarin.Forms;
//using SkiaSharp;
//using System.IO;

//namespace Filters.Forms
//{
//    public class FilterViewCsharp:ContentPage
//    {
//        public FilterViewCsharp()
//        {
//            var info = new SKImageInfo(640, 480);
//            using (var surface = SKSurface.Create(info))
//            {
//                SKCanvas canvas = surface.Canvas;

//                canvas.Clear(SKColors.White);

//                // set up drawing tools


//                // decode the bitmap from the stream
//                Stream fileStream = File.OpenRead("mex.png"); // open a stream to an image file

//                // clear the canvas / fill with white
//                canvas.DrawColor(SKColors.White);

//                // decode the bitmap from the stream
//                using (var stream = new SKManagedStream(fileStream))
//                using (var bitmap = SKBitmap.Decode(stream))
//                using (var paint = new SKPaint())
//                {
//                    // create the image filter
//                    using (var filter = SKImageFilter.CreateBlur(5, 5))
//                    {
//                        paint.ImageFilter = filter;

//                        // draw the bitmap through the filter
//                        canvas.DrawBitmap(bitmap, SKRect.Create(50, 50), paint);
//                    }
//                }
//            }
//        }
//    }
//}
