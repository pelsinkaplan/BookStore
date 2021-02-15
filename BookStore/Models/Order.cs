using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double PayAmount { get; set; }
        public int CardNum { get; set; }
        public int DateMounth { get; set; }
        public int DateYear { get; set; }
        public int CVC { get; set; }
    }
}
