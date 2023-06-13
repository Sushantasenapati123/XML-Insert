using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TIMETABLE_MANAGEMENT_SYSTEM.Repository
{
    public class BASE_REPOSITORY
    {
        private readonly IConfiguration _configuration;
        protected BASE_REPOSITORY(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
