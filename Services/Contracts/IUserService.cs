using Entities.DataTransferObject;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        //foreach ile dolaşabileceğimiz bir ifade
        Task<(IEnumerable<UserDto> users, MetaData metaData)>  GetAllUsersAsync(UserParameters userParameters, bool trackChanges);
        Task<UserDto> GetOneUserByIdAsync(int id, bool trackChanges);
        Task<UserDto> AddOneUserAsync(UserDtoForInsertion userDto);
        Task DeleteOneUserAsync(int id, bool trackchanges);
        //Automapper için düzenelemler yaptık
        Task UpdateOneUserAsync(int id, UserDtoForUpdate userDto, bool trackChanges);
    }
}
