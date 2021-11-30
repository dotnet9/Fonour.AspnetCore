using Fonour.Application.DepartmentApp.Dtos;
using Fonour.Application.MenuApp.Dtos;
using Fonour.Application.RoleApp.Dtos;
using Fonour.Application.UserApp.Dtos;
using Fonour.Domain.Entities;
using AutoMapper;

namespace Fonour.Application;

/// <summary>
///     Enity与Dto映射
/// </summary>
public class FonourMapper : Profile
{
	public FonourMapper()
	{
		CreateMap<Menu, MenuDto>().ReverseMap();
		CreateMap<Department, DepartmentDto>().ReverseMap();
		CreateMap<RoleDto, Role>().ReverseMap();
		CreateMap<RoleMenuDto, RoleMenu>().ReverseMap();
		CreateMap<UserDto, User>().ReverseMap();
		CreateMap<UserRoleDto, UserRole>().ReverseMap();
	}
}