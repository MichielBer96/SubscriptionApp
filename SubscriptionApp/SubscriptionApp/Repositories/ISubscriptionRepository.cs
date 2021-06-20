using SubscriptionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionApp.Repositories
{
    public interface ISubscriptionRepository : IGenericRepository<Subscription>
    {
        Task<List<Subscription>> GetFilteredSubscriptions(string filter);
    }
}
