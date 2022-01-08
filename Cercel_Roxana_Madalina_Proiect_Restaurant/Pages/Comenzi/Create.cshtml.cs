using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cercel_Roxana_Madalina_Proiect_Restaurant.Data;
using Cercel_Roxana_Madalina_Proiect_Restaurant.Models;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Pages.Comenzi
{
    public class CreateModel : PageModel
    {
        private readonly Cercel_Roxana_Madalina_Proiect_Restaurant.Data.Cercel_Roxana_Madalina_Proiect_RestaurantContext _context;

        public CreateModel(Cercel_Roxana_Madalina_Proiect_Restaurant.Data.Cercel_Roxana_Madalina_Proiect_RestaurantContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ClientiID"] = new SelectList(_context.Set<Client>(), "ClientId", "Nume", "ClientId", "Prenume");
            ViewData["MeniuID"] = new SelectList(_context.Set<Meniu>(), "MeniuID", "Denumire");
            ViewData["AngajatID"] = new SelectList(_context.Set<Angajat>(), "AngajatId", "Nume", "AngajatId", "Prenume");
            return Page();
        }

        [BindProperty]
        public Comanda Comanda { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Comanda.Add(Comanda);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
