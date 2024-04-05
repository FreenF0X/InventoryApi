using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Tests
{
    internal class DbContextFactory
    {
        private ApplicationContext GetContext()
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseNpgsql("Host=localhost;Port=5432;Database=some-db;Username=postgres;Password=1");
            return new ApplicationContext(builder.Options);
        }

        public async Task<ApplicationContext> RecreateDataBase()
        {
            using (var context = GetContext())
            {
                context.RecreateDb();
            }
            return GetContext();
        }

        public ApplicationContext GetContextWithoutRecreateDb()
        {
            return GetContext();
        }
    }
}
