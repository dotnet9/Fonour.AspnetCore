using Fonour.Domain.Entities;
using Fonour.Domain.IRepositories;

namespace Fonour.EntityFrameworkCore.Repositories;

public class MenuRepository : FonourRepositoryBase<Menu>, IMenuRepository
{
	public MenuRepository(FonourDbContext dbcontext) : base(dbcontext)
	{
	}
}