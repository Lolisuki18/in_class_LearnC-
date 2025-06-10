using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6_Dictionary
{
    public class Product
    {
        #region Khai báo thuộc tính
        public int id { get; set; }

        public string name { get; set; }

        public int quantity { get; set; }   

        public int price { get; set; }

        #endregion

        public override string ToString()
        {
            return $"{id}\t{name}\t{quantity}\t{price}";
        }
    }
}
