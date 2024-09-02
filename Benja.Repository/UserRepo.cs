using Benja.Library;
using Benja.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Repository
{
    public class UserRepo : BaseRepo, IDataAccess
    {
        public UserRepo(SqlServer sqlServer)
        {
            _sqlServer = sqlServer;
        }
        public Task<int> Add(dynamic dynamic)
        {
            string sql = @"INSERT INTO [User](
           userName
           ,userPassword
           ,userConfirmPassword
           ,fistName
           ,lastName
           ,email
           ,passwordHash
           ,createDate
           ,createBy
           ,updateDate
           ,updateBy
           ,migrationGuID)
     VALUES
           ( @userName
           ,@userPassword
           ,@userConfirmPassword
           ,@fistName
           ,@lastName
           ,@email
           ,@passwordHash
           ,@createDateString
           ,@createBy
           ,@updateDateString
           ,@updateBy
           ,@migrationGuIDString)
                            ";
            RegisterModel registerModel = (RegisterModel)dynamic;
            var parameter = new
            {
                userName = registerModel.userName,
                userPassword = registerModel.password,
                userConfirmPassword = registerModel.confirmPassword,
                fistName = "fistName",
                lastName = "lastName",
                email = registerModel.email,
                passwordHash = new BcryptPasswordHasher().HashPassword(registerModel.password),
                createDateString = DateTime.Now.ToString("yyyy-MM-dd",new CultureInfo("en-US")),
                createBy = "createBy",
                updateDateString = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("en-US")),
                updateBy = "updateBy",
                migrationGuIDString = Guid.NewGuid().ToString()
            };
            return _sqlServer.ExecuteNonQuery(sql, parameter);
        }
        public Task<int> Edit(string sql, object? parameter)
        {
            return _sqlServer.ExecuteNonQuery(sql, parameter);
        }
        public Task<int> Delete(string sql, object? parameter)
        {
            return _sqlServer.ExecuteNonQuery(sql, parameter);
        }
        public Task<IEnumerable<UserModel>> GetItem<UserModel>(string sql, object parameter)
        {
            return _sqlServer.ExecuteQuery<UserModel>(sql, parameter);
        }
        public Task<IEnumerable<UserModel>> GetList<UserModel>(string sql, object parameter)
        {
            return _sqlServer.ExecuteQuery<UserModel>(sql, parameter);
        }
        public Task<IEnumerable<UserModel>> GetByEmail<UserModel>(object parameter)
        {
            string sql = @"";
            return _sqlServer.ExecuteQuery<UserModel>(sql, parameter);
        }

       
    }
}

//    {
//        private readonly List<UserModel> listUserModel = new List<UserModel>();
//        public UserModel GetByUserName(string userName)
//        {
//            return listUserModel.FirstOrDefault(x => x.UserName == userName);
//        }
//        public UserModel GetById(Guid userID)
//        {
//            return listUserModel.FirstOrDefault(x => x.Id == userID);
//        }
//        public UserModel GetByEmail(string email)
//        {
//            return listUserModel.FirstOrDefault(x=>x.Email == email);
//        }
//        public UserModel Create(UserModel userModel)
//        {
//            userModel.Id=Guid.NewGuid();
//            listUserModel.Add(userModel);
//            return userModel;
//        }
//    }
//}
