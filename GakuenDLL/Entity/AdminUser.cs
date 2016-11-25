using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GakuenDLL.Entity
{
    public class AdminUser : AbstractEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
