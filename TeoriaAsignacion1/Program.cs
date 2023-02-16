    
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
                //Establezco la conexion en la base de datos - Inicializo el objeto Transaction - Estableciendo el command type Stored Procedure

                SqlTransaction transaction = null;
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Cn"].ConnectionString);
                connection.Open(); // abro la conexion con la base de datos
                Console.WriteLine(connection.State);
                SqlCommand command = new SqlCommand($"GetCliente", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                


                // Obtener los datos por consola del cliente
                Console.WriteLine("-----------Datos Cliente------------");

                Cliente cliente = new Cliente();
                Console.WriteLine("Tipo Documento: "); //Recibe tipo entero
                cliente.TipoDocumento = int.Parse(Console.ReadLine());
                Console.WriteLine("Documento: ");
                cliente.Documento = Console.ReadLine();

                // Data Reader - Para leer los datos de los clientes
                command.Parameters.AddWithValue("@TipoDocumento", cliente.TipoDocumento);
                command.Parameters.AddWithValue("@Documento", cliente.Documento);
                SqlDataReader dr = command.ExecuteReader();
                string comentario = "";

                if(dr.Read())
                {
                    Console.WriteLine("Nombres: " + dr["Nombres"].ToString());
                    cliente.Nombres = dr["Nombres"].ToString();

                    Console.WriteLine("Apellidos: " + dr["Apellidos"].ToString());
                    cliente.Apellidos = dr["Apellidos"].ToString();

                    Console.WriteLine("Sexo: " + dr["Sexo"].ToString());
                    cliente.Sexo = dr["Sexo"].ToString();

                    Console.WriteLine("Fecha Nacimiento: " + dr["FechaNacimiento"].ToString());
                    cliente.FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());

                    Console.WriteLine("Comentario: " + dr["Comentario"].ToString());
                    comentario = dr["Comentario"].ToString();

                    Console.WriteLine("Monto: " + decimal.Parse(dr["balance"].ToString())); // Balance actual del cliente
                    cliente.balance = (decimal)dr["balance"];

                }
                else
                {
                    Console.WriteLine("Nombres: ");
                    cliente.Nombres = Console.ReadLine();
                    Console.WriteLine("Apellidos: ");
                    cliente.Apellidos = Console.ReadLine();
                    cliente.Estado = 0;
                    Console.WriteLine("Sexo: ");
                    cliente.Sexo = Console.ReadLine();
                    Console.WriteLine("Fecha Nacimiento: ");
                    string FechaNacimiento = Console.ReadLine();
                    cliente.FechaNacimiento = DateTime.Parse(FechaNacimiento);
                    Console.WriteLine("Comentario: ");
                    comentario = Console.ReadLine();

                }

                dr.Close();

                // Conseguir los datos del movimiento por consola

                Console.WriteLine("-----------Datos Movimientos------------");

                Console.WriteLine("Monto: "); // Monto que se le agrega al cliente
                cliente.balance = decimal.Parse(Console.ReadLine());

                Movimientos movimiento = new Movimientos(); // Creamos una instancia de la clase movimientos

                Console.WriteLine("Dbcr: ");
                movimiento.Dbcr = Console.ReadLine();

                Console.WriteLine("Tipo Transaccion: "); // recibe 1 o -1
                movimiento.TipoTransaccion = int.Parse(Console.ReadLine());



                //Haciendo el upsert de los clientes en la base de datos
                command.Parameters.Clear();
                command.CommandText = "ppUpsertCliente2";

                command.Parameters.AddWithValue("@comentario", comentario);
                command.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                command.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                command.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                command.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);

                command.Parameters.AddWithValue("@TipoDocumento", cliente.TipoDocumento);
                command.Parameters.AddWithValue("@Documento", cliente.Documento);
                command.Parameters.AddWithValue("@Balance", cliente.balance);
                command.Parameters.AddWithValue("@TipoTransaccion", movimiento.TipoTransaccion);

                transaction = connection.BeginTransaction(); // Inicio de la Transaccion
                command.Transaction = transaction;
                command.ExecuteNonQuery();


                // Try Catch para la transaccion de InsertMovivimientos

                try
                {
                    command.Parameters.Clear(); // Limpair los parametros antes de utilizar el otro procedure

                    // Stored Procedure ppInserMovimientos - Insertamos los movimientos en la base de datos

                    command.CommandText = "ppInsertMovimientos"; // actualizamos el nombre del command a utilizar

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
                    transaction.Rollback();
                    throw;
                    
                }
                
                // CONDICION DE SALIDA DEL BUCLE
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
