using bsg_crud_app.Domain.Interfaces;
using bsg_crud_app.Infrastructure.Context;

namespace bsg_crud_app.Infrastructure.Repositories.Implementations;

/// <summary>
/// Pattern to control database transactions
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly CrudAppContext _context;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context"></param>
    public UnitOfWork(CrudAppContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Save all changes async
    /// </summary>
    /// <param name="cancellationToken"></param>
    public async Task Commit(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}