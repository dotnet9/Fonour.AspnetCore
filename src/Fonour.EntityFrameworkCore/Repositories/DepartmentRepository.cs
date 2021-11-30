using Fonour.Domain.Entities;
using Fonour.Domain.IRepositories;

namespace Fonour.EntityFrameworkCore.Repositories;

public class DepartmentRepository : FonourRepositoryBase<Department>, IDepartmentRepository
{
	public DepartmentRepository(FonourDbContext dbcontext) : base(dbcontext)
	{
	}
}