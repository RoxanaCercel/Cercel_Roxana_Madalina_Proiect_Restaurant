using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cercel_Roxana_Madalina_Proiect_Restaurant.Data;
using Cercel_Roxana_Madalina_Proiect_Restaurant.Models;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Pages.Rezervari
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
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ClientId", "Nume","ClientId","Prenume");
            return Page();
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rezervare.Add(Rezervare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
