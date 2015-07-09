// -----------------------------------------------------------------------
// <copyright file="IAuthenticationRepository.cs" company="Nexcel Solutions Vietnam">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.Razorbill.Security.Repositories.Authentication
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IAuthenticationRepository
    {
        bool CheckingCustomerStatus(int customerId, int subAccountId);
    }
}
