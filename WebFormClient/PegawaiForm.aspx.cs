using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    }
}