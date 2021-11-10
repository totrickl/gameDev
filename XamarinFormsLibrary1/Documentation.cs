using System.IO;
using Xamarin.Forms;

namespace XamarinFormsLibrary1
{
    public class Documentation
    {
        private IFileHelper helper;

        private readonly string _filePathWithName =
            string.Concat(System.Environment.SpecialFolder.Personal, "/", "gameData.json");

        private const string
            ResourcePath =
                "XamarinFormsLibrary1.cashFlowGameData.json"; // App would be your application's namespace, you may need to play with the Documentation path part to get it working

        public Documentation()
        {
            helper = DependencyService.Get<IFileHelper>(); // Your platform specific helper will be filled in here
        }

        public string GetDocs()
        {
            Stream stream = helper.GetSharedFile(ResourcePath);
            using (stream)
            using (StreamReader reader = new StreamReader(stream)) {
                return reader.ReadToEnd(); // This should be the file contents, you could serialize/process it further
            }
        }

        public void SetDoc(Stream data)
        {
            Stream stream = helper.GetSharedFile(ResourcePath);

            using (stream)
            using (StreamWriter sw = new StreamWriter(stream))
            {
                sw.Write(data);
            }
        }
    }
}