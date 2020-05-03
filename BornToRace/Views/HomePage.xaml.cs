using BornToRace.Models;
using BornToRace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BornToRace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        PlayerDb Player = new PlayerDb();

        public HomePage()
        {
            InitializeComponent();
        }

        private void LoadGame_Clicked(object sender, EventArgs e)
        {
            LoadGame _loadGame = new LoadGame();
            Player.Name = _loadGame.GetName();
            Player.Money = _loadGame.GetMoney();
            Player.Energy = _loadGame.GetEnergy();

            if (Player.Id == -1)
                DisplayAlert("Cannot Load", "Unable to load save game! Try to create new game instead", "Ok");

            // DEBUG ONLY! IT WILL PURGE THE PLAYER TABLE!!
            //_loadGame.DebugPurgeDatabase();
        }

        private void SaveGame_Clicked(object sender, EventArgs e)
        {
            WriteToDb _saveGame = new WriteToDb();
                //_saveGame.CreateTables();
                _saveGame.NewGame("Laszlo Toth");

        }
    }
}