using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class Response<T>
    {
        public Response()
        {
                
        }

        public Response(T data)
        {
            Data = data;
        }

        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string[] Errors { get; set; }
    }
}
