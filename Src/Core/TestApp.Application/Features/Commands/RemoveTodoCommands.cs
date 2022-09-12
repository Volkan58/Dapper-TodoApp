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
   public class RemoveTodoCommands:IRequest<ServiceResponse<bool>>
    {
        public int ID { get; set; }
        public class RemoveTodoCommandsHandler : IRequestHandler<RemoveTodoCommands, ServiceResponse<bool>>
        {
            private readonly ITodoRepository todorepository;
            private readonly IMapper mapper;

            public RemoveTodoCommandsHandler(ITodoRepository todorepository, IMapper mapper)
            {
                this.todorepository = todorepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<bool>> Handle(RemoveTodoCommands request, CancellationToken cancellationToken)
            {
                var map = mapper.Map<Domain.Entiti.Todo>(request);
                    var todol = await todorepository.RemoveAsync(map.ID);
                return new ServiceResponse<bool>(todol);



               

            }
        }
    }
}
