using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignacionLab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Run = true;
            string opcion;

            // Conexion con la Base de Datos

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Cn"].ConnectionString);
            connection.Open(); // abro la conexion con la base de datos
            Console.WriteLine(connection.State);







            while (Run)
            {
                // CONDICION DE SALIDA DEL BUCLE
                Console.WriteLine("Quieres salir (s/n): ");
                opcion = Console.ReadLine();

                if (opcion.ToLower() == "s")
                {
                    Run = false;
                }
                else
                {
                    Run = true;
                }

            }
        }
    }
}
