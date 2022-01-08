using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Display(Name = "Nume Client")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Campul nume trebuie sa inceapa cu litera mare si sa fie completat numai cu litere!"), Required, StringLength(50, MinimumLength = 3)]
        public string Nume { get; set; }
        [Display(Name = "Prenume Client")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Campul prenume trebuie sa inceapa cu litera mare si sa fie completat numai cu litere!"), Required, StringLength(50, MinimumLength = 3)]
        public string Prenume { get; set; }
        public int Varsta { get; set; }
        public ICollection<Rezervare> Rezervarile { get; set; }
    }
}
