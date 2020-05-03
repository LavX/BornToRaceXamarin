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
        private static ObservableCollection<PlayerDb> _player;
        private static SQLiteAsyncConnection _connection;

        public WriteToDb()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        public async Task<string> CreateTables()
        {
            await _connection.CreateTableAsync<PlayerDb>();
            return "success";
        }

        static async Task<string> LoadFromDb(SQLiteAsyncConnection connection)
        {
            var player = await connection.Table<PlayerDb>().ToListAsync();
            _player = new ObservableCollection<PlayerDb>(player);
            return "success";
        }

        async public void NewGame(string name)
        {
            var _createTables = CreateTables();
            await _createTables;
            var _loadFromDb = LoadFromDb(_connection);
            await _loadFromDb;
            if (_player.Count == 0)
            { 
                var player = new PlayerDb { Id = 0, Name = name, Energy = 100, Money = 5000 };
                await _connection.InsertAsync(player);
                _player.Add(player);
            }
        }
    }
}
