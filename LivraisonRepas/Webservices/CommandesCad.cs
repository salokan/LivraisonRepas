using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LivraisonRepas.LivraisonRepasCommandesServiceReference;

namespace LivraisonRepas.Webservices
{
    public class CommandesCad
    {
        LivraisonRepasCommandesServiceClient _client;

        public CommandesCad(LivraisonRepasCommandesServiceClient client)
        {
            _client = client;
        }

        public async Task<List<Commandes>> GetCommandes()
        {
            ObservableCollection<CommandesComposite> commandesList;
            List<Commandes> commandes = new List<Commandes>();

            commandesList = await _client.GetCommandesAsync();

            foreach (CommandesComposite c in commandesList)
            {
                Commandes commande = new Commandes();
                commande.Id = c.IdCommandesValue;
                commande.Id_Client = c.IdClientsValue;
                commande.Id_Livreur = c.IdLivreursValue;
                commande.Contenu = c.ContenuValue;
                commande.Etat = c.EtatValue;

                commandes.Add(commande);
            }

            return commandes;
        }

        public async Task<Commandes> GetCommandes(int id)
        {
            Commandes commande = new Commandes();

            CommandesComposite commandesComposite = await _client.GetCommandeAsync(id);

            commande.Id = commandesComposite.IdCommandesValue;
            commande.Id_Client = commandesComposite.IdClientsValue;
            commande.Id_Livreur = commandesComposite.IdLivreursValue;
            commande.Contenu = commandesComposite.ContenuValue;
            commande.Etat = commandesComposite.EtatValue;

            return commande;
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
