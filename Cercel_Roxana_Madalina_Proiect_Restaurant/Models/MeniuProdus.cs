using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Models
{
    public class MeniuProdus
    {
        public int ID { get; set; }
        public int MeniuID { get; set; }
        public Meniu Meniu { get; set; }
        public int ProdusID { get; set; }
        public Produs Produs { get; set; }
    }
}
