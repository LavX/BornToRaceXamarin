using BornToRace.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
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
            CreateTables();
        }

        async public void CreateTables()
        {
            await _connection.CreateTableAsync<PlayerDb>();
        }

        async public void NewGame(string name)
        {
            CreateTables();
            var players = await _connection.Table<PlayerDb>().ToListAsync();
            _player = new ObservableCollection<PlayerDb>(players);
            if (_player[0].Id != 0)
            {
            var player = new PlayerDb { Id = 0, Name = name, Energy = 100, Money = 5000 };
            await _connection.InsertAsync(player);
            _player.Add(player);
            }
        }
    }
}
