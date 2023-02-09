
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeoriaAsignacion1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente();
            cliente.ID = 1;
            cliente.Nombres = "Allen Radhames";
            cliente.Apellidos = "Silverio Olivo";
            cliente.Estado = 0;
            cliente.FechaNacimiento = DateTime.Parse("2004-01-06");

            Console.WriteLine($"NOMBRES: {cliente.Nombres}- APELLIDOS:{cliente.Apellidos}");
            Console.ReadLine();
        }
    }
}
