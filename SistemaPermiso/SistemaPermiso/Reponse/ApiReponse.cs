using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPermiso.Api.Reponse
{
    public class ApiReponse<T>
    {
        //Sending data object 
        public ApiReponse(T data)
        {
            Data = data;

        }

        public T Data { get; set; }
    }
}
