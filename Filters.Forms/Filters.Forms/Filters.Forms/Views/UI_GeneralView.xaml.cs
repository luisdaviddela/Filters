using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Filters.Forms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UI_GeneralView : ContentPage
	{
		public UI_GeneralView (byte[] imageS)
		{
			InitializeComponent ();
		}
	}
}