﻿namespace ForgetMeNot.Api.Domain
{
    public class Invite
    {
        public Invite()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public User CreatedByUser { get; set; } = null!;
        public User? AcceptedByUser { get; set; }
        public InvitationStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string InvitedUserName { get; set; } = null!;
        public string InvitedUserCustomMessage { get; set; } = null!;
    }
}
