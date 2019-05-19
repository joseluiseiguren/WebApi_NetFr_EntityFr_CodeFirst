using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_NetFr_EntityFr_CodeFirst.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual Province Province { get; set; }
    }
}