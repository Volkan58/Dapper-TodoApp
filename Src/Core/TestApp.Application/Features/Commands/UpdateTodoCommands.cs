using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestApp.Application.Interfaces;
using TestApp.Application.Wrappers;

namespace TestApp.Application.Features.Commands
{
    public class UpdateTodoCommands : IRequest<ServiceResponse<int>>
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }

        public TodoStatus Status { get; set; }

        public class UpdateTodoCommandsHandler : IRequestHandler<UpdateTodoCommands, ServiceResponse<int>>
        {
            private readonly ITodoRepository todorepository;
            private readonly IMapper mapper;

            public UpdateTodoCommandsHandler(ITodoRepository todorepository, IMapper mapper)
            {
                this.todorepository = todorepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<int>> Handle(UpdateTodoCommands request, CancellationToken cancellationToken)
            {
                var map = mapper.Map<Domain.Entiti.Todo>(request);
                var todol = await todorepository.UpdateAsync(map);
                return new ServiceResponse<int>(map.ID);
            }
        }
    }
}