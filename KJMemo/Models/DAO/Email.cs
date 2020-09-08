using System.ComponentModel.DataAnnotations;

namespace KJMemo.Models.DAO
{
    public class Email
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
