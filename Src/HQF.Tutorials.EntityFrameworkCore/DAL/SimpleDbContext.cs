using HQF.Daily.Web.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using JetBrains.Annotations;

namespace HQF.Tutorials.EntityFrameworkCore.DAL
{
    public class SimpleDbContext:DbContext
    {
        public SimpleDbContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<WorkItemPrice> WorkItemPrices { get; set; }

    }
}
