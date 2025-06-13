using Microsoft.EntityFrameworkCore;
using Receipt.Domain.Entity;
using Receipt.Domain.Interfaces;
using Receipt.Infra.Data;

namespace Receipt.Infra.Repositories
{
    public class CustomerRepositories(AppDbContext dbContext) : ICustomerRepositories
    {
        public async Task<CustomerMaster> AddCustomerAsync(CustomerMaster customer)
        {
            await dbContext.customerMasters.AddAsync(customer);
            await dbContext.SaveChangesAsync();
            foreach (CustomerDetail cd in customer.CustomerDetails)
            {
                cd.CustomerId = customer.CustomerMasterId; // Ensure the foreign key is set
                await dbContext.customerDetails.AddAsync(cd);
            }
            return customer;
        }

        public async Task<CustomerMaster> UpdateCustomerAsync(CustomerMaster customer)
        {
            dbContext.customerMasters.Update(customer);
            foreach (CustomerDetail cd in customer.CustomerDetails)
            {
                dbContext.customerDetails.Update(cd);
            }
            await dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            var customer = await dbContext.customerMasters.FindAsync(customerId);
            if (customer != null)
            {
                var customerDetails = await dbContext.customerDetails.FindAsync(customerId);
                if (customerDetails != null)
                {
                   dbContext.customerDetails.RemoveRange(customerDetails);
                }
                dbContext.customerMasters.Remove(customer);
                return true;
            }
            return false;
        }

        public async Task<CustomerMaster> GetCustomerByIdAsync(int customerId)
        {
            return await dbContext.customerMasters.
                Include(c => c.CustomerDetails).
                Include(w => w.WingMaster).
                Include(i => i.WingDetail).
                SingleOrDefaultAsync(x => x.CustomerMasterId == customerId);
        }

        public async Task<IEnumerable<CustomerMaster>> GetAllCustomersAsync()
        {
            return await dbContext.customerMasters.
                Include(c => c.CustomerDetails).
                Include(w => w.WingMaster).
                Include(i => i.WingDetail).ToListAsync();
        }

        public async Task<bool> DeActivateCustomer(int curentId)
        {
            var customer = await dbContext.customerMasters.SingleOrDefaultAsync(x=> x.CustomerMasterId==curentId);
            if (customer != null)
            {
                customer.IsActive = "0";
                dbContext.customerMasters.Update(customer);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
