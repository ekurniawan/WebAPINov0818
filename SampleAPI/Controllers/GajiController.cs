using SampleAPI.DAL;
using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleAPI.Controllers
{
    public class GajiController : ApiController
    {
        private GajiDAL gajiDAL;

        public GajiController()
        {
            gajiDAL = new GajiDAL();
        }
        // GET: api/Gaji
        public IEnumerable<Gaji> Get()
        {
            return gajiDAL.GetAll();
        }

        // GET: api/Gaji/5
        public Gaji Get(string id)
        {
            return gajiDAL.GetById(id);
        }

        public IEnumerable<Gaji> Get(decimal jumlah)
        {
            return gajiDAL.GetByJumlah(jumlah);
        }

        // POST: api/Gaji
        public IHttpActionResult Post(Gaji gaji)
        {
            try
            {
                gajiDAL.Insert(gaji);
                return Ok($"Data Rekening {gaji.Norek} berhasil ditambah");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // PUT: api/Gaji/5
        public IHttpActionResult Put(Gaji gaji)
        {
            try
            {
                gajiDAL.Update(gaji);
                return Ok($"Data Rekening {gaji.Norek} berhasil di update");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // DELETE: api/Gaji/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                gajiDAL.Delete(id);
                return Ok($"Data berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
    }
}
