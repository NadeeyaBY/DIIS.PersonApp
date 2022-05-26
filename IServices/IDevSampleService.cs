using DIIS.PersonApp.Entities;

namespace DIIS.PersonApp.IServices
{
    public interface IDevSampleService
    {
        Task<List<DevSample>> GetCustomers();
        Task<DevSample> GetCustomerById(decimal Id);
        Task<List<DevSample>> GetCustomerByFullName(string FullName);
        Task InsertCustomer(DevSample Customer);
        Task UpdateCustomer(DevSample Customer);
        Task DeleteCustomer(decimal Id);
    }
}
