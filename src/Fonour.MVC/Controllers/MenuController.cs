﻿using Fonour.Application.MenuApp;
using Fonour.Application.MenuApp.Dtos;
using Fonour.Application.UserApp;
using Fonour.MVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Fonour.MVC.Controllers;

/// <summary>
///     功能管理控制器
/// </summary>
public class MenuController : FonourControllerBase
{
	private readonly IMenuAppService _menuAppService;

	public MenuController(IMenuAppService menuAppService, IUserAppService userAppService)
	{
		_menuAppService = menuAppService;
	}

	// GET: /<controller>/
	public IActionResult Index()
	{
		return View();
	}

	/// <summary>
	///     获取功能树JSON数据
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	public IActionResult GetMenuTreeData()
	{
		var menus = _menuAppService.GetAllList();
		var treeModels = new List<TreeModel>();
		foreach (var menu in menus)
			treeModels.Add(new TreeModel
			{
				Id = menu.Id.ToString(), Text = menu.Name,
				Parent = menu.ParentId == Guid.Empty ? "#" : menu.ParentId.ToString()
			});
		return Json(treeModels);
	}

	/// <summary>
	///     获取子级功能列表
	/// </summary>
	/// <returns></returns>
	public IActionResult GetMneusByParent(Guid parentId, int startPage, int pageSize)
	{
		var rowCount = 0;
		var result = _menuAppService.GetMenusByParent(parentId, startPage, pageSize, out rowCount);
		return Json(new
		{
			rowCount,
			pageCount = Math.Ceiling(Convert.ToDecimal(rowCount) / pageSize),
			rows = result
		});
	}

	/// <summary>
	///     新增或编辑功能
	/// </summary>
	/// <param name="dto"></param>
	/// <returns></returns>
	public IActionResult Edit(MenuDto dto)
	{
		if (!ModelState.IsValid)
			return Json(new
			{
				Result = "Faild",
				Message = GetModelStateError()
			});
		if (_menuAppService.InsertOrUpdate(dto)) return Json(new { Result = "Success" });
		return Json(new { Result = "Faild" });
	}

	public IActionResult DeleteMuti(string ids)
	{
		try
		{
			var idArray = ids.Split(',');
			var delIds = new List<Guid>();
			foreach (var id in idArray) delIds.Add(Guid.Parse(id));
			_menuAppService.DeleteBatch(delIds);
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
			_menuAppService.Delete(id);
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

	public ActionResult Get(Guid id)
	{
		var dto = _menuAppService.Get(id);
		return Json(dto);
	}
}