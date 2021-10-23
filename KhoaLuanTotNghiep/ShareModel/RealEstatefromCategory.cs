using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel
{
    public class RealEstatefromCategory
    {
        public string RealEstateID { get; set; }

        public int CategoryID { get; set; }

        public string UserID { get; set; }
        
        public string CategoryName { get; set; }

        public string ReportID { get; set; }

        public string Title { get; set; }

        public string Price { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string acreage { get; set; }

        public int Approve { get; set; }

        public string Status { get; set; }

        public string Location { get; set; }


        //public List<RealEstatefromCategory> realestates { get; set; }
        ////public string CategoryName { get; set; }

        ////public List<RealEstateModel> realestates { get; set; }

        //public RealEstatefromCategory()
        //{
        //    realestates = new List<RealEstatefromCategory>();
        //}
    }
}
