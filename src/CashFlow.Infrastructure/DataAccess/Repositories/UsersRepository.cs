using CashFlow.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class UsersRepository : IUserReadOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;

    public UsersRepository(CashFlowDbContext dbContext) => _dbContext = dbContext;

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
    }
}
