using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Models
{
    public class User : IdentityUser
    {
        public User() : base()
        {
        }

        public User(string userName) : base(userName)
        {
        }

        public decimal Salary { get; set; }

        public int Point { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? JoinedDate { get; set; }

        public bool? IsChange { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public ICollection<News> News { get; set; }


    }
}
