namespace MealService.Domain.Migrations
{
    using MealService.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MealService.Models.MealServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MealService.Models.MealServiceContext context)
        {
            context.Chefs.AddOrUpdate(x => x.Id,
            new Chef() { Id = 1, Name = "Anthony Bourdain" },
            new Chef() { Id = 2, Name = "Heston Blumenthal" },
            new Chef() { Id = 3, Name = "Julia Child" },
            new Chef() { Id = 4, Name = "Thomas Keller" },
            new Chef() { Id = 5, Name = "Charlie Trotter" },
            new Chef() { Id = 6, Name = "Emeril Lagasse" },
            new Chef() { Id = 7, Name = "Paul Bucose" },
            new Chef() { Id = 8, Name = "Marco Pierre White" }
            );

            context.Recipies.AddOrUpdate(x => x.Id,
            new Recipie()
            {
                Id = 1,
                RecipieName = "Seafood paella",
                Description = "The sea is lapping just by your feet, a warm breeze whips the tablecloth around your legs and a steamy pan of paella sits in front of you. Shrimp, lobster, mussels and cuttlefish combine with white rice and various herbs, oil and salt in this Valencian dish to send you immediately into holiday mode.",
                PreparationTime = 20,
                Serves = 5,
                OriginCountry = "Spain",
                ChefId=1
            },
           new Recipie()
           {
               Id = 2,
               RecipieName = "Som tam",
               Description = "To prepare Thailand's most famous salad, pound garlic and chilies with a mortar and pestle. Toss in tamarind juice, fish sauce, peanuts, dried shrimp, tomatoes, lime juice, sugar cane paste, string beans and a handful of grated green papaya.",
               PreparationTime = 45,
               Serves = 1,
               OriginCountry = "Thailand",
               ChefId=2
           },
           new Recipie()
           {
               Id = 3,
               RecipieName = "Chicken rice",
               Description = "Often called the “national dish” of Singapore, this steamed or boiled chicken is served atop fragrant oily rice, with sliced cucumber as the token vegetable. Variants include roasted chicken or soy sauce chicken. However it's prepared, it's one of Singapore's best foods.",
               PreparationTime = 75,
               Serves = 1,
               OriginCountry = "Singapore",
               ChefId=3
           },
           new Recipie()
           {
               Id = 4,
               RecipieName = "Ankimo",
               Description = "The monkfish/anglerfish that unknowingly bestows its liver upon upscale sushi fans is threatened by commercial fishing nets damaging its sea-floor habitat, so it’s possible ankimo won't be around for much longer.",
               PreparationTime = 145,
               Serves = 1,
               OriginCountry = "Japan",
               ChefId=4
           }
            );
        }
    }
}
