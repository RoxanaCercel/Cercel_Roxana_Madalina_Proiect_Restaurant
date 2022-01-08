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

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Pages.Meniuri
{
    public class EditModel : MeniuProdusePageModel
    {
        private readonly Cercel_Roxana_Madalina_Proiect_Restaurant.Data.Cercel_Roxana_Madalina_Proiect_RestaurantContext _context;

        public EditModel(Cercel_Roxana_Madalina_Proiect_Restaurant.Data.Cercel_Roxana_Madalina_Proiect_RestaurantContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meniu Meniu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Meniu = await _context.Meniu
                .Include(b => b.MeniuProduse).ThenInclude(b => b.Produs)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.MeniuID == id);

            if (Meniu == null)
            {
                return NotFound();
            }
            PopulateAtribuireProdusData(_context, Meniu);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var meniuToUpdate = await _context.Meniu
                .Include(i => i.MeniuProduse)
                .ThenInclude(i => i.Produs)
                .FirstOrDefaultAsync(s => s.MeniuID == id);
            if (meniuToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Meniu>(meniuToUpdate,
            "Meniu",
            i => i.Denumire, i => i.Categorie,
            i => i.Gramaj, i => i.Pret))
            {
                UpdateMeniuProduse(_context, selectedCategories, meniuToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateMeniuProduse(_context, selectedCategories, meniuToUpdate);
            PopulateAtribuireProdusData(_context, meniuToUpdate);
            return Page();
            /*{
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _context.Attach(Meniu).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeniuExists(Meniu.MeniuID))
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

            private bool MeniuExists(int id)
            {
                return _context.Meniu.Any(e => e.MeniuID == id);
            }*/
        }
    }
}
