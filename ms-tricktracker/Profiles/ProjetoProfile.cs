using AutoMapper;
using ms_tracker.Models;
using ms_tracker.Models.Dtos;

namespace ms_tracker.Profiles
{
    public class ProjetoProfile : Profile
    {
        public ProjetoProfile()
        {
            CreateMap<AddProjetoDto, Projeto>();
            CreateMap<Projeto, ReadProjetoDto>();
            CreateMap<UpdateProjetoDto, Projeto>();
            CreateMap<Projeto, UpdateProjetoDto>();
        }
        
    }
}