
namespace Repositories.Contracts
{
    public interface IRepositoryManager
    { //birçok repoya buradan erişim vericez
        //unit of work pattern
        IUserRepository User {  get; }
        IJobRepository Job { get; }
        IRoleRepository Role { get; }
        IDepartmentRepository Department { get; }
        Task SaveAsync();
    }
}
