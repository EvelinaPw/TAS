using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XamarinClientApp.Models;
using Xamarin.Forms;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;

namespace XamarinClientApp
{
    public partial class EditBarangPage : ContentPage
    {
        public EditBarangPage()
        {
            InitializeComponent();
            btnEdit.Clicked += BtnEdit_Clicked;
            btnDelete.Clicked += BtnDelete_Clicked;
        }
        private RestClient _client=
            new RestClient("http://inventoryelin.azurewebsites.net/");

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/Barang/{id}", Method.DELETE);
            _request.AddParameter("id", txtKodeBarang.Text);
            try
            {
                var _response = await _client.Execute(_request);
                if(_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }
        private async void BtnEdit_Clicked (object sender, EventArgs e)
        {
            var _request = new RestRequest("api/Barang", Method.PUT);
            var newBarang = new Barang
            {
                KodeBarang = Convert.ToInt32(txtKodeBarang.Text),
                Nama = txtNamaBarang.Text,
                IdJenisMotor = Convert.ToInt32(txtIdJenisMotor.Text),
                KategoriId = Convert.ToInt32(txtKategoriId.Text),
                Stok = Convert.ToInt32(txtStok.Text),
                HargaBeli = Convert.ToInt32(txtHargaBeli.Text),
                HargaJual = Convert.ToInt32(txtHargaJual.Text),
                TanggalBeli = Convert.ToDateTime(txtTanggalBeli.Text)


            };
            _request.AddBody(newBarang);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayActionSheet("Error", "Error : " + ex.Message, "OK");


            }
        }
    }
    
}
