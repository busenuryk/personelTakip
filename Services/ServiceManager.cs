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
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            //new'leme işlemini buarda yapıyoruz
            _userService = new Lazy<IUserService>(() => new UserManager(repositoryManager, mapper));
        }
        public IUserService UserService => _userService.Value;
    }
}
