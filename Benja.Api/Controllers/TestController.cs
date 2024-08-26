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
        RoomModel roomModel = new RoomModel();
     //   public TestController(SqlServer sqlServer)
     //   {
     //       _sqlServer = sqlServer;
     //       roomModel.UpdateBy = "jay";
     //       roomModel.CreateBy = "jay";
     //       roomModel.UpdateDate = DateTime.Now;
     //       roomModel.CreateDate = DateTime.Now;
     //       roomModel.RoomName = "001";
     //       roomModel.Id = 1;
     //   }
     //   [HttpGet("executequery")]
     //   public JsonResult ExecuteQuery()
     //   {
     //       ApiResponse<List<RoomModel>> response = new ApiResponse<List<RoomModel>>();
     //       try
     //       {
     //           TestRepo testRepo = new TestRepo(_sqlServer);
     //           string sql = @"select 
     //                       * 
     //                       from 
     //                       Room
     //                       ";
     //           object parameter = new
     //           {
     //               Id = 1
     //           };

     //           response.Success = true;
     //           response.Data = testRepo.ExecuteQuery(sql, parameter).ToList();
     //       }
     //       catch (Exception ex)
     //       {
     //           response.Success = false;
     //           response.ErrorMessage = ex.Message;
     //       }
     //       return Json(response);
     //   }
     //   [HttpGet("executenonquery")]
     //   public JsonResult ExecuteNonQuery()
     //   {
     //       ApiResponse<int> response = new ApiResponse<int>();
     //       try
     //       {
     //           TestRepo testRepo = new TestRepo(_sqlServer);
     //           string sql = @"INSERT INTO Room
     //      (RoomName
     //      ,CreateDate
     //      ,CreateBy
     //      ,UpdateDate
     //      ,UpdateBy)
     //VALUES
     //     (@RoomName
     //      ,@CreateDate
     //      ,@CreateBy
     //      ,@UpdateDate
     //      ,@UpdateBy)
     //                       ";
     //           object parameter = new
     //           {
     //               RoomName = roomModel.RoomName,
     //               CreateDate = roomModel.CreateDate,
     //               CreateBy = roomModel.CreateBy,
     //               UpdateDate = roomModel.UpdateDate,
     //               UpdateBy = roomModel.UpdateBy
     //           };
     //           response.Success = true;
     //           response.Data = testRepo.ExecuteNonQuery(sql, parameter);
     //       }
     //       catch (Exception ex)
     //       {
     //           response.Success = false;
     //           response.ErrorMessage = ex.Message;
     //       }
     //       return Json(response);
     //   }
     //   [HttpGet("executescalar")]
     //   public JsonResult ExecuteScalar()
     //   {
     //       ApiResponse<object> response = new ApiResponse<object>();
     //       try
     //       {
     //           TestRepo testRepo = new TestRepo(_sqlServer);
     //           string sql = @"select 
     //                       sum(Id) as [sum]
     //                       from 
     //                       Room
     //                       ";
     //           response.Success = true;
     //           response.Data = testRepo.ExecuteScalar(sql);
     //       }
     //       catch (Exception ex)
     //       {
     //           response.Success = false;
     //           response.ErrorMessage = ex.Message;
     //       }
     //       return Json(response);
     //   }
     //   [HttpGet("executetransaction")]
     //   public JsonResult ExecuteTransaction()
     //   {
     //       ApiResponse<string> response = new ApiResponse<string>();
     //       TestRepo testRepo = new TestRepo(_sqlServer);
     //       _sqlServer.OpenSqlCon();
     //       SqlTransaction trans = _sqlServer.GetSqlCon().BeginTransaction();
     //       try
     //       {
     //           string sql1 = @"INSERT INTO Room
     //      (RoomName
     //      ,CreateDate
     //      ,CreateBy
     //      ,UpdateDate
     //      ,UpdateBy)
     //VALUES
     //     (@RoomName
     //      ,@CreateDate
     //      ,@CreateBy
     //      ,@UpdateDate
     //      ,@UpdateBy)
     //                       ";
     //           object parameter1 = new
     //           {
     //               RoomName = roomModel.RoomName,
     //               CreateDate = roomModel.CreateDate,
     //               CreateBy = roomModel.CreateBy,
     //               UpdateDate = roomModel.UpdateDate,
     //               UpdateBy = roomModel.UpdateBy
     //           };
     //           testRepo.ExecuteTransaction(sql1, parameter1, _sqlServer.GetSqlCon(), trans);
     //           string sql2 = @"INSERT INTO Room
     //      (RoomName
     //      ,CreateDate
     //      ,CreateBy
     //      ,UpdateDate
     //      ,UpdateBy)
     //VALUES
     //     (@RoomName
     //      ,@CreateDate
     //      ,@CreateBy
     //      ,@UpdateDate
     //      ,@UpdateBy)
     //                       ";
     //           object parameter2 = new
     //           {
     //               RoomName = roomModel.RoomName,
     //               CreateDate = roomModel.CreateDate,
     //               CreateBy = roomModel.CreateBy,
     //               UpdateDate = roomModel.UpdateDate,
     //               UpdateBy = roomModel.UpdateBy
     //           };
     //           testRepo.ExecuteTransaction(sql2, parameter2, _sqlServer.GetSqlCon(), trans);
     //           trans.Commit();
     //           response.Success = true;
     //           response.Data = "commit";
     //       }
     //       catch (Exception ex)
     //       {
     //           trans.Rollback();
     //           response.Success = false;
     //           response.ErrorMessage= ex.Message;  
     //       }
     //       finally
     //       {
     //           _sqlServer.CloseSqlCon();
     //       }
     //       return Json(response);
     //   }
    }
}


