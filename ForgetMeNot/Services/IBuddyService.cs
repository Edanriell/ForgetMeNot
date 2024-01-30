using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForgetMeNot.Models;

namespace ForgetMeNot.Services
{
    public interface IBuddyService
    {
        Task<List<Buddy>> GetBuddies();
        List<Preference> GetBuddyPreferences(string buddyId);
    }
}
