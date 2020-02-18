using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingManagement.DL;
using MeetingManagement.DL.Repository.Abstract;
using MeetingManagement.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingManagement.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IRepositoryBase<Meeting> _meetingRepo;
        private readonly IRepositoryBase<Attendee> _attendeeRepo;
        private readonly IRepositoryBase<MeetingAttendee> _meetAttendeeRepo;

        public MeetingController(IRepositoryBase<Meeting> meetingRepo,
            IRepositoryBase<Attendee> attendeeRepo,
            IRepositoryBase<MeetingAttendee> meetAttendeeRepo)
        {
            _meetingRepo = meetingRepo;
            _attendeeRepo = attendeeRepo;
            _meetAttendeeRepo = meetAttendeeRepo;
        }

        public List<MeetingVM> Get()
        {
            return _meetingRepo.GetAll().Select(m => new MeetingVM()
            {
                ID = m.ID,
                MeetingAgenda = m.MeetingAgenda,
                MeetingDateTime = m.MeetingDateTime,
                Subject = m.Subject
            }).ToList();
        }

        [Route("getAttendees")]
        public List<AttendeeVM> GetAttendees()
        {
            return _attendeeRepo.GetAll().Select(a => new AttendeeVM()
            {
                ID = a.ID,
                Name = a.Name
            }).ToList();
        }

        [HttpPost]
        [Route("add")]
        public MeetingVM Add(MeetingVM meetingVM)
        {
            var meeting = new Meeting()
            {
                MeetingAgenda = meetingVM.MeetingAgenda,
                Subject = meetingVM.Subject,
                MeetingDateTime = meetingVM.MeetingDateTime,
                Attendees = meetingVM.Attendees.Select(a => new MeetingAttendee() { AttendeeID = a.ID }).ToList()
            };
            _meetingRepo.Create(meeting);

            meetingVM.ID = meeting.ID;

            return meetingVM;
        }

        [HttpPost]
        [Route("update")]
        public MeetingVM Update(MeetingVM meetingVM)
        {
            var meeting = _meetingRepo.GetAll(m => m.Attendees).FirstOrDefault(m => m.ID == meetingVM.ID);
            if (meeting != null)
            {
                if (meeting.Attendees != null && meeting.Attendees.Count > 0)
                {
                    foreach (var attendee in meeting.Attendees)
                    {
                        _meetAttendeeRepo.Delete(attendee.ID);
                    }
                }

                meeting.Subject = meetingVM.Subject;
                meeting.MeetingAgenda = meetingVM.MeetingAgenda;
                meeting.MeetingDateTime = meetingVM.MeetingDateTime;
                meeting.Attendees = null;

                _meetingRepo.Update(meeting);

                if (meetingVM.Attendees != null && meetingVM.Attendees.Count > 0)
                {
                    foreach (var attendeeVM in meetingVM.Attendees)
                    {
                        var attendee = new MeetingAttendee()
                        {
                            AttendeeID = attendeeVM.ID,
                            MeetingID = meeting.ID
                        };

                        _meetAttendeeRepo.Create(attendee);
                    }
                }
                return meetingVM;
            }

            return null;
        }

        [HttpPost]
        [Route("delete")]
        public bool Delete(int id)
        {
            _meetingRepo.Delete(id);
            return true;
        }
    }
}