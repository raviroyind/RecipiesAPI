using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealService.Domain.Entities
{
    public class Recipie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        [Required]
        public string RecipieName { get; set; }

        public string Description { get; set; }

        public int PreparationTime { get; set; }
        public int Serves { get; set; }
        public string OriginCountry { get; set; }
        
        //FK
        public int ChefId { get; set; }
        
        // Navigation property
        public virtual Chef Chef { get; set; }
    }
}
