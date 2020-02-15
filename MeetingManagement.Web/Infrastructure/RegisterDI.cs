using MeetingManagement.DL.Repository;
using MeetingManagement.DL.Repository.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingManagement.Web.Infrastructure
{
    public static class RegisterDI
    {
        public static void RegisterTransient(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        }
    }
}
