using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogbookFE
{
    internal class Record
    {
        public int i_Id { get; set; }
        public string s_Nric { get; set; }
        public string s_Name { get; set; }
        public string s_Reason { get; set; }
        public DateTime dt_DateTimeIn { get; set; }
        public DateTime dt_DateTimeOut { get; set; }
    }
}
