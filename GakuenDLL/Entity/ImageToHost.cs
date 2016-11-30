using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace GakuenDLL.Entity
{
    public class ImageToHost : AbstractEntity
    {
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public byte[] Bytes { get; set; }
        public List<NewsMessage> NewsMessages { get; set; } = new List<NewsMessage>();
        public List<EventMessage> EventMessages { get; set; } = new List<EventMessage>();
    }
}
