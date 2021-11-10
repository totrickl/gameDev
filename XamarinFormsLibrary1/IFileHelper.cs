using System.IO;

namespace XamarinFormsLibrary1
{
    public interface IFileHelper {
        Stream GetSharedFile(string fileResourceName);
    }
}