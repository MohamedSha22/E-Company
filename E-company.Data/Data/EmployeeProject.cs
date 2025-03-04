using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace E_company.Data.Data
{
    /// <summary>
    /// Join table to represent the many-to-many relationship between Employees and Projects.
    /// </summary>
    public class EmployeeProject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [Required]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        /// <summary>
        /// Navigation property for Employee.
        /// </summary>
        public Employee Employee { get; set; } = null!;

        /// <summary>
        /// Navigation property for Project.
        /// </summary>
        public Project Project { get; set; } = null!;
    }

}
