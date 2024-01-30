namespace ForgetMeNot.Api.Domain
{
    public class Occasion
    {
        public Occasion()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public User? ForUser { get; set; }
        public string? OccasionName { get; set; }
        public DateTime Date { get; set; }
        public int NumDaysToNotify { get; set; }
    }
}
