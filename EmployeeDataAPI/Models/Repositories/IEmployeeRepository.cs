namespace EmployeeDataAPI.Models.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeParameters>> GetAllEmployees();
        Task<EmployeeParameters> GetEmployeeById(int employeeId);
        Task<EmployeeParameters> GetEmployeeByEmail(string email);
        Task<EmployeeParameters> AddEmployee(EmployeeParameters empParams);
        Task<EmployeeParameters> UpdateEmployee(int id,EmployeeParameters empParams);
        Task<EmployeeParameters> DeleteEmployee(int employeeId);
    }
}
