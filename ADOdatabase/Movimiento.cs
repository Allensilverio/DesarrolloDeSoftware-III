//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ADOdatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movimiento
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public int TipoDocumento { get; set; }
        public decimal Monto { get; set; }
        public int TipoTransaccion { get; set; }
        public string Dbcr { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaTransaccion { get; set; }
    }
}
