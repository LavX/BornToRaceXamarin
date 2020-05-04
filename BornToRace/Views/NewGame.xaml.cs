using BornToRace.Models;
using BornToRace.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BornToRace.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewGame : ContentPage
    {
        DriverDb Player = new DriverDb();
        public NewGame()
        {
            InitializeComponent();
        }

        private void NewGame_Clicked(object sender, EventArgs e)
        {
            WriteToDb _saveGame = new WriteToDb();

            MessagingCenter.Send<BornToRace.App, string>((BornToRace.App)Xamarin.Forms.Application.Current, Events.PlayerNameChanged, Player.LastName);
            MessagingCenter.Send<BornToRace.App, double>((BornToRace.App)Xamarin.Forms.Application.Current, Events.PlayerMoneyChanged, Player.Money);
            MessagingCenter.Send<BornToRace.App, int>((BornToRace.App)Xamarin.Forms.Application.Current, Events.PlayerEnergyChanged, Player.Energy);
        }

        private void AvatarCell_Tapped(object sender, EventArgs e)
        {

        }
    }
}