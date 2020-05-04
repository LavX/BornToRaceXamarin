using BornToRace.Models;
using BornToRace.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Subscribe();
            LoadGame();
        }

        protected void Subscribe()
        {
            MessagingCenter.Subscribe<App, double>((App)Application.Current, Events.PlayerMoneyChanged, (Sender, money) => {
                ToolbarMoney.Text = "Money:\r\n$" + money.ToString("#,##0");
            });

            MessagingCenter.Subscribe<App, int>((App)Application.Current, Events.PlayerEnergyChanged, (Sender, energy) => {
                ToolbarEnergy.Text = "Energy:\r\n" + energy.ToString()+"/100";
            });
        }
        protected async Task LoadGame()
        {
            LoadGame _loadGame = new LoadGame();
            Player.Name = await _loadGame.GetName();
            Player.Money = await _loadGame.GetMoney();
            Player.Energy = await _loadGame.GetEnergy();

            MessagingCenter.Send<BornToRace.App, string>((BornToRace.App)Xamarin.Forms.Application.Current, Events.PlayerNameChanged, Player.Name);
            MessagingCenter.Send<BornToRace.App, double>((BornToRace.App)Xamarin.Forms.Application.Current, Events.PlayerMoneyChanged, Player.Money);
            MessagingCenter.Send<BornToRace.App, int>((BornToRace.App)Xamarin.Forms.Application.Current, Events.PlayerEnergyChanged, Player.Energy);
            if (Player.Name != "NA")
            {
                WelcomeMessage.IsVisible = false;
                SaveGame.IsVisible = false;
            }
        }
        /* private async void LoadGame_Clicked(object sender, EventArgs e)
         {
             LoadGame _loadGame = new LoadGame();
             Player.Name = await _loadGame.GetName();
             Player.Money = await _loadGame.GetMoney();
             Player.Energy = await _loadGame.GetEnergy();

             MessagingCenter.Send(this, Events.PlayerNameChanged, Player.Name);
             MessagingCenter.Send(this, Events.PlayerMoneyChanged, Player.Money);
             MessagingCenter.Send(this, Events.PlayerEnergyChanged, Player.Energy);

             MessagingCenter.Send<BornToRace.App, string>((BornToRace.App)Xamarin.Forms.Application.Current, Events.PlayerNameChanged, Player.Name);
             MessagingCenter.Send<BornToRace.App, double>((BornToRace.App)Xamarin.Forms.Application.Current, Events.PlayerMoneyChanged, Player.Money);
             MessagingCenter.Send<BornToRace.App, int>((BornToRace.App)Xamarin.Forms.Application.Current, Events.PlayerEnergyChanged, Player.Energy);
             

        // DEBUG ONLY! IT WILL PURGE THE PLAYER TABLE!!
        //_loadGame.DebugPurgeDatabase();

    }*/

    private void SaveGame_Clicked(object sender, EventArgs e)
        {
            WriteToDb _saveGame = new WriteToDb();
                //_saveGame.CreateTables();
            _saveGame.NewGame("Laszlo Toth");
            LoadGame();

        }
    }
}