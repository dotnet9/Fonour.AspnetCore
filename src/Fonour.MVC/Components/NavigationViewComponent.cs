using Fonour.Application.MenuApp;
using Fonour.Application.UserApp;
using Microsoft.AspNetCore.Mvc;

namespace Fonour.MVC.Components;

[ViewComponent(Name = "Navigation")]
public class NavigationViewComponent : ViewComponent
{
	private readonly IMenuAppService _menuAppService;
	private readonly IUserAppService _userAppService;

	public NavigationViewComponent(IMenuAppService menuAppService, IUserAppService userAppService)
	{
		_menuAppService = menuAppService;
		_userAppService = userAppService;
	}

	public IViewComponentResult Invoke()
	{
		var userId = HttpContext.Session.GetString("CurrentUserId");
		var menus = _menuAppService.GetMenusByUser(Guid.Parse(userId));
		return View(menus);
	}
}