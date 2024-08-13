using Project1.Data;
using Project1.Models;
using Project1.Repository.IRepository;

namespace Project1.Repository
{
    public class ProductRepository: Repository<Product> , IProductRepository
    {
        private readonly ApplicationDbContext context;
        public ProductRepository(ApplicationDbContext context):base(context)
        {
            this.context = context;
        }
    }
}
