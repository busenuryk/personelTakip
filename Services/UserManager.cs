using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using static Entities.Exceptions.NotFoundException;

namespace Services
{
    public class UserManager : IUserService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public UserManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<UserDto> AddOneUserAsync(UserDtoForInsertion userDto)
        {
            var entity = _mapper.Map<User>(userDto);
            _manager.User.CreateOneUserAsync(entity);
            await _manager.SaveAsync();
            return _mapper.Map<UserDto>(entity);
        }

        public async Task DeleteOneUserAsync(int id, bool trackchanges)
        {
            var entity = await GetOneUserAndCheckExist(id, trackchanges);
            _manager.User.DeleteOneUserAsync(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<UserDto> users, MetaData metaData)> GetAllUsersAsync(UserParameters userParameters, bool trackChanges)
        {
            var usersWithMetaData= await _manager.User.GetAllUserAsync(userParameters,trackChanges);
            var userDto =  _mapper.Map<IEnumerable<UserDto>>(usersWithMetaData);
            return (userDto, usersWithMetaData.MetaData);
        }

        public async Task<UserDto> GetOneUserByIdAsync(int id, bool trackChanges)
        {
           var entity = await GetOneUserAndCheckExist(id, trackChanges);
            return _mapper.Map<UserDto>(entity);
        }

        public async Task UpdateOneUserAsync(int id,UserDtoForUpdate userDto, bool trackChanges)
        {
            var entity = await GetOneUserAndCheckExist(id, trackChanges);

            //mapper
            entity = _mapper.Map<User>(userDto);
            _manager.User.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<User> GetOneUserAndCheckExist(int id, bool trackChanges)
        {
            var entity = await _manager.User.GetOneUserByIdAsync(id, trackChanges);
            if (entity is null)
            {
                /* string message = $"Tho user with id: {id} could notfound";
                _logger.LogInfo(message); //mesaj ifadesini log'layıp
                throw new Exception(message); //hem de kullanıcıya gösteriyoruz*/
                throw new UserNotFoundException(id);

            }

            return entity;
        }
    }
}
