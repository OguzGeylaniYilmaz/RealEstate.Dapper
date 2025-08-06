namespace RealEstate.API.Dtos.ContactDtos
{
    public class GetContactByIdDto
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime DateOfPosting { get; set; }
    }
}
