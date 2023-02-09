
using System;
using System.Collections.Generic;
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

                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\carim\\OneDrive\\Escritorio\\Allen\\TeoriaAsignacion1\\TeoriaAsignacion1\\MyData.mdf;Integrated Security=True");
                connection.Open();
                Console.WriteLine(connection.State);

                SqlCommand command = new SqlCommand("INSERT tblClientes(NOMBRES, APELLIDOS, FECHANACIMIENTO, SEXO, COMENTARIO) VALUES (@Nombres, @Apellidos, @FechaNacimiento, 'M', @Comentario)", connection);
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
