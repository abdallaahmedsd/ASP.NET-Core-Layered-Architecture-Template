namespace HR.Service.IServices
{
    public interface IBaseService
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
