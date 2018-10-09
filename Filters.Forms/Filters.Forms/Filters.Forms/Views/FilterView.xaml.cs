using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Filters.Forms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FilterView : ContentPage
	{
        const string TEXT = "Blur My Text";
        //SKBitmap bitmap = BitmapExtensions.LoadBitmapResource(
        //                    typeof(FilterView),
        //                    "SkiaSharpFormsDemos.Media.SeatedMonkey.jpg");
        public FilterView ()
		{
			InitializeComponent ();
		}
        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            canvasView.InvalidateSurface();
        }

        private void canvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            float z = (float)zSlider.Value;
            float surfaceScale = (float)surfaceScaleSlider.Value;
            float lightConstant = (float)lightConstantSlider.Value;

            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;

                // Size text to 90% of canvas width
                paint.TextSize = 100;
                float textWidth = paint.MeasureText(TEXT);
                paint.TextSize *= 0.9f * info.Width / textWidth;

                // Find coordinates to center text
                SKRect textBounds = new SKRect();
                paint.MeasureText(TEXT, ref textBounds);

                float xText = info.Rect.MidX - textBounds.MidX;
                float yText = info.Rect.MidY - textBounds.MidY;

                // Create distant light image filter
                paint.ImageFilter = SKImageFilter.CreateDistantLitDiffuse(
                                        new SKPoint3(2, 3, z),
                                        SKColors.White,
                                        surfaceScale,
                                        lightConstant);

                canvas.DrawText(TEXT, xText, yText, paint);
            }
        }
    }
}