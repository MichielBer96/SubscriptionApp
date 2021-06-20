using SubscriptionApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionApp.Dtos
{
    public class SubscriptionForAddDto
    {
        [Required(ErrorMessage = "Naam is vereist")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is vereist")]
        [UniqueEmail]
        [ValidEmail]
        public string Email { get; set; }
    }
}
