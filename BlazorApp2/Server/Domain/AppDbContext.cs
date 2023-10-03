using BlazorApp2.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Server.Domain
{
    public class AppDbContext:DbContext
    {
        public DbSet<Element> Elements { get; set; }

        public DbSet<Row> Rows { get; set; }
        public DbSet<Form> Forms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Db");
        }
    }
}
