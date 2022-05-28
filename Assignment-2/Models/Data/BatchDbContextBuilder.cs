using Assignment_2.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Assignment_2.Data
{
    public class BatchDbContextBuilder : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("server=.;user id=sa;password=M8$tek12;database=Assignment1Db;TrustServerCertificate=true;");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
