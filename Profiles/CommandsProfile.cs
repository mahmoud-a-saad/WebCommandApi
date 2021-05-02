using AutoMapper;
using WebCommand.Dtos;
using WebCommand.Models;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //source -> target
            CreateMap<Command,CommandReadDTO>();
            CreateMap<CommandCreateDTO,Command>();
            CreateMap<CommandUpdateDTO,Command>();
            CreateMap<Command,CommandUpdateDTO>();
        }


    }


}
