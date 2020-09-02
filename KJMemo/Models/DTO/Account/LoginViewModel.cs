using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KJMemo.Models.DTO
{

    public class LoginViewModel
    {

        [EmailAddress(ErrorMessage="이메일 형식이 아닙니다.")]
        [DisplayName("이메일")]
        [Required(ErrorMessage = "{0}은 필수 입력사항 입니다.")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "{0}은 최소 8자 이상 되어야 합니다.")]
        public string Email { get; set; }

        [DisplayName("비밀번호")]
        [Required(ErrorMessage = "{0}는 필수 입력사항 입니다.")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "{0}는 최소 8자 이상 되어야 합니다.")]
        public string Password { get; set; }


        [DisplayName("아이디 저장")]
        public bool IsRemember { get; set; }
    }
}