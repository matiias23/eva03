using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api2.Models;

    public class Itemcontext : DbContext
    {
        public Itemcontext (DbContextOptions<Itemcontext> options)
            : base(options)
        {
        }

        public DbSet<Api2.Models.Item> Item { get; set; } = default!;
    }
