using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using log4net;
using log4net.Config;

namespace FeminicidiosWebApp
{
    /// <summary>
    /// Summary description for FeminicidiosWebService
    /// </summary>
    [WebService(Namespace = "http://intec.edu.do")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FeminicidiosWebService : System.Web.Services.WebService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]

        public Respuesta RegistrarDatos(Verdugo verdugo, Indicio indicio)
        {
            // Creando el objeto de respuesta
            Respuesta respuesta = new Respuesta()
            {
                codigo = 0,
                tipo = 1

            };

            //Enviando la data a la base de datos
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Cn"].ConnectionString);
            connection.Open(); // abro la conexion con la base de datos
            Console.WriteLine(connection.State);
            SqlTransaction transaction = null;

            //Insertar verdugo
            SqlCommand command = new SqlCommand($"ppInsertVerdugo", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                transaction = connection.BeginTransaction(); // Inicio de la Transaccion
                command.Transaction = transaction;
                command.CommandText = "ppInsertVerdugo";

                command.Parameters.AddWithValue("@TipoDocumento", verdugo.TipoDocumento);
                command.Parameters.AddWithValue("@Documento", verdugo.Documento); ;
                command.Parameters.AddWithValue("@Nombres", verdugo.Nombres);
                command.Parameters.AddWithValue("@Apellidos", verdugo.Apellidos);
                command.Parameters.AddWithValue("@FechaNacimiento", verdugo.FechaNacimiento);
                command.Parameters.AddWithValue("@FechaEvento", verdugo.FechaEvento);
                command.Parameters.AddWithValue("@CantidadHijos", verdugo.CantidadHijos);
                command.Parameters.AddWithValue("@Vivo", verdugo.Vivo);
                command.Parameters.AddWithValue("@Preso", verdugo.Preso);

                command.ExecuteNonQuery();
                command.Parameters.Clear();


                command.CommandText = "ppInsertIndicio";

                command.Parameters.AddWithValue("@Descripcion", indicio.Descripcion);
                command.Parameters.AddWithValue("@TipoDocumento", verdugo.TipoDocumento);
                command.Parameters.AddWithValue("@Documento", verdugo.Documento);

                command.ExecuteNonQuery();
                command.Parameters.Clear();

                transaction.Commit();
                log.Info("Se hizo el commit");
                respuesta.mensaje = "Se envio el mensaje con exito";
            }

            catch (Exception)
            {
                transaction.Rollback();
                log.Info("La transaccion fallo");
                respuesta.mensaje = "Ha ocurrido un error";

                throw;
            }


            return respuesta;

        }


    }
}
