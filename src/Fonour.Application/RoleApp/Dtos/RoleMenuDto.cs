﻿using Fonour.Application.MenuApp.Dtos;

namespace Fonour.Application.RoleApp.Dtos;

public class RoleMenuDto
{
	public Guid RoleId { get; set; }
	public RoleDto Role { get; set; }

	public Guid MenuId { get; set; }
	public MenuDto Menu { get; set; }
}