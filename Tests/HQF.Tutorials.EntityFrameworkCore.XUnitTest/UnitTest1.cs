using HQF.Daily.Web.DAL;
using HQF.Daily.Web.Domains;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace HQF.Tutorials.EntityFrameworkCore.XUnitTest
{
    public class UnitTest1 : IClassFixture<DailyDbContextFixture>
    {
        private ITestOutputHelper _outputHelper { get; }
        private DailyDbContextFixture _fixture;
        private readonly IMessageSink _diagnosticMessageSink;

        public UnitTest1(DailyDbContextFixture fixture, ITestOutputHelper outputHelper,
            IMessageSink diagnosticMessageSink)
        {
            _fixture = fixture;
            _outputHelper = outputHelper;
            _diagnosticMessageSink = diagnosticMessageSink;
        }

        [Fact]
        public void Test1()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                _outputHelper.WriteLine("Try to Test.");

                var options = new DbContextOptionsBuilder<DailyDbContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new DailyDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new DailyDbContext(options))
                {

                    context.WorkAreas.Add(new WorkArea() { Name = "工区1" });
                    context.SaveChanges();
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new DailyDbContext(options))
                {
                    Assert.Equal(1, context.WorkAreas.Count());
                    Assert.Equal("工区1", context.WorkAreas.Single().Name);
                }
            }

            finally
            {
                connection.Close();
            }

        }
               

    }
}
