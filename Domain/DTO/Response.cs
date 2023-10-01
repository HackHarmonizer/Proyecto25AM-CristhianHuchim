using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class Response<T>
    {
        //Constructor
        public Response() { }
        //3
        public Response(T data, string message = null)
        {
            Succeded = true;
            Message = message;
            Result = data;
        }
        //2
        public Response(string message, bool succeded)
        {
            Succeded = succeded;
            Message = message;

        }

        //3 variables
        public bool Succeded { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
