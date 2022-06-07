using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCEntityFramework.Models
{
    [Table("EmployeeTable")]
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Column("FirstName")]
        [Required(ErrorMessage ="FirstName is Required Field.")]
        [MaxLength(20, ErrorMessage = "FirstName should not be more than 20 characters.")]
        [MinLength(3)]
        [Display(Name = "First Name")]
        public string EmpFirstName { get; set; }

        [Column("LastName")]
        [Required(ErrorMessage = "LastName is Required Field.")]
        [MaxLength(20, ErrorMessage = "LastName should not be more than 20 characters.")]
        [MinLength(3)]
        [Display(Name = "Last Name")]
        public string EmpLastName { get; set; }

        [Column("EmailAddress")]
        [Required(ErrorMessage = "Email is Required Field.")]
        [MaxLength(40,ErrorMessage ="Email Address should not be more than 40 characters.")]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage ="Enter Valid Email")]
        [Display(Name = "Email Address")]
        public string EmpEmail { get; set; }

        public decimal Salary { get; set; }
    }
}