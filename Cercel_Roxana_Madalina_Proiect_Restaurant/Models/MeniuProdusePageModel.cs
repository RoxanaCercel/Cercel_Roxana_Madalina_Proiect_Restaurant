using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Cercel_Roxana_Madalina_Proiect_Restaurant.Data;


namespace Cercel_Roxana_Madalina_Proiect_Restaurant.Models
{
    public class MeniuProdusePageModel : PageModel
    {
        public List<AtribuireProdusData> AtribuireProdusDataList;
        public void PopulateAtribuireProdusData(Cercel_Roxana_Madalina_Proiect_RestaurantContext context,
        Meniu meniu)
        {
            var allCategories = context.Produs;
            var meniuProduse = new HashSet<int>(
            meniu.MeniuProduse.Select(c => c.ProdusID)); //
            AtribuireProdusDataList = new List<AtribuireProdusData>();
            foreach (var cat in allCategories)
            {
                AtribuireProdusDataList.Add(new AtribuireProdusData
                {
                    ProdusID = cat.ID,
                    Nume = cat.ProdusNume,
                    Assigned = meniuProduse.Contains(cat.ID)
                });
            }
        }
        public void UpdateMeniuProduse(Cercel_Roxana_Madalina_Proiect_RestaurantContext context,
        string[] selectedCategories, Meniu meniuToUpdate)
        {
            if (selectedCategories == null)
            {
                meniuToUpdate.MeniuProduse = new List<MeniuProdus>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var meniuProduse = new HashSet<int>
            (meniuToUpdate.MeniuProduse.Select(c => c.Produs.ID));
            foreach (var cat in context.Produs)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!meniuProduse.Contains(cat.ID))
                    {
                        meniuToUpdate.MeniuProduse.Add(
                        new MeniuProdus
                        {
                            MeniuID = meniuToUpdate.MeniuID,
                            ProdusID = cat.ID
                        });
                    }
                }
                else
                {
                    if (meniuProduse.Contains(cat.ID))
                    {
                        MeniuProdus courseToRemove
                        = meniuToUpdate
                        .MeniuProduse
                       .SingleOrDefault(i => i.ProdusID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
