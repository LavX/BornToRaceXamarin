using BornToRace.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BornToRace.ViewModels
{
    public class LoadGame
    {
        private static ObservableCollection<DriverDb> _player;
        private SQLiteAsyncConnection _connection;

        public LoadGame()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            try 
            {
               var loadFromDb = LoadFromDb(_connection);
            }
            catch
            {
                Console.WriteLine("Database is empty or corrupt.");
            }
        }

        public async Task<string> LoadFromDb(SQLiteAsyncConnection connection)
        {
            try 
            { 
                var player = await connection.Table<DriverDb>().ToListAsync();
                _player = new ObservableCollection<DriverDb>(player);
                return "success";
            }
            catch
            {
                return "Database is corrupt.";
            }
        }

        public async Task<int> GetId()
        {

            int _id;
            if (_player != null && _player.Count() > 0)
                   _id = _player[0].Id;
            else
            { 
                var loadFromDb = LoadFromDb(_connection);
                await loadFromDb;
                _id = -1;
                if (_player != null && _player.Count() > 0)
                    _id = _player[0].Id;
            }

            return _id;
        }
        public async Task<string> GetName()
        {
            string _name;
            if (_player != null && _player.Count() > 0)
                _name = _player[0].LastName;
            else
            {
                var loadFromDb = LoadFromDb(_connection);
                await loadFromDb;
                _name = "NA";
                if (_player != null && _player.Count() > 0)
                    _name = _player[0].LastName;
            }
            return _name;
        }
        public async Task<double> GetMoney()
        {
            double _money;
            if (_player != null && _player.Count() > 0)
                _money = _player[0].Money;
            else
            {
                var loadFromDb = LoadFromDb(_connection);
                await loadFromDb;
                _money = 0;
                if (_player != null && _player.Count() > 0)
                    _money = _player[0].Money;
            }

                return _money;
        }
        public async Task<int> GetEnergy()
        {
            int _energy;
            if (_player != null && _player.Count() > 0)
                _energy = _player[0].Energy;
            else
            {
                var loadFromDb = LoadFromDb(_connection);
                await loadFromDb;
                _energy = 0;
                if (_player != null && _player.Count() > 0)
                    _energy = _player[0].Energy;
            }
            return _energy;
        }

        // DEBUG ONLY! IT WILL PURGE THE PLAYER TABLE!!
        async public void DebugPurgeDatabase()
        {
            await _connection.DropTableAsync<DriverDb>();
        }
    }
}
