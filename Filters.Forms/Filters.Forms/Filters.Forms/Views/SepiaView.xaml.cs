using System;
using System.IO;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Filters.Forms.Views;
namespace Filters.Forms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SepiaView : ContentPage
	{
        Stream streaming = null;
        byte[] arry = null;
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
                PhotoSize = PhotoSize.Full
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
                    arry = GetImageStreamAsBytes(streaming);
                    byte[] fotingoo = DependencyService.Get<IFilterImage>().Sepia(arry);

                    //await DisplayAlert("Converted","converted image","ok");
                    await Navigation.PushAsync(new UI_GeneralView(fotingoo));
                }
                catch (Exception ex)
                {

                    await DisplayAlert("Converted", ex.Message.ToString(), "ok");
                }
            }
        }

        public byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();

            }
        }
    }
}