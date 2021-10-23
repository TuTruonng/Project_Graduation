using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Models
{
    public class Rate
    {
        [Key]
        public int idRate { get; set; }

        public int Value { get; set; }

        public string RealEstateId { get; set; }

        public string UserId { get; set; }
    }
}
