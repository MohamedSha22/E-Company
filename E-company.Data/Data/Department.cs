using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_company.Data
{
    /// <summary>
    /// Represents a department in the company.
    /// </summary>
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Name is required.")]
        [StringLength(100, ErrorMessage = "Department Name must be less than 100 characters.")]
        [Display(Name = "Department Name")]
        public required string DepartmentName { get; set; }

        [Required(ErrorMessage = "Manager ID is required.")]
        [ForeignKey("Manager")]
        [Display(Name = "Manager ID")]
        public int ManagerId { get; set; }

        /// <summary>
        /// Navigation property for the department manager.
        /// </summary>
        public Employee? Manager { get; set; }

        /// <summary>
        /// Navigation property for employees within the department.
        /// </summary>
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
