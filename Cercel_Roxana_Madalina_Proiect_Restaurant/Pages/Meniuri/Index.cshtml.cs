using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cercel_Roxana_Madalina_Proiect_Restaurant.Data;
using Cercel_Roxana_Madalina_Proiect_Restaurant.Models;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Pages.Meniuri
{
    public class IndexModel : PageModel
    {
        private readonly Cercel_Roxana_Madalina_Proiect_Restaurant.Data.Cercel_Roxana_Madalina_Proiect_RestaurantContext _context;

        public IndexModel(Cercel_Roxana_Madalina_Proiect_Restaurant.Data.Cercel_Roxana_Madalina_Proiect_RestaurantContext context)
        {
            _context = context;
        }

        public IList<Meniu> Meniu { get;set; }
        public MeniuData MeniuD { get; set; }
        public int MeniuID { get; set; }
        public int ProdusID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            MeniuD = new MeniuData();

            MeniuD.Meniuri = await _context.Meniu
 .Include(b => b.MeniuProduse)
 .ThenInclude(b => b.Produs)
 .AsNoTracking()
 .OrderBy(b => b.Denumire)
 .ToListAsync();
            if (id != null)
            {
                MeniuID = id.Value;
                Meniu meniu = MeniuD.Meniuri
                .Where(i => i.MeniuID == id.Value).Single();
                MeniuD.Produse = meniu.MeniuProduse.Select(s => s.Produs);
            }
        }
        /*
 public async Task OnGetAsync()
 {
     Meniu = await _context.Meniu.ToListAsync();
 }*/
    }
}
