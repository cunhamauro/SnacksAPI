using ApiECommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiECommerce.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail>  OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Snacks", ImageUrl = "lanches1.png" },
                new Category { Id = 2, Name = "Combos", ImageUrl = "combos1.png" },
                new Category { Id = 3, Name = "Natural", ImageUrl = "naturais1.png" },
                new Category { Id = 4, Name = "Drinks", ImageUrl = "refrigerantes1.png" },
                new Category { Id = 5, Name = "Juices", ImageUrl = "sucos1.png" },
                new Category { Id = 6, Name = "Desserts", ImageUrl = "sobremesas1.png" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Standard Hamburger", ImageUrl = "hamburger1.jpeg", CategoryId = 1, Price = 15, Stock = 13, Available = true, BestSeller = true, Popular = true, Details = "Soft bread, seasoned beef hamburger, onion, mustard, and ketchup " },
                new Product { Id = 2, Name = "Standard Cheeseburger", ImageUrl = "hamburger3.jpeg", CategoryId = 1, Price = 18, Stock = 10, Available = true, BestSeller = false, Popular = true, Details = "Soft bread, seasoned beef hamburger, and cheese all around." },
                new Product { Id = 3, Name = "Standard Cheese Salad", ImageUrl = "hamburger4.jpeg", CategoryId = 1, Price = 19, Stock = 13, Available = true, BestSeller = false, Popular = false, Details = "Soft bread, seasoned beef hamburger, onion, lettuce, mustard, and ketchup " },
                new Product { Id = 4, Name = "Hamburger, fries, soda", ImageUrl = "combo1.jpeg", CategoryId = 2, Price = 25, Stock = 10, Available = false, BestSeller = false, Popular = true, Details = "Soft bread, seasoned beef hamburger and cheese, soda, and fries" },
                new Product { Id = 5, Name = "Cheeseburger, fries, soda", ImageUrl = "combo2.jpeg", CategoryId = 2, Price = 27, Stock = 13, Available = true, BestSeller = false, Popular = false, Details = "Soft bread, seasoned beef hamburger, soda, and fries, onion, mayonnaise, and ketchup" },
                new Product { Id = 6, Name = "Cheese Salad, fries, soda", ImageUrl = "combo3.jpeg", CategoryId = 2, Price = 28, Stock = 10, Available = true, BestSeller = false, Popular = true, Details = "Soft bread, seasoned beef hamburger, soda, and fries, onion, mayonnaise, and ketchup" },
                new Product { Id = 7, Name = "Natural Snack with greens", ImageUrl = "lanche_natural1.jpeg", CategoryId = 3, Price = 14, Stock = 13, Available = true, BestSeller = false, Popular = false, Details = "Whole grain bread with greens and tomato" },
                new Product { Id = 8, Name = "Natural Snack and cheese", ImageUrl = "lanche_natural2.jpeg", CategoryId = 3, Price = 15, Stock = 10, Available = true, BestSeller = false, Popular = true, Details = "Whole grain bread, greens, tomato, and cheese." },
                new Product { Id = 9, Name = "Vegan Snack", ImageUrl = "lanche_vegano1.jpeg", CategoryId = 3, Price = 25, Stock = 18, Available = true, BestSeller = false, Popular = false, Details = "Vegan snack with healthy ingredients" },
                new Product { Id = 10, Name = "Coca-Cola", ImageUrl = "coca_cola1.jpeg", CategoryId = 4, Price = 21, Stock = 7, Available = true, BestSeller = false, Popular = true, Details = "Coca-Cola soda" },
                new Product { Id = 11, Name = "Guaraná", ImageUrl = "guarana1.jpeg", CategoryId = 4, Price = 25, Stock = 6, Available = true, BestSeller = false, Popular = false, Details = "Guaraná soda" },
                new Product { Id = 12, Name = "Pepsi", ImageUrl = "pepsi1.jpeg", CategoryId = 4, Price = 21, Stock = 6, Available = true, BestSeller = false, Popular = false, Details = "Pepsi Cola soda" },
                new Product { Id = 13, Name = "Orange Juice", ImageUrl = "suco_laranja.jpeg", CategoryId = 5, Price = 11, Stock = 10, Available = true, BestSeller = false, Popular = false, Details = "Delicious and nutritious orange juice" },
                new Product { Id = 14, Name = "Strawberry Juice", ImageUrl = "suco_morango1.jpeg", CategoryId = 5, Price = 15, Stock = 13, Available = true, BestSeller = false, Popular = false, Details = "Fresh strawberry juice" },
                new Product { Id = 15, Name = "Grape Juice", ImageUrl = "suco_uva1.jpeg", CategoryId = 5, Price = 13, Stock = 10, Available = true, BestSeller = false, Popular = false, Details = "Natural grape juice without sugar made with the fruit" },
                new Product { Id = 16, Name = "Water", ImageUrl = "agua_mineral1.jpeg", CategoryId = 4, Price = 5, Stock = 10, Available = true, BestSeller = false, Popular = false, Details = "Fresh natural mineral water" },
                new Product { Id = 17, Name = "Chocolate Cookies", ImageUrl = "cookie1.jpeg", CategoryId = 6, Price = 8, Stock = 10, Available = true, BestSeller = false, Popular = true, Details = "Chocolate cookies with chocolate chunks" },
                new Product { Id = 18, Name = "Vanilla Cookies", ImageUrl = "cookie2.jpeg", CategoryId = 6, Price = 8, Stock = 13, Available = true, BestSeller = true, Popular = false, Details = "Delicious and crunchy vanilla cookies" },
                new Product { Id = 19, Name = "Swiss Pie", ImageUrl = "torta_suica1.jpeg", CategoryId = 6, Price = 10, Stock = 10, Available = true, BestSeller = false, Popular = true, Details = "Swiss pie with cream and layers of dulce de leche" }
            );
        }
    }
}
