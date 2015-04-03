using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Data.Json;
using LivraisonRepas.Models;

namespace LivraisonRepas.Webservices
{
    public class MenuCommandeCad
    {
        private AppelsRest _service = new AppelsRest();

        public async Task<List<MenuCommande>> GetMenuCommande()
        {
            string response = await _service.GetMethodWithoutParameter("MenuCommande");

            JsonObject jsonObject = JsonObject.Parse(response);

            List<MenuCommande> menuCommande = new List<MenuCommande>();

            foreach (IJsonValue jsonValue in jsonObject.GetNamedArray("MenuCommandeListe"))
            {
                if (jsonValue.ValueType == JsonValueType.Object)
                {
                    menuCommande.Add(new MenuCommande(jsonValue.GetObject()));
                }
            }

            return menuCommande;
        }

        public async Task<List<MenuCommande>> GetMenuCommandeByCommande(int idCommande)
        {
            string response = await _service.GetMethodWithoutParameter("MenuCommandeByCommande/" + idCommande);

            JsonObject jsonObject = JsonObject.Parse(response);

            List<MenuCommande> menuCommande = new List<MenuCommande>();

            foreach (IJsonValue jsonValue in jsonObject.GetNamedArray("MenuCommandeListe"))
            {
                if (jsonValue.ValueType == JsonValueType.Object)
                {
                    menuCommande.Add(new MenuCommande(jsonValue.GetObject()));
                }
            }

            return menuCommande;
        }

        public async Task<MenuCommande> GetMenuCommande(int id)
        {
            string response = await _service.GetMethod("MenuCommande", id.ToString());

            JsonObject jsonObject = JsonObject.Parse(response);

            MenuCommande menuCommande = new MenuCommande(jsonObject);

            return menuCommande;
        }

        public void AddMenuCommande(MenuCommande mc)
        {
            string json;

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(MenuCommande));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, mc);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            json = sr.ReadToEnd();

            _service.PostMethod("MenuCommande", json);
        }

        public void DeleteMenuCommande(int id)
        {
            _service.DeleteMethod("MenuCommande", id.ToString());
        }

        public void UpdateMenuCommande(MenuCommande mc)
        {
            string json;

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(MenuCommande));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, mc);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            json = sr.ReadToEnd();

            _service.PutMethod("MenuCommande", json, "none");
        }
    }
}
