using StudentRegistration.Services.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.Implementations
{
    public class ApiResponse<T> : IApiResponses<T>
    {
        public T Data { get; set; }

        public string Message { get; set; }

        public int Status { get; set; }
    }
}
