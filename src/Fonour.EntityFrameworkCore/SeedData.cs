using Fonour.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fonour.EntityFrameworkCore;

public static class SeedData
{
	public static void Seed(this ModelBuilder modelBuilder)
	{
		//增加一个部门
		var department = new Department
		{
			Id = Guid.NewGuid(),
			Code = "001",
			Name = "Fonour集团总部",
			ParentId = Guid.Empty
		};
		modelBuilder.Entity<Department>().HasData(department);
		//增加一个角色
		var superRole = new Role
		{
			Id = Guid.NewGuid(),
			Code = "001",
			Name = "超级管理员"
		};
		modelBuilder.Entity<Role>().HasData(superRole);
		//增加一个超级管理员用户
		var adminUser = new User
		{
			Id = Guid.NewGuid(),
			UserName = "admin",
			Password = "123456", //暂不进行加密
			Name = "超级管理员",
			DepartmentId = department.Id
		};
		modelBuilder.Entity<User>().HasData(adminUser);
		//增加一个用户角色
		var userRole = new UserRole
		{
			UserId = adminUser.Id,
			RoleId = superRole.Id
		};
		modelBuilder.Entity<UserRole>().HasData(userRole);
		var lstMenus = new List<Menu>
		{
			new()
			{
				Id = Guid.NewGuid(),
				Name = "组织机构管理",
				Code = "Department",
				SerialNumber = 0,
				ParentId = Guid.Empty,
				Icon = "fa fa-link",
				Url = "/Department/Index"
			},
			new()
			{
				Id = Guid.NewGuid(),
				Name = "角色管理",
				Code = "Role",
				SerialNumber = 1,
				ParentId = Guid.Empty,
				Icon = "fa fa-link",
				Url = "/Role/Index"
			},
			new()
			{
				Id = Guid.NewGuid(),
				Name = "用户管理",
				Code = "User",
				SerialNumber = 2,
				ParentId = Guid.Empty,
				Icon = "fa fa-link",
				Url = "/User/Index"
			},
			new()
			{
				Id = Guid.NewGuid(),
				Name = "功能管理",
				Code = "Department",
				SerialNumber = 3,
				ParentId = Guid.Empty,
				Icon = "fa fa-link",
				Url = "/Menu/Index"
			}
		};
		//增加四个基本功能菜单
		modelBuilder.Entity<Menu>().HasData(lstMenus);
		//增加角色菜单
		var lstRoleMenu = lstMenus.ConvertAll(cu => new RoleMenu { RoleId = userRole.RoleId, MenuId = cu.Id });
		modelBuilder.Entity<RoleMenu>().HasData(lstRoleMenu);
	}
}