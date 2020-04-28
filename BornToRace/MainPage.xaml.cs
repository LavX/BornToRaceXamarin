using BornToRace.Models;
using BornToRace.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ShowSplashScreen();
            InitializeComponent();
            GenerateMenu();
            
        }

        public void GenerateMenu()
        {
            MenuList.ItemsSource = new List<MenuListItem>
            {
                new MenuListItem { Title = "Home", Target = typeof(HomePage)},
                new MenuListItem { Title = "Notification Center", Target = typeof(HomePage)},
                new MenuListItem { Title = "Activities", Target = typeof(HomePage)},
                new MenuListItem { Title = "Manager", Target = typeof(HomePage)},
                new MenuListItem { Title = "Championship", Target = typeof(HomePage)},
                new MenuListItem { Title = "Team", Target = typeof(HomePage)},
                new MenuListItem { Title = "About", Target = typeof(HomePage)}
            };
        }

        async private void ShowSplashScreen()
        {
            await Navigation.PushModalAsync(new SplashScreen());
        }

        private void MenuList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menuListItem = e.SelectedItem as MenuListItem;
            if (menuListItem != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(menuListItem.Target));
                MenuList.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
