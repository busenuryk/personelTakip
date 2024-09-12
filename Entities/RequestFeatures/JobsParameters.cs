using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class JobsParameters : RequestParameters
    {
        public string? SearchTerm { get; set; }
        public JobsParameters()
        {
            OrderBy = "id";
        }
    }
}
