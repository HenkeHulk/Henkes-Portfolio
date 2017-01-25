namespace Portfolio.DataAccessLayer.DomainClasses
{
    public class Contact
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public string FirstName { get; set; }

        public string SureName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}