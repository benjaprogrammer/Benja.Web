using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benja.Model;
namespace Benja.Repository
{
    public class RefreshTokenRepo
    {
        private readonly List<RefreshTokenModel> listRefreshTokenModel = new List<RefreshTokenModel>();
        public Task Create(RefreshTokenModel refreshTokenModel)
        {
            refreshTokenModel.Id = Guid.NewGuid();
            listRefreshTokenModel.Add(refreshTokenModel);
            return Task.CompletedTask;
        }
        public Task<RefreshTokenModel> GetByToken(string token)
        {
            RefreshTokenModel refreshTokenModel = listRefreshTokenModel.FirstOrDefault(x => x.Token == token);
            return Task.FromResult(refreshTokenModel);
        }
        public Task Delete(Guid id)
        {
            listRefreshTokenModel.RemoveAll(x=> x.Id == id);
            return Task.CompletedTask;
        }
        public Task DeleteAll(int userID)
        {
            listRefreshTokenModel.RemoveAll(x => x.UserId == userID);
            return Task.CompletedTask;
        }
    }
}
