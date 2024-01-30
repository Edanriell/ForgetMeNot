using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ForgetMeNot.Models
{
    [ObservableObject]
    public partial class User
    {
        [ObservableProperty]
        private string name = null!;

        [ObservableProperty]
        private string id = null!;

        [ObservableProperty]
        private List<Buddy> buddies = null!;

        // [ObservableProperty] private List<Invitation> invitations;

        [ObservableProperty]
        private List<Preference> preferences = null!;
    }
}
