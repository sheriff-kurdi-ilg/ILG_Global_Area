using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_Global.BussinessLogic.Models
{
    public class ContactInformationMaster
    {
        public int ID { get; set; }
        public string FontAwsomeIconCssClass { get; set; }
        public bool IsEnabled { get; set; }
        public string NavigationURL { get; set; }
        public bool IsClickable { get; set; }
        public List<ContactInformationDetail> ContactInformationDetails { get; set; }

    }
}
