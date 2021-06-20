using AutoMapper;
using SubscriptionApp.Dtos;
using SubscriptionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionApp.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // In, Out
            CreateMap<SubscriptionForAddDto, Subscription>();
        }
    }
}
