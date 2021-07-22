using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool isService = false;
            // when the service start we need to pass the --service parameter while running the.exe
            if (Debugger.IsAttached == false && args.Contains("--service"))
            {
                isService = true;
            }
            if (isService)
            {
                // Get the Content Root Directory
                var pathToContentRoot = Directory.GetCurrentDirectory();


                string ConfigurationFile = ""; //Configuration file.
                string PortNno = "5001"; //Port

                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                pathToContentRoot = Path.GetDirectoryName(pathToExe);
                // Get the json file and read the service port no if available in the json file.
                string AppJsonFilePath = Path.Combine(pathToContentRoot, ConfigurationFile);
                if (File.Exists(AppJsonFilePath))
                {
                    using (StreamReader sr = new StreamReader(AppJsonFilePath))
                    {
                        string jsonData = sr.ReadToEnd();
                        JObject jobject = JObject.Parse(jsonData);
                        if (jobject["Serviceport"] != null)
                            PortNno = jobject["Serviceport"].ToString();
                    }
                }

                var host = WebHost.CreateDefaultBuilder(args)
                    .UseContentRoot(pathToContentRoot)
                    .UseStartup<Startup>()
                    .UseUrls("http://localhost:" + PortNno)
                    .Build();

                host.RunAsService();
            }
            else
            {
                CreateHostBuilder(args).Build().Run();
            }
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
