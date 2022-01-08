using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cercel_Roxana_Madalina_Proiect_Restaurant.Data;
using Cercel_Roxana_Madalina_Proiect_Restaurant.Models;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Pages.Rezervari
{
    public class EditModel : PageModel
    {
        private readonly Cercel_Roxana_Madalina_Proiect_Restaurant.Data.Cercel_Roxana_Madalina_Proiect_RestaurantContext _context;

        public EditModel(Cercel_Roxana_Madalina_Proiect_Restaurant.Data.Cercel_Roxana_Madalina_Proiect_RestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rezervare = await _context.Rezervare.FirstOrDefaultAsync(m => m.RezervareID == id);

            if (Rezervare == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID", "NumeClient");
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID", "PrenumeClient");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Rezervare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RezervareExists(Rezervare.RezervareID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RezervareExists(int id)
        {
            return _context.Rezervare.Any(e => e.RezervareID == id);
        }
    }
}
