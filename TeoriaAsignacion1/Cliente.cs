using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeoriaAsignacion1
{
    internal class Cliente
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Estado { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int TipoDocumento { get; set; }
        public string Documento { get; set; }

        public decimal balance { get; set; }

        public string Sexo { get; set; }

    }
}
