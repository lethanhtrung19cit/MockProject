using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEcommerce.Models.DAO
{
    public class AccountModel : Connection
    {
        public int checkLogin(string Email, string PassWord)
        {
            Connect();
            connection.Open();
             
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select PassWord from Account where Email='"+Email+"'";

                var reader = command.ExecuteScalar();
                if (reader!=null)
                {
                    if (reader.ToString() == PassWord) return 1;

                }    
                else
                {
                    return 0;
                }    
            }

            connection.Close();
            return 0;
        }
        public string NameCu(string Email)
        {
            Connect();
            string nameCus = null;

            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select NameCus from Customer where Email='"+Email+"'";

                var reader = command.ExecuteScalar();
                nameCus = reader.ToString();
                
            }

            connection.Close();
            return nameCus;
        }
        public string IdCus(string Email)
        {
            Connect();
            string IdCus = null;

            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select IdCus from Customer where Email='"+Email+"'";

                var reader = command.ExecuteScalar();
                IdCus = reader.ToString();
                
            }

            connection.Close();
            return IdCus;
        }
    }
}