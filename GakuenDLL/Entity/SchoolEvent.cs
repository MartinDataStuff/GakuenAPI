using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GakuenDLL.Entity
{
    public class SchoolEvent : AbstractEntity
    {
        public int Minuttes { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
