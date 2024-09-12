using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        //lazy loading
        private readonly Lazy<IUserRepository> _userRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _userRepository  = new Lazy<IUserRepository>(() => new UserRepository(context));
        }
        /*RepositoryManager ile IRepositoryManager'ı IoC'ye kayıt edicez
         RepositoryManager üzerinde bir istek gelidğinde concrete ifade vericez 
        bu ifade RepositoryContext'i çözücek ve doğrudan sınıf içerisinde kullanabilicez
        burada merkezi bir new'leme yapıyoruz*/

        //Manager'dan kullanıcı istediği anda newleme yaparak _userRepository'den newlenmiş halini dönücez 
        //nesne sadece kullanıldığı anda new'lenir aksi halde bir şey olmaz
        public IUserRepository User => _userRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
