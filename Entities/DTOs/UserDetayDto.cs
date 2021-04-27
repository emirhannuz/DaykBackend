using Core.Entites.Abstract;

namespace Entities.DTOs
{
    public class UserDetayDto : IDto
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string TcNo { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
