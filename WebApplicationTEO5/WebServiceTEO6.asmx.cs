using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplicationTEO5
{
    /// <summary>
    /// Summary description for WebServiceTEO6
    /// </summary>
    [WebService(Namespace = "http://intec.edu.do/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceTEO6 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]

        public int Sumar(int num1, int num2)
        {
            return num1 + num2;
        }

        [WebMethod]

        public Respuesta RegistrarCliente(Cliente cliente)
        {
            Respuesta respuesta = new Respuesta() {codigo=10000 };
            return respuesta;
        }
    }
}

