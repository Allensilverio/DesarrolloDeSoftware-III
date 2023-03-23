using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsumirWebServiceFeminicidio.SR;
using log4net;
using log4net.Config;

namespace ConsumirWebServiceFeminicidio
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {

            bool run = true;
            string opcion;

            while (run)
            {
                FeminicidiosWebServiceSoapClient ws = new FeminicidiosWebServiceSoapClient();
                Verdugo verdugo = new Verdugo();
                Indicio indicio = new Indicio();

                Console.WriteLine("------ Insertar Verdugo -------");

                Console.WriteLine("Tipo Documento: ");
                verdugo.TipoDocumento = int.Parse(Console.ReadLine());

                Console.WriteLine("Documento: ");
                verdugo.Documento = Console.ReadLine();

                Console.WriteLine("Nombres: ");
                verdugo.Nombres = Console.ReadLine();

                Console.WriteLine("Apellidos: ");
                verdugo.Apellidos = Console.ReadLine();

                Console.WriteLine("Fecha Nacimiento: ");
                string FechaNacimiento = Console.ReadLine();
                verdugo.FechaNacimiento = DateTime.Parse(FechaNacimiento);

                Console.WriteLine("Fecha Evento: ");
                string FechaEvento = Console.ReadLine();
                verdugo.FechaEvento = DateTime.Parse(FechaEvento);

                Console.WriteLine("Cantidad Hijos: ");
                verdugo.CantidadHijos = int.Parse(Console.ReadLine());

                Console.WriteLine("Vivo: ");
                verdugo.Vivo = int.Parse(Console.ReadLine());

                Console.WriteLine("Preso: ");
                verdugo.Preso = int.Parse(Console.ReadLine());

                Console.WriteLine("--------- Insertar Indicio ---------");

                Console.WriteLine("Descipcion: ");
                indicio.Descripcion = Console.ReadLine();

                Console.WriteLine(ws.RegistrarDatos(verdugo, indicio).mensaje);
                log.Info("Se ha hecho un registro existoso");

                Console.WriteLine("Quieres salir (s/n)");
                opcion = Console.ReadLine();

                if (opcion.ToLower() == "s")
                {
                    run = false;
                }
                else
                {
                    run = true;
                }

            }

      
        }
    }
}
