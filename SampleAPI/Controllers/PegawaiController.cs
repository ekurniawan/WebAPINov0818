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
    public class PegawaiController : ApiController
    {
        private PegawaiDAL pegawaiDAL;
        public PegawaiController()
        {
            pegawaiDAL = new PegawaiDAL();
        }

        /// <summary>
        /// Return semua data Pegawai
        /// </summary>
        /// <returns>List Of Pegawai</returns>
        // GET: api/Pegawai
        public IEnumerable<Pegawai> Get()
        {
            return pegawaiDAL.GetAll();
        }

        // GET: api/Pegawai/5
        public Pegawai Get(string id)
        {
            return pegawaiDAL.GetById(id);
        }

        /*[Route("api/Pegawai/GetByName")]
        [HttpGet]
        public IEnumerable<Pegawai> GetByName(string nama)
        {
           
        }*/

        // POST: api/Pegawai
        public IHttpActionResult Post(Pegawai pegawai)
        {
            try
            {
                pegawaiDAL.Insert(pegawai);
                return Ok($"Data Pegawai dengan Nip {pegawai.Nip} berhasil ditambah");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // PUT: api/Pegawai/5
        public IHttpActionResult Put(Pegawai pegawai)
        {
            try
            {
                pegawaiDAL.Update(pegawai);
                return Ok($"Berhasil update data pegawai {pegawai.Nip}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // DELETE: api/Pegawai/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                pegawaiDAL.Delete(id);
                var custErr = new CustomError
                {
                    StatusCode = "200 OK",
                    StatusMessage = "Data berhasil ditambah"
                };
                return Ok(custErr);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }  
        }
    }
}
