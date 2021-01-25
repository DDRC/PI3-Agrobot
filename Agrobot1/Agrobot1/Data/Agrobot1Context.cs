using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Agrobot1.Models;

namespace Agrobot1.Data
{
    public class Agrobot1Context : DbContext
    {
        public Agrobot1Context (DbContextOptions<Agrobot1Context> options)
            : base(options)
        {
        }

        public DbSet<Agrobot1.Models.parte> parte { get; set; }
    }
}
