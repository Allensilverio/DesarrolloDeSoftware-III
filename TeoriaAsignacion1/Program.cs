
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeoriaAsignacion1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Run = true;
            string opcion;

            while (Run)
            {
                Cliente cliente = new Cliente();
                //cliente.ID = 1;
                Console.WriteLine("Nombres: ");
                cliente.Nombres = Console.ReadLine();
                Console.WriteLine("Apellidos: ");
                cliente.Apellidos = Console.ReadLine();
                cliente.Estado = 0;
                Console.WriteLine("Fecha Nacimiento: ");
                string FechaNacimiento = Console.ReadLine();
                cliente.FechaNacimiento = DateTime.Parse(FechaNacimiento);
                Console.WriteLine("Comentario: ");
                string comentario = Console.ReadLine();

                //Console.WriteLine($"NOMBRES: {cliente.Nombres}- APELLIDOS:{cliente.Apellidos}");
                

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Cn"].ConnectionString);
                connection.Open();
                Console.WriteLine(connection.State);
           
                SqlCommand command = new SqlCommand($"ppInsertCliente", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@comentario", comentario);
                command.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                command.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                command.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                

                command.ExecuteNonQuery();

                Console.WriteLine("Quieres salir (s/n): ");
                opcion = Console.ReadLine();


                if (opcion == "s")
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
