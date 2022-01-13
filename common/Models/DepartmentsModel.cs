using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace common
{
    public class DepartmentsModel
    {
        [Key]
        public int Department_id { get; set; }
        public string Department_name { get; set; }
    }
}
