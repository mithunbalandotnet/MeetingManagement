using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingManagement.Data
{
    public class Meeting : IEntityBase
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        public string MeetingAgenda { get; set; }
        public DateTime MeetingDateTime { get; set; }
    }
}
