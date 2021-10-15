using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Models
{
    public class Transaction
    {
        [Key]
        public string UserID { get; set; }
        public string RealEstateID { get; set; }

        public string Profit { get; set; }
    }
}
