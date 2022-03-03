using ProjectEcommerce.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEcommerce.Models.DAO
{
    public class OrderModel : Connection
    {
        public List<Order> listOrderAdmin(int Status)
        {
            Connect();
            connection.Open();
            List<Order> listOrder = new List<Order>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select IdOrder, NameCus, CodePro, NamePro, Price, Number, SumPrice, o.Address from Orders o inner join Product p on o.IdOrder=p.IdPro inner join Customer cu on o.IdCus = cu.IdCus where o.Status="+Status;

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                     var NameCus = reader["NameCus"].ToString();
                     var IdOrder = reader["IdOrder"].ToString();
                    var CodePro = reader["CodePro"].ToString();
                    var NamePro = reader["NamePro"].ToString();
                    var Price = reader["Price"].ToString();
                    var Number = reader["Number"].ToString();
                    var SumPrice = reader["SumPrice"].ToString();
                    var Address = reader["Address"].ToString();

                    Order o = new Order(int.Parse(IdOrder), NameCus, CodePro, NamePro, float.Parse(Price), int.Parse(Number), double.Parse(SumPrice), Address);
                    listOrder.Add(o);
                }

            }

            connection.Close();
            return listOrder;
        }
        public List<Order> listOrder(int IdCart)
        {
            Connect();
            connection.Open();
            List<Order> listOrder = new List<Order>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select IdCus, c.IdPro, Number, Price from Cart c inner join Product p on c.IdPro=p.IdPro where IdCart=" + IdCart;

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                     var IdPro = reader["IdPro"].ToString();
                    var IdCus = reader["IdCus"].ToString();
                    var Price = reader["Price"].ToString();
                    var Number = reader["Number"].ToString();
                     
                    Order o = new Order(int.Parse(IdCus), int.Parse(IdPro), int.Parse(Number), double.Parse(Price));
                    listOrder.Add(o);
                }

            }

            connection.Close();
            return listOrder;
        }
        
        public void addOrder(int IdCus, int IdPro, int Number, double sumPrice, string Address)
        {
            Connect();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                 
                command.CommandText = "Insert Into Orders (IdCus, IdPro, Number, sumPrice, Address, Status)" +
                    "Values (" + IdCus + ", " + IdPro + ", " + Number + ", " + sumPrice + ", N'"+Address+"',"+0+")";

                var affectedRow = command.ExecuteNonQuery();

                Console.WriteLine(affectedRow); //  Output: 1
            }
            connection.Close();
        }
        public void updateNumberPro(string CodePro, int Amount)
        {
            Connect();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                 
                command.CommandText = "update Product set Amount=Amount-"+Amount+" where CodePro='"+CodePro+"'";

                var affectedRow = command.ExecuteNonQuery();

                Console.WriteLine(affectedRow); //  Output: 1
            }
            connection.Close();
        }
        public void updateStatus(int IdOrder, int Status)
        {
            Connect();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                 
                command.CommandText = "update Orders set Status="+Status+" where IdOrder="+IdOrder;

                var affectedRow = command.ExecuteNonQuery();

                Console.WriteLine(affectedRow); //  Output: 1
            }
            connection.Close();
        }
    }
}