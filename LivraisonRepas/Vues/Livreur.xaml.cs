using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using LivraisonRepas.Models;
using LivraisonRepas.Webservices;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Bing.Maps;

namespace LivraisonRepas.Vues
{
    public sealed partial class Livreur
    {
        private Utilisateurs _userConnected;
        private Services _service;
        private List<Commandes> ListCommandes;
        private Utilisateurs ClientCommande;
        private Commandes CommandesValidate;
        public Livreur()
        {
            InitializeComponent();
            _service = new Services();
            _userConnected = ((App)(Application.Current)).UserConnected;
            Init();
        }

        private async void Init()
        {
            CommandeBox.Items.Clear();
            AddresseLivraison.Text = "";
            CommandePrix.Text = "";
            MapLivraison.Children.Clear();
            ListCommandes = new List<Commandes>();
            ListCommandes = await _service.Commandes.GetCommandes();
            foreach (Commandes commande in ListCommandes)
            {
                if (commande.IdLivreurs == _userConnected.IdUtilisateurs && commande.Etat.Equals("Non livré"))
                {
                    CommandeBox.Items.Add(commande);
                }
            }
        }

        private async void ComboBox_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            Commandes _commandeSelected = (Commandes)CommandeBox.SelectedItem;
            if (_commandeSelected != null)
            {
                ClientCommande = await _service.Utilisateurs.GetUtilisateur(_commandeSelected.IdClients);
                AddresseLivraison.Text = ClientCommande.Adresse;
                CommandePrix.Text = _commandeSelected.Prix.ToString();

                string BingMapsKey = "AuYeRnpqm1vyzkRFey2o4jXKWwYGdJGAPF7FrTA4d0w8w_vCF2z1NT9oT6BsVvog";

                Uri geocodeRequest = new Uri(
                    string.Format("http://dev.virtualearth.net/REST/v1/Locations?q={0}&key={1}",
                    ClientCommande.Adresse, BingMapsKey));

                Response r = await GetResponse(geocodeRequest);

                if (r != null &&
                    r.ResourceSets != null &&
                    r.ResourceSets.Length > 0 &&
                    r.ResourceSets[0].Resources != null &&
                    r.ResourceSets[0].Resources.Length > 0)
                {
                    LocationCollection locations = new LocationCollection();

                    int i = 1;

                    foreach (LivraisonRepas.Models.Location l in r.ResourceSets[0].Resources)
                    {
                        Bing.Maps.Location location = new Bing.Maps.Location(l.Point.Coordinates[0], l.Point.Coordinates[1]);
                        Pushpin pin = new Pushpin()
                        {
                            Tag = l.Name,
                            Text = i.ToString()
                        };

                        i++;

                        pin.Tapped += (s, a) =>
                        {
                            var p = s as Pushpin;
                        };

                        MapLayer.SetPosition(pin, location);
                        MapLivraison.Children.Add(pin);
                        locations.Add(location);
                    }

                    MapLivraison.SetView(new LocationRect(locations));
                }
                else
                {

                    MessageDialog msgDialog = new MessageDialog("Pas de résultat", "Désolé");
                    await msgDialog.ShowAsync();
                }
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

        private async void Valider_Click(object sender, RoutedEventArgs e)
        {
            CommandesValidate =  (Commandes)CommandeBox.SelectedItem;
            if(CommandesValidate != null) {
                CommandesValidate.Etat = "Livré";
                _service.Commandes.UpdateCommandes(CommandesValidate);
                Init();
            }
        }
    }
}
