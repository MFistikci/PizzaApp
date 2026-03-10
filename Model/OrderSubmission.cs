using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using PizzaApp;

namespace PizzaApp.Model
{
    public class OrderSubmission
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();

        public string OrderNumber { get; set; }
    }
}
