using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using CashFlow.ViewModels;
using CashFlow.ViewModels.Interfaces;

namespace CashFlow.DataAccess
{
    public partial class DbAccessor
    {
        private readonly SQLiteAsyncConnection connection;
        private Business _business;
        private RealEstate _realEstate;

        // private readonly SQLiteConnection connection;
        private Stock _stock;

        public DbAccessor(string dbPath)
        {
            connection = new(dbPath);

            _stock = new(connection);
            _realEstate = new(connection);
            _business = new(connection);

            Task.Run(async () =>
            {
                await connection.CreateTableAsync<BusinessViewModel>();
                await connection.CreateTableAsync<RealEstateViewModel>();
                await connection.CreateTableAsync<StockViewModel>();
                await connection.CreateTableAsync<PlayerViewModel>();
            }).GetAwaiter().GetResult();
        }

        public async Task<PlayerViewModel[]> GetPlayersAsync(int? take = null)
        {
            if (take is null) return Array.Empty<PlayerViewModel>();

            try
            {
                return Task.Run(async () => await connection.Table<PlayerViewModel>().Take(take.Value).ToArrayAsync())
                    .GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<PlayerViewModel> UpdatePlayerAsync(PlayerViewModel player)
        {
            await connection.UpdateAsync(player);
            return player;
        }

        public async Task<PlayerViewModel> SavePlayerAsync(PlayerViewModel player)
        {
            await connection.InsertAsync(player);
            return player;
            // return await GetPlayerById(player.Id);
        }


        public async Task<PlayerViewModel> GetPlayerById(int id)
        {
            return await connection.GetAsync<PlayerViewModel>(id);
        }
    }
}

public class Stock : ConnectionInitializer, IDbAccessible<StockViewModel>
{
    public Stock(SQLiteAsyncConnection connection) : base(connection)
    {
    }

    public async Task<int> CreateAsync(StockViewModel stock)
    {
        return await _connection.InsertAsync(stock);
    }

    public async Task<StockViewModel> GetByIdAsync(int id)
    {
        return await _connection.GetAsync<StockViewModel>(id);
    }

    public async Task<IEnumerable<StockViewModel>> GetByUserIdAsync(int userId)
    {
        string query = @"select * from StockViewModel where PlayerId = ?";
        return await _connection.DeferredQueryAsync<StockViewModel>(query, userId);
    }
}

public class RealEstate : ConnectionInitializer, IDbAccessible<RealEstateViewModel>
{
    public RealEstate(SQLiteAsyncConnection connection) : base(connection)
    {
    }

    public async Task<int> CreateAsync(RealEstateViewModel realEstate)
    {
        return await _connection.InsertAsync(realEstate);
    }

    public async Task<RealEstateViewModel> GetByIdAsync(int id)
    {
        return await _connection.GetAsync<RealEstateViewModel>(id);
    }

    public async Task<IEnumerable<RealEstateViewModel>> GetByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
}

public class Business : ConnectionInitializer, IDbAccessible<BusinessViewModel>
{
    public Business(SQLiteAsyncConnection connection) : base(connection)
    {
    }

    public async Task<int> CreateAsync(BusinessViewModel business)
    {
        return await _connection.InsertAsync(business);
    }

    public async Task<BusinessViewModel> GetByIdAsync(int id)
    {
        return await _connection.GetAsync<BusinessViewModel>(id);
    }

    public async Task<IEnumerable<BusinessViewModel>> GetByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
}