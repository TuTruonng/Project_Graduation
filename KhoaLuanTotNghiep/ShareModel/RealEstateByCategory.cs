using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel
{
    public class RealEstateByCategory
    {
        public CategoryModel CategoryName { get; set; }

        public List<RealEstatefromCategory> realestates { get; set; }
    }
}
