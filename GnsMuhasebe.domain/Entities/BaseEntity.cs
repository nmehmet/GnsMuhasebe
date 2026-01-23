using Microsoft.EntityFrameworkCore.Update.Internal;

namespace GnsMuhasebe.domain.Entities
{
    public class BaseEntity
    {
        public int Id { get;private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime UpdatedOn { get; private set; }
        public bool IsDeleted { get; private set; } = false;

        public BaseEntity()
        {
            DateTime now = DateTime.Now;
            CreatedOn = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
        }
        public void UpdateDate()
        {
            DateTime now = DateTime.Now;
            UpdatedOn = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
        }
    }
}
