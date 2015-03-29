using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using Windows.Web.Http.Headers;
using LivraisonRepas.LivraisonRepasUtilisateursServiceReference;
using LivraisonRepas.Webservices;
using HttpClient = Windows.Web.Http.HttpClient;
using HttpMethod = Windows.Web.Http.HttpMethod;
using HttpRequestMessage = Windows.Web.Http.HttpRequestMessage;
using HttpResponseMessage = Windows.Web.Http.HttpResponseMessage;


namespace LivraisonRepas.Vues
{
    public sealed partial class MainPage
    {
        private Services _service;
        public MainPage()
        {
            InitializeComponent();
            _service = new Services();
        }

        private async void ConnexionClick(object sender, RoutedEventArgs e)
        {
            Utilisateurs utilisateur = await _service._utilisateurs.AuthentificationUtilisateur(Pseudo.Text, Password.Password);

            if (utilisateur.Id == 0)
            {
                MessageDialog msgDialog = new MessageDialog("Le pseudo ou le mot de passe est incorrect", "Attention");
                await msgDialog.ShowAsync();
            }
            else
            {
                ((App)(Application.Current)).UserConnected = utilisateur;
                if (utilisateur.Type.Equals("livreur"))
                {
                    Frame.Navigate(typeof(Livreur), utilisateur);
                }
                else if (utilisateur.Type.Equals("client"))
                {
                    Frame.Navigate(typeof(Client), utilisateur);
                }
                else
                {
                    MessageDialog msgDialog = new MessageDialog("Il y a un problème concernant le type de l'utilisateur!", "Erreur");
                    await msgDialog.ShowAsync();
                }    
            }
        }

        private void InscriptionClick(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof (Enregistrement));
            GetMethod();
            //PostMethod();
            //PutMethod();
            //DeleteMethod();
        }

        public async void GetMethod()
        {
            HttpClient _httpClient;
            HttpResponseMessage _response;

            HttpBaseProtocolFilter rootFilter = new HttpBaseProtocolFilter();
            rootFilter.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;
            rootFilter.CacheControl.WriteBehavior = HttpCacheWriteBehavior.NoCache;
            _httpClient = new HttpClient(rootFilter);

            var headers = _httpClient.DefaultRequestHeaders;

            headers.UserAgent.ParseAdd("ie");
            headers.UserAgent.ParseAdd("Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");


            string adresse = "http://localhost:1234/LivraisonRepas/Test/coucou/coucou2";

            string reponse;

            _response = new HttpResponseMessage();

            Uri resourceUri;
            if (!Uri.TryCreate(adresse.Trim(), UriKind.Absolute, out resourceUri))
            {
            }
            if (resourceUri.Scheme != "http" && resourceUri.Scheme != "https")
            {
            }

            string responseBodyAsText;

            try
            {
                _response = await _httpClient.GetAsync(resourceUri);

                _response.EnsureSuccessStatusCode();

                responseBodyAsText = await _response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                responseBodyAsText = "";
            }
            reponse = responseBodyAsText;

            MessageDialog msgDialog = new MessageDialog(reponse, "Information");
            await msgDialog.ShowAsync();
        }

        public async void PostMethod()
        {
            string json = "{\"ContenuValue\":\"contenu\",\"EtatValue\":\"etat\",\"IdClientsValue\":1,\"IdCommandesValue\":2,\"IdLivreursValue\":3}";

            string adresse = "http://localhost:1234/LivraisonRepas/Test/Create";

            HttpClient httpClient = new HttpClient();
            HttpRequestMessage msg = new HttpRequestMessage(new HttpMethod("POST"), new Uri(adresse));
            msg.Content = new HttpStringContent(json);
            msg.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.SendRequestAsync(msg).AsTask();

        }

        public async void PutMethod()
        {
            string json = "{\"Id\":1,\"Titre\":\"Titanic!!!!!!!!!!!!!\",\"Annee\":1997,\"Entrees\":20.64,\"Uri\":null}";

            string adresse = "http://localhost:1234/LivraisonRepas/Test/Update/123";

            HttpClient httpClient = new HttpClient();
            HttpRequestMessage msg = new HttpRequestMessage(new HttpMethod("PUT"), new Uri(adresse));
            msg.Content = new HttpStringContent(json);
            msg.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.SendRequestAsync(msg).AsTask();
        }

        public async void DeleteMethod()
        {
            string adresse = "http://localhost:1234/LivraisonRepas/Test/Delete";
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.DeleteAsync(new Uri(String.Format("{0}/{1}", adresse, "123")));
        }
    }
}
