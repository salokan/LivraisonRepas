using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LivraisonRepas.LivraisonRepasServiceReference;

namespace LivraisonRepas.Webservices
{
    public class CommandesCad
    {
        LivraisonRepasServiceClient _client;

        public CommandesCad(LivraisonRepasServiceClient client)
        {
            _client = client;
        }

        public async Task<ObservableCollection<Commandes>> GetCommandes()
        {
            return await _client.GetCommandesAsync();
        }

        public async Task<Commandes> GetCommandes(int id)
        {
            return await _client.GetCommandeAsync(id);
        }

        public async void AddCommandes(Commandes u)
        {
            await _client.AddCommandesAsync(u);
        }

        public async void DeleteCommandes(int id)
        {
            await _client.DeleteCommandesAsync(id);
        }

        public async void UpdateCommandes(Commandes u)
        {
            await _client.UpdateCommandesAsync(u);
        }
    }
}
