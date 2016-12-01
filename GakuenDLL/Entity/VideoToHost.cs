using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GakuenDLL.Entity
{
    public class VideoToHost : AbstractEntity
    {
        public string VideoPath { get; set; }
        public string VideoName { get; set; }
        public byte[] Bytes { get; set; }
        public List<NewsMessage> NewsMessages { get; set; } = new List<NewsMessage>();
        public List<EventMessage> EventMessages { get; set; } = new List<EventMessage>();
    }
}
