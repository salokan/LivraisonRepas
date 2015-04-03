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
        private Menus _menuSelected;

        public Client()
        {
            InitializeComponent();
            _service = new Services();
            _userConnected = ((App)(Application.Current)).UserConnected;
            InitalizeCombobox();
        }

        private async void InitalizeCombobox()
        {
            ListRestaurants = new List<Restaurants>();
            ListMenus = new List<Menus>();
            ListRestaurants = await _service.Restaurants.GetRestaurants();
            ListMenus = await _service.Menus.GetMenus();
            foreach (Restaurants restos in ListRestaurants)
            {
                RestaurantBox.Items.Add(restos);
            }
        }

        private async void AjouterPanierClick(object sender, RoutedEventArgs e)
        {
            string prixTotal;
            Menus _menuSelected = (Menus)MenuBox.SelectedItem;
            if (_menuSelected != null)
            {
                ListViewPanier.Items.Add(_menuSelected);
                PrixTotal.Text = _menuSelected.Prix.ToString();
            }
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
            MenuBox.Items.Clear();
            Restaurants restoItem = (Restaurants)RestaurantBox.SelectedItem;
            MenuRestaurant menuResto = await _service.MenusRestaurant.GetMenuRestaurant(restoItem.IdRestaurants);
            
            foreach (Menus menu in ListMenus)
            {
                if (menu.IdRestaurant == restoItem.IdRestaurants)
                {
                    MenuBox.Items.Add(menu);
                }
            }
        }
    }
}
