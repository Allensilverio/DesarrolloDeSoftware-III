using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Guerra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILog log = LogManager.GetLogger(typeof(Program));

            string opcion = "";
            bool Run = true;

            while (Run)
            {
                // Conexion con la Base de Datos

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Cn"].ConnectionString);
                connection.Open(); // abro la conexion con la base de datos
                Console.WriteLine(connection.State);
                SqlTransaction transaction = null;


                SqlCommand command = new SqlCommand($"spUpsertGuerra", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                Console.WriteLine("---------- INSERTAR Guerra ---------");

                // Conseguir informacion feligreses por consola
                Guerra guerra = new Guerra();

                Console.WriteLine("Codigo Guerra: ");
                guerra.CodigoGuerra = Console.ReadLine();

                Console.WriteLine("Pais 1:");
                guerra.Pais1 = Console.ReadLine();


                Console.WriteLine("Pais 2: ");
                guerra.Pais2 = Console.ReadLine();

                Console.WriteLine("Fecha Inicio: ");
                string FechaInicio = Console.ReadLine();
                guerra.FechaInicio = DateTime.Parse(FechaInicio);

                Console.WriteLine("Fecha Fin: ");
                string FechaFin = Console.ReadLine();
                guerra.FechaFin = DateTime.Parse(FechaFin);

                Console.WriteLine("Pais Ganador: ");
                guerra.PaisGanador = Console.ReadLine();

                Console.WriteLine("Perdida Financiera: ");
                guerra.PerdidaFinaciera = int.Parse(Console.ReadLine());

                Console.WriteLine("Estado Guerrra: ");
                guerra.PerdidaFinaciera = int.Parse(Console.ReadLine());


                Console.WriteLine("----- Insertar Evento ------");

                // Insertar Evento
                Evento evento = new Evento();
                Console.WriteLine("Descripcion: ");
                evento.Descripcion = Console.ReadLine();

                Console.WriteLine("Tipo Evento: ");
                evento.TipoEvento = int.Parse(Console.ReadLine());

                Console.WriteLine("Fecha Evento: ");
                string FechaEvento = Console.ReadLine();
                evento.FechaEvento = DateTime.Parse(FechaEvento);

                Console.WriteLine("Cantidad Muertos: ");
                guerra.CantidadMuertos = int.Parse(Console.ReadLine());

                Console.WriteLine("Cantidad Presos: ");
                guerra.CantidadPresos = int.Parse(Console.ReadLine());

                Console.WriteLine("Cantidad Heridos: ");
                guerra.Heridos = int.Parse(Console.ReadLine());





                transaction = connection.BeginTransaction(); // Inicio de la Transaccion
                command.Transaction = transaction;

                try
                {
                    command.CommandText = "spUpsertGuerra";

                    command.Parameters.AddWithValue("@CodigoGuerra", guerra.CodigoGuerra);
                    command.Parameters.AddWithValue("@Pais1", guerra.Pais1); ;
                    command.Parameters.AddWithValue("@Pais2", guerra.Pais2);
                    command.Parameters.AddWithValue("@FechaInicio", guerra.FechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", guerra.FechaFin);
                    command.Parameters.AddWithValue("@PaisGanador", guerra.PaisGanador);
                    command.Parameters.AddWithValue("@CantidadMuertos", guerra.CantidadMuertos);
                    command.Parameters.AddWithValue("@CantidadPresos", guerra.CantidadPresos);
                    command.Parameters.AddWithValue("@PerdidaFinanciera", guerra.PerdidaFinaciera);
                    command.Parameters.AddWithValue("@EstadoGuerra", guerra.EstadoGuerra);
                    command.Parameters.AddWithValue("@Heridos", guerra.Heridos);


                    command.ExecuteNonQuery();
                    log.Info("Se ha insertado Una guerra");

                    command.Parameters.Clear();


                    command.CommandText = "spInsertEventos";

                    command.Parameters.AddWithValue("@CodigoGuerra", guerra.CodigoGuerra);
                    command.Parameters.AddWithValue("@TipoEvento", evento.TipoEvento);
                    command.Parameters.AddWithValue("@FechaEvento", evento.FechaEvento);
                    command.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                    command.Parameters.AddWithValue("@CantidadMuertos", guerra.CantidadMuertos);
                    command.Parameters.AddWithValue("@CantidadHeridos", guerra.Heridos);

                    command.ExecuteNonQuery();
                    log.Info("Se ha insertado un evento de Guerra");
                    command.Parameters.Clear();

                    transaction.Commit();
                    log.Info("Se hizo el commit");
                }

                catch (Exception)
                {
                    transaction.Rollback();

                    throw;
                }











                //Condicion para salir del bucle

                Console.WriteLine("Quieres salir (s/n)");
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
