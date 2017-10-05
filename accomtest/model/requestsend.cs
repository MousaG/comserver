using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accomtest.model
{
    public class requestsend
    {
        public int cocode { get; set; }
        public int formcode { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
        public long recordCount { get; set; }
    }
}
