using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Models.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Batch> Batch { get; set; }
        public DbSet<BusinessUnit> BusinessUnit { get; set; }
        public DbSet<Attribute> Attribute { get; set; }
        public DbSet<FileAttribute> FileAttribute { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<ReadUser> ReadUser { get; set; }
        public DbSet<ReadGroup> ReadGroup { get; set; }

    }
}
