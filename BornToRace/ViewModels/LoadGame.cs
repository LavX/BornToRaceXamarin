using BornToRace.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace BornToRace.ViewModels
{
    public class LoadGame
    {
        private static ObservableCollection<PlayerDb> _player;
        private SQLiteAsyncConnection _connection;

        public LoadGame()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            LoadFromDb(_connection);
        }

        async static void LoadFromDb(SQLiteAsyncConnection connection)
        {
            var player = await connection.Table<PlayerDb>().ToListAsync();
            _player = new ObservableCollection<PlayerDb>(player);
        }
        public int GetId()
        {
            int _id;
            try
            {
               _id = _player[0].Id;
            }
            catch
            {
               _id = -1;
            }
            return _id;
        }
        public string GetName()
        {
            string _name = _player[0].Name;
            return _name;
        }
        public double GetMoney()
        {
            double _money = _player[0].Money;
            return _money;
        }
        public int GetEnergy()
        {
            int _energy = _player[0].Energy;
            return _energy;
        }
    }
}
