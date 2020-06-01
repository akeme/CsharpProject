using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDApi.Models
{
    public class LogsDatabaseSettings : ILogsStoreDatabaseSettings
    {
        public string LogsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ILogsStoreDatabaseSettings
    {
        string LogsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
