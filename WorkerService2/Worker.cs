using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using Npgsql;

namespace WorkerService2
{
    public class Worker : BackgroundService
    {
        public readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                var cs = "Host=localhost;Username=postgres;Password=vukoja;Database=postgres";

                using var con = new NpgsqlConnection(cs);

                con.Open();


                string sql1 = "SELECT * FROM info";

                using var cmd1 = new NpgsqlCommand(sql1, con);

                using NpgsqlDataReader rdr1 = cmd1.ExecuteReader();

                var info = new List<string>();

                while (rdr1.Read())
                {

                    info.Add(rdr1.GetString(1));
                }


                cmd1.Dispose();
                rdr1.Close();




                string sql2 = "SELECT * FROM ip_address";

                using var cmd2 = new NpgsqlCommand(sql2, con);

                using NpgsqlDataReader rdr2 = cmd2.ExecuteReader();

                var ip_address = new List<string>();

                while (rdr2.Read())
                {

                    ip_address.Add(rdr2.GetString(1));
                }

                cmd2.Dispose();
                rdr2.Close();




                string sql3 = "SELECT * FROM server_name";

                using var cmd3 = new NpgsqlCommand(sql3, con);

                using NpgsqlDataReader rdr3 = cmd3.ExecuteReader();

                var server_name = new List<string>();

                while (rdr3.Read())
                {

                    server_name.Add(rdr3.GetString(1));
                }

                cmd3.Dispose();
                rdr3.Close();




                string sql4 = "SELECT * FROM server_status";

                using var cmd4 = new NpgsqlCommand(sql4, con);

                using NpgsqlDataReader rdr4 = cmd4.ExecuteReader();

                var server_status = new List<string>();

                while (rdr4.Read())
                {

                    server_status.Add(rdr4.GetString(1));
                }

                cmd4.Dispose();
                rdr4.Close();

                int userInput;
                Console.WriteLine("Unesite broj ponavljanja");
                userInput = int.Parse(Console.ReadLine());
                Console.WriteLine(userInput);

                for (int i = 0; i < userInput; i++)
                {

                    Random random1 = new Random();
                    string information = info[random1.Next(info.Count)];

                    Random random2 = new Random();
                    string ipaddress = ip_address[random2.Next(ip_address.Count)];

                    Random random3 = new Random();
                    string servername = server_name[random3.Next(server_name.Count)];

                    Random random4 = new Random();
                    string serverstatus = server_status[random4.Next(server_status.Count)];

                    string message = "Log info " + DateTimeOffset.Now + "  " + information + " at address " +
                        ipaddress + " and server name " + servername + " with status " + serverstatus + "\n";
                    _logger.LogInformation(message);

                    using (StreamWriter sw = File.AppendText(@"C:\LogFolder\WriteText.log"))
                        sw.WriteLine(message);
                    await Task.Delay(100, stoppingToken);
                }
            }
        }
    }
}
