using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.Services
{
    public class BaseFilter
    {
        public int numPage { get; set; }
        public int pageSize { get; set; }

        public int totalPage { get; set; }

        public string orderby { get; set; }
        public bool asc { get; set; }
    }
}
