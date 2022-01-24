using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Newtonsoft.Json;
using System.Net.Http;
using TesteKryptusMVVM.Models;
using TesteKryptusMVVM.ViewModels;
using Avalonia.Platform;
using Avalonia.Input;

namespace TesteKryptusMVVM.Views
{
    public partial class StarWars : Window
    {
        public StarWars()
        {
            InitializeComponent();
            this.DataContext = new StarWarsViewModel();
            this.AttachDevTools();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
        }

        public void InitWindow(object sender, GotFocusEventArgs e)
        {
            RetornaDados();
        }

        private void OnMovieChanged(object sender, SelectionChangedEventArgs e)
        {
            var context = this.DataContext as StarWarsViewModel;
            ListBox listbox = (ListBox)sender;


            if (listbox.SelectedItem != null)
            {
                Movie movieSelected = (Movie)listbox.SelectedItem;
                DeserializeCharacter(context, movieSelected);
                DeserializePlanet(context, movieSelected);
                DeserializeSpecie(context, movieSelected);
                DeserializeStarship(context, movieSelected);
                DeserializeVehicle(context, movieSelected);
            }



        }

        public void OnDashboardPressed(object sender, PointerPressedEventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        private async void RetornaDados()
        {
            string URI = "https://swapi.dev/api/films/";
            using (var cliente = new HttpClient())
            {
                using (var response = await cliente.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var JsonString = await response.Content.ReadAsStringAsync();
                        FilmsModel filmModel = JsonConvert.DeserializeObject<FilmsModel>(JsonString);
                        var context = this.DataContext as StarWarsViewModel;
                        //context.Teste = filmModel.movies[0].Title;
                        context.Movies = filmModel.movies;
                        
                    }
                }
            }
        }

        private async void DeserializePlanet(StarWarsViewModel context, Movie movieSelected)
        {
            movieSelected.Planets = new Planet[movieSelected.PlanetsUrl.Length + 1];
                for (int i = 0; i < movieSelected.PlanetsUrl.Length; i++)
                {
                    string URI = movieSelected.PlanetsUrl[i];
                    using (var cliente = new HttpClient())
                    {
                        using (var response = await cliente.GetAsync(URI))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var JsonString = await response.Content.ReadAsStringAsync();
                                Planet planet = JsonConvert.DeserializeObject<Planet>(JsonString);
                                if (planet != null)
                                {
                                movieSelected.Planets[i] = planet;
                                }
                            }
                        }
                    }
                }
                context.Planets = movieSelected.Planets;
        }

        private async void DeserializeVehicle(StarWarsViewModel context, Movie movieSelected)
        {

            movieSelected.Vehicles = new Vehicle[movieSelected.VehiclesUrl.Length + 1];
            for (int i = 0; i < movieSelected.VehiclesUrl.Length; i++)
            {
                string URI = movieSelected.VehiclesUrl[i];
                using (var cliente = new HttpClient())
                {
                    using (var response = await cliente.GetAsync(URI))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var JsonString = await response.Content.ReadAsStringAsync();
                            Vehicle vehicle = JsonConvert.DeserializeObject<Vehicle>(JsonString);
                            if (vehicle != null)
                            {
                                movieSelected.Vehicles[i] = vehicle;
                            }
                        }
                    }
                }
            }
            context.Vehicles = movieSelected.Vehicles;
            
        }

        private async void DeserializeSpecie(StarWarsViewModel context, Movie movieSelected)
        {
            movieSelected.Species = new Specie[movieSelected.CharactersUrl.Length + 1];
            for (int i = 0; i < movieSelected.CharactersUrl.Length; i++)
            {
                string URI = movieSelected.CharactersUrl[i];
                using (var cliente = new HttpClient())
                {
                    using (var response = await cliente.GetAsync(URI))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var JsonString = await response.Content.ReadAsStringAsync();
                            Specie specie = JsonConvert.DeserializeObject<Specie>(JsonString);
                            if (specie != null)
                            {
                                movieSelected.Species[i] = specie;
                            }
                        }
                    }
                }
            }
            context.Species = movieSelected.Species;
        }

        private async void DeserializeStarship(StarWarsViewModel context, Movie movieSelected)
        {
            movieSelected.Starships = new Starship[movieSelected.StarshipsUrl.Length + 1];
            for (int i = 0; i < movieSelected.StarshipsUrl.Length; i++)
            {
                string URI = movieSelected.StarshipsUrl[i];
                using (var cliente = new HttpClient())
                {
                    using (var response = await cliente.GetAsync(URI))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var JsonString = await response.Content.ReadAsStringAsync();
                            Starship starship = JsonConvert.DeserializeObject<Starship>(JsonString);
                            if (starship != null)
                            {
                                movieSelected.Starships[i] = starship;
                            }
                        }
                    }
                }
            }
            context.Starships = movieSelected.Starships;
        }

        private async void DeserializeCharacter(StarWarsViewModel context, Movie movieSelected)
        {
            movieSelected.Characters = new Character[movieSelected.CharactersUrl.Length + 1];
            for (int i = 0; i < movieSelected.CharactersUrl.Length; i++)
            {
                string URI = movieSelected.CharactersUrl[i];
                using (var cliente = new HttpClient())
                {
                    using (var response = await cliente.GetAsync(URI))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var JsonString = await response.Content.ReadAsStringAsync();
                            Character character = JsonConvert.DeserializeObject<Character>(JsonString);
                            if (character != null)
                            {
                                movieSelected.Characters[i] = character;
                            }
                        }
                    }
                }
            }
            context.Characters = movieSelected.Characters;
            
        }
    }
}
