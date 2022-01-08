using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cercel_Roxana_Madalina_Proiect_Restaurant.Models;

namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Data
{
    public class Cercel_Roxana_Madalina_Proiect_RestaurantContext : DbContext
    {
        public Cercel_Roxana_Madalina_Proiect_RestaurantContext (DbContextOptions<Cercel_Roxana_Madalina_Proiect_RestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<Cercel_Roxana_Madalina_Proiect_Restaurant.Models.Meniu> Meniu { get; set; }

        public DbSet<Cercel_Roxana_Madalina_Proiect_Restaurant.Models.Client> Client { get; set; }

        public DbSet<Cercel_Roxana_Madalina_Proiect_Restaurant.Models.Produs> Produs { get; set; }

        public DbSet<Cercel_Roxana_Madalina_Proiect_Restaurant.Models.Angajat> Angajat { get; set; }

        public DbSet<Cercel_Roxana_Madalina_Proiect_Restaurant.Models.Rezervare> Rezervare { get; set; }

        public DbSet<Cercel_Roxana_Madalina_Proiect_Restaurant.Models.Comanda> Comanda { get; set; }

    }
}
