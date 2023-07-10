using EmployeeDataAPI.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDataAPI.Models.Repositories
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration configuration;
        private readonly EmpDbContextClass context;

        public EmployeeRepository(IConfiguration configuration, EmpDbContextClass empDbContextClass) 
        {
            this.configuration = configuration;
            this.context = empDbContextClass;
        }

        public async Task<IEnumerable<EmployeeParameters>> GetAllEmployees()
        {
            return await context.EmployeeData.ToListAsync();
        }

        public async Task<EmployeeParameters> AddEmployee(EmployeeParameters empParams)
        {
            var result = await context.AddAsync(empParams);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<EmployeeParameters> DeleteEmployee(int employeeId)
        {
            var result = await context.EmployeeData.FirstOrDefaultAsync(e => e.UserID == employeeId);

            if(result != null) 
            {
                context.EmployeeData.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<EmployeeParameters> GetEmployeeByEmail(string email)
        {
            return await context.EmployeeData.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<EmployeeParameters> GetEmployeeById(int employeeId)
        {
            return await context.EmployeeData.FirstOrDefaultAsync(e => e.UserID == employeeId);
        }

        public async Task<EmployeeParameters> UpdateEmployee(int id, EmployeeParameters empParams)
        {
            //var result = await context.EmployeeData.FirstOrDefaultAsync(e => e.UserID == empParams.UserID);
            var result = await context.EmployeeData.FirstOrDefaultAsync(e => e.UserID == id);

            if (result != null) 
            {
                result.UserID = empParams.UserID;
                result.Name = empParams.Name;
                result.Email = empParams.Email;
                result.Gender = empParams.Gender;
                result.Phone = empParams.Phone;
                result.Address = empParams.Address;
                result.JoiningDate = empParams.JoiningDate;
                result.CreatedOn = empParams.CreatedOn;

                await context.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
