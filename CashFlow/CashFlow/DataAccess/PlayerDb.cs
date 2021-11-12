using System;
using System.Threading.Tasks;
using SQLite;
using CashFlow.Models;
using System.Data;

namespace CashFlow.DataAccess
{
    public class PlayerDb
    {
        private readonly SQLiteAsyncConnection connection;

        public PlayerDb(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<Player>();
        }

        public async Task<Player> SavePlayerAsync(Player player)
        {
            if (player.Id != 0)
            {
                return await GetPlayerById(player.Id);
            }
            else
            {
                var pid = await connection.InsertAsync(player);
                return await GetPlayerById(pid);
            }
        }

        public async Task<Player> GetPlayerById(int id)
        {
            if (id == -1)
            {
                return await SavePlayerAsync(new Player());
            }
            
            return await connection.GetAsync<Player>(id);
        }
    }
}