using FactoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FactoryAPI
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider) 
        {
            using (var context = new FactoryDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FactoryDbContext>>()))
            {
                if (context.Items.Any()) 
                {
                    return;
                }
                context.Items.AddRange(
                    new Item
                    {
                        Name = "Apple",
                        Description = "A nice, round apple. Perfect for... munching on, I suppose.",
                        Price = 0.79M
                    },
                    new Item
                    {
                        Name = "Banana",
                        Description = "Ideal for monkeying around.",
                        Price = 0.99M
                    },
                    new Item
                    {
                        Name = "Pineapple",
                        Description = "The tropical rebel with a spiky crown, packing a zesty punch that screams, \"Let's fiesta!\".",
                        Price = 2.99M
                    },
                    new Item
                    {
                        Name = "Watermelon",
                        Description = "The heavyweight champ of summer.",
                        Price = 1.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
