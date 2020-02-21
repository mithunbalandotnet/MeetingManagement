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
    [Route("api/meeting")]
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

        [Route("get")]
        public List<MeetingVM> Get()
        {
            return _meetingRepo.GetAll(m => m.Attendees).Select(m => new MeetingVM()
            {
                ID = m.ID,
                MeetingAgenda = m.MeetingAgenda,
                MeetingDateTime = m.MeetingDateTime,
                Subject = m.Subject,
                Attendees = m.Attendees.Select(a => new AttendeeVM { ID = a.AttendeeID, Name = a.Attendee.Name }).ToList()
            }).ToList();
        }

        [Route("getmeeting")]
        public MeetingVM GetMeeting(int id)
        {
            var meeting = _meetingRepo.GetById(id);
            var attendees = _meetAttendeeRepo.GetAll().Where(ma => ma.MeetingID == id);
            return new MeetingVM {
                ID = meeting.ID, Subject = meeting.Subject, MeetingAgenda = meeting.MeetingAgenda,
                MeetingDateTime = meeting.MeetingDateTime,
                Attendees = attendees.Select(a => new AttendeeVM { ID = a.AttendeeID, Name = a.Attendee.Name }).ToList()
            };
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
            var meeting = _meetingRepo.GetAll().FirstOrDefault(m => m.ID == meetingVM.ID);
            if (meeting != null)
            {
                var attendees = _meetAttendeeRepo.GetAll(ma => ma.MeetingID == meeting.ID).ToList();
                if (attendees != null && attendees.Count > 0)
                {
                    foreach (var attendee in attendees)
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
        public bool Delete(DeleteVM deleteVM)
        {
            _meetingRepo.Delete(deleteVM.ID);
            return true;
        }
    }
}