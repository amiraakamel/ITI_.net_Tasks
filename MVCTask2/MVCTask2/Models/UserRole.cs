using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTask2.Models
{
    [PrimaryKey("RoleId", "UserId")]
    public class UserRole
    {
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public List<Role> Roles { get; set;}
    }
}
