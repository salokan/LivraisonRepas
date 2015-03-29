using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Data.Json;
using LivraisonRepas.Models;

namespace LivraisonRepas.Webservices
{
    public class CommandesCad
    {
        private AppelsRest _service = new AppelsRest();

        public async Task<List<Commandes>> GetCommandes()
        {
            string response = await _service.GetMethodWithoutParameter("Commandes");

            JsonObject jsonObject = JsonObject.Parse(response);

            List<Commandes> commandes = new List<Commandes>();

            foreach (IJsonValue jsonValue in jsonObject.GetNamedArray("CommandesListe"))
            {
                if (jsonValue.ValueType == JsonValueType.Object)
                {
                    commandes.Add(new Commandes(jsonValue.GetObject()));
                }
            }

            return commandes;
        }

        public async Task<Commandes> GetCommandes(int id)
        {
            string response = await _service.GetMethod("Commande", id.ToString());

            JsonObject jsonObject = JsonObject.Parse(response);

            Commandes commandes = new Commandes(jsonObject);

            return commandes;
        }

        public void AddCommandes(Commandes c)
        {
            string json;

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Commandes));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, c);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            json = sr.ReadToEnd();

            _service.PostMethod("Commande", json);
        }

        public void DeleteCommandes(int id)
        {
            _service.DeleteMethod("Commande", id.ToString());
        }

        public void UpdateCommandes(Commandes c)
        {
            string json;

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Commandes));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, c);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            json = sr.ReadToEnd();

            _service.PutMethod("Commande", json, "none");
        }
    }
}
