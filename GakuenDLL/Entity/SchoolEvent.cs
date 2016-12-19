using System.Collections.Generic;

namespace GakuenDLL.Entity
{
    public class SchoolEvent : AbstractEntity
    {
        public int Minuttes { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public Schedule Schedule { get; set; }
    }
}
