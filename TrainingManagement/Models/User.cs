using System.ComponentModel.DataAnnotations;

namespace TrainingManagement.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string   UserName { get; set; }
        //public string Password { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }

        //public Batch Batch { get; set; }
        //public Role Role { get; set; }
        public Role UserRole { get; set; }

       
        public int ManagerId { get; set; }

        //public virtual User? Manager { get; set; }

        [DataType(DataType.Password)]   
        public string Password { get; set; }

    }
    public enum Role
    {
        Manager = 1,
        Employee = 2

    }
}
