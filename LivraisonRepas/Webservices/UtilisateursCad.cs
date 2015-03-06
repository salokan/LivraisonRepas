using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LivraisonRepas.LivraisonRepasServiceReference;

namespace LivraisonRepas.Webservices
{
    public class UtilisateursCad
    {
        LivraisonRepasServiceClient _client;

        public UtilisateursCad(LivraisonRepasServiceClient client)
        {
            _client = client;
        }

        public async Task<ObservableCollection<Utilisateurs>> GetUtilisateurs()
        {
            return await _client.GetUtilisateursAsync();
        }

        public async Task<Utilisateurs> GetUtilisateur(int id)
        {
            return await _client.GetUtilisateurAsync(id);
        }

        public async void AddUtilisateurs(Utilisateurs u)
        {
            await _client.AddUtilisateursAsync(u);
        }

        public async void DeleteUtilisateurs(int id)
        {
            await _client.DeleteUtilisateursAsync(id);
        }

        public async void UpdateUtilisateurs(Utilisateurs u)
        {
            await _client.UpdateUtilisateursAsync(u);
        }

        public async Task<Utilisateurs> AuthentificationUtilisateur(string pseudo, string password)
        {
            Utilisateurs u = await _client.GetUtilisateurAsync(1);
            return u;
        }
    }
}
