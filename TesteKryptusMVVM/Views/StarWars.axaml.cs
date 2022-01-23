using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Newtonsoft.Json;
using System.Net.Http;
using TesteKryptusMVVM.Models;
using TesteKryptusMVVM.ViewModels;

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


        }

        private void OnButtonClick(object sender, RoutedEventArgs args)
        {
            RetornaDados();

        }

        /* private async Task RunAsync()
         {
             HttpClient client;
             Uri userUri;


             client = new HttpClient();
             client.BaseAddress = new Uri("https://swapi.dev");
             client.DefaultRequestHeaders.Accept.Clear();
             client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
             var context = this.DataContext as StarWarsViewModel;

             HttpResponseMessage response = await client.GetAsync("api/films/");
             Movie movie = await response.Content.ReadAsAsync<Movie>();
             context.Teste = movie.Director;

             if (response.IsSuccessStatusCode)
             {
                 Movie movie = await response.Content.ReadAsAsync<Movie>();
                 context.Teste = movie.Director;
             }
             else
             {
                 context.Teste = "ERRO";
             }
         }*/

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
                        DeserializeCharacter(context);
                        DeserializePlanet(context);
                        DeserializeSpecie(context);
                        DeserializeStarship(context);
                        DeserializeVehicle(context);

                    }
                }
            }
        }

        private async void DeserializePlanet(StarWarsViewModel context)
        {
            foreach (Movie movie in context.Movies)
            {
                movie.Planets = new Planet[movie.PlanetsUrl.Length + 1];
                for (int i = 0; i < movie.PlanetsUrl.Length; i++)
                {
                    string URI = movie.PlanetsUrl[i];
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
                                    movie.Planets[i] = planet;
                                }
                            }
                        }
                    }
                }
                context.Planets = movie.Planets;
            }
        }

        private async void DeserializeVehicle(StarWarsViewModel context)
        {
            foreach (Movie movie in context.Movies)
            {
                movie.Vehicles = new Vehicle[movie.VehiclesUrl.Length + 1];
                for (int i = 0; i < movie.VehiclesUrl.Length; i++)
                {
                    string URI = movie.VehiclesUrl[i];
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
                                    movie.Vehicles[i] = vehicle;
                                }
                            }
                        }
                    }
                }
                context.Vehicles = movie.Vehicles;
            }
        }

        private async void DeserializeSpecie(StarWarsViewModel context)
        {
            foreach (Movie movie in context.Movies)
            {
                movie.Species = new Specie[movie.CharactersUrl.Length + 1];
                for (int i = 0; i < movie.CharactersUrl.Length; i++)
                {
                    string URI = movie.CharactersUrl[i];
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
                                    movie.Species[i] = specie;
                                }
                            }
                        }
                    }
                }
                context.Species = movie.Species;
            }
        }

        private async void DeserializeStarship(StarWarsViewModel context)
        {
            foreach (Movie movie in context.Movies)
            {
                movie.Starships = new Starship[movie.StarshipsUrl.Length + 1];
                for (int i = 0; i < movie.StarshipsUrl.Length; i++)
                {
                    string URI = movie.StarshipsUrl[i];
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
                                    movie.Starships[i] = starship;
                                }
                            }
                        }
                    }
                }
                context.Starships = movie.Starships;
            }
        }

        private async void DeserializeCharacter(StarWarsViewModel context)
        {
            foreach (Movie movie in context.Movies)
            {
                movie.Characters = new Character[movie.CharactersUrl.Length + 1];
                for (int i = 0; i < movie.CharactersUrl.Length; i++)
                {
                    string URI = movie.CharactersUrl[i];
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
                                    movie.Characters[i] = character;
                                }
                            }
                        }
                    }
                }
                context.Characters = movie.Characters;
            }
        }
    }
}
