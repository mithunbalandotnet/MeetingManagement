using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingManagement.DL.Extension
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { ID = 1, UserName = "user1", Password = "pass1" },
                new User { ID = 2, UserName = "user2", Password = "pass2" },
                new User { ID = 3, UserName = "user3", Password = "pass3" });

            modelBuilder.Entity<Attendee>().HasData(new Attendee { ID = 1, Name = "Attendee 1" },
                new Attendee { ID = 2, Name = "Attendee 2" },
                new Attendee { ID = 3, Name = "Attendee 3" });
        }
    }
}
