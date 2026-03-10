using Microsoft.EntityFrameworkCore;
using PizzaApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApp.Data
{
    public class PizzaContext : DbContext
    {
        // Mevcut constructor (çalışma zamanı için)
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) { }

        // Boş constructor (tasarım zamanı/migration için)
        public PizzaContext() { }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PizzaSpecial> Specials { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Address> Addresses { get; set; }

        // Tasarım zamanında SQLite kullanacağını belirt
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=pizza.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PizzaTopping>().HasKey(pt => new { pt.PizzaId, pt.ToppingId });
        }

        public static void SeedData(PizzaContext context)
        {
            // =========================================
            // PIZZA SPECIALS - eksik olanlari ekle
            // =========================================
            var mevcutPizzaIsimleri = context.Specials
                .Select(s => s.Name)
                .ToHashSet();

            var pizzaSeed = new List<PizzaSpecial>
            {
                new PizzaSpecial { Name = "Napoli", BasePrice = 130m, ImageUrl = "img/pizzas/napoli.jpg", Description = "Mozzarella, Domates Sosu, Ançuez, Zeytin, Kekik" },
                new PizzaSpecial { Name = "Capricciosa", BasePrice = 150m, ImageUrl = "img/pizzas/capricciosa.jpg", Description = "Mozzarella, Domates Sosu, Mantar, Zeytin, Jambon, Enginar" },
                new PizzaSpecial { Name = "Margherita", BasePrice = 120m, ImageUrl = "img/pizzas/margherita.jpg", Description = "Mozzarella, Domates Sosu, Fesleğen" },                new PizzaSpecial { Name = "Pepperoni", BasePrice = 140m, ImageUrl = "img/pizzas/pepperoni.jpg", Description = "Mozzarella, Domates Sosu, Pepperoni" },
                new PizzaSpecial { Name = "Dört Peynirli", BasePrice = 155m, ImageUrl = "img/pizzas/four_cheese.jpg", Description = "Mozzarella, Cheddar, Parmesan, Gorgonzola, Domates Sosu" },
                new PizzaSpecial { Name = "Vejetaryen", BasePrice = 145m, ImageUrl = "img/pizzas/vegetarian.jpg", Description = "Mozzarella, Domates Sosu, Mantar, Biber, Zeytin, Soğan" },
                new PizzaSpecial { Name = "Tavuklu BBQ", BasePrice = 160m, ImageUrl = "img/pizzas/bbq_chicken.jpg", Description = "Mozzarella, BBQ Sosu, Tavuk, Soğan, Mısır" },
                new PizzaSpecial { Name = "Sucuklu", BasePrice = 150m, ImageUrl = "img/pizzas/sucuklu.jpg", Description = "Mozzarella, Domates Sosu, Sucuk, Zeytin" },
                new PizzaSpecial { Name = "Deniz Mahsullü", BasePrice = 175m, ImageUrl = "img/pizzas/seafood.jpg", Description = "Mozzarella, Domates Sosu, Karides, Kalamar, Zeytin" },
                new PizzaSpecial { Name = "Meksika", BasePrice = 165m, ImageUrl = "img/pizzas/mexican.jpg", Description = "Mozzarella, Domates Sosu, Kıyma, Mısır, Jalapeno, Soğan" },
                new PizzaSpecial { Name = "Supreme", BasePrice = 180m, ImageUrl = "img/pizzas/supreme.jpg", Description = "Mozzarella, Domates Sosu, Sucuk, Mantar, Zeytin, Biber, Soğan" },
                new PizzaSpecial { Name = "Kavurmalı", BasePrice = 170m, ImageUrl = "img/pizzas/kavurmali.jpg", Description = "Mozzarella, Domates Sosu, Kavurma, Biber, Soğan" },
                new PizzaSpecial { Name = "Ton Balıklı", BasePrice = 160m, ImageUrl = "img/pizzas/tuna.jpg", Description = "Mozzarella, Domates Sosu, Ton Balığı, Mısır, Zeytin" },
                new PizzaSpecial { Name = "Mantarlı", BasePrice = 135m, ImageUrl = "img/pizzas/funghi.jpg", Description = "Mozzarella, Domates Sosu, Mantar, Kekik" },
                new PizzaSpecial { Name = "Akdeniz", BasePrice = 150m, ImageUrl = "img/pizzas/mediterranean.jpg", Description = "Mozzarella, Domates Sosu, Zeytin, Beyaz Peynir, Domates, Fesleğen" }
            };

            foreach (var pizza in pizzaSeed)
            {
                if (!mevcutPizzaIsimleri.Contains(pizza.Name))
                {
                    context.Specials.Add(pizza);
                }
            }

            // =========================================
            // TOPPINGS - eksik olanlari ekle
            // =========================================
            var mevcutToppingIsimleri = context.Toppings
                .Select(t => t.Name)
                .ToHashSet();

            var toppingSeed = new List<Topping>
            {
                new Topping { Name = "Mozzarella Peyniri", Price = 10m },
                new Topping { Name = "Pepperoni", Price = 10m },
                new Topping { Name = "Tavuk", Price = 10m },
                new Topping { Name = "Mantar", Price = 10m },
                new Topping { Name = "Zeytin", Price = 10m },
                new Topping { Name = "Biber", Price = 10m },
                new Topping { Name = "Soğan", Price = 10m },
                new Topping { Name = "Mısır", Price = 10m },
                new Topping { Name = "Jambon", Price = 10m },
                new Topping { Name = "Enginar", Price = 10m }
            };

            foreach (var topping in toppingSeed)
            {
                if (!mevcutToppingIsimleri.Contains(topping.Name))
                {
                    context.Toppings.Add(topping);
                }
            }

            context.SaveChanges();
        }
    }
}
