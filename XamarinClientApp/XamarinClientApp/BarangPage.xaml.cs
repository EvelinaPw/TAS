﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using XamarinClientApp.ViewModels;
using XamarinClientApp.Models;

namespace XamarinClientApp
{
    public partial class BarangPage : ContentPage
    {
        public BarangPage()
        {
            InitializeComponent();
            listBarang.ItemTapped += ListBarang_ItemTapped;
            btnTambah.Clicked += BtnTambah_Clicked;
            btnSearch.Clicked += BtnSearch_Clicked;
        }
        protected override void OnAppearing()
        {
            this.BindingContext = new BarangViewModels();
        }

        private void ListBarang_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Barang item = (Barang)e.Item;
            EditBarangPage editPage = new EditBarangPage();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }

        private async void BtnTambah_Clicked (object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new TambahBarangPage());
        }

        private async void BtnSearch_Clicked(object sender, EventArgs e)
        {

        }
    }
}
