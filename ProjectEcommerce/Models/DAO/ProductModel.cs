using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjectEcommerce.Models.EF;

namespace ProjectEcommerce.Models
{
    public class ProductModel : Connection
    {
        
        public List<Product> listProducts() 
        {
            Connect();
            connection.Open();
            List<Product> listProducts = new List<Product>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select IdPro, CodePro, NamePro, Price, Amount, Image from Product";

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    var IdPro = reader["IdPro"].ToString();
                    var CodePro = reader["CodePro"].ToString();
                    var NamePro = reader["NamePro"].ToString();
                    var Price = reader["Price"].ToString();
                    var Amount = reader["Amount"].ToString();
                    var Image = reader["Image"].ToString();
                    Product p = new Product(int.Parse(IdPro), CodePro, NamePro, float.Parse(Price), int.Parse(Amount), Image);
                    listProducts.Add(p);
                 }
            }

            connection.Close();
            return listProducts;
        }
        public List<Product> SearchProduct(string NameProduct)
        {
            Connect();
            connection.Open();
            List<Product> listProducts = new List<Product>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select IdPro, CodePro, NamePro, Price, Amount, Image from Product where NamePro like N'%"+NameProduct+"%'";

                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    var IdPro = reader["IdPro"].ToString();
                    var CodePro = reader["CodePro"].ToString();
                    var NamePro = reader["NamePro"].ToString();
                    var Price = reader["Price"].ToString();
                    var Amount = reader["Amount"].ToString();
                    var Image = reader["Image"].ToString();
                    Product p = new Product(int.Parse(IdPro), CodePro, NamePro, float.Parse(Price), int.Parse(Amount), Image);
                    listProducts.Add(p);
                }
            }

            connection.Close();
            return listProducts;
        }
        public void addProduct(string CodePro, string NamePro, string Image, int Price, int Number)
        {
            Connect();
            connection.Open();
            using (var command = connection.CreateCommand())
            {

                command.CommandText = "Insert Into Product " +
                    "Values ('" + CodePro + "', N'" + NamePro + "', "+Price+", " + Number+", '"+Image+"')";

                var affectedRow = command.ExecuteNonQuery();

                Console.WriteLine(affectedRow); //  Output: 1
            }
            connection.Close();
        }
        public void updateProduct(int IdPro, string NamePro, float Price, int Number)
        {
            Connect();
            connection.Open();
            using (var command = connection.CreateCommand())
            {

                command.CommandText = "update Product set NamePro=N'" +NamePro+ "', Price= " + Price + ", Amount="+ Number+" where IdPro="+IdPro;

                var affectedRow = command.ExecuteNonQuery();

                Console.WriteLine(affectedRow); //  Output: 1
            }
            connection.Close();
        }
        public void deleteProduct(int IdPro)
        {
            Connect();
            connection.Open();
            using (var command = connection.CreateCommand())
            {

                command.CommandText = "delete from Product where IdPro="+IdPro;

                var affectedRow = command.ExecuteNonQuery();

                Console.WriteLine(affectedRow); //  Output: 1
            }
            connection.Close();
        }
    }
}