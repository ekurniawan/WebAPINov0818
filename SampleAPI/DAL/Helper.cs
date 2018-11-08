using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace SampleAPI.DAL
{
    public class Helper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager
                .ConnectionStrings["Default"].ConnectionString;
        }
    }
}