using Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Business.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<UserEntity> WithoutPasswords(this IEnumerable<UserEntity> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static UserEntity WithoutPassword(this UserEntity user)
        {
            //user.Password = null;
            return user;
        }
        public static string Error(string msg)
        {
            return msg;
        }
    }
}