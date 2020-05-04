using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BornToRace.Models
{

        public class DriverDb : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            [PrimaryKey]
            public int Id { get; set; }

            private string _firstname;
            [MaxLength(255)]
            public string FirstName
            {
                get { return _firstname; }
                set
                {
                    if (_firstname == value)
                        return;
                _firstname = value;

                    OnPropertyChanged();
                }
            }

        private string _lastname;
        [MaxLength(255)]
        public string LastName
        {
            get { return _lastname; }
            set
            {
                if (_lastname == value)
                    return;
                _lastname = value;

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

        private int _fitness;
        public int Fitness
        {
            get { return _fitness; }
            set
            {
                if (_fitness == value)
                    return;
                _fitness = value;

                OnPropertyChanged();
            }
        }

        private int _focus;
        public int Focus
        {
            get { return _focus; }
            set
            {
                if (_focus == value)
                    return;
                _focus = value;

                OnPropertyChanged();
            }
        }

        private int _agility;
        public int Agility
        {
            get { return _agility; }
            set
            {
                if (_agility == value)
                    return;
                _agility = value;

                OnPropertyChanged();
            }
        }

        private int _courage;
        public int Courage
        {
            get { return _courage; }
            set
            {
                if (_courage == value)
                    return;
                _courage = value;

                OnPropertyChanged();
            }
        }

        private int _intelligence;
        public int Intelligence
        {
            get { return _intelligence; }
            set
            {
                if (_intelligence == value)
                    return;
                _intelligence = value;

                OnPropertyChanged();
            }
        }

        private int _morale;
        public int Morale
        {
            get { return _intelligence; }
            set
            {
                if (_morale == value)
                    return;
                _morale = value;

                OnPropertyChanged();
            }
        }

        private int _marketibility;
        public int Marketability
        {
            get { return _marketibility; }
            set
            {
                if (_marketibility == value)
                    return;
                _marketibility = value;

                OnPropertyChanged();
            }
        }

        private int _skills;
        public int Skills
        {
            get { return _skills; }
            set
            {
                if (_skills == value)
                    return;
                _skills = value;

                OnPropertyChanged();
            }
        }

        private int _fame;
        public int Fame
        {
            get { return _fame; }
            set
            {
                if (_fame == value)
                    return;
                _fame = value;

                OnPropertyChanged();
            }
        }

        private int _manager;
        public int Manager
        {
            get { return _manager; }
            set
            {
                if (_manager == value)
                    return;
                _manager = value;

                OnPropertyChanged();
            }
        }


        private int _salary;
        public int Salary
        {
            get { return _salary; }
            set
            {
                if (_salary == value)
                    return;
                _salary = value;

                OnPropertyChanged();
            }
        }
        /*
        private int _effects;
        public int Effects
        {
            get { return _effects; }
            set
            {
                if (_effects == value)
                    return;
                _effects = value;

                OnPropertyChanged();
            }
        }

        private int _items;
        public int Items
        {
            get { return _items; }
            set
            {
                if (_items == value)
                    return;
                _items = value;

                OnPropertyChanged();
            }
        }
        */
        private DateTime _born;
        public DateTime Born
        {
            get { return _born; }
            set
            {
                if (_born == value)
                    return;
                _born = value;

                OnPropertyChanged();
            }
        }


        /*
        private List<int> _relation;
        public List<int> Relation
        {
            get { return _relation; }
            set
            {
                if (_relation == value)
                    return;
                _relation = value;

                OnPropertyChanged();
            }
        }

        private List<int> _fanrelation;
        public List<int> FanRelation
        {
            get { return _fanrelation; }
            set
            {
                if (_fanrelation == value)
                    return;
                _fanrelation = value;

                OnPropertyChanged();
            }
        }
        */
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }