using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnsMuhasebe.domain.Entities
{
    public class BaseEntity
    {
        private int Id { get; set; }
        private DateTime CreatedOn { get; set; }
        private DateTime UpdatedOn { get; set; }
        private bool IsDeleted { get; set; } = false;
    }
}
