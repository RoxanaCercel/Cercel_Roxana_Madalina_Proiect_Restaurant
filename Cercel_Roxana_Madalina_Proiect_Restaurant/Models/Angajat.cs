using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Models
{
    public class Angajat
    {
        public int AngajatId { get; set; }
        [Display(Name = "Nume Angajat")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Campul nume trebuie sa inceapa cu litera mare si sa fie completat numai cu litere!"), Required, StringLength(50, MinimumLength = 3)]
        public string Nume { get; set; }
        [Display(Name = "Prenume Angajat")]
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Campul prenume trebuie sa inceapa cu litera mare si sa fie completat numai cu litere!"), Required, StringLength(50, MinimumLength = 3)]
        public string Prenume { get; set; }
        [Display(Name = "Numar Telefon")]
        [Required, StringLength(15, MinimumLength = 10)]
        public string NrTelefon { get; set; }
        public int Salariu { get; set; }
        [Display(Name = "Ore suplimentare")]
        public int OreSupl { get; set; }
        public ICollection<Comanda> Comenzi { get; set; }
    }
}
