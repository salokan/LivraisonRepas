using System;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using Windows.Web.Http.Headers;

namespace LivraisonRepas.Webservices
{
    public class AppelsRest
    {
        private string _url;

        public AppelsRest()
        {
            _url = "http://localhost:1234/LivraisonRepas";
        }

        public async Task<string> GetMethod(string parametre)
        {
            _url = _url + parametre;

            HttpClient _httpClient;
            HttpResponseMessage _response;

            HttpBaseProtocolFilter rootFilter = new HttpBaseProtocolFilter();
            rootFilter.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;
            rootFilter.CacheControl.WriteBehavior = HttpCacheWriteBehavior.NoCache;
            _httpClient = new HttpClient(rootFilter);

            var headers = _httpClient.DefaultRequestHeaders;

            headers.UserAgent.ParseAdd("ie");
            headers.UserAgent.ParseAdd("Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");


            string reponse;

            _response = new HttpResponseMessage();

            Uri resourceUri;
            if (!Uri.TryCreate(_url.Trim(), UriKind.Absolute, out resourceUri))
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

            return reponse;
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
