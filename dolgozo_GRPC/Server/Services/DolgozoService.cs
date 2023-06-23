using Grpc.Core;

namespace Server.Services
{
    public class DolgozoService:Dolgozo.DolgozoBase
    {
        private byte MAX_SIZE = 100;
        private List<DolgozoModel> dolgozok;
        private sbyte index = -1;
        public DolgozoService()
        {
            dolgozok = new List<DolgozoModel>(MAX_SIZE);
        }

        public override Task<DolgozoModel> GetDolgozo(DolgozoID request, ServerCallContext context)
        {
            if(request.Id < 0 || request.Id >= MAX_SIZE)
            {
                return Task.FromResult(new DolgozoModel() { Nev = "null" });
            }
            return Task.FromResult(dolgozok[request.Id]);
        }

        public override Task ListDolgozok(Empty request, IServerStreamWriter<DolgozoModel> responseStream, ServerCallContext context)
        {
            return Task.FromResult(dolgozok);
        }

        public override Task<Response> AddDolgozo(DolgozoModel request, ServerCallContext context)
        {
            ++index;
            if(index >= MAX_SIZE)
            {
                return Task.FromResult(new Response() { Code = 500 }); //megtelt a tömb
            }
            dolgozok[index] = request;

            return Task.FromResult(new Response() { Code = 200 });
        }

        public override Task<Response> RemoveDolgozo(DolgozoID request, ServerCallContext context)
        {
            try
            {
                dolgozok.RemoveAt(request.Id);
            }
            catch (ArgumentException)
            {
                return Task.FromResult(new Response() { Code = 500 });
            }
            return Task.FromResult(new Response() { Code= 200 });
        }

        public override Task<Response> UpdateDolgozo(DolgozoUpdate request, ServerCallContext context)
        {
            if (request.Id.Id < 0 || request.Id.Id >= MAX_SIZE)
            {
                return Task.FromResult(new Response() { Code = 500 });
            }
            DolgozoModel found = dolgozok[request.Id.Id];
            DolgozoModel uj = request.Dolgozo;
            found.Nev = uj.Nev;
            found.FotoNev = uj.FotoNev;
            found.ReszlegId = uj.ReszlegId;
            return Task.FromResult(new Response() { Code = 200 });
        }
    }
}
