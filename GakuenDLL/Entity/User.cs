using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GakuenDLL.Entity
{
    class User : AbstractEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNr { get; set; }
        public Address Address { get; set; }
        public Schedule Schedule { get; set; }
        public Position Position { get; set; }
    }

    enum Position
    {
        Teacher, Student
    }
}
