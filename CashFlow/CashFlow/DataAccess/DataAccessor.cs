using System.IO;
using CashFlow.Models;
using Newtonsoft.Json;
using XamarinFormsLibrary1;

namespace CashFlow.DataAccess
{
    public class DataAccessor
    {
        private Documentation _filehelper;
        public Player Player { get; set; }
        
        public DataAccessor()
        {
            this.Player = GetDataFromFile();
            _filehelper = new Documentation();
        }
        
        private Player GetDataFromFile()
        {
            return JsonConvert.DeserializeObject<Player>(_filehelper.GetDocs());
        }

        public void UpdateFileData(Stream data)
        {
            _filehelper.SetDoc(data);
        }
    }
}