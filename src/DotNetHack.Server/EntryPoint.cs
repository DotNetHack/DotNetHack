using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Server;
using Thrift.Transport;

namespace DotNetHack.Server
{
    /// <summary>
    /// DNHPacketHandler
    /// </summary>
    public class DNHPacketHandler : DNHService.Iface
    {
        /// <summary>
        /// DNHPacketHandler
        /// </summary>
        public DNHPacketHandler()
        {
            LogCallback += Console.Write;
        }

        public Action<String> LogCallback { get; set; }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="userName">the user name</param>
        /// <param name="passwordHash">the password hash</param>
        /// <returns>an auth response object containing -1 on auth failure</returns>
        DNHAuthResponse DNHService.Iface.Authenticate(string userName, string passwordHash)
        {
            LogCallback(string.Format("Authenticating {0}", userName));

            DNHAuthResponse retVal = new DNHAuthResponse() 
            {
                ID = -1,
                Message = "",
            };

            try
            {
                using (var dbConn = new SqlConnection(Properties.Settings.Default.DSN))
                {
                    dbConn.Open();

                    const string sqlText = "SELECT [ID] FROM [User] WHERE [Name] = @Name AND [PasswordHash] = @PasswordHash";

                    using (SqlCommand cmd = new SqlCommand(sqlText, dbConn))
                    {
                        cmd.Parameters.AddWithValue("@Name", userName);
                        cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                        using (var dr = cmd.ExecuteReader(System.Data.CommandBehavior.SingleRow))
                        {
                            if (!dr.Read())
                            {
                                retVal.Message = "Invalid username / password";
                            }
                            else
                            {
                                retVal.ID = (int)dr[0];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retVal.Message = ex.Message;
            }

            return retVal;
        }
    }

    /// <summary>
    /// EntryPoint for DotNetHack Server
    /// </summary>
    class EntryPoint
    {
        [STAThread]
        static void Main(string[] args)
        {
            DNHPacketHandler handler = new DNHPacketHandler();
            DNHService.Processor processor = new DNHService.Processor(handler);

            TServerTransport serverTransport = new TServerSocket(9090);
            TServer server = new TThreadPoolServer(processor, serverTransport);

            Console.WriteLine("Starting the server...");
            server.Serve();
        }
    }
}
