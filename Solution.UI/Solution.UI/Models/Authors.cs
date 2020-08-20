using System;
using System.Collections.Generic;

namespace Solution.UI.Models
{
    public partial class Authors
    {
        public int AuId { get; set; }
        public string AuLname { get; set; }
        public string AuFname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool Contract { get; set; }
    }
}
