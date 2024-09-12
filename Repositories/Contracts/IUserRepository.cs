using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<PagedList<User>> GetAllUserAsync(UserParameters userParameters, bool trackChanges);
        Task<User> GetOneUserByIdAsync(int id, bool trackChanges);
        void CreateOneUserAsync(User user);
        void UpdateOneUserAsync(User user);
        void DeleteOneUserAsync(User user);
    }
}
