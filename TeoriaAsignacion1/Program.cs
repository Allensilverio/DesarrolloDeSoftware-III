
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
            Cliente cliente = new Cliente();
            //cliente.ID = 1;
            cliente.Nombres = "Allen Radhames";
            cliente.Apellidos = "Silverio Olivo";
            cliente.Estado = 0;
            cliente.FechaNacimiento = DateTime.Parse("2004-06-01");

            Console.WriteLine($"NOMBRES: {cliente.Nombres}- APELLIDOS:{cliente.Apellidos}");

            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\carim\\OneDrive\\Escritorio\\Allen\\TeoriaAsignacion1\\TeoriaAsignacion1\\MyData.mdf;Integrated Security=True");
            connection.Open();
            Console.WriteLine(connection.State);

            SqlCommand command = new SqlCommand($"INSERT tblClientes(NOMBRES, APELLIDOS, FECHANACIMIENTO, SEXO, COMENTARIO) VALUES ('{cliente.Nombres}', '{cliente.Apellidos}', '{cliente.FechaNacimiento}', 'M', 'COMENTARIO')", connection);
            
             command.ExecuteNonQuery();
        }
    }
}
