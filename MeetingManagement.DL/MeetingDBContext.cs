using MeetingManagement.DL.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingManagement.DL
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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingAttendee> MeetingAttendees { get; set; }
    }
}
