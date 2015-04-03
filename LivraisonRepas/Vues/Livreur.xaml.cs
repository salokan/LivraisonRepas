using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using LivraisonRepas.Models;
using LivraisonRepas.Webservices;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

namespace LivraisonRepas.Vues
{
    public sealed partial class Livreur
    {
        private Utilisateurs _userConnected;
        private Services _service;
        private List<Commandes> ListCommandes;
        private List<Commandes> ListCommandesLivreur;
        private Commandes CommandeSelected;
        private Utilisateurs ClientCommande;
        private string CommandEnCours;
        private double Latitude;
        private double Longitude;
        public Livreur()
        {
            _service = new Services();
            Init();
            InitializeComponent();
        }

        private async void Init()
        {
            _userConnected = ((App)(Application.Current)).UserConnected;
            MessageDialog msgDialog = new MessageDialog("Bienvenue " + _userConnected.Pseudo, "Attention");
            await msgDialog.ShowAsync();
            ListCommandes = new List<Commandes>();
            ListCommandesLivreur = new List<Commandes>();
            ListCommandes = await _service.Commandes.GetCommandes();
            foreach (Commandes commande in ListCommandes)
            {
                if (commande.IdLivreurs == _userConnected.IdUtilisateurs && commande.Etat.Equals("Non livré"))
                {
                    ListCommandesLivreur.Add(commande);
                }
            }
        }

        private async void ComboBox_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            CommandEnCours = CommandeBox.SelectedValue.ToString();
            foreach (Commandes commande in ListCommandes)
            {
                if (commande.IdCommandes == int.Parse(CommandEnCours))
                {
                    CommandeSelected = commande;
                }
            }
            ClientCommande = await _service.Utilisateurs.GetUtilisateur(CommandeSelected.IdClients);
            AdresseLivraison.Text = ClientCommande.Adresse;
            EtatLivraison.Text = CommandeSelected.Etat;
            CommandePrix.Text = CommandeSelected.Prix.ToString();

            string BingMapsKey = "AuYeRnpqm1vyzkRFey2o4jXKWwYGdJGAPF7FrTA4d0w8w_vCF2z1NT9oT6BsVvog";

            Uri geocodeRequest = new Uri(
                string.Format("http://dev.virtualearth.net/REST/v1/Locations?q={0}&key={1}",
                ClientCommande.Adresse, BingMapsKey));

            Response r = await GetResponse(geocodeRequest);

            foreach (Location l in r.ResourceSets[0].Resources)
            {
                Latitude = l.Point.Coordinates[0];
                Longitude = l.Point.Coordinates[1];
            }

        }

        private async Task<Response> GetResponse(Uri uri)
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            var response = await client.GetAsync(uri);

            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response));
                return ser.ReadObject(stream) as Response;
            }
        } 

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
