using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlogs.Models
{
    public class Students
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(10), MinLength(3)]
        public string Name { get; set; }
        [Range(0, 150)]
        [Required]
        public int Age { get; set; }
    }
}