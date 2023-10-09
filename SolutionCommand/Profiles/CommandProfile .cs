using AutoMapper;
using Solution.Dtos;
using Solution.Models;

namespace Solution.Profiles
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
        {
            CreateMap<CommandCreatedDto, Command>();

            CreateMap<Command, CommandReadDto>();

            CreateMap<CommandUpdateDto, Command>();
        }
    }
}