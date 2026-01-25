using Microsoft.EntityFrameworkCore;
using Receipt.Domain.Entity;
using Receipt.Domain.Interfaces;
using Receipt.Infra.CommonFunction;
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

        public async Task<IEnumerable<CustomerMaster>> GetDataFromDB(Expression<Func<CustomerMaster, bool>> expression = null)
        {
            if (expression == null)
            {
                return await dbContext.customerMasters.
                    Include(x => x.CustomerDetails).
                    Include(x => x.WingMaster).
                    Include(x => x.WingDetail).
                    Include(x => x.Site).
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
                cd.SiteId = customer.SiteId;
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
            var customer = await dbContext.customerMasters.SingleOrDefaultAsync(x => x.CustomerMasterId == curentId);
            if (customer != null)
            {
                customer.IsActive = true;
                dbContext.customerMasters.Update(customer);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CustomerDetail> GetCustomerDetail(int customerDetailId)
        {
            CustomerDetail customerDetails = await dbContext.customerDetails.
                                        Where(x => x.CustomerDetailsId == customerDetailId).FirstOrDefaultAsync();
            return customerDetails;
        }
        public async Task<bool> DeleteCustomerDetail(int customerDetailId)
        {
            var customerDetail = await dbContext.customerDetails.SingleOrDefaultAsync(x => x.CustomerDetailsId == customerDetailId);
            if (customerDetail != null)
            {
                customerDetail.IsActive = true;
                dbContext.customerDetails.Update(customerDetail);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<CustomerDetail> AddUpdateCustomerDetail(CustomerDetail customerdetail)
        {
            var customerDetail = await dbContext.customerDetails.SingleOrDefaultAsync(x => x.CustomerDetailsId == customerdetail.CustomerDetailsId);
            if (customerDetail != null)
            {
                PropertyUpdater.UpdateMatchingProperty(customerDetail, customerdetail);
                customerDetail.UpdatedAt = DateTime.Now.ToString("dd/MM/yyyy");
                customerDetail.UpdateuserId = 1;
                dbContext.customerDetails.Update(customerDetail);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                customerDetail = new CustomerDetail();
                PropertyUpdater.UpdateMatchingProperty(customerDetail, customerdetail);
                customerDetail.CreatedAt = DateTime.Now.ToString("dd/MM/yyyy");
                customerDetail.CreateuserId = 1;
                await dbContext.customerDetails.AddAsync(customerDetail);
                await dbContext.SaveChangesAsync();
            }
            return customerDetail;
        }
    }
}
