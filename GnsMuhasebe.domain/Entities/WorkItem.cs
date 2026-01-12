using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnsMuhasebe.domain.Entities
{
    public class WorkItem : BaseEntity
    {
        public int WorkId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
