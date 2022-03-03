using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectEcommerce.Models
{
    public class Connection
    {
        protected SqlConnection connection;
        public void Connect()
        {
            string sqlconnectStr = @"Data Source=DESKTOP-ECMGDNK\SQLEXPRESS;Initial Catalog=Ecommerce;integrated security=True";
            connection = new SqlConnection(sqlconnectStr);
             
        }
    }
}