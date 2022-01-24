using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TesteKryptusMVVM.Models;

namespace TesteKryptusMVVM.ViewModels
{
    class StarWarsViewModel : INotifyPropertyChanged
    {
        private Movie[] _movies;

        private Character[] _characters;

        private Planet[] _planets;

        private Vehicle[] _vehicles;

        private Starship[] _starships;

        private Specie[] _species;

        private Movie _selectedMovie;


        public Movie[] Movies
        {
            get => _movies;
            set
            {
                if (value != _movies)
                {
                    _movies = value;
                    OnPropertyChanged();
                }
            }
        }

        public Character[] Characters
        {
            get => _characters;
            set
            {
                if (value != _characters)
                {
                    _characters = value;
                    OnPropertyChanged();
                }
            }
        }



        public Planet[] Planets
        {
            get => _planets;
            set
            {
                if (value != _planets)
                {
                    _planets = value;
                    OnPropertyChanged();
                }
            }
        }

        public Vehicle[] Vehicles
        {
            get => _vehicles;
            set
            {
                if (value != _vehicles)
                {
                    _vehicles = value;
                    OnPropertyChanged();
                }
            }
        }

        public Starship[] Starships
        {
            get => _starships;
            set
            {
                if (value != _starships)
                {
                    _starships = value;
                    OnPropertyChanged();
                }
            }
        }

        public Specie[] Species
        {
            get => _species;
            set
            {
                if (value != _species)
                {
                    _species = value;
                    OnPropertyChanged();
                }
            }
        }

        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                if (value != _selectedMovie)
                {
                    _selectedMovie = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
