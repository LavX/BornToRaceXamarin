using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BornToRace.Extensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AvatarCell : ViewCell
    {
        public static readonly BindableProperty ImageProperty =
            BindableProperty.Create("Source", typeof(string), typeof(DateCell));
        public string Source
        { 
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public AvatarCell()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}