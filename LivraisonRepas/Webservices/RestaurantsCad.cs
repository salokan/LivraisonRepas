using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Data.Json;
using LivraisonRepas.Models;

namespace LivraisonRepas.Webservices
{
    public class RestaurantsCad
    {
        private AppelsRest _service = new AppelsRest();

        public async Task<List<Restaurants>> GetRestaurants()
        {
            string response = await _service.GetMethodWithoutParameter("Restaurants");

            JsonObject jsonObject = JsonObject.Parse(response);

            List<Restaurants> restaurants = new List<Restaurants>();

            foreach (IJsonValue jsonValue in jsonObject.GetNamedArray("RestaurantsListe"))
            {
                if (jsonValue.ValueType == JsonValueType.Object)
                {
                    restaurants.Add(new Restaurants(jsonValue.GetObject()));
                }
            }

            return restaurants;
        }

        public async Task<Restaurants> GetRestaurants(int id)
        {
            string response = await _service.GetMethod("Restaurant", id.ToString());

            JsonObject jsonObject = JsonObject.Parse(response);

            Restaurants restaurants = new Restaurants(jsonObject);

            return restaurants;
        }

        public void AddRestaurants(Restaurants r)
        {
            string json;

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Restaurants));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, r);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            json = sr.ReadToEnd();

            _service.PostMethod("Restaurant", json);
        }

        public void DeleteRestaurants(int id)
        {
            _service.DeleteMethod("Restaurant", id.ToString());
        }

        public void UpdateRestaurants(Restaurants r)
        {
            string json;

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Restaurants));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, r);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            json = sr.ReadToEnd();

            _service.PutMethod("Restaurant", json, "none");
        }
    }
}
