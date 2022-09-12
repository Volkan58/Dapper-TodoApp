using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Application.Wrappers
{
    public class TodoResponse<T> : ServiceResponse<T>
    {
        //Valueye Yolladığım Değerler gibi düşünebiliriz.
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public TodoResponse(T Value,string title, string description):base(Value)
        {
            Title = title;
            Description = description;
        }
        

    
    }
}






