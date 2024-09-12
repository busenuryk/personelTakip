using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    { //birçok repoya buradan erişim vericez
        //unit of work pattern
        IUserRepository User {  get; }
        Task SaveAsync();
    }
}
