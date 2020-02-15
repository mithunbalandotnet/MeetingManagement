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

        public MeetingController(IRepositoryBase<Meeting> meetingRepo)
        {
            _meetingRepo = meetingRepo;
        }

        public List<MeetingVM> Get()
        {
            return _meetingRepo.GetAll().Select(m => new MeetingVM()
            {
                ID = m.ID,MeetingAgenda = m.MeetingAgenda, MeetingDateTime = m.MeetingDateTime, Subject = m.Subject
            }).ToList();
        }
    }
}