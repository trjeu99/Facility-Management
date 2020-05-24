using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Car : FullAuditModel
    {
        public string CarID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
