using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOdatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDataEntities myDataEntities1 = new MyDataEntities();
            myDataEntities1.tblClientes.Add(new tblClientes()
            {
                Nombres = "Allen",
                Apellidos = "Silverio",
                Documento = "123456",
                TipoDocumento = 2,
                Balance = 0,
                Comentario = "N/A",
                Estado = 0,
                FechaIngreso = DateTime.Now,
                FechaNacimiento = DateTime.Now,
                Sexo = "M",
                Id = 0,
      

            });

            myDataEntities1.SaveChanges();
        }
    }
}
