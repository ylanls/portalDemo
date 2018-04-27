using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal.Domain.Model
{
    public class SubDomainModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public Int32 Type { get; set; }
        public Int32 Count { get; set; }
        public Int32 Total { get; set; }
        public string SubDate { get; set; }
    }
}
