using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseFirstApproach.Models
{
    public class Worker
    {
        public int Workerid { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }

    }
}