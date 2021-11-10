using System;
using System.IO;
using Xamarin.Forms;
using XamarinFormsLibrary1;

[assembly: Dependency(typeof(CashFlow.iOS.FileHelper))]
namespace CashFlow.iOS
{
    public class FileHelper : IFileHelper {
        public Stream GetSharedFile(string fileResourceName) {
            Type type = typeof(IFileHelper); // We could use any type here, just needs to be something in your shared project so we get the correct Assembly below
            return type.Assembly.GetManifestResourceStream(fileResourceName);
        }
    }
}