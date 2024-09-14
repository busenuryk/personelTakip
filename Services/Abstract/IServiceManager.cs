using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        //bütün servileri orginize etmek için 
        IUserService UserService { get; }
        IJobsService jobsService { get; }
        IDepartmentService departmentService { get; }
        IRoleService roleService { get; }

    }
}
