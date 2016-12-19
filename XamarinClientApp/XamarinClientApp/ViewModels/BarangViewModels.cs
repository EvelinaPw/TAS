using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinClientApp.Models;

using RestSharp;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;


namespace XamarinClientApp.ViewModels
{
    public class BarangViewModels : BindableObject
    {
        private RestClient _client =
            new RestClient("http://inventoryelin.azurewebsites.net/");
        private ObservableCollection<Barang> listBarang;
        public ObservableCollection<Barang> ListBarang
        {
            get { return listBarang;  }
            set { listBarang = value; OnPropertyChanged("ListBarang"); }
        }
        private async void RefreshDataAsync()
        {
            RestRequest _request = new RestRequest("api/Barang", Method.GET);
            var _response = await _client.Execute<List<Barang>>(_request);
            ListBarang = new ObservableCollection<Barang>(_response.Data);
        }
        public BarangViewModels()
        {
            RefreshDataAsync();
        }
    }
}
