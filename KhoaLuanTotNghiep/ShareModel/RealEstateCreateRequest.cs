using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel
{
    public class RealEstateCreateRequest
    {
        public int CategoryID { get; set; }

    
        public string Title { get; set; }

        public string Price { get; set; }

        public string Image { get; set; }

      
    }
}
