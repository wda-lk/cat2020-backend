using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT20.Core.Models.Control
{
    public partial class EmailConfiguration
    {
        public int ID { get; set; }
        public string SystemMailAddress { get; set; }
        public int? SystemMailPORT { get; set; }
        public string SystemMailSMTP { get; set; }
        public string SystemMailPassword { get; set; }
        public string SystemURL { get; set; }
    }
}
