using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.IO;

namespace SportingEvents.Models
{
    public class CallConnectionString
    {
        public static string ConnectionString() 
        {
            var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var config = configBuilder.Build();
            string connectionstring = config.GetConnectionString("DefaultConnection");
            return connectionstring;
        }
    }
}
