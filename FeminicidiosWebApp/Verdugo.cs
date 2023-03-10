using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeminicidiosWebApp
{
    public class Verdugo
    {
        public int TipoDocumento { get; set; }
        public string Documento { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaEvento { get; set; }
        public int CantidadHijos { get; set; }
        public int Vivo { get; set; }

        public int Preso { get; set; }

    }
}