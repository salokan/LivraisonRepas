using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Windows.Data.Json;
using LivraisonRepas.Models;


namespace LivraisonRepas.Webservices
{
    public class UtilisateursCad
    {
        private AppelsRest _service = new AppelsRest();

        public async Task<List<Utilisateurs>> GetUtilisateurs()
        {
            string response = await _service.GetMethodWithoutParameter("Utilisateurs");

            JsonObject jsonObject = JsonObject.Parse(response);

            List<Utilisateurs> utilisateurs = new List<Utilisateurs>();

            foreach (IJsonValue jsonValue in jsonObject.GetNamedArray("UtilisateursListe"))
            {
                if (jsonValue.ValueType == JsonValueType.Object)
                {
                    utilisateurs.Add(new Utilisateurs(jsonValue.GetObject()));
                }
            }

            return utilisateurs;
        }

        public async Task<Utilisateurs> GetUtilisateur(int id)
        {
            string response = await _service.GetMethod("Utilisateur", id.ToString());

            JsonObject jsonObject = JsonObject.Parse(response);

            Utilisateurs utilisateur = new Utilisateurs(jsonObject);

            return utilisateur;
        }

        public void AddUtilisateurs(Utilisateurs u)
        {
            string json;

            u.IdUtilisateurs = 0;

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Utilisateurs));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, u);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            json = sr.ReadToEnd();

            _service.PostMethod("Utilisateur", json);
        }

        public void DeleteUtilisateurs(int id)
        {
            _service.DeleteMethod("Utilisateur", id.ToString());
        }

        public void UpdateUtilisateurs(Utilisateurs u)
        {
            string json;

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Utilisateurs));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, u);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            json = sr.ReadToEnd();

            _service.PutMethod("Utilisateur", json,"none");
        }

        public async Task<Utilisateurs> AuthentificationUtilisateur(string pseudo, string password)
        {
            string response = await _service.GetMethod("Utilisateur/Authentification", pseudo + "/" + password);

            JsonObject jsonObject = JsonObject.Parse(response);

            Utilisateurs utilisateur = new Utilisateurs(jsonObject);

            return utilisateur;
        }

        public async Task<bool> ExistePseudo(string pseudo)
        {
            string response = await _service.GetMethod("Utilisateur/ExistePseudo", pseudo);

            if (response.Equals("\"true\""))
                return true;
            return false;
        }
    }
}
