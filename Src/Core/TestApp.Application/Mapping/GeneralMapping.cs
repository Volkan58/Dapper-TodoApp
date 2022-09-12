using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application.Features.Commands;
using TestApp.Application.Features.Queries.GetTodoById;

//using TestApp.Application.Features.Queries.GetTodoById;

namespace TestApp.Application.Mapping
{
   public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<TestApp.Domain.Entiti.Todo, TestApp.Application.Dto.TodoViewDto>().ReverseMap();
            CreateMap<TestApp.Domain.Entiti.Todo, InsertTodoCommands>().ReverseMap();
            CreateMap<TestApp.Domain.Entiti.Todo, GetByTodoIdQuery>().ReverseMap();
            CreateMap<TestApp.Domain.Entiti.Todo, UpdateTodoCommands>().ReverseMap();
            CreateMap<TestApp.Domain.Entiti.Todo, RemoveTodoCommands>().ReverseMap();
            

        }
    }
}
