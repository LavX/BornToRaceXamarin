using BornToRace.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BornToRace.ViewModels
{
    class WriteToDb
    {
        private static ObservableCollection<DriverDb> _player;
        private static SQLiteAsyncConnection _connection;

        public WriteToDb()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        public async Task<string> CreateTables()
        {
            await _connection.CreateTableAsync<DriverDb>();
            return "success";
        }

        static async Task<string> LoadFromDb(SQLiteAsyncConnection connection)
        {
            var player = await connection.Table<DriverDb>().ToListAsync();
            _player = new ObservableCollection<DriverDb>(player);
            return "success";
        }

        async public Task NewGame(DriverDb player)
        {
            var _createTables = CreateTables();
            await _createTables;
            var _loadFromDb = LoadFromDb(_connection);
            await _loadFromDb;
            if (_player.Count == 0)
            {
                //var player = new DriverDb { Id = 0, LastName = name, Energy = 100, Money = 5000 };
                await _connection.InsertAsync(player);
                _player.Add(player);
            }
        }
    }
}
