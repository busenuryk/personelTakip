using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EfCore
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(RepositoryContext _context) : base(_context)
        {
        }
    }
}
