using System;
using System.Net;
using System.ServiceModel.Web;
using LivraisonRepasServices;

namespace LivraisonRepasServer
{
    public class Server
    {
        static void Main(string[] args)
        {
            LivraisonRepasService services = new LivraisonRepasService();
            WebServiceHost _serviceHost = new WebServiceHost(services, new Uri("http://localhost:1234/LivraisonRepas"));
            _serviceHost.Open();

            Console.WriteLine("Serveur démarré");

            Console.ReadKey();
            _serviceHost.Close();
        }
    }
}
