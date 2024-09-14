using Services.Contracts;
using Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        //lazy loading burada da yapıyoruz
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IJobsService> _jobsService;
        private readonly Lazy<IDepartmentService> _depertmentService;
        private readonly Lazy<IRoleService> _roleService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            //new'leme işlemini buarda yapıyoruz
            _userService = new Lazy<IUserService>(() => new UserManager(repositoryManager, mapper));
            _jobsService = new Lazy<IJobsService>(() => new JobsManager(repositoryManager, mapper));
            _roleService = new Lazy<IRoleService>(() => new RoleManager(repositoryManager, mapper));
            _depertmentService = new Lazy<IDepartmentService>(() => new DepertmentService(repositoryManager, mapper));


        }

        public IUserService UserService => throw new NotImplementedException();

        public IJobsService jobsService => throw new NotImplementedException();

        public IDepartmentService departmentService => throw new NotImplementedException();

        public IRoleService roleService => throw new NotImplementedException();
    }   
}