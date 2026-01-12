using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnsMuhasebe.domain.Entities
{
    public class WorkItem : BaseEntity
    {
        private int WorkId { get; set; }
        private int ProductId { get; set; }
        private Product Product { get; set; } = null!;
        private int Quantity { get; set; }
    }
}
