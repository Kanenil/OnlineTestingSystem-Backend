using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace OnlineTestingSystem.Domain.Identity
{
    public class UserEntity : IdentityUser<int>
    {
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string? Image { get; set; }
        [StringLength(100)]
        public string? BackgroundImage { get; set; }
        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
        public virtual ICollection<CourseUserEntity> CourseUsers { get; set; }
    }
}
