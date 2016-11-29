using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace GakuenDLL.Entity
{
    public class Image : AbstractEntity
    {
        public string ImageName { get; set; }
        public byte[] Bytes { get; set; }
    }
}
