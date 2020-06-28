using System.Collections.Generic;
using System.IO;
using System.Linq;
using DutchTreat.Data.Entities;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace DutchTreat.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext _ctx;

        private readonly IHostEnvironment
            _hosting; //different then the video.. Once again IHostingEnvironment throws errors. Hope this works. 

        public DutchSeeder(DutchContext ctx, IHostEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated(); //make sure the database is there first.

            if (!_ctx.Products.Any()) //verify products are there.
            {
                //need to create sample data
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(products);

                var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null)
                {
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    };
                }
                _ctx.SaveChanges();
            }
        }
    }
}