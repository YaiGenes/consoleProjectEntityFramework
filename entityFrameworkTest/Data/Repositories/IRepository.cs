namespace entityFrameworkTest.Data.Repositories
{
    public interface IRepository<TEntity, in TKey> : IReadRepository<TEntity, TKey> , IWriteRepository<TEntity, TKey> where TEntity : class
    {

    }
}