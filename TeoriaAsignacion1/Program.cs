
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
                // Obtener los datos por consola del cliente

                Cliente cliente = new Cliente();
                //cliente.ID = 1;
                Console.WriteLine("Tipo Documento: "); //Recibe tipo entero
                cliente.TipoDocumento = int.Parse(Console.ReadLine());
                Console.WriteLine("Documento: ");
                cliente.Documento = Console.ReadLine();

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
      
                Console.WriteLine("Monto: "); // Monto que se le agrega al cliente
                cliente.balance = decimal.Parse(Console.ReadLine());



                // Conseguir los datos del movimiento por consola

                Movimientos movimiento = new Movimientos(); // Creamos una instancia de la clase movimientos

                Console.WriteLine("Dbcr: ");
                movimiento.Dbcr = Console.ReadLine();

                Console.WriteLine("Tipo Transaccion: "); // recibe 1 o -1


                movimiento.TipoTransaccion = int.Parse(Console.ReadLine());


                //Console.WriteLine($"NOMBRES: {cliente.Nombres}- APELLIDOS:{cliente.Apellidos}");


                //Establezco la conexion en la base de datos
                SqlTransaction transaction = null;

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Cn"].ConnectionString);
                connection.Open();

                
                Console.WriteLine(connection.State);


                SqlCommand command = new SqlCommand($"ppUpsertCliente2", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@comentario", comentario);
                command.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                command.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                command.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);

                command.Parameters.AddWithValue("@TipoDocumento", cliente.TipoDocumento);
                command.Parameters.AddWithValue("@Documento", cliente.Documento);
                command.Parameters.AddWithValue("@Balance", cliente.balance);
                command.Parameters.AddWithValue("@TipoTransaccion", movimiento.TipoTransaccion);



                command.ExecuteNonQuery();
                command.Parameters.Clear(); // Limpiamos los parametro para hacer el siguiente query

                try
                {
                    transaction = connection.BeginTransaction();
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                   
                    
                    command.CommandText = "ppInsertMovimientos"; // actualizamos el nombre del command

                    command.Parameters.AddWithValue("@TipoDocumento", cliente.TipoDocumento);
                    command.Parameters.AddWithValue("@Documento", cliente.Documento);
                    command.Parameters.AddWithValue("@TipoTransaccion", movimiento.TipoTransaccion);
                    command.Parameters.AddWithValue("@Dbcr", movimiento.Dbcr);
                    command.Parameters.AddWithValue("@Monto", cliente.balance);
                    command.Parameters.AddWithValue("@Descripcion", comentario);

                    command.ExecuteNonQuery();
                    transaction.Commit();

                }
                catch (Exception)
                {
                    transaction.Rollback(); // Devuelve la transaccion
                    throw;

                }
           
                
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
