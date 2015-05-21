using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace MealService.Domain.Entities
{
    public class Chef
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
