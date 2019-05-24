using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_NetFr_EntityFr_CodeFirst.Models;

namespace WebApi_NetFr_EntityFr_CodeFirst.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            var ret = new List<string>();

            DeleteStudent();
            AddGrade();
            AddStudent();
            var students = GetStudents();
            foreach(var student in students)
            {
                ret.Add(student.StudentID.ToString() + " - " + student.StudentName);
            }

            return ret;
        }

        private void AddGrade()
        {
            using (var ctx = new SchoolContext())
            {
                var gradeId = 1;

                var lastGrade = ctx.Grades.OrderByDescending(p => p.GradeId).FirstOrDefault();
                if (lastGrade != null)
                {
                    gradeId = lastGrade.GradeId + 1;
                }

                var province = ctx.Provinces.Where(p => p.Description.Equals("Bcn")).FirstOrDefault();
                if (province == null)
                {
                    province = new Province()
                    {
                        Description = "Bcn"
                    };
                }

                var grade = new Grade()
                {
                    GradeName = "Grade Test " + gradeId.ToString(),
                    Section = "Bcn " + gradeId.ToString(),
                    Province = province
                };

                ctx.Grades.Add(grade);
                ctx.SaveChanges();

            }
        }

        private void AddStudent()
        {
            using (var ctx = new SchoolContext())
            {
                Student st = new Student()
                {
                    DateOfBirth = DateTime.UtcNow,
                    Grade = ctx.Grades.OrderByDescending(p => p.GradeId).FirstOrDefault(),
                    Height = 10,
                    Photo = null,
                    StudentName = GenerateName(new Random().Next(5, 10)),
                    Weight = 50
                };

                ctx.Students.Add(st);
                ctx.SaveChanges();

            }
        }

        private IEnumerable<Student> GetStudents()
        {
            using (var ctx = new SchoolContext())
            {
                return ctx.Students.OrderBy(p => p.StudentID).ToList();                

            }
        }

        private string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }

        private void DeleteStudent()
        {
            using (var ctx = new SchoolContext())
            {
                if (ctx.Students.ToList().Count < 20)
                {
                    return;
                }

                var students = ctx.Students.ToList();
                for (int i = 20; i > 0; i--)
                {
                    ctx.Students.Remove(students[i-1]);
                }
                
                ctx.SaveChanges();

            }
        }
    }
}
