using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlanner.Models
{
    public class TeacherViewModel
    {
        [Key]
        public int TeacherId { get; set; }
        [Required(ErrorMessage = "Add Teacher FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
