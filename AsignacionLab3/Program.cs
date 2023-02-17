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
        //Desarrolla Aplicacion Transaccional para regidtrar
        // si el pais existe y la ciudad existe se actualiza la cantidad de muertes y cantidad de hombres
        // Inserto un pais, si el pais existe aumentar si es hombre o mujer

        static void Main(string[] args)
        {
            bool Run = true;
            string opcion;

            while (Run)
            {

                // Conexion con la Base de Datos

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Cn"].ConnectionString);
                connection.Open(); // abro la conexion con la base de datos
                Console.WriteLine(connection.State);
                SqlTransaction transaction = null;

                SqlCommand command = new SqlCommand($"ppInsertFallecidos2", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // ----- Registro Fallecidos --------------

                Fallecidos fallecidos = new Fallecidos();

                Console.WriteLine("------ Insertar Fallecidos -------");
                Console.WriteLine("Tipo Documento: "); //Recibe tipo entero
                fallecidos.TipoDocumento = int.Parse(Console.ReadLine());
                Console.WriteLine("Documento: ");
                fallecidos.Documento = Console.ReadLine();  
                Console.WriteLine("Nombres: ");
                fallecidos.Nombres = Console.ReadLine();
                Console.WriteLine("Apellidos: ");
                fallecidos.Apellidos = Console.ReadLine();
                fallecidos.Estado = 0;
                Console.WriteLine("Sexo: ");
                fallecidos.Sexo = Console.ReadLine();
                Console.WriteLine("Fecha Nacimiento: ");
                string FechaNacimiento = Console.ReadLine();
                fallecidos.FechaNacimiento = DateTime.Parse(FechaNacimiento);
                Console.WriteLine("Pais: ");
                fallecidos.Pais = Console.ReadLine();
                Console.WriteLine("Ciudad: ");
                fallecidos.Ciudad = Console.ReadLine();

                transaction = connection.BeginTransaction(); // Inicio de la Transaccion
                command.Transaction = transaction;

                try
                {
                    
                    // actualizamos el nombre del command a utilizar

                    // Agregando los parametros para ppInsertFallecidos

                    command.Parameters.AddWithValue("@TipoDocumento", fallecidos.TipoDocumento);
                    command.Parameters.AddWithValue("@Documento", fallecidos.Documento);
                    command.Parameters.AddWithValue("@Nombres", fallecidos.Nombres);
                    command.Parameters.AddWithValue("@Apellidos", fallecidos.Apellidos);
                    command.Parameters.AddWithValue("@Sexo", fallecidos.Sexo);
                    command.Parameters.AddWithValue("@FechaNacimiento", fallecidos.FechaNacimiento);
                    command.Parameters.AddWithValue("@Pais", fallecidos.Pais);
                    command.Parameters.AddWithValue("@Ciudad", fallecidos.Ciudad);
                    command.Parameters.AddWithValue("@Estado", fallecidos.Estado);

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                    command.Parameters.AddWithValue("@Sexo", fallecidos.Sexo);
                    command.Parameters.AddWithValue("@Pais", fallecidos.Pais);
                    command.Parameters.AddWithValue("@Ciudad", fallecidos.Ciudad);

                    command.CommandText = "ppUpsertResumen";
                    command.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    transaction.Rollback();

                    throw;
                }




















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
