using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormClient.Models;
using WebFormClient.Services;

namespace WebFormClient
{
    public partial class PegawaiForm : System.Web.UI.Page
    {
        private PegawaiServices _services;
        public PegawaiForm()
        {
            _services = new PegawaiServices();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString();
        }
        protected async void btnGet_Click(object sender, EventArgs e)
        {
            var results = await _services.GetAll();

            foreach(var p in results)
            {
                lblPegawai.Text += "<br/>"+p.Nama + "<br/>";
            }

            gvPegawai.DataSource = results;
            gvPegawai.DataBind();
        }

        protected async void btnGetByNip_Click(object sender, EventArgs e)
        {
            var result = await _services.GetById(txtNip.Text);
            lblPegawai.Text = $"{result.Nip} - {result.Nama} - {result.Email}";
        }

        protected async void btnAdd_Click(object sender, EventArgs e)
        {
            var newPegawai = new Pegawai
            {
                Nip = txtNip.Text,
                Nama = txtNama.Text,
                Telp = txtTelp.Text,
                Email = txtEmail.Text,
                Umur = Convert.ToInt32(txtUmur.Text)
            };
            try
            {
                await _services.Insert(newPegawai);
                lblPegawai.Text = $"Tambah data {newPegawai.Nama} berhasil";
            }
            catch (Exception ex)
            {
                lblPegawai.Text = $"Error: {ex.Message}";
            }
        }
    }
}