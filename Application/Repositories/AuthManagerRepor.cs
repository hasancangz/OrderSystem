using C__SQL_ADO.NET_Application.InterfaceRepor;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Application.Repositories
{
    public class AuthManagerRepor: IAuthRepository<Manager>
    {


        private readonly string sql;
        public AuthManagerRepor()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            sql = configuration.GetConnectionString("DefaultConnection");
        }

        public Result<Manager> Login(string username, byte[] password)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("LoginManager", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 150).Value = username;
                cmd.Parameters.Add("@password", SqlDbType.Binary).Value = password;

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                   
                    if (!reader.HasRows)
                        return Result<Manager>.Fail("The Manager not found");

                    reader.Read();

                    Manager manager = new Manager(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetFieldValue<byte[]>(3));

                    reader.Close();

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
        public Result<Manager> Register(string name,string username, byte[] password)
        {
            using (SqlConnection con = new SqlConnection(sql))
            {
                SqlCommand cmd = new SqlCommand("RegisterManager", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 150).Value = username;
                cmd.Parameters.Add("@password", SqlDbType.Binary).Value =password;

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    Manager Manager = new Manager(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetFieldValue<byte[]>(3));

                    return Result<Manager>.Success(Manager, "Login is sucessfully");
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

    }
}
