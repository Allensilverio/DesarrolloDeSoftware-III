using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirWebServiceTEO5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SR.WebServiceTEO6SoapClient ws = new SR.WebServiceTEO6SoapClient();
            Console.WriteLine(ws.Sumar(10, 5));
            Console.ReadKey();
            SR.Cliente cliente = new SR.Cliente() { Apellidos = "Hola" };
            Console.WriteLine(ws.RegistrarCliente(cliente).codigo);
            Console.ReadKey();
        }
    }
}
