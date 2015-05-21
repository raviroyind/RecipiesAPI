using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MealService.Models
{
    public class RecipieDTO
    {
        public int Id { get; set; }
        public string RecipieName { get; set; }
        public string ChefName { get; set; }
    }
    public class RecipieDetailDTO
    {
        public int Id { get; set; }
        public string RecipieName { get; set; }
        public string Description { get; set; }
        public int PreparationTime { get; set; }
        public int Serves { get; set; }
        public string OriginCountry { get; set; }
        public string ChefName { get; set; }
    }
}