using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleAPI.Controllers
{
    /// <summary>
    /// Controller untuk setup nama
    /// </summary>
    public class ValuesController : ApiController
    {
        private static List<string> arrNama = new List<string>
        {
            "Erick", "Bambang","Budi","Joko","Amir"
        };

        /// <summary>
        /// Mengembalikan semua data nama
        /// </summary>
        public IEnumerable<string> Get()
        {
            return arrNama;
        }

        /// <summary>
        /// Menampilkan nama berdasarkan pencarian parameter nama
        /// </summary>
        /// <param name="nama">masukan nama yang dicari</param>
        /// <returns>Collection dari nama</returns>
        public IEnumerable<string> Get(string nama)
        {
            var results = from n in arrNama
                          where n.ToLower().Contains(nama.ToLower())
                          select n;

            return results;
        }

        /// <summary>
        /// Menampilkan nama berdasarkan id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        public string Get(int id)
        {
            var data = arrNama[id];
            return data;
        }


        // POST api/values
        public IHttpActionResult Post([FromBody]string value)
        {
            arrNama.Add(value);
            return Ok($"Data berhasil ditambahkan {value}");
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
