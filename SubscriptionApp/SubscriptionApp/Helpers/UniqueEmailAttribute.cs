using SubscriptionApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionApp.Helpers
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = (DataContext)validationContext.GetService(typeof(DataContext));
            var subscription = _context.subscriptions.FirstOrDefault(s => s.Email.Equals(value));

            if (subscription != null)
                return new ValidationResult(string.Format("De email {0} is al in gebruik.", value.ToString()));

            return ValidationResult.Success;
        }
    }
}
