﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using GakuenDLL.Entity;

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
        public DbSet<SchoolEvent> SchoolEvents { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<OrderList> OrderLists { get; set; }

        public DbSet<AdminUser> AdminUsers { get; set; }

        public DbSet<NewsMessage> NewsMessages { get; set; }
        public DbSet<EventMessage> EventMessages { get; set; }
        public DbSet<ImageToHost> Images { get; set; }
        public DbSet<VideoToHost> VideoToHosts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Orderlist has many-to-many products.
            modelBuilder.Entity<OrderList>()
                .HasMany<Product>(list => list.ItemsList)
                .WithMany(product => product.OrderLists);

            //SchoolEvent has 1 Schedule. Schedule has many SchoolEvents.
            modelBuilder.Entity<SchoolEvent>()
                .HasOptional<Schedule>(schoolEvent => schoolEvent.Schedule)
                .WithMany(schedule => schedule.SchoolEvents);

            base.OnModelCreating(modelBuilder);
        }
    }

    //Seeded Database.
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
                Day = Schedule.Days.Fredag,
                DateTime = DateTime.Now
                //SchoolEvents = eventList
            });


            SchoolEvent schoolEvent1 = context.SchoolEvents.Add(new SchoolEvent
            {
                Minuttes = 40,
                Name = "Japansk",
                Schedule = schedule1
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
                Birthday = DateTime.Now,
                IsAdmin = false
            });

            var user2 = context.Users.Add(new User
            {
                FirstName = "Morten",
                LastName = "Sonson",
                ConfirmedUser = true,
                Address = null,
                Email = "ToAdmin@mail.com",
                PhoneNr = "25252525",
                Password = "Hello123",
                UserName = "ToAdmin@mail.com",
                Position = User.Positions.Teacher,
                OrderLists = null,
                SchoolEvents = eventList,
                Birthday = DateTime.Now,
                IsAdmin = true
            });
            var userList = new List<User> { user1, user2 };



            //byte[] imgBytes;
            //var loadedImage =
            //    Image.FromFile(@"C:\Users\Martin\Desktop\Avatar\1532512.jpg");

            //using (MemoryStream ms = new MemoryStream())
            //{
            //    loadedImage.Save(ms, ImageFormat.Jpeg);
            //    imgBytes = ms.ToArray();
            //}


            ImageToHost imageToHost1 = context.Images.Add(new ImageToHost
            {
                //Bytes = imgBytes,
                ImagePath = "http://images5.fanpop.com/image/answers/2128000/2128709_1320189934337.28res_354_458.jpg",
                ImageName = "Mad Girl"
            });

            ImageToHost imageToHost2 = context.Images.Add(new ImageToHost
            {
                ImagePath = "http://www.animeplus.tv/images/series/small/13.jpg",
                ImageName = "Cheering"
            });

            ImageToHost imageToHost3 = context.Images.Add(new ImageToHost
            {
                ImagePath = "https://myanimelist.cdn-dena.com/images/anime/12/70143.jpg",
                ImageName = "Hot Men 4 Hot Day"
            });

            ImageToHost imageToHost4 = context.Images.Add(new ImageToHost
            {
                ImagePath = "https://scontent-arn2-1.xx.fbcdn.net/v/t34.0-12/15645256_1161155567270931_1187945786_n.png?oh=ebf1fe1f13f4ac0dc03f90fa72db4622&oe=585A363B",
                ImageName = "School Body"
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
                ImageToHost = imageToHost1,
                VideoToHost = videoToHost
            });

            NewsMessage newsMessage2 = context.NewsMessages.Add(new NewsMessage
            {
                Title = "Second News",
                Body =
                    "Spicy jalapeno drumstick pig kevin doner strip steak. Kielbasa turducken spare ribs flank. Frankfurter doner meatball shankle pork belly burgdoggen. Filet mignon picanha biltong, landjaeger pig capicola kevin jowl pork corned beef turkey tri-tip short loin. Frankfurter shankle jowl, boudin shoulder sausage salami short ribs biltong alcatra.",
                ImageToHost = imageToHost2
            });
            NewsMessage newsMessage3 = context.NewsMessages.Add(new NewsMessage
            {
                Title = "More News",
                Body =
"Does your lorem ipsum text long for something a little meatier ? Give our generator a try… it’s tasty!",
                ImageToHost = imageToHost3
            }); NewsMessage newsMessage4 = context.NewsMessages.Add(new NewsMessage
            {
                Title = "New Line News",
                Body = "Sirloin boudin short ribs, ham hock jerky shoulder t-bone brisket cupim strip steak ball tip pancetta spare ribs chuck. Ball tip drumstick beef ribs kevin tongue pastrami pig meatloaf. Kielbasa turducken capicola meatball drumstick venison burgdoggen landjaeger tail. Leberkas burgdoggen ground round, boudin shoulder bacon filet mignon corned beef. Boudin flank beef ribs chicken ball tip burgdoggen swine, bacon pastrami. Alcatra burgdoggen ribeye picanha beef ribs, beef biltong ham hock hamburger spare ribs meatloaf ball tip prosciutto boudin tongue.",
                ImageToHost = imageToHost4
            });

            EventMessage eventMessage1 = context.EventMessages.Add(new EventMessage
            {
                Title = "Glade dage",
                Body = "Så er der dømt glade dage til jer alle",
                ImageToHost = imageToHost1
            });

            base.Seed(context);
        }
    }
}
