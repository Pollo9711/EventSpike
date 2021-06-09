using System.ComponentModel.DataAnnotations;

namespace EventSpikeBack.Context.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}