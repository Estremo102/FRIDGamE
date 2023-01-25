namespace FRIDGamE.Models
{
    public class Customer
    {
        public Customer()
        {
            Games = new HashSet<Game>();
            News = new HashSet<News>();
        }

        public Guid CustomerId { get; set; }
        public string? IdentityUserId { get; set; }
        public FRIDGamEUser? IdentityUser { get; set; }
        public ISet<Game> Games { get; set; }
        public ISet<News> News { get; set; }
        public decimal Balance { get; set; }
    }
}
