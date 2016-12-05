using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            // Database.SetInitializer(new DropCreateDatabaseAlways<GakuenContext>());
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<SchoolEvent> SchoolEvents { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<OrderList> OrderLists { get; set; }

        public DbSet<AdminUser> AdminUsers { get; set; }

        public DbSet<NewsMessage> NewsMessages { get; set; }
        public DbSet<EventMessage> EventMessages { get; set; }
        public DbSet<ImageToHost> Images { get; set; }
        public DbSet<VideoToHost> VideoToHosts { get; set; }
    }

    class DatabaseInitializer : DropCreateDatabaseAlways<GakuenContext>
    {
        protected override void Seed(GakuenContext context)
        {

            Product product1 = context.Products.Add(new Product
            {
                Name = "Weekend",
                Info = "Være til connen alle dagene i weekenden",
                Price = 390
            });

            List<Product> products = new List<Product>();
            products.Add(product1);



            OrderList orderList1 = context.OrderLists.Add(new OrderList
            {
                ItemsList = products,
                PaidStringCode = "123abc"
            });
            var orderLists = new List<OrderList> { orderList1 };
            Address address1 = context.Addresses.Add(new Address
            {
                Country = "Denmark",
                Street1 = "Street 5",
                Town = "Esbjerg",
                ZipCode = "6700"
            });




            var schedule1 = context.Schedules.Add(new Schedule
            {
                Day = Schedule.Days.Fredag
            });
            var schedules = new List<Schedule> { schedule1 };

            SchoolEvent schoolEvent1 = context.SchoolEvents.Add(new SchoolEvent
            {
                Minuttes = 40,
                Name = "Japansk",
                Schedules = schedules
            });
            var eventList = new List<SchoolEvent> { schoolEvent1 };

            var user1 = context.Users.Add(new User
            {
                FirstName = "Torben",
                LastName = "Sonson",
                ConfirmedUser = true,
                Address = address1,
                Email = "ToSon@mail.com",
                PhoneNr = "25252525",
                Password = "Hello123",
                UserName = "ToSon@mail.com",
                Position = User.Positions.Student,
                OrderLists = orderLists,
                SchoolEvents = eventList,
                Birthday = DateTime.Now

            });




            //byte[] imgBytes;
            //var loadedImage =
            //    Image.FromFile(@"C:\Users\Martin\Desktop\Avatar\1532512.jpg");

            //using (MemoryStream ms = new MemoryStream())
            //{
            //    loadedImage.Save(ms, ImageFormat.Jpeg);
            //    imgBytes = ms.ToArray();
            //}

            ImageToHost imageToHost = context.Images.Add(new ImageToHost
            {
                //Bytes = imgBytes,
                ImagePath = "http://images5.fanpop.com/image/answers/2128000/2128709_1320189934337.28res_354_458.jpg",
                ImageName = "Mad Girl"
            });

            VideoToHost videoToHost = context.VideoToHosts.Add(new VideoToHost
            {
                VideoPath = "https://www.youtube.com/watch?v=0yJn-5hpU94",
                VideoName = "Anime Song"
            });

            NewsMessage newsMessage1 = context.NewsMessages.Add(new NewsMessage
            {
                Title = "Open",
                Body = "Så er butikken open for alle, glæder os til at se jer",
                ImageToHost = imageToHost,
                VideoToHost = videoToHost
            });

            EventMessage eventMessage1 = context.EventMessages.Add(new EventMessage
            {
                Title = "Glade dage",
                Body = "Så er der dømt glade dage til jer alle",
                ImageToHost = imageToHost
            });

            base.Seed(context);
        }
    }
}
