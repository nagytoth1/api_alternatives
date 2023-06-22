using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography;

namespace dolgozok_ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReszlegController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ReszlegController(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

        [HttpGet]
        public JsonResult Get()
        {
            string sql = @"SELECT id, nev FROM reszleg;";
            DataTable table = new DataTable();
            MySqlDataReader reader;

            using MySqlConnection conn = new MySqlConnection(_configuration.GetConnectionString("DolgozoCon"));
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                reader = cmd.ExecuteReader();
                table.Load(reader);
                reader.Close();
            }
            conn.Close();

            return new JsonResult(table);
        }
    }
}
