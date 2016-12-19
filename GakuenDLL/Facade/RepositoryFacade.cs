using GakuenDLL.Entity;
using GakuenDLL.Interface;
using GakuenDLL.Repository;

namespace GakuenDLL.Facade
{
    public class RepositoryFacade
    {
        public IRepository<Address> GetAddressRepository()
        {
            return new AddressRepository();
        }

        public IRepository<User> GetUserRepository()
        {
            return new UserRepository();
        }

        public IRepository<NewsMessage> GetNewsMessageRepository()
        {
            return new NewsMessageRepository();
        }

        public IRepository<EventMessage> GetEventMessageRepository()
        {
            return new EventMessageRepository();
        }

        public IRepository<AdminUser> GetAdminUserRepository()
        {
            return new AdminUserRepository();
        }

        public IRepository<ImageToHost> GetImageRepository()
        {
            return new ImageToHostRepository(); 
        }

        public IRepository<VideoToHost> GetVideoRepository()
        {
            return new VideoToHostRepository();
        }

        public IRepository<OrderList> GetOrderListRepository()
        {
            return new OrderListRepository();
        }

        public IRepository<Product> GetProductRepository()
        {
            return new ProductRepository();
        }

        public IRepository<SchoolEvent> GetSchoolEvent()
        {
            return new SchoolEventRepository();
        }

        public IRepository<Schedule> GetScheduleRepository()
        {
            return new ScheduleRepository();
        }
    }
}
