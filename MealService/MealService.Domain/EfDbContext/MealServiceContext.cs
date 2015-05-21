using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MealService.Models
{
    public class MealServiceContext : DbContext
    {
    
        public MealServiceContext() : base("name=MealServiceContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<MealService.Domain.Entities.Chef> Chefs { get; set; }

        public System.Data.Entity.DbSet<MealService.Domain.Entities.Recipie> Recipies { get; set; }
    
    }
}
