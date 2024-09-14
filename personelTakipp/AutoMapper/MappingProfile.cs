using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;

namespace personelTakipp.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<source, destination>();
            CreateMap<UserDtoForUpdate, User>().ReverseMap();
            CreateMap<User, UserDto>(); //Dto şeklinde bir nesneyi transfer edebiliriz
            CreateMap<UserDtoForInsertion, User>().ReverseMap();
        }
    }
}
