using Entities.DataTransferObject;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {   //Service katmanından geldiği belli olsun diye başlarına S ekledim.
        //foreach ile dolaşabileceğimiz bir ifade
        Task<(IEnumerable<UserDto> users, MetaData metaData)>  SGetAllUsersAsync(UserParameters userParameters, bool trackChanges);
        Task<UserDto> SGetFilteredAllAsync(Expression<Func<UserDto, bool>> expression, bool trackChange);
        Task<UserDto> SAddOneUserAsync(UserDtoForInsertion userDto);
        Task SDeleteOneUserAsync(int id, bool trackchanges);
        Task SUpdateOneUserAsync(int id, UserDtoForUpdate userDto, bool trackChanges);
        Task<UserDto> SGetByIdAsync(int id);
        Task<UserDto> SGetByFilterAsync(Expression<Func<UserDto, bool>> expression);
        //Automapper için düzenelemler yaptık
    }
}
