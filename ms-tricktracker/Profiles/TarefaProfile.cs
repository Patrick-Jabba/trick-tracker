using AutoMapper;
using ms_tracker.Models;
using ms_tracker.Models.Dtos.Tarefa;

namespace ms_tracker.Profiles;

  public class TarefaProfile : Profile
  {
      public TarefaProfile()
      {
          CreateMap<AddTarefaDto, Tarefa>();
          CreateMap<Tarefa, ReadTarefaDto>();
          CreateMap<UpdateTarefaDto, Tarefa>();
          CreateMap<Tarefa, UpdateTarefaDto>();
      }
  }