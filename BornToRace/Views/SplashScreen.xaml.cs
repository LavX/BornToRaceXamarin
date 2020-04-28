using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BornToRace.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreen : ContentPage
    {
        public SplashScreen()
        {
            InitializeComponent();
            Splash();
            
        }

        async private void Splash()
        {
            await PageLayout.FadeTo(0, 10);
            await PageLayout.FadeTo(1, 3000);
            await Task.Delay(4000);
            await PageLayout.FadeTo(0, 1000);
            await Task.Delay(1000);
            await Navigation.PopModalAsync();
        }
    }
}