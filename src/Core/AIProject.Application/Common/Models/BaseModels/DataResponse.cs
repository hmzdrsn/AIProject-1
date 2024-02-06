using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Application.Common.Models.BaseModels
{
    public class DataResponse<T> where T : class
    {
        public string? Message { get; set; }
        public string? Status { get; set; }
        public T? Data { get; set; }

    }


}
