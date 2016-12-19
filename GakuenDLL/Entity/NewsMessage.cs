using System;

namespace GakuenDLL.Entity
{
    public class NewsMessage : AbstractEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public ImageToHost ImageToHost { get; set; }
        public VideoToHost VideoToHost { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
