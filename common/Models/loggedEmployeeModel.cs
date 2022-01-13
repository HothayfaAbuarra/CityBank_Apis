using System;
using System.Collections.Generic;
using System.Text;

namespace common
{
    public class loggedEmployeeModel
    {
        public Guid Employee_id { get; set; }

        public string Department_name { get; set; }
        public dynamic token { get; set; }
    }
}
