using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace Project.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                new Product
                {
                    Name = "AMD Ryzen 7 3700X",
                    Description = "8-Core, 16-Thread Unlocked Desktop Processor with Wraith Prism LED Cooler",
                    Category = "CPU Processors",
                    Price = 295
                },
                new Product
                {
                    Name = "AMD Ryzen 7 3800X",
                    Description = "8-Core, 16-Thread Unlocked Desktop Processor with Wraith Prism LED Cooler",
                    Category = "CPU Processors",
                    Price = 340
                },
                new Product
                {
                    Name = "AMD Ryzen 9 3900XT",
                    Description = "12-core, 24-Threads Unlocked Desktop Processor Without Cooler",
                    Category = "CPU Processors",
                    Price = 458
                },
                new Product
                {
                    Name = "XFX Radeon RX 580",
                    Description = "GTS XXX Edition 1386MHz OC+, 8GB GDDR5, VR Ready, Dual BIOS, 3xDP HDMI DVI, AMD Graphics Card (RX-580P8DFD6)",
                    Category = "Graphics Cards",
                    Price = 220
                },
                 new Product
                 {
                     Name = "ZOTAC Gaming GeForce RTX 2060",
                     Description = "6GB GDDR6 192-bit Gaming Graphics Card, Super Compact, ZT-T20600H-10M",
                     Category = "Graphics Cards",
                     Price = 340
                 },
                 new Product
                 {
                     Name = "MSI Gaming GeForce GTX 1660",
                     Description = "192-Bit HDMI/DP 6GB GDRR5 HDCP Support DirectX 12 Dual Fan VR Ready OC Graphics Card (GTX 1660 VENTUS XS 6G OC)",
                     Category = "Graphics Cards",
                     Price = 220
                 },
                 new Product
                 {
                     Name = "Corsair Vengeance LPX 16GB",
                     Description = "2x8GB) DDR4 DRAM 3200MHz C16 Desktop Memory Kit - Black",
                     Category = "Memory",
                     Price = 60
                 },
                 new Product
                 {
                     Name = "Corsair Vengeance RGB Pro 32GB",
                     Description = "(2x16GB) DDR4 3200 (PC4-25600) C16 Desktop Memory - Black",
                     Category = "Memory",
                     Price = 130
                 },
                 new Product
                 {
                     Name = "Corsair Vengeance RGB PRO 16GB",
                     Description = "(2x8GB) DDR4 3200MHz C16 LED Desktop Memory - Black",
                     Category = "Memory",
                     Price = 75
                 }
                 );
                context.SaveChanges();
            }
        }
    }
}
