using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using LivraisonRepas.Models;

namespace LivraisonRepas.Vues
{
    public sealed partial class Client
    {
        private Utilisateurs _userConnected;

        public Client()
        {
            InitializeComponent();
        }

        private void AjouterPanierClick(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)Menu.SelectedItem;
            if (typeItem != null)
            {
                if (typeItem.Content != null)
                {
                    string selected = typeItem.Content.ToString();
                    if (ListViewPanier.Items != null) ListViewPanier.Items.Add(selected);
                }
            }
        }

        private async void ValiderClick(object sender, RoutedEventArgs e)
        {
            _userConnected = ((App)(Application.Current)).UserConnected;
            MessageDialog msgDialog = new MessageDialog("Bienvenue " + _userConnected.Pseudo, "Attention");
            await msgDialog.ShowAsync();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _userConnected = ((App)(Application.Current)).UserConnected;
            username.Text = _userConnected.Pseudo;
        }
    }
}
