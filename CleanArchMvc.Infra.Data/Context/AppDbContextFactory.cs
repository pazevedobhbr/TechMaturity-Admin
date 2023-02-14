using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CleanArchMvc.Infra.Data.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>

    {

        public ApplicationDbContext CreateDbContext(string[] args)

        {

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer("Server=localhost;Database=CleanArchMvcDb1;User Id=SA;Password=12345678};TrustServerCertificate=true");

            return new ApplicationDbContext(optionsBuilder.Options);

        }

    }
}

