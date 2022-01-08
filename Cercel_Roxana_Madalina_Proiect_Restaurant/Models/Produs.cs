using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Models
{
    public class Produs
    {
        public int ID { get; set; }
        [Display(Name = "Nume Produs")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Campul nume produs trebuie sa inceapa cu litera mare si sa fie completat numai cu litere!"), Required, StringLength(50, MinimumLength = 3)]
        public string ProdusNume { get; set; }
        public ICollection<MeniuProdus> MeniuProduse { get; set; }
    }
}
