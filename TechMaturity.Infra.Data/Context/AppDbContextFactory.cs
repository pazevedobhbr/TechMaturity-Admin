using System;
//using MySql.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TechMaturity.Infra.Data.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>

    {

        public ApplicationDbContext CreateDbContext(string[] args)

        {

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer("Server=localhost;Database=TechMaturityCadDb;User Id=SA;Password=12345678};TrustServerCertificate=true");


            //optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=TechMaturityDb;User Id=SA;Password=12345678};TrustServerCertificate=true");


            return new ApplicationDbContext(optionsBuilder.Options);

        }

    }
}

