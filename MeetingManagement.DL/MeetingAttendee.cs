using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MeetingManagement.DL
{
    public class MeetingAttendee : IEntityBase
    {
        public int ID { get; set; }
        [ForeignKey("Meeting")]
        public int MeetingID { get; set; }
        [ForeignKey("Attendee")] 
        public int AttendeeID { get; set; }

        public virtual Meeting Meeting { get; set; }
        public virtual Attendee Attendee { get; set; }
    }
}
