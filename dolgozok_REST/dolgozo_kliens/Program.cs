using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace dolgozo_kliens
{
    internal class Program
    {
        private const string URL = "http://localhost:8000/dolgozo/";
        static void Main(string[] args)
        {
            RestClient client = new RestClient(URL);
            RestRequest request = new RestRequest("read.php", Method.Get);
            request.Timeout = 500;
            RestResponse<PHPResponse> response = client.Execute<PHPResponse>(request);
            if(response.StatusCode == 0)
            {
                Console.WriteLine("Kapcsolat a szerverrel meghiúsult. Enter a kilépéshez");
                Console.ReadLine();
                return;
            }
            //RestResponse<List<Dolgozo>> response = client.Execute<List<Dolgozo>>(request);
            Console.WriteLine("id|nev|reszleg_id|foto");
            response.Data.Data.ForEach(x => Console.WriteLine(x));

            Console.ReadKey();
        }
    }
    internal class PHPResponse
    {
        /*
            'status' => 200,
            'message' => 'Employee List Fetched Successfully',
            'data' => $employees
         */
        public int Status { get;set; }
        public string Message { get; set; }
        public List<Dolgozo> Data { get; set; }
    }
    internal class Dolgozo
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public byte Reszleg_id { get; set; }
        public string Foto { get; set; }

        public override string ToString()
        {
            return string.Format($"{Id}|{Nev}|{Reszleg_id}|{Foto}");
        }
    }
}
