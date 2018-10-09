using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;
namespace Filters.Forms
{
    public interface IFilterImage
    {
        byte[] Sepia(Stream image);
    }
}
