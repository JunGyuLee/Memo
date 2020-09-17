using System;
using System.ComponentModel.DataAnnotations;

namespace KJMemo.Models.DAO
{
    public class Member
    {
        //[Key]
        [Required]
        public Guid MemberID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        [Required]
        public bool IsValid { get; set; }

        public Member(
            Guid memberID,
            string name,
            string email,
            string password,
            bool isValid)
        {
            MemberID = memberID;
            Name = name;
            Email = email;
            Password = password;
            IsValid = isValid;
        }
    }
}
