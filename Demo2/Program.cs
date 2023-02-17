using Demo2.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            tblClientesTableAdapter adapter = new tblClientesTableAdapter();
            adapter.Insert("Pepe", "Martinez", 1, DateTime.Now.AddYears(20), DateTime.Now, "M","N/A", 15, "3", 100M);


        
        }
    }
}
