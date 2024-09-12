using Entities.DataTransferObject;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EfCore.Extensions;
using System.Linq.Expressions;

namespace Repositories.EfCore
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    { //RepositoryBase'den
        public UserRepository(RepositoryContext _context) : base(_context)
        {
        }

        public async void RAddOneUserAsync(User user) => Add(user);
        public async void RDeleteOneUserAsync(User user) => Delete(user);
        public async void RUpdateOneUserAsync(User user) => Update(user);

        public async Task<PagedList<User>> RGetAllUserAsync(UserParameters userParameters, bool trackChanges)
        {
            var users = await GetAll(trackChanges)
            .Search(userParameters.SearchTerm)
            .OrderBy(b => b.UserId)
            .ToListAsync();

            return PagedList<User>.ToPagedList(users, userParameters.PageNumber, userParameters.PageSize);
        }

        public async Task<UserDto> RGetByFilter(UserParameters userParameters)
        {
            var user = await GetAll(false)
        .Where(u => u.UserId == userParameters.UserId) // Burada filtreleme yapabilirsiniz.
        .SingleOrDefaultAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<User> RGetByIdAsync(Expression<Func<User, bool>> expression) =>
            await GetById(b => b.UserId,false)
            .SingleOrDefaultAsync();

        public async Task<UserDto> RGetFilteredAllAsync(UserParameters userParameters, bool trackChange)
        {
            throw new NotImplementedException();
        }

    }
}
