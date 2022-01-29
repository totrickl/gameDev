using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using CashFlow.Models;
using System.Data;
using System.Linq;
using CashFlow.ViewModels;
using CashFlow.ViewModels.Interfaces;

namespace CashFlow.DataAccess
{
    public class DbAccessor
    {
        private readonly SQLiteAsyncConnection connection;
        // private readonly SQLiteConnection connection;
        private Stock _stock;
        private RealEstate _realEstate;
        private Business _business;

        public DbAccessor(string dbPath)
        {
            connection = new(dbPath);

            _stock = new(connection);
            _realEstate = new(connection);
            _business = new(connection);

            connection.CreateTableAsync<BusinessViewModel>();
            connection.CreateTableAsync<RealEstateViewModel>();
            connection.CreateTableAsync<StockViewModel>();
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
                    await connection.InsertAsync(player);
                    return (await connection.QueryAsync<PlayerViewModel>(@"SELECT * FROM PlayerViewModel")).LastOrDefault();
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
                return await SavePlayerAsync(new());
            }

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