using Mall.EntityFrameworkCore;

namespace Mall.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly MallDbContext _context;

        public TestDataBuilder(MallDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}