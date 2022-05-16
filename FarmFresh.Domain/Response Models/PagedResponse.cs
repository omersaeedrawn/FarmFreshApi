using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Models.Response_Models
{
    public class PagedResponse<T> : GenericResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public PagedResponse(T data, int count, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.TotalRecords = count;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
        }
    }
}
