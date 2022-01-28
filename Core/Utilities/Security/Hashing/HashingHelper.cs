using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password,out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;// kullandığımız algoritmanın o andaki key değeri. Her kullanıcı için ayrı key değeri oluşturulur
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//passwordun byte değeri
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)//passwordhashi doğrula
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            
        }
    }
}
