using System.Text;
using DotPlatform.Storage;
using WMS.DataTransferObject.Dtos;

namespace WMS.Web.Client.External.Ez
{
    /// <summary>
    /// EZ 系统数据仓储
    /// </summary>
    public class EzUserRepository : EzRepository
    {
        public EzUserRepository(IRdbmsStorageProvider provider) : base(provider)
        {
        }

        /// <summary>
        /// 查找用户信息。若没找到，返回 null
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public UserDto FindUser(string userName)
        {
            var sql = new StringBuilder();
            sql.AppendLine(" SELECT EMAIL_ADDR AS UserName, Password, EMAIL_ADDR AS EmailAddress, EMPLR_ID AS EmployeeNo ");
            sql.AppendLine("        ,ENG_NAME AS EnglishName, LOCAL_NAME AS LocalName, ORG_NAME AS Organization, DIV_NAME AS Department ");
            sql.AppendLine("        ,JOBTITLE_NAME AS Job, CELL_PH_NUM AS Tel, Extension ");
            sql.AppendLine(" FROM   [dbo].[VW_people_finder] ");
            sql.AppendLine(" WHERE  EMAIL_ADDR = @UserName ");

            return this.FirstOrDefault<UserDto>(sql.ToString(), new { UserName = userName });
        }
    }
}
