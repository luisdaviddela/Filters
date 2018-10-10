using System.IO;
namespace Filters.Forms
{
    public interface IFilterImage
    {
        byte[] Sepia(byte[] image);
    }
}
