using DIIS.PersonApp.Entities;
using DIIS.PersonApp.IServices;
using Microsoft.EntityFrameworkCore;

namespace DIIS.PersonApp.Services
{
    public class DevSampleService : IDevSampleService
    {
        private readonly ModelContext dbContext;
        public DevSampleService(ModelContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task InsertCustomer(DevSample Customer)
        {
            dbContext.DevSamples.Add(Customer);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteCustomer(decimal Id)
        {
            var customer = await GetCustomerById(Id);
            dbContext.DevSamples.Remove(customer);
            await dbContext.SaveChangesAsync();
        }


        public async Task<DevSample> GetCustomerById(decimal Id)
        {
            return await dbContext.DevSamples.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<DevSample>> GetCustomers()
        {
            return await dbContext.DevSamples.OrderBy(a => a.Id).ToListAsync();
        }

        public async Task UpdateCustomer(DevSample Customer)
        {
            dbContext.DevSamples.Update(Customer);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<DevSample>> GetCustomerByFullName(string FullName)
        {
            return await dbContext.DevSamples.Where(d => (d.CustFirstName + " " + d.CustLastName).Contains(FullName)).OrderBy(a => a.Id).ToListAsync();
        }
    }
}
