﻿namespace Fonour.Domain.Entities;

public class Role : Entity
{
	public string? Code { get; set; }

	public string? Name { get; set; }

	public Guid CreateUserId { get; set; }

	public DateTime? CreateTime { get; set; }

	public string? Remarks { get; set; }

	public virtual ICollection<RoleMenu>? RoleMenus { get; set; }
}