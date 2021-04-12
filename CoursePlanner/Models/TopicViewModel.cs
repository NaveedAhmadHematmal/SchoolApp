using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlanner.Models
{
    public class TopicViewModel
    {
        [Key]
        public int TopicId { get; set; }
        [Required(ErrorMessage = "Add Topic")]
        [Display(Name = "Topic")]
        public string Topic { get; set; }
        [Display(Name = "Details")]
        public string Details { get; set; }
        [Display(Name = "CodeSnippets Link")]
        [DataType(DataType.Url)]
        public string CodeSnippetsLink { get; set; }
        [Display(Name = "Assignment Link")]
        [DataType(DataType.Url)]
        public string Assignment { get; set; }
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }
        public CourseViewModel Course { get; set; }
    }
}
