using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GakuenDLL.Entity;

namespace GakuenDLL.Context
{
    class GakuenContext : DbContext
    {
        public GakuenContext() : base("name=Gakuen")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<GakuenContext>());

            //Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<NewsMessage> NewsMessages { get; set; }
        public DbSet<EventMessage> EventMessages { get; set; }
    }

    class DatabaseInitializer : DropCreateDatabaseAlways<GakuenContext>
    {
        
    }
}
