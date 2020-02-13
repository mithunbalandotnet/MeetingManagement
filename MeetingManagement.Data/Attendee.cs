using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingManagement.Data
{
    public class Attendee : IEntityBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
