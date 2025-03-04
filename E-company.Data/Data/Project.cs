using E_company.Data.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_company.Data
{
    /// <summary>
    /// Represents a project in the company.
    /// </summary>
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Project Name is required.")]
        [StringLength(100, ErrorMessage = "Project Name must be less than 100 characters.")]
        [Display(Name = "Project Name")]
        public required string ProjectName { get; set; }

        [Required(ErrorMessage = "Project Description is required.")]
        [StringLength(500, ErrorMessage = "Project Description must be less than 500 characters.")]
        [Display(Name = "Description")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateOnly StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateOnly? EndDate { get; set; }

        /// <summary>
        /// Navigation property for employees assigned to the project.
        /// </summary>
        public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }

 }
