using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace HQF.Tutorials.EntityFrameworkCore.XUnitTest
{
    public class DailyDbContextFixture
    {
        public ITestOutputHelper OutputHelper { get; }

        public DailyDbContextFixture(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;
        }


    }
}
