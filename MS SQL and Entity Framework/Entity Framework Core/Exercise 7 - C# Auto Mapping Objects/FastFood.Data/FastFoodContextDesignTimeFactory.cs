using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FastFood.Data
{
    public class FastFoodContextDesignTimeFactory : IDesignTimeDbContextFactory<FastFoodContext>
    {
        public FastFoodContext CreateDbContext(string[] args)
        {
            var bulder = new DbContextOptionsBuilder<FastFoodContext>();

            bulder.
                UseSqlServer("Server=DESKTOP-QE96OKD\\SQLEXPRESS;Database=FastFood;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new FastFoodContext(bulder.Options);
        }
    }
}