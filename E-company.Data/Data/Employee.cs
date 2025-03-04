using E_company.Data.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_company.Data
{
    /// <summary>
    /// Represents an Employee in the company.
    /// </summary>
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee Name is required.")]
        [StringLength(50, ErrorMessage = "Employee Name must be less than 50 characters.")]
        [Display(Name = "Name")]
        public required string EmployeeName { get; set; }

        [Required(ErrorMessage = "Job Title is required.")]
        [Display(Name = "Job Title")]
        public JobTitles Job { get; set; }

        [Required(ErrorMessage = "Employee Email is required.")]
        [StringLength(100, ErrorMessage = "Employee Email must be less than 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [Display(Name = "Email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Enter a valid Egyptian phone number (e.g., 01012345678).")]
        [StringLength(11, ErrorMessage = "Phone number must be 11 digits.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, 99999, ErrorMessage = "Salary must be between 0 and 99,999.")]
        [Display(Name = "Salary")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Hiring date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }

        /// <summary>
        /// Foreign key representing the department the employee belongs to.
        /// </summary>
        [Required(ErrorMessage = "Department is required.")]
        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Navigation property for the department.
        /// </summary>
        public Department? Department { get; set; }

        /// <summary>
        /// Navigation property for projects assigned to the employee.
        /// </summary>
        public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }

    /// <summary>
    /// Enumeration for job titles within the company.
    /// </summary>
    public enum JobTitles
    {
        DotNetDeveloper,
        AngularDeveloper,
        Tester,
        BusinessAnalyst,
        ProjectManager,
        ProductOwner
    }
}
