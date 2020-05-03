using BornToRace.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace BornToRace.ViewModels
{
    public class LoadGame
    {
        private static ObservableCollection<PlayerDb> _player;
        private SQLiteAsyncConnection _connection;

        public LoadGame()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            try { 
            LoadFromDb(_connection);
            }
            catch
            {
                Console.WriteLine("Database is empty or corrupt.");
            }
        }

        async static void LoadFromDb(SQLiteAsyncConnection connection)
        {
            try 
            { 
            var player = await connection.Table<PlayerDb>().ToListAsync();
            _player = new ObservableCollection<PlayerDb>(player);
            }
            catch
            {
                Console.WriteLine("Database is corrupt.");
            }
        }
        public int GetId()
        {
            int _id;
            if (_player != null && _player.Count() > 0)
                   _id = _player[0].Id;
            else
                   _id = -1;

            return _id;
        }
        public string GetName()
        {
            string _name;
            if (_player != null && _player.Count() > 0)
                _name = _player[0].Name;
            else
                _name = "NA";

            return _name;
        }
        public double GetMoney()
        {
            double _money;
            if (_player != null && _player.Count() > 0)
                _money = _player[0].Money;
            else
                _money = 0;

            return _money;
        }
        public int GetEnergy()
        {
            int _energy;
            if (_player != null && _player.Count() > 0)
                _energy = _player[0].Energy;
            else
                _energy = 0;
            return _energy;
        }

        // DEBUG ONLY! IT WILL PURGE THE PLAYER TABLE!!
        async public void DebugPurgeDatabase()
        {
            await _connection.DropTableAsync<PlayerDb>();
        }
    }
}
