using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingManagement.DL
{
    public class User : IEntityBase
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
