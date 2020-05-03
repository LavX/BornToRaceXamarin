using BornToRace.Models;
using BornToRace.ViewModels;
using BornToRace.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BornToRace
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]


    public partial class MainPage : MasterDetailPage
    {

        public MainPage()
        {
            //ShowSplashScreen();
            InitializeComponent();
            Subscribe();
        }

        protected void Subscribe()
        {
            MessagingCenter.Subscribe<App, string>((App)Application.Current, Events.PlayerNameChanged, (Sender, name) => {
                PlayerName.Text = name;
            });

            MessagingCenter.Subscribe<App, double>((App)Application.Current, Events.PlayerMoneyChanged, (Sender, money) => {
                ToolbarMoney.Text = money.ToString();
            });

            MessagingCenter.Subscribe<App, int>((App)Application.Current, Events.PlayerEnergyChanged, (Sender, energy) => {
                ToolbarEnergy.Text = energy.ToString();
            });
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();
            GenerateMenu();
            AppVersion.Text = AppInfo.VersionString;
        }

        public void GenerateMenu()
        {
            MenuList.ItemsSource = new List<MenuListItem>
            {
                new MenuListItem { Title = "Home", IconSource="home.png", Target = typeof(HomePage)},
                new MenuListItem { Title = "Notification Center", IconSource="notifications.png", Target = typeof(HomePage)},
                new MenuListItem { Title = "Activities", IconSource="activity.png", Target = typeof(HomePage)},
                new MenuListItem { Title = "Manager", IconSource="manager.png", Target = typeof(HomePage)},
                new MenuListItem { Title = "Championship", IconSource="championship.png", Target = typeof(HomePage)},
                new MenuListItem { Title = "Team", IconSource="teams.png", Target = typeof(HomePage)},
                new MenuListItem { Title = "About", IconSource="about.png", Target = typeof(HomePage)}
            };
            
        }

        async private void ShowSplashScreen()
        {
            await Navigation.PushModalAsync(new SplashScreen());
        }

        private void MenuList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            MenuListItem menuListItem = e.SelectedItem as MenuListItem;
            if (menuListItem != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(menuListItem.Target));
                MenuList.SelectedItem = null;
                IsPresented = false;
            }
        }

        private void DEBUGButtonPurge_Clicked(object sender, EventArgs e)
        {
            LoadGame _loadGame = new LoadGame();
            _loadGame.DebugPurgeDatabase();
        }
    }
}
