using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BornToRace.Models
{

        public class PlayerDb : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            [PrimaryKey]
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
    }