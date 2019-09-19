using System;
using System.Collections.Generic;
using System.Text;

namespace QUTCal
{
    class Item
    {
        public string UnitCode { get; set; }
        public string Description { get; set; }

        public Item(string unitCode, string description)
        {
            UnitCode = unitCode;
            Description = description;
        }
    }
}
