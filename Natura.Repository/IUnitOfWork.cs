namespace Natura.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IOrderRepository Orders { get; }
        ICartRepository Carts { get; }
        Task<int> SaveChangesAsync();
    }
}
