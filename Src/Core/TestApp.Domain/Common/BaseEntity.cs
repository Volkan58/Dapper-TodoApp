using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain.Common
{
  public  class BaseEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }

        public BaseEntity()
        {

        }
    }
}
