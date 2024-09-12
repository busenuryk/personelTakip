using Entities.DataTransferObject;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class JobsRepository : RepositoryBase<Jobs>, IJobRepository
    {
        public JobsRepository(RepositoryContext _context) : base(_context)
        {
        }

        public async void RAddOneJobAsync(Jobs jobs) => Add(jobs);
        public async void RDeleteOneJobAsync(Jobs jobs) => Delete(jobs);
        public async void RUpdateOneJobAsync(Jobs jobs) => Update(jobs);

        public async Task<PagedList<Jobs>> RGetAllJobsAsync(JobsParameters jobsParameters, bool trackChanges)
        {
            var jobs = await GetAll(trackChanges)
                .Search(jobsParameters.SearchTerm)
                .OrderBy(b => b.UserId)
                .ToListAsync();

            return PagedList<Jobs>
                .ToPagedList(jobs,
                jobsParameters.PageNumber,
                jobsParameters.PageSize);
        }

        public async Task<JobsDto> RGetByFilter(JobsParameters jobsParameters)
        {
            throw new NotImplementedException();
        }

        public async Task<JobsDto> RGetFilteredAllAsync(JobsParameters jobsParameters, bool trackChange)
        {
            throw new NotImplementedException();
        }

        public async Task<Jobs> RGetJobByIdAsync(JobsParameters jobsParameters, bool trackChanges) =>
            await FindByCondition(b => b.Id.Equals(id), trackCahnges)
            .SingleOrDefaultAsync();

    }
}
