using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using LivraisonRepas.Models;
using LivraisonRepas.Webservices;
using System.Collections.Generic;

namespace LivraisonRepas.Vues
{
    public sealed partial class Client
    {
        private Utilisateurs _userConnected;
        private Services _service;
        private List<Restaurants> ListRestaurants;
        private List<Menus> ListMenus;
        private MenuRestaurant _menuResto;
        private Menus _menuSelected;
        private string RestaurantEnCours;
        private string MenusEnCours;

        public Client()
        {
            _service = new Services();
            InitalizeCombobox();
            InitializeComponent();
        }

        private async void InitalizeCombobox()
        {
            _userConnected = ((App)(Application.Current)).UserConnected;
            MessageDialog msgDialog = new MessageDialog("Bienvenue " + _userConnected.Pseudo, "Attention");
            await msgDialog.ShowAsync();
            ListRestaurants = new List<Restaurants>();
            ListRestaurants = await _service.Restaurants.GetRestaurants();
        }

        private async void AjouterPanierClick(object sender, RoutedEventArgs e)
        {
            if (ListViewPanier.Items != null) ListViewPanier.Items.Add(_menuSelected);
        }

        private async void ValiderClick(object sender, RoutedEventArgs e)
        {
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _userConnected = ((App)(Application.Current)).UserConnected;
            username.Text = _userConnected.Pseudo;
        }

        private async void RestaurantBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListMenus = new List<Menus>();
            RestaurantEnCours = RestaurantBox.SelectedValue.ToString();
            _menuResto = await _service.MenusRestaurant.GetMenuRestaurant(int.Parse(RestaurantEnCours));
            ListMenus = await _service.Menus.GetMenus();
            foreach (Menus menu in ListMenus)
            {
                if (menu.IdMenus == _menuResto.IdMenu)
                {
                    _menuSelected = menu;
                }
            }
            MenuResto.Text = _menuSelected.NomMenus;
        }
    }
}
