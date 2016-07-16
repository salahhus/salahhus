using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace SimpleApplicationMVC.Models
{
    /// <summary>
    /// Class Employer
    /// </summary>
   public class Employer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Occupation { get; set; }
        public decimal Salary { get; set; }
        public class EmployerDbModel : DbContext
        {
            public DbSet<Employer> Employers { get; set; }
        }
    }
}