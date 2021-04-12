using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlanner.Models
{
    public class CourseViewModel
    {
        [Key]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Add Course Name")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public TeacherViewModel Teacher { get; set; }
    }
}
