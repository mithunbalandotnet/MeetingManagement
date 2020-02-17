using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingManagement.Web.Models
{
    public class MeetingVM
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        public string MeetingAgenda { get; set; }
        public DateTime MeetingDateTime { get; set; }
        public List<AttendeeVM> Attendees { get; set; }
    }
}
