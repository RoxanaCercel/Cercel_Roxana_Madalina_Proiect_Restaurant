using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Models
{
    public class Comanda
    {
        public int ComandaID { get; set; }
        public int MeniuID { get; set; }
        public Meniu Meniu { get; set; }
        public int ClientiID { get; set; }
        public Client Client { get; set; }
        public int AngajatID { get; set; }
        public Angajat Angajat { get; set; }
        [Display(Name = "Detalii")]
        public string nota { get; set; }
        [Display(Name = "Număr bucăți")]
        public int buc { get; set; }

    }
}
