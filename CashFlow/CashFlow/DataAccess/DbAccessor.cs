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
        private Stock _stock;
        private RealEstate _realEstate;
        private Business _business;

        public int TotalPlayersCount => 
            Task.Run(async () => (await connection.QueryAsync<PlayerViewModel>("select * from PlayerViewModel")).Count()).GetAwaiter().GetResult();

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
            var existingPlayer = await GetPlayerById(player.Id);

            if (existingPlayer == null)
                await connection.InsertAsync(player);

            if (EntityChanged(player, existingPlayer))
                await connection.UpdateAsync(player);

            return await connection.GetAsync<PlayerViewModel>(p => p.Id == player.Id);
            // return (await connection.QueryAsync<PlayerViewModel>(@"SELECT * FROM PlayerViewModel")).LastOrDefault();
        }

        private async Task<PlayerViewModel> GetPlayerById(int id) => await connection.GetAsync<PlayerViewModel>(p => p.Id == id);

        public async Task<PlayerViewModel> GetLastAddedPlayer()
        {
            return (await connection.QueryAsync<PlayerViewModel>(@"SELECT * FROM PlayerViewModel ORDER BY Id")).LastOrDefault();
        } 

        private bool EntityChanged(PlayerViewModel inputEntity, PlayerViewModel existingEntity)
            =>
                inputEntity.Id != existingEntity.Id
                && inputEntity.Cash != existingEntity.Cash
                && inputEntity.GeneralExpense != existingEntity.GeneralExpense
                && inputEntity.GeneralIncome != existingEntity.GeneralIncome
                && inputEntity.PassiveIncome != existingEntity.PassiveIncome
                && inputEntity.PayCheck != existingEntity.PayCheck
                && inputEntity.PlayerName != existingEntity.PlayerName
                && inputEntity.Salary != existingEntity.Salary;
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

    public async Task<IEnumerable<StockViewModel>> GetByPlayerIdAsync(int userId)
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

    public async Task<IEnumerable<RealEstateViewModel>> GetByPlayerIdAsync(int userId)
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

    public async Task<IEnumerable<BusinessViewModel>> GetByPlayerIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
}