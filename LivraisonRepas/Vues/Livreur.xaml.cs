using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using LivraisonRepas.Models;

namespace LivraisonRepas.Vues
{
    public sealed partial class Livreur
    {
        private Utilisateurs _userConnected;
        public Livreur()
        {
            InitializeComponent();

            Init();
        }

        private async void Init()
        {
            _userConnected = ((App)(Application.Current)).UserConnected;
            MessageDialog msgDialog = new MessageDialog("Bienvenue " + _userConnected.Pseudo, "Attention");
            await msgDialog.ShowAsync();
        }
    }
}
