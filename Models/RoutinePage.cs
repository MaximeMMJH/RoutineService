using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutineService.Models
{
    public class RoutinePage
    {
        public List<RoutineDBO> items { get; set; }
        public int TotalPages { get; set; }
        public int TotalElements { get; set; }
    }
}
