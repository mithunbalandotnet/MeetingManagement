﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingManagement.DL
{
    public class Attendee : IEntityBase
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MeetingAttendee> Meetings { get; set; }
    }
}
