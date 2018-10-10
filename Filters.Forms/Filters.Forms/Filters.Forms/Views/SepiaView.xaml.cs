using System;
using System.IO;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Filters.Forms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SepiaView : ContentPage
	{
        Stream streaming = null;
        public static byte[] Foto;
        
        public SepiaView ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
             
            if (!CrossMedia.Current.IsPickPhotoSupported || !CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = PhotoSize.Small,
                CompressionQuality = 50
            });

            if (file == null)
            {
                return;
            }
            else
            {
                streaming = file.GetStream();
                try
                {
                    byte[] fotingoo = DependencyService.Get<IFilterImage>().Sepia(streaming);
                    //byte[] fotingoo = DependencyService.Register<>();


                    await DisplayAlert("Converted","converted image","ok");
                }
                catch (Exception ex)
                {

                    await DisplayAlert("Converted", ex.Message.ToString(), "ok");
                }
            }
        }

        
    }
}