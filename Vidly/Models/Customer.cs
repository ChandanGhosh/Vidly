namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name => $"{FirstName} {LastName}";
        public bool IsSubscribedToNewsletter { get; set; }

        // Navigation property
        public MembershipType MembershipType { get; set; }
        // For optimization. When we don't need all
        // the properties one foreignkey id will help
        public byte MembershipTypeId { get; set; }
        
    }
}
