using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Common;
using TestApp.Domain.Entiti;

namespace TestApp.Application.Interfaces
{
    public interface ITodoRepository 
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo> GetByIdAsync(int id);
        Task<bool> AddAsync(Todo t);
        Task<bool> UpdateAsync(Todo t);
        Task<bool> RemoveAsync(int id);

    }
}
