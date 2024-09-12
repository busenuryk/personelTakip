using Entities.DataTransferObject;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IJobRepository : IRepositoryBase<Jobs>
    {
        Task<PagedList<Jobs>> RGetAllJobsAsync(JobsParameters jobsParameters, bool trackChanges);
        Task<Jobs> RGetJobByIdAsync(JobsParameters jobsParameters, bool trackChanges);
        Task<JobsDto> RGetByFilter(JobsParameters jobsParameters);
        Task<JobsDto> RGetFilteredAllAsync(JobsParameters jobsParameters, bool trackChange);
        void RAddOneJobAsync(Jobs jobs);
        void RUpdateOneJobAsync(Jobs jobs);
        void RDeleteOneJobAsync(Jobs jobs);
    }
}
