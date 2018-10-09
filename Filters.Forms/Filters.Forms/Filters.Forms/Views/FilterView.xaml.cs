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
		public FilterView ()
		{
			InitializeComponent ();
		}
	}
}