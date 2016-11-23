using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GakuenDLL.Context
{
    class GakuenContext : DbContext
    {
        public GakuenContext() : base("name=Gakuen")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<GakuenContext>());
        }
    }
}
