using Entities.DataTransferObject;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<PagedList<User>> RGetAllUserAsync(UserParameters userParameters, bool trackChanges);
        Task<User> RGetByIdAsync(Expression<Func<User, bool>> expression);
        Task<UserDto> RGetByFilter(UserParameters userParameters);
        Task<UserDto> RGetFilteredAllAsync(UserParameters userParameters, bool trackChange);
        void RAddOneUserAsync(User user);
        void RUpdateOneUserAsync(User user);
        void RDeleteOneUserAsync(User user);
    }
}
