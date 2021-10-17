using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel
{
    
   public class UserModel
    {
        public string UserId { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public DateTime? JoinedDate { get; set; }

        public string RoleName { get; set; }


        public bool Status { get; set; }
    }
}
