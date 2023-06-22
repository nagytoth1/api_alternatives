using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Service
{
    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract]
        Dolgozo[] GetDolgozok();
    }

    [DataContract]
    public class Dolgozo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nev { get; set; }
        [DataMember]
        public int Reszleg_id { get; set; }
        [DataMember]
        public string Foto { get; set; }

        public override string ToString()
        {
            return $"Dolgozo: {Id}|{Nev}|{Reszleg_id}|{Foto}";
        }

        public Dolgozo(ushort id, string nev, byte reszleg_id, string foto)
        {
            this.Id = id;
            this.Nev = nev;
            this.Reszleg_id = reszleg_id;
            this.Foto = foto;
        }
    }
}
