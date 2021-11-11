using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ILG_Global.BussinessLogic.Models
{
    public class ContactInformationDetail
    {
        public int ContactInformationID { get; set; }
        [ForeignKey("ContactInformationID")]
        public ContactInformationMaster ContactInformationMaster { get; set; }

        public string LanguageCode { get; set; }
        [ForeignKey("LanguageCode")]
        public Language Language { get; set; }

        public string Text { get; set; }
   
    }
}
