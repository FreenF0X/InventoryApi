using DataAccess;

namespace BuisnessLogic.Tests
{
    public class RecreateTest
    {
        private readonly ApplicationContext dbContext;

        public RecreateTest()
        {
            dbContext = new DbContextFactory().RecreateDataBase().Result;
        }

        [Fact]
        public async void MergeCellsTestSuccess()
        {
            Assert.True(true);

        }
    }
}