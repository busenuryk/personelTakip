using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EfCore
{
    public class DepartmentRepository : IRepositoryBase<Department>, IDepartmentRepository
    {
        private RepositoryContext context;

        public DepartmentRepository(RepositoryContext context)
        {
            this.context = context;
        }
    }
}
