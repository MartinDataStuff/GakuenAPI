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
            //Database.SetInitializer(new DropCreateDatabaseAlways<GakuenContext>());
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<OrderList> OrderLists { get; set; }

        public DbSet<AdminUser> AdminUsers { get; set; }

        public DbSet<NewsMessage> NewsMessages { get; set; }
        public DbSet<EventMessage> EventMessages { get; set; }
        public DbSet<ImageToHost> Images { get; set; }
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

            double fullPrice=0;
            foreach (var product in products)
            {
                fullPrice += product.Price;
            }

            OrderList orderList1 = context.OrderLists.Add(new OrderList
            {
                ItemsList = products,
                PaidStringCode = "123abc",
                PriceToPay = fullPrice
            });

            Address address1 = context.Addresses.Add(new Address
            {
                Country = "Denmark",
                Street1 = "Street 5",
                Town = "Esbjerg",
                ZipCode = "6700"
            });

            Schedule schedule = context.Schedules.Add(new Schedule());

            List<OrderList> orderLists = new List<OrderList>();
            orderLists.Add(orderList1);
            User user1 = context.Users.Add(new User
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
                Schedule = schedule,
                OrderLists = orderLists
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
                ImageName = "Mad Girl"
            });

            NewsMessage newsMessage1 = context.NewsMessages.Add(new NewsMessage
            {
                Title = "Open",
                Body = "Så er butikken open for alle, glæder os til at se jer",
                ImageToHost = imageToHost
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
