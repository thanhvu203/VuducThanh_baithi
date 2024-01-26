using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Orderweb.Model;

namespace Orderweb.Data
{
    public class OrderwebContext : DbContext
    {
        public OrderwebContext (DbContextOptions<OrderwebContext> options)
            : base(options)
        {
        }

        public DbSet<Orderweb.Model.OrderTbl> OrderTbl { get; set; } = default!;
    }
}
