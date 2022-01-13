using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace common
{
    public class Employees
    {
        [Key]
        public Guid Employee_id { get; set; }

        [ForeignKey("Department_id")]
        public int Department_id { get; set; }
        public int Role_id { get; set; }
        public string Employee_username { get; set; }
        public string Employee_password { get; set; }
        public string Employee_Email { get; set; }
        public int Employee_identity { get; set; }
        public int Employee_phone { get; set; }
        public bool Employee_Status { get; set; }
    }
}
