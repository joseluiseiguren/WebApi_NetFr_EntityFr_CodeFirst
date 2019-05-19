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
            AddGrade();



            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
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
    }
}
