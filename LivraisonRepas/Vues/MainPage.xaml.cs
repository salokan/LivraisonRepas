using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using LivraisonRepas.LivraisonRepasUtilisateursServiceReference;
using LivraisonRepas.Webservices;

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
                MessageDialog msgDialog = new MessageDialog("Bravo", "Félicitation");
                ((App)(App.Current)).UserConnected = utilisateur;
                await msgDialog.ShowAsync();
                Frame.Navigate(typeof(Client));
            }
        }

        private void InscriptionClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (Identification));
        }
    }
}
