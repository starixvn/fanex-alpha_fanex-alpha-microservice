// -----------------------------------------------------------------------
// <copyright file="ICustomerInfoRepository.cs" company="Nexcel Solution">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.Razorbill.Module.ContextualCustomer.Repositories.CustomerInfo
{
    public interface ICustomerInfoRepository
    {
        bool CheckingUsernameIsExisted(string username);
    }
}