// -----------------------------------------------------------------------
// <copyright file="CustomerInfoService.cs" company="Nexcel Solution">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fanex.Razorbill.Module.ContextualCustomer.Services.CustomerInfo
{
    using Fanex.Razorbill.Module.ContextualCustomer.Repositories.CustomerInfo;

    /// <summary>
    /// Customer information service.
    /// </summary>
    public class CustomerInfoService : ICustomerInfoService
    {
        private ICustomerInfoRepository _customerInfoRepository;

        public CustomerInfoService() : this(null)
        {
        }

        public CustomerInfoService(CustomerInfoRepository customerInfoRepository)
        {
            _customerInfoRepository = _customerInfoRepository ?? new CustomerInfoRepository();
        }

        /// <summary>
        /// Function to check username is existed.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>Return status.</returns>
        public bool CheckingUsernameIsExisted(string username)
        {
            return _customerInfoRepository.CheckingUsernameIsExisted(username);
        }
    }
}