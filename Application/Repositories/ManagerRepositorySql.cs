using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Application.InterfaceRepor;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Application.Repositories
{
    public class ManagerRepositorySql: IManagerRepository,ICommonProcess<Manager>
    {
        private readonly string sql;
        public ManagerRepositorySql()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            sql = configuration.GetConnectionString("DefaultConnection");
        }


        public Result<Manager> TakingPassword(int managerıd, byte[] oldpassword)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CheckPasswordManager", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ıd", SqlDbType.Int).Value = managerıd;
                cmd.Parameters.Add("@oldpassword", SqlDbType.Binary, 32).Value=oldpassword;
                try
                {
                 SqlDataReader dr=cmd.ExecuteReader();


                    if (!dr.HasRows)
                        return Result<Manager>.Fail("The Manager not found or password was wrong");

                    dr.Read();


                    Manager manager = new Manager(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetFieldValue<byte[]>(3));

                    dr.Close();

                    return Result<Manager>.Success(manager, default);

                }
                catch (SqlException ex)
                {
                    return Result<Manager>.Fail(ex.Message);
                }
                catch
                {
                    throw;
                }
            
            }
        }
        public Result<Manager> ChangingPassword(string oldpass,int managerıd, string newps)
        {

            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("PasswordManager", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ıd", SqlDbType.Int).Value=managerıd;
                cmd.Parameters.Add("@newpass", SqlDbType.Binary).Value = HashHelper.ComputeSha256Hash(newps);
                cmd.Parameters.Add("@oldpass", SqlDbType.Binary).Value = HashHelper.ComputeSha256Hash(oldpass);


                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    dr.Read();

                    Manager manager = new Manager(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetFieldValue<byte[]>(3));

                    dr.Close();
                    return Result<Manager>.Success(manager, "the process of changing password was sucesfully");

                }
                catch (SqlException ex) 
                {
                    return Result<Manager>.Fail(ex.Message);

                }
             
            }
            
        }
        public Result<Manager> ChangingUserName(int managerıd, string username)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand com = new SqlCommand("UserNameManager", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@ID",SqlDbType.Int).Value=managerıd;
                com.Parameters.Add("@username",SqlDbType.NVarChar).Value= username;
                try
                {
                    SqlDataReader dr = com.ExecuteReader();

                    if (!dr.HasRows)
                        return Result<Manager>.Fail("The Manager not found");

                    dr.Read();

                    Manager manager = new Manager(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetFieldValue<byte[]>(3));

                    dr.Close();
                    return Result<Manager>.Success(manager, "the process of changing username was sucesfully");
                }
                catch(SqlException ex) 
                {
                    return Result<Manager>.Fail(ex.Message);
                }
            }
        }

        public Result<List<UpdateProductDTO>> IncreasingStock(Dictionary<int,int>products)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("IncreasingStock", con);
                cmd.CommandType=CommandType.StoredProcedure;

                DataTable table = new DataTable();

                table.Columns.Add("ProductID", typeof(int));
                table.Columns.Add("Quantity", typeof(int));

                foreach (var b in products)
                {
                    table.Rows.Add(b.Key,b.Value);
                }

                var param = cmd.Parameters.Add("@ıtem", SqlDbType.Structured);
                param.TypeName = "OrderItemType";
                param.Value = table;

                try
                {
                   SqlDataReader dr=cmd.ExecuteReader();

                    var list=new List<UpdateProductDTO>();
                    while (dr.Read())
                    {
                        UpdateProductDTO product = new UpdateProductDTO(dr.GetString(0), dr.GetInt32(1), dr.GetInt32(2));
                        list.Add(product);
                    }
                    dr.Close();

                    return Result<List<UpdateProductDTO>>.Success(list, "The stock of products was updated");
                    
                }
                catch (SqlException ex) 
                {
                    return Result<List<UpdateProductDTO>>.Fail(ex.Message);

                }
                catch
                {
                    throw;
                }
            }
        }
        public Result<Manager> GetUser(int Managererıd)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("GetManager", con);
                cmd.Parameters.Add("@ıd", SqlDbType.Int).Value = Managererıd;
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                        return Result<Manager>.Fail("The Manager not found");


                    reader.Read();

                    Manager Manager = new Manager(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetFieldValue<byte[]>(3));

                    reader.Close();

                    return Result<Manager>.Success(Manager, default);
                }
                catch (SqlException ex)
                {

                    return Result<Manager>.Fail(ex.Message);
                }

                catch
                {
                    throw;
                }
            }


        }
        public Result<List<UpdateProductDTO>> DecreasingStock(Dictionary<int, int> products)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DecreasingStock", con);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable table = new DataTable();

                table.Columns.Add("ProductID", typeof(int));
                table.Columns.Add("Quantity", typeof(int));

                foreach (var b in products)
                {
                    table.Rows.Add(b.Key, b.Value);
                }

                var param = cmd.Parameters.Add("@ıtem", SqlDbType.Structured);
                param.TypeName = "OrderItemType";
                param.Value = table;

                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    var list = new List<UpdateProductDTO>();
                    while (dr.Read())
                    {
                        UpdateProductDTO product = new UpdateProductDTO(dr.GetString(0), dr.GetInt32(1), dr.GetInt32(2));
                        list.Add(product);
                    }
                    dr.Close();

                    return Result<List<UpdateProductDTO>>.Success(list, "The stock of products was updated");

                }
                catch (SqlException ex) 
                {
                    return Result<List<UpdateProductDTO>>.Fail(ex.Message);

                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
