using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingManagement.Data
{
    public class MeetingDBContext : DbContext
    {
        #region MeetingDBContext
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="options"></param>
        public MeetingDBContext(DbContextOptions<MeetingDBContext> options) : base(options)
        {

        }
        #endregion

        public DbSet<User> Users { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingAttendee> MeetingAttendees { get; set; }
    }
}
