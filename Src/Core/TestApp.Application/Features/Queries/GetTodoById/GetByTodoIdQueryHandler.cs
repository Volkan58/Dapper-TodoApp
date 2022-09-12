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

namespace TestApp.Application.Features.Queries.GetTodoById
{
    public class GetByTodoIdQueryHandler : IRequestHandler<GetByTodoIdQuery, ServiceResponse<TodoViewDto>>
    {
        private readonly ITodoRepository todorepository;
        private readonly IMapper mapper;

        public GetByTodoIdQueryHandler(ITodoRepository todorepository, IMapper mapper)
        {
            this.todorepository = todorepository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<TodoViewDto>> Handle(GetByTodoIdQuery request, CancellationToken cancellationToken)
        {
            var todol = await todorepository.GetByIdAsync(request.ID);
            var dto = mapper.Map<TodoViewDto>(todol);
            return new ServiceResponse<TodoViewDto>(dto);

        }
    }
}
