using Benja.Library;
using Benja.Model;
using Benja.Repository;
using Benja.ViewModel;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace Benja.Api.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/v1/menu")]
    public class MenuController : BaseController
    {
        public MenuController(SqlServer sqlServer)
        {
            _sqlServer = sqlServer;
        }
        [HttpPost("add")]
        public JsonResult Add(MenuVm menuVm)
        {
            ApiResponse<int> response = new ApiResponse<int>();
            try
            {
                MenuRepo menuRepo = new MenuRepo(_sqlServer);
                string sql = @"INSERT INTO Menu
           (MenuName
           )
     VALUES
          (@MenuName
          )
                            ";
                object parameter = new
                {
                    MenuName = menuVm.menuModel.MenuName,
                };

                response.Data = menuRepo.Add(sql, parameter);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return Json(response);
        }
        //        [HttpGet("edit")]
        //        public JsonResult Edit([FromBody] RoomModel roomModel)
        //        {
        //            ApiResponse<int> response = new ApiResponse<int>();
        //            try
        //            {
        //                RoomRepo roomRepo = new RoomRepo(_sqlServer);
        //                string sql = @"Update Room set
        //           RoomName=@RoomName
        //           ,CreateDate=@CreateDate
        //           ,CreateBy=@CreateBy
        //           ,UpdateDate=@UpdateDate
        //           ,UpdateBy=@UpdateBy
        //           where Id=@Id
        //                            ";
        //                object parameter = new
        //                {
        //                    RoomName = roomModel.RoomName,
        //                    CreateDate = roomModel.CreateDate,
        //                    CreateBy = roomModel.CreateBy,
        //                    UpdateDate = roomModel.UpdateDate,
        //                    UpdateBy = roomModel.UpdateBy,
        //                    Id = roomModel.Id
        //                };

        //                response.Data = roomRepo.Edit(sql, parameter);
        //            }
        //            catch (Exception ex)
        //            {
        //                response.Success = false;
        //                response.ErrorMessage = ex.Message;
        //            }
        //            return Json(response);
        //        }
        //        [HttpGet("delete")]
        //        public JsonResult Delete([FromBody] RoomModel roomModel)
        //        {
        //            ApiResponse<int> response = new ApiResponse<int>();
        //            try
        //            {
        //                RoomRepo roomRepo = new RoomRepo(_sqlServer);
        //                string sql = @"Delete from Room 
        //           where Id=@Id
        //                            ";
        //                object parameter = new
        //                {
        //                    Id = roomModel.Id
        //                };

        //                response.Data = roomRepo.Delete(sql, parameter);
        //            }
        //            catch (Exception ex)
        //            {
        //                response.Success = false;
        //                response.ErrorMessage = ex.Message;
        //            }
        //            return Json(response);
        //        }
        [HttpGet("getitem")]
        public JsonResult GetItem(string menuModel)
        {
            ApiResponse<RoomModel> response = new ApiResponse<RoomModel>();
            try
            {
                MenuRepo menuRepo = new MenuRepo(_sqlServer);
                string sql = @"SELECT *
FROM Menu 
where MenuName like '%@MenuName%'";
                object parameter = new
                {
                    MenuName = menuModel
                };
                List<RoomModel> listRoomModel = menuRepo.GetItem<RoomModel>(sql, parameter).ToList();
                if (listRoomModel.Count > 0)
                {
                    response.Data = listRoomModel[0];
                }
                else
                {
                    response.Data = new RoomModel();
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return Json(response);
        }
        //        [HttpPost("getlists")]
        //        public JsonResult GetLists([FromBody] RoomListVM roomListVM)
        //        {
        //            ApiResponse<List<RoomModel>> response = new ApiResponse<List<RoomModel>>();
        //            try
        //            {
        //                RoomRepo roomRepo = new RoomRepo(_sqlServer);
        //                string sql = @"SELECT *
        //FROM room WITH(NOLOCK)
        //where (1=1) {0}
        //ORDER BY Id 
        //OFFSET @Offset ROWS
        //FETCH NEXT @Next ROWS ONLY";
        //                var dictionary = new Dictionary<string, object>();
        //                string condition = string.Empty;
        //                if (roomListVM.roomModel.Id != 0)
        //                {
        //                    condition += " and Id=" + roomListVM.roomModel.Id.ToString() + " ";
        //                    roomListVM.pagingModel.Offset = 0;
        //                }
        //                if (roomListVM.roomModel.RoomName == "006")
        //                {
        //                    condition += " and RoomName='" + roomListVM.roomModel.RoomName + "' ";
        //                    roomListVM.pagingModel.Offset = 0;
        //                }
        //                if (condition == string.Empty)
        //                {
        //                    sql = string.Format(sql, string.Empty);
        //                }
        //                else
        //                {
        //                    sql = string.Format(sql, condition);
        //                }
        //                dictionary.Add("@Offset", roomListVM.pagingModel.Offset);
        //                dictionary.Add("@Next", roomListVM.pagingModel.Next);
        //                var parameters = new DynamicParameters(dictionary);
        //                response.Data = roomRepo.GetList<RoomModel>(sql, parameters).ToList();
        //            }
        //            catch (Exception ex)
        //            {
        //                response.Success = false;
        //                response.ErrorMessage = ex.Message;
        //            }
        //            return Json(response);
        //        }
        //        [HttpPost("getlist")]
        //        public JsonResult GetList([FromBody] DtParameters dtParameters)
        //        {
        //            var searchBy = dtParameters.search?.Value;

        //            var orderCriteria = "";
        //            var orderAscendingDirection = true;

        //            if (dtParameters.order != null)
        //            {
        //                orderCriteria = dtParameters.columns[dtParameters.order[0].Column].Data;
        //                if (orderCriteria == "0")
        //                {
        //                    orderCriteria = "";
        //                }
        //                orderAscendingDirection = dtParameters.order[0].Dir.ToString().ToLower() == "asc";
        //            }
        //            RoomRepo roomRepo = new RoomRepo(_sqlServer);
        //            string sql = @"";
        //            var dictionary = new Dictionary<string, object>();
        //            var parameters = new DynamicParameters(dictionary);
        //            IEnumerable<RoomModel> listRoomModel = roomRepo.GetList<RoomModel>(sql, parameters);
        //            var result = listRoomModel.AsQueryable();

        //            if (!string.IsNullOrEmpty(searchBy))
        //            {
        //                result = result.Where(r => (r.RoomName.ToLower() != null && r.RoomName.ToLower().Contains(searchBy.ToLower())));

        //            }
        //            result = orderAscendingDirection ? result.OrderByDynamic(orderCriteria, DtOrderDir.Asc) : result.OrderByDynamic(orderCriteria, DtOrderDir.Desc);

        //            var filteredResultsCount = result.Count();
        //            var totalResultsCount = listRoomModel.Count();

        //            return Json(new DtResult<RoomModel>
        //            {
        //                Draw = dtParameters.draw,
        //                RecordsTotal = totalResultsCount,
        //                RecordsFiltered = filteredResultsCount,
        //                Data = result
        //                    .Skip(dtParameters.start)
        //                    .Take(dtParameters.length)
        //                    .ToList()
        //            });
        //        }
    }
}
