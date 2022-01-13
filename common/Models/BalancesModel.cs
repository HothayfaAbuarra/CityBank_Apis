using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace common
{
    public class BalancesModel
    {
        [Key]
        public int Balance_id { get; set; }
        public double balance { get; set; }
        public int Account_id { get; set; }
    }
}
