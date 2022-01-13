using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace common
{
    public class Roles
    {
        [Key]
        public int Role_id { get; set; }
        public string Role_name { get; set; }
    }
}
