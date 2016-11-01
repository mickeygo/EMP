using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WMS.Web.Client
{
    /// <summary>
    /// 用户身份扩展类型
    /// </summary>
    public static class HtmlUserIdentityExtensions
    {
        public const int DotASCII = 46;     // '.'
        public const int WhiteASCII = 32;   // ' '

        /// <summary>
        /// 当前登录者的用户名.
        /// 若用户未验证，显示 "Anonymous" 匿名; 对于 mail, 只显示用户名
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static IHtmlString LoginUserName(this HtmlHelper helper)
        {
            var user = HttpContext.Current.User;
            if (user == null)
                return MvcHtmlString.Create("Anonymous");

            var identity = user.Identity;
            if (!identity.IsAuthenticated)
                return MvcHtmlString.Create("Anonymous");

            return MvcHtmlString.Create(GetCamelUserNameFromEmail(identity.Name));
        }

        private static string GetCamelUserNameFromEmail(string email)
        {
            if (email == null)
                return "";

            // 'A' ~ 'Z' ==> 65 ~ 90
            // 'a' ~ 'z' ==> 97 ~ 122   - 32
            // '.' ==> 46
            // '@' ==> 64
            // ' ' ==> 32

            var index = 0;
            var str = new StringBuilder(email.Length);
            foreach (var ch in email)
            {
                if (ch == '@')
                    break;

                if (index++ == 0)
                {
                    str.Append(ToUpperChar(ch));
                    continue;
                }

                if (DotASCII == ch)
                {
                    index = 0;
                    str.Append(ch);
                    continue;
                }

                str.Append(ToLowerChar(ch));
            }

            return str.ToString();
        }


        private static char ToLowerChar(char ch)
        {
            return IsCapitalLetterChar(ch) ? (char)(ch + 32) : ch;
        }

        private static char ToUpperChar(char ch)
        {
            return IsLowerLetterChar(ch) ? (char)(ch - 32) : ch;
        }

        // 'a' ~ 'z' ==> 97 ~ 122
        private static bool IsLowerLetterChar(char ch)
        {
            return 97 <= ch && ch <= 122;
        }

        // 'A' ~ 'Z' ==> 65 ~ 90
        private static bool IsCapitalLetterChar(char ch)
        {
            return 65 <= ch && ch <= 90;
        }
    }
}
