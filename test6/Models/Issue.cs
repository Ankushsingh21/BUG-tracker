using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test6.Models
{
    public class Issue
    {
        [Key]
        public string ProjectName { get; set; }
        [Required]
        public string Discription { get; set; }

        [Required]
        public string Severity { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
