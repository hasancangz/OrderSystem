using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using C__SQL_ADO.NET_Application.InterfaceRepor;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using C__SQL_ADO.NET_Application.DTO;
namespace C__SQL_ADO.NET_Application.Repositories
{
    public class OrderRepositorySql: IOrderRepository
    {
        private readonly string sql;
        public OrderRepositorySql()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();
            sql = configuration.GetConnectionString("DefaultConnection");
        }

        public Result<Order> CreatingOrder(Dictionary<int,int>orderıtem,int customerıd)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                
                con.Open();
               
                SqlCommand cmd = new SqlCommand("CreateOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderTime", SqlDbType.DateTime2).Value = DateTime.Now;
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerıd;

                DataTable dt = new DataTable();
                dt.Columns.Add("ProductId", typeof(int));
                dt.Columns.Add("Quantity", typeof(int));
                foreach (var a in orderıtem)
                {
                    dt.Rows.Add(a.Key, a.Value);
                }
                var param = cmd.Parameters.Add("@ıtem", SqlDbType.Structured);
                param.TypeName = "OrderItemType";
                param.Value = dt;
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    dr.Read();

                    Order order = new Order(

                      dr.GetInt32(0),
                      dr.GetDateTime(1),
                      (Order.OrderType)dr.GetByte(2),
                      dr.GetDecimal(3),
                      dr.GetInt32(4)
                    );

                    dr.NextResult();

                    var item = new List<OrderItem>();
                    ;
                    while (dr.Read())
                    {
                       item.Add(new OrderItem(dr.GetInt32(0), dr.GetString(1), dr.GetDecimal(2), dr.GetInt32(3)));
                    }


                    order.AssignItem(item);

                   return Result<Order>.Success(order, "Created");
                       


                }
                catch (SqlException ex) 
                {
                    return Result<Order>.Fail(ex.Message);
                }
             
                catch
                {
                    throw;
                }
           
            }
        }
        public Result<Order> CancelledOrder(int orderıd)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CancelledOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@orderıd",SqlDbType.Int).Value= orderıd;

                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    
                        dr.Read();

                        Order order = new Order(dr.GetInt32(0), dr.GetDateTime(1), (Order.OrderType)dr.GetByte(2), dr.GetDecimal(3), dr.GetInt32(4));

                       
                          dr.Close();                   
                    return Result<Order>.Success(order, "The cancelled order process was succesfully");

                }
                catch (SqlException ex) 
                {
                    return Result<Order>.Fail(ex.Message);
                }
                catch
                {
                    throw;
                }
               
            }
        }
        public Result<Order> ApporvedOrder(int orderıd)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ApporvedOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@orderıd",SqlDbType.Int).Value= orderıd;
                try
                {
                   SqlDataReader dr=cmd.ExecuteReader();

                    dr.Read();

                    Order order = new Order(dr.GetInt32(0), dr.GetDateTime(1), (Order.OrderType)dr.GetByte(2), dr.GetDecimal(3), dr.GetInt32(4));

                    cmd.Dispose();

                    return Result<Order>.Success(order, "The apporved order process was succesfully");
                }
                catch (SqlException ex) 
                {
                    return Result<Order>.Fail(ex.Message);
                }
                catch
                {
                    throw;
                }
           
            }
        }
        public Result<Order> GetOrderID(int orderıd)
        {

            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetOrderByID", con);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.Add("@ıd", SqlDbType.Int).Value = orderıd;


                try
                {
                    
                    SqlDataReader dr = cmd.ExecuteReader();


                    if (!dr.HasRows)
                        return Result<Order>.Fail("The Order not found");


                    dr.Read();

                    Order order = new Order(dr.GetInt32(0), dr.GetDateTime(1), (Order.OrderType)dr.GetByte(2), dr.GetDecimal(3), dr.GetInt32(4));
                    
                    dr.Close(); 

                    return Result<Order>.Success(order, default);

                }
                catch(SqlException ex)
                {
                   return Result<Order>.Fail(ex.Message);                  
                }
                catch
                {
                    throw;
                }

            }
        }

        public Result<List<Product>> GetProducts()
        {

            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("GetProducts", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (!dr.HasRows)
                        return Result<List<Product>>.Fail("There is no products");

                    List<Product> products = new List<Product>();

                    while (dr.Read())
                    {
                        products.Add(new Product(dr.GetInt32(0), dr.GetString(1), dr.GetDecimal(2), dr.GetInt32(3),null));
                    }

                    dr.Close();

                    return Result<List<Product>>.Success(products, default);


                }
                catch (SqlException ex)
                {
                    return Result<List<Product>>.Fail(ex.Message);

                }
                catch
                {
                    throw;
                }
            }
        }

        public Result<List<Product>> GetProductFor()
        {

            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DecAndInc", con);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (!dr.HasRows)
                        return Result<List<Product>>.Fail("There is no products");

                    List<Product> products = new List<Product>();

                    while (dr.Read())
                    {
                        products.Add(new Product(dr.GetInt32(0), dr.GetString(1), dr.GetDecimal(2), dr.GetInt32(3), dr.GetInt32(4)));
                    }

                    dr.Close();

                    return Result<List<Product>>.Success(products, default);


                }
                catch (SqlException ex)
                {
                    return Result<List<Product>>.Fail(ex.Message);

                }
                catch
                {
                    throw;
                }
            }
        }

      
    }
}
