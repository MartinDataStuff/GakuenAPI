using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IRepository<Image> GetImageRepository()
        {
            return new ImageRepository(); 
            
        }

    }
}
