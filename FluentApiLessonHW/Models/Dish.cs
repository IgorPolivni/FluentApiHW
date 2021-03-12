using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FluentApiLesson.Models
{
    public class Dish : Entity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
