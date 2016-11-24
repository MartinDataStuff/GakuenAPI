using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GakuenAPI.Models
{
    public class Message
    {


        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Reciever { get; set; }
        public const string Sender = "gakuenreply@gmail.com";
        public const string Code = "p@ssW0rd";
    }
}
