using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GakuenDLL.Entity;
using GakuenDLL.Facade;

namespace GakuenDLL.Context
{
    class GakuenContext : DbContext
    {
        public GakuenContext() : base("name=Gakuen")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<GakuenContext>());
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<AdminUser> AdminUsers { get; set; }

        public DbSet<NewsMessage> NewsMessages { get; set; }
        public DbSet<EventMessage> EventMessages { get; set; }
        public DbSet<Image> Images { get; set; }
    }

    class DatabaseInitializer : DropCreateDatabaseAlways<GakuenContext>
    {
        protected override void Seed(GakuenContext context)
        {

            Address address1 = context.Addresses.Add(new Address
            {
                Country = "Denmark",
                Street1 = "Street 5",
                Town = "Esbjerg",
                ZipCode = "6700"
            });

            User user1 = context.Users.Add(new User
            {
                FirstName = "Torben",
                LastName = "Sonson",
                Confirmed = true,
                Address = address1,
                Email = "ToSon@mail.com",
                PhoneNr = "25252525",
                Password = "Hello123",
                UserName = "ToSon@mail.com",
                PaidStringCode = "123abc"
            });

            NewsMessage newsMessage1 = context.NewsMessages.Add(new NewsMessage
            {
                Title = "Open",
                Body = "Så er butikken open for alle, glæder os til at se jer"
            });

            EventMessage eventMessage1 = context.EventMessages.Add(new EventMessage
            {
                Title = "Glade dage",
                Body = "Så er der dømt glade dage til jer alle"
            });

            base.Seed(context);
        }
    }
}
