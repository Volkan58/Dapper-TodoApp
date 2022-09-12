using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Common;

namespace TestApp.Domain.Entiti
{
   public class Todo:BaseEntity
    {
      
        public String Title { get; set; }
        public String Description { get; set; }
      
        public TodoStatus Status { get; set; }
     
    }
}
