using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Linq.Expressions;
using static Entities.Exceptions.NotFoundException;

namespace Services
{
    public class UserManager(IRepositoryManager _manager, IMapper _mapper) : IUserService
    {
        //public async Task<UserDto> SGetByFilter(Expression<Func<UserDto, bool>> expression){}

        public async Task<UserDto> SAddOneUserAsync(UserDtoForInsertion userDto)
        {
            var entity =  _mapper.Map<User>(userDto);
            _manager.User.CreateOneUserAsync(entity);
            await _manager.SaveAsync();
            return _mapper.Map<UserDto>(entity);
        }

        public async Task SDeleteOneUserAsync(int id, bool trackchanges)
        {
            var entity = await GetOneUserAndCheckExist(id, trackchanges);
            _manager.User.DeleteOneUserAsync(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<UserDto> users, MetaData metaData)> SGetAllUsersAsync(UserParameters userParameters, bool trackChanges)
        {
            var usersWithMetaData = await _manager.User.GetAllUserAsync(userParameters, trackChanges);
            var userDto = _mapper.Map<IEnumerable<UserDto>>(usersWithMetaData);
            return (userDto, usersWithMetaData.MetaData);
        }

        public Task<UserDto> SGetByFilterAsync(Expression<Func<UserDto, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> SGetByIdAsync(int id)
        {
            var entity = await GetOneUserAndCheckExist(id, false);
            return _mapper.Map<UserDto>(entity);
        }

        public async Task<UserDto> SGetFilteredAllAsync(Expression<Func<UserDto, bool>> expression, bool trackChange)
        {
            throw new NotImplementedException();
        }

        public async Task SUpdateOneUserAsync(int id, UserDtoForUpdate userDto, bool trackChanges)
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
                string message = $"Tho user with id: {id} could notfound";
                throw new Exception(message); //hem de kullanıcıya gösteriyoruz
                throw new UserNotFoundException(id);
            }

            return entity;
        }
    }
}

