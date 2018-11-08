using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAPI.Models
{
    public class Gaji
    {
        public int Id { get; set; }
        public string Nip { get; set; }
        public string Norek { get; set; }
        public decimal Jumlah { get; set; }
        public Pegawai Pegawai { get; set; }
    }
}