using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareModel
{
    public class CreateRatingRequest
    {
        public string ProductId { get; set; }

        public int value { get; set; }
    }
}
