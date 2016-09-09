using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WMS.Web.Models
{
    /// <summary>
    /// 登录 ViewModel
    /// </summary>
    public class LoginViewModel
    {
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remember me?")]
        public bool RememberMe { get; set; }
    }
}
