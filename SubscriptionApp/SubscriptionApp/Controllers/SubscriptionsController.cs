using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SubscriptionApp.Attributes;
using SubscriptionApp.Dtos;
using SubscriptionApp.Helpers;
using SubscriptionApp.Models;
using SubscriptionApp.Repositories;

namespace SubscriptionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionRepository _repository;
        private readonly IMapper _mapper;

        public SubscriptionsController(ISubscriptionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetSubscription/{id}")]
        public async Task<ActionResult<Subscription>> GetSubscription(int id)
        {
            var model = await _repository.GetById(id);

            return model;
        }

        [HttpGet]
        [Route("GetSubscriptions/{filter?}")]
        public async Task<ActionResult<IEnumerable<Subscription>>> Getsubscriptions(string filter)
        {
            List<Subscription> subscriptions = new List<Subscription>();

            if (!string.IsNullOrEmpty(filter) && filter.Length > 3)
                subscriptions = await _repository.GetFilteredSubscriptions(filter);
            else
                subscriptions = await _repository.GetAll();
            
            return subscriptions;
        }

        [HttpPost]
        public async Task<ActionResult<Subscription>> AddSubscription(SubscriptionForAddDto subscriptionForAdd)
        {
            var model = _mapper.Map<Subscription>(subscriptionForAdd);

            await _repository.Add(model);

            return CreatedAtAction("GetSubscription", new { id = model.Id }, model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Subscription>> DeleteSubscription(int id)
        {
            var model = await _repository.GetById(id);

            await _repository.Remove(model);

            return model;
        }
    }
}
