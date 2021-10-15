using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Models
{
    public class News
    {
        [Key]
        public string NewsID { get; set; }
        public string UserID { get; set; }

        public string NewsName { get; set; }

        public string Description { get; set; }
    }
}
