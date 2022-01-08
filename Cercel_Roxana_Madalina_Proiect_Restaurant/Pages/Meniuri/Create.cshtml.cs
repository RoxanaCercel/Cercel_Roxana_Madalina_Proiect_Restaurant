using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cercel_Roxana_Madalina_Proiect_Restaurant.Data;
using Cercel_Roxana_Madalina_Proiect_Restaurant.Models;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Pages.Meniuri
{
    public class CreateModel : MeniuProdusePageModel
    {
        private readonly Cercel_Roxana_Madalina_Proiect_Restaurant.Data.Cercel_Roxana_Madalina_Proiect_RestaurantContext _context;

        public CreateModel(Cercel_Roxana_Madalina_Proiect_Restaurant.Data.Cercel_Roxana_Madalina_Proiect_RestaurantContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var meniu = new Meniu();
            meniu.MeniuProduse = new List<MeniuProdus>();
            PopulateAtribuireProdusData(_context, meniu);
            return Page();
        }

        [BindProperty]
        public Meniu Meniu { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
 {
            var newMeniu = new Meniu();
            if (selectedCategories != null)
            {
                newMeniu.MeniuProduse = new List<MeniuProdus>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new MeniuProdus
                    {
                        ProdusID = int.Parse(cat)
                    };
                    newMeniu.MeniuProduse.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Meniu>(newMeniu,
             "Meniu",
            i => i.Denumire, i => i.Categorie,
            i => i.Gramaj, i => i.Pret))
            {
                _context.Meniu.Add(newMeniu);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAtribuireProdusData(_context, newMeniu);
            return Page();
        }
        /*{
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Meniu.Add(Meniu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }*/
    }
}
