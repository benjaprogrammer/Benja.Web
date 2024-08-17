using Benja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Repository
{
    public class UserRepo
    {
        public UserModel GetByUserName(string userName)
        {
            UserModel user = new UserModel();
            user.UserName = "jay";
            user.Password = "jay";
            user.FistName = "benja";
            user.LastName = "pattanasak";
            user.Email = "lifeisprogrammer@gmail.com";
            return user;
        }
        public UserModel GetById(Guid userID)
        {
            UserModel user = new UserModel();
            user.UserName = "jay";
            user.Password = "jay";
            user.FistName = "benja";
            user.LastName = "pattanasak";
            user.Email = "lifeisprogrammer@gmail.com";
            return user;
        }
    }
}
