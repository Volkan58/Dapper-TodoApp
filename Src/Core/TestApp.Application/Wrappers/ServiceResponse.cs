using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Application.Wrappers
{
   public class ServiceResponse<T>
    {

       
        public T Value { get; set; }

        //Bize Bu Value GÖnderilirse Dışardan Gelen Value ile bizimkini Set Edebiliriz.
        public ServiceResponse(T value)
        {
            Value = value;
        }

    
    }
}
