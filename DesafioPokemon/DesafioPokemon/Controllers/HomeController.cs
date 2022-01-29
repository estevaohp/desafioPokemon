using DesafioPokemon.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DesafioPokemon.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            return View(new HomeModel());
        }

        public async Task<ActionResult> PesquisarPokemonAsync(string cidade)
        {
            string jsonClima = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?q={cidade}&appid=8ed3ffcc12385a93aeebe881e2b84847");

            HomeModel.JSONClima clima = new JavaScriptSerializer().Deserialize<HomeModel.JSONClima>(jsonClima);

            double temperaturaEmGrausCelsius = clima.main.temp - 273;
            bool estaChovendo = clima.weather.FirstOrDefault().main.Contains("rain");

            string tipoPokemon = CarregarTipoPokemon(temperaturaEmGrausCelsius, estaChovendo);

            string jsonPokemon = await client.GetStringAsync($"https://pokeapi.co/api/v2/type/{tipoPokemon}");

            HomeModel.JSONPokemon pokemon = new JavaScriptSerializer().Deserialize<HomeModel.JSONPokemon>(jsonPokemon);

            Random numeroAleatorio = new Random();

            int pokemonEscolhido = numeroAleatorio.Next(0, pokemon.pokemon.Length - 1);

            HomeModel model = new HomeModel
            {
                Temperatura = temperaturaEmGrausCelsius,
                NomePokemon = pokemon.pokemon[pokemonEscolhido].pokemon.name.ToUpper(),
                Cidade = cidade
            };

            if (estaChovendo)
                model.EstaChovendo = "SIM";
            else
                model.EstaChovendo = "NÃO";

            return View("~/Views/Home/Index.cshtml", model);
        }

        private static string CarregarTipoPokemon(double temperaturaEmGrausCelsius, bool estaChovendo)
        {
            string tipoPokemon;

            if (estaChovendo)
            {
                tipoPokemon = "electric";
            }
            else if (temperaturaEmGrausCelsius < 5)
            {
                tipoPokemon = "ice";
            }
            else if (temperaturaEmGrausCelsius >= 5 && temperaturaEmGrausCelsius < 10)
            {
                tipoPokemon = "water";
            }
            else if (temperaturaEmGrausCelsius >= 12 && temperaturaEmGrausCelsius < 15)
            {
                tipoPokemon = "grass";
            }
            else if (temperaturaEmGrausCelsius >= 15 && temperaturaEmGrausCelsius < 21)
            {
                tipoPokemon = "ground";
            }
            else if (temperaturaEmGrausCelsius >= 23 && temperaturaEmGrausCelsius < 27)
            {
                tipoPokemon = "bug";
            }
            else if (temperaturaEmGrausCelsius >= 27 || temperaturaEmGrausCelsius <= 33)
            {
                tipoPokemon = "rock";
            }
            else if (temperaturaEmGrausCelsius > 33)
            {
                tipoPokemon = "fire";
            }
            else
            {
                tipoPokemon = "normal";
            }

            return tipoPokemon;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Desafio Pokemon - Online Applications";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}