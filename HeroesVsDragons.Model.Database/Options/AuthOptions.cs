using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HeroesVsDragons.Model.Database.Options
{
    ///<summary>
    /// Class options for Auth.
    /// </summary>
    public class AuthOptions
    {
        ///<summary>
        /// издатель токена.
        /// </summary>
        public const string ISSUER = "MyAuthServer";
        ///<summary>
        /// потребитель токена.
        /// </summary>
        public const string AUDIENCE = "https://localhost:5001/";
        ///<summary>
        /// ключ для шифрации.
        /// </summary>
        const string KEY = "mysupersecret_secretkey!123";
        ///<summary>
        /// время жизни токена - 1 минута.
        /// </summary>
        public const int LIFETIME = 1;
        ///<summary>
        /// get key.
        /// </summary>
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
