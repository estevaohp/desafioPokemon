namespace DesafioPokemon.Models
{
    public class HomeModel
    {
        public double Temperatura { get; set; }
        public string EstaChovendo { get; set; }
        public string NomePokemon { get; set; }
        public string Cidade { get; set; }  

        public class JSONClima
        {
            public Coord coord { get; set; }
            public Weather[] weather { get; set; }
            public string _base { get; set; }
            public Main main { get; set; }
            public int visibility { get; set; }
            public Wind wind { get; set; }
            public Rain rain { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public Sys sys { get; set; }
            public int timezone { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }
        }

        public class Coord
        {
            public float lon { get; set; }
            public float lat { get; set; }
        }

        public class Main
        {
            public float temp { get; set; }
            public float feels_like { get; set; }
            public float temp_min { get; set; }
            public float temp_max { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
        }

        public class Wind
        {
            public float speed { get; set; }
            public int deg { get; set; }
        }

        public class Rain
        {
            public float _1h { get; set; }
        }

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Sys
        {
            public int type { get; set; }
            public int id { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class JSONPokemon
        {
            public Damage_Relations damage_relations { get; set; }
            public Game_Indices[] game_indices { get; set; }
            public Generation generation { get; set; }
            public int id { get; set; }
            public Move_Damage_Class move_damage_class { get; set; }
            public Move[] moves { get; set; }
            public string name { get; set; }
            public Name[] names { get; set; }
            public object[] past_damage_relations { get; set; }
            public Pokemon[] pokemon { get; set; }
        }

        public class Damage_Relations
        {
            public Double_Damage_From[] double_damage_from { get; set; }
            public Double_Damage_To[] double_damage_to { get; set; }
            public Half_Damage_From[] half_damage_from { get; set; }
            public Half_Damage_To[] half_damage_to { get; set; }
            public object[] no_damage_from { get; set; }
            public No_Damage_To[] no_damage_to { get; set; }
        }

        public class Double_Damage_From
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Double_Damage_To
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Half_Damage_From
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Half_Damage_To
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class No_Damage_To
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Generation
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Move_Damage_Class
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Game_Indices
        {
            public int game_index { get; set; }
            public Generation1 generation { get; set; }
        }

        public class Generation1
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Move
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Name
        {
            public Language language { get; set; }
            public string name { get; set; }
        }

        public class Language
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Pokemon
        {
            public Pokemon1 pokemon { get; set; }
            public int slot { get; set; }
        }

        public class Pokemon1
        {
            public string name { get; set; }
            public string url { get; set; }
        }
    }
}