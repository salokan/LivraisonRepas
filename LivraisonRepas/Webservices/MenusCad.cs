using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Data.Json;
using LivraisonRepas.Models;

namespace LivraisonRepas.Webservices
{
    public class MenusCad
    {
        private AppelsRest _service = new AppelsRest();

        public async Task<List<Menus>> GetMenus()
        {
            string response = await _service.GetMethodWithoutParameter("Menus");

            JsonObject jsonObject = JsonObject.Parse(response);

            List<Menus> menus = new List<Menus>();

            foreach (IJsonValue jsonValue in jsonObject.GetNamedArray("MenusListe"))
            {
                if (jsonValue.ValueType == JsonValueType.Object)
                {
                    menus.Add(new Menus(jsonValue.GetObject()));
                }
            }

            return menus;
        }

        public async Task<Menus> GetMenus(int id)
        {
            string response = await _service.GetMethod("Menu", id.ToString());

            JsonObject jsonObject = JsonObject.Parse(response);

            Menus menus = new Menus(jsonObject);

            return menus;
        }

        public void AddMenus(Menus m)
        {
            string json;

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Menus));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, m);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            json = sr.ReadToEnd();

            _service.PostMethod("Menu", json);
        }

        public void DeleteMenus(int id)
        {
            _service.DeleteMethod("Menu", id.ToString());
        }

        public void UpdateMenus(Menus m)
        {
            string json;

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Menus));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, m);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            json = sr.ReadToEnd();

            _service.PutMethod("Menu", json, "none");
        }
    }
}
