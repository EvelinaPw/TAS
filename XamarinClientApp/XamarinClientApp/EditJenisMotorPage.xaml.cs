using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinClientApp.Models;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;


namespace XamarinClientApp
{
    public partial class EditJenisMotorPage : ContentPage
    {
        public EditJenisMotorPage()
        {
            InitializeComponent();

            btnEdit.Clicked += BtnEdit_Clicked;
            btnDelete.Clicked += BtnDelete_Clicked;

        }
        private RestClient _client =
            new RestClient("http://inventoryelin.azurewebsites.net/");

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/JenisMotor/{id}", Method.DELETE);

            _request.AddParameter("id", txtIdJenisMotor.Text);
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
                await DisplayAlert("Error ", "Error : " + ex.Message, "OK");

            }
        }
        private async void BtnEdit_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/JenisMotor", Method.PUT);
            var newJenisMotor = new JenisMotor
            {
                IdJenisMotor = Convert.ToInt32(txtIdJenisMotor.Text),
                NamaJenisMotor = txtNamaJenisMotor.Text
            };
            _request.AddBody(newJenisMotor);
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
                await DisplayActionSheet("Error ", "Error : " + ex.Message, "OK");
            }

        }
    }
}
