using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using WebFormClient.Models;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

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

        public async Task<Pegawai> GetById(string id)
        {
            Pegawai pegawai = new Pegawai();
            var response = await _client.GetAsync($"api/Pegawai/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                pegawai = JsonConvert.DeserializeObject<Pegawai>(content);
            }
            return pegawai;
        }

        public async Task Insert(Pegawai pegawai)
        {
            var newPegawai = JsonConvert.SerializeObject(pegawai);
            var content =
                new StringContent(newPegawai, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            try
            {
                response = await _client.PostAsync("api/Pegawai",content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(Pegawai pegawai)
        {
            var updatePegawai = JsonConvert.SerializeObject(pegawai);
            var content =
                new StringContent(updatePegawai, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            try
            {
                response = await _client.PutAsync("api/Pegawai", content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CustomError> Delete(string id)
        {
            try
            {
                var response = await _client.DeleteAsync($"api/Pegawai/{id}");
                var custErr = JsonConvert
                    .DeserializeObject<CustomError>(
                    await response.Content.ReadAsStringAsync());
                return custErr;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}