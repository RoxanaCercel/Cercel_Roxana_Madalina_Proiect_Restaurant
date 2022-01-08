using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cercel_Roxana_Madalina_Proiect_Restaurant.Data;
using Cercel_Roxana_Madalina_Proiect_Restaurant.Models;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Pages.Rezervari
{
    public class IndexModel : PageModel
    {
        private readonly Cercel_Roxana_Madalina_Proiect_Restaurant.Data.Cercel_Roxana_Madalina_Proiect_RestaurantContext _context;

        public IndexModel(Cercel_Roxana_Madalina_Proiect_Restaurant.Data.Cercel_Roxana_Madalina_Proiect_RestaurantContext context)
        {
            _context = context;
        }

        public IList<Rezervare> Rezervare { get;set; }

        public async Task OnGetAsync()
        {
            Rezervare = await _context.Rezervare
                .Include(c=>c.Client)
                .ToListAsync();
        }
    }
}
