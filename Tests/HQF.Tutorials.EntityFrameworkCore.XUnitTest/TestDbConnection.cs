using HQF.Daily.Web.DAL;
using HQF.Daily.Web.Domains;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace HQF.Tutorials.EntityFrameworkCore.XUnitTest
{
    public class TestDbConnection : IClassFixture<DailyDbContextFixture>
    {
        private ITestOutputHelper _outputHelper { get; }
        private DailyDbContextFixture _fixture;
       // private readonly IMessageSink _diagnosticMessageSink;

        public TestDbConnection(DailyDbContextFixture fixture, ITestOutputHelper outputHelper )
        {
            _fixture = fixture;
            _outputHelper = outputHelper;
           // _diagnosticMessageSink = diagnosticMessageSink;
        }

        [Fact]
        public void TestUsingServiceProvider()
        {
            // In-memory database only exists while the connection is open
            // var connection = new SqliteConnection("DataSource=:memory:");
            //var connection = new SqlConnection(_fixture.SqlConnectionStr);
            //connection.Open();

            try
            {
                _outputHelper.WriteLine("Try to Test.");

                //var options = new DbContextOptionsBuilder<DailyDbContext>()
                //    //.UseSqlite(connection)
                //    .UseSqlServer(connection)                    
                //    .Options;

                // Create the schema in the database
                using (var context = _fixture.DailyDbContext)
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = _fixture.DailyDbContext)
                {

                    context.WorkAreas.Add(new WorkArea() { Name = "工区1" });
                    context.SaveChanges();
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = _fixture.DailyDbContext)
                {
                    Assert.Equal(1, context.WorkAreas.Count());
                    Assert.Equal("工区1", context.WorkAreas.Single().Name);
                }
            }

            finally
            {
                //connection.Close();
            }

        }


        [Fact]
        public void TestUsingSqlConnection()
        {
            // In-memory database only exists while the connection is open
            // var connection = new SqliteConnection("DataSource=:memory:");
            var connection = new SqlConnection(_fixture.SqlConnectionStr);
            connection.Open();

            try
            {
                _outputHelper.WriteLine("Try to Test.");

                var options = new DbContextOptionsBuilder<DailyDbContext>()
                    //.UseSqlite(connection)
                    .UseSqlServer(connection)
                    .Options;

                // Create the schema in the database
                using (var context = _fixture.DailyDbContext)
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = _fixture.DailyDbContext)
                {
                    context.Database.EnsureCreated();
                    context.Projects.Add(new Project() { Name = "Project1" });
                    context.SaveChanges();
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = _fixture.DailyDbContext)
                {
                    context.Database.EnsureCreated();
                    Assert.Equal(1, context.Projects.Count());
                    Assert.Equal("Project1", context.Projects.Single().Name);
                }
            }

            finally
            {
                connection.Close();
            }

        }





    }
}
