using System;
using System.Collections.Generic;
using System.Text;
using HQF.Tutorials.EntityFrameworkCore.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HQF.Tutorials.EntityFrameworkCore.XUnitTest
{
    public class SimpleDbContextFixture
    {
       public SimpleDbContext GetSimpleDbContext()
        {
            var serviceProvider = new ServiceCollection()
               .AddEntityFrameworkSqlServer()
               .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<SimpleDbContext>();

            builder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=Simple_db_{Guid.NewGuid()};Trusted_Connection=True;MultipleActiveResultSets=true")
                    .UseInternalServiceProvider(serviceProvider);

            var context = new SimpleDbContext(builder.Options);

            return context;
        }
    }
}
