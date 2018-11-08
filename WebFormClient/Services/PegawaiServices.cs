using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using WebFormClient.Models;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebFormClient.Services
{
    public class PegawaiServices
    {
        private const string API_URL = "http://brilabs.azurewebsites.net";
        private HttpClient _client;
        public PegawaiServices()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(API_URL);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Pegawai>> GetAll()
        {
            List<Pegawai> lstPegawai = new List<Pegawai>();
            var response = await _client.GetAsync("api/Pegawai");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                lstPegawai = JsonConvert.DeserializeObject<List<Pegawai>>(content);
            }
            return lstPegawai;
        }


    }
}