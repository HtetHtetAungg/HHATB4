using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHA_B4_ConsoleApp
{
    internal class ProductDto
    {
        public int MedicineId { get; set; }
        public string Name {  get; set; }
        public decimal Price { get; set; }
        public int Stock {  get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedBy { get; set; }
        public bool IsActive { get; set; }

    }


}
