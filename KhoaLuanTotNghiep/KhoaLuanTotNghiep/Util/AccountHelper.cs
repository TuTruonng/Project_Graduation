using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Util
{
    public class AccountHelper
    {
        public static string GenerateAccountPass(string userName, DateTime dateBirth)
        {
            return userName + "@" + dateBirth.ToString("ddMMyyyy");
        }
    }
}
