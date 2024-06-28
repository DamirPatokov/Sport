using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport
{
    public class SalesReportItem
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
