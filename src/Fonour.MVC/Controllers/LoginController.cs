﻿using Fonour.Application.UserApp;
using Fonour.MVC.Models;
using Fonour.Utility.Convert;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Fonour.MVC.Controllers;

public class LoginController : Controller
{
	private readonly IUserAppService _userAppService;

	public LoginController(IUserAppService userAppService)
	{
		_userAppService = userAppService;
	}

	// GET: /<controller>/
	public IActionResult Index()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Index(LoginModel model)
	{
		if (ModelState.IsValid)
		{
			//检查用户信息
			var user = _userAppService.CheckUser(model.UserName, model.Password);
			if (user != null)
			{
				//记录Session
				HttpContext.Session.SetString("CurrentUserId", user.Id.ToString());
				HttpContext.Session.Set("CurrentUser", ByteConvertHelper.Object2Bytes(user));
				//跳转到系统首页
				return RedirectToAction("Index", "Home");
			}

			ViewBag.ErrorInfo = "用户名或密码错误。";
			return View();
		}

		foreach (var item in ModelState.Values)
			if (item.Errors.Count > 0)
			{
				ViewBag.ErrorInfo = item.Errors[0].ErrorMessage;
				break;
			}

		return View(model);
	}
}