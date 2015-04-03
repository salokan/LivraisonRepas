using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Data.Json;
using LivraisonRepas.Models;

namespace LivraisonRepas.Webservices
{
    public class MenuRestaurantCad
    {
        private AppelsRest _service = new AppelsRest();

        public async Task<List<MenuRestaurant>> GetMenuRestaurant()
        {
            string response = await _service.GetMethodWithoutParameter("MenuRestaurant");

            JsonObject jsonObject = JsonObject.Parse(response);

            List<MenuRestaurant> menuRestaurant = new List<MenuRestaurant>();

            foreach (IJsonValue jsonValue in jsonObject.GetNamedArray("MenuRestaurantListe"))
            {
                if (jsonValue.ValueType == JsonValueType.Object)
                {
                    menuRestaurant.Add(new MenuRestaurant(jsonValue.GetObject()));
                }
            }

            return menuRestaurant;
        }

        public async Task<MenuRestaurant> GetMenuRestaurant(int id)
        {
            string response = await _service.GetMethod("MenuRestaurant", id.ToString());

            JsonObject jsonObject = JsonObject.Parse(response);

            MenuRestaurant menuRestaurant = new MenuRestaurant(jsonObject);

            return menuRestaurant;
        }

        public void AddMenuRestaurant(MenuRestaurant mr)
        {
            string json;

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(MenuRestaurant));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, mr);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            json = sr.ReadToEnd();

            _service.PostMethod("MenuRestaurant", json);
        }

        public void DeleteMenuRestaurant(int id)
        {
            _service.DeleteMethod("MenuRestaurant", id.ToString());
        }

        public void UpdateMenuRestaurant(MenuRestaurant mr)
        {
            string json;

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(MenuRestaurant));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, mr);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            json = sr.ReadToEnd();

            _service.PutMethod("MenuRestaurant", json, "none");
        }
    }
}
