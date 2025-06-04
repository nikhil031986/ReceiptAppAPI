using Receipt.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Domain.Interfaces
{
    public interface ICustomerRepositories
    {
        Task<CustomerMaster> AddCustomerAsync(CustomerMaster customer);
        Task<CustomerMaster> UpdateCustomerAsync(CustomerMaster customer);
        Task<bool> DeleteCustomerAsync(int customerId);
        Task<CustomerMaster> GetCustomerByIdAsync(int customerId);
        Task<IEnumerable<CustomerMaster>> GetAllCustomersAsync();
        Task<bool>DeActivateCustomer(int customerId);
    }
}
