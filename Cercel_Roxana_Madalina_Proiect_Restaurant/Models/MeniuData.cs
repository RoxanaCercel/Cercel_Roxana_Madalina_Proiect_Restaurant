using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Models
{
    public class MeniuData
    {
        public IEnumerable<Meniu> Meniuri { get; set; }
        public IEnumerable<Produs> Produse { get; set; }
        public IEnumerable<MeniuProdus> MeniuProduse { get; set; }
    }
}
