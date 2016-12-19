using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using RestSharp;
using XamarinClientApp.Models;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;

namespace XamarinClientApp
{
    public partial class TambahBarangPage : ContentPage
    {
        public TambahBarangPage()
        {
            InitializeComponent();
            btnTambahBarang.Clicked += BtnTambahBarang_Clicked;
        }
        private RestClient _client =
            new RestClient("http://inventoryelin.azurewebsites.net/");

        private async void BtnTambahBarang_Clicked(object sender, EventArgs e)

        {
            var _request = new RestRequest("api/Barang", Method.POST);
            var newBarang = new Barang
            {
                KodeBarang = Convert.ToInt32(txtKodeBarang.Text),
                Nama = txtNamaBarang.Text,
                IdJenisMotor = Convert.ToInt32(txtIdJenisMotor.Text),
                KategoriId = Convert.ToInt32(txtKategoriId.Text),
                HargaBeli = Convert.ToInt32(txtHargaBeli.Text),
                HargaJual = Convert.ToInt32(txtHargaBeli.Text),
                Stok = Convert.ToInt32(txtStok.Text),
                TanggalBeli = Convert.ToDateTime(txtTanggalBeli.Text)
            };
            _request.AddBody(newBarang);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PushAsync(new BarangPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }
    }
}
