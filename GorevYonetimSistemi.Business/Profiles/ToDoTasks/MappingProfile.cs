using AutoMapper;
using GorevYonetimSistemi.Business.DTOs;
using GorevYonetimSistemi.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.Business.Profiles.ToDoTasks
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoTask, ToDoTaskDto>().ReverseMap();
        }
    }
}
