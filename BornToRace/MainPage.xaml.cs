using BornToRace.Models;
using BornToRace.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        /*debug
        string Money = "Money: $ 144 001.31";
        string Energy = "Energy: 100/100";
        string Date = "01/05/2020";
        */
        private ObservableCollection<Player> _player;
        private SQLiteAsyncConnection _connection;

        public MainPage()
        {
            ShowSplashScreen();
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Player>();
            var player = await _connection.Table<Player>().ToListAsync();
            _player = new ObservableCollection<Player>(player);
            base.OnAppearing();
            GenerateMenu();
            //ToolbarDate.Text = "02/12/2000";
            //ToolbarEnergy.Text = 
            AppVersion.Text = AppInfo.VersionString;

        }

        public class Player : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }

            private string _name;
            [MaxLength(255)]
            public string Name
            {
                get { return _name; }
                set
                {
                    if (_name == value)
                        return;
                    _name = value;

                    OnPropertyChanged();
                }
            }


            private double _money;
            public double Money
            {
                get { return _money; }
                set
                {
                    if (_money == value)
                        return;
                    _money = value;

                    OnPropertyChanged();
                }
            }

            private int _energy;
            public int Energy
            {
                get { return _energy; }
                set
                {
                    if (_energy == value)
                        return;
                    _energy = value;

                    OnPropertyChanged();
                }
            }

            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

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
    }
}
