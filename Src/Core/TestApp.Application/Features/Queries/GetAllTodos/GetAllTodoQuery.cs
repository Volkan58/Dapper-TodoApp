using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestApp.Application.Dto;
using TestApp.Application.Interfaces;
using TestApp.Application.Wrappers;

namespace TestApp.Application.Features.Queries.GetAllTodos
{
   public class GetAllTodoQuery:IRequest<ServiceResponse<List<TodoViewDto>>>
    {

        public class GetAllTodoQueryHandler : IRequestHandler<GetAllTodoQuery, ServiceResponse<List<TodoViewDto>>>
        {
            private readonly ITodoRepository _todorepository;
            private readonly IMapper mapper;

            public GetAllTodoQueryHandler(ITodoRepository todorepository, IMapper mapper)
            {
                _todorepository = todorepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<TodoViewDto>>> Handle(GetAllTodoQuery request, CancellationToken cancellationToken)
            {
                var todo = await _todorepository.GetAllAsync();
                var view = mapper.Map<List<TodoViewDto>>(todo);
                return new ServiceResponse<List<TodoViewDto>>(view);
            }
        }



    }
}
