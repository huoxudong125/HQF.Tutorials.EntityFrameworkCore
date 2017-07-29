using HQF.Daily.Web.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HQF.Daily.Web.DAL
{
    public class DailyDbContext : DbContext
    {
        public DailyDbContext(DbContextOptions<DailyDbContext> options) : base(options)
        {

        }

        public DbSet<Company> Companys { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<WorkItemPrice> WorkItemPrices { get; set; }

        public DbSet<WorkArea> WorkAreas { get; set; }

        public DbSet<WorkTeam> WorkTeams { get; set; }

        public DbSet<WorkItem> WorkItems { get; set; }

        public DbSet<WorkType> WorkTypes { get; set; }


        public DbSet<WorkUnit> WorkUnits { get; set; }

        public DbSet<WorkTypeUnit> WorkTypeUnits { get; set; }

        public DbSet<WorkItemProgress> WorkItemProgresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<WorkArea>().HasOne(t => t.Project).WithMany(a => a.WorkAreas).HasForeignKey(t => t.ProjectId);

            ///https://stackoverflow.com/a/40610532/1616023

            modelBuilder.Entity<WorkType>().HasOne(a => a.ParentWorkType).WithMany(b => b.SubWorkTypes).HasForeignKey(t => t.ParentId).IsRequired(false);

            #region WorkTypeUnit

            //http://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration
            //https://docs.microsoft.com/en-us/ef/core/modeling/relationships
            modelBuilder.Entity<WorkTypeUnit>().HasOne(a => a.WorkType).WithMany(b => b.WorkTypeUnits).HasForeignKey(t => t.WorkTypeId);
            modelBuilder.Entity<WorkTypeUnit>().HasOne(a => a.WorkUnit).WithMany(b => b.WorkTypeUnits).HasForeignKey(t => t.WorkUnitId);
            // modelBuilder.Entity<WorkTypeUnit>().HasKey(t => new { t.WorkTypeId, t.WorkUnitId });

            #endregion



            #region WorkItems

            modelBuilder.Entity<WorkItem>().HasOne(a => a.ParentWorkItem).WithMany(b => b.SubWorkItems).HasForeignKey(t => t.ParentId);

           // modelBuilder.Entity<WorkItem>().HasOne(a => a.WorkArea).WithMany(b => b.WorkItems).HasForeignKey(t => t.WorkAreaId);

            modelBuilder.Entity<WorkItem>().HasOne(a => a.WorkType).WithMany(b => b.WorkItems).HasForeignKey(t => t.WorkTypeId);

            #endregion



            #region WorkItemPrices

           // modelBuilder.Entity<WorkItemPrice>().HasOne(a => a.WorkTeam).WithMany(b => b.WorkItemPrices).HasForeignKey(t => t.WorkTeamId);
           //// modelBuilder.Entity<WorkItemPrice>().HasOne(a => a.WorkTypeUnit).WithMany(b => b.WorkItemPrices).HasForeignKey(t=>t.WorkTypeUnitId);
           // modelBuilder.Entity<WorkItemPrice>().HasOne(a => a.WorkItem).WithMany(b => b.WorkItemPrices).HasForeignKey(t => t.WorkItemId);



            #endregion


            #region WorkItemProgresses

            modelBuilder.Entity<WorkItemProgress>().HasKey(t => t.Id);
            modelBuilder.Entity<WorkItemProgress>().HasOne(a => a.WorkItemPrice).WithMany(b => b.WorkItemProgresses).HasForeignKey(t => t.WorkItemPriceId);

            #endregion


        }

    }
}
