using System.ComponentModel.DataAnnotations;

namespace EmployeeDataAPI.Models
{
    public class SignUp
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public String Email { get; set; }
        public String Gender { get; set; }
        public string Pwd { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
