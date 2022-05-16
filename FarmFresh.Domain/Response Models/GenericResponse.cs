using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Models.Response_Models
{
    public class GenericResponse<T>
    {
        public GenericResponse()
        {
        }
        public GenericResponse(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}
