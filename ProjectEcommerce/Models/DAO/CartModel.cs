using ProjectEcommerce.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProjectEcommerce.Models.DAO
{
    public class CartModel : Connection
    {
        public List<DetailCart> listCart(string IdCus)
        {
            Connect();
            connection.Open();
            List<DetailCart> listCart = new List<DetailCart>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select IdCart,p.IdPro, CodePro, NamePro, Image, Price, Number from Product p inner join Cart c on p.IdPro=c.IdPro inner join Customer cu on c.IdCus=cu.IdCus where c.IdCus="+IdCus;

                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                     var IdPro = reader["IdPro"].ToString();
                     var IdCart = reader["IdCart"].ToString();
                     var CodePro = reader["CodePro"].ToString();
                    var NamePro = reader["NamePro"].ToString();
                    var Price = reader["Price"].ToString();
                    var Number = reader["Number"].ToString();
                    var Image = reader["Image"].ToString();
                    DetailCart c = new DetailCart(CodePro, NamePro, Image, float.Parse(Price), int.Parse(Number),int.Parse(IdPro), int.Parse(IdCart));
                    listCart.Add(c);
                }
            }

            connection.Close();
            return listCart;
        }

        public void addCart(string IdCus, string IdPro, int Number)
        {
            Connect();
            connection.Open();
            using (var command = connection.CreateCommand())
            {                 
                command.CommandText = "Insert Into Cart " +
                    "Values ('" + IdCus + "', '" + IdPro + "', " + Number + ")";

                var affectedRow = command.ExecuteNonQuery();

            }
            connection.Close();
        }
        public void updateCart(int IdCart, int Number)
        {
            Connect();
            connection.Open();
            using (var command = connection.CreateCommand())
            {                 
                command.CommandText = "update Cart set Number="+Number+" where IdCart="+IdCart;

                var affectedRow = command.ExecuteNonQuery();

            }
            connection.Close();
        }
        public void deleteCart(int IdCart)
        {
            Connect();
            connection.Open();
            using (var command = connection.CreateCommand())
            {                 
                command.CommandText = "delete from Cart where IdCart=" + IdCart;

                var affectedRow = command.ExecuteNonQuery();

            }
            connection.Close();
        }
        public int checkIdCart(int IdCus, int IdPro)
        {
            Connect();
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select IdCart from Cart where IdPro="+IdPro+" and IdCus="+IdCus;

                var reader = command.ExecuteScalar();
                if (reader != null)
                {
                     return int.Parse(reader.ToString());

                }
                else
                {
                    return 1;
                }
            }

            connection.Close();
            return 0;
        }
        public int getAmount(int IdCart)
        {
            Connect();
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select Number from Cart where IdCart="+IdCart;

                var reader = command.ExecuteScalar();
                if (reader != null)
                {
                     return int.Parse(reader.ToString());

                }
                else
                {
                    return 1;
                }
            }

            connection.Close();
            return 0;
        }
    }
}