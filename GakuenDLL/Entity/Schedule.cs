using System;
using System.Collections.Generic;

namespace GakuenDLL.Entity
{
    public class Schedule : AbstractEntity
    {
        public List<SchoolEvent> SchoolEvents { get; set; } = new List<SchoolEvent>();
        public DateTime DateTime { get; set; }

        public enum Days
        {
            Fredag, Lørdag, Søndag
        }

        public Days Day { get; set; }
    }
}
