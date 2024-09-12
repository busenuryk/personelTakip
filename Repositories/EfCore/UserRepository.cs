using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EfCore.Extensions;

namespace Repositories.EfCore
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    { //RepositoryBase'den
        public UserRepository(RepositoryContext context) : base(context)
        {

        }

        public async Task<PagedList<User>> GetAllUserAsync(UserParameters userParameters,
            bool trackChanges)
        {
            var users = await GetAll(trackChanges)
            .Search(userParameters.SearchTerm)
            .OrderBy(b => b.UserId)
            .ToListAsync();

            return PagedList<User>.ToPagedList(users, userParameters.PageNumber, userParameters.PageSize);
        }

        public async Task<User> GetOneUserByIdAsync(int id, bool trackChanges) =>
            await GetOneUser(b => b.UserId.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateOneUserAsync(User user) => Add(user);
        public void UpdateOneUserAsync(User user) => Update(user);
        public void DeleteOneUserAsync(User user) => Delete(user);
    }
}
