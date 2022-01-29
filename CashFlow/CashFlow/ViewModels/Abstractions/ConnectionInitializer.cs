using System.Threading.Tasks;
using SQLite;

namespace CashFlow.ViewModels.Interfaces
{
    public abstract class ConnectionInitializer
    {
        protected readonly SQLiteAsyncConnection _connection;
        
        protected ConnectionInitializer(SQLiteAsyncConnection connection)
        {
            this._connection = connection;
        }
    }
}