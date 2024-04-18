using System.ComponentModel.DataAnnotations;

namespace CP2.Net.Models
{
    public class UserCP2
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }
}
