using System.ComponentModel.DataAnnotations;

namespace MVCTask2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Post>? Posts { get; set; }
        public List<Role>? Roles { get; set; }
    }
}
