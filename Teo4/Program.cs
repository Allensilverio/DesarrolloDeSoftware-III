using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Teo4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILog log = LogManager.GetLogger(typeof(Program)); // objeto del logger
            log.Info("Holaaaa");
            log.Error("Errorrrr");

            EventLog logEvt = new EventLog();
            logEvt.Source = "Application";
            logEvt.WriteEntry("SaludoSSSSSS", EventLogEntryType.Information);

            MyDataEntities1 myDataEntities1 = new MyDataEntities1();
            myDataEntities1.tblClientes.Add(new tblClientes()
            {
                Nombres = "Allen",
                Apellidos = "Silverio",
                Documento= "123456",
                Balance = 0,
                Comentario = "N/A",
                Estado = 0,
                FechaNacimiento = DateTime.Now.AddYears(-15),
                Sexo = "M"

            });

            myDataEntities1.SaveChanges();
        }
    }
}
