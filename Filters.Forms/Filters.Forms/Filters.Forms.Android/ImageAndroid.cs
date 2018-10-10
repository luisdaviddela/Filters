using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Android;
using Xamarin.Forms;
using Filters.Forms.Droid;
using Filters.Forms;
using System.IO;
using Android.Graphics;
using Java.Nio;

[assembly: Dependency(typeof(ImageAndroid))]
namespace Filters.Forms.Droid
{
    public class ImageAndroid : IFilterImage
    {
        public byte[] Sepia(Stream image)
        {
            byte[] s = null;
            

            
            return s;
        }
        public Bitmap ImageFilter(Bitmap bmpOriginal)
        {
            byte[] bitmapdata = null;
            Bitmap bitmap = BitmapFactory.DecodeByteArray(bitmapdata, 0, bitmapdata.Length);

            int width, height, r, g, b, c, gry;
            height = bmpOriginal.Height;
            width = bmpOriginal.Width;
            int depth = 20;
            Bitmap bmpSephia = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
            Canvas canvas = new Canvas(bmpSephia);
            Paint paint = new Paint();
            ColorMatrix cm = new ColorMatrix();
            cm.SetScale(.3f, .3f, .3f, 1.0f);
            ColorMatrixColorFilter f = new ColorMatrixColorFilter(cm);
            paint.SetColorFilter(f);
            canvas.DrawBitmap(bmpOriginal, 0, 0, paint);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    c = bmpOriginal.GetPixel(x, y);

                    r = Android.Graphics.Color.GetRedComponent(c);
                    g = Android.Graphics.Color.GetGreenComponent(c);
                    b = Android.Graphics.Color.GetBlueComponent(c);

                    gry = (r + g + b) / 3;
                    r = g = b = gry;

                    r = r + (depth * 2);
                    g = g + depth;

                    if (r > 255)
                    {
                        r = 255;
                    }
                    if (g > 255)
                    {
                        g = 255;
                    }
                    bmpSephia.SetPixel(x, y, Android.Graphics.Color.Rgb(r,g,b));
                }
            }

            return bmpSephia;
        }
        
    }
}