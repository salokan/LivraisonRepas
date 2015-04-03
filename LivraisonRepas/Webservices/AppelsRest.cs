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
            InitUrl();
        }

        public void InitUrl ()
        {
            _url = "http://localhost:1234/LivraisonRepas/";
        }

        public async Task<string> GetMethod(string table, string parametre)
        {
            InitUrl();

            _url = _url + table + "/" + parametre;

            HttpBaseProtocolFilter rootFilter = new HttpBaseProtocolFilter();
            rootFilter.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;
            rootFilter.CacheControl.WriteBehavior = HttpCacheWriteBehavior.NoCache;
            HttpClient httpClient = new HttpClient(rootFilter);

            var headers = httpClient.DefaultRequestHeaders;

            headers.UserAgent.ParseAdd("ie");
            headers.UserAgent.ParseAdd("Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");

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
                HttpResponseMessage response = await httpClient.GetAsync(resourceUri);

                response.EnsureSuccessStatusCode();

                responseBodyAsText = await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                responseBodyAsText = "";
            }
            string reponse = responseBodyAsText;

            return reponse;
        }

        public async Task<string> GetMethodWithoutParameter(string table)
        {
            InitUrl();

            _url = _url + table;

            HttpBaseProtocolFilter rootFilter = new HttpBaseProtocolFilter();
            rootFilter.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;
            rootFilter.CacheControl.WriteBehavior = HttpCacheWriteBehavior.NoCache;
            HttpClient httpClient = new HttpClient(rootFilter);

            var headers = httpClient.DefaultRequestHeaders;

            headers.UserAgent.ParseAdd("ie");
            headers.UserAgent.ParseAdd("Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");

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
                HttpResponseMessage response = await httpClient.GetAsync(resourceUri);

                response.EnsureSuccessStatusCode();

                responseBodyAsText = await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                responseBodyAsText = "";
            }
            string reponse = responseBodyAsText;

            return reponse;
        }

        public async void PostMethod(string table, string json)
        {
            InitUrl();

            _url = _url + table + "/Create";

            HttpClient httpClient = new HttpClient();
            HttpRequestMessage msg = new HttpRequestMessage(new HttpMethod("POST"), new Uri(_url));
            msg.Content = new HttpStringContent(json);
            msg.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("application/json");
            await httpClient.SendRequestAsync(msg).AsTask();
        }

        public async void PutMethod(string table, string json, string parametre)
        {
            InitUrl();

            _url = _url + table + "/Update/" + parametre;

            HttpClient httpClient = new HttpClient();
            HttpRequestMessage msg = new HttpRequestMessage(new HttpMethod("PUT"), new Uri(_url));
            msg.Content = new HttpStringContent(json);
            msg.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("application/json");
            await httpClient.SendRequestAsync(msg).AsTask();
        }

        public async void DeleteMethod(string table, string parametre)
        {
            InitUrl();

            _url = _url + table + "/Delete";
            HttpClient httpClient = new HttpClient();
            await httpClient.DeleteAsync(new Uri(String.Format("{0}/{1}", _url, parametre)));
        }
    }
}
