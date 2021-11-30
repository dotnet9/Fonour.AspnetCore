using Fonour.Application.MenuApp.Dtos;
using Fonour.Domain.Entities;
using Fonour.Domain.IRepositories;
using AutoMapper;

namespace Fonour.Application.MenuApp;

public class MenuAppService : IMenuAppService
{
	private readonly IMenuRepository _menuRepository;
	private readonly IRoleRepository _roleRepository;
	private readonly IUserRepository _userRepository;
	private readonly IMapper mapper;

	public MenuAppService(IMenuRepository menuRepository, IUserRepository userRepository,
		IRoleRepository roleRepository, IMapper mapper)
	{
		_menuRepository = menuRepository;
		_userRepository = userRepository;
		_roleRepository = roleRepository;
		this.mapper = mapper;
	}

	public List<MenuDto> GetAllList()
	{
		var menus = _menuRepository.GetAllList().OrderBy(it => it.SerialNumber);
		//使用AutoMapper进行实体转换
		return mapper.Map<List<MenuDto>>(menus);
	}

	public List<MenuDto> GetMenusByParent(Guid parentId, int startPage, int pageSize, out int rowCount)
	{
		var menus = _menuRepository.LoadPageList(startPage, pageSize, out rowCount, it => it.ParentId == parentId,
			it => it.SerialNumber);
		return mapper.Map<List<MenuDto>>(menus);
	}

	public bool InsertOrUpdate(MenuDto dto)
	{
		var menu = _menuRepository.InsertOrUpdate(mapper.Map<Menu>(dto));
		return menu == null ? false : true;
	}

	public void DeleteBatch(List<Guid> ids)
	{
		_menuRepository.Delete(it => ids.Contains(it.Id));
	}

	public void Delete(Guid id)
	{
		_menuRepository.Delete(id);
	}

	public MenuDto Get(Guid id)
	{
		return mapper.Map<MenuDto>(_menuRepository.Get(id));
	}

	/// <summary>
	///     根据用户获取功能菜单
	/// </summary>
	/// <param name="userId">用户ID</param>
	/// <returns></returns>
	public List<MenuDto> GetMenusByUser(Guid userId)
	{
		var result = new List<MenuDto>();
		var allMenus = _menuRepository.GetAllList(it => it.Type == 0).OrderBy(it => it.SerialNumber);
		if (userId == Guid.Empty) //超级管理员
			return mapper.Map<List<MenuDto>>(allMenus);
		var user = _userRepository.GetWithRoles(userId);
		if (user == null)
			return result;
		var userRoles = user.UserRoles;
		var menuIds = new List<Guid>();
		foreach (var role in userRoles)
			menuIds = menuIds.Union(_roleRepository.GetAllMenuListByRole(role.RoleId)).ToList();
		allMenus = allMenus.Where(it => menuIds.Contains(it.Id)).OrderBy(it => it.SerialNumber);
		return mapper.Map<List<MenuDto>>(allMenus);
	}
}