using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BornToRace.Models
{
    public class WorldDb : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey]
        public int Id { get; set; }

        private string _country;
        [MaxLength(255)]
        public string Country
        {
            get { return _country; }
            set
            {
                if (_country == value)
                    return;
                _country = value;

                OnPropertyChanged();
            }
        }

        private string _flag;
        public string Flag
        {
            get { return _flag; }
            set
            {
                if (_flag == value)
                    return;
                _flag = value;

                OnPropertyChanged();
            }
        }

        private bool _isenabled;
        public bool IsEnabled
        {
            get { return _isenabled; }
            set
            {
                if (_isenabled == value)
                    return;
                _isenabled = value;

                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
