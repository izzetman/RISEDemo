using RISEDemo.Core.Interfaces;
using RISEDemo.Core.Models;

namespace RISEDemo.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<UrunDetay>, IUrunRepository
    {
        public ProductRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}
