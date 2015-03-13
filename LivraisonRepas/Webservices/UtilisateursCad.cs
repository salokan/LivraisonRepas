using System.Collections.Generic;
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

        public async Task<List<Utilisateurs>> GetUtilisateurs()
        {
            ObservableCollection<UtilisateursComposite> utilisateursList;
            List<Utilisateurs> utilisateurs = new List<Utilisateurs>();

            utilisateursList = await _client.GetUtilisateursAsync();

            foreach (UtilisateursComposite u in utilisateursList)
            {
                Utilisateurs utilisateur = new Utilisateurs();
                utilisateur.Id = u.IdUtilisateursValue;
                utilisateur.Pseudo = u.PseudoValue;
                utilisateur.Password = u.PasswordValue;
                utilisateur.Adresse = u.AdresseValue;
                utilisateur.Type = u.TypeValue;

                utilisateurs.Add(utilisateur);
            }

            return utilisateurs;
        }

        public async Task<Utilisateurs> GetUtilisateur(int id)
        {
            Utilisateurs utilisateurs = new Utilisateurs();

            UtilisateursComposite utilisateursComposite = await _client.GetUtilisateurAsync(id);

            utilisateurs.Id = utilisateursComposite.IdUtilisateursValue;
            utilisateurs.Pseudo = utilisateursComposite.PseudoValue;
            utilisateurs.Password = utilisateursComposite.PasswordValue;
            utilisateurs.Adresse = utilisateursComposite.AdresseValue;
            utilisateurs.Type = utilisateursComposite.TypeValue;

            return utilisateurs;
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
            Utilisateurs utilisateurs = new Utilisateurs();

            UtilisateursComposite utilisateursComposite = await _client.AuthentificationUtilisateurAsync(pseudo,password);

            utilisateurs.Id = utilisateursComposite.IdUtilisateursValue;
            utilisateurs.Pseudo = utilisateursComposite.PseudoValue;
            utilisateurs.Password = utilisateursComposite.PasswordValue;
            utilisateurs.Adresse = utilisateursComposite.AdresseValue;
            utilisateurs.Type = utilisateursComposite.TypeValue;

            return utilisateurs;
        }
    }
}
