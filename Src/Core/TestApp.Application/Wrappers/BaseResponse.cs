using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Application.Wrappers
{
   public class BaseResponse
    {
        //Servisimizden Geriye Her Türlü Bu Objeyi döneceğiz.

        public int Id { get; set; }
        public bool Success { get; set; }
        public String Message { get; set; }
    }
}
