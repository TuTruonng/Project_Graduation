using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Models
{
    public class Report
    {
        [Key]
        public string ReportID { get; set; }

        public string RealEstatetID { get; set; }

        public string Status { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public string IPAddress { get; set; }
    }
}
