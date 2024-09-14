using Repositories.Contracts;

namespace Repositories.EfCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        //lazy loading
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IJobRepository> _jobRepository;
        private readonly Lazy<IRoleRepository> _roleRepository;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;


        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _userRepository  = new Lazy<IUserRepository>(() => new UserRepository(context));
            _jobRepository = new Lazy<IJobRepository>(() => new JobsRepository(context));
            _roleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(context));
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(context));

        }
        /*RepositoryManager ile IRepositoryManager'ı IoC'ye kayıt edicez
         RepositoryManager üzerinde bir istek gelidğinde concrete ifade vericez 
        bu ifade RepositoryContext'i çözücek ve doğrudan sınıf içerisinde kullanabilicez
        burada merkezi bir new'leme yapıyoruz*/

        //Manager'dan kullanıcı istediği anda newleme yaparak _userRepository'den newlenmiş halini dönücez 
        //nesne sadece kullanıldığı anda new'lenir aksi halde bir şey olmaz
        public IUserRepository User => _userRepository.Value;

        public IJobRepository Job => _jobRepository.Value;

        public IRoleRepository Role => _roleRepository.Value;

        public IDepartmentRepository Department => _departmentRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
