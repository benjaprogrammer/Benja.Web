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
        private readonly List<UserModel> listUserModel = new List<UserModel>();
        public UserModel GetByUserName(string userName)
        {
            return listUserModel.FirstOrDefault(x => x.UserName == userName);
        }
        public UserModel GetById(Guid userID)
        {
            return listUserModel.FirstOrDefault(x => x.Id == userID);
        }
        public UserModel GetByEmail(string email)
        {
            return listUserModel.FirstOrDefault(x=>x.Email == email);
        }
        public UserModel Create(UserModel userModel)
        {
            userModel.Id=Guid.NewGuid();
            listUserModel.Add(userModel);
            return userModel;
        }
    }
}
