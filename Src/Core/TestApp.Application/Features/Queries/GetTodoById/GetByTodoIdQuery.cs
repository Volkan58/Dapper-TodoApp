using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application.Dto;
using TestApp.Application.Wrappers;

namespace TestApp.Application.Features.Queries.GetTodoById
{
   public class GetByTodoIdQuery:IRequest<ServiceResponse<TodoViewDto>>
    {
        public int ID { get; set; }


    }
}
