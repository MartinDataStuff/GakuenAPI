using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace GakuenDLL.Entity
{
    public class Schedule : AbstractEntity
    {
        public List<SchoolEvent> SchoolEvents { get; set; } = new List<SchoolEvent>();
        public string Day { get; set; }
    }
}
