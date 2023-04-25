namespace API.DTOs.Contacts
{
    public class ContactGetModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Complaint { get; set; }
        public DateTime Date { get; set; }
    }
}
