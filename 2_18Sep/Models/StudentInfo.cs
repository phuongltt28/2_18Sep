using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2_18Sep.Models
{
    public class StudentInfo
    {
        [Display(Name = "Mã số sinh viên")]
        [MaxLength(10, ErrorMessage = "10 kí tự")]
        public string Id { get; set; }

        [Display(Name = "Họ tên sinh viên")]
        [Required]
        public string Name { get; set; }
        
        [Display(Name = "Điểm")]
        [Range(0, 10)]
        public string GPA { get; set; }

    }
}
