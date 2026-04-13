using C__SQL_ADO.NET_Application.InterfaceRepor;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Application.Repositories
{
    public class AuthCustomerRepor: IAuthRepository<Custom>
    {
        private readonly string sql;
        public AuthCustomerRepor()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            sql = configuration.GetConnectionString("DefaultConnection");
        }


        public Result<Custom> Login(string username, byte[] password)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                
                SqlCommand cmd = new SqlCommand("LoginCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 150).Value = username;
                cmd.Parameters.Add("@password", SqlDbType.Binary).Value = password;

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                        return Result<Custom>.Fail("The customer not found");

                    reader.Read();

                    Custom custom = new Custom(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetFieldValue<byte[]>(3));

                    reader.Close();

                    return Result<Custom>.Success(custom, "The Login process is succesfully");
                }
                catch(SqlException ex)
                {
                  return  Result<Custom>.Fail(ex.Message);
                }
                catch
                {
                    throw;
                }
            }
        }
        public Result<Custom> Register(string name, string username, byte[] password)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("RegisterCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@name",SqlDbType.NVarChar,100).Value = name;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 150).Value = username;
                cmd.Parameters.Add("@password", SqlDbType.Binary).Value = password;

                try
                {

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                        return Result<Custom>.Fail("The customer not found");

                    reader.Read();

                    Custom custom = new Custom(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetFieldValue<byte[]>(3));

                    reader.Close();

                    return Result<Custom>.Success(custom, default);
                }
                catch(SqlException ex) 
                {
                  return  Result<Custom>.Fail(ex.Message);
                }
                catch
                {
                    throw;
                }
            }
        }

    }
}
