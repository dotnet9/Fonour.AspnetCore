using Fonour.Application.RoleApp;
using Fonour.Application.UserApp;
using Fonour.Application.UserApp.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Fonour.MVC.Controllers;

public class UserController : FonourControllerBase
{
	private readonly IRoleAppService _roleService;
	private readonly IUserAppService _service;

	public UserController(IUserAppService service, IRoleAppService roleService)
	{
		_service = service;
		_roleService = roleService;
	}

	// GET: /<controller>/
	public IActionResult Index()
	{
		return View();
	}

	public IActionResult GetUserByDepartment(Guid departmentId, int startPage, int pageSize)
	{
		var rowCount = 0;
		var result = _service.GetUserByDepartment(departmentId, startPage, pageSize, out rowCount);
		var roles = _roleService.GetAllList();
		return Json(new
		{
			rowCount,
			pageCount = Math.Ceiling(Convert.ToDecimal(rowCount) / pageSize),
			rows = result,
			roles
		});
	}

	public IActionResult Edit(UserDto dto, string roles)
	{
		try
		{
			if (dto.Id == Guid.Empty) dto.Id = Guid.NewGuid();
			var userRoles = new List<UserRoleDto>();
			foreach (var role in roles.Split(','))
				userRoles.Add(new UserRoleDto { UserId = dto.Id, RoleId = Guid.Parse(role) });
			dto.UserRoles = userRoles;
			var user = _service.InsertOrUpdate(dto);
			return Json(new { Result = "Success" });
		}
		catch (Exception ex)
		{
			return Json(new { Result = "Faild", ex.Message });
		}
	}

	public IActionResult DeleteMuti(string ids)
	{
		try
		{
			var idArray = ids.Split(',');
			var delIds = new List<Guid>();
			foreach (var id in idArray) delIds.Add(Guid.Parse(id));
			_service.DeleteBatch(delIds);
			return Json(new
			{
				Result = "Success"
			});
		}
		catch (Exception ex)
		{
			return Json(new
			{
				Result = "Faild", ex.Message
			});
		}
	}

	public IActionResult Delete(Guid id)
	{
		try
		{
			_service.Delete(id);
			return Json(new
			{
				Result = "Success"
			});
		}
		catch (Exception ex)
		{
			return Json(new
			{
				Result = "Faild", ex.Message
			});
		}
	}

	public IActionResult Get(Guid id)
	{
		var dto = _service.Get(id);
		return Json(dto);
	}
}