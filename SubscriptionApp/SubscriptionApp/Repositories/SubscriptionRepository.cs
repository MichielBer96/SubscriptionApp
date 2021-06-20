using Microsoft.EntityFrameworkCore;
using SubscriptionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionApp.Repositories
{
    public class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(DataContext context) : base(context)
        {

        }

        public async Task<List<Subscription>> GetFilteredSubscriptions(string filter)
        {
            var subscriptions = await _context.subscriptions.Where(s => s.Name.Contains(filter) || s.Email.Contains(filter)).ToListAsync();

            return subscriptions;
        }
    }
}
