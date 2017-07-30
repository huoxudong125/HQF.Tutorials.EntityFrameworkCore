using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace HQF.Tutorials.EntityFrameworkCore.XUnitTest
{
   public class TestSimleDbContext: IClassFixture<SimpleDbContextFixture>
    {
        private SimpleDbContextFixture _fixture;

        public TestSimleDbContext(SimpleDbContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Test()
        {

            using (var dbContext = _fixture.GetSimpleDbContext())
            {
                dbContext.Database.EnsureCreated();
                var count = dbContext.WorkItemPrices.Count();
                Assert.Equal(0, count);
            }

        }
    }
}
