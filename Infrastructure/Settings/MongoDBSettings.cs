using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Settings
{
    public class MongoDBSettings
    {
        public string Host { get; init; }
        public string Port { get; init; }
        public string DatabaseName { get; set; }
        public List<string> Collections { get; set; }
        public string ConnectionString => $"mongodb://{Host}:{Port}";
    }
}
