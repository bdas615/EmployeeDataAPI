using System.ComponentModel.DataAnnotations;

namespace EmployeeDataAPI.Models
{
    public class EmployeeParameters
    {
        [Key]
        public int UserID { get; set; }
        public String Name { get; set; } = String.Empty;
        public String Email { get; set; } = String.Empty;
        public String Gender { get; set; } = String.Empty;
        public String Address { get; set; } = String.Empty;
        public String Phone { get; set; } = String.Empty;
        public DateTime JoiningDate { get; set; } 
        public DateTime CreatedOn { get; set; } 
    }
}
