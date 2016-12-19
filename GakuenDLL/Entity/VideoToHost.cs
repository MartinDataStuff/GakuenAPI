using System.Collections.Generic;

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
