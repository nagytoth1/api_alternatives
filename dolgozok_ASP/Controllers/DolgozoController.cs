using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace dolgozok_ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DolgozoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private string connString;
        public DolgozoController(IConfiguration configuration)
        {
            _configuration = configuration;
            connString = _configuration.GetConnectionString("DolgozoCon");
        }

        [HttpGet]
        public JsonResult Get()
        {
            string sql =
                @"SELECT d.id, d.nev, r.nev, d.foto 
                from dolgozo d 
                inner join reszleg r on r.id = d.reszleg_id;";
            DataTable table = new DataTable();
            MySqlDataReader reader;
            using MySqlConnection conn = new MySqlConnection(connString);
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
        [HttpPost]
        public JsonResult Post(Dolgozo dolgozo)
        {
            string sql = @"INSERT INTO dolgozo(nev, reszleg_id, foto) VALUES
                           (@Nev, @Reszleg_id, @Foto);";
            using MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Nev", dolgozo.Nev);
                cmd.Parameters.AddWithValue("@Reszleg_id", dolgozo.Reszleg_id);
                cmd.Parameters.AddWithValue("@Foto", dolgozo.Foto_nev);
                cmd.ExecuteReader().Close();
            }
            conn.Close();
            return new JsonResult("Dolgozó hozzáadása sikeres volt.");
        }

        [HttpPut]
        public JsonResult Put(Dolgozo dolgozo) //ezek a headerben mennek át: ushort id, string name
        {
            string sql = @"UPDATE dolgozo 
                           SET nev = @Nev 
                           WHERE id = @Id;";
            using MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", dolgozo.Id);
                cmd.Parameters.AddWithValue("@Nev", dolgozo.Nev);
                cmd.ExecuteReader().Close();
            }
            conn.Close();
            return new JsonResult("Dolgozó módosítása sikeres volt.");
        }

        [HttpDelete]
        public JsonResult Delete(ushort id) 
        {
            string sql = @"DELETE FROM dolgozo 
                           WHERE id = @Id;";
            using MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteReader().Close();
            }
            conn.Close();
            return new JsonResult("Dolgozó törlése sikeres volt.");
        }
    }
}
