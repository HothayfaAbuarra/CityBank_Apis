using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace common
{
    public class BankAccountsModel
    {
        [Key]
        public int BankAccount_id { get; set; }
        [ForeignKey("FK_Customer_id")]
        public Guid Customerscuid { get; set; }
        public string Account_type { get; set; }
        public string Account_Date { get; set; }
        public bool Account_Status { get; set; }
    }
}
