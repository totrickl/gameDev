using System;
using System.Threading.Tasks;
using SQLite;
using CashFlow.Models;
using System.Data;
using CashFlow.ViewModels;

namespace CashFlow.DataAccess
{
    public class PlayerDb
    {
        private readonly SQLiteAsyncConnection connection;

        public PlayerDb(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<PlayerViewModel>();
        }

        public async Task<PlayerViewModel> SavePlayerAsync(PlayerViewModel player)
        {
            if (player.Id != 0)
            {
                return await GetPlayerById(player.Id);
            }
            else
            {
                try
                {
                    var pid = await connection.InsertAsync(player);
                    var player1 = await GetPlayerById(pid);
                    return player1;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                // return await GetPlayerById(pid);
            }
        }

        public async Task<PlayerViewModel> GetPlayerById(int id)
        {
            if (id == -1)
            {
                return await SavePlayerAsync(new PlayerViewModel());
            }

            return await connection.GetAsync<PlayerViewModel>(id);
        }
    }
}