using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Models
{
    public class Meniu
    {
        public int MeniuID { get; set; }
        [Display(Name = "Denumire Meniu")]
        [Required, StringLength(150, MinimumLength = 3)]
        public string Denumire { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        public string Categorie { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        public string Gramaj { get; set; }
        public int Pret { get; set; }
        public ICollection<MeniuProdus> MeniuProduse { get; set; }
    }
}
