using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Models
{
    public class Rezervare
    {
        public int RezervareID { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        [Display(Name = "Ora și Data Rezervării")]
        public DateTime OraData { get; set; } 
    }
}
