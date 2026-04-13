using C__SQL_ADO.NET_Application.InterfaceRepor;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Application.Repositories
{
    public class CustomerRepositorySql:ICustomerRepository,ICommonProcess<Custom>
    {
        private readonly string sql;
        public CustomerRepositorySql()
        {

            var builder=new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            sql = configuration.GetConnectionString("DefaultConnection");

        }

        public Result<Custom> TakingPassword(int Customıd, byte[] oldpassword)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CheckPasswordCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ıd", SqlDbType.Int).Value = Customıd;
                cmd.Parameters.Add("@oldpassword", SqlDbType.Binary, 32).Value = oldpassword;
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (!dr.HasRows)
                        return Result<Custom>.Fail("The Customer not found or password was wrong");

                    dr.Read();

                    Custom Custom = new Custom(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetFieldValue<byte[]>(3));

                    dr.Close();

                    return Result<Custom>.Success(Custom, default);

                }
                catch (SqlException ex)
                {
                    return Result<Custom>.Fail(ex.Message);
                }
                catch
                {
                    throw;
                }

            }
        }

        public Result<Custom> ChangingPassword(string oldpass,int customerıd,string newps)
        {

            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ChangingPassword", con);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.Add("@ıd",SqlDbType.Int).Value=customerıd;
                cmd.Parameters.Add("@newpass", SqlDbType.Binary).Value = HashHelper.ComputeSha256Hash(newps);
                cmd.Parameters.Add("@oldpass", SqlDbType.Binary).Value = HashHelper.ComputeSha256Hash(oldpass);


                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();

                    Custom custom = new Custom(reader.GetInt32(0), reader.GetString(1),reader.GetString(2), reader.GetFieldValue<byte[]>(3));

                    return Result<Custom>.Success(custom, "the process of changing password was sucesfully");
                     
                }
                catch (SqlException ex) when (ex.Number == 50010)
                {
                    return Result<Custom>.Fail(ex.Message);
                }
                catch
                {

                    throw;
                }
            }
        }
        public Result<Custom> GetUser(int customerıd)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open ();

                SqlCommand cmd = new SqlCommand("GetCustomer", con);
                cmd.Parameters.Add("@ıd", SqlDbType.Int).Value = customerıd;
                cmd.CommandType= CommandType.StoredProcedure;

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                        return Result<Custom>.Fail("The customer not found");

                    reader.Read();

                    Custom custom = new Custom(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetFieldValue<byte[]>(3));

                    reader.Close ();
                    
                    return Result<Custom>.Success(custom, default);
                }
                catch(SqlException ex)
                {

                    return Result<Custom>.Fail(ex.Message);
                }

                catch
                {
                    throw;
                }
            }


        }
        public Result<Custom> ChangingUserName(int customerıd,string username)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();

                SqlCommand com = new SqlCommand("ChangingUserName", con);
                com.CommandType=CommandType.StoredProcedure;
                com.Parameters.Add("@username", SqlDbType.NVarChar, 150).Value = username;
                com.Parameters.Add("@ID", SqlDbType.Int).Value = customerıd;

                try
                {
                    SqlDataReader reader = com.ExecuteReader();

                    reader.Read();

                    Custom custom = new Custom(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetFieldValue<byte[]>(3));

                    reader.Close();
                    return Result<Custom>.Success(custom, "the process of changing username was sucesfully");

                }
                catch (SqlException e) when (e.Number == 50010)
                {
                    return Result<Custom>.Fail(e.Message);

                }
                catch
                {
                    throw;
                }
            }
        }
        public Result<List<OrderItem>> PreviousOrder(int customerıd)
        {

            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PreviousOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ıd", SqlDbType.Int).Value = customerıd;

                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (!dr.HasRows)
                        return Result<List<OrderItem>>.Fail("The orders that you have ordered not found");

                    List<OrderItem> ıtems = new List<OrderItem>();



                    while (dr.Read())
                    {

                        ıtems.Add(new OrderItem(dr.GetInt32(0), dr.GetString(1), dr.GetDecimal(2), dr.GetInt32(3)));

                    }

                    dr.Close();

                    return Result<List<OrderItem>>.Success(ıtems, default);
                }
                catch (SqlException ex)
                {
                    return Result<List<OrderItem>>.Fail(ex.Message);
                }
                catch
                {
                    throw;
                }
            }

        }
    }
}
