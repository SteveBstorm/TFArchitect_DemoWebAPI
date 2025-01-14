using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CorrectifLabo.Repositories
{
    public abstract class BaseRepository
    {
        private readonly IConfiguration _config;
        public string ConnectionString { get; set; }
        public BaseRepository(IConfiguration config)
        {
            _config = config;
            ConnectionString = config.GetConnectionString("default");
        }

        protected abstract object Mapper(SqlDataReader reader);
    }
}
