using Receipt.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Domain.Interfaces
{
    public interface ICustomerRepositories:ICommonFunction<CustomerMaster>
    {
        Task<CustomerMaster> AddCustomerAsync(CustomerMaster customer);
        Task<CustomerMaster> UpdateCustomerAsync(CustomerMaster customer);
        Task<bool> DeleteCustomerAsync(int customerId);
        Task<CustomerMaster> GetCustomerByIdAsync(int customerId);
    }
}
