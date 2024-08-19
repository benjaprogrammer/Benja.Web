using Benja.Library;
using Benja.Model;
using Benja.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Benja.Api.Controllers
{
    [ApiController]
    [Route("api/v1/test")]
    public class TestController : BaseController
    {
        public SqlServer _sqlServer;
        RoomModel roomModel = new RoomModel();
        public TestController(SqlServer sqlServer)
        {
            _sqlServer = sqlServer;
            roomModel.UpdateBy = "jay";
            roomModel.CreateBy = "jay";
            roomModel.UpdateDate = DateTime.Now;
            roomModel.CreateDate = DateTime.Now;
            roomModel.RoomName = "001";
            roomModel.Id = 1;
        }
        [HttpGet("executequery")]
        public JsonResult ExecuteQuery()
        {
            TestRepo testRepo = new TestRepo(_sqlServer);
            string sql = @"select 
                            * 
                            from 
                            Room
                            ";
            object parameter = new
            {
                Id = 1
            };
            return Json(testRepo.ExecuteQuery(sql, parameter).ToList());
        }
        [HttpGet("executenonquery")]
        public JsonResult ExecuteNonQuery()
        {
            TestRepo testRepo = new TestRepo(_sqlServer);
            string sql = @"INSERT INTO Room
           (RoomName
           ,CreateDate
           ,CreateBy
           ,UpdateDate
           ,UpdateBy)
     VALUES
          (@RoomName
           ,@CreateDate
           ,@CreateBy
           ,@UpdateDate
           ,@UpdateBy)
                            ";
            object parameter = new
            {
                RoomName = roomModel.RoomName,
                CreateDate = roomModel.CreateDate,
                CreateBy = roomModel.CreateBy,
                UpdateDate = roomModel.UpdateDate,
                UpdateBy = roomModel.UpdateBy
            };
            return Json(testRepo.ExecuteNonQuery(sql, parameter));
        }
        [HttpGet("executescalar")]
        public JsonResult ExecuteScalar()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            TestRepo testRepo = new TestRepo(_sqlServer);
            string sql = @"select 
                            sum(Id) as [sum]
                            from 
                            Room
                            ";
            return Json(testRepo.ExecuteScalar(sql));
        }
        [HttpGet("executetransaction")]
        public JsonResult ExecuteTransaction()
        {
            TestRepo testRepo = new TestRepo(_sqlServer);
            _sqlServer.OpenSqlCon();
            SqlTransaction trans = _sqlServer.GetSqlCon().BeginTransaction();
            try
            {
                string sql1 = @"INSERT INTO Room
           (RoomName
           ,CreateDate
           ,CreateBy
           ,UpdateDate
           ,UpdateBy)
     VALUES
          (@RoomName
           ,@CreateDate
           ,@CreateBy
           ,@UpdateDate
           ,@UpdateBy)
                            ";
                object parameter1 = new
                {
                    RoomName = roomModel.RoomName,
                    CreateDate = roomModel.CreateDate,
                    CreateBy = roomModel.CreateBy,
                    UpdateDate = roomModel.UpdateDate,
                    UpdateBy = roomModel.UpdateBy
                };
                testRepo.ExecuteTransaction(sql1, parameter1, _sqlServer.GetSqlCon(), trans);
                string sql2 = @"INSERT INTO Room
           (RoomName
           ,CreateDate
           ,CreateBy
           ,UpdateDate
           ,UpdateBy)
     VALUES
          (@RoomName
           ,@CreateDate
           ,@CreateBy
           ,@UpdateDate
           ,@UpdateBy)
                            ";
                object parameter2 = new
                {
                    RoomName = roomModel.RoomName,
                    CreateDate = roomModel.CreateDate,
                    CreateBy = roomModel.CreateBy,
                    UpdateDate = roomModel.UpdateDate,
                    UpdateBy = roomModel.UpdateBy
                };
                testRepo.ExecuteTransaction(sql2, parameter2, _sqlServer.GetSqlCon(), trans);
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
            }
            finally
            {
                _sqlServer.CloseSqlCon();
            }
            return Json("Success");
        }
    }
}
