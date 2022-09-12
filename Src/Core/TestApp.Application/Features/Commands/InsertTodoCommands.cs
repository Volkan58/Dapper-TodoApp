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

namespace TestApp.Application.Features.Commands
{
   public class InsertTodoCommands:IRequest<ServiceResponse<int>>
    {
       
        public String Title { get; set; }
        public String Description { get; set; }

        public TodoStatus Status { get; set; }

        public class InsertTodoCommandsHandler : IRequestHandler<InsertTodoCommands, ServiceResponse<int>>
        {
            private readonly ITodoRepository todorepository;
            private readonly IMapper mapper;

            public InsertTodoCommandsHandler(ITodoRepository todorepository, IMapper mapper)
            {
                this.todorepository = todorepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<int>> Handle(InsertTodoCommands request, CancellationToken cancellationToken)
            {
                var map = mapper.Map<Domain.Entiti.Todo>(request);
                var todol = await todorepository.AddAsync(map);
                return new ServiceResponse<int>(map.ID);
            }
        }
    }
}
