using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lesson1
{
    public class Deal
    {
        public int Sum { get; set; }
        public string Id { get; set; }
        public DateTime Date { get; set; }

        public Deal() 
        {
            Sum = 0;
            Id = string.Empty;
            Date = DateTime.MinValue;
        }
    }
}
