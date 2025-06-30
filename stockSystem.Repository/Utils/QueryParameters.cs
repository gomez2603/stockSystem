using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.Repository.Utils
{
    public class QueryParameters
    {
        public Dictionary<string, string> Filters { get; set; } = new();
        public string OrderBy { get; set; } = "Id";
        public bool Desc { get; set; } = false;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

}
