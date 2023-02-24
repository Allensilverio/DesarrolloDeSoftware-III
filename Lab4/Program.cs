using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcion = "";
            bool Run = true;

            while(Run)
            {
                // Conexion con la Base de Datos

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Cn"].ConnectionString);
                connection.Open(); // abro la conexion con la base de datos
                Console.WriteLine(connection.State);
                SqlTransaction transaction = null;


                SqlCommand command = new SqlCommand($"spUpsertFeligreses", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                Console.WriteLine("---------- INSERTAR FELIGRESES ---------");

                // Conseguir informacion feligreses por consola
                Feligreses feligreses = new Feligreses();

                Console.WriteLine("Tipo Documento: ");
                feligreses.tipodocumento = int.Parse(Console.ReadLine());

                Console.WriteLine("Documento: ");
                feligreses.documento = Console.ReadLine();


                Console.WriteLine("Nombres: ");
                feligreses.nombres = Console.ReadLine();

                Console.WriteLine("Apellidos: ");
                feligreses.apellidos = Console.ReadLine();

                Console.WriteLine("Fecha Nacimiento: ");
                string FechaNacimiento = Console.ReadLine();
                feligreses.fechaNacimiento = DateTime.Parse(FechaNacimiento);

                Console.WriteLine("Fecha Ultima Confesion: ");
                string FechaUltimaConfesion = Console.ReadLine();
                feligreses.fechaUltimaConfecion = DateTime.Parse(FechaUltimaConfesion);

                Console.WriteLine("Fecha Ultima Visita: ");
                string FechaUltimaVisita = Console.ReadLine();
                feligreses.fechaUltimaVisita = DateTime.Parse(FechaUltimaVisita);

                Console.WriteLine("Estado Civil: ");
                feligreses.estadoCivil = Console.ReadLine();

                Console.WriteLine("Sexo: ");
                feligreses.sexo = Console.ReadLine();

                Console.WriteLine("Diezma: ");
                feligreses.diezma = int.Parse(Console.ReadLine());

                Console.WriteLine("Pertenece a Comunidad: ");
                feligreses.perteneceAcomunidad = int.Parse(Console.ReadLine());

                Console.WriteLine("----- Insertar Pecado ------");

                // Insertar Pecado
                Evento pecado = new Evento();

                Console.WriteLine("Tipo de Pecado: ");
                pecado.TipoEvento = int.Parse(Console.ReadLine());

                Console.WriteLine("Nota: ");
                pecado.Nota = Console.ReadLine();

                Console.WriteLine("Descripcion: ");
                pecado.Descripcion = Console.ReadLine();


                transaction = connection.BeginTransaction(); // Inicio de la Transaccion
                command.Transaction = transaction;

                try
                {
                    command.Parameters.AddWithValue("@TipoDocumento", feligreses.tipodocumento);
                    command.Parameters.AddWithValue("@Documento", feligreses.documento);;
                    command.Parameters.AddWithValue("@Nombres", feligreses.nombres);
                    command.Parameters.AddWithValue("@Apellidos", feligreses.apellidos);
                    command.Parameters.AddWithValue("@FechaNacimiento", feligreses.fechaNacimiento);
                    command.Parameters.AddWithValue("@FechaUltimaConfecion", feligreses.fechaUltimaConfecion);
                    command.Parameters.AddWithValue("@EstadoCivil", feligreses.estadoCivil);
                    command.Parameters.AddWithValue("@Sexo", feligreses.sexo);
                    command.Parameters.AddWithValue("@Diezma", feligreses.diezma);
                    command.Parameters.AddWithValue("@PerteneceComunidad", feligreses.PerteneceAComunidad);
                    command.Parameters.AddWithValue("@UltimaVisitaIglesia", feligreses.fechaUltimaVisita);
                    

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                    command.CommandText = "spInsertEvento";
                    command.Parameters.AddWithValue("@TipoEvento", pecado.TipoEvento);
                    command.Parameters.AddWithValue("@Nota", pecado.Nota);
                    command.Parameters.AddWithValue("@Descripcion", pecado.Descripcion);

                    
                    command.ExecuteNonQuery();

                    transaction.Commit();

                }
                catch (Exception)
                {
                    transaction.Rollback();

                    throw;
                }











                //Condicion para salir del bucle

                Console.WriteLine("Quieres salir (s/n)");
                opcion = Console.ReadLine();

                if(opcion.ToLower() == "s")
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
