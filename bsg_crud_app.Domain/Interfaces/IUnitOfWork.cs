namespace bsg_crud_app.Domain.Interfaces;

/// <summary>
/// Pattern to control database transactions
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Save all changes async
    /// </summary>
    /// <param name="cancellationToken"></param>
    Task Commit(CancellationToken cancellationToken);
}