using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApplication.Models
{
    public class CageSelectViewModel
    {
        public int selectedId { get; set; }
        public IEnumerable<Cage> cages { get; set; }
    }
}
