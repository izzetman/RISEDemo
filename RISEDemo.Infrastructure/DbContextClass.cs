using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RISEDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISEDemo.Infrastructure
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<UrunDetay> Products { get; set; }
    }
}
