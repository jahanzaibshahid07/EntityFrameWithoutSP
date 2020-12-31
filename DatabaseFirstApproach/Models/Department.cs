using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseFirstApproach.Models
{
    public class Department
    {
        public int Departmentid { get; set; }
        public string  Name { get; set; }
        public ICollection<Worker> workers { get; set; }

    }
}