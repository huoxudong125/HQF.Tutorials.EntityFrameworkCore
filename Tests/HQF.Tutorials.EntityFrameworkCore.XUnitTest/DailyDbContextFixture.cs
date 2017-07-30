using HQF.Daily.Web.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace HQF.Tutorials.EntityFrameworkCore.XUnitTest
{
    public class DailyDbContextFixture : IDisposable
    {

        private  DailyDbContext _dailyDbContext;


        public DailyDbContext DailyDbContext
        {
            get
            {
                if (_dailyDbContext == null) {
                    _dailyDbContext = GetDailyDbContext();
                }
                return _dailyDbContext;
            }
        }

        public string SqlConnectionStr
        {
            get
            {
                return @"Server=(localdb)\mssqllocaldb;Database=daily_db_Test;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;";
            }
        }

        private DailyDbContext GetDailyDbContext()
        {
            var serviceProvider = new ServiceCollection()
               .AddEntityFrameworkSqlServer()
               .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<DailyDbContext>();

            builder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=Daily_db_{Guid.NewGuid()};Trusted_Connection=True;MultipleActiveResultSets=true")
                    .UseInternalServiceProvider(serviceProvider);

            var context = new DailyDbContext(builder.Options);

            return context;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~DailyDbContextFixture() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
