using Microsoft.EntityFrameworkCore;
using Receipt.Domain.Entity;
using Receipt.Domain.Interfaces;
using Receipt.Infra.Data;
using System.Linq.Expressions;

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

        public async Task<IEnumerable<CustomerMaster>> GetDataFromDB(Expression<Func<CustomerMaster,bool>> expression=null)
        {
            if(expression == null)
            {
                return await dbContext.customerMasters.
                    Include(x=> x.CustomerDetails).
                    Include(x=> x.WingMaster).
                    Include(x=> x.WingDetail).
                    Include(x=>x.Site).
                    ToListAsync();
            }
            else
            {
                return await dbContext.customerMasters.Include(x => x.CustomerDetails).
                    Include(x => x.WingMaster).
                    Include(x => x.WingDetail).
                    Include(x => x.Site).
                    Where(expression).
                    ToListAsync();
            }
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
        public async Task<bool> DeActivate(int curentId)
        {
            var customer = await dbContext.customerMasters.SingleOrDefaultAsync(x=> x.CustomerMasterId==curentId);
            if (customer != null)
            {
                customer.IsActive = true;
                dbContext.customerMasters.Update(customer);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
