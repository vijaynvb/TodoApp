using AutoMapper;
using TodoAPI.DTO;
using TodoAPI.Models;

namespace TodoAPI.Configurations
{
    public class AutoMapperConfig : Profile
    {
        // SignupDTO = ApplicationUser
        public AutoMapperConfig()
        {
            CreateMap<ApplicationUser, SignUpDTO>().ReverseMap()
            .ForMember(f => f.UserName, t2 => t2.MapFrom(src => src.Email));
            CreateMap<Todo, TodoDTO>().ReverseMap();
        }
    }
}
