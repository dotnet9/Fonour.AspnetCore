﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Fonour.MVC.Controllers;

public class SharedController : Controller
{
	// GET: /<controller>/
	public IActionResult Error()
	{
		return View();
	}
}